
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using QuanLyCuaHangThietBiCongNghe.DTO;

namespace QuanLyCuaHangThietBiCongNghe.DAL
{
    public class SanPhamDAL
    {
        // Sinh mã sản phẩm tiếp theo: SP001, SP002, SP003...
        // Bao gồm cả sản phẩm đã ngừng kinh doanh.
        public string GetNextProductCode()
        {
            string query = @"
                SELECT ISNULL(
                    MAX(TRY_CONVERT(INT, SUBSTRING(MaSanPham, 3, LEN(MaSanPham)))),
                    0
                ) + 1
                FROM SanPham
                WHERE MaSanPham LIKE 'SP[0-9]%';";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                int nextNumber = Convert.ToInt32(command.ExecuteScalar());

                return "SP" + nextNumber.ToString("D3");
            }
        }

        // Lấy toàn bộ sản phẩm đang kinh doanh.
        public DataTable GetAll()
        {
            DataTable dataTable = new DataTable();

            string query = @"
                SELECT
                    MaSanPham,
                    TenSanPham,
                    LoaiSanPham,
                    ThuongHieu,
                    DonViTinh,
                    GiaBan,
                    SoLuongTon,
                    MoTa,
                    TrangThai
                FROM SanPham
                WHERE TrangThai = 1
                ORDER BY TenSanPham;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // Lấy sản phẩm theo mã.
        public SanPhamDTO GetById(string maSanPham)
        {
            string query = @"
                SELECT
                    MaSanPham,
                    TenSanPham,
                    LoaiSanPham,
                    ThuongHieu,
                    DonViTinh,
                    GiaBan,
                    SoLuongTon,
                    MoTa,
                    TrangThai
                FROM SanPham
                WHERE MaSanPham = @MaSanPham;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@MaSanPham", SqlDbType.VarChar, 10)
                    .Value = maSanPham;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new SanPhamDTO
                        {
                            MaSanPham = reader["MaSanPham"].ToString() ?? string.Empty,
                            TenSanPham = reader["TenSanPham"].ToString() ?? string.Empty,
                            LoaiSanPham = reader["LoaiSanPham"].ToString() ?? string.Empty,
                            ThuongHieu = reader["ThuongHieu"].ToString() ?? string.Empty,
                            DonViTinh = reader["DonViTinh"].ToString() ?? string.Empty,
                            GiaBan = Convert.ToDecimal(reader["GiaBan"]),
                            SoLuongTon = Convert.ToInt32(reader["SoLuongTon"]),
                            MoTa = reader["MoTa"] == DBNull.Value
                                ? string.Empty
                                : reader["MoTa"].ToString() ?? string.Empty,
                            TrangThai = Convert.ToBoolean(reader["TrangThai"])
                        };
                    }
                }
            }

            return null;
        }

        // Thêm sản phẩm.
        // Số lượng tồn ban đầu = 0, trạng thái = đang kinh doanh.
        public bool Insert(SanPhamDTO sanPham)
        {
            string query = @"
                INSERT INTO SanPham
                (
                    MaSanPham,
                    TenSanPham,
                    LoaiSanPham,
                    ThuongHieu,
                    DonViTinh,
                    GiaBan,
                    SoLuongTon,
                    MoTa,
                    TrangThai
                )
                VALUES
                (
                    @MaSanPham,
                    @TenSanPham,
                    @LoaiSanPham,
                    @ThuongHieu,
                    @DonViTinh,
                    @GiaBan,
                    0,
                    @MoTa,
                    1
                );";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                AddProductParameters(command, sanPham);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật thông tin sản phẩm.
        // Không cập nhật số lượng tồn.
        public bool Update(SanPhamDTO sanPham)
        {
            string query = @"
                UPDATE SanPham
                SET
                    TenSanPham = @TenSanPham,
                    LoaiSanPham = @LoaiSanPham,
                    ThuongHieu = @ThuongHieu,
                    DonViTinh = @DonViTinh,
                    GiaBan = @GiaBan,
                    MoTa = @MoTa
                WHERE MaSanPham = @MaSanPham
                  AND TrangThai = 1;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                AddProductParameters(command, sanPham);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        // Ngừng kinh doanh: không xóa dữ liệu khỏi database.
        public bool StopBusiness(string maSanPham)
        {
            string query = @"
                UPDATE SanPham
                SET TrangThai = 0
                WHERE MaSanPham = @MaSanPham
                  AND TrangThai = 1;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@MaSanPham", SqlDbType.VarChar, 10)
                    .Value = maSanPham;

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        // Tìm kiếm sản phẩm đang kinh doanh.
        public DataTable Search(string keyword)
        {
            DataTable dataTable = new DataTable();

            string query = @"
                SELECT
                    MaSanPham,
                    TenSanPham,
                    LoaiSanPham,
                    ThuongHieu,
                    DonViTinh,
                    GiaBan,
                    SoLuongTon,
                    MoTa,
                    TrangThai
                FROM SanPham
                WHERE TrangThai = 1
                  AND
                  (
                      MaSanPham LIKE @Keyword
                      OR TenSanPham LIKE @Keyword
                      OR LoaiSanPham LIKE @Keyword
                      OR ThuongHieu LIKE @Keyword
                  )
                ORDER BY TenSanPham;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.Add("@Keyword", SqlDbType.NVarChar, 150)
                    .Value = "%" + (keyword ?? string.Empty).Trim() + "%";

                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // Khai báo tham số dùng chung cho thêm và cập nhật.
        private void AddProductParameters(
            SqlCommand command,
            SanPhamDTO sanPham)
        {
            command.Parameters.Add("@MaSanPham", SqlDbType.VarChar, 10)
                .Value = sanPham.MaSanPham;

            command.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 150)
                .Value = sanPham.TenSanPham;

            command.Parameters.Add("@LoaiSanPham", SqlDbType.NVarChar, 100)
                .Value = sanPham.LoaiSanPham;

            command.Parameters.Add("@ThuongHieu", SqlDbType.NVarChar, 100)
                .Value = sanPham.ThuongHieu;

            command.Parameters.Add("@DonViTinh", SqlDbType.NVarChar, 30)
                .Value = sanPham.DonViTinh;

            SqlParameter giaBanParameter =
                command.Parameters.Add("@GiaBan", SqlDbType.Decimal);

            giaBanParameter.Precision = 18;
            giaBanParameter.Scale = 2;
            giaBanParameter.Value = sanPham.GiaBan;

            command.Parameters.Add("@MoTa", SqlDbType.NVarChar, 500)
                .Value = string.IsNullOrWhiteSpace(sanPham.MoTa)
                    ? DBNull.Value
                    : sanPham.MoTa;
        }
    }
}

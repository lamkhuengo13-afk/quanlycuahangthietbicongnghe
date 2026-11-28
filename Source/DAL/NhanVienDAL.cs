using Microsoft.Data.SqlClient;
using System;
using System.Data;
using QuanLyCuaHangThietBiCongNghe.DTO;

namespace QuanLyCuaHangThietBiCongNghe.DAL
{
    public class NhanVienDAL
    {
        private const string DanhSachCot = @"
                    MaNhanVien,
                    HoTen,
                    NgaySinh,
                    GioiTinh,
                    SoDienThoai,
                    Email,
                    DiaChi,
                    NgayVaoLam,
                    TrangThai,
                    CASE WHEN TrangThai = 1 THEN N'Đang làm việc'
                         ELSE N'Ngừng hoạt động' END AS TrangThaiHienThi";

        // Sinh mã nhân viên tiếp theo: NV001, NV002, NV003...
        // Bao gồm cả nhân viên đã ngừng hoạt động.
        public string GetNextEmployeeCode()
        {
            string query = @"
                SELECT ISNULL(
                    MAX(TRY_CONVERT(INT, SUBSTRING(MaNhanVien, 3, LEN(MaNhanVien)))),
                    0
                ) + 1
                FROM NhanVien
                WHERE MaNhanVien LIKE 'NV[0-9]%';";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                int nextNumber = Convert.ToInt32(command.ExecuteScalar());

                return "NV" + nextNumber.ToString("D3");
            }
        }

        // Lấy toàn bộ nhân viên (cả đang làm việc và đã ngừng hoạt động).
        public DataTable GetAll()
        {
            DataTable dataTable = new DataTable();

            string query = "SELECT" + DanhSachCot + @"
                FROM NhanVien
                ORDER BY TrangThai DESC, MaNhanVien;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // Tìm nhân viên theo mã, họ tên hoặc số điện thoại.
        public DataTable Search(string keyword)
        {
            DataTable dataTable = new DataTable();

            string query = "SELECT" + DanhSachCot + @"
                FROM NhanVien
                WHERE MaNhanVien LIKE @Keyword
                   OR HoTen LIKE @Keyword
                   OR SoDienThoai LIKE @Keyword
                ORDER BY TrangThai DESC, MaNhanVien;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.Add("@Keyword", SqlDbType.NVarChar, 120)
                    .Value = "%" + (keyword ?? string.Empty).Trim() + "%";

                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // Nhân viên đang làm việc và chưa có tài khoản (dùng cho Form đăng kí).
        public DataTable GetEmployeesWithoutAccount()
        {
            DataTable dataTable = new DataTable();

            string query = @"
                SELECT
                    nv.MaNhanVien,
                    nv.MaNhanVien + N' - ' + nv.HoTen AS HienThi
                FROM NhanVien nv
                WHERE nv.TrangThai = 1
                  AND NOT EXISTS
                  (
                      SELECT 1
                      FROM TaiKhoan tk
                      WHERE tk.MaNhanVien = nv.MaNhanVien
                  )
                ORDER BY nv.MaNhanVien;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // Lấy nhân viên theo mã.
        public NhanVienDTO GetById(string maNhanVien)
        {
            string query = @"
                SELECT
                    MaNhanVien,
                    HoTen,
                    NgaySinh,
                    GioiTinh,
                    SoDienThoai,
                    Email,
                    DiaChi,
                    NgayVaoLam,
                    TrangThai
                FROM NhanVien
                WHERE MaNhanVien = @MaNhanVien;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@MaNhanVien", SqlDbType.VarChar, 10)
                    .Value = maNhanVien;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NhanVienDTO
                        {
                            MaNhanVien = reader["MaNhanVien"].ToString() ?? string.Empty,
                            HoTen = reader["HoTen"].ToString() ?? string.Empty,
                            NgaySinh = reader["NgaySinh"] == DBNull.Value
                                ? null
                                : Convert.ToDateTime(reader["NgaySinh"]),
                            GioiTinh = reader["GioiTinh"] == DBNull.Value
                                ? string.Empty
                                : reader["GioiTinh"].ToString() ?? string.Empty,
                            SoDienThoai = reader["SoDienThoai"].ToString() ?? string.Empty,
                            Email = reader["Email"] == DBNull.Value
                                ? string.Empty
                                : reader["Email"].ToString() ?? string.Empty,
                            DiaChi = reader["DiaChi"] == DBNull.Value
                                ? string.Empty
                                : reader["DiaChi"].ToString() ?? string.Empty,
                            NgayVaoLam = Convert.ToDateTime(reader["NgayVaoLam"]),
                            TrangThai = Convert.ToBoolean(reader["TrangThai"])
                        };
                    }
                }
            }

            return null;
        }

        // Kiểm tra số điện thoại đã được nhân viên khác sử dụng chưa.
        // maBoQua: mã của chính nhân viên đang sửa (null khi thêm mới).
        public bool IsPhoneExists(string soDienThoai, string maBoQua)
        {
            string query = @"
                SELECT COUNT(*)
                FROM NhanVien
                WHERE SoDienThoai = @SoDienThoai
                  AND (@MaBoQua IS NULL OR MaNhanVien <> @MaBoQua);";

            return CountExists(query, "@SoDienThoai", SqlDbType.VarChar, 15, soDienThoai, maBoQua);
        }

        // Kiểm tra email đã được nhân viên khác sử dụng chưa.
        public bool IsEmailExists(string email, string maBoQua)
        {
            string query = @"
                SELECT COUNT(*)
                FROM NhanVien
                WHERE Email = @Email
                  AND (@MaBoQua IS NULL OR MaNhanVien <> @MaBoQua);";

            return CountExists(query, "@Email", SqlDbType.NVarChar, 254, email, maBoQua);
        }

        // Thêm nhân viên, trạng thái mặc định = đang làm việc.
        public bool Insert(NhanVienDTO nhanVien)
        {
            string query = @"
                INSERT INTO NhanVien
                (
                    MaNhanVien,
                    HoTen,
                    NgaySinh,
                    GioiTinh,
                    SoDienThoai,
                    Email,
                    DiaChi,
                    NgayVaoLam,
                    TrangThai
                )
                VALUES
                (
                    @MaNhanVien,
                    @HoTen,
                    @NgaySinh,
                    @GioiTinh,
                    @SoDienThoai,
                    @Email,
                    @DiaChi,
                    @NgayVaoLam,
                    1
                );";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                AddEmployeeParameters(command, nhanVien);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật thông tin nhân viên.
        // Không đổi trạng thái ở đây; ngừng hoạt động dùng hàm StopWorking.
        public bool Update(NhanVienDTO nhanVien)
        {
            string query = @"
                UPDATE NhanVien
                SET
                    HoTen = @HoTen,
                    NgaySinh = @NgaySinh,
                    GioiTinh = @GioiTinh,
                    SoDienThoai = @SoDienThoai,
                    Email = @Email,
                    DiaChi = @DiaChi,
                    NgayVaoLam = @NgayVaoLam
                WHERE MaNhanVien = @MaNhanVien;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                AddEmployeeParameters(command, nhanVien);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        // Ngừng hoạt động: không xóa dữ liệu khỏi database.
        // Đồng thời khóa tài khoản của nhân viên (nếu có) trong cùng một giao dịch.
        public bool StopWorking(string maNhanVien)
        {
            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int soDong;

                        using (SqlCommand command = new SqlCommand(@"
                            UPDATE NhanVien
                            SET TrangThai = 0
                            WHERE MaNhanVien = @MaNhanVien
                              AND TrangThai = 1;", connection, transaction))
                        {
                            command.Parameters.Add("@MaNhanVien", SqlDbType.VarChar, 10)
                                .Value = maNhanVien;

                            soDong = command.ExecuteNonQuery();
                        }

                        if (soDong == 0)
                        {
                            transaction.Rollback();
                            return false;
                        }

                        using (SqlCommand command = new SqlCommand(@"
                            UPDATE TaiKhoan
                            SET TrangThai = 0
                            WHERE MaNhanVien = @MaNhanVien;", connection, transaction))
                        {
                            command.Parameters.Add("@MaNhanVien", SqlDbType.VarChar, 10)
                                .Value = maNhanVien;

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Cho nhân viên làm việc trở lại (tài khoản vẫn giữ trạng thái khóa,
        // người quản lý tự mở lại nếu cần).
        public bool Reactivate(string maNhanVien)
        {
            string query = @"
                UPDATE NhanVien
                SET TrangThai = 1
                WHERE MaNhanVien = @MaNhanVien
                  AND TrangThai = 0;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@MaNhanVien", SqlDbType.VarChar, 10)
                    .Value = maNhanVien;

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        // Khai báo tham số dùng chung cho thêm và cập nhật.
        private void AddEmployeeParameters(
            SqlCommand command,
            NhanVienDTO nhanVien)
        {
            command.Parameters.Add("@MaNhanVien", SqlDbType.VarChar, 10)
                .Value = nhanVien.MaNhanVien;

            command.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100)
                .Value = nhanVien.HoTen;

            command.Parameters.Add("@NgaySinh", SqlDbType.Date)
                .Value = nhanVien.NgaySinh.HasValue
                    ? nhanVien.NgaySinh.Value.Date
                    : DBNull.Value;

            command.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 10)
                .Value = string.IsNullOrWhiteSpace(nhanVien.GioiTinh)
                    ? DBNull.Value
                    : nhanVien.GioiTinh;

            command.Parameters.Add("@SoDienThoai", SqlDbType.VarChar, 15)
                .Value = nhanVien.SoDienThoai;

            command.Parameters.Add("@Email", SqlDbType.NVarChar, 254)
                .Value = string.IsNullOrWhiteSpace(nhanVien.Email)
                    ? DBNull.Value
                    : nhanVien.Email;

            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 255)
                .Value = string.IsNullOrWhiteSpace(nhanVien.DiaChi)
                    ? DBNull.Value
                    : nhanVien.DiaChi;

            command.Parameters.Add("@NgayVaoLam", SqlDbType.Date)
                .Value = nhanVien.NgayVaoLam.Date;
        }

        private bool CountExists(
            string query,
            string tenThamSo,
            SqlDbType kieu,
            int doDai,
            string giaTri,
            string maBoQua)
        {
            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add(tenThamSo, kieu, doDai).Value = giaTri;

                command.Parameters.Add("@MaBoQua", SqlDbType.VarChar, 10)
                    .Value = string.IsNullOrWhiteSpace(maBoQua)
                        ? DBNull.Value
                        : maBoQua;

                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }
    }
}

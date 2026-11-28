using Microsoft.Data.SqlClient;
using System;
using System.Data;
using QuanLyCuaHangThietBiCongNghe.DTO;

namespace QuanLyCuaHangThietBiCongNghe.DAL
{
    public class TaiKhoanDAL
    {
        // Kiểm tra tên đăng nhập đã tồn tại chưa (UQ_TaiKhoan_TenDangNhap).
        public bool IsUsernameExists(string tenDangNhap)
        {
            string query = @"
                SELECT COUNT(*)
                FROM TaiKhoan
                WHERE TenDangNhap = @TenDangNhap;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TenDangNhap", SqlDbType.VarChar, 50)
                    .Value = tenDangNhap;

                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        // Kiểm tra nhân viên đã có tài khoản chưa (UQ_TaiKhoan_MaNhanVien).
        public bool HasAccount(string maNhanVien)
        {
            string query = @"
                SELECT COUNT(*)
                FROM TaiKhoan
                WHERE MaNhanVien = @MaNhanVien;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@MaNhanVien", SqlDbType.VarChar, 10)
                    .Value = maNhanVien;

                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        // Lấy tài khoản theo tên đăng nhập (dùng cho Form đăng nhập).
        public TaiKhoanDTO GetByUsername(string tenDangNhap)
        {
            string query = @"
                SELECT
                    MaTaiKhoan,
                    MaNhanVien,
                    TenDangNhap,
                    MatKhauHash,
                    VaiTro,
                    TrangThai,
                    NgayTao
                FROM TaiKhoan
                WHERE TenDangNhap = @TenDangNhap;";

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TenDangNhap", SqlDbType.VarChar, 50)
                    .Value = tenDangNhap;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TaiKhoanDTO
                        {
                            MaTaiKhoan = reader["MaTaiKhoan"].ToString() ?? string.Empty,
                            MaNhanVien = reader["MaNhanVien"].ToString() ?? string.Empty,
                            TenDangNhap = reader["TenDangNhap"].ToString() ?? string.Empty,
                            MatKhauHash = reader["MatKhauHash"].ToString() ?? string.Empty,
                            VaiTro = reader["VaiTro"].ToString() ?? string.Empty,
                            TrangThai = Convert.ToBoolean(reader["TrangThai"]),
                            NgayTao = Convert.ToDateTime(reader["NgayTao"])
                        };
                    }
                }
            }

            return null;
        }

        // Thêm tài khoản. Mã tài khoản (TK001, TK002...) được sinh trong
        // cùng giao dịch với lệnh INSERT, khóa bảng trong lúc sinh mã
        // để hai người tạo cùng lúc không bị trùng mã.
        public bool Insert(TaiKhoanDTO taiKhoan)
        {
            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            {
                connection.Open();

                using (SqlTransaction transaction =
                    connection.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(@"
                            SELECT ISNULL(
                                MAX(TRY_CONVERT(INT, SUBSTRING(MaTaiKhoan, 3, LEN(MaTaiKhoan)))),
                                0
                            ) + 1
                            FROM TaiKhoan WITH (UPDLOCK, HOLDLOCK)
                            WHERE MaTaiKhoan LIKE 'TK[0-9]%';", connection, transaction))
                        {
                            int nextNumber = Convert.ToInt32(command.ExecuteScalar());
                            taiKhoan.MaTaiKhoan = "TK" + nextNumber.ToString("D3");
                        }

                        int soDong;

                        using (SqlCommand command = new SqlCommand(@"
                            INSERT INTO TaiKhoan
                            (
                                MaTaiKhoan,
                                MaNhanVien,
                                TenDangNhap,
                                MatKhauHash,
                                VaiTro,
                                TrangThai,
                                NgayTao
                            )
                            VALUES
                            (
                                @MaTaiKhoan,
                                @MaNhanVien,
                                @TenDangNhap,
                                @MatKhauHash,
                                @VaiTro,
                                @TrangThai,
                                @NgayTao
                            );", connection, transaction))
                        {
                            command.Parameters.Add("@MaTaiKhoan", SqlDbType.VarChar, 10)
                                .Value = taiKhoan.MaTaiKhoan;
                            command.Parameters.Add("@MaNhanVien", SqlDbType.VarChar, 10)
                                .Value = taiKhoan.MaNhanVien;
                            command.Parameters.Add("@TenDangNhap", SqlDbType.VarChar, 50)
                                .Value = taiKhoan.TenDangNhap;
                            command.Parameters.Add("@MatKhauHash", SqlDbType.NVarChar, 255)
                                .Value = taiKhoan.MatKhauHash;
                            command.Parameters.Add("@VaiTro", SqlDbType.VarChar, 20)
                                .Value = taiKhoan.VaiTro;
                            command.Parameters.Add("@TrangThai", SqlDbType.Bit)
                                .Value = taiKhoan.TrangThai;
                            command.Parameters.Add("@NgayTao", SqlDbType.DateTime2)
                                .Value = taiKhoan.NgayTao;

                            soDong = command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return soDong > 0;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}

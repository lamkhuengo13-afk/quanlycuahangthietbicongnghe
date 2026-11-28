
using System;
using System.Security.Cryptography;

namespace QuanLyCuaHangThietBiCongNghe.BUS
{
    // Băm mật khẩu có Salt bằng PBKDF2-SHA256 (có sẵn trong .NET, không cần cài thêm gói).
    // Chuỗi lưu vào cột MatKhauHash: PBKDF2$<số vòng lặp>$<salt base64>$<hash base64>
    // (khoảng 83 ký tự, vừa với NVARCHAR(255)).
    public static class MatKhauHelper
    {
        private const int DoDaiSalt = 16;
        private const int DoDaiHash = 32;
        private const int SoVongLap = 100000;

        // Băm mật khẩu trước khi lưu (dùng ở Form đăng kí).
        public static string HashPassword(string matKhau)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(DoDaiSalt);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                matKhau,
                salt,
                SoVongLap,
                HashAlgorithmName.SHA256,
                DoDaiHash);

            return "PBKDF2$" + SoVongLap + "$"
                + Convert.ToBase64String(salt) + "$"
                + Convert.ToBase64String(hash);
        }

        // So mật khẩu người dùng nhập với giá trị đã lưu (dùng ở Form đăng nhập).
        public static bool VerifyPassword(string matKhau, string matKhauHash)
        {
            if (string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(matKhauHash))
                return false;

            string[] phan = matKhauHash.Split('$');

            if (phan.Length != 4
                || phan[0] != "PBKDF2"
                || !int.TryParse(phan[1], out int soVongLap))
                return false;

            try
            {
                byte[] salt = Convert.FromBase64String(phan[2]);
                byte[] hashDaLuu = Convert.FromBase64String(phan[3]);

                byte[] hashNhapVao = Rfc2898DeriveBytes.Pbkdf2(
                    matKhau,
                    salt,
                    soVongLap,
                    HashAlgorithmName.SHA256,
                    hashDaLuu.Length);

                return CryptographicOperations.FixedTimeEquals(hashNhapVao, hashDaLuu);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}

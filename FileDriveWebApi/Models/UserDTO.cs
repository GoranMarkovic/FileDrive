using System.Text.Json.Serialization;

namespace FileDriveWebApi.Models
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;

        public byte[] ConvertToByteArray(string value)
        {
            return System.Text.Encoding.UTF8.GetBytes(value);
        }

    }
}

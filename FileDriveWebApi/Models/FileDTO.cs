namespace FileDriveWebApi.Models
{
    public class FileDTO
    {
        public int FileId { get; set; }

        public string Filename { get; set; } = null!;

        public double Filesize { get; set; }

        public int UserId { get; set; }

    }
}

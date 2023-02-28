using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FileDriveWebApi.Models;

public partial class File
{
    public int FileId { get; set; }

    public string Filename { get; set; } = null!;

    public double Filesize { get; set; }

    public int UserId { get; set; }
    [JsonIgnore]
    public virtual ICollection<SharedFile> SharedFiles { get; } = new List<SharedFile>();
    [JsonIgnore]
    public virtual User User { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FileDriveWebApi.Models;

public partial class SharedFile
{
    public int SharedFileId { get; set; }

    public int FileId { get; set; }

    public int UserId { get; set; }
    [JsonIgnore]
    public virtual File File { get; set; } = null!;
    [JsonIgnore]
    public virtual User User { get; set; } = null!;
}

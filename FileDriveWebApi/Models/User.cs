using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FileDriveWebApi.Models;

public partial class User
{
    [JsonIgnore]
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public virtual ICollection<File> Files { get; } = new List<File>();

    public virtual ICollection<SharedFile> SharedFiles { get; } = new List<SharedFile>();
}

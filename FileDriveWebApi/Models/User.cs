using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FileDriveWebApi.Models;

public partial class User
{
    [JsonPropertyName("UserId")]
    public int UserId { get; set; }
    [JsonPropertyName("Username")]
    public string Username { get; set; } = null!;
    [JsonPropertyName("PasswordHash")]
    public byte[] PasswordHash { get; set; } = null!;
    [JsonPropertyName("PasswordSalt")]
    public byte[] PasswordSalt { get; set; } = null!;

    [JsonPropertyName("Files")]
    public virtual ICollection<File> Files { get; } = new List<File>();
    [JsonPropertyName("SharedFiles")]
    public virtual ICollection<SharedFile> SharedFiles { get; } = new List<SharedFile>();
}

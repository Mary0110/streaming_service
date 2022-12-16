namespace streaming_service.Models;

public class ClientProfileModel
{
    public uint? id { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Username { get; set; }
    public DateOnly DateOfBirth { get; set; }
}
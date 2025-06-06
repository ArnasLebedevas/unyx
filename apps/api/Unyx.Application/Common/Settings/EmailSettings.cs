namespace Unyx.Application.Common.Settings;

public class EmailSettings
{
    public required string Server { get; set; }
    public required int Port { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string FromEmail { get; set; }
}
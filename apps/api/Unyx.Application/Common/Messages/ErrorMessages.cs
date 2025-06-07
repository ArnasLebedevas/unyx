namespace Unyx.Application.Common.Messages;

public static class ErrorMessages
{
    public const string ValidationFailed = "Validation failed.";
    public const string InvalidCredentials = "Invalid email or password.";
    public const string MissingJWT = "JWT Secret is missing in configuration.";
    public const string MissingRefreshTokenForUser = "No refresh token found for user with ID '{0}'.";
    public const string UnSupportedTemplate = "Unsupported email template type";
    public const string EmailServiceNetworkError = "Email service encountered a network issue.";
    public const string SeedingDatabaseError = "An error occurred while seeding the database.";
}

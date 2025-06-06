namespace Unyx.Application.Common.Exceptions;

public class EmailSendFailureException(string message, Exception innerException) : Exception(message, innerException);
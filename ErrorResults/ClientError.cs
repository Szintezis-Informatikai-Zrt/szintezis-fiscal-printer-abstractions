using FluentResults;

namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs during communication or interaction with the fiscal printer client,
/// encapsulating underlying hardware or communication failures.
/// </summary>
/// <remarks>
/// Client errors occur when the fiscal printer implementation encounters problems communicating with
/// the physical printer hardware, processing printer responses, or handling printer-specific operations.
/// These errors typically wrap underlying technical errors from the printer communication layer and
/// provide context about what operation was being attempted when the failure occurred.
/// 
/// <para>
/// Common scenarios that trigger client errors include:
/// <list type="bullet">
/// <item><description>Network or serial communication failures with the printer</description></item>
/// <item><description>Printer hardware malfunctions or timeout conditions</description></item>
/// <item><description>Invalid responses from the printer firmware</description></item>
/// <item><description>Protocol-level communication errors</description></item>
/// <item><description>Printer configuration or state issues</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve client errors, check the underlying error reasons for specific details about the
/// communication problem, verify printer connectivity and status, and ensure the printer is
/// properly configured and operational.
/// </para>
/// </remarks>
public sealed class ClientError : ErrorBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientError"/> class with a collection of underlying error reasons.
    /// </summary>
    /// <param name="reasons">The collection of underlying errors that caused this client error</param>
    /// <remarks>
    /// The underlying error reasons provide detailed information about the specific technical problems
    /// that occurred during printer communication or operation. These reasons are aggregated into
    /// a single client error to simplify error handling while preserving diagnostic information.
    /// </remarks>
    public ClientError(IReadOnlyList<IError> reasons)
    {
        Reasons.AddRange(reasons);
        Message = $"FisCat client returned errors: {string.Join(", ", reasons)}";
    }

    /// <summary>
    /// Gets the comprehensive error message describing the client error and its underlying causes.
    /// </summary>
    /// <value>
    /// A detailed message that includes information about the client error and lists all underlying error reasons.
    /// </value>
    /// <remarks>
    /// The message provides a human-readable summary of the client error and its causes, making it easier
    /// to diagnose communication problems and understand what went wrong during the printer operation.
    /// </remarks>
    public override string Message { get; }

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "ClientError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(ClientError);
}

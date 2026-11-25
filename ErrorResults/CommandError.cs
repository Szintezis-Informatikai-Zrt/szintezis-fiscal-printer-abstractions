namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when the fiscal printer returns an error response to a command,
/// including detailed error codes and messages for comprehensive troubleshooting.
/// </summary>
/// <remarks>
/// Command errors are returned directly from the fiscal printer hardware when operations cannot
/// be completed successfully. These errors provide detailed diagnostic information from the printer
/// itself, including specific error codes and descriptive messages that help identify the exact
/// nature of the problem. Command errors are essential for troubleshooting hardware issues,
/// configuration problems, and operational conflicts.
/// 
/// <para>
/// Command errors can indicate various issues:
/// <list type="bullet">
/// <item><description>Hardware malfunctions or mechanical problems with the printer</description></item>
/// <item><description>Configuration errors or invalid settings in the fiscal printer</description></item>
/// <item><description>Operational conflicts such as incorrect printer state for the requested operation</description></item>
/// <item><description>Resource limitations such as memory or storage constraints</description></item>
/// <item><description>Protocol violations or invalid command parameters</description></item>
/// <item><description>Regulatory compliance issues preventing operation completion</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// The response code and message provide specific diagnostic information that should be used
/// to identify the root cause and implement appropriate resolution strategies. Consult the
/// fiscal printer documentation for detailed error code explanations and troubleshooting procedures.
/// </para>
/// </remarks>
public class CommandError : ErrorBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CommandError"/> class with the printer's error response details.
    /// </summary>
    /// <param name="responseCode">The specific error code returned by the fiscal printer</param>
    /// <param name="responseMessage">The descriptive error message returned by the fiscal printer</param>
    /// <remarks>
    /// The constructor automatically creates a comprehensive error message combining both the response
    /// code and message, and adds them to the error metadata for diagnostic and troubleshooting purposes.
    /// </remarks>
    public CommandError(string responseCode, string responseMessage)
    {
        ResponseCode = responseCode;
        WithMetadata(nameof(ResponseCode), responseCode);

        ResponseMessage = responseMessage;
        WithMetadata(nameof(ResponseMessage), responseMessage);

        Message = $"Printer returned error code: {ResponseCode} with error message: {ResponseMessage}.";
    }

    /// <summary>
    /// Gets the specific error code returned by the fiscal printer hardware.
    /// </summary>
    /// <value>
    /// The printer-specific error code that identifies the type of problem encountered.
    /// </value>
    /// <remarks>
    /// Response codes are defined by the fiscal printer manufacturer and provide precise
    /// identification of the error condition. These codes can be used for programmatic
    /// error handling and should be referenced against the printer's technical documentation
    /// for detailed troubleshooting guidance.
    /// </remarks>
    public string ResponseCode { get; }

    /// <summary>
    /// Gets the descriptive error message returned by the fiscal printer hardware.
    /// </summary>
    /// <value>
    /// A human-readable description of the error condition as provided by the printer.
    /// </value>
    /// <remarks>
    /// Response messages provide additional context about the error beyond the numeric code,
    /// often including specific details about what went wrong and potential resolution hints.
    /// These messages are valuable for troubleshooting and user communication.
    /// </remarks>
    public string ResponseMessage { get; }

    /// <summary>
    /// Gets the comprehensive error message combining the response code and message.
    /// </summary>
    /// <value>
    /// A detailed message that includes both the error code and descriptive message from the printer.
    /// </value>
    /// <remarks>
    /// The combined message provides complete error information in a single, easy-to-read format
    /// that includes all diagnostic details returned by the fiscal printer hardware.
    /// </remarks>
    public override string Message { get; }

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "CommandError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(CommandError);
}

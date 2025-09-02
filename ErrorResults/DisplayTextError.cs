namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when there are problems with displaying text content
/// on the customer-facing display, affecting customer communication and transaction transparency.
/// </summary>
/// <remarks>
/// Display text errors indicate issues with sending, formatting, or presenting text information
/// on customer displays during transaction processing. These errors can impact customer experience
/// by preventing proper communication of transaction details, payment information, or other
/// important messages that customers need to see during the checkout process.
/// 
/// <para>
/// Common causes of display text errors include:
/// <list type="bullet">
/// <item><description>Text content exceeding display character limits or line length restrictions</description></item>
/// <item><description>Invalid characters or encoding issues that the display cannot render</description></item>
/// <item><description>Display hardware malfunctions or communication timeouts</description></item>
/// <item><description>Formatting conflicts with display capabilities or character sets</description></item>
/// <item><description>Memory limitations preventing proper text buffer management</description></item>
/// <item><description>Display driver or firmware issues affecting text rendering</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve display text errors, verify that text content fits within display limitations,
/// check for invalid characters or encoding issues, test display hardware functionality,
/// ensure proper communication with the display device, and validate that text formatting
/// is compatible with the display's capabilities.
/// </para>
/// </remarks>
public sealed class DisplayTextError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the display text processing failure.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that an error occurred while processing text for display.
    /// </value>
    public new string Message { get; } = "Display text error.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "DisplayTextError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(DisplayTextError);
}

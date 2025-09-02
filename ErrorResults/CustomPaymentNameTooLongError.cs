using CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when a custom payment method name exceeds the maximum allowed
/// character length supported by the fiscal printer system.
/// </summary>
/// <remarks>
/// The fiscal printer system enforces strict limits on the length of custom payment method names
/// to ensure proper display formatting, receipt printing compatibility, and system performance.
/// These limitations are typically imposed by hardware constraints, display device specifications,
/// and fiscal compliance requirements that govern how payment methods are presented to customers
/// and documented in fiscal records.
/// 
/// <para>
/// Custom payment name length restrictions serve several purposes:
/// <list type="bullet">
/// <item><description>Ensuring proper formatting on customer displays and printed receipts</description></item>
/// <item><description>Maintaining consistent user interface layout and readability</description></item>
/// <item><description>Complying with fiscal printer hardware memory and display limitations</description></item>
/// <item><description>Supporting reliable data storage and retrieval in fiscal memory</description></item>
/// <item><description>Ensuring payment method names fit within regulatory reporting formats</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve this error, shorten the custom payment method name to fit within the allowed
/// character limit (typically 13 characters or less), use abbreviations where appropriate,
/// and ensure that the shortened name remains clear and recognizable to both operators
/// and customers during transaction processing.
/// </para>
/// </remarks>
public sealed class CustomPaymentNameTooLongError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the payment name length violation.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that the custom payment method name exceeds the maximum allowed length.
    /// </value>
    public new string Message { get; } = "Custom payment name is too long.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "CustomPaymentNameTooLongError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(CustomPaymentNameTooLongError);
}

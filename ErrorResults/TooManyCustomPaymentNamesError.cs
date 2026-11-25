namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when attempting to configure more custom payment methods than
/// the fiscal printer system supports, exceeding the hardware or software limitations.
/// </summary>
/// <remarks>
/// The fiscal printer system has built-in limitations on the number of custom payment methods
/// that can be simultaneously configured and supported. This limitation exists to maintain system
/// performance, simplify cash drawer management, ensure proper fiscal compliance reporting,
/// and avoid overwhelming operators with too many payment options.
/// 
/// <para>
/// Custom payment method limitations serve several important purposes:
/// <list type="bullet">
/// <item><description>Maintaining system performance and response times during transactions</description></item>
/// <item><description>Simplifying cash drawer reconciliation and management procedures</description></item>
/// <item><description>Ensuring manageable complexity for operators and customers</description></item>
/// <item><description>Complying with fiscal printer hardware and memory constraints</description></item>
/// <item><description>Supporting reliable payment processing and reporting accuracy</description></item>
/// <item><description>Preventing user interface overcrowding and confusion</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve this error, review the custom payment methods being configured and prioritize
/// the most commonly used payment instruments for your business operations. Consider removing
/// less frequently used payment methods or evaluate whether all configured payment methods
/// are necessary for your customer base and operational requirements.
/// </para>
/// </remarks>
public sealed class TooManyCustomPaymentNamesError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the custom payment method configuration limit violation.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that the maximum number of supported custom payment methods has been exceeded.
    /// </value>
    public override string Message { get; } = "Too many custom payment names error.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "TooManyCustomPaymentNamesError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(TooManyCustomPaymentNamesError);
}

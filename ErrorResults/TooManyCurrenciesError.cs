namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when attempting to configure more foreign currencies than the
/// fiscal printer system supports, exceeding hardware or software limitations.
/// </summary>
/// <remarks>
/// The fiscal printer system has built-in limitations on the number of foreign currencies that
/// can be simultaneously configured and supported. This limitation exists to maintain system
/// performance, simplify cash drawer management, and ensure proper fiscal compliance reporting.
/// Typically, the system supports up to 5 custom foreign currencies in addition to standard
/// Euro support.
/// 
/// <para>
/// Currency limitations serve several important purposes:
/// <list type="bullet">
/// <item><description>Maintaining system performance and response times</description></item>
/// <item><description>Simplifying cash drawer reconciliation and management</description></item>
/// <item><description>Ensuring manageable complexity for operators and customers</description></item>
/// <item><description>Complying with fiscal printer hardware and memory constraints</description></item>
/// <item><description>Supporting reliable currency conversion and reporting accuracy</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve this error, review the currencies being configured and prioritize the most
/// commonly used foreign currencies for your business operations. Consider removing less
/// frequently used currencies or evaluate whether all configured currencies are necessary
/// for your customer base and business requirements.
/// </para>
/// </remarks>
public sealed class TooManyCurrenciesError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the currency configuration limit violation.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that the maximum number of supported currencies has been exceeded.
    /// </value>
    public new string Message { get; } = "Too many currencies.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "TooManyCurrenciesError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(TooManyCurrenciesError);
}

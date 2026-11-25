using FluentResults;

namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when the fiscal printer's automatic cancellation mechanism
/// fails to properly void or reverse a fiscal document that encountered issues during printing.
/// </summary>
/// <remarks>
/// Automatic cancellation is a critical safety mechanism in fiscal systems that attempts to void
/// or reverse partially printed or failed fiscal documents to maintain fiscal integrity and prevent
/// inconsistencies between the fiscal memory and actual printed receipts. When this mechanism fails,
/// it can result in orphaned fiscal entries, memory corruption, or compliance violations.
/// 
/// <para>
/// Common causes of automatic cancellation failures include:
/// <list type="bullet">
/// <item><description>Printer hardware malfunctions during the cancellation process</description></item>
/// <item><description>Power loss or interruption while executing automatic cancellation</description></item>
/// <item><description>Communication errors between the application and fiscal printer</description></item>
/// <item><description>Fiscal memory full or corrupted, preventing cancellation operations</description></item>
/// <item><description>Printer in an inconsistent state that prevents cancellation commands</description></item>
/// <item><description>Timeout errors when the printer fails to respond to cancellation requests</description></item>
/// <item><description>Cancellation operation conflicts with other pending fiscal operations</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// When automatic cancellation fails, immediate intervention is typically required to resolve
/// the fiscal inconsistency. This may involve manual cancellation procedures, printer reset operations,
/// or fiscal administrator intervention to ensure compliance with tax regulations. The fiscal document
/// state should be carefully verified and reconciled to prevent revenue leakage or audit issues.
/// </para>
/// 
/// <para>
/// To prevent and resolve automatic cancellation failures, ensure stable power supply to the printer,
/// maintain reliable communication channels, regularly verify printer status before operations,
/// implement proper error recovery procedures, and monitor fiscal memory capacity to prevent
/// overflow conditions that can block cancellation operations.
/// </para>
/// </remarks>
public class AutomaticCancellationFailedError : ErrorBase
{
    public AutomaticCancellationFailedError(IReadOnlyList<IError> reasons)
    {
        Reasons.AddRange(reasons);
    }

    /// <summary>
    /// Gets the error message describing the automatic cancellation failure.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that the automatic cancellation operation failed.
    /// </value>
    public override string Message => "Automatic cancellation failed.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "AutomaticCancellationFailedError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode => nameof(AutomaticCancellationFailedError);
}

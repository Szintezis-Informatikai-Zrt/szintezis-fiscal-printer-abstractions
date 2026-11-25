namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when attempting to create a deposit ticket that already exists
/// in the fiscal system, preventing duplicate deposit processing.
/// </summary>
/// <remarks>
/// This error is triggered when the system detects an attempt to create a deposit ticket with
/// an identifier or reference that has already been used. Deposit tickets typically involve
/// container deposits, security deposits, or other refundable amounts that require unique
/// identification to prevent duplicate processing and ensure proper liability tracking.
/// 
/// <para>
/// Common scenarios that trigger deposit ticket duplication errors include:
/// <list type="bullet">
/// <item><description>Processing the same container deposit return multiple times</description></item>
/// <item><description>System retry operations attempting to recreate existing deposit tickets</description></item>
/// <item><description>Integration errors where multiple systems attempt to process the same deposit</description></item>
/// <item><description>Manual data entry errors resulting in duplicate deposit references</description></item>
/// <item><description>Backup or recovery operations that attempt to replay completed deposits</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve this error, verify that the deposit ticket hasn't already been processed,
/// check for duplicate deposit references in the system, ensure that retry logic doesn't
/// create duplicates, and confirm that the deposit operation is actually needed before
/// attempting to create a new ticket.
/// </para>
/// </remarks>
public sealed class DepositTicketAlreadyExistsError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the duplicate deposit ticket condition.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that a deposit ticket with the same identifier already exists.
    /// </value>
    public override string Message { get; } = "Deposit ticket already exists.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "DepositTicketAlreadyExistsError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(DepositTicketAlreadyExistsError);
}

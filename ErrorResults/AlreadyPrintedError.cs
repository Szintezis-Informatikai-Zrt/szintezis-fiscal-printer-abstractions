namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when attempting to print or process a fiscal document that has already
/// been completed and printed, preventing duplicate document generation and maintaining fiscal integrity.
/// </summary>
/// <remarks>
/// This error is triggered when operations attempt to reprocess transactions that have already been
/// successfully completed and documented in the fiscal system. The fiscal printer maintains strict
/// controls to prevent duplicate document generation, which could violate fiscal regulations and
/// create accounting inconsistencies.
/// 
/// <para>
/// Situations that trigger already printed errors include:
/// <list type="bullet">
/// <item><description>Attempting to reprint completed transactions without proper authorization</description></item>
/// <item><description>System retry operations trying to process already successful transactions</description></item>
/// <item><description>Integration errors where multiple systems attempt to process the same transaction</description></item>
/// <item><description>User interface errors that allow duplicate submission of completed transactions</description></item>
/// <item><description>Backup or recovery operations that attempt to replay completed transactions</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve this error, verify the transaction status in the system, check if the document has
/// already been successfully processed, and ensure that only new, unprocessed transactions are
/// submitted for printing. If document reprinting is needed, use appropriate reprint functions
/// that are designed for historical document reproduction.
/// </para>
/// </remarks>
public sealed class AlreadyPrintedError() : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the duplicate printing attempt.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that the document has already been printed and cannot be processed again.
    /// </value>
    public override string Message { get; } = "Already printed.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "AlreadyPrintedError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(AlreadyPrintedError);
}

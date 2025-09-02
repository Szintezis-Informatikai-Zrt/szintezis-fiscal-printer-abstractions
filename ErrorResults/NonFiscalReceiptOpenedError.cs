namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when attempting to perform fiscal operations while a non-fiscal
/// receipt is currently open, preventing mixed document type operations.
/// </summary>
/// <remarks>
/// This error is triggered when fiscal operations are attempted while the printer is processing
/// a non-fiscal document. The fiscal printer maintains strict separation between fiscal and
/// non-fiscal operations to ensure compliance with regulatory requirements and prevent mixing
/// of different document types that have different legal and accounting implications.
/// 
/// <para>
/// Operations that conflict with open non-fiscal receipts include:
/// <list type="bullet">
/// <item><description>Starting new fiscal receipt transactions</description></item>
/// <item><description>Processing invoice or empties ticket operations</description></item>
/// <item><description>Performing cash drawer operations that affect fiscal totals</description></item>
/// <item><description>Adding fiscal items or processing payments</description></item>
/// <item><description>Any operation that requires fiscal transaction context</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve this error, complete or cancel the currently open non-fiscal receipt before
/// attempting fiscal operations. Non-fiscal documents must be finalized (printed) or cancelled
/// to clear the printer state and allow normal fiscal operations to proceed.
/// </para>
/// </remarks>
public sealed class NonFiscalReceiptOpenedError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the conflicting non-fiscal receipt state.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that a non-fiscal receipt is currently open and preventing fiscal operations.
    /// </value>
    public new string Message { get; } = "Non fiscal receipt opened.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "NonFiscalReceiptOpenedError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(NonFiscalReceiptOpenedError);
}

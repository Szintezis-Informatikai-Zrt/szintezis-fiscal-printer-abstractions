namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when attempting to perform operations that require an active
/// fiscal receipt transaction when no receipt is currently open.
/// </summary>
/// <remarks>
/// This error is triggered when operations that depend on an active fiscal transaction are attempted
/// while no receipt is currently being processed. Many fiscal operations require a receipt to be
/// opened first to establish the transaction context, ensure proper fiscal compliance, and maintain
/// transaction integrity throughout the process.
/// 
/// <para>
/// Operations that require an open fiscal receipt include:
/// <list type="bullet">
/// <item><description>Adding items to a transaction</description></item>
/// <item><description>Applying discounts or surcharges to the current transaction</description></item>
/// <item><description>Processing payments for the current transaction</description></item>
/// <item><description>Adding customer information to the current transaction</description></item>
/// <item><description>Calculating subtotals or finalizing transaction amounts</description></item>
/// <item><description>Performing any operation that modifies the current fiscal transaction</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve this error, ensure that a fiscal receipt is properly opened before attempting
/// dependent operations. This typically involves starting a new receipt transaction and
/// establishing the appropriate transaction context before proceeding with item additions,
/// payments, or other transaction-related operations.
/// </para>
/// </remarks>
public sealed class FiscalReceiptNotOpenedError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the missing receipt context.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that no fiscal receipt is currently open for operations.
    /// </value>
    public new string Message { get; } = "Fiscal receipt not opened.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "FiscalReceiptNotOpenedError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(FiscalReceiptNotOpenedError);
}

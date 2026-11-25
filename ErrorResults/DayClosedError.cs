namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when attempting to perform fiscal operations that require an open fiscal day
/// while the fiscal day is currently closed.
/// </summary>
/// <remarks>
/// This error is triggered when trying to execute sales transactions, cash operations, or other business
/// activities that can only be performed when the fiscal day is open and active. Most customer-facing
/// operations and revenue-generating activities require an open fiscal day to ensure proper fiscal
/// compliance and accurate daily reporting.
/// 
/// <para>
/// Operations that require an open fiscal day include:
/// <list type="bullet">
/// <item><description>Processing sales receipts and invoices</description></item>
/// <item><description>Handling cash drawer operations (pay-in/pay-out)</description></item>
/// <item><description>Processing returns and storno transactions</description></item>
/// <item><description>Customer display operations during active sales</description></item>
/// <item><description>Any operation that affects daily financial totals</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve this error, the fiscal day must be opened using appropriate day opening procedures,
/// which typically involve setting initial cash amounts and confirming operational readiness.
/// Day opening is usually performed at the beginning of each business day and establishes
/// the fiscal period for all subsequent transactions.
/// </para>
/// </remarks>
public sealed class DayClosedError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the closed day condition.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that the fiscal day is closed and preventing the operation.
    /// </value>
    public override string Message { get; } = "Day closed.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "DayClosedError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(DayClosedError);
}

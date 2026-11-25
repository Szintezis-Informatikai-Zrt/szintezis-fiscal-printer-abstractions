namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when attempting to perform operations that conflict with
/// an already open fiscal receipt transaction, preventing concurrent or overlapping operations.
/// </summary>
/// <remarks>
/// This error is triggered when trying to start new fiscal operations while a receipt is already
/// open and being processed. The fiscal printer can only handle one active receipt transaction
/// at a time to ensure proper transaction integrity, audit trails, and compliance with fiscal
/// regulations. Operations that conflict with open receipts must wait until the current receipt
/// is completed or cancelled.
/// 
/// <para>
/// Operations that conflict with open fiscal receipts include:
/// <list type="bullet">
/// <item><description>Starting a new receipt while another receipt is being processed</description></item>
/// <item><description>Beginning invoice transactions when a receipt is open</description></item>
/// <item><description>Initiating return or storno operations during active receipt processing</description></item>
/// <item><description>Starting empties ticket processing with an open receipt</description></item>
/// <item><description>Performing certain configuration changes during active transactions</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve this error, the currently open receipt must be completed by printing it,
/// or cancelled if the transaction needs to be aborted. Once the receipt state is cleared,
/// new fiscal operations can be initiated normally.
/// </para>
/// </remarks>
public sealed class FiscalReceiptOpenedError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the conflicting fiscal receipt state.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that a fiscal receipt is currently open and preventing the operation.
    /// </value>
    public override string Message { get; } = "Fiscal receipt opened.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "FiscalReceiptOpenedError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(FiscalReceiptOpenedError);
}

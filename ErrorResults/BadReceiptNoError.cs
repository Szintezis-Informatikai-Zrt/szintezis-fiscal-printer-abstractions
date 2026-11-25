namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when an invalid, malformed, or non-existent receipt number
/// is referenced in fiscal operations requiring document identification.
/// </summary>
/// <remarks>
/// Receipt numbers are unique identifiers assigned to fiscal documents within their closure periods
/// and are essential for document retrieval, storno operations, returns, and audit procedures.
/// Bad receipt number errors occur when operations reference receipt numbers that don't exist,
/// are improperly formatted, or don't correspond to actual fiscal documents in the system.
/// 
/// <para>
/// Common causes of bad receipt number errors include:
/// <list type="bullet">
/// <item><description>Referencing receipt numbers that don't exist in the specified closure period</description></item>
/// <item><description>Using incorrect receipt number formats or character encoding</description></item>
/// <item><description>Data entry errors when manually inputting receipt numbers</description></item>
/// <item><description>System integration issues with receipt number generation or mapping</description></item>
/// <item><description>Attempting to reference receipt numbers from different fiscal printers</description></item>
/// <item><description>Using receipt numbers that have been invalidated or cancelled</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve bad receipt number errors, verify the correct receipt number format for the
/// fiscal system, ensure that the receipt exists within the specified closure period,
/// check for data entry errors, and confirm that the receipt number corresponds to a
/// valid fiscal document in the printer's memory.
/// </para>
/// </remarks>
public sealed class BadReceiptNoError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the receipt number validation failure.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that an invalid receipt number was provided.
    /// </value>
    public override string Message { get; } = "Bad receiptNo.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "BadReceiptNoError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(BadReceiptNoError);
}

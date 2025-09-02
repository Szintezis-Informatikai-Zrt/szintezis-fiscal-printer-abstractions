namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the different modes used for reading and referencing fiscal documents stored in printer memory.
/// </summary>
/// <remarks>
/// Receipt modes are used when reading historical documents, checking document status, or referencing
/// previously printed fiscal documents for operations like returns, storno procedures, or audit purposes.
/// Each mode corresponds to a specific category of fiscal document stored in the printer's memory.
/// </remarks>
public enum ReceiptModes
{
    /// <summary>
    /// Mode for accessing standard sales receipts, invoices, and empties tickets.
    /// </summary>
    /// <remarks>
    /// Sale receipts include all customer transaction documents such as normal receipts,
    /// simplified invoices, and empties tickets. This mode is used for reading transaction
    /// details, verifying completion status, or preparing return/storno documents that
    /// reference original sales transactions.
    /// </remarks>
    SaleReceipt = 1,

    /// <summary>
    /// Mode for accessing cash management and drawer operation receipts.
    /// </summary>
    /// <remarks>
    /// Money movement receipts include cash-in receipts, cash-out receipts, payment method
    /// changes, and other financial operations that don't involve customer sales but affect
    /// cash drawer totals and financial reporting. Used for cash reconciliation and
    /// financial audit purposes.
    /// </remarks>
    MoneyMovementReceipt = 2,

    /// <summary>
    /// Mode for accessing return receipts and merchandise return documentation.
    /// </summary>
    /// <remarks>
    /// Return receipts document customer returns and refunds. This mode is used for
    /// reading return transaction details, verifying return processing, and maintaining
    /// proper audit trails for merchandise return operations and customer refunds.
    /// </remarks>
    ReturnReceipt = 3,

    /// <summary>
    /// Mode for accessing storno (cancellation/correction) receipts.
    /// </summary>
    /// <remarks>
    /// Storno receipts are used to cancel or correct previously issued documents.
    /// This mode provides access to cancellation documentation for audit purposes,
    /// compliance verification, and ensuring proper handling of document corrections
    /// and transaction cancellations.
    /// </remarks>
    StornoReceipt = 4,
}

using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a storno (cancellation/correction) receipt used to cancel or correct previously issued fiscal documents,
/// providing proper audit trails and regulatory compliance for transaction corrections.
/// </summary>
/// <remarks>
/// Storno receipts are essential for maintaining fiscal compliance when transactions need to be cancelled
/// or corrected after they have been completed and printed. They create proper audit trails by referencing
/// the original document and providing clear justification for the cancellation. Storno procedures must
/// follow strict regulatory requirements and are typically restricted to the same fiscal day as the
/// original transaction, though some implementations may allow extended periods.
/// 
/// <para>
/// Storno receipts are used in various scenarios:
/// <list type="bullet">
/// <item><description>Customer returns that require document cancellation</description></item>
/// <item><description>Operator errors discovered after transaction completion</description></item>
/// <item><description>Payment processing problems requiring transaction reversal</description></item>
/// <item><description>Inventory corrections affecting completed sales</description></item>
/// <item><description>Regulatory compliance corrections</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// All storno operations must maintain complete referential integrity with the original document
/// and provide clear reasons for the cancellation to satisfy audit and compliance requirements.
/// </para>
/// </remarks>
public sealed class StornoReceipt
{
    /// <summary>
    /// Gets or sets the fiscal printer apparatus number that issued the original document being cancelled.
    /// </summary>
    /// <value>
    /// The unique identifier of the fiscal printer device that created the original transaction.
    /// </value>
    /// <remarks>
    /// The AP (Apparatus) number must match the printer that issued the original document for the
    /// storno to be valid. This ensures that cancellations can only be performed by the same
    /// fiscal device that created the original transaction, maintaining audit integrity and
    /// preventing unauthorized cross-device cancellations.
    /// </remarks>
    public required string ApNumber { get; set; }

    /// <summary>
    /// Gets or sets the date when the original receipt being cancelled was issued.
    /// </summary>
    /// <value>
    /// The date of the original transaction being cancelled. Defaults to today's date.
    /// </value>
    /// <remarks>
    /// The receipt date is crucial for locating the original document in the fiscal printer's memory
    /// and ensuring that storno procedures comply with time-based restrictions. Many fiscal
    /// regulations limit storno operations to transactions from the same fiscal day or within
    /// a specific time period after the original transaction.
    /// </remarks>
    public DateOnly ReceiptDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    /// <summary>
    /// Gets or sets the type of the original document being cancelled.
    /// </summary>
    /// <value>
    /// An <see cref="OriginalDocumentType"/> value indicating whether the original was a fiscal receipt or simplified invoice.
    /// </value>
    /// <remarks>
    /// The original document type determines the cancellation procedure and affects how customer
    /// information is handled during the storno process. Different document types may have
    /// different regulatory requirements for cancellation and different audit trail needs.
    /// </remarks>
    public OriginalDocumentType OriginalDocumentType { get; set; } = OriginalDocumentType.FiscalReceipt;

    /// <summary>
    /// Gets or sets the receipt number of the original document being cancelled.
    /// </summary>
    /// <value>
    /// The complete receipt number in the format "CCCC/RRRRR" identifying the original transaction.
    /// </value>
    /// <remarks>
    /// The receipt number provides the precise reference to the original document in the fiscal
    /// printer's memory. This number is used to locate the original transaction data and ensure
    /// that the storno operation references the correct document. The format typically includes
    /// both closure number and sequential receipt number.
    /// </remarks>
    public required string ReceiptNo { get; set; }

    /// <summary>
    /// Gets or sets the reason code explaining why this storno cancellation is being performed.
    /// </summary>
    /// <value>
    /// A string representing the cancellation reason, typically corresponding to <see cref="StornoReason"/> values.
    /// Defaults to "Other" for general cancellations.
    /// </value>
    /// <remarks>
    /// The storno reason is essential for audit trails and regulatory compliance. It provides
    /// clear documentation of why the transaction was cancelled, which is important for business
    /// analysis, compliance reporting, and audit procedures. The reason should accurately reflect
    /// the circumstances that necessitated the cancellation.
    /// </remarks>
    public string StornoReason { get; set; } = "Other";

    public List<Tender> Tenders { get; set; } = [];

    /// <summary>Items supplied by the caller for free storno printing.</summary>
    public List<Invoice.Item> Items { get; set; } = [];

    /// <summary>Receipt-level discounts grouped by tax category.</summary>
    public List<TaxDiscount> TaxDiscounts { get; set; } = [];

    /// <summary>
    /// Gets or sets the customer information associated with this storno transaction.
    /// </summary>
    /// <value>
    /// A <see cref="Customer"/> object containing the customer details for the storno documentation.
    /// </value>
    /// <remarks>
    /// Customer information for storno receipts may be required depending on the original document
    /// type and local regulations. For invoice cancellations, complete customer information is
    /// typically required to maintain proper business documentation. For receipt cancellations,
    /// customer information may be optional but can be useful for customer service and audit purposes.
    /// </remarks>
    public required Customer Customer { get; set; }

    public List<NonFiscalLine> NonFiscalRows { get; set; } = [];
}

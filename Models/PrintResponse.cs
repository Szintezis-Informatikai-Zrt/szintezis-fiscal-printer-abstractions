using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Contains the response information returned after successfully printing a fiscal document,
/// including document identifiers and type information for tracking and reference purposes.
/// </summary>
/// <remarks>
/// Print responses provide essential information about completed fiscal transactions that
/// applications need for record keeping, customer service, and audit purposes. The response
/// includes all necessary identifiers to uniquely identify and reference the printed document
/// within the fiscal printer's memory and reporting systems.
/// </remarks>
public sealed class PrintResponse
{
    /// <summary>
    /// Gets or sets the fiscal printer's unique identifier number.
    /// </summary>
    /// <value>
    /// The alphanumeric identifier that uniquely identifies the specific fiscal printer device
    /// that processed this transaction, or <c>null</c> if not available.
    /// </value>
    /// <remarks>
    /// The AP (Apparatus) number is assigned to each fiscal printer by tax authorities and
    /// appears on all fiscal documents. It's used for audit purposes and to ensure that
    /// transactions can be traced back to specific printer devices for compliance verification.
    /// </remarks>
    public string? ApNumber { get; set; }

    /// <summary>
    /// Gets or sets the document number assigned by the fiscal printer.
    /// </summary>
    /// <value>
    /// The document number in the format "CCCC/RRRRR" where CCCC is the closure number and
    /// RRRRR is the sequential document number, or <c>null</c> if not applicable.
    /// </value>
    /// <remarks>
    /// Document numbers are sequential identifiers that uniquely identify each fiscal transaction
    /// within the printer's memory. They are used for document lookup, reprinting, and audit
    /// trail purposes. The format includes both the fiscal closure period and the sequential
    /// number within that period.
    /// </remarks>
    public string? DocumentNumber { get; set; }

    /// <summary>
    /// Gets or sets the invoice number for simplified invoice transactions.
    /// </summary>
    /// <value>
    /// The invoice number assigned to simplified invoices, or <c>null</c> for non-invoice transactions.
    /// </value>
    /// <remarks>
    /// Invoice numbers are generated for simplified invoice transactions and are separate from
    /// receipt numbers. They provide additional tracking capabilities for business-to-business
    /// transactions and are required for proper VAT accounting and reporting.
    /// </remarks>
    public string? InvoiceNo { get; set; }

    /// <summary>
    /// Gets or sets the type of fiscal document that was printed.
    /// </summary>
    /// <value>
    /// A <see cref="DocumentType"/> value indicating the specific type of document that was processed.
    /// </value>
    /// <remarks>
    /// The document type determines the fiscal treatment and legal requirements that were applied
    /// to this transaction. This information is essential for proper categorization in reporting
    /// systems and for understanding the regulatory context of the transaction.
    /// </remarks>
    public DocumentType DocumentType { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a manual receipt reprint should be offered.
    /// </summary>
    public bool ManualReprintRequired { get; set; }

    /// <summary>
    /// Gets or sets the printer status reported by the completed print command.
    /// </summary>
    public PrinterStatus? PrinterStatus { get; set; }

}

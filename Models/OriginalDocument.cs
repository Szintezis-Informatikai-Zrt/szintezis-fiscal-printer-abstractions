using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents reference information for an original fiscal document that serves as the basis
/// for related transactions such as returns, storno operations, or payment modifications.
/// </summary>
/// <remarks>
/// Original document references provide essential audit trail connections between related transactions,
/// ensuring proper fiscal compliance and enabling accurate business analysis. These references are
/// required for operations that modify, cancel, or build upon previously completed fiscal transactions,
/// maintaining regulatory compliance and business accountability.
/// 
/// <para>
/// Original document references are commonly used in:
/// <list type="bullet">
/// <item><description>Return transactions that reference original purchase receipts</description></item>
/// <item><description>Storno operations that cancel or correct previous documents</description></item>
/// <item><description>Payment method changes that modify transaction settlement</description></item>
/// <item><description>Warranty claims that reference original sales documentation</description></item>
/// <item><description>Audit procedures that require transaction history verification</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// Proper document referencing ensures regulatory compliance, supports audit requirements,
/// and maintains complete business transaction histories for accountability and analysis.
/// </para>
/// </remarks>
public class OriginalDocument
{
    /// <summary>
    /// Gets or sets the apparatus number of the fiscal printer that issued the original document.
    /// </summary>
    /// <value>
    /// The unique identifier of the fiscal printer device that created the original transaction.
    /// </value>
    /// <remarks>
    /// The AP (Apparatus) number ensures that document references are tied to specific fiscal
    /// devices, maintaining audit integrity and preventing cross-device document confusion.
    /// This identifier is assigned by tax authorities and appears on all fiscal documents
    /// for compliance and verification purposes.
    /// </remarks>
    public required string APNumber { get; set; }

    /// <summary>
    /// Gets or sets the date when the original document was issued.
    /// </summary>
    /// <value>
    /// The fiscal date of the original transaction being referenced. Defaults to today's date.
    /// </value>
    /// <remarks>
    /// The receipt date is essential for locating original documents in fiscal memory and
    /// ensuring that referencing operations comply with time-based business rules and
    /// regulatory requirements. Many operations have time limitations that depend on the
    /// original transaction date.
    /// </remarks>
    public required DateOnly ReceiptDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    /// <summary>
    /// Gets or sets the type of the original fiscal document being referenced.
    /// </summary>
    /// <value>
    /// An <see cref="OriginalDocumentType"/> value indicating the fiscal document type of the original transaction.
    /// </value>
    /// <remarks>
    /// The original document type determines the appropriate referencing procedures and affects
    /// how the related transaction is processed. Different document types may have different
    /// business rules, time limitations, and regulatory requirements for referencing operations.
    /// </remarks>
    public required OriginalDocumentType OriginalDocumentType { get; set; } = OriginalDocumentType.FiscalReceipt;

    /// <summary>
    /// Gets or sets the receipt number of the original document being referenced.
    /// </summary>
    /// <value>
    /// The complete receipt number in the format "CCCC/RRRRR" that uniquely identifies the original transaction.
    /// </value>
    /// <remarks>
    /// The receipt number provides the precise reference to the original document in fiscal memory.
    /// This identifier is used to locate the original transaction data and establish the proper
    /// audit trail connection between the original and related transactions. The format typically
    /// includes both closure number and sequential receipt number for complete identification.
    /// </remarks>
    public required string ReceiptNo { get; set; }
}

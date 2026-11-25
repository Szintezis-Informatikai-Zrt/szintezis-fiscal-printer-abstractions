using System.ComponentModel.DataAnnotations;
using NetEscapades.EnumGenerators;

namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the types of original fiscal documents that can be referenced in related transactions
/// such as returns, storno operations, or payment modifications.
/// </summary>
/// <remarks>
/// Original document types specify the category of fiscal document being referenced when performing
/// operations that depend on previously issued transactions. This classification is essential for
/// proper fiscal compliance, audit trail maintenance, and ensuring that referencing operations
/// follow appropriate business rules and regulatory requirements.
/// 
/// <para>
/// The Display attribute values represent the fiscal printer codes used internally for each document type,
/// enabling proper communication with fiscal hardware and ensuring compliance with fiscal protocols.
/// </para>
/// 
/// <para>
/// Document type classification serves multiple purposes:
/// <list type="bullet">
/// <item><description>Ensures appropriate business rules are applied to referencing operations</description></item>
/// <item><description>Maintains proper audit trails and compliance documentation</description></item>
/// <item><description>Supports correct tax treatment and reporting for related transactions</description></item>
/// <item><description>Enables proper customer information handling based on original document type</description></item>
/// </list>
/// </para>
/// </remarks>
[EnumExtensions(MetadataSource = MetadataSource.DisplayAttribute)]
public enum OriginalDocumentType
{
    /// <summary>
    /// References a standard fiscal receipt issued for retail customer transactions.
    /// </summary>
    /// <remarks>
    /// Fiscal receipts are the most common transaction documents for retail sales to individual
    /// customers. When referenced in operations like returns or storno procedures, they typically
    /// require less customer information verification and may have different time limitations
    /// compared to business documents. The fiscal treatment focuses on individual consumer
    /// transaction requirements and compliance.
    /// </remarks>
    [Display(Name = "F")]
    FiscalReceipt,

    /// <summary>
    /// References a simplified invoice issued for business-to-business transactions.
    /// </summary>
    /// <remarks>
    /// Simplified invoices contain comprehensive business customer information and detailed
    /// tax breakdowns required for B2B transactions. When referenced in operations, they
    /// typically require complete customer information verification and may have extended
    /// time allowances for modifications. The fiscal treatment includes proper business
    /// accounting requirements and VAT compliance considerations.
    /// </remarks>
    [Display(Name = "I")]
    SimplifiedInvoice,
}

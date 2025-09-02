namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a single formatted row for tabular display or report printing, containing
/// style information and text content for structured document presentation.
/// </summary>
/// <remarks>
/// Table rows provide structured formatting capabilities for reports, receipts, and other
/// fiscal documents that require organized presentation of information in tabular format.
/// Each row combines styling instructions with text content to create professional-looking
/// documents with consistent formatting and clear information hierarchy.
/// 
/// <para>
/// Table rows are commonly used in various document types:
/// <list type="bullet">
/// <item><description>Fiscal reports with structured data presentation</description></item>
/// <item><description>Receipt sections requiring tabular organization</description></item>
/// <item><description>Invoice layouts with itemized information</description></item>
/// <item><description>Summary reports with categorized data</description></item>
/// <item><description>Audit documents requiring clear information structure</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// The combination of style and text enables flexible document formatting while maintaining
/// consistency and professional appearance across different document types and business
/// requirements.
/// </para>
/// </remarks>
public sealed class TableRow
{
    /// <summary>
    /// Gets or sets the formatting style specification for this table row.
    /// </summary>
    /// <value>
    /// A string containing style instructions that control the appearance and formatting of this row.
    /// </value>
    /// <remarks>
    /// The style specification determines how this table row will be formatted when printed,
    /// including alignment, font weight, text decoration, spacing, and other visual attributes.
    /// Style instructions may include combinations of formatting options such as bold text,
    /// underlining, different alignments, or special spacing requirements for optimal
    /// document presentation.
    /// </remarks>
    public required string Style { get; set; }

    /// <summary>
    /// Gets or sets the text content to be displayed in this table row.
    /// </summary>
    /// <value>
    /// The actual text content that will be formatted and printed according to the specified style.
    /// </value>
    /// <remarks>
    /// The text content represents the information to be displayed in this table row,
    /// which will be formatted according to the style specifications. Content should be
    /// appropriate for the intended document type and consider any length limitations
    /// imposed by the printing device or document format requirements.
    /// </remarks>
    public required string Text { get; set; }
}

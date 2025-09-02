namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a non-fiscal document that can be printed without affecting sales totals, tax calculations,
/// or fiscal reporting, used for promotional materials, information notices, and customer communications.
/// </summary>
/// <remarks>
/// Non-fiscal documents provide a way to use the fiscal printer for printing purposes that don't involve
/// monetary transactions or tax implications. These documents don't impact business sales totals, tax
/// reporting, or fiscal compliance requirements, making them suitable for various informational and
/// promotional printing needs while utilizing the same printer hardware used for fiscal operations.
/// 
/// <para>
/// Common uses for non-fiscal documents include:
/// <list type="bullet">
/// <item><description>Promotional announcements and special offers</description></item>
/// <item><description>Store information and operating hours</description></item>
/// <item><description>Product information and user instructions</description></item>
/// <item><description>Customer service messages and contact information</description></item>
/// <item><description>Loyalty program details and terms</description></item>
/// <item><description>Receipt paper testing and printer maintenance</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// While non-fiscal documents don't affect fiscal calculations, they may still be tracked for
/// operational purposes and paper usage monitoring. They provide businesses with flexible
/// communication capabilities using existing printer infrastructure.
/// </para>
/// </remarks>
public sealed class NonFiscal
{
    /// <summary>
    /// Gets or sets the optional barcode to be printed on the non-fiscal document.
    /// </summary>
    /// <value>
    /// A string containing barcode data to be printed, or <c>null</c> if no barcode is required.
    /// </value>
    /// <remarks>
    /// Barcodes on non-fiscal documents can be used for various purposes such as promotional codes,
    /// reference numbers, website URLs, or tracking information. Unlike fiscal documents, these
    /// barcodes are purely informational and don't affect transaction processing or fiscal compliance.
    /// When present, the barcode is typically printed as a Code128 format for wide compatibility.
    /// </remarks>
    public string? Barcode { get; set; }

    /// <summary>
    /// Gets or sets the collection of formatted text lines that comprise the non-fiscal document content.
    /// </summary>
    /// <value>
    /// A list of <see cref="NonFiscalLine"/> objects containing the text content and formatting instructions.
    /// </value>
    /// <remarks>
    /// Non-fiscal lines contain the actual content to be printed, including text, formatting styles,
    /// and alignment instructions. Each line can have individual formatting such as bold, underline,
    /// different heights, and various alignment options. The collection should be organized in the
    /// order that the content should appear on the printed document.
    /// </remarks>
    public List<NonFiscalLine> NonFiscalLines { get; set; } = [];
}

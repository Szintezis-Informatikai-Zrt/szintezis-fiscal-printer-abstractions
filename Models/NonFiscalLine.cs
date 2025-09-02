using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a single formatted text line for non-fiscal document printing, including content and styling information
/// to control how the text appears on the printed output.
/// </summary>
/// <remarks>
/// Non-fiscal lines provide precise control over text formatting and appearance for informational documents
/// that don't affect fiscal calculations. Each line can have individual formatting styles applied, including
/// text alignment, font weight, underlining, and size modifications. This flexibility allows for professional-looking
/// documents that can effectively communicate information to customers while maintaining clear visual hierarchy
/// and readability.
/// 
/// <para>
/// Non-fiscal lines are commonly used in various document types:
/// <list type="bullet">
/// <item><description>Receipt headers and footers with store information</description></item>
/// <item><description>Promotional messages with emphasized text</description></item>
/// <item><description>Formatted product information and descriptions</description></item>
/// <item><description>Terms and conditions with proper visual structure</description></item>
/// <item><description>Customer service information with clear formatting</description></item>
/// </list>
/// </para>
/// </remarks>
public sealed class NonFiscalLine
{
    /// <summary>
    /// Gets or sets the formatting style to be applied to this text line.
    /// </summary>
    /// <value>
    /// A <see cref="NonFiscalStyle"/> value that controls the visual appearance of the text.
    /// Defaults to <see cref="NonFiscalStyle.AlignLeft"/> for standard left-aligned text.
    /// </value>
    /// <remarks>
    /// The style property determines how the text line will be formatted when printed, including
    /// alignment (left, center, right), font weight (normal, bold), text decoration (underline),
    /// and size (normal, double height). Multiple style flags can be combined using bitwise operations
    /// to create complex formatting combinations such as centered bold text or right-aligned underlined text.
    /// </remarks>
    public NonFiscalStyle Style { get; set; } = NonFiscalStyle.AlignLeft;

    /// <summary>
    /// Gets or sets the text content to be printed on this line.
    /// </summary>
    /// <value>
    /// The string content that will be printed with the specified formatting style.
    /// </value>
    /// <remarks>
    /// The line content should be appropriate for the printer's character set and line width limitations.
    /// Text that exceeds the printer's line width may be truncated or wrapped depending on the printer
    /// implementation. Consider the formatting style when determining appropriate line lengths, as
    /// centered and right-aligned text may have different effective width constraints than left-aligned text.
    /// </remarks>
    public required string Line { get; set; }
}

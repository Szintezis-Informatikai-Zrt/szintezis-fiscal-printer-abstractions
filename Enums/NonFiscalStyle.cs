namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines text formatting styles that can be applied to non-fiscal document lines, providing control over
/// text alignment, weight, decoration, and size for professional document presentation.
/// </summary>
/// <remarks>
/// Non-fiscal style flags can be combined using bitwise operations to create complex formatting combinations.
/// The flags enum design allows multiple styles to be applied simultaneously, such as centered bold text
/// or right-aligned underlined text. This flexibility enables the creation of visually appealing and
/// professionally formatted documents that effectively communicate information to customers.
/// 
/// <para>
/// Style combinations follow these rules:
/// <list type="bullet">
/// <item><description>Only one alignment style should be used (Left, Center, or Right)</description></item>
/// <item><description>Bold, DoubleHeight, and UnderLine can be combined with any alignment</description></item>
/// <item><description>Multiple decoration styles (Bold, DoubleHeight, UnderLine) can be combined together</description></item>
/// <item><description>Printer hardware capabilities may limit which style combinations are supported</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// Example combinations:
/// <code>
/// NonFiscalStyle.AlignCenter | NonFiscalStyle.Bold  // Centered bold text
/// NonFiscalStyle.AlignRight | NonFiscalStyle.UnderLine  // Right-aligned underlined text
/// NonFiscalStyle.AlignLeft | NonFiscalStyle.DoubleHeight | NonFiscalStyle.Bold  // Large bold left-aligned text
/// </code>
/// </para>
/// </remarks>
[Flags]
public enum NonFiscalStyle
{
    /// <summary>
    /// Aligns text to the left margin of the printer line.
    /// </summary>
    /// <remarks>
    /// Left alignment is the default text positioning for most printed content. Text starts at the
    /// leftmost position of the printable area and extends rightward. This alignment is most commonly
    /// used for standard document content, lists, and general informational text.
    /// </remarks>
    AlignLeft = 0b0000001,

    /// <summary>
    /// Centers text horizontally within the printer line width.
    /// </summary>
    /// <remarks>
    /// Center alignment positions text in the middle of the printable line width, with equal spacing
    /// on both sides. This alignment is commonly used for headers, titles, store names, promotional
    /// messages, and other content that should draw attention or appear prominently on the document.
    /// </remarks>
    AlignCenter = 0b0000010,

    /// <summary>
    /// Aligns text to the right margin of the printer line.
    /// </summary>
    /// <remarks>
    /// Right alignment positions text at the rightmost edge of the printable area, extending leftward.
    /// This alignment is often used for monetary amounts, totals, dates, or other numerical data that
    /// benefits from consistent right-edge positioning for easy comparison and reading.
    /// </remarks>
    AlignRight = 0b0000100,

    /// <summary>
    /// Applies bold formatting to make text appear thicker and more prominent.
    /// </summary>
    /// <remarks>
    /// Bold formatting increases the visual weight of text, making it stand out from regular text.
    /// This style is useful for emphasizing important information, headings, warnings, or key details
    /// that require customer attention. Bold can be combined with any alignment style.
    /// </remarks>
    Bold = 0b0001000,

    /// <summary>
    /// Increases text height to double the normal size for enhanced visibility.
    /// </summary>
    /// <remarks>
    /// Double height formatting makes text significantly larger and more visible, useful for headers,
    /// store names, important announcements, or promotional messages that need to stand out prominently.
    /// This style can be combined with other formatting options and alignment styles for maximum impact.
    /// </remarks>
    DoubleHeight = 0b0010000,

    /// <summary>
    /// Adds an underline decoration beneath the text for emphasis.
    /// </summary>
    /// <remarks>
    /// Underline formatting adds a horizontal line beneath text characters, providing subtle emphasis
    /// without the heavy visual weight of bold formatting. This style is useful for section headers,
    /// important terms, or content that needs emphasis while maintaining readability. Can be combined
    /// with other styles and alignments.
    /// </remarks>
    UnderLine = 0b0100000,
}

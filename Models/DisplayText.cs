namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents custom text content to be displayed on the customer-facing display,
/// providing two-line messaging capabilities for customer communication and system feedback.
/// </summary>
/// <remarks>
/// Display text enables flexible customer communication during various checkout scenarios,
/// from operational messages and instructions to promotional content and system status updates.
/// The two-line format accommodates most customer display hardware while providing sufficient
/// space for clear, concise messaging that enhances customer experience and operational efficiency.
/// 
/// <para>
/// Common use cases for display text include:
/// <list type="bullet">
/// <item><description>Welcome messages and store greetings</description></item>
/// <item><description>Operational instructions and customer guidance</description></item>
/// <item><description>System status messages and wait notifications</description></item>
/// <item><description>Promotional announcements and special offers</description></item>
/// <item><description>Error messages and resolution instructions</description></item>
/// <item><description>Payment processing status and confirmations</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// Text content should be designed for the display's character limitations and customer
/// readability, considering viewing distance and display technology constraints.
/// </para>
/// </remarks>
public sealed class DisplayText
{
    /// <summary>
    /// Gets or sets the display duration in microseconds before the display content automatically updates or clears.
    /// </summary>
    /// <value>
    /// The time in microseconds that this text will remain visible on the customer display.
    /// Default value is 1,000,000 microseconds (1 second).
    /// </value>
    /// <remarks>
    /// The display time allows control over how long customers see specific messages, enabling
    /// appropriate timing for different message types. Short messages may require brief display
    /// times, while important instructions or promotional content may benefit from longer display
    /// periods. The timing should balance message visibility with checkout flow efficiency.
    /// </remarks>
    public int Time { get; set; } = 1000000;

    /// <summary>
    /// Gets or sets the text content for the first (top) line of the customer display.
    /// </summary>
    /// <value>
    /// The text string to display on the first line, typically limited to 19-20 characters
    /// depending on display hardware specifications.
    /// </value>
    /// <remarks>
    /// The first line is typically used for primary messages, headings, or the most important
    /// information that customers should see immediately. Text length should be appropriate
    /// for the display width to ensure complete visibility without truncation. Consider using
    /// the first line for key information and the second line for supporting details.
    /// </remarks>
    public string Line1 { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the text content for the second (bottom) line of the customer display.
    /// </summary>
    /// <value>
    /// The text string to display on the second line, typically limited to 20 characters
    /// depending on display hardware specifications.
    /// </value>
    /// <remarks>
    /// The second line complements the first line with additional information, details, or
    /// secondary messaging. It's often used for supplementary information, continuation of
    /// the first line's message, or specific details that support the primary message.
    /// The second line may have slightly different character limits than the first line
    /// depending on the display hardware design.
    /// </remarks>
    public string Line2 { get; set; } = string.Empty;
}


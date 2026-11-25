namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when the customer-facing display (VFD - Vacuum Fluorescent Display) 
/// is disconnected or not responding, preventing customer interaction and transaction transparency.
/// </summary>
/// <remarks>
/// The customer-facing display is a critical component of point-of-sale operations that shows transaction
/// information to customers in real-time. When the display is disconnected or malfunctioning, customers
/// cannot see item details, prices, totals, or other transaction information, which may violate regulatory
/// requirements and significantly impact customer experience and trust.
/// 
/// <para>
/// Display disconnection can occur due to various factors:
/// <list type="bullet">
/// <item><description>Physical disconnection of display cables or connectors</description></item>
/// <item><description>Display hardware failure or malfunction</description></item>
/// <item><description>Communication protocol errors between printer and display</description></item>
/// <item><description>Power supply issues affecting the display unit</description></item>
/// <item><description>Display driver or firmware problems</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve display disconnection errors, check all physical connections, verify power supply
/// to the display unit, test communication links, and ensure that display drivers and firmware
/// are functioning correctly. Some fiscal operations may be restricted until display functionality
/// is restored to maintain customer transparency and regulatory compliance.
/// </para>
/// </remarks>
public sealed class DisplayDisconnectedError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the display disconnection condition.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that the customer display is disconnected or not responding.
    /// </value>
    public override string Message { get; } = "Display disconnected.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "DisplayDisconnectedError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(DisplayDisconnectedError);
}

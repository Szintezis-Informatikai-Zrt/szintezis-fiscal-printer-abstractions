namespace CronisNext.FiscalPrinter.Events;

/// <summary>
/// Represents a warning event that is raised when the fiscal printer encounters non-critical issues
/// that don't prevent operations but may require attention or monitoring.
/// </summary>
/// <param name="Message">The warning message describing the condition or issue that requires attention</param>
/// <remarks>
/// Warning events provide notification of printer conditions that are not severe enough to prevent
/// operations but may indicate potential problems, maintenance needs, or operational conditions
/// that operators should be aware of. Unlike errors, warnings don't halt operations but serve
/// as early indicators of issues that may require preventive action.
/// 
/// <para>
/// Common warning scenarios include:
/// <list type="bullet">
/// <item><description>Low paper levels that may require replacement soon</description></item>
/// <item><description>Intermittent communication issues that don't prevent operation</description></item>
/// <item><description>Performance degradation or slower response times</description></item>
/// <item><description>Non-critical hardware status changes</description></item>
/// <item><description>Configuration recommendations or optimization suggestions</description></item>
/// <item><description>Maintenance reminders or service notifications</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// Applications should subscribe to warning events to implement proactive monitoring,
/// maintenance scheduling, and user notifications that help prevent minor issues from
/// becoming critical problems. Warning events support operational excellence by enabling
/// preventive maintenance and early intervention strategies.
/// </para>
/// </remarks>
public sealed record PrinterWarningEvent(string Message);

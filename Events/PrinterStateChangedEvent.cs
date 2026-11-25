using CronisNext.Enums;
using CronisNext.FiscalPrinter.Models;

namespace CronisNext.FiscalPrinter.Events;

/// <summary>
/// Represents an event that is raised when the operational state of the fiscal printer changes.
/// </summary>
/// <param name="State">The new operational state that the printer has transitioned to</param>
/// <param name="Status">The printer status</param>
/// <remarks>
/// This event provides notification of printer state transitions, allowing the application
/// to respond appropriately to changes in printer availability, error conditions, or
/// operational modes. State changes may affect what operations are available and may
/// require user intervention or system responses.
/// 
/// <para>
/// Common state transitions include:
/// <list type="bullet">
/// <item><description>Transitioning to ready state after initialization</description></item>
/// <item><description>Entering error state due to hardware problems</description></item>
/// <item><description>Becoming busy during printing operations</description></item>
/// <item><description>Going offline due to communication issues</description></item>
/// </list>
/// </para>
/// 
/// Applications should subscribe to this event to maintain accurate printer status
/// displays, enable or disable printer-dependent functionality, and trigger appropriate
/// error handling or recovery procedures.
/// </remarks>
public sealed record PrinterStateChangedEvent(PrinterStatusType State, PrinterStatus Status);

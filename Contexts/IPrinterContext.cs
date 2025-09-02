using CronisNext.Enums;
using CronisNext.FiscalPrinter.Models;

namespace CronisNext.FiscalPrinter.Contexts;

/// <summary>
/// Manages the runtime state and initialization of fiscal printer hardware, providing
/// centralized status monitoring and event handling for printer operations.
/// </summary>
/// <remarks>
/// This context maintains the current state of the fiscal printer including initialization status,
/// hardware conditions, and error states. It serves as the central point for monitoring
/// printer health and coordinating between different printer operations.
/// </remarks>
public interface IPrinterContext
{
    /// <summary>
    /// Gets a value indicating whether the fiscal printer has been successfully initialized and is ready for operations.
    /// </summary>
    /// <value>
    /// <c>true</c> if the printer has completed initialization and is ready for use; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// Initialization includes establishing communication with the printer hardware,
    /// verifying device capabilities, and confirming operational readiness.
    /// </remarks>
    bool Initialized { get; }

    /// <summary>
    /// Gets the current operational state of the fiscal printer.
    /// </summary>
    /// <value>
    /// A <see cref="PrinterStatusType"/> value indicating the current printer state
    /// such as ready, error, or busy.
    /// </value>
    /// <remarks>
    /// This property provides high-level status information for quick operational decisions.
    /// For detailed error conditions, check the <see cref="Status"/> property.
    /// </remarks>
    PrinterStatusType State { get; }

    /// <summary>
    /// Gets detailed status information about the fiscal printer's current condition.
    /// </summary>
    /// <value>
    /// A <see cref="PrinterStatus"/> object containing detailed hardware status information,
    /// or <c>null</c> if status information is not available.
    /// </value>
    /// <remarks>
    /// This provides comprehensive status including paper levels, cover state, display connectivity,
    /// battery status, and other hardware-specific conditions that may affect operations.
    /// </remarks>
    PrinterStatus? Status { get; }

    /// <summary>
    /// Initializes the fiscal printer connection and prepares it for operations.
    /// </summary>
    /// <remarks>
    /// This method establishes communication with the printer hardware, performs initial
    /// configuration, and sets the printer to a ready state. Should be called before
    /// attempting any printer operations.
    /// </remarks>
    void Initialize();

    /// <summary>
    /// Asynchronously waits for the fiscal printer to complete initialization.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the wait operation</param>
    /// <returns>A task that completes when the printer initialization is finished</returns>
    /// <remarks>
    /// This method allows callers to wait for initialization completion without blocking.
    /// It will return immediately if the printer is already initialized.
    /// </remarks>
    Task UntilInitialized(CancellationToken cancellationToken);

    /// <summary>
    /// Sets the printer context to an error state, indicating that operations cannot proceed.
    /// </summary>
    /// <remarks>
    /// This method is typically called when critical errors occur that prevent normal
    /// printer operations. It updates the state to reflect the error condition and
    /// may trigger error handling procedures.
    /// </remarks>
    void SetErrorState();

    /// <summary>
    /// Updates the detailed status information for the fiscal printer.
    /// </summary>
    /// <param name="status">
    /// New status information to set, or <c>null</c> to clear the current status.
    /// </param>
    /// <remarks>
    /// This method is typically called by printer implementations to update the context
    /// with current hardware status after status polling or operation completion.
    /// Status changes may trigger events or state transitions.
    /// </remarks>
    void SetStatus(PrinterStatus? status);

    /// <summary>
    /// Records a warning message related to printer operations for monitoring and debugging purposes.
    /// </summary>
    /// <param name="message">Warning message describing the condition or issue</param>
    /// <remarks>
    /// Warnings are non-critical issues that don't prevent operations but may indicate
    /// potential problems or conditions that require attention. These messages are
    /// typically logged and may be displayed to operators.
    /// </remarks>
    void PushWarning(string message);
}

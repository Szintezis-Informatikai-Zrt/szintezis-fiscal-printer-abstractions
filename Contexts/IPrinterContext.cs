using CronisNext.Enums;
using CronisNext.FiscalPrinter.Enums;
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
    /// <summary>The selected output type for the active sales document.</summary>
    DocumentOutputType OutputType { get; }

    /// <summary>Whether this printer supports electronic receipts.</summary>
    bool SupportsElectronicReceipts { get; }

    /// <summary>Whether the cash drawer should be opened when printing a canceled sales document.</summary>
    bool OpenDrawerForCanceledDocuments { get; }

    /// <summary>Whether the last output is available for manual reprinting.</summary>
    bool CanReprint { get; }

    /// <summary>Selects the output type and clears the previous reprint state.</summary>
    void SetOutputType(DocumentOutputType outputType);

    /// <summary>Toggles the output type and clears the previous reprint state.</summary>
    void SwapOutputType();

    /// <summary>Marks the last output as available for reprinting.</summary>
    void EnableReprint();

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
    /// Asynchronously waits until the printer context has been initialized.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the wait operation.</param>
    /// <returns>A task that completes when initialization is finished.</returns>
    /// <remarks>
    /// This method is useful for components that need to wait for the printer to be ready
    /// before proceeding with their operations. The wait will complete whether initialization
    /// succeeds or fails - check <see cref="Initialized"/> to determine the outcome.
    /// </remarks>
    Task UntilInitialized(CancellationToken cancellationToken);

    /// <summary>
    /// Attempts to begin initialization. Returns true if this call started initialization,
    /// false if initialization was already started or completed.
    /// </summary>
    /// <returns>True if initialization was started by this call; false if already in progress or completed.</returns>
    /// <remarks>
    /// This method is used by <see cref="Interfaces.IFiscalPrinterService.InitializeAsync"/> to coordinate
    /// initialization state. The context stores the initialization state since it is a singleton,
    /// while services may be transient.
    /// </remarks>
    bool TryBeginInitialization();

    /// <summary>
    /// Marks initialization as successfully completed.
    /// </summary>
    /// <remarks>
    /// Called by <see cref="Interfaces.IFiscalPrinterService.InitializeAsync"/> after all plugins have
    /// completed successfully. This signals waiting tasks and updates the state to ready.
    /// </remarks>
    void CompleteInitialization();

    /// <summary>
    /// Marks initialization as failed, allowing retry.
    /// </summary>
    /// <remarks>
    /// Called by <see cref="Interfaces.IFiscalPrinterService.InitializeAsync"/> when plugin initialization fails.
    /// This resets the initialization state to allow retrying.
    /// </remarks>
    void FailInitialization();

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

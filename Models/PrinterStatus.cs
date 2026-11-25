namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Provides detailed status information about the current operational condition of a fiscal printer,
/// including hardware states, error conditions, and operational flags.
/// </summary>
/// <remarks>
/// This class captures real-time hardware status that affects printer operations. It implements
/// equality comparison to detect status changes and trigger appropriate responses to operational
/// conditions that may require attention or prevent normal operation.
/// </remarks>
public sealed class PrinterStatus : IEquatable<PrinterStatus>
{
    /// <summary>
    /// Gets or sets a value indicating whether the customer-facing display (VFD) is disconnected or not responding.
    /// </summary>
    /// <value>
    /// <c>true</c> if the VFD display is disconnected or not responding; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// The VFD (Vacuum Fluorescent Display) shows transaction information to customers. When disconnected,
    /// customers cannot see transaction details, which may affect compliance requirements and customer experience.
    /// Some operations may be restricted when the display is unavailable.
    /// </remarks>
    public required bool VfdDisplayDisconnected { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the printer cover is open.
    /// </summary>
    /// <value>
    /// <c>true</c> if the printer cover is open; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// An open cover typically prevents printing operations for safety and print quality reasons.
    /// This condition must be resolved before fiscal operations can continue. The cover protects
    /// the print mechanism and paper path from environmental contamination.
    /// </remarks>
    public required bool PrinterCover { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether there is a paper-related error condition.
    /// </summary>
    /// <value>
    /// <c>true</c> if there is no paper, paper jam, or other paper-related error; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// Paper errors include out-of-paper conditions, paper jams, or incorrect paper feeding.
    /// These conditions prevent receipt printing and must be resolved before fiscal operations
    /// can continue. Regular paper monitoring helps prevent transaction interruptions.
    /// </remarks>
    public required bool PaperError { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether sales have been ongoing for more than 24 hours without a fiscal day closure.
    /// </summary>
    /// <value>
    /// <c>true</c> if sales have exceeded the 24-hour limit without day closure; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// Fiscal regulations typically require daily closure procedures within 24 hours of opening.
    /// This flag indicates a compliance issue that must be addressed by printing a Z-report
    /// and properly closing the fiscal day before new transactions can be processed.
    /// </remarks>
    public required bool SalesOver24Hours { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether there is a printing mechanism hardware failure.
    /// </summary>
    /// <value>
    /// <c>true</c> if the printing mechanism has failed or is malfunctioning; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// Print mechanism failures can include thermal head problems, motor malfunctions, or other
    /// hardware issues that prevent proper document printing. This condition typically requires
    /// technical service and may prevent all printing operations.
    /// </remarks>
    public required bool PrintingMechanismFailure { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the printer's backup battery is low.
    /// </summary>
    /// <value>
    /// <c>true</c> if the backup battery is low or depleted; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// The backup battery maintains fiscal memory and real-time clock during power outages.
    /// A low battery condition indicates potential data loss risk and should be addressed
    /// promptly to maintain fiscal compliance and prevent memory corruption.
    /// </remarks>
    public required bool LowBattery { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the printer has been suspended by user action.
    /// </summary>
    /// <value>
    /// <c>true</c> if the printer is in user-suspended state; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// User suspension typically occurs when operators manually pause operations for maintenance,
    /// cash handling, or other administrative tasks. Normal operations cannot proceed while
    /// the printer is in suspended state.
    /// </remarks>
    public required bool UserSuspend { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the fiscal day is currently open and accepting transactions.
    /// </summary>
    /// <value>
    /// <c>true</c> if the fiscal day is open; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// Most fiscal operations require an open day. When the day is closed, only administrative
    /// operations like configuration changes and day opening procedures are available.
    /// The fiscal day must be explicitly opened with initial cash amounts.
    /// </remarks>
    public required bool DayOpened { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether self-service mode is enabled.
    /// </summary>
    /// <remarks>When self-service mode is enabled, <see cref="VfdDisplayDisconnected" /> is not an error.</remarks>
    public required bool SelfServiceMode { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether there is a communication error with the printer hardware.
    /// </summary>
    /// <value>
    /// <c>true</c> if communication with the printer has failed or is unreliable; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// Communication errors can be caused by connection problems, hardware malfunctions, or
    /// configuration issues. This condition typically prevents all printer operations until
    /// the communication link is restored.
    /// </remarks>
    public bool ErrorComm { get; set; }

    /// <summary>
    /// Determines whether the specified <see cref="PrinterStatus"/> is equal to the current instance.
    /// </summary>
    /// <param name="other">The <see cref="PrinterStatus"/> to compare with the current instance.</param>
    /// <returns>
    /// <c>true</c> if the specified <see cref="PrinterStatus"/> is equal to the current instance; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Two <see cref="PrinterStatus"/> instances are considered equal if all their status flags
    /// have the same values. This method is used to detect status changes that may require
    /// operational responses or user notifications.
    /// </remarks>
    public bool Equals(PrinterStatus? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return VfdDisplayDisconnected == other.VfdDisplayDisconnected &&
               PrinterCover == other.PrinterCover &&
               PaperError == other.PaperError &&
               SalesOver24Hours == other.SalesOver24Hours &&
               PrintingMechanismFailure == other.PrintingMechanismFailure &&
               LowBattery == other.LowBattery &&
               UserSuspend == other.UserSuspend &&
               DayOpened == other.DayOpened &&
               SelfServiceMode == other.SelfServiceMode &&
               ErrorComm == other.ErrorComm;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>
    /// <c>true</c> if the specified object is a <see cref="PrinterStatus"/> and is equal to the current instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals(object? obj) => Equals(obj as PrinterStatus);

    /// <summary>
    /// Returns a hash code for the current instance based on all status flag values.
    /// </summary>
    /// <returns>A hash code for the current <see cref="PrinterStatus"/>.</returns>
    /// <remarks>
    /// The hash code is computed from all status flags to ensure that instances with
    /// the same status values produce the same hash code for proper equality behavior.
    /// </remarks>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(VfdDisplayDisconnected);
        hashCode.Add(PrinterCover);
        hashCode.Add(PaperError);
        hashCode.Add(SalesOver24Hours);
        hashCode.Add(PrintingMechanismFailure);
        hashCode.Add(LowBattery);
        hashCode.Add(UserSuspend);
        hashCode.Add(DayOpened);
        hashCode.Add(SelfServiceMode);

        return hashCode.ToHashCode();
    }
}

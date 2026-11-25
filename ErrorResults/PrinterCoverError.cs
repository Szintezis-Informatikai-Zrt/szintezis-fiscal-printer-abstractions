namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when the fiscal printer's cover is open, preventing
/// normal printing operations and ensuring security of the fiscal mechanism.
/// </summary>
/// <remarks>
/// Printer cover errors are critical security and operational issues that prevent fiscal
/// printing when the printer's protective cover is open or improperly secured. The cover
/// protection mechanism is essential for maintaining fiscal integrity, preventing unauthorized
/// access to the printing mechanism, and ensuring compliance with fiscal regulations that
/// require secure printer operation.
/// 
/// <para>
/// Printer cover protection serves several important purposes:
/// <list type="bullet">
/// <item><description>Preventing unauthorized access to fiscal printing mechanisms</description></item>
/// <item><description>Ensuring paper path integrity and preventing paper jams or foreign object interference</description></item>
/// <item><description>Maintaining thermal head protection and optimal printing conditions</description></item>
/// <item><description>Compliance with fiscal regulations requiring secure printer operation</description></item>
/// <item><description>Protecting internal components from dust, debris, and environmental factors</description></item>
/// <item><description>Preventing tampering with fiscal memory or printing mechanisms</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve printer cover errors, ensure that the printer cover is properly closed and
/// securely latched, check for any obstructions preventing proper cover closure, verify
/// that cover sensors are functioning correctly, and confirm that the cover mechanism
/// is not damaged or misaligned.
/// </para>
/// </remarks>
public sealed class PrinterCoverError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the printer cover security condition.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that the printer cover is open and preventing operations.
    /// </value>
    public override string Message { get; } = "Printer cover.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "PrinterCoverError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(PrinterCoverError);
}

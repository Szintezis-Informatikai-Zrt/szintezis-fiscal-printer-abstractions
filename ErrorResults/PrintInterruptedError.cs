namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when a printing operation is unexpectedly interrupted before completion,
/// potentially causing document corruption or incomplete fiscal transactions.
/// </summary>
/// <remarks>
/// Print interruption errors are critical issues that occur when fiscal document printing is halted
/// before completion due to hardware failures, power issues, or other unexpected conditions. These
/// errors can create fiscal compliance problems and require careful handling to maintain transaction
/// integrity and audit trail accuracy.
/// 
/// <para>
/// Common causes of print interruption include:
/// <list type="bullet">
/// <item><description>Power failures or voltage fluctuations during printing operations</description></item>
/// <item><description>Paper jams or mechanical failures in the printing mechanism</description></item>
/// <item><description>Communication timeouts or connection losses with the printer</description></item>
/// <item><description>Thermal head overheating or other hardware protection mechanisms</description></item>
/// <item><description>System crashes or software failures during document generation</description></item>
/// <item><description>User interruptions or emergency stops during critical operations</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve print interruption errors, check the printer hardware status, verify paper and
/// power supply conditions, assess the transaction state for completeness, and determine whether
/// the interrupted document needs to be reprinted or if the transaction should be cancelled.
/// Proper error recovery procedures are essential for maintaining fiscal compliance.
/// </para>
/// </remarks>
public sealed class PrintInterruptedError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the print interruption condition.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that the printing operation was unexpectedly halted.
    /// </value>
    public override string Message { get; } = "Print operation was interrupted.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "PrintInterruptedError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(PrintInterruptedError);
}

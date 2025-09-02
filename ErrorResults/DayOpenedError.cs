namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when attempting to perform operations that require a closed fiscal day
/// while the fiscal day is currently open.
/// </summary>
/// <remarks>
/// This error is thrown when trying to execute configuration operations, system maintenance tasks,
/// or administrative functions that can only be performed when the fiscal day is closed. Common
/// scenarios include setting receipt limits, configuring currencies, or updating payment method names.
/// 
/// <para>
/// To resolve this error, the fiscal day must be properly closed by printing a Z-report using the
/// day closing procedures before attempting the restricted operation again.
/// </para>
/// </remarks>
public sealed class DayOpenedError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the day opened condition.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that the fiscal day is currently open and preventing the operation.
    /// </value>
    public new string Message { get; } = "Day opened.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "DayOpenedError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(DayOpenedError);
}

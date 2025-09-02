namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when fiscal transactions have been ongoing for more than 24 hours
/// without proper fiscal day closure, violating regulatory compliance requirements.
/// </summary>
/// <remarks>
/// This error is triggered when sales operations continue beyond the mandatory 24-hour fiscal period
/// without performing the required day closure procedures. Fiscal regulations typically require that
/// business days be closed within 24 hours of opening to ensure proper tax reporting, audit trails,
/// and compliance with fiscal memory requirements.
/// 
/// <para>
/// The 24-hour limit serves several important regulatory purposes:
/// <list type="bullet">
/// <item><description>Ensures regular fiscal reporting and tax calculation cycles</description></item>
/// <item><description>Maintains proper audit trail boundaries for daily operations</description></item>
/// <item><description>Prevents excessive accumulation of fiscal data without proper closure</description></item>
/// <item><description>Supports regulatory compliance for tax authority reporting requirements</description></item>
/// <item><description>Ensures fiscal memory integrity and prevents data overflow conditions</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve this error, immediately perform a fiscal day closure by printing a Z-report using the
/// day closing procedures. This will reset the fiscal period and allow normal operations to resume.
/// The closure process finalizes all daily transactions and prepares the system for the next
/// business day's operations.
/// </para>
/// </remarks>
public sealed class SalesOver24HoursError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the 24-hour sales period violation.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that sales have exceeded the regulatory 24-hour limit.
    /// </value>
    public new string Message { get; } = "Sales over 24 hours.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "SalesOver24HoursError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(SalesOver24HoursError);
}

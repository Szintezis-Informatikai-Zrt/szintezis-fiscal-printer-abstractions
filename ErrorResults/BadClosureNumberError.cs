namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when an invalid or non-existent closure number is referenced
/// in fiscal operations requiring access to historical transaction data.
/// </summary>
/// <remarks>
/// Closure numbers represent fiscal periods (typically daily periods) that have been finalized
/// and closed in the fiscal printer's memory. Bad closure number errors occur when operations
/// attempt to reference closure periods that don't exist, haven't been created yet, or contain
/// invalid formatting. This prevents access to historical transaction data and can disrupt
/// audit procedures or document retrieval operations.
/// 
/// <para>
/// Common causes of bad closure number errors include:
/// <list type="bullet">
/// <item><description>Referencing future closure numbers that haven't been created yet</description></item>
/// <item><description>Using closure numbers from different fiscal printers or systems</description></item>
/// <item><description>Data corruption affecting closure number storage or retrieval</description></item>
/// <item><description>System integration errors with incorrect closure number mapping</description></item>
/// <item><description>Manual entry errors when inputting closure numbers for document retrieval</description></item>
/// <item><description>Attempting to access closure periods that have been archived or purged</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve bad closure number errors, verify that the closure number exists in the fiscal
/// printer's memory, check the valid range of closure numbers for the specific device, ensure
/// that the closure period has been properly finalized, and confirm that the correct fiscal
/// printer is being referenced for the historical data request.
/// </para>
/// </remarks>
public sealed class BadClosureNumberError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the closure number validation failure.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that an invalid closure number was referenced.
    /// </value>
    public new string Message { get; } = "Bad closure number.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "BadClosureNumberError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(BadClosureNumberError);
}


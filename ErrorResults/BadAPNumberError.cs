namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when an invalid or incorrect apparatus (AP) number is provided
/// for fiscal operations that require proper device identification.
/// </summary>
/// <remarks>
/// The apparatus number is a unique identifier assigned to each fiscal printer by tax authorities
/// and is essential for proper fiscal compliance and audit trails. Bad AP number errors occur when
/// operations reference incorrect, non-existent, or improperly formatted apparatus numbers, which
/// can prevent transaction processing and violate fiscal regulations.
/// 
/// <para>
/// Common causes of bad AP number errors include:
/// <list type="bullet">
/// <item><description>Referencing transactions from a different fiscal printer device</description></item>
/// <item><description>Using outdated apparatus numbers after device replacement or reconfiguration</description></item>
/// <item><description>Data entry errors when manually inputting apparatus numbers</description></item>
/// <item><description>System integration issues where wrong device identifiers are used</description></item>
/// <item><description>Attempting operations on apparatus numbers not registered with tax authorities</description></item>
/// <item><description>Format errors in apparatus number representation or encoding</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve bad AP number errors, verify the correct apparatus number for the target device,
/// ensure that the apparatus is properly registered with tax authorities, check for data entry
/// errors, and confirm that the device identification matches the fiscal printer being used.
/// </para>
/// </remarks>
public sealed class BadAPNumberError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the apparatus number validation failure.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that an invalid apparatus number was provided.
    /// </value>
    public new string Message { get; } = "Bad AP number.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "BadAPNumberError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(BadAPNumberError);
}

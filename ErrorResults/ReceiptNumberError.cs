namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when there are problems with receipt number generation, validation,
/// or processing, including custom error messages that provide specific diagnostic information.
/// </summary>
/// <remarks>
/// Receipt number errors encompass various issues related to the generation, assignment, validation,
/// or processing of receipt numbers in the fiscal system. These errors can occur during receipt
/// creation, sequence number validation, or when attempting to reference receipt numbers for
/// other operations. The custom error message provides specific details about the nature of the
/// receipt number problem for targeted troubleshooting.
/// 
/// <para>
/// Common receipt number issues include:
/// <list type="bullet">
/// <item><description>Receipt number sequence generation failures or gaps</description></item>
/// <item><description>Invalid receipt number formats or character encoding issues</description></item>
/// <item><description>Receipt number validation failures against system constraints</description></item>
/// <item><description>Database or storage issues affecting receipt number persistence</description></item>
/// <item><description>Synchronization problems in multi-terminal environments</description></item>
/// <item><description>Receipt number overflow or limit exceeded conditions</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// The error message provides specific diagnostic information about the receipt number problem,
/// enabling targeted troubleshooting and resolution strategies. Common solutions include verifying
/// receipt number sequence configuration, checking database integrity, ensuring proper system
/// synchronization, and validating receipt number formatting requirements.
/// </para>
/// </remarks>
public class ReceiptNumberError(string errorMessage) : ErrorBase
{
    /// <summary>
    /// Gets the custom error message providing specific details about the receipt number problem.
    /// </summary>
    /// <value>
    /// A descriptive message that explains the specific nature of the receipt number error encountered.
    /// </value>
    /// <remarks>
    /// The custom error message provides targeted diagnostic information about what went wrong
    /// with receipt number processing. This detailed information helps identify the root cause
    /// of the problem and guides appropriate resolution strategies, whether they involve
    /// configuration changes, data corrections, or system adjustments.
    /// </remarks>
    public override string Message { get; } = errorMessage;

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "ReceiptNumberError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(ReceiptNumberError);
}

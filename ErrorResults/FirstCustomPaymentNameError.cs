using CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when there are issues with the first custom payment method
/// configuration, which has special significance in fiscal printer systems.
/// </summary>
/// <remarks>
/// The first custom payment method position typically has special meaning in fiscal printer
/// systems and may be reserved for specific functionality such as automatic fiscal receipt (AFR)
/// operations or have particular regulatory requirements. Errors with the first custom payment
/// name can affect system initialization, compliance procedures, and specialized payment processing.
/// 
/// <para>
/// Common issues with the first custom payment method include:
/// <list type="bullet">
/// <item><description>Attempting to use reserved names that conflict with system functionality</description></item>
/// <item><description>Configuration errors that affect AFR or specialized payment processing</description></item>
/// <item><description>Regulatory compliance issues where the first position has specific requirements</description></item>
/// <item><description>System initialization problems related to primary payment method configuration</description></item>
/// <item><description>Integration conflicts where the first payment method affects other system components</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve first custom payment name errors, review the system documentation for special
/// requirements regarding the first payment method position, ensure that the name doesn't
/// conflict with reserved functionality, verify compliance with regulatory requirements,
/// and check for integration dependencies that may be affected by the first payment method
/// configuration.
/// </para>
/// </remarks>
public sealed class FirstCustomPaymentNameError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the first custom payment method configuration issue.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that there is a problem with the first custom payment method name.
    /// </value>
    public new string Message { get; } = "First custom payment name error.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "FirstCustomPaymentNameError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(FirstCustomPaymentNameError);
}

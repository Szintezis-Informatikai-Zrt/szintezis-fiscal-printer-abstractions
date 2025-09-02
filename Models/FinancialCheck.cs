namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a comprehensive financial reconciliation check that verifies cash drawer contents
/// and payment method balances against expected values for audit and accountability purposes.
/// </summary>
/// <remarks>
/// Financial checks provide essential accountability and audit functionality by enabling
/// systematic verification of cash drawer contents and payment method balances. These checks
/// are typically performed during shift changes, day closure procedures, or when discrepancies
/// are suspected. The process helps maintain financial accuracy and provides audit trails
/// for cash management procedures.
/// 
/// <para>
/// Financial checks serve multiple critical business functions:
/// <list type="bullet">
/// <item><description>Shift change accountability and cash handover procedures</description></item>
/// <item><description>Daily reconciliation and cash management verification</description></item>
/// <item><description>Audit trail documentation for financial oversight</description></item>
/// <item><description>Discrepancy identification and resolution procedures</description></item>
/// <item><description>Compliance verification for financial controls and procedures</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// The financial check process typically involves comparing expected payment method balances
/// with actual system-reported amounts, identifying any variances, and documenting the
/// results for audit and accountability purposes.
/// </para>
/// </remarks>
public sealed class FinancialCheck
{
    /// <summary>
    /// Gets or sets the cloud system identifier for this financial check operation.
    /// </summary>
    /// <value>
    /// A unique identifier that links this financial check to cloud-based systems or central reporting.
    /// </value>
    /// <remarks>
    /// The cloud ID enables integration with centralized financial management systems,
    /// allowing multi-location businesses to coordinate financial checks across different
    /// locations and maintain centralized audit trails. This identifier facilitates
    /// cloud-based reporting and consolidated financial oversight.
    /// </remarks>
    public required int CloudId { get; set; }

    /// <summary>
    /// Gets or sets the name of the cashier performing or responsible for this financial check.
    /// </summary>
    /// <value>
    /// The identifier or name of the cashier conducting the financial reconciliation.
    /// </value>
    /// <remarks>
    /// The cashier name provides accountability for the financial check process, linking
    /// the reconciliation to a specific individual responsible for the cash drawer during
    /// the period being verified. This information is essential for audit trails and
    /// helps establish clear responsibility for cash management procedures.
    /// </remarks>
    public required string Cashiername { get; set; }

    /// <summary>
    /// Gets or sets the collection of payment method verification requests for this financial check.
    /// </summary>
    /// <value>
    /// A list of <see cref="PaymentRequest"/> objects representing the payment methods and amounts to be verified.
    /// </value>
    /// <remarks>
    /// Payment requests specify which payment methods should be verified and their expected
    /// amounts for comparison with actual system balances. This comprehensive verification
    /// ensures that all payment methods are properly accounted for and that any discrepancies
    /// are identified and documented as part of the financial check process.
    /// </remarks>
    public List<PaymentRequest> Payments { get; set; } = [];
}

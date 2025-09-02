namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a request for payment method information and current balance details
/// from the fiscal printer system for cash management and reporting purposes.
/// </summary>
/// <remarks>
/// Payment requests enable applications to query the current state of payment methods
/// and their accumulated balances in the fiscal system. This information is essential
/// for cash drawer reconciliation, financial reporting, operational management, and
/// real-time monitoring of payment method performance throughout the business day.
/// 
/// <para>
/// Payment request functionality supports various business operations:
/// <list type="bullet">
/// <item><description>Real-time cash drawer balance monitoring</description></item>
/// <item><description>Shift change reconciliation procedures</description></item>
/// <item><description>Payment method performance analysis</description></item>
/// <item><description>Financial reporting and daily summaries</description></item>
/// <item><description>Operational decision-making for cash management</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// The information retrieved through payment requests provides accurate, real-time
/// financial data that helps businesses maintain effective cash management and
/// operational oversight.
/// </para>
/// </remarks>
public sealed class PaymentRequest
{
    /// <summary>
    /// Gets or sets the name or identifier of the payment method being requested.
    /// </summary>
    /// <value>
    /// A descriptive name for the payment method such as "Local Cash", "Credit Card", "EUR", or custom payment names.
    /// Defaults to an empty string.
    /// </value>
    /// <remarks>
    /// The payment method name identifies which specific payment instrument's information
    /// is being requested. This should match the names used in the fiscal system configuration
    /// to ensure accurate retrieval of payment method data and balance information.
    /// </remarks>
    public string Name { get; set; } = "";

    /// <summary>
    /// Gets or sets the expected or target amount for comparison with actual payment method balance.
    /// </summary>
    /// <value>
    /// The monetary amount for comparison or verification purposes. Defaults to 0.
    /// </value>
    /// <remarks>
    /// The amount can be used for balance verification, target comparisons, or as a reference
    /// point for reconciliation procedures. When used in verification scenarios, this amount
    /// can be compared against the actual payment method balance to identify discrepancies
    /// or confirm expected values.
    /// </remarks>
    public decimal Amount { get; set; } = 0;

    /// <summary>
    /// Gets or sets the number of decimal places to use when formatting monetary amounts in the response.
    /// </summary>
    /// <value>
    /// The precision level for amount formatting (typically 2 for most currencies). Defaults to 0.
    /// </value>
    /// <remarks>
    /// Decimal places control how monetary amounts are formatted in the payment response,
    /// ensuring appropriate precision for the currency being used. Most currencies use
    /// 2 decimal places, but the precision should match business requirements and
    /// currency standards for proper financial reporting and display.
    /// </remarks>
    public int DecPlaces { get; set; } = 0;
}

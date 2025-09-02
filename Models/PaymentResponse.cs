using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents the current balance information for a specific payment method in the cash drawer,
/// providing real-time financial status for cash management and reconciliation purposes.
/// </summary>
/// <remarks>
/// Payment responses contain the current accumulated amounts for each payment method tracked
/// by the fiscal system. This information is essential for cash drawer reconciliation, financial
/// reporting, and operational management. The data reflects all transactions processed since
/// the fiscal day was opened, including sales, returns, cash operations, and other activities
/// that affect payment method balances.
/// 
/// <para>
/// Payment response data serves multiple operational purposes:
/// <list type="bullet">
/// <item><description>Cash drawer reconciliation at shift changes or day closure</description></item>
/// <item><description>Real-time monitoring of cash and payment method balances</description></item>
/// <item><description>Financial reporting and daily sales analysis</description></item>
/// <item><description>Security monitoring and fraud prevention</description></item>
/// <item><description>Operational decision-making for cash management</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// The balance information is updated in real-time as transactions are processed and provides
/// accurate financial status for effective business operations and compliance monitoring.
/// </para>
/// </remarks>
public sealed class PaymentResponse
{
    /// <summary>
    /// Gets or sets the human-readable name of the payment method.
    /// </summary>
    /// <value>
    /// A descriptive name for the payment method such as "Local Cash", "Credit Card", "EUR", or custom payment method names.
    /// </value>
    /// <remarks>
    /// The payment method name provides clear identification of the payment instrument for
    /// operational staff and financial reporting. Names should be consistent with those used
    /// in transaction processing and system configuration to ensure accurate tracking and
    /// reconciliation activities.
    /// </remarks>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the current accumulated amount for this payment method.
    /// </summary>
    /// <value>
    /// The total monetary value currently held or tracked for this payment method in the local currency.
    /// </value>
    /// <remarks>
    /// The amount represents the net total for this payment method since the fiscal day was opened,
    /// including all sales receipts, returns, cash operations, and other transactions. For cash
    /// payments, this typically represents the physical cash in the drawer. For electronic payments,
    /// this represents the accumulated transaction value. Foreign currency amounts are converted
    /// to local currency using configured exchange rates.
    /// </remarks>
    public required decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the payment mode classification for this payment method.
    /// </summary>
    /// <value>
    /// A <see cref="PaidMode"/> value indicating the specific payment instrument type,
    /// or <c>null</c> if the payment mode is not specified or applicable.
    /// </value>
    /// <remarks>
    /// The payment mode provides technical classification of the payment method for system
    /// integration and processing purposes. It links the human-readable name to the internal
    /// payment processing categories and ensures consistent handling across different system
    /// components and integrations.
    /// </remarks>
    public PaidMode? PaidMode { get; set; }
}

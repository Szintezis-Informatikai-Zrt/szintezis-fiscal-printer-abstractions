using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a payment tender consisting of a payment method and amount, used for cash drawer operations,
/// day opening procedures, and multi-payment transactions.
/// </summary>
/// <remarks>
/// Tenders are fundamental units of payment that specify both the payment instrument and the amount
/// being processed. They are used in various fiscal operations including transaction payments,
/// cash drawer management (pay-in/pay-out operations), fiscal day opening procedures, and
/// cash reconciliation activities. Each tender represents a specific amount in a particular
/// payment method that affects cash drawer totals and fiscal reporting.
/// </remarks>
public sealed class Tender
{
    /// <summary>
    /// Gets or sets the payment method used for this tender.
    /// </summary>
    /// <value>
    /// A <see cref="PaidMode"/> value indicating the specific payment instrument or method being used.
    /// </value>
    /// <remarks>
    /// The payment mode determines how this tender affects cash drawer operations, currency conversion
    /// requirements, and fiscal reporting categories. Different payment modes have different handling
    /// requirements - for example, cash affects physical drawer totals while cards are tracked
    /// electronically, and foreign currencies require exchange rate calculations.
    /// </remarks>
    public PaidMode PaidMode { get; set; }

    /// <summary>
    /// Gets or sets the monetary amount for this tender.
    /// </summary>
    /// <value>
    /// The amount in the tender's currency or payment method denomination.
    /// </value>
    /// <remarks>
    /// The amount represents the value being processed for this specific payment method. For foreign
    /// currency tenders, this amount is in the foreign currency units and will be converted to local
    /// currency using configured exchange rates. For cash drawer operations, this amount directly
    /// affects the drawer balance for the specified payment method.
    /// </remarks>
    public decimal Amount { get; set; }
}

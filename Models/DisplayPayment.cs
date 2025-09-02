namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents payment information to be displayed on the customer-facing display during payment processing,
/// showing payment method details and remaining balance information for transaction transparency.
/// </summary>
/// <remarks>
/// Display payment information provides real-time feedback to customers during the payment process,
/// showing which payment method is being used, the amount being paid, and any remaining balance.
/// This enhances customer understanding of multi-payment transactions and provides transparency
/// throughout the payment process, improving customer confidence and reducing payment confusion.
/// 
/// <para>
/// Payment display information is particularly valuable for:
/// <list type="bullet">
/// <item><description>Multi-payment transactions using various payment methods</description></item>
/// <item><description>Foreign currency payments requiring conversion display</description></item>
/// <item><description>Partial payments where remaining balances need to be shown</description></item>
/// <item><description>Complex transactions requiring payment verification</description></item>
/// <item><description>Customer education about payment processing status</description></item>
/// </list>
/// </para>
/// </remarks>
public sealed class DisplayPayment
{
    /// <summary>
    /// Gets or sets the display duration in milliseconds before the payment information automatically updates.
    /// </summary>
    /// <value>
    /// The time in milliseconds that this payment information will remain visible on the customer display.
    /// Default value is 300 milliseconds.
    /// </value>
    /// <remarks>
    /// The display time allows customers sufficient opportunity to verify payment details while
    /// maintaining efficient payment processing flow. Longer display times may be appropriate
    /// for complex payments or when customer verification is particularly important.
    /// </remarks>
    public int Time { get; set; } = 300;

    /// <summary>
    /// Gets or sets the human-readable name of the payment method being used.
    /// </summary>
    /// <value>
    /// A descriptive name for the payment instrument such as "Cash", "Credit Card", "EUR", or custom payment method names.
    /// </value>
    /// <remarks>
    /// The payment instrument name helps customers understand which payment method is currently
    /// being processed. This is particularly useful in multi-payment scenarios where customers
    /// use different payment methods for a single transaction, or when foreign currencies are involved.
    /// </remarks>
    public required string PaymentInstrumentName { get; set; }

    /// <summary>
    /// Gets or sets the amount being paid using this payment method.
    /// </summary>
    /// <value>
    /// The monetary value being processed for this specific payment method.
    /// </value>
    /// <remarks>
    /// This amount represents the portion of the total transaction being covered by this
    /// specific payment method. For foreign currency payments, this amount is typically
    /// in the foreign currency units before conversion to local currency.
    /// </remarks>
    public decimal PayValue { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal places to display for the payment amount.
    /// </summary>
    /// <value>
    /// The precision level for payment amount formatting (typically 2 for most currencies).
    /// </value>
    /// <remarks>
    /// Decimal precision ensures that payment amounts are displayed appropriately for the
    /// currency being used. Most currencies use 2 decimal places, but some may require
    /// different precision levels for proper customer understanding and legal compliance.
    /// </remarks>
    public int PayDecimalPlaces { get; set; }

    /// <summary>
    /// Gets or sets the currency symbol for the payment amount.
    /// </summary>
    /// <value>
    /// The currency symbol or abbreviation (e.g., "$", "€", "Ft") to display with the payment amount.
    /// </value>
    /// <remarks>
    /// The currency sign provides essential context for payment amounts, ensuring customers
    /// clearly understand the currency being used for this payment method. This is particularly
    /// important in foreign currency transactions or multi-currency environments.
    /// </remarks>
    public required string PayCurrencySign { get; set; }

    /// <summary>
    /// Gets or sets the remaining balance due after this payment is applied.
    /// </summary>
    /// <value>
    /// The amount still owed by the customer after this payment is processed.
    /// </value>
    /// <remarks>
    /// The remainder shows customers how much they still need to pay after this payment
    /// method is applied. This is crucial for multi-payment transactions and helps customers
    /// understand their payment progress. A remainder of zero indicates the transaction
    /// is fully paid.
    /// </remarks>
    public decimal Remainder { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal places to display for the remaining balance.
    /// </summary>
    /// <value>
    /// The precision level for remainder amount formatting (typically 2 for local currency).
    /// </value>
    /// <remarks>
    /// Decimal precision for the remainder ensures consistent monetary display formatting
    /// and proper customer understanding of the remaining payment obligation.
    /// </remarks>
    public int DecimalPlaces { get; set; }

    /// <summary>
    /// Gets or sets the currency symbol for the remaining balance amount.
    /// </summary>
    /// <value>
    /// The currency symbol or abbreviation for the remaining balance, typically in local currency.
    /// </value>
    /// <remarks>
    /// The remainder currency sign ensures customers understand the currency for the remaining
    /// balance, which is typically in local currency even when foreign currency payments
    /// are being processed.
    /// </remarks>
    public required string CurrencySign { get; set; }
}


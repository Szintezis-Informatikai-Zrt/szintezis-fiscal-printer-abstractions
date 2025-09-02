namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents total amount information to be displayed on the customer-facing display,
/// showing transaction totals, amounts due, or other monetary summaries during checkout.
/// </summary>
/// <remarks>
/// Display totals provide customers with clear visibility into their transaction amounts,
/// including subtotals, final totals, amounts due for payment, or remaining balances.
/// This enhances transaction transparency and allows customers to verify amounts before
/// payment processing. The display automatically formats amounts with appropriate
/// decimal precision and currency symbols for optimal customer readability.
/// </remarks>
public sealed class DisplayTotal
{
    /// <summary>
    /// Gets or sets the display duration in milliseconds before the display automatically updates.
    /// </summary>
    /// <value>
    /// The time in milliseconds that this total information will remain visible on the customer display.
    /// Default value is 300 milliseconds.
    /// </value>
    /// <remarks>
    /// The display time gives customers adequate opportunity to review and verify total amounts
    /// while maintaining checkout flow efficiency. Longer display times may be appropriate for
    /// high-value transactions or when customer verification is particularly important.
    /// </remarks>
    public int Time { get; set; } = 300;

    /// <summary>
    /// Gets or sets the monetary amount to display to the customer.
    /// </summary>
    /// <value>
    /// The total amount value in the transaction currency to be shown on the customer display.
    /// </value>
    /// <remarks>
    /// This value represents the monetary total being communicated to the customer, such as
    /// transaction subtotal, final total including taxes, amount due for payment, or remaining
    /// balance. Clear display of amounts enhances customer confidence and transaction transparency.
    /// </remarks>
    public decimal Value { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal places to display for the monetary amount.
    /// </summary>
    /// <value>
    /// The precision level for monetary display formatting (typically 2 for most currencies).
    /// </value>
    /// <remarks>
    /// Decimal places ensure that monetary amounts are displayed with appropriate precision
    /// for the currency being used. Most currencies use 2 decimal places, but some may
    /// require different precision levels for proper customer understanding and legal compliance.
    /// </remarks>
    public int DecimalPlaces { get; set; }

    /// <summary>
    /// Gets or sets the currency symbol to display with the monetary amount.
    /// </summary>
    /// <value>
    /// The currency symbol or abbreviation (e.g., "$", "€", "Ft") to display with the amount.
    /// </value>
    /// <remarks>
    /// The currency sign provides essential context for monetary amounts, ensuring customers
    /// clearly understand the currency being used for their transaction. This is particularly
    /// important in international retail environments or when multiple currencies are accepted.
    /// </remarks>
    public required string CurrencySign { get; set; }
}


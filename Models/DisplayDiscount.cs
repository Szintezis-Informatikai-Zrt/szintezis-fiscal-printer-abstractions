namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents discount information to be displayed on the customer-facing display during checkout,
/// showing customers the savings they are receiving through promotional offers or price reductions.
/// </summary>
/// <remarks>
/// Display discount information enhances customer satisfaction and transaction transparency by
/// clearly showing the value of discounts being applied to their purchase. This visibility
/// helps customers understand promotional benefits, appreciate savings, and builds confidence
/// in the fairness and accuracy of the pricing system.
/// 
/// <para>
/// Discount displays are particularly valuable for:
/// <list type="bullet">
/// <item><description>Promotional campaigns and special offers</description></item>
/// <item><description>Loyalty program benefits and member discounts</description></item>
/// <item><description>Volume discounts and quantity-based savings</description></item>
/// <item><description>Seasonal sales and clearance promotions</description></item>
/// <item><description>Customer service gestures and goodwill adjustments</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// Clear discount communication helps customers feel valued, understand promotional benefits,
/// and encourages future purchases by highlighting the savings they receive.
/// </para>
/// </remarks>
public sealed class DisplayDiscount
{
    /// <summary>
    /// Gets or sets the percentage value of the discount being applied.
    /// </summary>
    /// <value>
    /// The discount percentage (e.g., 10 for 10% discount), or <c>null</c> if this is a fixed-amount discount.
    /// </value>
    /// <remarks>
    /// Percentage discounts show customers the proportional savings they are receiving relative
    /// to the original price. This is particularly effective for promotional displays as customers
    /// can easily understand the value of percentage-based offers. When null, the discount is
    /// a fixed monetary amount rather than a percentage.
    /// </remarks>
    public decimal? Percentage { get; set; }

    /// <summary>
    /// Gets or sets the monetary amount of the discount in the transaction currency.
    /// </summary>
    /// <value>
    /// The discount amount that will be deducted from the customer's total.
    /// </value>
    /// <remarks>
    /// The discount amount shows customers the actual monetary savings they are receiving,
    /// providing concrete value demonstration. For percentage discounts, this represents
    /// the calculated discount amount. For fixed-amount discounts, this represents the
    /// predetermined discount value being applied.
    /// </remarks>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the currency symbol to display with the discount amount.
    /// </summary>
    /// <value>
    /// The currency symbol or abbreviation (e.g., "$", "€", "Ft") to display with the discount amount,
    /// or <c>null</c> if no currency symbol should be displayed.
    /// </value>
    /// <remarks>
    /// The currency sign provides essential context for the discount amount, ensuring customers
    /// clearly understand the monetary value of their savings. This is particularly important
    /// in international retail environments or when multiple currencies are involved in transactions.
    /// </remarks>
    public string? CurrencySign { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal places to display for the discount amount.
    /// </summary>
    /// <value>
    /// The precision level for discount amount formatting. Default value is 0 for whole number display.
    /// </value>
    /// <remarks>
    /// Decimal precision determines how the discount amount is formatted for customer display.
    /// A value of 0 shows whole numbers (e.g., "5"), while 2 shows standard currency precision
    /// (e.g., "5.00"). The precision should match the currency standards and business preferences
    /// for discount presentation to customers.
    /// </remarks>
    public int DecimalPlaces { get; set; } = 0;
}

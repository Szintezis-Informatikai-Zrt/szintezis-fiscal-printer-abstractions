namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents item information to be displayed on the customer-facing display during checkout,
/// providing real-time transaction transparency and customer verification capabilities.
/// </summary>
/// <remarks>
/// Display items show customers what is being scanned and added to their transaction in real-time.
/// This enhances customer experience by providing transparency and allows customers to verify
/// items, quantities, and prices as they are processed. The display formatting automatically
/// handles quantity precision and currency formatting for optimal customer readability.
/// </remarks>
public sealed class DisplayItem
{
    /// <summary>
    /// Gets or sets the display duration in milliseconds before the display automatically updates.
    /// </summary>
    /// <value>
    /// The time in milliseconds that this item information will remain visible on the customer display.
    /// Default value is 300 milliseconds.
    /// </value>
    /// <remarks>
    /// The display time allows customers sufficient time to verify the item information while
    /// maintaining a responsive checkout experience. Shorter times provide faster checkout flow,
    /// while longer times give customers more verification time for complex items.
    /// </remarks>
    public int Time { get; set; } = 300;

    /// <summary>
    /// Gets or sets the abbreviated name of the item to display to the customer.
    /// </summary>
    /// <value>
    /// A concise, customer-friendly product name that fits within display screen limitations.
    /// </value>
    /// <remarks>
    /// The item name should be clear and recognizable to customers while fitting within the
    /// display screen constraints (typically 19-20 characters for the first line). This helps
    /// customers verify that the correct item has been scanned and processed.
    /// </remarks>
    public required string ShortName { get; set; }

    /// <summary>
    /// Gets or sets the total value for this item (quantity × unit price).
    /// </summary>
    /// <value>
    /// The total monetary value for this item in the transaction currency.
    /// </value>
    /// <remarks>
    /// This value represents the line total that will be added to the customer's transaction.
    /// It allows customers to see the financial impact of each item as it's processed,
    /// enhancing transaction transparency and customer confidence.
    /// </remarks>
    public decimal Value { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the item being purchased.
    /// </summary>
    /// <value>
    /// The amount of the item, measured in the units specified by <see cref="SalesUnitCode"/>.
    /// </value>
    /// <remarks>
    /// Quantity information helps customers verify that the correct amount has been entered,
    /// particularly important for weighed items, bulk goods, or when multiple quantities
    /// of the same item are purchased.
    /// </remarks>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit of measure code for displaying quantity information.
    /// </summary>
    /// <value>
    /// A short code indicating the unit type (e.g., "kg", "pcs", "ltr") for customer understanding.
    /// </value>
    /// <remarks>
    /// The sales unit code helps customers understand how the quantity is measured, which is
    /// particularly important for weighed items, liquids, or items sold in specific units.
    /// This enhances customer comprehension of what they're purchasing.
    /// </remarks>
    public required string SalesUnitCode { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal places to display for quantity values.
    /// </summary>
    /// <value>
    /// The precision level for quantity display formatting (typically 0 for pieces, 2-3 for measured items).
    /// </value>
    /// <remarks>
    /// Precision ensures that quantity information is displayed appropriately for the item type.
    /// Piece items typically show no decimal places, while weighed or measured items show
    /// appropriate precision for customer understanding and verification.
    /// </remarks>
    public int Precision { get; set; }

    /// <summary>
    /// Gets or sets the currency symbol to display with monetary values.
    /// </summary>
    /// <value>
    /// The currency symbol or abbreviation (e.g., "$", "€", "Ft") to append to monetary displays.
    /// </value>
    /// <remarks>
    /// The currency sign provides clear monetary context for customers, particularly important
    /// in multi-currency environments or when foreign currencies are accepted. It ensures
    /// customers understand the currency being used for their transaction.
    /// </remarks>
    public required string CurrencySign { get; set; }
}


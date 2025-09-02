namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents an empties ticket for processing container deposit returns and bottle redemptions,
/// documenting returnable containers and calculating deposit refunds for customers.
/// </summary>
/// <remarks>
/// Empties tickets are specialized fiscal documents used primarily in retail environments that
/// handle container deposits, such as beverage stores, supermarkets, and recycling centers.
/// These tickets typically have negative monetary values representing refunds owed to customers
/// for returning deposit containers like bottles, cans, or reusable packaging materials.
/// 
/// <para>
/// Empties tickets serve several important functions:
/// <list type="bullet">
/// <item><description>Environmental compliance by encouraging container recycling</description></item>
/// <item><description>Deposit liability management for businesses</description></item>
/// <item><description>Customer incentive programs for sustainable practices</description></item>
/// <item><description>Inventory tracking for returnable container systems</description></item>
/// <item><description>Legal compliance with container deposit legislation</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// The fiscal treatment of empties tickets may involve special tax handling and requires proper
/// integration with inventory systems to track container flow and deposit liability management.
/// These transactions reduce business cash flow but also reduce container deposit liabilities.
/// </para>
/// </remarks>
public sealed class EmptiesTicket()
{
    /// <summary>
    /// Gets or sets the total refund amount to be paid to the customer for returned containers.
    /// </summary>
    /// <value>
    /// The total monetary value being refunded, typically negative to indicate money owed to the customer.
    /// </value>
    /// <remarks>
    /// The total amount represents the sum of all container deposit refunds. Since this is money
    /// being paid out to customers, the amount is typically negative in fiscal calculations,
    /// indicating a reduction in cash and deposit liabilities. The amount must equal the sum
    /// of all individual container deposit values being returned.
    /// </remarks>
    public required decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the barcode to be printed on the empties ticket for tracking and verification.
    /// </summary>
    /// <value>
    /// A string containing barcode data for the empties ticket transaction.
    /// </value>
    /// <remarks>
    /// The barcode on empties tickets often contains transaction identifiers, customer information,
    /// or redemption tracking codes that integrate with container return systems or customer
    /// loyalty programs. This enables automated processing and verification of container returns
    /// and helps prevent fraud in deposit redemption systems.
    /// </remarks>
    public required string Barcode { get; set; }

    /// <summary>
    /// Gets or sets the collection of returnable containers being processed in this empties ticket.
    /// </summary>
    /// <value>
    /// A list of <see cref="Item"/> objects representing individual container types and quantities being returned.
    /// </value>
    /// <remarks>
    /// Each item represents a specific type of returnable container with its associated deposit value.
    /// The items include detailed information about container types, quantities, and deposit amounts
    /// necessary for proper refund calculation and inventory tracking of returnable containers.
    /// </remarks>
    public List<Item> Items { get; set; } = [];

    /// <summary>
    /// Represents an individual type of returnable container being processed in the empties ticket.
    /// </summary>
    /// <remarks>
    /// Container items include detailed information about the specific type of returnable packaging,
    /// quantities being returned, and the deposit value associated with each container type.
    /// This information is essential for accurate refund calculation and container inventory management.
    /// </remarks>
    public sealed class Item
    {
        /// <summary>
        /// Gets or sets the descriptive name of the returnable container type.
        /// </summary>
        /// <value>
        /// A concise description of the container type for identification and customer reference.
        /// </value>
        /// <remarks>
        /// The container name helps identify the specific type of returnable packaging, such as
        /// "Glass Bottle 0.5L", "Aluminum Can 0.33L", or "Plastic Crate". This information
        /// appears on the empties ticket and helps customers verify their returns.
        /// </remarks>
        public required string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure for counting the returned containers.
        /// </summary>
        /// <value>
        /// A unit code indicating how containers are counted, typically "PCS" for pieces.
        /// </value>
        /// <remarks>
        /// Container returns are typically counted in pieces (individual containers), but may
        /// use other units for bulk containers or specialized packaging systems. The unit
        /// ensures proper quantity interpretation for refund calculations.
        /// </remarks>
        public required string SalesUnitTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the decimal precision for displaying container quantities.
        /// </summary>
        /// <value>
        /// The number of decimal places for quantity display, typically 0 for whole containers.
        /// </value>
        /// <remarks>
        /// Container quantities are usually whole numbers (individual containers), so precision
        /// is typically 0. However, some specialized systems may handle fractional quantities
        /// for damaged containers or partial returns.
        /// </remarks>
        public int Precision { get; set; }

        /// <summary>
        /// Gets or sets the quantity of containers of this type being returned.
        /// </summary>
        /// <value>
        /// The number of containers being returned for deposit refund.
        /// </value>
        /// <remarks>
        /// The quantity represents how many containers of this specific type are being returned.
        /// This number is multiplied by the individual container deposit value to calculate
        /// the total refund for this container type.
        /// </remarks>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the deposit value per individual container of this type.
        /// </summary>
        /// <value>
        /// The deposit amount that was originally charged for each container and is now being refunded.
        /// </value>
        /// <remarks>
        /// The gross price represents the deposit value per container that customers originally paid
        /// and are now receiving back. This amount is typically standardized by container type
        /// and may be regulated by deposit legislation or industry standards.
        /// </remarks>
        public decimal GrossPrice { get; set; }

        /// <summary>
        /// Gets or sets the total deposit value for all containers of this type (quantity × deposit value).
        /// </summary>
        /// <value>
        /// The total refund amount for this container type before any adjustments.
        /// </value>
        /// <remarks>
        /// This value should equal the quantity multiplied by the gross price and represents
        /// the total deposit refund for this specific container type. It contributes to the
        /// overall empties ticket total amount.
        /// </remarks>
        public decimal GrossValue { get; set; }

        /// <summary>
        /// Gets or sets the product code or identifier for this container type.
        /// </summary>
        /// <value>
        /// The unique identifier used to classify and track this specific container type.
        /// </value>
        /// <remarks>
        /// Product codes enable precise tracking of different container types in inventory
        /// and deposit management systems. They help ensure accurate refund processing and
        /// support integration with container tracking and recycling programs.
        /// </remarks>
        public required string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the VAT classification code for this container deposit transaction.
        /// </summary>
        /// <value>
        /// A tax classification code that may apply to container deposit transactions.
        /// </value>
        /// <remarks>
        /// Container deposits may have special tax treatment depending on local regulations.
        /// Some jurisdictions treat deposits as tax-neutral transactions, while others may
        /// apply specific tax rules to deposit refunds and container handling fees.
        /// </remarks>
        public required string VatCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this container item has been cancelled from the return.
        /// </summary>
        /// <value>
        /// <c>true</c> if this container type is cancelled and excluded from refund calculations; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Cancelled container items remain on the empties ticket for audit purposes but are
        /// excluded from refund calculations. This is useful for handling damaged containers,
        /// disputed returns, or corrections during the return processing.
        /// </remarks>
        public bool Cancelled { get; set; } = false;
    }
}

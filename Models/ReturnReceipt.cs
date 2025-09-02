using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a return receipt for merchandise being returned by customers, documenting the return transaction
/// and providing proper fiscal compliance for refund operations.
/// </summary>
/// <remarks>
/// Return receipts handle customer merchandise returns and typically result in refunds or store credit.
/// They maintain proper audit trails by referencing original purchase documents and provide clear
/// documentation of return reasons for business analysis and compliance purposes. Return receipts
/// ensure that inventory adjustments, financial impacts, and customer refunds are properly tracked
/// and documented within the fiscal system.
/// 
/// <para>
/// Return receipts support various return scenarios:
/// <list type="bullet">
/// <item><description>Customer dissatisfaction or product defects</description></item>
/// <item><description>Size, color, or specification changes</description></item>
/// <item><description>Duplicate purchases or ordering errors</description></item>
/// <item><description>Warranty returns and exchanges</description></item>
/// <item><description>Policy-based returns within return periods</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// All return operations must comply with business return policies, fiscal regulations,
/// and maintain complete audit trails for customer service and compliance purposes.
/// </para>
/// </remarks>
public sealed class ReturnReceipt
{
    /// <summary>
    /// Gets or sets the total amount being refunded to the customer for this return transaction.
    /// </summary>
    /// <value>
    /// The total monetary value being returned to the customer in the local currency.
    /// </value>
    /// <remarks>
    /// The total amount represents the financial impact of the return transaction and determines
    /// the refund amount to be processed. This amount is typically negative in fiscal calculations
    /// as it reduces the business revenue and increases cash outflow. The amount must be validated
    /// against the original purchase amounts and current return policies.
    /// </remarks>
    public required decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the reference information for the original purchase document being returned.
    /// </summary>
    /// <value>
    /// An <see cref="OriginalDocument"/> object containing details about the original purchase,
    /// or <c>null</c> if no original document reference is available.
    /// </value>
    /// <remarks>
    /// Original document information helps verify the legitimacy of the return and ensures that
    /// the return is processed against valid purchase records. This information is crucial for
    /// audit trails, return policy enforcement, and customer service verification. When available,
    /// it provides complete traceability between the return and the original transaction.
    /// </remarks>
    public OriginalDocument? OriginalDocument { get; set; }

    /// <summary>
    /// Gets or sets the reason code explaining why this merchandise return is being processed.
    /// </summary>
    /// <value>
    /// A string representing the return reason, typically corresponding to <see cref="ReturnReason"/> values.
    /// </value>
    /// <remarks>
    /// Return reasons are essential for business analysis, quality control, and customer service
    /// improvements. They help identify patterns in returns, track product quality issues, and
    /// support business decisions about product lines, suppliers, and return policies. Accurate
    /// reason codes also support warranty claims and supplier negotiations.
    /// </remarks>
    public required string ReturnReason { get; set; }

    /// <summary>
    /// Gets or sets the customer information for this return transaction.
    /// </summary>
    /// <value>
    /// A <see cref="Customer"/> object containing the customer details for return documentation.
    /// </value>
    /// <remarks>
    /// Customer information is important for return processing, refund authorization, and customer
    /// service tracking. It enables proper customer identification, return history tracking, and
    /// ensures that refunds are processed to the correct customer accounts. Complete customer
    /// information also supports return policy enforcement and fraud prevention.
    /// </remarks>
    public required Customer Customer { get; set; }

    /// <summary>
    /// Gets or sets the collection of payment methods used to process the refund for this return.
    /// </summary>
    /// <value>
    /// A list of <see cref="Tender"/> objects representing the refund payment methods and amounts.
    /// </value>
    /// <remarks>
    /// Refund tenders specify how the return amount will be refunded to the customer, such as
    /// cash refund, credit card reversal, store credit, or other refund methods. The refund
    /// method may depend on the original payment method, return policies, and customer preferences.
    /// Multiple tenders can be used for partial refunds or when splitting refunds across methods.
    /// </remarks>
    public List<Tender> Tenders { get; set; } = [];

    /// <summary>
    /// Gets or sets the collection of items being returned in this transaction.
    /// </summary>
    /// <value>
    /// A list of <see cref="Item"/> objects representing the specific products being returned.
    /// </value>
    /// <remarks>
    /// Return items provide detailed information about what merchandise is being returned,
    /// including quantities, prices, and product identification. This information is essential
    /// for inventory adjustments, quality tracking, and ensuring that the correct items are
    /// being processed for return.
    /// </remarks>
    public List<Item> Items { get; set; } = [];

    /// <summary>
    /// Represents an individual item being returned in a merchandise return transaction.
    /// </summary>
    /// <remarks>
    /// Return items include detailed product information necessary for proper inventory adjustments,
    /// quality tracking, and return processing. Each item maintains complete product identification
    /// to ensure accurate return processing and inventory management.
    /// </remarks>
    public sealed class Item
    {
        /// <summary>
        /// Gets or sets the position index of this item within the return transaction.
        /// </summary>
        /// <value>
        /// A sequential number indicating the order of this item in the return list.
        /// </value>
        /// <remarks>
        /// The index provides ordering information for return processing and helps maintain
        /// consistent item sequencing in return documentation and system processing.
        /// </remarks>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the abbreviated name of the item being returned.
        /// </summary>
        /// <value>
        /// A concise product name for identification and documentation purposes.
        /// </value>
        /// <remarks>
        /// The item name helps identify the product being returned for customer service,
        /// inventory management, and return documentation. It should be clear and recognizable
        /// for both staff and customer reference during the return process.
        /// </remarks>
        public required string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure code for this returned item.
        /// </summary>
        /// <value>
        /// A standard unit code indicating how the returned item is measured or counted.
        /// </value>
        /// <remarks>
        /// Unit codes ensure that return quantities are properly interpreted and processed
        /// for inventory adjustments. They maintain consistency with the original sale
        /// units and support accurate inventory management.
        /// </remarks>
        public required string SalesUnitTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the quantity of this item being returned.
        /// </summary>
        /// <value>
        /// The amount of the item being returned, measured in the specified units.
        /// </value>
        /// <remarks>
        /// Return quantities must be validated against original purchase quantities and
        /// current return policies. Accurate quantity tracking is essential for proper
        /// inventory adjustments and refund calculations.
        /// </remarks>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the gross price per unit that was charged for this item in the original transaction.
        /// </summary>
        /// <value>
        /// The tax-inclusive price that was paid for one unit of this item.
        /// </value>
        /// <remarks>
        /// The gross price is used to calculate the refund amount for this item and must
        /// reflect the original purchase price. It ensures that customers receive appropriate
        /// refunds based on what they actually paid for the merchandise.
        /// </remarks>
        public decimal GrossPrice { get; set; }

        /// <summary>
        /// Gets or sets the product code or SKU for this returned item.
        /// </summary>
        /// <value>
        /// The unique product identification code for inventory and business system tracking.
        /// </value>
        /// <remarks>
        /// Product codes enable precise inventory adjustments and help ensure that the correct
        /// items are being processed for return. They support inventory management systems
        /// and provide accurate tracking for return analysis and quality monitoring.
        /// </remarks>
        public required string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the VAT (Value Added Tax) classification code for this returned item.
        /// </summary>
        /// <value>
        /// A single character code indicating the tax rate category for proper tax handling.
        /// </value>
        /// <remarks>
        /// VAT codes ensure that tax implications of returns are properly calculated and
        /// reported. They affect how the return impacts tax reporting and ensure compliance
        /// with tax regulations for return transactions.
        /// </remarks>
        public required string VatCode { get; set; }
    }
}

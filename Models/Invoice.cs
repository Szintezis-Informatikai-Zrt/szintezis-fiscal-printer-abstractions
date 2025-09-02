using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a complete simplified invoice document containing all business transaction details,
/// customer information, and fiscal compliance data required for B2B transactions.
/// </summary>
/// <remarks>
/// Simplified invoices are used for business-to-business transactions and require comprehensive
/// customer information including tax identification numbers. They provide detailed product codes,
/// tax breakdowns, and compliance documentation necessary for VAT reporting and business accounting.
/// Invoices typically have higher monetary limits than standard receipts and include additional
/// regulatory requirements for proper business documentation.
/// </remarks>
public sealed class Invoice()
{
    /// <summary>
    /// Gets or sets the barcode to be printed on the invoice for tracking and verification purposes.
    /// </summary>
    /// <value>
    /// A string containing the barcode data that will be printed as a Code128 barcode on the invoice.
    /// </value>
    /// <remarks>
    /// The barcode typically contains transaction identifiers, invoice numbers, or business reference
    /// information that allows for quick lookup and verification of the invoice in business systems
    /// and accounting software.
    /// </remarks>
    public required string Barcode { get; set; }

    /// <summary>
    /// Gets or sets the final total amount for the entire invoice after all items, discounts, and taxes.
    /// </summary>
    /// <value>
    /// The total amount in the local currency that the business customer must pay for this transaction.
    /// </value>
    /// <remarks>
    /// This total must match the sum of all item values minus discounts, and must equal the sum
    /// of all payment amounts. The fiscal printer will validate this total during processing.
    /// Invoice totals are typically subject to higher limits than standard receipt totals.
    /// </remarks>
    public required decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the business customer information required for invoice generation.
    /// </summary>
    /// <value>
    /// An <see cref="InvoiceCustomer"/> object containing the complete business customer details.
    /// </value>
    /// <remarks>
    /// Customer information is mandatory for all invoices and must include valid business details
    /// for proper tax reporting and compliance. The information is used to generate the invoice
    /// header and ensure proper VAT documentation.
    /// </remarks>
    public required InvoiceCustomer Customer { get; set; }

    /// <summary>
    /// Gets or sets the collection of items being sold in this invoice.
    /// </summary>
    /// <value>
    /// A list of <see cref="Item"/> objects representing individual products or services being invoiced.
    /// </value>
    /// <remarks>
    /// Invoice items include additional business information such as product codes that are required
    /// for business accounting and inventory management. Each item contains detailed product
    /// information, pricing, quantities, and tax classification for B2B transactions.
    /// </remarks>
    public List<Item> Items { get; set; } = [];

    /// <summary>
    /// Gets or sets the collection of payment methods used to pay for this invoice.
    /// </summary>
    /// <value>
    /// A list of <see cref="Payment"/> objects representing different payment methods and amounts.
    /// </value>
    /// <remarks>
    /// Business payments can involve multiple payment methods and may include terms for delayed
    /// payment or business credit arrangements. The total of all payments must equal the
    /// invoice's total amount.
    /// </remarks>
    public List<Payment> Payments { get; set; } = [];

    /// <summary>
    /// Gets or sets the collection of tax-specific discounts applied to this invoice.
    /// </summary>
    /// <value>
    /// A list of <see cref="TaxDiscount"/> objects representing discounts applied to specific tax categories.
    /// </value>
    /// <remarks>
    /// Tax discounts are particularly important for business invoices as they affect VAT calculations
    /// and tax reporting requirements. They are applied after item-level discounts and affect
    /// entire tax categories for proper business accounting compliance.
    /// </remarks>
    public List<TaxDiscount> TaxDiscounts { get; set; } = [];

    /// <summary>
    /// Gets or sets the collection of non-fiscal text lines to be printed on the invoice.
    /// </summary>
    /// <value>
    /// A list of <see cref="NonFiscalLine"/> objects containing additional text content for the invoice.
    /// </value>
    /// <remarks>
    /// Non-fiscal lines on invoices often contain business terms, payment conditions, legal notices,
    /// or additional business information required for B2B transactions. They are printed after
    /// the fiscal portion and can include formatted business communications.
    /// </remarks>
    public List<NonFiscalLine> NonFiscalRows { get; set; } = [];

    /// <summary>
    /// Represents an individual item or service being invoiced in a business transaction.
    /// </summary>
    /// <remarks>
    /// Invoice items include additional business information beyond standard receipt items,
    /// particularly product codes that are essential for business accounting, inventory management,
    /// and VAT reporting requirements.
    /// </remarks>
    public sealed class Item
    {
        /// <summary>
        /// Gets or sets the abbreviated name of the item for display and printing on the invoice.
        /// </summary>
        /// <value>
        /// A concise product name that will appear on the invoice and business documentation.
        /// </value>
        /// <remarks>
        /// The item name should be descriptive enough for business recognition and accounting purposes
        /// while being suitable for invoice formatting and business record keeping.
        /// </remarks>
        public required string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure code for this invoiced item (e.g., "KG", "PCS", "LTR").
        /// </summary>
        /// <value>
        /// A standard unit code indicating how the item is measured or counted for business purposes.
        /// </value>
        /// <remarks>
        /// Business unit codes should follow standard industry conventions and may be required
        /// for proper inventory management and business accounting integration.
        /// </remarks>
        public required string SalesUnitTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the number of decimal places to use when displaying the quantity on the invoice.
        /// </summary>
        /// <value>
        /// The precision level for quantity display, important for accurate business measurements.
        /// </value>
        /// <remarks>
        /// Business transactions often require precise quantity measurements for proper billing
        /// and inventory tracking, especially for measured goods and professional services.
        /// </remarks>
        public int Precision { get; set; }

        /// <summary>
        /// Gets or sets the quantity of this item being invoiced.
        /// </summary>
        /// <value>
        /// The amount of the item being sold, measured in the units specified by <see cref="SalesUnitTypeCode"/>.
        /// </value>
        /// <remarks>
        /// Business quantities must be accurate for proper billing, inventory management, and
        /// accounting purposes. Precision is important for service billing and bulk goods.
        /// </remarks>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the gross price per unit including all applicable taxes.
        /// </summary>
        /// <value>
        /// The tax-inclusive price for one unit of this item in business transactions.
        /// </value>
        /// <remarks>
        /// Business pricing includes all applicable taxes and is used for VAT calculations
        /// and tax reporting. The gross price forms the basis for business accounting
        /// and tax compliance documentation.
        /// </remarks>
        public decimal GrossPrice { get; set; }

        /// <summary>
        /// Gets or sets the total gross value for this line item (quantity × gross price).
        /// </summary>
        /// <value>
        /// The total amount for this item before any item-specific discounts are applied.
        /// </value>
        /// <remarks>
        /// This value is crucial for business accounting and must equal the quantity multiplied
        /// by the gross price. It represents the line total before discounts but after taxes
        /// for proper business documentation.
        /// </remarks>
        public decimal GrossValue { get; set; }

        /// <summary>
        /// Gets or sets the business product code or SKU for this invoiced item.
        /// </summary>
        /// <value>
        /// The product identification code used for business inventory and accounting systems.
        /// </value>
        /// <remarks>
        /// Product codes are essential for business invoices as they enable proper inventory
        /// tracking, accounting integration, and business system coordination. They appear
        /// on the printed invoice for business reference and audit purposes.
        /// </remarks>
        public required string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the VAT (Value Added Tax) classification code for this business item.
        /// </summary>
        /// <value>
        /// A single character code (typically A, B, C, D, or E) indicating the business tax rate category.
        /// </value>
        /// <remarks>
        /// VAT codes are critical for business invoices as they determine tax calculations
        /// and affect VAT reporting requirements. Proper VAT classification is essential
        /// for business tax compliance and accounting accuracy.
        /// </remarks>
        public required string VatCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this item has been cancelled or voided.
        /// </summary>
        /// <value>
        /// <c>true</c> if the item is cancelled and should not be included in business totals; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Cancelled items remain on the invoice for business audit purposes but are excluded
        /// from total calculations. This is important for business transaction integrity
        /// and proper accounting documentation.
        /// </remarks>
        public bool Cancelled { get; set; } = false;

        /// <summary>
        /// Gets or sets the collection of business discounts applied specifically to this invoiced item.
        /// </summary>
        /// <value>
        /// A list of <see cref="Discount"/> objects representing various business promotional or contractual discounts.
        /// </value>
        /// <remarks>
        /// Business discounts may include volume discounts, contractual terms, or promotional
        /// arrangements specific to B2B relationships. They are applied before invoice-level
        /// and tax-level discounts for proper business accounting.
        /// </remarks>
        public List<Discount> Discounts { get; set; } = [];
    }

    /// <summary>
    /// Represents a payment method and amount used for business invoice payment.
    /// </summary>
    /// <remarks>
    /// Business payments may involve different terms and conditions than retail payments,
    /// including credit arrangements, wire transfers, and business-specific payment instruments.
    /// </remarks>
    public sealed class Payment
    {
        /// <summary>
        /// Gets or sets the amount paid using this business payment method.
        /// </summary>
        /// <value>
        /// The amount in the payment method's currency being applied to this business transaction.
        /// </value>
        /// <remarks>
        /// Business payment amounts may involve larger sums than retail transactions and may
        /// be subject to different currency conversion rules and business payment terms.
        /// </remarks>
        public required decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the payment method used for this portion of the business transaction.
        /// </summary>
        /// <value>
        /// A <see cref="PaidMode"/> value indicating the specific business payment instrument used.
        /// </value>
        /// <remarks>
        /// Business payment modes may include specialized instruments such as wire transfers,
        /// business credit accounts, or corporate payment systems in addition to standard
        /// cash and card payments.
        /// </remarks>
        public PaidMode PaidMode { get; set; }
    }

    /// <summary>
    /// Represents comprehensive business customer information required for invoice generation and tax compliance.
    /// </summary>
    /// <remarks>
    /// Invoice customer information must meet business documentation standards and tax authority
    /// requirements for B2B transactions. All address components are essential for proper
    /// invoice formatting and legal compliance.
    /// </remarks>
    public sealed class InvoiceCustomer
    {
        /// <summary>
        /// Gets or sets the business customer's tax reference number (tax identification number).
        /// </summary>
        /// <value>
        /// The business tax identification number required for VAT reporting and business transactions.
        /// </value>
        /// <remarks>
        /// The tax reference number is mandatory for business invoices and must be valid for
        /// proper VAT reporting and tax compliance. Invalid numbers will be handled according
        /// to fiscal regulations and may affect invoice validity.
        /// </remarks>
        public string TaxRefNum { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the business customer's official registered name.
        /// </summary>
        /// <value>
        /// The complete legal business name as registered with tax authorities.
        /// </value>
        /// <remarks>
        /// The business name must match official registration records for proper invoice validity
        /// and tax compliance. This name appears prominently on the invoice header and is used
        /// for business identification and tax reporting purposes.
        /// </remarks>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the postal code for the business customer's registered address.
        /// </summary>
        /// <value>
        /// The business postal code following standard formatting conventions.
        /// </value>
        /// <remarks>
        /// The postal code is part of the complete business address required for invoice validity
        /// and tax compliance. It must correspond to the official business registration address.
        /// </remarks>
        public string PostCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the city name for the business customer's registered address.
        /// </summary>
        /// <value>
        /// The official city or municipality name for the business location.
        /// </value>
        /// <remarks>
        /// The city name must match the official business registration address and is required
        /// for proper invoice documentation and tax authority compliance.
        /// </remarks>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the street address for the business customer's registered location.
        /// </summary>
        /// <value>
        /// The complete street address information for the business.
        /// </value>
        /// <remarks>
        /// The business address must be complete and accurate for proper invoice validity
        /// and may be subject to verification for tax compliance purposes.
        /// </remarks>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the street type designation for the business address.
        /// </summary>
        /// <value>
        /// The street type designation following local addressing conventions.
        /// </value>
        /// <remarks>
        /// Street type information ensures complete and properly formatted business addresses
        /// that meet local postal and business registration standards.
        /// </remarks>
        public string StreetType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the building number and identifier for the business location.
        /// </summary>
        /// <value>
        /// The complete building identification including number and any additional identifiers.
        /// </value>
        /// <remarks>
        /// Building information must be complete for proper business address identification
        /// and may include floor numbers, suite designations, or other location specifics
        /// required for business correspondence and legal documentation.
        /// </remarks>
        public string HouseNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets additional business comments or special instructions for the invoice.
        /// </summary>
        /// <value>
        /// Free-form text for business-specific information, terms, or special instructions.
        /// </value>
        /// <remarks>
        /// Comments may include business reference numbers, special terms, payment instructions,
        /// or other business-specific information that needs to appear on the invoice for
        /// proper business communication and documentation.
        /// </remarks>
        public string Comment { get; set; } = string.Empty;
    }
}

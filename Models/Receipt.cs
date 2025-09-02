using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a complete fiscal receipt containing all sales items, payments, discounts, and customer information
/// required for point-of-sale transactions.
/// </summary>
/// <remarks>
/// A fiscal receipt is the primary transaction document in retail operations. It contains itemized sales,
/// applies various discount types, processes multiple payment methods, and generates a legally compliant
/// fiscal document with proper tax calculations and audit trails.
/// </remarks>
public sealed class Receipt()
{
    /// <summary>
    /// Gets or sets the barcode to be printed on the receipt for tracking and verification purposes.
    /// </summary>
    /// <value>
    /// A string containing the barcode data that will be printed as a Code128 barcode on the receipt.
    /// </value>
    /// <remarks>
    /// The barcode typically contains transaction identifiers, timestamps, or other tracking information
    /// that allows for quick lookup and verification of the transaction in business systems.
    /// </remarks>
    public required string Barcode { get; set; }

    /// <summary>
    /// Gets or sets the final total amount for the entire receipt after all items, discounts, and taxes.
    /// </summary>
    /// <value>
    /// The total amount in the local currency that the customer must pay for this transaction.
    /// </value>
    /// <remarks>
    /// This total must match the sum of all item values minus discounts, and must equal the sum
    /// of all payment amounts. The fiscal printer will validate this total during processing.
    /// </remarks>
    public required decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the collection of items being purchased in this receipt.
    /// </summary>
    /// <value>
    /// A list of <see cref="Item"/> objects representing individual products or services being sold.
    /// </value>
    /// <remarks>
    /// Each item contains product information, pricing, quantities, and tax classification.
    /// Items can have individual discounts applied and can be marked as cancelled if needed.
    /// </remarks>
    public List<Item> Items { get; set; } = [];

    /// <summary>
    /// Gets or sets the collection of payment methods used to pay for this receipt.
    /// </summary>
    /// <value>
    /// A list of <see cref="Payment"/> objects representing different payment methods and amounts.
    /// </value>
    /// <remarks>
    /// Multiple payment methods can be used for a single transaction. The total of all payments
    /// must equal the receipt's total amount. Payments can be in different currencies.
    /// </remarks>
    public List<Payment> Payments { get; set; } = [];

    /// <summary>
    /// Gets or sets the collection of tax-specific discounts applied to this receipt.
    /// </summary>
    /// <value>
    /// A list of <see cref="TaxDiscount"/> objects representing discounts applied to specific tax categories.
    /// </value>
    /// <remarks>
    /// Tax discounts are applied after item-level discounts and affect entire tax categories
    /// rather than individual items. They are used for promotions that apply to all items
    /// within specific tax classifications.
    /// </remarks>
    public List<TaxDiscount> TaxDiscounts { get; set; } = [];

    /// <summary>
    /// Gets or sets the collection of non-fiscal text lines to be printed on the receipt.
    /// </summary>
    /// <value>
    /// A list of <see cref="NonFiscalLine"/> objects containing additional text content for the receipt.
    /// </value>
    /// <remarks>
    /// Non-fiscal lines contain promotional messages, instructions, or other information that
    /// doesn't affect the fiscal calculations. They are printed after the fiscal portion
    /// of the receipt and can include formatted text and styling.
    /// </remarks>
    public List<NonFiscalLine> NonFiscalRows { get; set; } = [];

    /// <summary>
    /// Represents an individual item or service being sold within a fiscal receipt.
    /// </summary>
    /// <remarks>
    /// Each item represents a distinct product or service with its own pricing, quantity,
    /// tax classification, and discount information. Items are the fundamental building
    /// blocks of fiscal transactions.
    /// </remarks>
    public sealed class Item
    {
        /// <summary>
        /// Gets or sets the abbreviated name of the item for display and printing purposes.
        /// </summary>
        /// <value>
        /// A concise product name that will appear on the receipt and customer display.
        /// </value>
        /// <remarks>
        /// This name should be descriptive enough for customer recognition while being
        /// short enough to fit on receipt lines and display screens. Typically limited
        /// to 20-30 characters depending on printer capabilities.
        /// </remarks>
        public required string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure code for this item (e.g., "KG", "PCS", "LTR").
        /// </summary>
        /// <value>
        /// A standard unit code indicating how the item is measured or counted.
        /// </value>
        /// <remarks>
        /// Common values include "DB" or "DARAB" for pieces, "KG" for kilograms, "LTR" for liters.
        /// The unit determines how quantity is interpreted and displayed to customers.
        /// </remarks>
        public required string SalesUnitTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the number of decimal places to use when displaying the quantity.
        /// </summary>
        /// <value>
        /// The precision level for quantity display, typically 0 for whole units or 2-3 for measured items.
        /// </value>
        /// <remarks>
        /// Items sold by piece typically use 0 precision, while items sold by weight or volume
        /// use 2-3 decimal places for accurate measurement display.
        /// </remarks>
        public int Precision { get; set; }

        /// <summary>
        /// Gets or sets the quantity of this item being purchased.
        /// </summary>
        /// <value>
        /// The amount of the item being sold, measured in the units specified by <see cref="SalesUnitTypeCode"/>.
        /// </value>
        /// <remarks>
        /// For piece items, this is typically a whole number. For measured items (weight, volume),
        /// this can include decimal values. Must be greater than zero for sales items.
        /// </remarks>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the gross price per unit including all applicable taxes.
        /// </summary>
        /// <value>
        /// The tax-inclusive price for one unit of this item.
        /// </value>
        /// <remarks>
        /// This is the price that customers see and pay. It includes all applicable taxes
        /// as determined by the VAT code. The fiscal printer will calculate net amounts
        /// and tax portions based on this gross price and the VAT classification.
        /// </remarks>
        public decimal GrossPrice { get; set; }

        /// <summary>
        /// Gets or sets the total gross value for this line item (quantity × gross price).
        /// </summary>
        /// <value>
        /// The total amount for this item before any item-specific discounts are applied.
        /// </value>
        /// <remarks>
        /// This value should equal <see cref="Quantity"/> multiplied by <see cref="GrossPrice"/>.
        /// It represents the subtotal for this line item before discounts but after taxes.
        /// </remarks>
        public decimal GrossValue { get; set; }

        /// <summary>
        /// Gets or sets the VAT (Value Added Tax) classification code for this item.
        /// </summary>
        /// <value>
        /// A single character code (typically A, B, C, D, or E) indicating the tax rate category.
        /// </value>
        /// <remarks>
        /// VAT codes determine the tax rate applied to this item. Common codes include:
        /// A (27%), B (18%), C (5%), D (0%), E (special rates). The specific rates
        /// depend on local tax regulations and printer configuration.
        /// </remarks>
        public required string VatCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this item has been cancelled or voided.
        /// </summary>
        /// <value>
        /// <c>true</c> if the item is cancelled and should not be included in totals; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Cancelled items remain on the receipt for audit purposes but are excluded from
        /// total calculations. This is used for item corrections during transaction processing.
        /// </remarks>
        public bool Cancelled { get; set; } = false;

        /// <summary>
        /// Gets or sets the collection of discounts applied specifically to this item.
        /// </summary>
        /// <value>
        /// A list of <see cref="Discount"/> objects representing various promotional or adjustment discounts.
        /// </value>
        /// <remarks>
        /// Item-level discounts are applied before receipt-level and tax-level discounts.
        /// Multiple discounts can be applied to a single item, and they can be either
        /// percentage-based or fixed amount discounts.
        /// </remarks>
        public List<Discount> Discounts { get; set; } = [];
    }

    /// <summary>
    /// Represents a payment method and amount used to pay for the receipt.
    /// </summary>
    /// <remarks>
    /// Payments can be made using various methods including cash, credit cards, foreign currencies,
    /// and custom payment types. Multiple payments can be combined to complete a transaction.
    /// </remarks>
    public sealed class Payment
    {
        /// <summary>
        /// Gets or sets the amount paid using this payment method.
        /// </summary>
        /// <value>
        /// The amount in the payment method's currency being applied to this transaction.
        /// </value>
        /// <remarks>
        /// For foreign currency payments, this amount is in the foreign currency units.
        /// The fiscal printer will handle currency conversion based on configured exchange rates.
        /// </remarks>
        public required decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the payment method used for this portion of the transaction.
        /// </summary>
        /// <value>
        /// A <see cref="PaidMode"/> value indicating the specific payment instrument used.
        /// </value>
        /// <remarks>
        /// Payment modes include local cash, credit cards, various foreign currencies,
        /// and custom payment methods configured in the system. Each mode may have
        /// different processing requirements and reporting categories.
        /// </remarks>
        public PaidMode PaidMode { get; set; }
    }
}

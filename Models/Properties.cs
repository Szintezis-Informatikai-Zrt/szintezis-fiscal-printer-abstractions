namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Contains comprehensive configuration properties for fiscal printer operation, including transaction limits,
/// currency settings, and custom payment method definitions.
/// </summary>
/// <remarks>
/// Properties define the operational parameters and limits that govern fiscal printer behavior.
/// These settings must be configured when the fiscal day is closed and affect all subsequent
/// transactions until changed. The configuration ensures compliance with local fiscal regulations
/// and business requirements while providing flexibility for different operational needs.
/// 
/// <para>
/// All property changes require the fiscal day to be closed and may need administrative privileges
/// depending on the regulatory environment. Changes take effect immediately and apply to all
/// future transactions processed by the fiscal printer.
/// </para>
/// </remarks>
public sealed class Properties
{
    /// <summary>
    /// Gets or sets the maximum allowed total amount for individual receipt transactions.
    /// </summary>
    /// <value>
    /// The maximum monetary limit for a single receipt transaction in the local currency.
    /// </value>
    /// <remarks>
    /// Receipt limits help prevent accidentally large transactions and ensure compliance with
    /// fiscal regulations that may restrict retail transaction amounts. When a transaction
    /// exceeds this limit, the system may require additional verification or reject the
    /// transaction entirely. This limit applies to standard receipts but not to invoices.
    /// </remarks>
    public decimal ReceiptTotalMaxValue { get; set; }

    /// <summary>
    /// Gets or sets the maximum allowed total amount for individual invoice transactions.
    /// </summary>
    /// <value>
    /// The maximum monetary limit for a single invoice transaction in the local currency.
    /// </value>
    /// <remarks>
    /// Invoice limits are typically higher than receipt limits to accommodate business-to-business
    /// transactions which often involve larger amounts. This limit ensures compliance with
    /// business transaction regulations while providing adequate capacity for legitimate
    /// business purchases and bulk transactions.
    /// </remarks>
    public decimal InvoiceTotalMaxValue { get; set; }

    /// <summary>
    /// Gets or sets the exchange rate from Euro to the local currency for foreign currency transactions.
    /// </summary>
    /// <value>
    /// The Euro to local currency exchange rate, or <c>null</c> if Euro transactions are not supported.
    /// </value>
    /// <remarks>
    /// The Euro rate is used for converting Euro-denominated payments to local currency equivalents
    /// for fiscal reporting and cash drawer management. The rate should be updated regularly to
    /// reflect current market conditions and must comply with official exchange rate regulations
    /// where applicable. When null, Euro payments are not accepted.
    /// </remarks>
    public decimal? EuroRate { get; set; }

    /// <summary>
    /// Gets or sets the collection of custom foreign currencies and their exchange rates.
    /// </summary>
    /// <value>
    /// A list of <see cref="Currency"/> objects defining additional foreign currencies beyond Euro.
    /// Maximum of 5 custom currencies are supported.
    /// </value>
    /// <remarks>
    /// Custom currencies allow businesses to accept additional international currencies beyond
    /// the standard Euro support. Each currency requires a name and current exchange rate.
    /// The system enforces a limit of 5 custom currencies to maintain operational simplicity
    /// and ensure proper cash drawer management and reporting capabilities.
    /// </remarks>
    public IList<Currency> Currencies { get; set; } = [];

    /// <summary>
    /// Gets or sets the collection of custom payment method names and their configuration.
    /// </summary>
    /// <value>
    /// A list of <see cref="CustomPayment"/> objects defining business-specific payment methods.
    /// Maximum of 8 custom payment methods are supported.
    /// </value>
    /// <remarks>
    /// Custom payment methods allow businesses to define specialized payment instruments such as
    /// gift cards, vouchers, loyalty points, or business-specific payment systems. Each payment
    /// method requires a descriptive name (maximum 13 characters) and a position order. The first
    /// payment method is typically reserved for "AFR" (automatic fiscal receipt) functionality.
    /// </remarks>
    public IList<CustomPayment> CustomPaymentNames { get; set; } = [];
}

/// <summary>
/// Represents a custom payment method definition with name and ordering information.
/// </summary>
/// <remarks>
/// Custom payments allow businesses to extend the standard payment methods with specialized
/// instruments that meet their specific operational needs. Each custom payment method is
/// assigned a specific position in the payment method list and appears in that order on
/// receipts and in system interfaces.
/// </remarks>
public sealed class CustomPayment
{
    /// <summary>
    /// Gets or sets the descriptive name for this custom payment method.
    /// </summary>
    /// <value>
    /// A business-friendly name for the payment method, limited to 13 characters for display compatibility.
    /// </value>
    /// <remarks>
    /// The payment method name appears on receipts, displays, and in reporting systems. It should
    /// be clear and recognizable to both staff and customers. The name length is restricted to
    /// ensure proper formatting on printed receipts and customer displays.
    /// </remarks>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the position order for this custom payment method in the system.
    /// </summary>
    /// <value>
    /// A numeric value (1-8) indicating the position of this payment method in lists and displays.
    /// </value>
    /// <remarks>
    /// The custom order determines where this payment method appears in system interfaces,
    /// receipt printing order, and reporting sequences. Lower numbers appear first in lists.
    /// Position 1 is typically reserved for "AFR" functionality in many implementations.
    /// </remarks>
    public required byte CustomOrder { get; set; }
}

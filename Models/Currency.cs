namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a foreign currency configuration with exchange rate information for multi-currency
/// transaction support in fiscal operations.
/// </summary>
/// <remarks>
/// Currency configurations enable businesses to accept payments in foreign currencies while
/// maintaining proper fiscal compliance and accurate financial reporting. Each currency requires
/// a current exchange rate that converts foreign currency amounts to local currency equivalents
/// for fiscal calculations, tax reporting, and cash drawer management.
/// 
/// <para>
/// Foreign currency support provides several business benefits:
/// <list type="bullet">
/// <item><description>Enhanced customer service for international customers</description></item>
/// <item><description>Competitive advantage in tourist and international business areas</description></item>
/// <item><description>Compliance with multi-currency business requirements</description></item>
/// <item><description>Proper financial tracking and reporting for foreign transactions</description></item>
/// <item><description>Accurate cash drawer management across currency types</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// Exchange rates should be updated regularly to reflect current market conditions and must
/// comply with official exchange rate regulations where applicable. The fiscal system
/// supports up to 5 custom foreign currencies in addition to standard Euro support.
/// </para>
/// </remarks>
public sealed class Currency
{
    /// <summary>
    /// Gets or sets the name or code of the foreign currency.
    /// </summary>
    /// <value>
    /// A descriptive name or standard currency code (such as "USD", "GBP", "CHF") for the foreign currency,
    /// or <c>null</c> if not specified.
    /// </value>
    /// <remarks>
    /// Currency names should be clear and recognizable to both staff and customers. Standard
    /// three-letter ISO currency codes are recommended for international recognition and
    /// consistency. The name appears in transaction documentation and system interfaces,
    /// so it should be concise yet descriptive enough for proper identification.
    /// </remarks>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the exchange rate from this foreign currency to the local currency.
    /// </summary>
    /// <value>
    /// The conversion rate used to calculate local currency equivalents for foreign currency transactions.
    /// </value>
    /// <remarks>
    /// The exchange rate determines how foreign currency amounts are converted to local currency
    /// for fiscal calculations and reporting. For example, if the local currency is Hungarian Forint
    /// and the foreign currency is USD with a rate of 380, then 1 USD equals 380 HUF. Exchange rates
    /// should be updated regularly to reflect current market conditions and must comply with
    /// official exchange rate regulations and business policies for currency conversion.
    /// </remarks>
    public decimal Rate { get; set; }
}



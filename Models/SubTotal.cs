namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a breakdown of transaction totals by VAT tax categories, providing detailed
/// tax analysis and compliance reporting for fiscal transactions.
/// </summary>
/// <remarks>
/// Subtotals provide essential tax compliance information by breaking down transaction totals
/// into their component tax categories. This detailed breakdown is required for proper VAT
/// reporting, tax authority compliance, and business financial analysis. Each tax category
/// represents a different VAT rate as configured in the fiscal system.
/// 
/// <para>
/// Tax category breakdowns serve multiple purposes:
/// <list type="bullet">
/// <item><description>VAT compliance reporting for tax authorities</description></item>
/// <item><description>Business financial analysis by tax rate category</description></item>
/// <item><description>Audit trail documentation for fiscal compliance</description></item>
/// <item><description>Integration with accounting systems requiring tax detail</description></item>
/// <item><description>Verification of tax calculations and compliance accuracy</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// The five tax categories (A through E) correspond to different VAT rates configured
/// in the fiscal system, with each category potentially having different tax rates
/// and reporting requirements based on local tax regulations.
/// </para>
/// </remarks>
public sealed class SubTotal
{
    /// <summary>
    /// Gets or sets the total transaction amount including all taxes across all categories.
    /// </summary>
    /// <value>
    /// The complete transaction total in local currency including all applicable taxes.
    /// </value>
    /// <remarks>
    /// The total amount represents the sum of all items, discounts, and taxes across all
    /// VAT categories. This amount should equal the sum of all individual tax category
    /// amounts and serves as a verification point for tax calculation accuracy.
    /// </remarks>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the total amount for items classified under VAT tax category A.
    /// </summary>
    /// <value>
    /// The sum of all transaction items that fall under tax category A, including applicable taxes.
    /// </value>
    /// <remarks>
    /// Tax category A typically represents the highest standard VAT rate (often 27% in some
    /// jurisdictions). This includes luxury goods, non-essential items, and products subject
    /// to the standard VAT rate. The amount includes both the net value and the calculated
    /// VAT for items in this category.
    /// </remarks>
    public decimal TaxAmountA { get; set; }

    /// <summary>
    /// Gets or sets the total amount for items classified under VAT tax category B.
    /// </summary>
    /// <value>
    /// The sum of all transaction items that fall under tax category B, including applicable taxes.
    /// </value>
    /// <remarks>
    /// Tax category B typically represents a reduced VAT rate (often 18% in some jurisdictions).
    /// This may include certain consumer goods, services, or products that qualify for reduced
    /// taxation. The amount includes both the net value and the calculated VAT for items
    /// in this category.
    /// </remarks>
    public decimal TaxAmountB { get; set; }

    /// <summary>
    /// Gets or sets the total amount for items classified under VAT tax category C.
    /// </summary>
    /// <value>
    /// The sum of all transaction items that fall under tax category C, including applicable taxes.
    /// </value>
    /// <remarks>
    /// Tax category C typically represents a further reduced VAT rate (often 5% in some
    /// jurisdictions). This often includes essential items, basic foodstuffs, books, or
    /// other goods considered necessary for daily life. The amount includes both the net
    /// value and the calculated VAT for items in this category.
    /// </remarks>
    public decimal TaxAmountC { get; set; }

    /// <summary>
    /// Gets or sets the total amount for items classified under VAT tax category D.
    /// </summary>
    /// <value>
    /// The sum of all transaction items that fall under tax category D, including applicable taxes.
    /// </value>
    /// <remarks>
    /// Tax category D typically represents VAT-exempt items (0% VAT rate). This includes
    /// certain essential services, medical products, educational materials, or other goods
    /// that are exempt from VAT taxation. While the VAT rate is 0%, the amounts are still
    /// tracked for compliance and reporting purposes.
    /// </remarks>
    public decimal TaxAmountD { get; set; }

    /// <summary>
    /// Gets or sets the total amount for items classified under VAT tax category E.
    /// </summary>
    /// <value>
    /// The sum of all transaction items that fall under tax category E, including applicable taxes.
    /// </value>
    /// <remarks>
    /// Tax category E represents special or custom VAT rates that may vary based on specific
    /// business circumstances, special economic zones, or temporary tax measures. The specific
    /// rate and treatment depend on local tax regulations and system configuration.
    /// </remarks>
    public decimal TaxAmountE { get; set; }
}

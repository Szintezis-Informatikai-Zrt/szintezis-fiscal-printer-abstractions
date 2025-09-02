using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a tax-level discount applied to entire VAT categories within a transaction,
/// affecting all items within specific tax classifications rather than individual items.
/// </summary>
/// <remarks>
/// Tax discounts are applied after individual item discounts and affect entire tax categories
/// (VAT groups) rather than specific items. This type of discount is particularly important for
/// business invoices and complex promotional scenarios where discounts apply to all items
/// within specific tax rates. Tax discounts ensure proper VAT calculation and reporting
/// while supporting sophisticated business discount policies.
/// 
/// <para>
/// Tax-level discounts are commonly used for:
/// <list type="bullet">
/// <item><description>Volume discounts affecting all items in specific tax categories</description></item>
/// <item><description>Promotional campaigns targeting specific product tax classifications</description></item>
/// <item><description>Business-to-business contractual discounts by tax category</description></item>
/// <item><description>Seasonal sales affecting entire tax groups</description></item>
/// <item><description>Government or regulatory discount programs by tax type</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// Tax discounts require careful handling to ensure compliance with VAT regulations
/// and proper tax reporting. They affect the tax calculation base and must be properly
/// documented for audit and compliance purposes.
/// </para>
/// </remarks>
public sealed class TaxDiscount
{
    /// <summary>
    /// Gets or sets the calculation method for applying this tax-level discount.
    /// </summary>
    /// <value>
    /// A <see cref="TaxDiscountMode"/> value specifying how the discount should be calculated and applied.
    /// </value>
    /// <remarks>
    /// The tax discount mode determines the mathematical approach for discount calculation
    /// at the tax category level. Different modes support various business discount policies
    /// while ensuring proper fiscal treatment and compliance with VAT reporting requirements.
    /// The mode affects how the discount integrates with tax calculations and reporting.
    /// </remarks>
    public TaxDiscountMode TaxDiscountMode { get; set; }

    /// <summary>
    /// Gets or sets the discount amount, which may represent a monetary value or percentage depending on <see cref="IsPercentage"/>.
    /// </summary>
    /// <value>
    /// The discount value - either a monetary amount in local currency or a percentage value.
    /// </value>
    /// <remarks>
    /// For monetary tax discounts, this represents the absolute amount to be deducted from
    /// the tax category total. For percentage discounts, this represents the percentage to
    /// be applied to all items within the specified tax category. The interpretation depends
    /// on the <see cref="IsPercentage"/> flag and affects VAT calculations and reporting.
    /// </remarks>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the original value that serves as the basis for tax discount calculations.
    /// </summary>
    /// <value>
    /// The base amount from the tax category that serves as the reference for discount calculations.
    /// </value>
    /// <remarks>
    /// The original value represents the total value of all items within the tax category
    /// before this tax discount is applied. It provides the baseline for percentage calculations
    /// and ensures accurate discount application. This value is crucial for audit trails
    /// and VAT compliance documentation.
    /// </remarks>
    public decimal OriginalValue { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the discount amount represents a percentage or a fixed monetary amount.
    /// </summary>
    /// <value>
    /// <c>true</c> if the <see cref="Amount"/> represents a percentage; <c>false</c> if it represents a monetary amount.
    /// </value>
    /// <remarks>
    /// This flag determines how the tax discount amount is interpreted and calculated.
    /// When true, the amount is treated as a percentage to be applied to the original
    /// tax category value. When false, the amount is treated as a fixed monetary deduction
    /// from the tax category total. This affects VAT calculations and compliance reporting.
    /// </remarks>
    public bool IsPercentage { get; set; }

    /// <summary>
    /// Gets or sets an optional comment explaining the reason for this tax-level discount.
    /// </summary>
    /// <value>
    /// A text description of the tax discount reason, promotion name, or business justification,
    /// or <c>null</c> if no comment is provided.
    /// </value>
    /// <remarks>
    /// Comments provide business context for tax discounts, such as promotion names, contractual
    /// terms, or regulatory compliance reasons. This information is valuable for business analysis,
    /// audit documentation, and VAT compliance reporting. Comments may appear on business
    /// documents depending on system configuration and business requirements.
    /// </remarks>
    public string? Comment { get; set; }

    /// <summary>
    /// Gets or sets the VAT tax letter (classification code) that this discount applies to.
    /// </summary>
    /// <value>
    /// A single character VAT code (typically A, B, C, D, or E) identifying the tax category affected by this discount.
    /// </value>
    /// <remarks>
    /// The tax letter specifies which VAT category this discount applies to, ensuring that
    /// the discount only affects items with the matching tax classification. This is crucial
    /// for proper VAT calculation and compliance, as different tax categories have different
    /// rates and reporting requirements. The tax letter must match valid VAT codes configured
    /// in the fiscal system.
    /// </remarks>
    public required string TaxLetter { get; set; }

    /// <summary>
    /// Gets or sets the collector code for advanced tax discount tracking and reporting.
    /// </summary>
    /// <value>
    /// A two-digit code used for specialized tax discount tracking and reporting purposes.
    /// Defaults to "00" for standard tax discounts.
    /// </value>
    /// <remarks>
    /// The collector code provides additional categorization for tax discounts, enabling
    /// specialized reporting and analysis for different discount programs, promotional
    /// campaigns, or business arrangements. This code may be used for integration with
    /// business intelligence systems or specialized fiscal reporting requirements.
    /// </remarks>
    public string? Collector { get; set; } = "00";
}

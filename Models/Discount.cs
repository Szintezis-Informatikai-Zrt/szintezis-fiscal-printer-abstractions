using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a discount applied to an individual item or transaction line, including promotional
/// reductions, quantity discounts, or other price adjustments that reduce the customer's cost.
/// </summary>
/// <remarks>
/// Discounts provide flexible pricing adjustments that can be applied to individual items during
/// transaction processing. They support both percentage-based and fixed-amount reductions, and
/// include comprehensive tracking information for proper fiscal documentation and business analysis.
/// All discounts are properly reflected in fiscal calculations and reporting to ensure compliance
/// with tax regulations and accurate business accounting.
/// </remarks>
public sealed class Discount
{
    /// <summary>
    /// Gets or sets the type of discount being applied, determining calculation and application behavior.
    /// </summary>
    /// <value>
    /// A <see cref="DiscountMode"/> value specifying how this discount should be calculated and applied.
    /// </value>
    /// <remarks>
    /// The discount mode determines the mathematical approach used for discount calculation and may
    /// affect how the discount is displayed, calculated, and reported. Different modes support
    /// various business discount policies and promotional strategies while ensuring proper fiscal
    /// treatment and compliance with tax regulations.
    /// </remarks>
    public DiscountMode DiscountMode { get; set; }

    /// <summary>
    /// Gets or sets the discount amount, which may represent a monetary value or percentage depending on <see cref="IsPercentage"/>.
    /// </summary>
    /// <value>
    /// The discount value - either a monetary amount in the local currency or a percentage value.
    /// </value>
    /// <remarks>
    /// For monetary discounts, this represents the absolute amount to be deducted from the item price.
    /// For percentage discounts, this represents the percentage to be applied (e.g., 10 for 10% discount).
    /// The interpretation depends on the <see cref="IsPercentage"/> flag and affects how the final
    /// discount amount is calculated and applied to the transaction.
    /// </remarks>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the original value before the discount was applied, used for calculation reference.
    /// </summary>
    /// <value>
    /// The base amount that serves as the reference for discount calculations.
    /// </value>
    /// <remarks>
    /// The original value provides the baseline for percentage calculations and helps ensure accurate
    /// discount application. For item discounts, this is typically the item's gross value. This value
    /// is important for audit trails and ensures that discount calculations are transparent and
    /// verifiable for both business analysis and regulatory compliance.
    /// </remarks>
    public decimal OriginalValue { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the discount amount represents a percentage or a fixed monetary amount.
    /// </summary>
    /// <value>
    /// <c>true</c> if the <see cref="Amount"/> represents a percentage; <c>false</c> if it represents a monetary amount.
    /// </value>
    /// <remarks>
    /// This flag determines how the discount amount is interpreted and calculated. When true, the amount
    /// is treated as a percentage to be applied to the original value. When false, the amount is treated
    /// as a fixed monetary deduction. This flexibility supports various discount strategies and promotional
    /// policies while ensuring clear calculation methods.
    /// </remarks>
    public bool IsPercentage { get; set; }

    /// <summary>
    /// Gets or sets an optional comment or description explaining the reason for this discount.
    /// </summary>
    /// <value>
    /// A text description of the discount reason, promotion name, or other explanatory information,
    /// or <c>null</c> if no comment is provided.
    /// </value>
    /// <remarks>
    /// Comments provide human-readable context for discounts, such as promotion names, discount reasons,
    /// or special circumstances. This information can be useful for customer communication, staff
    /// reference, business analysis, and audit documentation. Comments may appear on printed receipts
    /// depending on system configuration and business requirements.
    /// </remarks>
    public string? Comment { get; set; }
}

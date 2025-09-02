using System.ComponentModel.DataAnnotations;
using NetEscapades.EnumGenerators;

namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the calculation methods for applying tax-level discounts and surcharges to entire VAT categories
/// within transactions, supporting both percentage-based and fixed-amount adjustments.
/// </summary>
/// <remarks>
/// Tax discount modes determine how price adjustments are calculated and applied at the VAT category level,
/// affecting all items within specific tax classifications rather than individual items. These modes ensure
/// proper VAT calculation and compliance while supporting sophisticated business discount policies that
/// operate across tax categories.
/// 
/// <para>
/// Tax-level discounts are applied after item-level discounts and require careful handling to maintain
/// VAT compliance and accurate tax reporting. Each mode has specific calculation rules and fiscal
/// treatment that ensure proper integration with tax authorities' reporting requirements.
/// </para>
/// 
/// <para>
/// The Display attribute values represent the fiscal printer codes used internally for each tax discount type,
/// enabling proper communication with fiscal hardware and ensuring compliance with fiscal protocols.
/// </para>
/// </remarks>
[EnumExtensions]
public enum TaxDiscountMode
{
    /// <summary>
    /// Fixed monetary amount reduction applied to the total value of a specific VAT category.
    /// </summary>
    /// <remarks>
    /// Tax amount discounts deduct a specific monetary value from the total of all items
    /// within a particular VAT category. This mode is useful for fixed-value promotional
    /// discounts that apply to entire tax groups, contractual discounts by tax category,
    /// or regulatory discount programs. The discount amount is subtracted from the tax
    /// category total before VAT calculations are finalized.
    /// </remarks>
    [Display(Name = "TD")]
    TaxAmountDiscount,

    /// <summary>
    /// Fixed monetary amount addition applied to the total value of a specific VAT category.
    /// </summary>
    /// <remarks>
    /// Tax amount surcharges add a specific monetary value to the total of all items
    /// within a particular VAT category. This mode supports handling of additional fees,
    /// environmental charges, or special levies that apply to entire tax groups. The
    /// surcharge amount is added to the tax category total and included in VAT calculations.
    /// </remarks>
    [Display(Name = "TI")]
    TaxAmountSurcharge,

    /// <summary>
    /// Percentage-based reduction applied to the total value of a specific VAT category.
    /// </summary>
    /// <remarks>
    /// Tax percentage discounts reduce the total value of all items within a VAT category
    /// by a specified percentage. This mode is commonly used for volume discounts that
    /// apply to entire tax groups, seasonal sales affecting specific tax categories, or
    /// business-to-business contractual discount arrangements. The percentage is applied
    /// to the tax category total, making it proportional to the category's value.
    /// </remarks>
    [Display(Name = "TM")]
    TaxPercentageDiscount,

    /// <summary>
    /// Percentage-based addition applied to the total value of a specific VAT category.
    /// </summary>
    /// <remarks>
    /// Tax percentage surcharges increase the total value of all items within a VAT category
    /// by a specified percentage. This mode is useful for handling service charges, premium
    /// fees, or additional taxes that should be proportional to the category's value. The
    /// percentage is applied to the tax category total and integrated into VAT calculations
    /// and reporting.
    /// </remarks>
    [Display(Name = "TP")]
    TaxPercentageSurcharge,
}

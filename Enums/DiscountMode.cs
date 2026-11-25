using System.ComponentModel.DataAnnotations;
using NetEscapades.EnumGenerators;

namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the different calculation methods for applying discounts and surcharges to transaction items,
/// supporting both percentage-based and fixed-amount adjustments in either direction.
/// </summary>
/// <remarks>
/// Discount modes determine how price adjustments are calculated and applied to transaction items.
/// The system supports both reductions (discounts) and increases (surcharges) that can be calculated
/// either as fixed monetary amounts or as percentages of the original item value. Each mode has
/// specific calculation rules and display formatting that ensure accurate pricing and clear
/// customer communication.
/// 
/// <para>
/// The Display attribute values represent the fiscal printer codes used internally for each discount type,
/// enabling proper communication with fiscal hardware and ensuring compliance with fiscal protocols.
/// </para>
/// </remarks>
[EnumExtensions(MetadataSource = MetadataSource.DisplayAttribute)]
public enum DiscountMode
{
    /// <summary>
    /// Fixed monetary amount reduction from the item price.
    /// </summary>
    /// <remarks>
    /// Amount discounts deduct a specific monetary value from the item price, regardless of the
    /// original item value. This mode is useful for fixed-value coupons, specific promotional
    /// deductions, or standard discount amounts. The discount amount is specified in the local
    /// currency and is subtracted directly from the item's gross value.
    /// </remarks>
    [Display(Name = "D")]
    AmountDiscount,

    /// <summary>
    /// Fixed monetary amount addition to the item price.
    /// </summary>
    /// <remarks>
    /// Amount surcharges add a specific monetary value to the item price, useful for handling
    /// additional fees, special charges, or premium service costs. The surcharge amount is
    /// specified in the local currency and is added directly to the item's gross value.
    /// This mode supports various business scenarios where fixed additional costs apply.
    /// </remarks>
    [Display(Name = "I")]
    AmountSurcharge,

    /// <summary>
    /// Percentage-based reduction from the item price.
    /// </summary>
    /// <remarks>
    /// Percentage discounts reduce the item price by a specified percentage of the original value.
    /// This mode is commonly used for promotional sales, volume discounts, loyalty rewards, and
    /// seasonal sales. The percentage is applied to the item's gross value, making it proportional
    /// to the item's cost and ensuring consistent discount application across different price points.
    /// </remarks>
    [Display(Name = "M")]
    PercentageDiscount,

    /// <summary>
    /// Percentage-based addition to the item price.
    /// </summary>
    /// <remarks>
    /// Percentage surcharges increase the item price by a specified percentage of the original value.
    /// This mode is useful for handling service charges, convenience fees, or premium pricing that
    /// should be proportional to the item's base cost. The percentage is applied to the item's
    /// gross value, ensuring that surcharges scale appropriately with item values.
    /// </remarks>
    [Display(Name = "P")]
    PercentageSurcharge,
}

using System.ComponentModel.DataAnnotations;
using NetEscapades.EnumGenerators;

namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the various payment methods available for fiscal transactions, including cash, cards, 
/// foreign currencies, and custom payment instruments.
/// </summary>
/// <remarks>
/// Payment modes determine how transactions are processed, reported, and reconciled. Each mode
/// has specific handling requirements and may affect currency conversion, reporting categories,
/// and cash drawer operations. The Display attribute values represent the fiscal printer codes
/// used internally for each payment method.
/// </remarks>
[EnumExtensions]
public enum PaidMode
{
    /// <summary>
    /// Payment made with local currency cash.
    /// </summary>
    /// <remarks>
    /// Local cash is the primary payment method that affects the physical cash drawer.
    /// These payments require exact change calculations and cash handling procedures.
    /// All amounts are in the local currency without conversion.
    /// </remarks>
    [Display(Name = "P")]
    LocalCash,

    /// <summary>
    /// Payment made with credit or debit card.
    /// </summary>
    /// <remarks>
    /// Card payments are electronic transactions that don't affect the physical cash drawer.
    /// They may require integration with payment terminals and typically provide electronic
    /// receipts or transaction confirmations.
    /// </remarks>
    [Display(Name = "N")]
    CreditCard,

    /// <summary>
    /// Payment made with foreign currency cash (typically Euro).
    /// </summary>
    /// <remarks>
    /// Foreign cash payments require currency conversion using configured exchange rates.
    /// The converted amount affects cash drawer tracking, and change may be given in
    /// local currency depending on business policies.
    /// </remarks>
    [Display(Name = "F0")]
    ForeignCash,

    /// <summary>
    /// Payment made with the first custom foreign currency.
    /// </summary>
    /// <remarks>
    /// Custom foreign currencies allow businesses to accept additional international currencies
    /// beyond the standard Euro. Exchange rates must be configured before use.
    /// </remarks>
    [Display(Name = "F1")]
    CustomForeignCurrency01,

    /// <summary>
    /// Payment made with the second custom foreign currency.
    /// </summary>
    /// <remarks>
    /// Custom foreign currencies allow businesses to accept additional international currencies
    /// beyond the standard Euro. Exchange rates must be configured before use.
    /// </remarks>
    [Display(Name = "F2")]
    CustomForeignCurrency02,

    /// <summary>
    /// Payment made with the third custom foreign currency.
    /// </summary>
    /// <remarks>
    /// Custom foreign currencies allow businesses to accept additional international currencies
    /// beyond the standard Euro. Exchange rates must be configured before use.
    /// </remarks>
    [Display(Name = "F3")]
    CustomForeignCurrency03,

    /// <summary>
    /// Payment made with the fourth custom foreign currency.
    /// </summary>
    /// <remarks>
    /// Custom foreign currencies allow businesses to accept additional international currencies
    /// beyond the standard Euro. Exchange rates must be configured before use.
    /// </remarks>
    [Display(Name = "F4")]
    CustomForeignCurrency04,

    /// <summary>
    /// Payment made with the fifth custom foreign currency.
    /// </summary>
    /// <remarks>
    /// Custom foreign currencies allow businesses to accept additional international currencies
    /// beyond the standard Euro. Exchange rates must be configured before use.
    /// </remarks>
    [Display(Name = "F5")]
    CustomForeignCurrency05,

    /// <summary>
    /// Payment made with the first predefined alternative payment method.
    /// </summary>
    /// <remarks>
    /// Other payment methods are predefined categories for business-specific payment instruments
    /// such as vouchers, gift cards, or loyalty points. These don't typically affect cash drawer totals.
    /// </remarks>
    [Display(Name = "O1")]
    OtherPayment01,

    /// <summary>
    /// Payment made with the second predefined alternative payment method.
    /// </summary>
    /// <remarks>
    /// Other payment methods are predefined categories for business-specific payment instruments
    /// such as vouchers, gift cards, or loyalty points. These don't typically affect cash drawer totals.
    /// </remarks>
    [Display(Name = "O2")]
    OtherPayment02,

    /// <summary>
    /// Payment made with the third predefined alternative payment method.
    /// </summary>
    /// <remarks>
    /// Other payment methods are predefined categories for business-specific payment instruments
    /// such as vouchers, gift cards, or loyalty points. These don't typically affect cash drawer totals.
    /// </remarks>
    [Display(Name = "O3")]
    OtherPayment03,

    /// <summary>
    /// Payment made with the fourth predefined alternative payment method.
    /// </summary>
    /// <remarks>
    /// Other payment methods are predefined categories for business-specific payment instruments
    /// such as vouchers, gift cards, or loyalty points. These don't typically affect cash drawer totals.
    /// </remarks>
    [Display(Name = "O4")]
    OtherPayment04,

    /// <summary>
    /// Payment made with the fifth predefined alternative payment method.
    /// </summary>
    /// <remarks>
    /// Other payment methods are predefined categories for business-specific payment instruments
    /// such as vouchers, gift cards, or loyalty points. These don't typically affect cash drawer totals.
    /// </remarks>
    [Display(Name = "O5")]
    OtherPayment05,

    /// <summary>
    /// Payment made with the sixth predefined alternative payment method.
    /// </summary>
    /// <remarks>
    /// Other payment methods are predefined categories for business-specific payment instruments
    /// such as vouchers, gift cards, or loyalty points. These don't typically affect cash drawer totals.
    /// </remarks>
    [Display(Name = "O6")]
    OtherPayment06,

    /// <summary>
    /// Payment made with the seventh predefined alternative payment method.
    /// </summary>
    /// <remarks>
    /// Other payment methods are predefined categories for business-specific payment instruments
    /// such as vouchers, gift cards, or loyalty points. These don't typically affect cash drawer totals.
    /// </remarks>
    [Display(Name = "O7")]
    OtherPayment07,

    /// <summary>
    /// Payment made with the eighth predefined alternative payment method.
    /// </summary>
    /// <remarks>
    /// Other payment methods are predefined categories for business-specific payment instruments
    /// such as vouchers, gift cards, or loyalty points. These don't typically affect cash drawer totals.
    /// </remarks>
    [Display(Name = "O8")]
    OtherPayment08,

    /// <summary>
    /// Payment made with the first custom-named payment method.
    /// </summary>
    /// <remarks>
    /// Custom payment methods allow businesses to define their own payment instrument names
    /// and categories. The first custom payment is reserved for "AFR" (automatic fiscal receipt)
    /// in many implementations. Names must be configured before use.
    /// </remarks>
    [Display(Name = "U1")]
    CustomPayment01,

    /// <summary>
    /// Payment made with the second custom-named payment method.
    /// </summary>
    /// <remarks>
    /// Custom payment methods allow businesses to define their own payment instrument names
    /// and categories. Names can be up to 13 characters and must be configured before use.
    /// </remarks>
    [Display(Name = "U2")]
    CustomPayment02,

    /// <summary>
    /// Payment made with the third custom-named payment method.
    /// </summary>
    /// <remarks>
    /// Custom payment methods allow businesses to define their own payment instrument names
    /// and categories. Names can be up to 13 characters and must be configured before use.
    /// </remarks>
    [Display(Name = "U3")]
    CustomPayment03,

    /// <summary>
    /// Payment made with the fourth custom-named payment method.
    /// </summary>
    /// <remarks>
    /// Custom payment methods allow businesses to define their own payment instrument names
    /// and categories. Names can be up to 13 characters and must be configured before use.
    /// </remarks>
    [Display(Name = "U4")]
    CustomPayment04,

    /// <summary>
    /// Payment made with the fifth custom-named payment method.
    /// </summary>
    /// <remarks>
    /// Custom payment methods allow businesses to define their own payment instrument names
    /// and categories. Names can be up to 13 characters and must be configured before use.
    /// </remarks>
    [Display(Name = "U5")]
    CustomPayment05,

    /// <summary>
    /// Payment made with the sixth custom-named payment method.
    /// </summary>
    /// <remarks>
    /// Custom payment methods allow businesses to define their own payment instrument names
    /// and categories. Names can be up to 13 characters and must be configured before use.
    /// </remarks>
    [Display(Name = "U6")]
    CustomPayment06,

    /// <summary>
    /// Payment made with the seventh custom-named payment method.
    /// </summary>
    /// <remarks>
    /// Custom payment methods allow businesses to define their own payment instrument names
    /// and categories. Names can be up to 13 characters and must be configured before use.
    /// </remarks>
    [Display(Name = "U7")]
    CustomPayment07,

    /// <summary>
    /// Payment made with the eighth custom-named payment method.
    /// </summary>
    /// <remarks>
    /// Custom payment methods allow businesses to define their own payment instrument names
    /// and categories. Names can be up to 13 characters and must be configured before use.
    /// </remarks>
    [Display(Name = "U8")]
    CustomPayment08,
}

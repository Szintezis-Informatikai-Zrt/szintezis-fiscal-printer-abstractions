namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the different categories of cash withdrawals that can be processed through the fiscal system,
/// providing proper classification for various types of money flowing out of the business.
/// </summary>
/// <remarks>
/// Pay-out types enable precise categorization of different cash withdrawal scenarios, supporting
/// accurate financial reporting, audit trails, and business analysis. Each type represents a
/// specific business reason for removing money from the cash drawer, which helps with accounting
/// accuracy, compliance reporting, and operational management.
/// 
/// <para>
/// Proper categorization of pay-out transactions serves several important purposes:
/// <list type="bullet">
/// <item><description>Accurate financial reporting and accounting classification</description></item>
/// <item><description>Compliance with fiscal regulations and audit requirements</description></item>
/// <item><description>Business analysis and cash flow management</description></item>
/// <item><description>Operational transparency and accountability</description></item>
/// <item><description>Integration with business intelligence and reporting systems</description></item>
/// </list>
/// </para>
/// </remarks>
public enum PayOutType
{
    /// <summary>
    /// Withdrawal of excess cash from the register to maintain optimal operating levels.
    /// </summary>
    /// <remarks>
    /// Skimming involves removing excess cash from the register to prevent accumulation of
    /// large amounts that could pose security risks. This is a common cash management practice
    /// that helps maintain appropriate cash levels while reducing theft exposure and ensuring
    /// efficient operations.
    /// </remarks>
    Skim = 0,

    /// <summary>
    /// Cash payment directly to cashier for wages, tips, or personal withdrawals.
    /// </summary>
    /// <remarks>
    /// Pay-outs to cashiers can include salary payments, tip distributions, personal loans,
    /// or other employee-related cash distributions. These transactions require careful
    /// documentation for payroll and labor compliance purposes.
    /// </remarks>
    PayOutToCashier = 1,

    /// <summary>
    /// Payment using checks or check-like instruments for business expenses.
    /// </summary>
    /// <remarks>
    /// Check payments represent business expenses paid through check instruments, requiring
    /// special handling and documentation for accounting and reconciliation purposes.
    /// These transactions bridge cash operations with traditional banking instruments.
    /// </remarks>
    PayPutCheq = 2,

    /// <summary>
    /// Cash payment for gift card redemptions or gift card-related transactions.
    /// </summary>
    /// <remarks>
    /// Gift card pay-outs occur when customers redeem gift cards for cash or when gift card
    /// balances are converted to cash. These transactions require special tracking for
    /// gift card liability management and customer service purposes.
    /// </remarks>
    GiftCardPayOut = 3,

    /// <summary>
    /// Salary or wage payments made in cash to employees.
    /// </summary>
    /// <remarks>
    /// Salary pay-outs represent direct cash wage payments to employees, which may be
    /// necessary in certain business environments or for specific employee arrangements.
    /// These payments require careful documentation for payroll tax compliance.
    /// </remarks>
    SalaryPayOut = 4,

    /// <summary>
    /// Deposits made for sales-related security or guarantee purposes.
    /// </summary>
    /// <remarks>
    /// Sales deposits are cash amounts set aside as security deposits, guarantees, or
    /// escrow funds related to specific sales transactions. These amounts may be held
    /// temporarily and returned based on transaction completion or terms.
    /// </remarks>
    SalesDeposit = 5,

    /// <summary>
    /// Payment of postal or shipping costs for business operations.
    /// </summary>
    /// <remarks>
    /// Post costs represent cash payments for shipping, postage, or delivery services
    /// related to business operations. These are typically operational expenses that
    /// require separate tracking for accounting and cost management purposes.
    /// </remarks>
    PostCost = 6,

    /// <summary>
    /// Payment of miscellaneous fees or charges not covered by other categories.
    /// </summary>
    /// <remarks>
    /// Other fees encompass various business-related charges, service fees, or
    /// administrative costs that don't fit into specific categories but require
    /// cash payment and proper documentation for expense tracking.
    /// </remarks>
    OtherFee = 7,

    /// <summary>
    /// Cash payment for purchasing goods or inventory for the business.
    /// </summary>
    /// <remarks>
    /// Buy goods payments represent cash expenditures for inventory, supplies, or other
    /// business purchases. These transactions are typically part of cost of goods sold
    /// calculations and require proper documentation for inventory management.
    /// </remarks>
    BuyGoods = 8,

    /// <summary>
    /// Total cash withdrawal representing the sum of all daily cash removals.
    /// </summary>
    /// <remarks>
    /// Total pay-out represents a comprehensive cash withdrawal that may encompass
    /// multiple categories or represent a complete cash removal operation. This is
    /// often used for end-of-day procedures or comprehensive cash management operations.
    /// </remarks>
    TotalPayOut = 9,

    /// <summary>
    /// General cash withdrawal not covered by specific categories.
    /// </summary>
    /// <remarks>
    /// Other pay-out provides flexibility for unusual or business-specific withdrawal
    /// scenarios that don't fit standard categories. This ensures all cash movements
    /// can be properly documented and tracked even in exceptional circumstances.
    /// </remarks>
    OtherPayOut = 10,

    /// <summary>
    /// Cash adjustments related to changing payment methods or payment corrections.
    /// </summary>
    /// <remarks>
    /// Payment type change withdrawals occur when payment methods are modified after
    /// transactions, such as converting cash payments to cards or handling payment
    /// method corrections. These transactions ensure proper audit trails for payment
    /// modifications.
    /// </remarks>
    PaymentTypeChange = 11,
}

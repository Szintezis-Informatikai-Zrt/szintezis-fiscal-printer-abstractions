namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the different categories of cash deposits that can be processed through the fiscal system,
/// providing proper classification for various types of money flowing into the cash drawer.
/// </summary>
/// <remarks>
/// Pay-in types enable precise categorization of different cash deposit scenarios, supporting
/// accurate financial reporting, audit trails, and business analysis. Each type represents a
/// specific business reason for adding money to the cash drawer, which helps with accounting
/// accuracy, compliance reporting, and operational management.
/// 
/// <para>
/// Proper categorization of pay-in transactions serves several important purposes:
/// <list type="bullet">
/// <item><description>Accurate financial reporting and accounting classification</description></item>
/// <item><description>Compliance with fiscal regulations and audit requirements</description></item>
/// <item><description>Business analysis and cash flow management</description></item>
/// <item><description>Operational transparency and accountability</description></item>
/// <item><description>Integration with business intelligence and reporting systems</description></item>
/// </list>
/// </para>
/// </remarks>
public enum PayInType
{
    /// <summary>
    /// Deposit of change money to ensure adequate small denominations for customer transactions.
    /// </summary>
    /// <remarks>
    /// Change money deposits typically occur when cash drawers need additional small denomination
    /// bills and coins to provide proper change to customers. This is a common operational need
    /// to maintain effective customer service and prevent change-making difficulties during
    /// busy periods or when large bills are frequently received.
    /// </remarks>
    ChangeMoney = 0,

    /// <summary>
    /// Cashier's personal deposit or security deposit for drawer responsibility.
    /// </summary>
    /// <remarks>
    /// Cashier deposits represent personal funds placed in the drawer by individual cashiers,
    /// often used for security purposes or personal accountability. These deposits help establish
    /// individual responsibility for cash handling and may be required by business policies
    /// for cash management and loss prevention.
    /// </remarks>
    CashierDeposit = 1,

    /// <summary>
    /// Collection of various fees, charges, or service payments not related to product sales.
    /// </summary>
    /// <remarks>
    /// Fee collections include various service charges, processing fees, membership fees, or
    /// other non-product revenue that businesses collect. These transactions require separate
    /// tracking from product sales for proper accounting and revenue categorization.
    /// </remarks>
    FeeCollection = 2,

    /// <summary>
    /// Revenue from lottery ticket sales or similar gaming products.
    /// </summary>
    /// <remarks>
    /// Lottery ticket sales represent a specific category of revenue that often requires
    /// separate tracking and reporting due to regulatory requirements, commission structures,
    /// and accounting treatments that differ from regular product sales.
    /// </remarks>
    LotteryTicketSales = 3,

    /// <summary>
    /// Customer prepayments or deposits for future goods or services.
    /// </summary>
    /// <remarks>
    /// Prepayments represent customer deposits for future purchases, layaway payments, or
    /// advance payments for services. These transactions require careful tracking as they
    /// represent liabilities until the goods or services are delivered.
    /// </remarks>
    Prepayment = 4,

    /// <summary>
    /// Deposit to cover cash register shortages or deficits discovered during reconciliation.
    /// </summary>
    /// <remarks>
    /// Cash register deficit deposits are used to balance cash drawers when shortages are
    /// discovered during reconciliation processes. These transactions help maintain drawer
    /// accuracy and provide audit trails for cash discrepancies and their resolution.
    /// </remarks>
    CashRegisterDeficit = 5,

    /// <summary>
    /// Tips or gratuities collected for service staff.
    /// </summary>
    /// <remarks>
    /// Tip collections represent gratuities received for services, which may require separate
    /// tracking for payroll purposes, tax reporting, and distribution to service staff.
    /// Proper categorization ensures compliance with labor laws and tax regulations.
    /// </remarks>
    Tip = 6,

    /// <summary>
    /// Other miscellaneous cash deposits not covered by specific categories.
    /// </summary>
    /// <remarks>
    /// Other cash-in transactions provide flexibility for unusual or business-specific deposit
    /// scenarios that don't fit standard categories. This ensures all cash movements can be
    /// properly documented and tracked even in exceptional circumstances.
    /// </remarks>
    OtherCashIn = 7,

    /// <summary>
    /// Deposits related to changing payment methods or payment type corrections.
    /// </summary>
    /// <remarks>
    /// Payment type change deposits occur when payment methods are modified after transactions,
    /// such as converting card payments to cash or handling payment method exchanges.
    /// These transactions ensure proper audit trails for payment modifications.
    /// </remarks>
    PaymentTypeChange = 8,
}

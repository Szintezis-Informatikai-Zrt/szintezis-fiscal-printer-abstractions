using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when the cash drawer contains insufficient funds for a specific
/// payment method to complete a requested operation such as providing change or processing refunds.
/// </summary>
/// <remarks>
/// Drawer content errors are critical cash management issues that occur when the physical cash
/// drawer doesn't contain enough money in a specific payment method to fulfill transaction
/// requirements. This commonly happens during change-making operations, refund processing, or
/// cash-out operations where the drawer lacks sufficient denominations or currency amounts.
/// 
/// <para>
/// Common scenarios that trigger drawer content errors include:
/// <list type="bullet">
/// <item><description>Insufficient cash for providing change to customers during sales transactions</description></item>
/// <item><description>Lack of specific currency denominations needed for foreign currency operations</description></item>
/// <item><description>Inadequate funds for processing customer refunds or returns</description></item>
/// <item><description>Missing payment method balances for cash-out or withdrawal operations</description></item>
/// <item><description>Drawer skimming operations that removed too much of a specific payment method</description></item>
/// <item><description>End-of-day operations attempting to balance accounts with insufficient drawer contents</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve drawer content errors, add sufficient funds of the specified payment method to
/// the cash drawer, perform cash-in operations to replenish depleted payment methods, or
/// modify the transaction to use alternative payment methods that have adequate balances.
/// Regular cash management procedures can help prevent these issues.
/// </para>
/// </remarks>
public class DrawerContentError : ErrorBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DrawerContentError"/> class for a specific payment method.
    /// </summary>
    /// <param name="paidMode">The payment method that has insufficient drawer content</param>
    /// <remarks>
    /// The constructor automatically creates a descriptive error message identifying the specific
    /// payment method that lacks sufficient drawer content and adds the payment method to the
    /// error metadata for diagnostic purposes.
    /// </remarks>
    public DrawerContentError(PaidMode paidMode)
    {
        PaidMode = paidMode;
        WithMetadata(nameof(PaidMode), paidMode);

        Message = $"Drawer content is insufficient: {PaidMode}";
    }

    /// <summary>
    /// Gets the payment method that has insufficient content in the cash drawer.
    /// </summary>
    /// <value>
    /// The <see cref="PaidMode"/> that lacks adequate balance for the requested operation.
    /// </value>
    /// <remarks>
    /// The payment mode identifies which specific payment method or currency lacks sufficient
    /// drawer content. This information is essential for cash management decisions and helps
    /// operators understand which payment methods need replenishment to resolve the issue.
    /// </remarks>
    public PaidMode PaidMode { get; }

    /// <summary>
    /// Gets the descriptive error message identifying the payment method with insufficient content.
    /// </summary>
    /// <value>
    /// A message that specifies which payment method has inadequate drawer balance.
    /// </value>
    public new string Message { get; }

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "DrawerContentError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(DrawerContentError);
}

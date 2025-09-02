using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a payment method change operation that documents the modification of payment instruments
/// used for a completed transaction, providing audit trails for payment adjustments.
/// </summary>
/// <remarks>
/// Payment method changes are used when customers or business needs require modification of how
/// a transaction was originally settled. This could occur due to customer preference changes,
/// technical issues with the original payment method, or business operational requirements.
/// These operations maintain proper fiscal compliance by documenting all payment modifications
/// with complete audit trails.
/// 
/// <para>
/// Common scenarios for payment method changes include:
/// <list type="bullet">
/// <item><description>Customer requests to change from card payment to cash after completion</description></item>
/// <item><description>Technical issues requiring payment method switching during processing</description></item>
/// <item><description>Business policy changes affecting payment method preferences</description></item>
/// <item><description>Cash management operations requiring payment redistribution</description></item>
/// <item><description>Customer service adjustments for payment-related issues</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// All payment changes must comply with fiscal regulations and maintain complete documentation
/// for audit purposes, ensuring that the change process is transparent and accountable.
/// </para>
/// </remarks>
public sealed class ChangePayment
{
    /// <summary>
    /// Gets or sets the original payment method that is being changed.
    /// </summary>
    /// <value>
    /// A <see cref="PaidMode"/> value indicating the payment method used in the original transaction.
    /// </value>
    /// <remarks>
    /// The source payment method represents how the transaction was originally settled and serves
    /// as the reference point for the payment change operation. This ensures proper tracking
    /// of payment method transitions and maintains accurate audit trails for compliance purposes.
    /// </remarks>
    public PaidMode FromPayment { get; set; }

    /// <summary>
    /// Gets or sets the new payment method that will replace the original payment.
    /// </summary>
    /// <value>
    /// A <see cref="PaidMode"/> value indicating the payment method that will be used after the change.
    /// </value>
    /// <remarks>
    /// The destination payment method represents how the transaction will be settled after the
    /// payment change operation. This payment method must be valid and available for use according
    /// to business policies and fiscal regulations. The change affects cash drawer balances and
    /// payment method reporting accordingly.
    /// </remarks>
    public PaidMode ToPayment { get; set; }

    /// <summary>
    /// Gets or sets the monetary amount involved in the payment method change.
    /// </summary>
    /// <value>
    /// The amount in local currency that is being transferred between payment methods.
    /// </value>
    /// <remarks>
    /// The amount represents the value being moved from one payment method to another. This amount
    /// must match the original transaction amount or the portion being changed if partial payment
    /// method modifications are allowed. The amount affects cash drawer totals and payment method
    /// balances according to the direction of the change operation.
    /// </remarks>
    public required decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets an optional note explaining the reason for the payment method change.
    /// </summary>
    /// <value>
    /// A text description providing context about why the payment change was necessary,
    /// or <c>null</c> if no additional explanation is needed.
    /// </value>
    /// <remarks>
    /// Notes provide valuable documentation for payment changes, helping with audit trails,
    /// customer service records, and operational analysis. They can include reasons such as
    /// customer requests, technical issues, or business operational requirements that
    /// necessitated the payment method modification.
    /// </remarks>
    public string? Note { get; set; }
}

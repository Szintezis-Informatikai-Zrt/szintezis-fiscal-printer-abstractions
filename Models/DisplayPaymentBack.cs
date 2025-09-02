namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents change amount information to be displayed on the customer-facing display when customers
/// receive money back due to overpayment, providing transaction transparency and confirmation.
/// </summary>
/// <remarks>
/// Display payment back information shows customers the exact amount of change they will receive
/// when they have overpaid for their transaction. This enhances customer trust and transaction
/// transparency by clearly communicating the change amount before it is dispensed, allowing
/// customers to verify the calculation and prepare to receive their change.
/// 
/// <para>
/// Change amount displays are particularly important for:
/// <list type="bullet">
/// <item><description>Cash transactions where customers pay more than the exact amount</description></item>
/// <item><description>Foreign currency transactions with conversion calculations</description></item>
/// <item><description>Multi-payment scenarios where final payment exceeds remaining balance</description></item>
/// <item><description>Customer service verification and dispute prevention</description></item>
/// <item><description>Training scenarios where change calculation accuracy is important</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// Clear change amount communication helps prevent misunderstandings, reduces disputes,
/// and enhances overall customer satisfaction by providing transparency in the payment process.
/// </para>
/// </remarks>
public sealed class DisplayPaymentBack
{
    /// <summary>
    /// Gets or sets the display duration in milliseconds before the change amount information automatically updates.
    /// </summary>
    /// <value>
    /// The time in milliseconds that this change amount will remain visible on the customer display.
    /// Default value is 300 milliseconds.
    /// </value>
    /// <remarks>
    /// The display time gives customers adequate opportunity to see and verify the change amount
    /// they will receive. This timing should be sufficient for customer recognition while maintaining
    /// efficient transaction flow, especially important when customers need to prepare to receive
    /// physical change or verify electronic payment reversals.
    /// </remarks>
    public int Time { get; set; } = 300;

    /// <summary>
    /// Gets or sets the monetary amount of change to be returned to the customer.
    /// </summary>
    /// <value>
    /// The change amount in the local currency that will be dispensed to the customer.
    /// </value>
    /// <remarks>
    /// This value represents the difference between the amount paid by the customer and the
    /// total transaction amount. It shows customers exactly how much money they will receive
    /// back, enabling them to verify the calculation and prepare for change collection.
    /// The amount should always be positive when change is due.
    /// </remarks>
    public decimal Value { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal places to display for the change amount.
    /// </summary>
    /// <value>
    /// The precision level for change amount formatting (typically 2 for most currencies).
    /// </value>
    /// <remarks>
    /// Decimal precision ensures that change amounts are displayed with appropriate accuracy
    /// for the currency being used. Most currencies use 2 decimal places, but the precision
    /// should match the smallest denomination of physical currency available for change
    /// to avoid confusion about exact amounts that can be dispensed.
    /// </remarks>
    public int DecimalPlaces { get; set; }

    /// <summary>
    /// Gets or sets the currency symbol to display with the change amount.
    /// </summary>
    /// <value>
    /// The currency symbol or abbreviation (e.g., "$", "€", "Ft") to display with the change amount.
    /// </value>
    /// <remarks>
    /// The currency sign provides essential context for the change amount, ensuring customers
    /// clearly understand the currency they will receive. This is particularly important in
    /// international retail environments or when foreign currency payments have been converted
    /// to local currency for change calculation.
    /// </remarks>
    public required string CurrencySign { get; set; }
}


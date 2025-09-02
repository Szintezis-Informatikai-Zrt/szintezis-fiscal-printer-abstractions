namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when calculated transaction subtotals do not match expected values,
/// indicating potential calculation errors, data corruption, or system integration problems.
/// </summary>
/// <remarks>
/// Subtotal mismatch errors are critical validation failures that prevent transaction completion
/// to ensure fiscal accuracy and compliance. These errors typically occur when the sum of individual
/// item values, discounts, and adjustments doesn't equal the provided total amount, which could
/// indicate calculation errors, rounding issues, or data integrity problems.
/// 
/// <para>
/// Common causes of subtotal mismatches include:
/// <list type="bullet">
/// <item><description>Calculation errors in item pricing or discount applications</description></item>
/// <item><description>Rounding differences between systems or calculation methods</description></item>
/// <item><description>Currency conversion errors or precision issues</description></item>
/// <item><description>Data transmission errors or corruption during processing</description></item>
/// <item><description>Integration problems between business systems and fiscal printer</description></item>
/// <item><description>Timing issues where item data changes during transaction processing</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve subtotal mismatch errors, verify all item calculations, check for rounding consistency,
/// ensure data integrity throughout the transaction process, and validate that all systems use
/// consistent calculation methods and precision levels.
/// </para>
/// </remarks>
public sealed class SubTotalMisMatchError : ErrorBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubTotalMisMatchError"/> class with the expected and actual subtotal values.
    /// </summary>
    /// <param name="_expected">The expected subtotal amount based on item calculations</param>
    /// <param name="_actual">The actual subtotal amount provided in the transaction</param>
    /// <remarks>
    /// The constructor automatically creates a detailed error message showing both expected and actual values
    /// and adds them to the error metadata for diagnostic and troubleshooting purposes.
    /// </remarks>
    public SubTotalMisMatchError(decimal _expected, decimal _actual)
    {
        Message = $"SubTotal mismatch. Expected: {_expected}, Actual: {_actual}";
        Expected = _expected;
        Actual = _actual;
        WithMetadata(nameof(Expected), _expected);
        WithMetadata(nameof(Actual), _actual);
    }

    /// <summary>
    /// Gets or sets the expected subtotal amount calculated from individual transaction components.
    /// </summary>
    /// <value>
    /// The subtotal amount that should result from summing all items, discounts, and adjustments.
    /// </value>
    /// <remarks>
    /// The expected value represents the correct subtotal based on detailed item-by-item calculations,
    /// including individual prices, quantities, discounts, and tax considerations. This value serves
    /// as the reference point for validating transaction accuracy and fiscal compliance.
    /// </remarks>
    public decimal Expected { get; set; }

    /// <summary>
    /// Gets or sets the actual subtotal amount provided in the transaction data.
    /// </summary>
    /// <value>
    /// The subtotal amount that was submitted with the transaction but doesn't match calculations.
    /// </value>
    /// <remarks>
    /// The actual value represents the subtotal amount provided by the calling system or user input
    /// that failed validation against the calculated expected amount. The difference between expected
    /// and actual values helps diagnose the source and magnitude of the calculation discrepancy.
    /// </remarks>
    public decimal Actual { get; set; }

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "SubTotalMisMatchError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode => nameof(SubTotalMisMatchError);

    /// <summary>
    /// Gets the detailed error message describing the subtotal mismatch with specific values.
    /// </summary>
    /// <value>
    /// A comprehensive message showing both expected and actual subtotal amounts for diagnostic purposes.
    /// </value>
    public new string Message { get; }
}

namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when an invalid or unsupported VAT (Value Added Tax) code is used
/// in fiscal transactions, preventing proper tax calculation and compliance reporting.
/// </summary>
/// <remarks>
/// VAT codes are critical for fiscal compliance as they determine tax rates, reporting categories,
/// and legal treatment of individual transaction items. Invalid VAT codes can prevent transactions
/// from being processed correctly and may violate fiscal regulations that require proper tax
/// classification for all sold items.
/// 
/// <para>
/// VAT code validation errors can occur due to several factors:
/// <list type="bullet">
/// <item><description>Using VAT codes that are not configured in the fiscal printer</description></item>
/// <item><description>Attempting to use deprecated or obsolete VAT codes</description></item>
/// <item><description>Providing VAT codes in incorrect format or case sensitivity</description></item>
/// <item><description>Using VAT codes that don't match the item's tax classification</description></item>
/// <item><description>System configuration issues affecting VAT code recognition</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve VAT code errors, verify that the VAT codes used in transactions match those
/// configured in the fiscal printer system, ensure proper tax classification for all items,
/// and confirm that the fiscal printer's tax configuration is current and properly maintained.
/// Consult with tax authorities or fiscal compliance specialists if VAT code requirements
/// are unclear.
/// </para>
/// </remarks>
public sealed class InvalidVatCodeError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the VAT code validation failure.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that an invalid VAT code was encountered during processing.
    /// </value>
    public new string Message { get; } = "Invalid Vat code error.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "InvalidVatCodeError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(InvalidVatCodeError);
}

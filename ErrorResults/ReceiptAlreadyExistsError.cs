namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when attempting to create a receipt with an identifier that already
/// exists in the fiscal system, preventing duplicate receipt generation and maintaining fiscal integrity.
/// </summary>
/// <remarks>
/// This error is triggered when the system detects an attempt to create a receipt with a reference,
/// identifier, or sequence number that has already been used. Receipt duplication prevention is
/// essential for maintaining fiscal compliance, preventing accounting inconsistencies, and ensuring
/// that each fiscal transaction has a unique identifier for audit and regulatory purposes.
/// 
/// <para>
/// Common scenarios that trigger receipt duplication errors include:
/// <list type="bullet">
/// <item><description>System retry operations attempting to recreate completed transactions</description></item>
/// <item><description>Integration errors where multiple systems attempt to process the same transaction</description></item>
/// <item><description>Database synchronization issues causing duplicate receipt number assignment</description></item>
/// <item><description>Manual data entry errors resulting in duplicate receipt references</description></item>
/// <item><description>Backup or recovery operations that attempt to replay completed transactions</description></item>
/// <item><description>Clock synchronization problems affecting receipt sequence numbering</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve this error, verify that the receipt hasn't already been processed successfully,
/// check for duplicate receipt identifiers in the system, ensure that retry logic doesn't create
/// duplicates, and confirm that the receipt creation operation is actually needed before attempting
/// to create a new receipt with the same identifier.
/// </para>
/// </remarks>
public sealed class ReceiptAlreadyExistsError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the duplicate receipt condition.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that a receipt with the same identifier already exists.
    /// </value>
    public new string Message { get; } = "Receipt already exists.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "ReceiptAlreadyExistsError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(ReceiptAlreadyExistsError);
}

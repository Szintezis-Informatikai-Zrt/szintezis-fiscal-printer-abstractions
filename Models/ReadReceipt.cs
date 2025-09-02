using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents the parameters required to read or retrieve a specific fiscal document from
/// the printer's memory for reprinting, verification, or audit purposes.
/// </summary>
/// <remarks>
/// Read receipt parameters provide the precise identification needed to locate and retrieve
/// specific fiscal documents from the printer's internal memory. This functionality is essential
/// for document reprinting, transaction verification, audit procedures, and compliance reporting.
/// The combination of receipt mode, closure number, and receipt number creates a unique
/// identifier for any fiscal document stored in the system.
/// 
/// <para>
/// Document reading capabilities support various business needs:
/// <list type="bullet">
/// <item><description>Reprinting lost or damaged customer receipts</description></item>
/// <item><description>Verification of transaction details for customer service</description></item>
/// <item><description>Audit procedures and compliance verification</description></item>
/// <item><description>Historical transaction analysis and reporting</description></item>
/// <item><description>Legal or regulatory document reproduction requirements</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// The fiscal printer maintains a comprehensive archive of all transactions, enabling
/// businesses to access historical data for various operational and compliance purposes.
/// </para>
/// </remarks>
public sealed class ReadReceipt
{
    /// <summary>
    /// Gets or sets the type of fiscal document being requested for reading.
    /// </summary>
    /// <value>
    /// A <see cref="ReceiptModes"/> value indicating the category of document to retrieve.
    /// </value>
    /// <remarks>
    /// The receipt mode determines which category of fiscal documents to search within,
    /// such as sales receipts, money movement receipts, returns, or storno documents.
    /// This categorization helps the system efficiently locate the requested document
    /// and ensures that the appropriate document type is retrieved.
    /// </remarks>
    public required ReceiptModes ReceiptMode { get; set; }

    /// <summary>
    /// Gets or sets the fiscal closure number that contains the requested document.
    /// </summary>
    /// <value>
    /// The numeric identifier of the fiscal closure period when the document was issued.
    /// </value>
    /// <remarks>
    /// The closure number represents the fiscal period (typically a daily period) during
    /// which the document was created. Each fiscal closure represents a bounded period
    /// of transactions that were finalized together, providing temporal organization
    /// of fiscal documents for efficient retrieval and audit purposes.
    /// </remarks>
    public required int ClosureNumber { get; set; }

    /// <summary>
    /// Gets or sets the sequential receipt number within the specified closure period.
    /// </summary>
    /// <value>
    /// The sequential number assigned to the document within its closure period.
    /// </value>
    /// <remarks>
    /// The receipt number provides the specific sequential identifier for the document
    /// within its closure period. Combined with the closure number and receipt mode,
    /// this creates a unique identifier that precisely locates the requested document
    /// in the fiscal printer's memory archive.
    /// </remarks>
    public required int ReceiptNumber { get; set; }
}


using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents a specialized cash withdrawal operation with specific categorization, documentation,
/// and receipt handling for various types of money flowing out of the business.
/// </summary>
/// <remarks>
/// Other pay-out operations provide structured handling of cash withdrawals that go beyond simple
/// cash removals, offering precise categorization and documentation for different business
/// scenarios. These operations ensure proper audit trails, compliance with fiscal regulations,
/// and accurate financial reporting for various types of cash outflows that require specific
/// accounting treatment.
/// 
/// <para>
/// Specialized pay-out operations are commonly used for:
/// <list type="bullet">
/// <item><description>Business-specific expense categories requiring separate tracking</description></item>
/// <item><description>Regulatory compliance for specific types of cash distributions</description></item>
/// <item><description>Detailed financial analysis and cash flow categorization</description></item>
/// <item><description>Audit trail requirements for different cash destinations</description></item>
/// <item><description>Integration with accounting systems requiring detailed classification</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// The structured approach ensures that all cash withdrawals are properly documented,
/// categorized, and tracked according to business needs and regulatory requirements.
/// </para>
/// </remarks>
public sealed class OtherPayOut
{
    /// <summary>
    /// Gets or sets the specific category of cash withdrawal being processed.
    /// </summary>
    /// <value>
    /// A <see cref="PayOutType"/> value indicating the business reason for this cash withdrawal.
    /// </value>
    /// <remarks>
    /// The pay-out type determines how this withdrawal is categorized for accounting, reporting,
    /// and compliance purposes. Different types may have different handling requirements,
    /// reporting obligations, and business process implications. Accurate categorization
    /// is essential for proper financial management and regulatory compliance.
    /// </remarks>
    public required PayOutType PayOutType { get; set; }

    /// <summary>
    /// Gets or sets the receipt copy handling specification for this pay-out operation.
    /// </summary>
    /// <value>
    /// A <see cref="CopyType"/> value indicating how receipt copies should be managed.
    /// </value>
    /// <remarks>
    /// Copy type determines the receipt documentation requirements for this pay-out operation,
    /// which may vary based on the type of withdrawal, business policies, or regulatory requirements.
    /// Some operations may require multiple copies for different parties or record-keeping purposes.
    /// </remarks>
    public required CopyType CopyType { get; set; }

    /// <summary>
    /// Gets or sets an optional descriptive note explaining the purpose or context of this pay-out operation.
    /// </summary>
    /// <value>
    /// A text description providing additional context about the withdrawal,
    /// or <c>null</c> if no additional notes are needed.
    /// </value>
    /// <remarks>
    /// Notes provide valuable context for pay-out operations, helping with audit trails,
    /// operational documentation, and business analysis. They can include reference numbers,
    /// explanations of unusual circumstances, or other information that helps clarify the
    /// business purpose of the withdrawal for future reference and compliance documentation.
    /// </remarks>
    public string? Note { get; set; }

    /// <summary>
    /// Gets or sets the collection of payment methods and amounts being withdrawn.
    /// </summary>
    /// <value>
    /// A list of <see cref="Tender"/> objects representing the various payment methods and amounts being removed from the drawer.
    /// </value>
    /// <remarks>
    /// Tenders specify the exact composition of the pay-out operation, including different
    /// currencies, denominations, and payment methods being withdrawn. This detailed breakdown
    /// ensures accurate cash drawer tracking, proper currency handling, and comprehensive
    /// audit trails for all withdrawn funds. Multiple tenders can be combined in a single
    /// pay-out operation for complex withdrawals.
    /// </remarks>
    public List<Tender> Tenders { get; set; } = [];
}

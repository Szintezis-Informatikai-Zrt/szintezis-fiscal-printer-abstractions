namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the number of receipt copies to be printed for fiscal transactions,
/// supporting various business documentation and record-keeping requirements.
/// </summary>
/// <remarks>
/// Copy types determine how many physical copies of fiscal documents are printed,
/// which is important for business operations, customer service, record-keeping, and
/// compliance with various business policies. Different transaction types may require
/// different copy strategies based on business needs, regulatory requirements, or
/// customer service policies.
/// 
/// <para>
/// Copy requirements vary based on several factors:
/// <list type="bullet">
/// <item><description>Business policies for customer receipt provision</description></item>
/// <item><description>Record-keeping requirements for different transaction types</description></item>
/// <item><description>Regulatory compliance for specific business categories</description></item>
/// <item><description>Customer service standards and expectations</description></item>
/// <item><description>Audit trail requirements for financial documentation</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// Proper copy management helps businesses balance operational efficiency with
/// documentation requirements while meeting customer service expectations.
/// </para>
/// </remarks>
public enum CopyType
{
    /// <summary>
    /// No physical receipt copy is printed for this transaction.
    /// </summary>
    /// <remarks>
    /// Not printing receipts is typically used for internal operations, testing scenarios,
    /// or when digital receipts are preferred. This option reduces paper consumption and
    /// is environmentally friendly, but businesses must ensure they meet any regulatory
    /// requirements for transaction documentation and customer receipt provision.
    /// </remarks>
    NotPrint = 0,

    /// <summary>
    /// One copy of the receipt is printed for standard transaction documentation.
    /// </summary>
    /// <remarks>
    /// Single copy printing is the most common approach for standard retail transactions,
    /// providing customers with their transaction documentation while minimizing paper
    /// usage. This option balances customer service needs with operational efficiency
    /// and is suitable for most standard business transactions.
    /// </remarks>
    OneCopy = 1,

    /// <summary>
    /// Two copies of the receipt are printed for enhanced documentation or dual-party requirements.
    /// </summary>
    /// <remarks>
    /// Dual copy printing is useful for transactions requiring additional documentation,
    /// such as business-to-business sales, warranty transactions, or situations where
    /// both parties need physical documentation. This option provides enhanced record-keeping
    /// but increases paper usage and printing time. Often used for invoices or special transactions.
    /// </remarks>
    TwoCopies = 2,
}

namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the different types of fiscal documents that can be printed by the fiscal printer system.
/// </summary>
/// <remarks>
/// Receipt types determine the fiscal treatment, legal requirements, and processing behavior of documents.
/// Each type has specific validation rules, customer information requirements, and tax handling procedures
/// that must be followed for regulatory compliance.
/// </remarks>
public enum ReceiptType
{
    /// <summary>
    /// A standard retail receipt for customer purchases.
    /// </summary>
    /// <remarks>
    /// Normal receipts are the most common transaction type for retail sales. They include
    /// itemized purchases, tax calculations, and payment information. Customer details are
    /// optional unless required by local regulations for high-value transactions.
    /// </remarks>
    Normal = 0,

    /// <summary>
    /// A simplified invoice for business-to-business transactions.
    /// </summary>
    /// <remarks>
    /// Invoices require customer information including name, address, and tax identification.
    /// They provide detailed tax breakdowns and product codes necessary for business accounting
    /// and VAT reporting. Invoices typically have higher monetary limits than normal receipts.
    /// </remarks>
    Invoice = 1,

    /// <summary>
    /// A receipt for recycling or environmental fee transactions.
    /// </summary>
    /// <remarks>
    /// Recycle receipts handle environmental fees and recycling deposits that may have
    /// special tax treatment or reporting requirements. These transactions often involve
    /// container deposits or environmental protection surcharges.
    /// </remarks>
    Recycle = 2,

    /// <summary>
    /// A return receipt for merchandise being returned to the store.
    /// </summary>
    /// <remarks>
    /// Return receipts document merchandise returns and typically result in refunds or store credit.
    /// They may reference original purchase documents and require return reason codes for
    /// inventory and accounting purposes. Return processing may have time limits and restrictions.
    /// </remarks>
    Return = 3,

    /// <summary>
    /// A storno (cancellation/correction) receipt for previously issued documents.
    /// </summary>
    /// <remarks>
    /// Storno receipts are used to cancel or correct previously issued fiscal documents.
    /// They must reference the original document and provide justification for the cancellation.
    /// Storno operations are typically restricted to the same fiscal day as the original transaction.
    /// </remarks>
    Storno = 4,

    /// <summary>
    /// A receipt for pharmaceutical or medical product sales.
    /// </summary>
    /// <remarks>
    /// Pharmacy receipts may have special regulatory requirements, prescription tracking,
    /// or insurance integration. They often include additional product identification codes
    /// and may require patient or prescription information for controlled substances.
    /// </remarks>
    Pharmacy = 5,

    /// <summary>
    /// A receipt for restaurant or food service transactions.
    /// </summary>
    /// <remarks>
    /// Restaurant receipts may include table numbers, service charges, tips, or special
    /// tax treatments for food and beverage items. They might integrate with point-of-sale
    /// systems for order management and kitchen communication.
    /// </remarks>
    Restaurant = 6,

    /// <summary>
    /// A free-form storno receipt with flexible cancellation rules.
    /// </summary>
    /// <remarks>
    /// Free storno receipts provide more flexibility in cancellation procedures than
    /// standard storno receipts. They may allow cancellations across fiscal days or
    /// have different documentation requirements based on local regulations.
    /// </remarks>
    FreeStrono = 7,

    /// <summary>
    /// A free-form return receipt with flexible return policies.
    /// </summary>
    /// <remarks>
    /// Free return receipts allow more flexible return processing than standard returns.
    /// They may not require original receipt references or may have extended return periods
    /// for customer service or promotional purposes.
    /// </remarks>
    FreeReturn = 8,

    /// <summary>
    /// A cash management receipt for drawer operations.
    /// </summary>
    /// <remarks>
    /// Cash receipts document cash drawer operations such as deposits, withdrawals, or
    /// cash exchanges. They're used for internal accounting and cash reconciliation
    /// rather than customer sales transactions.
    /// </remarks>
    Cash = 9,

    /// <summary>
    /// A non-fiscal document that doesn't affect sales totals or tax calculations.
    /// </summary>
    /// <remarks>
    /// Non-fiscal receipts are used for promotional materials, information notices, or
    /// customer communications that don't involve monetary transactions. They don't impact
    /// sales reporting or tax calculations but may be tracked for operational purposes.
    /// </remarks>
    NonFiscal = 10,

    /// <summary>
    /// An empties ticket for container deposit returns.
    /// </summary>
    /// <remarks>
    /// Empties tickets document the return of deposit containers such as bottles or crates.
    /// They typically have negative monetary values representing refunds owed to customers
    /// and may integrate with inventory management for container tracking.
    /// </remarks>
    EmptiesTicket = 11,
}

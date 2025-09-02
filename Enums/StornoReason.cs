namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the valid reasons for issuing storno (cancellation/correction) receipts,
/// providing standardized categorization for document cancellation procedures.
/// </summary>
/// <remarks>
/// Storno reasons ensure proper documentation and audit trails for cancelled or corrected
/// transactions. Each reason code provides specific context about why a transaction was
/// cancelled, which is important for compliance reporting, business analysis, and audit
/// procedures. The reason codes help distinguish between different types of cancellations
/// and may affect how the cancellation is processed and reported.
/// </remarks>
public enum StornoReason
{
    /// <summary>
    /// General cancellation reason when no specific category applies.
    /// </summary>
    /// <remarks>
    /// Used for cancellations that don't fit into the predefined categories or when
    /// a general cancellation is appropriate without specific classification. This
    /// provides flexibility for unusual circumstances while maintaining audit compliance.
    /// </remarks>
    Other = 0,

    /// <summary>
    /// Customer cancelled the purchase transaction before completion.
    /// </summary>
    /// <remarks>
    /// Used when customers decide not to proceed with their purchase for any reason,
    /// such as changing their mind, insufficient funds, or deciding against the items.
    /// This is a common reason for retail transaction cancellations and helps track
    /// customer behavior and transaction patterns.
    /// </remarks>
    PurchaseCanceled = 1,

    /// <summary>
    /// Cancellation due to incorrect data entry or input errors.
    /// </summary>
    /// <remarks>
    /// Used when transactions need to be cancelled because of operator errors in data
    /// entry, such as wrong quantities, incorrect prices, wrong items scanned, or
    /// other input mistakes that require transaction correction. This helps identify
    /// training needs and system usability issues.
    /// </remarks>
    BadInput = 2,

    /// <summary>
    /// Cancellation due to payment processing problems or invalid payment methods.
    /// </summary>
    /// <remarks>
    /// Used when payment processing fails, payment methods are declined, cards are
    /// rejected, or other payment-related issues prevent transaction completion.
    /// This helps identify payment system problems and customer payment issues.
    /// </remarks>
    BadPayment = 3,

    /// <summary>
    /// Cancellation because requested products are not available in inventory.
    /// </summary>
    /// <remarks>
    /// Used when items in the transaction are discovered to be out of stock, discontinued,
    /// or otherwise unavailable after the transaction has been started. This helps track
    /// inventory accuracy issues and customer demand for unavailable products.
    /// </remarks>
    ProductOutOfStock = 4,

    /// <summary>
    /// Cancellation due to incorrect document type selection or processing.
    /// </summary>
    /// <remarks>
    /// Used when the wrong type of fiscal document was started (e.g., receipt instead
    /// of invoice, or invoice instead of receipt) and needs to be cancelled to start
    /// the correct document type. This helps identify process confusion and training needs.
    /// </remarks>
    BadDocumentType = 5,

    /// <summary>
    /// Customer aborted the payment process before completion.
    /// </summary>
    /// <remarks>
    /// Used specifically when customers start the payment process but then decide to
    /// abort before completing payment, such as walking away during card processing
    /// or deciding not to pay after seeing the total. This is distinct from general
    /// purchase cancellation as it occurs during the payment phase.
    /// </remarks>
    AbortPaying = 6,

    /// <summary>
    /// Cancellation due to incorrect or invalid customer information.
    /// </summary>
    /// <remarks>
    /// Used when customer data required for invoices or special transactions is found
    /// to be incorrect, incomplete, or invalid, requiring transaction cancellation to
    /// obtain proper customer information. This is particularly relevant for invoice
    /// transactions requiring accurate business customer data.
    /// </remarks>
    BadCustomerData = 7,

    /// <summary>
    /// Cancellation of test transactions used for system testing or training purposes.
    /// </summary>
    /// <remarks>
    /// Used when transactions are created for testing system functionality, training
    /// purposes, or demonstration activities and need to be cancelled to avoid affecting
    /// actual business totals and reporting. This helps maintain clean business data
    /// while allowing necessary testing activities.
    /// </remarks>
    TestPurchases = 8,
}

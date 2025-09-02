using CronisNext.FiscalPrinter.Enums;
using CronisNext.FiscalPrinter.Models;
using FluentResults;

namespace CronisNext.FiscalPrinter.Interfaces;

/// <summary>
/// Provides a comprehensive interface for fiscal printer operations including receipt printing,
/// invoice generation, cash management, and display control for point-of-sale systems.
/// </summary>
/// <remarks>
/// This interface abstracts fiscal printer functionality to support various hardware implementations
/// while ensuring compliance with fiscal regulations. All operations return FluentResults to provide
/// detailed error handling and success confirmation.
/// </remarks>
public interface IFiscalPrinterService
{
    /// <summary>
    /// Configures the fiscal printer with essential operational parameters including receipt limits,
    /// currency rates, and custom payment methods.
    /// </summary>
    /// <param name="properties">Configuration properties containing limits, rates, and payment settings</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the configuration operation</returns>
    /// <remarks>
    /// This method must be called when the fiscal day is closed. It configures receipt and invoice
    /// total limits, Euro exchange rates, custom foreign currencies, and custom payment method names.
    /// The operation will fail if attempted during an open fiscal day.
    /// </remarks>
    ValueTask<Result> SetPropertiesAsync(Properties properties, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the maximum total amount allowed for a single receipt transaction.
    /// </summary>
    /// <param name="receiptLimit">Maximum allowed receipt total amount</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of setting the receipt limit</returns>
    /// <remarks>
    /// This limit helps prevent accidentally large transactions and ensures compliance with
    /// fiscal regulations. Can only be set when the fiscal day is closed.
    /// </remarks>
    ValueTask<Result> SetReceiptLimitAsync(decimal receiptLimit, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the maximum total amount allowed for a single invoice transaction.
    /// </summary>
    /// <param name="invoiceLimit">Maximum allowed invoice total amount</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of setting the invoice limit</returns>
    /// <remarks>
    /// Invoice limits are typically higher than receipt limits and support business-to-business
    /// transactions. Can only be set when the fiscal day is closed.
    /// </remarks>
    ValueTask<Result> SetInvoiceLimitAsync(decimal invoiceLimit, CancellationToken cancellationToken = default);

    /// <summary>
    /// Configures the Euro to local currency exchange rate for foreign currency transactions.
    /// </summary>
    /// <param name="euroRate">Exchange rate from Euro to local currency</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of setting the Euro rate</returns>
    /// <remarks>
    /// This rate is used for Euro-denominated payments and must comply with official exchange
    /// rate regulations. Can only be set when the fiscal day is closed.
    /// </remarks>
    ValueTask<Result> SetEuroRateAsync(decimal euroRate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Configures custom foreign currencies and their exchange rates for multi-currency operations.
    /// </summary>
    /// <param name="currencies">List of custom currencies with their exchange rates</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of setting custom currencies</returns>
    /// <remarks>
    /// Supports up to 5 custom foreign currencies beyond the standard Euro. Each currency
    /// requires a name and exchange rate. Can only be set when the fiscal day is closed.
    /// </remarks>
    ValueTask<Result> SetCustomForeignCurrencyAsync(IList<Currency> currencies, CancellationToken cancellationToken = default);

    /// <summary>
    /// Opens a new fiscal receipt transaction, preparing the printer for item sales.
    /// </summary>
    /// <param name="receiptNo">Optional pre-assigned receipt number for validation</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the print response with receipt details, or failure information</returns>
    /// <remarks>
    /// This operation starts a new fiscal receipt transaction. The fiscal day must be open,
    /// and no other receipt or invoice can be currently open. Returns the assigned receipt number
    /// and printer status information.
    /// </remarks>
    ValueTask<Result<PrintResponse>> PrintReceiptOpenAsync(string? receiptNo, CancellationToken cancellationToken = default);

    /// <summary>
    /// Completes and prints a fiscal receipt with all items, discounts, and payments.
    /// </summary>
    /// <param name="receipt">Complete receipt data including items, payments, and totals</param>
    /// <param name="receiptNo">Optional receipt number for validation</param>
    /// <param name="canceled">Whether to cancel the receipt instead of completing it</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the final receipt details, or failure information</returns>
    /// <remarks>
    /// Processes all receipt items, applies discounts, validates payments, and prints the final
    /// receipt. The receipt must have been previously opened. If canceled is true, the receipt
    /// is cancelled instead of completed.
    /// </remarks>
    ValueTask<Result<PrintResponse>> PrintReceiptAsync(Receipt receipt, string? receiptNo, bool canceled = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels the currently open receipt transaction without printing.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the cancellation</returns>
    /// <remarks>
    /// Use this method to abort a receipt transaction that has been opened but not yet completed.
    /// This is useful for handling customer cancellations or transaction errors.
    /// </remarks>
    ValueTask<Result> ReceiptCancelAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Opens a new simplified invoice transaction for business customers.
    /// </summary>
    /// <param name="receiptNo">Optional pre-assigned receipt number for validation</param>
    /// <param name="customer">Customer information required for invoice generation</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the invoice details, or failure information</returns>
    /// <remarks>
    /// Simplified invoices require customer information and provide tax-compliant documentation
    /// for business transactions. Returns both receipt and invoice numbers for tracking.
    /// </remarks>
    ValueTask<Result<PrintResponse>> PrintInvoiceOpenAsync(string? receiptNo, Customer customer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Completes and prints a simplified invoice with all items, discounts, and payments.
    /// </summary>
    /// <param name="invoice">Complete invoice data including items, customer, and payments</param>
    /// <param name="receiptNo">Optional receipt number for validation</param>
    /// <param name="canceled">Whether to cancel the invoice instead of completing it</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the final invoice details, or failure information</returns>
    /// <remarks>
    /// Processes all invoice items, applies discounts, validates payments, and prints the final
    /// invoice with customer details. Includes product codes for business accounting requirements.
    /// </remarks>
    ValueTask<Result<PrintResponse>> PrintInvoiceAsync(Invoice invoice, string? receiptNo, bool canceled = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels the currently open invoice transaction without printing.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the cancellation</returns>
    /// <remarks>
    /// Use this method to abort an invoice transaction that has been opened but not yet completed.
    /// This is useful for handling customer cancellations or transaction errors.
    /// </remarks>
    ValueTask<Result> InvoiceCancelAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Opens a new empties ticket transaction for container deposit returns.
    /// </summary>
    /// <param name="receiptNo">Optional pre-assigned receipt number for validation</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the empties ticket details, or failure information</returns>
    /// <remarks>
    /// Empties tickets are used for returning deposit containers and bottles.
    /// They typically have negative values representing money owed to the customer.
    /// </remarks>
    ValueTask<Result<PrintResponse>> PrintEmptiesTicketOpenAsync(string? receiptNo, CancellationToken cancellationToken = default);

    /// <summary>
    /// Completes and prints an empties ticket for container deposit returns.
    /// </summary>
    /// <param name="ticket">Complete empties ticket data including items and totals</param>
    /// <param name="receiptNo">Optional receipt number for validation</param>
    /// <param name="canceled">Whether to cancel the ticket instead of completing it</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the final ticket details, or failure information</returns>
    /// <remarks>
    /// Processes empties items with negative values representing deposit refunds.
    /// The total amount is typically negative, indicating money owed to the customer.
    /// </remarks>
    ValueTask<Result<PrintResponse>> PrintEmptiesTicketAsync(EmptiesTicket ticket, string? receiptNo, bool canceled = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels the currently open empties ticket transaction without printing.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the cancellation</returns>
    /// <remarks>
    /// Use this method to abort an empties ticket transaction that has been opened but not yet completed.
    /// </remarks>
    ValueTask<Result> EmptiesTicketCancelAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Prints a non-fiscal document such as promotional material or information notices.
    /// </summary>
    /// <param name="nonFiscal">Non-fiscal document content including text lines and optional barcode</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the non-fiscal printing</returns>
    /// <remarks>
    /// Non-fiscal documents don't affect sales totals or tax calculations. They're used for
    /// promotional materials, information notices, or customer communications.
    /// </remarks>
    ValueTask<Result<PrintResponse>> PrintNonFiscalAsync(NonFiscal nonFiscal, CancellationToken cancellationToken = default);

    /// <summary>
    /// Records cash deposits into the register drawer with fiscal documentation.
    /// </summary>
    /// <param name="tenders">Payment methods and amounts being deposited</param>
    /// <param name="note">Optional note describing the purpose of the deposit</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the receipt number for the cash-in operation</returns>
    /// <remarks>
    /// Used for daily opening amounts, cash deposits, or restocking the drawer.
    /// If the fiscal day is closed, this operation will automatically open the day.
    /// </remarks>
    ValueTask<Result<string>> PayInReceiptAsync(IList<Tender> tenders, string? note, CancellationToken cancellationToken = default);

    /// <summary>
    /// Records custom cash deposits with specific deposit types and documentation.
    /// </summary>
    /// <param name="otherPayin">Detailed pay-in information including type and payment methods</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the receipt number for the pay-in operation</returns>
    /// <remarks>
    /// Supports various pay-in types such as change money, tips, or other custom categories.
    /// Requires the fiscal day to be open.
    /// </remarks>
    ValueTask<Result<string>> OtherPayInReceiptAsync(OtherPayIn otherPayin, CancellationToken cancellationToken = default);

    /// <summary>
    /// Records cash withdrawals from the register drawer with fiscal documentation.
    /// </summary>
    /// <param name="tenders">Payment methods and amounts being withdrawn</param>
    /// <param name="note">Optional note describing the purpose of the withdrawal</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the receipt number for the cash-out operation</returns>
    /// <remarks>
    /// Used for skimming excess cash, making deposits, or other cash removal needs.
    /// Requires the fiscal day to be open and no other transactions to be in progress.
    /// </remarks>
    ValueTask<Result<string>> PayOutReceiptAsync(IEnumerable<Tender> tenders, string? note, CancellationToken cancellationToken = default);

    /// <summary>
    /// Records custom cash withdrawals with specific withdrawal types and documentation.
    /// </summary>
    /// <param name="otherPayout">Detailed pay-out information including type and payment methods</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the receipt number for the pay-out operation</returns>
    /// <remarks>
    /// Supports various pay-out types such as skimming, tips payout, or other custom categories.
    /// Requires the fiscal day to be open.
    /// </remarks>
    ValueTask<Result<string>> OtherPayOutReceiptAsync(OtherPayOut otherPayout, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves current cash drawer contents and payment method totals.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the list of payment methods and their current amounts</returns>
    /// <remarks>
    /// Provides real-time cash drawer information for reconciliation and management purposes.
    /// Includes all payment methods and their accumulated amounts since day opening.
    /// </remarks>
    ValueTask<Result<List<PaymentResponse>>> ReadXDataAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Prints a storno (cancellation/correction) receipt for previously issued documents.
    /// </summary>
    /// <param name="stornoReceipt">Storno details including original document reference and customer information</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the storno receipt details, or failure information</returns>
    /// <remarks>
    /// Storno receipts are used to cancel or correct previously issued receipts or invoices.
    /// Requires reference to the original document and reason for cancellation.
    /// </remarks>
    ValueTask<Result<PrintResponse>> PrintStornoAsync(StornoReceipt stornoReceipt, CancellationToken cancellationToken = default);

    /// <summary>
    /// Prints a receipt documenting a change in payment method for a transaction.
    /// </summary>
    /// <param name="changePayment">Payment change details including original and new payment methods</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the change payment receipt details, or failure information</returns>
    /// <remarks>
    /// Used when customers need to change their payment method after a transaction,
    /// such as switching from card to cash or vice versa.
    /// </remarks>
    ValueTask<Result<PrintResponse>> PrintChangePaymentReceiptCommandAsync(ChangePayment changePayment, CancellationToken cancellationToken = default);

    /// <summary>
    /// Prints a return receipt for merchandise being returned by customers.
    /// </summary>
    /// <param name="returnReceipt">Return details including items, customer, and original purchase information</param>
    /// <param name="receiptNo">Optional receipt number for validation</param>
    /// <param name="canceled">Whether to cancel the return instead of completing it</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the return receipt details, or failure information</returns>
    /// <remarks>
    /// Return receipts document merchandise returns and typically result in refunds to customers.
    /// May reference original purchase documents and include customer information.
    /// </remarks>
    ValueTask<Result<PrintResponse>> PrintReturnAsync(ReturnReceipt returnReceipt, string? receiptNo, bool canceled = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Closes the fiscal day by printing a Z-report and finalizing all daily transactions.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the day closing operation</returns>
    /// <remarks>
    /// The Z-report summarizes all daily transactions and must be printed to close the fiscal day.
    /// After closing, no new transactions can be processed until the next day is opened.
    /// </remarks>
    ValueTask<Result> PrintCloseDayAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Prints an X-report showing current daily totals without closing the fiscal day.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the report printing</returns>
    /// <remarks>
    /// X-reports provide interim daily totals for management purposes without affecting
    /// the fiscal day status. Multiple X-reports can be printed throughout the day.
    /// </remarks>
    ValueTask<Result> PrintCashierReportAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Opens a new return receipt transaction for merchandise returns.
    /// </summary>
    /// <param name="receiptNo">Optional pre-assigned receipt number for validation</param>
    /// <param name="returnReceipt">Return receipt details including customer and original document information</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the return receipt details, or failure information</returns>
    /// <remarks>
    /// This operation starts a new return transaction. The fiscal day must be open,
    /// and no other receipt or invoice can be currently open.
    /// </remarks>
    ValueTask<Result<PrintResponse>> PrintReturnOpenAsync(string? receiptNo, ReturnReceipt returnReceipt, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels the currently open non-fiscal document transaction without printing.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the cancellation</returns>
    /// <remarks>
    /// Use this method to abort a non-fiscal document transaction that has been started
    /// but not yet completed.
    /// </remarks>
    ValueTask<Result> NonFiscalCancelAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the content of a previously printed fiscal document.
    /// </summary>
    /// <param name="readReceipt">Document identification including receipt mode, closure, and receipt numbers</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the document content as a string, or failure information</returns>
    /// <remarks>
    /// Allows reading historical documents for reprinting, verification, or audit purposes.
    /// Returns the complete document content in text format.
    /// </remarks>
    ValueTask<Result<string>> ReadReceiptCommandAsync(ReadReceipt readReceipt, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks whether a specific receipt was cancelled during printing.
    /// </summary>
    /// <param name="readReceipt">Document identification including receipt mode, closure, and receipt numbers</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing true if the receipt was cancelled, false if completed successfully</returns>
    /// <remarks>
    /// Used to verify the status of receipts that may have been interrupted during printing
    /// due to paper jams, power failures, or other technical issues.
    /// </remarks>
    ValueTask<Result<bool>> IsReceiptCanceledAsync(ReadReceipt readReceipt, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of currently configured custom payment method names.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the list of custom payment method names</returns>
    /// <remarks>
    /// Custom payment methods allow businesses to define their own payment types
    /// beyond the standard cash, card, and currency options.
    /// </remarks>
    ValueTask<Result<List<string>>> ReadCustomPaymentNameAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Configures custom payment method names for specialized payment types.
    /// </summary>
    /// <param name="customPaymentNames">List of custom payment method names (maximum 8)</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of setting custom payment names</returns>
    /// <remarks>
    /// The first payment method must be "AFR" and each name cannot exceed 13 characters.
    /// Can only be configured when the fiscal day is closed.
    /// </remarks>
    ValueTask<Result> WriteCustomPaymentNameAsync(IList<string> customPaymentNames, CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a product item on the customer-facing display screen.
    /// </summary>
    /// <param name="receiptItem">Item details including name, quantity, price, and display duration</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Shows item information to customers during checkout, enhancing transparency
    /// and allowing customers to verify their purchases in real-time.
    /// </remarks>
    ValueTask<Result> DisplayItemAsync(DisplayItem receiptItem, CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays the total amount on the customer-facing display screen.
    /// </summary>
    /// <param name="receiptTotal">Total amount details including value and currency information</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Shows the calculated total to customers, allowing them to verify the final
    /// amount before payment processing.
    /// </remarks>
    ValueTask<Result> DisplayTotalAsync(DisplayTotal receiptTotal, CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays the amount due for payment on the customer-facing display screen.
    /// </summary>
    /// <param name="payable">Payable amount details including value and currency information</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Shows the amount that needs to be paid, which may differ from the total
    /// if partial payments have been made or discounts applied.
    /// </remarks>
    ValueTask<Result> DisplayPayableAsync(DisplayTotal payable, CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays payment information on the customer-facing display screen.
    /// </summary>
    /// <param name="receiptPayment">Payment details including method, amount, and remaining balance</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Shows payment progress to customers, including the payment method used,
    /// amount paid, and any remaining balance due.
    /// </remarks>
    ValueTask<Result> DisplayPaymentAsync(DisplayPayment receiptPayment, CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays change amount to be returned on the customer-facing display screen.
    /// </summary>
    /// <param name="receiptPayment">Change amount details including value and currency information</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Shows customers the change amount they will receive when overpayment has occurred,
    /// providing transparency in the transaction completion.
    /// </remarks>
    ValueTask<Result> DisplayPaymentBackAsync(DisplayPaymentBack receiptPayment, CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays custom text messages on the customer-facing display screen.
    /// </summary>
    /// <param name="displayText">Text content for both display lines with timing information</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Allows displaying custom messages to customers, such as promotional information,
    /// instructions, or status updates during the checkout process.
    /// </remarks>
    ValueTask<Result> DisplayTextAsync(DisplayText displayText, CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a "register closed" message on the customer-facing display screen.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Shows customers that the register is currently closed and unavailable for transactions,
    /// typically used during breaks or end-of-day procedures.
    /// </remarks>
    ValueTask<Result> DisplayCloseStateAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a welcome message on the customer-facing display screen.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Shows a friendly welcome message to customers when the register is open
    /// and ready for transactions.
    /// </remarks>
    ValueTask<Result> DisplayOpenStateAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a farewell message on the customer-facing display screen.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Shows a "thank you" message to customers after transaction completion,
    /// enhancing customer experience and encouraging return visits.
    /// </remarks>
    ValueTask<Result> DisplayGoodbyeMessageAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a "register locked" message on the customer-facing display screen.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Indicates that the register is temporarily locked, typically due to security
    /// procedures or system maintenance.
    /// </remarks>
    ValueTask<Result> DisplayRegisterLockedAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a "please wait" message on the customer-facing display screen.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Informs customers that processing is in progress and they should wait,
    /// typically during payment processing or system operations.
    /// </remarks>
    ValueTask<Result> DisplayWaitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a customer confirmation message on the customer-facing display screen.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Confirms successful customer-related operations, such as adding customer
    /// information for invoice generation.
    /// </remarks>
    ValueTask<Result> DisplayCustomerOKAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Clears the customer-facing display screen, removing all text.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Removes all content from the display, providing a clean slate for new information
    /// or returning to the default state.
    /// </remarks>
    ValueTask<Result> ClearDisplayAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays formatted text on the customer-facing display screen with automatic line wrapping.
    /// </summary>
    /// <param name="displayText">Text content to display</param>
    /// <param name="time">Display duration in milliseconds (default: 1000000)</param>
    /// <param name="lineBreakOnSpace">Whether to break lines at word boundaries (default: false)</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Automatically formats text across two display lines with options for intelligent
    /// word wrapping and custom display duration.
    /// </remarks>
    ValueTask<Result> DisplayTextAsync(string displayText, int time = 1000000, bool lineBreakOnSpace = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Opens the cash drawer attached to the fiscal printer.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the drawer opening operation</returns>
    /// <remarks>
    /// Electronically triggers the cash drawer to open, typically used for cash transactions
    /// or manual cash management operations.
    /// </remarks>
    ValueTask<Result> OpenDrawerAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves fiscal report data for analysis and compliance purposes.
    /// </summary>
    /// <param name="ReadReportType">Type of report to retrieve (daily, monthly, etc.)</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the report data as a string, or failure information</returns>
    /// <remarks>
    /// Provides access to various fiscal reports required for compliance, auditing,
    /// and business analysis. Report types vary based on fiscal regulations.
    /// </remarks>
    ValueTask<Result<string>> ReadReportPrintDataAsync(ReadReportType ReadReportType, CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays discount information on the customer-facing display screen.
    /// </summary>
    /// <param name="receiptDiscount">Discount details including amount, percentage, and currency</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the display operation</returns>
    /// <remarks>
    /// Shows applied discounts to customers, providing transparency about savings
    /// and promotional benefits being applied to their purchase.
    /// </remarks>
    ValueTask<Result> DisplayDiscountAsync(DisplayDiscount receiptDiscount, CancellationToken cancellationToken = default);

    /// <summary>
    /// Reopens the fiscal day after closing, typically for emergency transactions.
    /// </summary>
    /// <param name="tenders">Opening cash amounts by payment method</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing the receipt number for the day reopening operation</returns>
    /// <remarks>
    /// This operation first closes the current day (if open) and then immediately
    /// opens a new fiscal day. Use sparingly and only when required by business needs.
    /// </remarks>
    ValueTask<Result<string>> ReOpenDayAsync(IList<Tender> tenders, CancellationToken cancellationToken = default);

    /// <summary>
    /// Refreshes the printer status information and updates the printer context.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result indicating success or failure of the status refresh operation</returns>
    /// <remarks>
    /// Updates internal status information including paper levels, cover status,
    /// display connectivity, and fiscal day state for real-time monitoring.
    /// </remarks>
    ValueTask<Result> RefreshStatusAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Verifies whether a specific document was successfully printed and completed.
    /// </summary>
    /// <param name="readReceipt">Document identification including receipt mode, closure, and receipt numbers</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>A result containing true if the document was successfully printed, false if cancelled or failed</returns>
    /// <remarks>
    /// Used to verify document completion status after printing operations,
    /// especially important for ensuring fiscal compliance and audit trails.
    /// </remarks>
    ValueTask<Result<bool>> IsDocumentSuccessfullyPrintedAsync(ReadReceipt readReceipt, CancellationToken cancellationToken = default);
}

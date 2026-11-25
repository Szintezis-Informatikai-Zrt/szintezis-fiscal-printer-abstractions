using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Models;

public sealed class StornoDocument
{
    public required string ApNumber { get; set; }

    public DateOnly ReceiptDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    public OriginalDocumentType OriginalDocumentType { get; set; }

    public required string ReceiptNo { get; set; }

    public string StornoReason { get; set; } = "Other";

    public List<Tender> Tenders { get; set; } = [];

    public required Customer Customer { get; set; }

    public List<NonFiscalLine> NonFiscalLines { get; set; } = [];

    public string? StornoApNumber { get; set; }

    public string? StornoReceiptNo { get; set; }
}

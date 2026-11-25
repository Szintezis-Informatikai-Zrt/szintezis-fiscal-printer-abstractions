namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Indicates that the configured fiscal printer cannot reprint the last receipt.
/// </summary>
public sealed class ReceiptReprintNotSupportedError : ErrorBase
{
    /// <inheritdoc />
    public override string Message { get; } = "The configured fiscal printer does not support receipt reprinting.";

    /// <inheritdoc />
    public override string ErrorCode { get; } = nameof(ReceiptReprintNotSupportedError);
}

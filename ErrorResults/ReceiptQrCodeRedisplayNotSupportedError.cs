namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Indicates that the configured fiscal printer cannot redisplay the receipt's QR code.
/// </summary>
public sealed class ReceiptQrCodeRedisplayNotSupportedError : ErrorBase
{
    /// <inheritdoc />
    public override string Message { get; } = "The configured fiscal printer does not support receipt QR code redisplay.";

    /// <inheritdoc />
    public override string ErrorCode { get; } = nameof(ReceiptQrCodeRedisplayNotSupportedError);
}

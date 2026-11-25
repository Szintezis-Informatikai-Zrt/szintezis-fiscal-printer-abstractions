using CronisNext.FiscalPrinter.Enums;

namespace CronisNext.FiscalPrinter.Events;

public sealed record DocumentOutputTypeChangedEvent(DocumentOutputType OutputType);

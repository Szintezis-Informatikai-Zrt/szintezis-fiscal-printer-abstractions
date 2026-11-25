# CronisNext.FiscalPrinter.Abstractions

Source of the `CronisNext.FiscalPrinter.Abstractions` package: the interfaces, models, enums, errors and events of the Celeste Fiscal Printer Library, which fiscal printer implementations implement and applications code against (`IFiscalPrinterService`, `IPrinterContext`, `IPrinterInitializationPlugin`).

Documentation: **[wiki](https://github.com/Szintezis-Informatikai-Zrt/szintezis-fiscal-printer-abstractions/wiki)**. Upgrading from an earlier version: see the [Migration Guide](https://github.com/Szintezis-Informatikai-Zrt/szintezis-fiscal-printer-abstractions/wiki/Migration-Guide).

## Packages

Published to GitHub Packages (`https://nuget.pkg.github.com/Szintezis-Informatikai-Zrt/index.json`, a personal access token with `read:packages` is required):

| Package | Contents |
|---|---|
| `CronisNext.FiscalPrinter.Abstractions` | This source. `.nupkg` with XML docs. |
| `Szintezis.FisCat.Aee.eFP` | Implementation for FisCat AEE printers via the eFP endpoint (binary only). |
| `Szintezis.FisCat.Aee` | Legacy FisCat AEE implementation (binary only). |

Target framework: `net10.0`. Dependency: [FluentResults](https://www.nuget.org/packages/FluentResults) 4.0.0 (the enum source generator is build-time only).

## Building

```
dotnet build -c Release
```

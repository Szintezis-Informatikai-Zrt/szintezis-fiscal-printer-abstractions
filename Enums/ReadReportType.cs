using System.ComponentModel.DataAnnotations;
using NetEscapades.EnumGenerators;

namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the different types of fiscal reports that can be retrieved from the fiscal printer
/// for business analysis, compliance reporting, and operational management purposes.
/// </summary>
/// <remarks>
/// Fiscal reports provide essential business intelligence and compliance documentation required
/// for tax authorities, business analysis, and operational management. Each report type serves
/// specific purposes and contains different categories of transaction and operational data.
/// Reports support both interim analysis (X-reports) and official closure procedures (Z-reports).
/// 
/// <para>
/// The Display attribute values represent the fiscal printer codes used internally for each report type,
/// enabling proper communication with fiscal hardware and ensuring compliance with fiscal protocols.
/// </para>
/// 
/// <para>
/// Reports serve multiple business and regulatory purposes:
/// <list type="bullet">
/// <item><description>Tax compliance and regulatory reporting requirements</description></item>
/// <item><description>Business performance analysis and operational insights</description></item>
/// <item><description>Financial auditing and accountability documentation</description></item>
/// <item><description>Daily operational management and decision support</description></item>
/// <item><description>Historical data analysis and trend identification</description></item>
/// </list>
/// </para>
/// </remarks>
[EnumExtensions]
public enum ReadReportType
{
    /// <summary>
    /// Interim tax report showing current tax category totals without closing the fiscal day.
    /// </summary>
    /// <remarks>
    /// X-Tax reports provide current tax totals by VAT category for operational analysis and
    /// interim compliance checking. These reports show accumulated tax amounts and can be
    /// generated multiple times throughout the day without affecting the fiscal day status.
    /// Useful for tax planning and compliance monitoring.
    /// </remarks>
    [Display(Name = "T")]
    XTaxReport,

    /// <summary>
    /// Interim collector report showing payment method and cashier totals without closing the fiscal day.
    /// </summary>
    /// <remarks>
    /// X-Collector reports provide current totals by payment method and cashier for cash management
    /// and operational oversight. These reports help track payment method performance, cashier
    /// productivity, and cash flow patterns throughout the day without affecting fiscal status.
    /// </remarks>
    [Display(Name = "C")]
    XCollectorReport,

    /// <summary>
    /// Interim daily summary report showing overall transaction totals without closing the fiscal day.
    /// </summary>
    /// <remarks>
    /// X-Daily reports provide comprehensive daily transaction summaries including sales totals,
    /// transaction counts, and key performance indicators. These interim reports support operational
    /// decision-making and performance monitoring throughout the business day without affecting
    /// the fiscal day closure requirements.
    /// </remarks>
    [Display(Name = "X")]
    XDailyReport,

    /// <summary>
    /// Interim department report showing sales totals by business department or category without closing the fiscal day.
    /// </summary>
    /// <remarks>
    /// X-Department reports provide sales analysis by business departments or product categories,
    /// enabling operational managers to track department performance and make informed business
    /// decisions. These reports support inventory management and sales strategy without affecting
    /// fiscal day status.
    /// </remarks>
    [Display(Name = "D")]
    XDepartReport,

    /// <summary>
    /// Interim PLU (Price Look-Up) report showing individual product sales performance without closing the fiscal day.
    /// </summary>
    /// <remarks>
    /// X-PLU reports provide detailed product-level sales analysis including quantities sold,
    /// revenue generated, and individual product performance metrics. These reports support
    /// inventory management, product performance analysis, and purchasing decisions without
    /// affecting the fiscal day closure procedures.
    /// </remarks>
    [Display(Name = "P")]
    XPluReport,

    /// <summary>
    /// Interim clerk report showing individual cashier performance and transaction totals without closing the fiscal day.
    /// </summary>
    /// <remarks>
    /// X-Clerk reports provide individual cashier performance metrics including transaction counts,
    /// sales totals, and operational statistics. These reports support staff management, performance
    /// evaluation, and operational oversight throughout the day without requiring fiscal day closure.
    /// </remarks>
    [Display(Name = "K")]
    XClerkReport,

    /// <summary>
    /// Official daily closure report that finalizes the fiscal day and provides comprehensive transaction summaries.
    /// </summary>
    /// <remarks>
    /// Z-Day Close reports are mandatory fiscal closure documents that finalize the business day
    /// and provide official transaction summaries required for tax compliance and regulatory reporting.
    /// This report closes the fiscal day, making it unavailable for new transactions until the next
    /// day is opened. Z-reports are essential for audit trails and tax authority compliance.
    /// </remarks>
    [Display(Name = "Z")]
    ZDayCloseReport,
}

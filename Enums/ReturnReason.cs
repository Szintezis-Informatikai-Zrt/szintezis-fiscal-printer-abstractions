namespace CronisNext.FiscalPrinter.Enums;

/// <summary>
/// Defines the valid reasons for processing merchandise returns, providing standardized categorization
/// for return transactions that helps with business analysis and customer service tracking.
/// </summary>
/// <remarks>
/// Return reasons provide essential business intelligence about why customers return merchandise,
/// enabling businesses to identify quality issues, improve customer satisfaction, and make informed
/// decisions about products, suppliers, and return policies. Proper categorization of return reasons
/// also supports warranty claims, supplier negotiations, and quality control processes.
/// 
/// <para>
/// Return reason tracking serves multiple business purposes:
/// <list type="bullet">
/// <item><description>Quality control and product improvement initiatives</description></item>
/// <item><description>Supplier performance evaluation and vendor management</description></item>
/// <item><description>Customer satisfaction analysis and service improvements</description></item>
/// <item><description>Return policy evaluation and optimization</description></item>
/// <item><description>Inventory management and demand forecasting adjustments</description></item>
/// <item><description>Financial analysis of return costs and impact</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// Accurate return reason classification helps businesses understand customer behavior,
/// product performance, and operational effectiveness while supporting continuous
/// improvement efforts across the organization.
/// </para>
/// </remarks>
public enum ReturnReason
{
    /// <summary>
    /// Returns due to defective, damaged, or poor-quality merchandise.
    /// </summary>
    /// <remarks>
    /// Faulty goods returns indicate quality issues with products, including manufacturing defects,
    /// damage during shipping or handling, products that don't meet quality expectations, or items
    /// that fail to function as advertised. This category is crucial for quality control analysis
    /// and may trigger supplier discussions, warranty claims, or product improvement initiatives.
    /// High rates of faulty goods returns may indicate systemic quality issues that need attention.
    /// </remarks>
    FaultyGoods = 1,

    /// <summary>
    /// Returns due to customer decision to cancel the purchase for personal reasons.
    /// </summary>
    /// <remarks>
    /// Purchase cancellations occur when customers change their mind about purchases for reasons
    /// unrelated to product quality, such as budget constraints, size or color preferences,
    /// duplicate purchases, or simply no longer needing the item. These returns are typically
    /// policy-driven and help businesses understand customer decision-making patterns and
    /// the effectiveness of their return policies in building customer confidence.
    /// </remarks>
    PurchaseCanceled = 2,

    /// <summary>
    /// Returns for reasons not covered by the other specific categories.
    /// </summary>
    /// <remarks>
    /// Other returns encompass various scenarios that don't fit standard categories, such as
    /// special circumstances, unusual situations, or business-specific return reasons that
    /// require individual consideration. This category provides flexibility for handling
    /// unique return situations while maintaining proper documentation and audit trails.
    /// Businesses may want to track subcategories within "Other" for more detailed analysis.
    /// </remarks>
    Other = 3,
}

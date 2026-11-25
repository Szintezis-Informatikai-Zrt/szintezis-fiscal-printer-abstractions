namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when the fiscal printer encounters paper-related problems that prevent printing operations.
/// </summary>
/// <remarks>
/// Paper errors encompass various paper-related conditions including out of paper, paper jams, incorrect paper loading,
/// or paper feed mechanism problems. These errors prevent any printing operations from completing successfully and
/// require physical intervention to resolve.
/// 
/// <para>
/// Common paper error conditions include:
/// <list type="bullet">
/// <item><description>Paper roll completely exhausted</description></item>
/// <item><description>Paper jam in the feed mechanism</description></item>
/// <item><description>Paper loaded incorrectly or not properly seated</description></item>
/// <item><description>Paper sensor malfunction detecting paper presence</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve paper errors, check the paper supply, clear any jams, ensure proper paper loading,
/// and verify that the paper path is clear of obstructions.
/// </para>
/// </remarks>
public sealed class PaperError : ErrorBase
{
    /// <summary>
    /// Gets the error message describing the paper-related problem.
    /// </summary>
    /// <value>
    /// A descriptive message indicating that paper-related issues are preventing printing operations.
    /// </value>
    public override string Message { get; } = "No paper.";

    /// <summary>
    /// Gets the unique error code that identifies this specific error type.
    /// </summary>
    /// <value>
    /// The error code "PaperError" used for programmatic error handling and logging.
    /// </value>
    public override string ErrorCode { get; } = nameof(PaperError);
}

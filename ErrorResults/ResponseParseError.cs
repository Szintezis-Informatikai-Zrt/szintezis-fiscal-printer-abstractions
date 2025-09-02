using FluentResults;

namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Represents an error that occurs when the system fails to parse or convert response data
/// from the fiscal printer into the expected data type or format.
/// </summary>
/// <remarks>
/// Response parse errors indicate problems with data conversion or interpretation when processing
/// responses from fiscal printer hardware. These errors typically occur when the printer returns
/// data in an unexpected format, when communication protocols change, or when data corruption
/// occurs during transmission. Parse errors can prevent proper operation and require careful
/// diagnosis to identify the root cause.
/// 
/// <para>
/// Common causes of response parse errors include:
/// <list type="bullet">
/// <item><description>Firmware version mismatches between printer and software expectations</description></item>
/// <item><description>Communication protocol errors or data transmission issues</description></item>
/// <item><description>Hardware malfunction causing corrupted response data</description></item>
/// <item><description>Encoding or character set mismatches in text responses</description></item>
/// <item><description>Unexpected response formats due to printer configuration changes</description></item>
/// <item><description>Network or connection issues causing partial data transmission</description></item>
/// </list>
/// </para>
/// 
/// <para>
/// To resolve parse errors, verify printer firmware compatibility, check communication settings,
/// validate data transmission integrity, and ensure that response format expectations match
/// the actual printer hardware and firmware configuration.
/// </para>
/// </remarks>
public sealed class ResponseParseError(string value, Type targetType)
    : Error($"Failed to parse '{value}' to {targetType.Name}.")
{
    /// <summary>
    /// Gets the original response value that failed to parse correctly.
    /// </summary>
    /// <value>
    /// The raw response data that could not be converted to the expected type.
    /// </value>
    /// <remarks>
    /// The original value provides diagnostic information about what data was received
    /// from the fiscal printer that could not be properly parsed. This information is
    /// essential for troubleshooting communication issues and identifying the source
    /// of parsing problems.
    /// </remarks>
    public string Value { get; } = value;

    /// <summary>
    /// Gets the target data type that the response value was expected to be converted to.
    /// </summary>
    /// <value>
    /// The .NET type that the parsing operation was attempting to create from the response data.
    /// </value>
    /// <remarks>
    /// The target type indicates what kind of data structure or value the system was expecting
    /// to create from the printer response. This information helps identify whether the issue
    /// is with the expected data format, the actual response format, or the conversion logic.
    /// </remarks>
    public Type TargetType { get; } = targetType;
}

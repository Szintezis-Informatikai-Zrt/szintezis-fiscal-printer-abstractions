using FluentResults;

namespace CronisNext.FiscalPrinter.ErrorResults;

/// <summary>
/// Provides a base class for all fiscal printer-specific error types, implementing consistent error handling
/// and metadata management for diagnostic and troubleshooting purposes.
/// </summary>
/// <remarks>
/// This abstract base class ensures that all fiscal printer errors include standardized error codes
/// and metadata for consistent error handling across the system. Error codes are automatically
/// added to the error metadata during construction, enabling structured error analysis and
/// automated error response procedures.
/// </remarks>
public abstract class ErrorBase : Error
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorBase"/> class and configures error metadata.
    /// </summary>
    /// <remarks>
    /// The constructor automatically adds the error code to the error metadata using the
    /// <see cref="ErrorCode"/> property. This ensures consistent error identification and
    /// enables structured error handling and logging throughout the application.
    /// </remarks>
    protected ErrorBase()
    {
        WithMetadata(nameof(ErrorCode), ErrorCode);
    }

    /// <summary>
    /// Gets the unique error code that identifies the specific type of fiscal printer error.
    /// </summary>
    /// <value>
    /// A string containing the error code that uniquely identifies this error type within
    /// the fiscal printer error hierarchy.
    /// </value>
    /// <remarks>
    /// Error codes provide a structured way to identify and categorize different error conditions.
    /// They enable automated error handling, user-friendly error messages, and integration
    /// with monitoring and diagnostic systems. Each derived error class must provide a unique
    /// error code that clearly identifies the error condition.
    /// </remarks>
    public abstract string ErrorCode { get; }
}

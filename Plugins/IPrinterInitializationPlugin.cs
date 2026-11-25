// <copyright file="IPrinterInitializationPlugin.cs" company="Szintézis Informatikai Kft.">
// Copyright (c) Szintézis Informatikai Kft. All rights reserved.
// </copyright>

using CronisNext.FiscalPrinter.Contexts;

namespace CronisNext.FiscalPrinter.Plugins;

/// <summary>
/// Defines a plugin that participates in the printer service initialization process.
/// Plugins are executed sequentially in order during initialization and have ongoing
/// access to the printer context for runtime status updates.
/// </summary>
/// <remarks>
/// <para>
/// Implementations of this interface are discovered automatically via dependency injection
/// and executed during <see cref="Interfaces.IFiscalPrinterService.InitializeAsync"/>. All registered plugins
/// must succeed for initialization to complete successfully.
/// </para>
/// <para>
/// Common use cases include:
/// <list type="bullet">
/// <item><description>Platform-specific driver initialization (e.g., Android AEE driver)</description></item>
/// <item><description>Hardware connection establishment</description></item>
/// <item><description>Pre-flight checks before printer operations</description></item>
/// </list>
/// </para>
/// <para>
/// Plugins should store a reference to the <see cref="IPrinterContext"/> provided during
/// initialization to enable runtime status updates such as pushing warnings or setting
/// error states when driver disconnections or other issues occur.
/// </para>
/// </remarks>
public interface IPrinterInitializationPlugin
{
    /// <summary>
    /// Gets the execution order for this plugin. Lower values execute first.
    /// </summary>
    /// <value>
    /// An integer indicating the relative execution order. Default implementations
    /// should use 0. Use negative values to execute before default, positive values
    /// to execute after.
    /// </value>
    int Order { get; }

    /// <summary>
    /// Initializes the plugin asynchronously. Called during printer context initialization.
    /// </summary>
    /// <param name="printerContext">
    /// The printer context instance. Plugins should store this reference for later use
    /// to push warnings or update printer state during runtime.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used to cancel the initialization operation.
    /// </param>
    /// <returns>
    /// A task that resolves to <c>true</c> if initialization succeeded, <c>false</c> otherwise.
    /// When <c>false</c> is returned, the printer context will be set to error state and
    /// subsequent plugins will not be executed.
    /// </returns>
    /// <remarks>
    /// If initialization fails, implementations should log appropriate error information
    /// and may call <see cref="IPrinterContext.PushWarning"/> to notify users of the failure reason.
    /// The printer context will automatically be set to error state when <c>false</c> is returned.
    /// </remarks>
    Task<bool> InitializeAsync(IPrinterContext printerContext, CancellationToken cancellationToken);
}

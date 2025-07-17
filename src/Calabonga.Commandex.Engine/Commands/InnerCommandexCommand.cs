using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Zones;
using Calabonga.OperationResults;
using System;
using System.Diagnostics;

namespace Calabonga.Commandex.Engine.Commands;

/// <summary>
/// Inner Commandex Command base class for command working as a UserControl (integrated in main windows)
/// </summary>
public abstract class InnerCommandexCommand<TZoneView, TZoneViewModel> : ICommandexCommand
    where TZoneView : IZoneView
    where TZoneViewModel : IZoneViewModel
{
    private readonly IZoneManager _zoneManager;

    protected InnerCommandexCommand(IZoneManager zoneManager)
    {
        _zoneManager = zoneManager;
    }

    /// <summary>
    /// Returns True/False indicating that's data from command will push to shell
    /// </summary>
    public virtual bool IsPushToShellEnabled
    {
        get
        {
            return false;
        }
    }

    /// <summary>
    /// Current command type
    /// </summary>
    public string TypeName
    {
        get
        {
            return GetType().Name;
        }
    }

    /// <summary>
    /// Author of the current command
    /// </summary>
    public abstract string CopyrightInfo { get; }

    /// <summary>
    /// Display name for the current command
    /// </summary>
    public abstract string DisplayName { get; }

    /// <summary>
    /// Description for the current command
    /// </summary>
    public abstract string Description { get; }

    /// <summary>
    /// Version for the current command
    /// </summary>
    public abstract string Version { get; }

    /// <summary>
    /// The name of the zone where current command will be opened
    /// </summary>
    private string ZoneName
    {
        get
        {
            return _zoneManager.GetDefaultZoneName();
        }
    }

    /// <summary>
    /// Internal dialog result
    /// </summary>
    protected IViewModel? Result { get; set; }

    public Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        if (string.IsNullOrEmpty(ZoneName))
        {
            return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Error(new ExecuteCommandexCommandException("ZoneName is not provided. Failed to find a zone.")));
        }

        var result = _zoneManager.ActivateZone<TZoneView, TZoneViewModel>(ZoneName);

        return Task.FromResult(result);
    }

    /// <summary>
    /// Returns result from command
    /// </summary>
    public virtual object? GetResult()
    {
        return IsPushToShellEnabled ? Result : null;
    }

    /// <summary>
    /// Tags that describes what command created for
    /// </summary>
    public virtual string[]? Tags { get; set; }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose() { }
}

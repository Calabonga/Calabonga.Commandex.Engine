﻿using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Commands;

/// <summary>
/// Base class for Dialog Commandex Command
/// </summary>
/// <typeparam name="TDialogView"></typeparam>
/// <typeparam name="TDialogResult"></typeparam>
public abstract class DialogCommandexCommand<TDialogView, TDialogResult> : ICommandexCommand
    where TDialogView : IDialogView
    where TDialogResult : IViewModel
{
    private readonly IDialogService _dialogService;

    protected DialogCommandexCommand(IDialogService dialogService)
    {
        _dialogService = dialogService;
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
    /// Author or copyright information
    /// </summary>
    public abstract string CopyrightInfo { get; }

    /// <summary>
    /// Display command name in command list 
    /// </summary>
    public abstract string DisplayName { get; }

    /// <summary>
    /// Brief information about what command created for
    /// </summary>
    public abstract string Description { get; }

    /// <summary>
    /// Current command version info for identification
    /// </summary>
    public abstract string Version { get; }

    /// <summary>
    /// Internal dialog result
    /// </summary>
    protected IViewModel? Result { get; set; }

    /// <summary>
    /// Executes command
    /// </summary>
    public Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        var result = _dialogService.ShowDialog<TDialogView, TDialogResult>(result =>
        {
            if (IsPushToShellEnabled)
            {
                OnClosingDialogCallback(result);
            }
        });

        return Task.FromResult(result);
    }

    /// <summary>
    /// Sets current command result for Shell or other command
    /// </summary>
    /// <param name="result"></param>
    protected virtual TDialogResult SetResult(TDialogResult result)
    {
        return result;
    }

    /// <summary>
    /// Handler OnDialogClosed
    /// </summary>
    /// <param name="result"></param>
    private void OnClosingDialogCallback(TDialogResult result)
    {
        Result = SetResult(result);
    }

    /// <summary>
    /// Returns result when <see cref="IsPushToShellEnabled"/> enabled
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
    public virtual void Dispose() { }
}

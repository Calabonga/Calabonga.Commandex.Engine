﻿namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Dialog result interface
/// </summary>
public interface IViewModel : IResult
{
    /// <summary>
    /// Set parameter from <see cref="IDialogService"/>
    /// </summary>
    /// <param name="parameter"></param>
    void OnParameterSet(object? parameter);
}
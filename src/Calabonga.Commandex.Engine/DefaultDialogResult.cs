﻿using System.Windows;

namespace Calabonga.Commandex.Engine;

/// <summary>
/// // Calabonga: Summary required (DefaultDialogResult 2024-07-31 05:51)
/// </summary>
/// <typeparam name="T"></typeparam>
public partial class DefaultDialogResult<T> : DefaultDialogResult
{
    /// <summary>
    /// // Calabonga: Summary required (DefaultDialogResult 2024-07-31 05:52)
    /// </summary>
    public T? Result { get; set; }
}

public abstract class DefaultDialogResult : ViewModelBase, IDialogResult
{
    /// <summary>
    /// Default value <see cref="ResizeMode.NoResize"/>
    /// </summary>
    public virtual ResizeMode ResizeMode => ResizeMode.NoResize;

    /// <summary>
    /// Default value <see cref="SizeToContent.WidthAndHeight"/>
    /// </summary>
    public virtual SizeToContent SizeToContent => SizeToContent.WidthAndHeight;

    /// <summary>
    /// Default value <see cref="WindowStyle.ToolWindow"/>
    /// </summary>
    public virtual WindowStyle WindowStyle => WindowStyle.ToolWindow;

    /// <summary>
    /// Window instance that open this dialog
    /// </summary>
    public object? Owner { get; set; }
}
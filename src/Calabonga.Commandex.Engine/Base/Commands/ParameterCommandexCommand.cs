using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.Engine.Settings;
using Calabonga.OperationResults;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Calabonga.Commandex.Engine.Base.Commands;

/// <summary>
/// // Calabonga: Summary required (CommandexCommand 2024-07-29 09:38)
/// </summary>
/// <typeparam name="TParams"></typeparam>
public abstract class ParameterCommandexCommand<TParams> : ICommandexCommand
    where TParams : CommandexParameter
{
    private readonly string _parameterPath;
    private TParams? _parameter;

    protected ParameterCommandexCommand(IAppSettings appSettings)
    {
        var file = typeof(TParams).Name.PascalToKebabCase() + ".prm";
        _parameterPath = Path.Combine(appSettings.CommandsPath, file);
    }

    /// <summary>
    /// Author or copyright information
    /// </summary>
    public abstract string CopyrightInfo { get; }

    /// <summary>
    /// Returns True/False indicating that's data from command will push to shell
    /// </summary>
    public virtual bool IsPushToShellEnabled => false;

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

    public abstract Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync();

    public object? GetResult() => Parameter;

    /// <summary>
    ///  Tags about what the command is intended for
    /// </summary>
    public abstract string[] Tags { get; }

    protected TParams? Parameter
    {
        get => _parameter ??= GetParameter();
        set
        {
            _parameter = value;
            SetParameter();
        }
    }

    /// <summary>
    /// // Calabonga: Summary required (ParamsToResultCommandexCommand 2024-08-20 12:12)
    /// </summary>
    protected void SaveParameter() => SetParameter();

    /// <summary>
    /// // Calabonga: Summary required (ParamsToResultCommandexCommand 2024-08-20 01:00)
    /// </summary>
    protected void ClearParameter() => ResetParameter();

    private void ResetParameter()
    {
        if (File.Exists(_parameterPath))
        {
            File.Delete(_parameterPath);
        }
    }

    private void SetParameter()
    {
        if (_parameter is null)
        {
            return;
        }

        var data = JsonSerializer.SerializeToUtf8Bytes(_parameter);
        var base64 = Convert.ToBase64String(data);
        File.WriteAllText(_parameterPath, base64, Encoding.UTF8);
    }

    private TParams? GetParameter()
    {

        if (!File.Exists(_parameterPath))
        {
            return null;
        }

        var parameter = File.ReadAllText(_parameterPath);
        var s = Convert.FromBase64String(parameter);
        return JsonSerializer.Deserialize<TParams>(s);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose()
    {

    }
}
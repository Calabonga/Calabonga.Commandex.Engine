using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;
using System.Text;
using System.Text.Json;

namespace Calabonga.Commandex.Engine.Commands;

/// <summary>
/// // Calabonga: Summary required (CommandexCommand 2024-07-29 09:38)
/// </summary>
/// <typeparam name="TParams"></typeparam>
public abstract class ParameterCommandexCommand<TParams> : ICommandexCommand
    where TParams : CommandexParameter
{
    private TParams? _parameter;

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
        var path = "C:/Temp/TEMP.TMP";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    private void SetParameter()
    {
        if (_parameter is null)
        {
            return;
        }

        var path = "C:/Temp/TEMP.TMP";
        var data = JsonSerializer.SerializeToUtf8Bytes(_parameter);
        var base64 = Convert.ToBase64String(data);
        File.WriteAllText(path, base64, Encoding.UTF8);
    }

    private TParams? GetParameter()
    {
        var path = "C:/Temp/TEMP.TMP";
        if (!File.Exists(path))
        {
            return null;
        }

        var parameter = File.ReadAllText(path);
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
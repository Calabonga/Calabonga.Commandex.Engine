using System.Collections.ObjectModel;

namespace Calabonga.Commandex.Engine.Wizards;

public interface IWizardStepViewModel
{
    string Title { get; }

    bool CanLeave { get; }

    ObservableCollection<string> Errors { get; }

    event EventHandler<bool>? CanLeaveChanged;
}
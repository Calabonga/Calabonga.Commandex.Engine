﻿namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (DemoWizardDialogViewModel 2024-08-13 11:45)
/// </summary>
public abstract class WizardContext<TPayload>
{
    public int StepIndex { get; set; }

    public TPayload? Payload { get; set; }
}
# Calabonga.Commandex.Engine

This is a [nuget-package](https://www.nuget.org/packages/Calabonga.Commandex.Engine/) for modular monolith application on WPF platform with plugins as modules. Engine and contracts library for Calabonga.Commandex. Contracts are using for developing a modules for Commandex Shell.

## What is Calabonga.Commandex

The `Calabonga.Commandex` - This is an application on WPF-platform built with CommunityToolkit.MVVM for modules (plugins) using: launch and execute.

What is the `Calabonga.Commandex` can:
* Find a modules `.dll` (plugins) in the folder you set up.
* Launch or execute modules `.dll` (plughis) from GUI.
* Get the results of the module's (plugis) work after they completed.

It's a complex solution with a few repositories:

* **[Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell)** → Command Executer or Command Launcher. To run commands of any type for any purpose. For example, to execute a stored procedure or just to copy some files to some destination.
* **[Calabonga.Commandex.Commands](https://github.com/Calabonga/Calabonga.Commandex.Commands)** → Commands for Calabonga.Commandex.Shell that can execute them from unified shell.
* **[Calabonga.Commandex.Shell.Develop.Template](https://github.com/Calabonga/Calabonga.Commandex.Shell.Develop.Template)** → This is a Developer version of the Command Executer (`Calabonga.Commandex`). Which is created to runs commands of any type for any purposes. For example, to execute a stored procedure or just to co…
* **[Calabonga.Commandex.Engine](https://github.com/Calabonga/Calabonga.Commandex.Engine)** → Engine and contracts library for Calabonga.Commandex. Contracts are using for developing a modules for Commandex Shell.
* **[Calabonga.Commandex.Engine.Processors](https://github.com/Calabonga/Calabonga.Commandex.Engine.Processors)** → Results Processors for Calabonga.Commandex.Shell commands execution results. This is an extended version of the just show string in the notification dialog.

## History of changes

### v1.3.0 2024-10-12

* The `SettingsPath` parameter was created to allow you to store the command's settings env-files in a separate folder
* Summaries for some members were updated

### v1.2.0 2024-10-09

* Nugets dependencies versions updated
* `ServiceCollection` extension created for DefaultResultProcessor registration in container
* Base commands processing implementation updated for new type of the result creation available
* `IResultProcessor` interface created as abstraction for pipeline processing
* Some classes and interface was renamed
* Some base commands property Result is marked as virtual

### v1.1.0 2024-10-07

* Dialog window size management improved for ObservableValidator too. Now, you can set up a size of the dialog window. 

### v1.1.0-beta.1 2024-10-03

* Dialog window size management improved

### v1.0.0 2024-10-01

* First Release 

### v1.0.0-rc.17 2024-09-28

* `ParameterCommandexCommand` getting parameter and setting parameter refactored. Property `Parameter` removed. For read data you can use `ReadParameter()` method. And for write - `WriteParameter()`.
* Some summaries added/updated

### v1.0.0-rc.16 2024-09-16

* UX refactored
  * Menu added
  * Shortcuts added
  * Three type of the command list view added
* `IDialogResult` renamed to `IViewModel`
* New property `Tags` added to `ICommandexCommand` for future commands groups management

### v1.0.0-rc.15 2024-09-15

* Restart Wizard command crash fixed.
* NotificationDialog windows size fixed.

### v1.0.0-rc.14 2024-09-14

* Main window MinHeight and MinWitdth are set
* Wizard window MinHeight and MinWidth are set
* Wizard window UX management properties make as virtual
* Some controls sizing improved
* Nugets dependencies updated
* Windows accent color is set for `ActiveStep` on Wizard dialog.

### v1.0.0-rc.13 2024-09-13

* Nugets versions updated
* `OnSetParameter()` method created for `IDialogResult`
* `DialogService` implementation moved into engine nuget
* `NotificationDialog` implementation moved into engine nuget
* `Wizard` component moved into engine nuget
* `AppSettings` moved into engine nuget

### v1.0.0-rc.11 2024-09-11

* `ShoeDialog()` added override with special parameter for `ViewModel`
* Nuget feed URL moved into configuration parameters

### v1.0.0-rc.3 2024-08-14

* Реализован новый тип команды Wizard для Commandex. Теперь можно формировать набор шагов, которые проходит команда при в выполнении. 

* Обновлен также Shell для Developer, чтобы иметь возможность запускать новый тип команд.

### v1.0.0-beta.9 2024-08-02

* Добавлена возможность управлять типом `Window` при отображении модального окна.

### v1.0.0-beta.7 2024-07-31

* Первая публичная сборка в nuget

## Видео (Video)

В основном репозитории [Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell) есть несколько видео с инструкциями и разъяснениями, как использовать Commandex. А также видео о том, какие типы команд существуют и как для Commandex создавать команды разных типов.

# Calabonga.Commandex.Engine

This is a [nuget-package](https://www.nuget.org/packages/Calabonga.Commandex.Engine/) for modular monolith application on WPF platform with plugins as modules. Engine and contracts library for Calabonga.Commandex. Contracts are using for developing a modules for Commandex Shell.

## What is Calabonga.Commandex

The `Calabonga.Commandex` - This is an application on WPF-platform built with CommunityToolkit.MVVM for modules (plugins) using: launch and execute.

What is the `Calabonga.Commandex` can:
* Find a modules `.dll` (plugins) in the folder you set up.
* Launch or execute modules `.dll` (plughis) from GUI.
* Get the results of the module's (plugis) work after they completed.

It's a complex solution with a few repositories:

* **[Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell)** →  Command Executer or Command Launcher. To run commands of any type for any purpose. For example, to execute a stored procedure or just to copy some files to some destination.
* **[Calabonga.Commandex.Commands](https://github.com/Calabonga/Calabonga.Commandex.Commands)** →  Commands for Calabonga.Commandex.Shell that can execute them from unified shell.
* **[Calabonga.Commandex.Shell.Develop.Template](https://github.com/Calabonga/Calabonga.Commandex.Shell.Develop.Template)** →  (`Tool Template`) This is a Developer version of the Command Executer Shell (`Calabonga.Commandex`). Which is created to runs commands of any type for any purposes. For example, to execute a stored procedure or just to co…
* **[Calabonga.Commandex.Engine](https://github.com/Calabonga/Calabonga.Commandex.Engine)** →  Engine and contracts library for Calabonga.Commandex. Contracts are using for developing a modules for Commandex Shell.
* **[Calabonga.Commandex.Engine.Processors](https://github.com/Calabonga/Calabonga.Commandex.Engine.Processors)** →  Results Processors for Calabonga.Commandex.Shell commands execution results. This is an extended version of the just show string in the notification dialog.
* **[Calabonga.CommandexCommand.Template](https://github.com/Calabonga/Calabonga.CommandexCommand.Template)** →  (`Tool Template`) This is a template of the project to create a Command for Commandex. Just install this nuget as a template for Visual Studio (Rider or dotnet CLI) and then you can create a DialogCommand faster.

## History of changes

### 3.0.0 2025-07-18

* New type `ZoneCommandexCommand<TView, TViewModel>` of the `CommandexCommand` created. This command type can be switched in the `ContentControl` (UIElement) named as `MainZone`. New `IZoneManager` can activate you command in the special zone in the Shell main window;
* Some summaries added
* Some summaries updated
* Nuget-packages dependencies were updated

### v2.8.1 2025-07-09

* `Calabonga.Utils.Extensions` version updated

### v2.8.0 2025-07-08

* `Calabonga.Utils.Extensions` version updated

### v2.7.0 2025-07-07

* Wizard dialog NextButton visibility fixed
* Wizard CanMove split into `CanDoNextStep` and `CanDoPreviousStep`
* Unused properties removed

### v2.6.0 2025-07-04

* Wizard Dialog ViewModel `ISizable` applied
* `Calabonga.Utils.Extensions` nuget updated:
    * SemVer utilites added
    * There are new extensions for `DateTime` added:
        * `.ToJiraString()` => `1d 4h 34m 23s`
        * `.GetMonthStartDay()` => return the first day of the month
        * `.GetMonthStartDay()` => return the first day of the month
        * `.GetWeekStartDay()` => return the first day of the week
        * `.GetWeekEndDay()` => return the last day of the week

### v2.5.0 2025-06-29

Toast Notification implemented: Success, Information, Warning, Error. How it works? It's really easy.
1. Inject `INotificationManager` into your ViewModel constructor:
    ```csharp
    public partial class MainWindowsViewModel : ViewModelBase, IDisposable
    {
        private readonly INotificationManager _notificationManager;
        
        public MainWindowsViewModel(INotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
        }
        
        // ... other code...
    }
    ```
2. Create a toast message:
    ```csharp
        var errorToast = NotificationManager.CreateErrorToast("Message text", "Title");
        //  or
        var successToast = NotificationManager.CreateSuccessToast("Message text", "Title");
        // or 
        var warningToast = NotificationManager.CreateWarningToast("Message text", "Title");
        // or 
        var informationToast = NotificationManager.CreateInformationToast("Message text", "Title");
    ```
3. The show a toast:
    ```csharp
     _notificationManager.Show(errorToast);
     // or
     _notificationManager.Show(successToast);
     // or
     _notificationManager.Show(warningToast);
     // or
     _notificationManager.Show(informationToast);
    ```
4. There are two zone where you can show a toasts: 
   * `Screen` - All toast notifications will show on the screen outside of the application. In this case you do not do anything. This case already works "out of the box".
   * `NotificationZone` - All toast notification will show in the special control `NotificationZone` you should add on your XAML (`VisualTree`). You can do this something like shown below:
    
        Add namespace first
        ```xml
            xmlns:controls="clr-namespace:Calabonga.Commandex.Engine.ToastNotifications.Controls;assembly=Calabonga.Commandex.Engine"
        ``` 
        
        Then add control `NotificationZone` with name "**NotificationZone**":
        ```xml
        <controls:NotificationZone x:Name="NotificationZone" ItemsCountMax="3" Position="TopRight" />
        ```
        
        After than you should add a `NotificationZone` as a parameter for `Show()` method:
        ```csharp
        _notificationManager.Show(errorToast, "NotificationZone");
        // or
        _notificationManager.Show(successToast, "NotificationZone");
        // or
        _notificationManager.Show(warningToast , "NotificationZone");
        // or
        _notificationManager.Show(informationToast, "NotificationZone");
        ```

### v2.3.0 2025-06-18

`ViewModelLocationProvider` and `ViewModelLocation` created for Views and ViewModels binding automation. If you want to use `AutoBindingViewModel` on the View (XAML), something like shown below:

```diff
<UserControl x:Class="Commandex.MyDemoCommand.Views.MyDemoView"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
            xmlns:local="clr-namespace:Commandex.MyDemoCommand.Views"
            xmlns:viewModels="clr-namespace:Commandex.MyDemoCommand.ViewModels"
+           xmlns:viewModelLocator="clr-namespace:Calabonga.Commandex.Engine.ViewModelLocator;assembly=Calabonga.Commandex.Engine"
+           viewModelLocator:ViewModelLocator.AutoBindingViewModel="True"
            mc:Ignorable="d" 
            d:DesignHeight="450" d:DesignWidth="800">
```

Than you should initialize `ViewModelLocationProvider` in your Shell project in the `Composition Root` of your Application. For example:

```csharp
var buildServiceProvider = services.BuildServiceProvider();
ViewModelLocationProvider.SetDefaultViewModelFactory(type => buildServiceProvider.GetRequiredService(type));
return buildServiceProvider;
```

You should also follow the naming rules for Views and ViewModels (or create your own overrides). What's the rule? Everything is simple. For example, if your have a view with name **PersonProfileView.xaml** than you should create a ViewModel for it with name **PersonProfileViewModel**.


### v2.2.0 2025-04-15
* Open dialog in the window maximized now available. See the override for DialogResult `IsMaximized`
* Some summaries updated/added/improved.
* Some refactoring made, syntax error fixed. 


### v2.1.0 2025-01-30

* `ICommandexIdentity` abstraction added for user managing. This abstraction help to create an application user and store it on the `Shell`. Please see [Wiki samples](https://github.com/Calabonga/Calabonga.Commandex.Engine/wiki/ApplicationUser-on-the-modules).
* `ISecureData` abstraction added for availability to store on the Shell side data about tokens (`access_token`, `refresh_token`).
* `IIdentityManager` abstraction for dependency injection container. This can help to make availdable a logged user on the Shell for commands (plugins/modules).
* Some summaries updated/added/improved.
* Some refactoring made, syntax error fixed.

### v2.0.0 2024-11-19

* Migration to NET9.0
* Some summaries were updated (added)

### v1.4.2 2024-11-05

The result for `ConfirmationDialog` as Func result added (delegate). Now you can use async/await for confirmation.

### v1.4.1 2024-11-01

New feature implemented `ConfirmationDialog`. Now you can ask your user some confirmations:

``` csharp
[RelayCommand]
private void OpenLogsFolder()
    => _dialogService.ShowConfirmation("Open logs folder?", result =>
    {
        if (result.ConfirmResult != ConfirmationType.Ok)
        {
            return;
        }

        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

        if (!Path.Exists(path))
        {
            _dialogService.ShowNotification($"Folder not found: {path}");
            return;
        }

        Process.Start(new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = true,
            Verb = "open"
        });
    }, ConfirmationTypes.OkCancel);
```

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

# CLAUDE.md

Этот файл содержит указания для Claude Code (claude.ai/code) при работе с кодом в репозитории **Calabonga.Commandex.Engine**.

## Обзор

Это NuGet-пакет **Engine** (`Calabonga.Commandex.Engine`) — контракты и базовые классы для модульного WPF-приложения Commandex. Он предоставляет:

- Контракты команд (`ICommandexCommand`, базовые типы команд)
- Систему диалогов (`IDialogService`, `DialogService`, уведомления, подтверждения)
- Фреймворк wizard (`IWizardManager`, `WizardDialogViewModel`, шаги)
- Поддержку зон (`IZoneManager`, `ZoneCommandexCommand`)
- Toast-уведомления (`INotificationManager`, зоны)
- Абстракции identity (`ICommandexIdentity`, `ISecureData`)
- Инфраструктуру настроек (`ISettingsReaderConfiguration`, `SettingsBase`)
- ViewModelLocator для автоматической привязки View/ViewModel
- Конвейер обработки результата (`IResultProcessor`)

## Команды сборки

```bash
# Сборка solution
dotnet build src/Calabonga.Commandex.Engine.sln -c Release

# Упаковка NuGet-пакета (вывод в bin/Release)
dotnet pack src/Calabonga.Commandex.Engine/Calabonga.Commandex.Engine.csproj -c Release -o ./nupkg

# Локальная публикация пакета (требуется NUGET_API_KEY)
dotnet nuget push ./nupkg/*.nupkg --api-key $NUGET_API_KEY --source https://api.nuget.org/v3/index.json
```

Целевой фреймворк: `net10.0-windows8.0`, `UseWPF=true`

## Структура проекта

```
src/Calabonga.Commandex.Engine/
├── Base/                    # Основные интерфейсы и базовые классы
│   ├── ICommandexCommand.cs       # Главный контракт команды
│   ├── IResultProcessor.cs        # Абстракция обработки результата
│   ├── IDialog.cs                 # Контракт ViewModel диалога
│   ├── ISettingsReaderConfiguration.cs
│   ├── ISizable.cs                # Управление размером окна
│   ├── IView.cs                   # Маркерный интерфейс View
│   ├── SettingsBase.cs            # Базовые настройки с поддержкой env-файла
│   ├── ViewModelBase.cs           # База MVVM (CommunityToolkit)
│   ├── ViewModelWithValidatorBase.cs  # База VM с валидацией
│   └── CommandexParameter.cs      # Модель файла параметра (JSON+base64)
├── Commands/                # Базовые реализации команд
│   ├── EmptyCommandexCommand.cs          # Запустил и забыл
│   ├── ResultCommandexCommand.cs         # Возвращает типизированный результат
│   ├── DialogCommandexCommand.cs         # Команда с модальным диалогом
│   ├── WizardDialogCommandexCommand.cs   # Многошаговый wizard
│   ├── ParameterCommandexCommand.cs      # Общий файл параметра
│   ├── ZoneCommandexCommand.cs           # Встроенный View в зоне
│   └── InnerCommandexCommand.cs          # Команда, вызываемая другой командой
├── Dialogs/                 # Инфраструктура диалогов
│   ├── DialogService.cs              # Реализация IDialogService по умолчанию
│   ├── IDialogService.cs             # Абстракция диалога
│   ├── IDialogView.cs                # Маркер View диалога
│   ├── IDialogWindow.cs              # Абстракция кастомного окна диалога (v5.0+)
│   ├── DialogWindow.xaml/.cs         # Окно диалога по умолчанию
│   ├── ConfirmationDialog.xaml/.cs   # Диалог Yes/No/Cancel
│   ├── NotificationDialog.xaml/.cs   # Диалог Info/Warning/Error
│   └── DefaultDialogResult.cs        # Базовые типы результата диалога
├── Wizards/                 # Фреймворк wizard
│   ├── IWizardManager.cs             # Оркестрация wizard
│   ├── WizardManager.cs              # Реализация по умолчанию
│   ├── WizardDialogViewModel.cs      # База VM wizard
│   ├── WizardStep.cs / ViewModel     # Абстракция шага
│   ├── WizardContext.cs              # Контекст данных шага
│   └── Wizard.xaml/.cs               # UI wizard
├── Zones/                   # Поддержка зон (встроенные View)
│   ├── IZoneManager.cs
│   └── ZoneManager.cs
├── ToastNotifications/      # Система toast
│   ├── INotificationManager.cs
│   ├── NotificationManager.cs
│   ├── Controls/NotificationZone.xaml  # Внутриприложенный контейнер toast
│   └── Models/ToastNotification.cs
├── Identity/                # Абстракции identity
│   ├── ICommandexIdentity.cs
│   ├── ISecureData.cs
│   └── IUserManager.cs
├── Settings/                # Инфраструктура настроек
│   ├── IAppSettings.cs
│   ├── AppSettings.cs
│   └── DefaultSettingsReaderConfiguration.cs
├── ViewModelLocator/        # Автопривязка View/ViewModel
│   ├── ViewModelLocator.cs
│   └── ViewModelLocationProvider.cs
├── Exceptions/              # Доменные исключения
│   └── ExecuteCommandexCommandException.cs
├── NugetDependencies/       # Объявления NuGet-зависимостей
│   └── INugetDependency.cs
└── Extensions/              # Расширения DI
    └── ServiceCollectionExtensions.cs  # AddDefinitions, AddResultProcessor
```

## Ключевые типы и паттерны

### Типы команд (наследуйте один из них)

| Базовый класс | Сценарий использования | Ключевые члены |
|------------|----------|-------------|
| `EmptyCommandexCommand` | Только побочный эффект | `ExecuteCommandAsync()` |
| `ResultCommandexCommand<TResult>` | Возвращает данные | `protected abstract TResult? Result { get; set; }` |
| `DialogCommandexCommand<TView, TResult>` | Модальный диалог | Внедряет `IDialogService`, `IsPushToShellEnabled` |
| `WizardDialogCommandexCommand<...>` | Многошаговый wizard | Использует `IWizardManager` |
| `ParameterCommandexCommand<TParams>` | Общий файл параметра | `ReadParameter()`, `WriteParameter()` |
| `ZoneCommandexCommand<TView, TViewModel>` | Встроено в зону Shell | Использует `IZoneManager` |
| `InnerCommandexCommand` | Вызывается другой командой | Без DI, ручное выполнение |

### Система диалогов

- **`IDialogService`** — интерфейс для показа диалогов (в `Dialogs/`)
- **`DialogService`** — реализация по умолчанию на базе `DialogWindow`
- **`IDialogWindow`** (v5.0+) — абстракция для кастомных окон диалога; регистрируется через `services.AddScoped<IDialogWindow, CustomDialogWindow>()`
- **Типы результата диалога**: `IViewModel`, `DefaultDialogResult`, `DefaultDialogWithValidationResult`, `ConfirmationDialogResult`, `NotificationDialogResult`
- **Toast**: `INotificationManager.Show(toast, zoneName?)` — zoneName=`"NotificationZone"` для внутриприложенных, null для экранных

### Соглашение ViewModelLocator

```xml
<!-- В XAML View -->
xmlns:viewModelLocator="clr-namespace:Calabonga.Commandex.Engine.ViewModelLocator;assembly=Calabonga.Commandex.Engine"
viewModelLocator:ViewModelLocator.AutoBindingViewModel="True"
```

Именование: `FooView` ↔ `FooViewModel` (тот же сегмент namespace, `View` → `ViewModel`)

Активация в composition root Shell:
```csharp
var provider = services.BuildServiceProvider();
ViewModelLocationProvider.SetDefaultViewModelFactory(type => provider.GetRequiredService(type));
```

### Обработка результата

- `IResultProcessor.ProcessCommand(ICommandexCommand)` — вызывается после выполнения команды
- Engine предоставляет `DefaultResultProcessor` (показывает `GetResult().ToString()`)
- Пакет Processors добавляет `AdvancedResultProcessor` для `TextFileResult`, `ClipboardResult`

### Настройки

- `SettingsBase` — базовый класс с `Load()`/`Save()` на базе `DotNetEnv`
- `ISettingsReaderConfiguration.GetEnvironmentFileName(Type)` — разрешает `.env`-файл для конкретного типа
- Параметры хранятся как JSON в base64 по пути `<CommandsPath>/<kebab-name>.prm`

## Версия и зависимости

Текущая версия: **5.0.0** (см. `.csproj`)

Ключевые зависимости:
- `CommunityToolkit.Mvvm` 8.4.2
- `Calabonga.Wpf.AppDefinitions` 3.0.0-alpha.1 (модульный DI)
- `Calabonga.Results` 1.1.0 / `Calabonga.OperationResults`
- `DotNetEnv` 3.2.0
- `Microsoft.Xaml.Behaviors.Wpf` 1.1.142

## CI/CD

GitHub Actions (`.github/workflows/main.yml`):
- Триггеры: push в `main`, workflow_dispatch
- Выполняется на `windows-latest` с .NET 10 SDK
- Собирает solution, упаковывает, пушит на nuget.org (требуется secret `NUGET_API_KEY`)

## Заметки по разработке

- **Тестов нет** в этом репозитории — тесты существуют только в репозитории Shell
- Пакет потребляется Shell, Processors, шаблонами и примерами команд **как опубликованный NuGet**
- Локальные изменения требуют `dotnet pack` + поднятие версии либо локального feed, чтобы быть видимыми ниже по цепочке
- WPF XAML-файлы используют `<Generator>MSBuild:Compile</Generator>` для `NotificationDialog.xaml`
- Стиль кода задаётся `.editorconfig` (CRLF, отступ 4 пробела, file-scoped namespaces)

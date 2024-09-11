# Calabonga.Commandex.Engine

## Calabonga.Commandex

`Calabonga.Commandex` - Приложение на платформе WPF построенное с использованием CommunityToolkit.MVVM. 

Предназначение - оболочка для работы с модулями (плагинами).

`Calabonga.Commandex` может:
* Находить модули `.dll` (плагины) в указанной папке.
* Запускать модули `.dll` (плагины) из GUI.
* Получать от модулей результаты работы.

## What is Calabonga.Commandex

It's a complex solution with a few repositories:

* **[Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell)** → Command Executer or Command Launcher. To run commands of any type for any purpose. For example, to execute a stored procedure or just to copy some files to some destination.

* **[Calabonga.Commandex.Commands](https://github.com/Calabonga/Calabonga.Commandex.Commands)** → Commands for Calabonga.Commandex.Shell that can execute them from unified shell.

* **[Calabonga.Commandex.Shell.Develop.Template](https://github.com/Calabonga/Calabonga.Commandex.Shell.Develop.Template)** → This is a Developer version of the Command Executer (`Calabonga.Commandex`). Which is created to runs commands of any type for any purposes. For example, to execute a stored procedure or just to co…

* **[Calabonga.Commandex.Engine](https://github.com/Calabonga/Calabonga.Commandex.Engine)** → Engine and contracts library for Calabonga.Commandex. Contracts are using for developing a modules for Commandex Shell.
 
## Calabonga.Commandex.Engine (en)
Engine and contracts library for Calabonga.Commandex. Contracts are using for developing a modules for Commandex Shell.

## История изменений

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
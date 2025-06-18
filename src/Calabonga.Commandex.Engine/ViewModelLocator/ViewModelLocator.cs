using System.ComponentModel;
using System.Windows;

namespace Calabonga.Commandex.Engine.ViewModelLocator;

/// <summary>
/// This class defines the attached property and related change handler that calls the ViewModelLocator in Prism.Mvvm.
/// </summary>
public static class ViewModelLocator
{
    public static readonly DependencyProperty AutoBindingViewModelProperty = DependencyProperty.RegisterAttached(
        "AutoBindingViewModel",
        typeof(bool?),
        typeof(ViewModelLocator),
        new PropertyMetadata(defaultValue: null, propertyChangedCallback: AutoBindingViewModelChanged));

    /// <summary>
    /// Gets the value for the <see cref="AutoBindingViewModelProperty"/> attached property.
    /// </summary>
    /// <param name="obj">The target element.</param>
    /// <returns>The <see cref="AutoBindingViewModelProperty"/> attached to the <paramref name="obj"/> element.</returns>
    public static bool? GetAutoBindingViewModel(DependencyObject obj)
    {
        return (bool?)obj.GetValue(AutoBindingViewModelProperty);
    }

    /// <summary>
    /// Sets the <see cref="AutoBindingViewModelProperty"/> attached property.
    /// </summary>
    /// <param name="obj">The target element.</param>
    /// <param name="value">The value to attach.</param>
    public static void SetAutoBindingViewModel(DependencyObject obj, bool? value)
    {
        obj.SetValue(AutoBindingViewModelProperty, value);
    }

    private static void AutoBindingViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (!DesignerProperties.GetIsInDesignMode(d))
        {
            var value = (bool?)e.NewValue;
            if (value.HasValue && value.Value)
            {
                ViewModelLocationProvider.AutoBindingViewModelChanged(d, Bind);
            }
        }
    }

    /// <summary>
    /// Sets the DataContext of a View.
    /// </summary>
    /// <param name="view">The View to set the DataContext on.</param>
    /// <param name="viewModel">The object to use as the DataContext for the View.</param>
    static void Bind(object view, object viewModel)
    {
        if (view is not FrameworkElement element)
        {
            return;
        }

        element.DataContext = viewModel;
    }
}

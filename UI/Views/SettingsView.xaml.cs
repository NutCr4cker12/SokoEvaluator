using SokoEqCalculator.ViewModels;

namespace SokoEqCalculator.Views;

public partial class SettingsView : ContentPage
{
    public SettingsView(SettingsViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }

    private void OnThemeStyleChanged(object sender, CheckedChangedEventArgs e)
    {
        if (BindingContext is not SettingsViewModel settingsViewModel)
        {
            throw new ArgumentNullException($"Can't change app theme style, {nameof(BindingContext)} was null");
        }

        if (sender is not RadioButton radioButton)
        {
            throw new ArgumentNullException($"Can't change app theme style, sender was not {nameof(RadioButton)}");
        }

        // Invoke the change function only on the newly selected value
        if (!radioButton.IsChecked)
        {
            return;
        }

        var newTheme = App.StringToTheme(radioButton.Value as string);
        settingsViewModel.OnThemeColorChange(newTheme);
    }
}
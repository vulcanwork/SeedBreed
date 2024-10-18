using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SeedBreed.Core;
using SeedBreed.Wpf.Views;
using System.Windows;
using System.Windows.Controls;

namespace SeedBreed.Wpf;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell() => Container.Resolve<MainWindow>();
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<Api>();
        containerRegistry.RegisterSingleton<Seedlings>();
        CreateGlobalTexBoxEvents();
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
    }
    private void CreateGlobalTexBoxEvents()
    {
        EventManager.RegisterClassHandler(typeof(TextBox),
            TextBox.GotFocusEvent,
            new RoutedEventHandler(TextBox_GotFocus));
        EventManager.RegisterClassHandler(typeof(TextBox),
            TextBox.MouseDoubleClickEvent,
            new RoutedEventHandler(TextBox_GotFocus));
    }

    /// <summary>
    /// Selects all text in a text box when it gets focus or is double-clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBox_GotFocus(object sender, RoutedEventArgs e) => (sender as TextBox).SelectAll();
}

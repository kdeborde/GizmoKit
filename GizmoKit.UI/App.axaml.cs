using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Themes.Fluent;
using Avalonia.Themes.Simple;
using GizmoKit.UI.ViewModels;
using GizmoKit.UI.Views;

namespace GizmoKit.UI
{
    public partial class App : Application
    {
        public static FluentTheme FluentTheme = new FluentTheme();

        public static SimpleTheme SimpleTheme = new SimpleTheme();
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
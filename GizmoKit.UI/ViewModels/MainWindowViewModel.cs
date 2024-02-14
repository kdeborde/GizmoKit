using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace GizmoKit.UI.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly Window _hostWindow;

        [ObservableProperty]
        private StreamGeometry _expandCollapseButtonIcon;

        [ObservableProperty]
        private NavigationItemTemplate _selectedNavigationItem;

        [ObservableProperty]
        private bool _isSideMenuPaneOpen = true;

        [ObservableProperty]
        private ViewModelBase _currentPage = new HomePageViewModel();

        public MainWindowViewModel()
        {
        }
        public MainWindowViewModel(Window _hostWindow)
        {
            ChangeToggleSideMenuIcon();
            this._hostWindow = _hostWindow;
        }

        partial void OnSelectedNavigationItemChanged(NavigationItemTemplate value)
        {
            if (value == null)
            {
                return;
            }
            var instance = Activator.CreateInstance(value.ModelType);
            if (instance == null)
            {
                return;
            }
            CurrentPage = (ViewModelBase)instance;
        }

        public ObservableCollection<NavigationItemTemplate> NavigationItems { get; } =
        [
            new NavigationItemTemplate(typeof(HomePageViewModel), "HomeRegular"),
            new NavigationItemTemplate(typeof(ChatGPTPageViewModel), "ChatBubblesQuestionRegular")
        ];

        [RelayCommand]
        public void TriggerToggleSideMenuCommand()
        {
            IsSideMenuPaneOpen = !IsSideMenuPaneOpen;
            ChangeToggleSideMenuIcon();
        }

        public void ChangeToggleSideMenuIcon()
        {
            string key;
            if (IsSideMenuPaneOpen || ExpandCollapseButtonIcon == null)
            {
                key = "ArrowLeftRegular";
            }
            else
            {
                key = "TextAlignCenterRegular";
            }
            Application.Current!.TryFindResource(key, out var res);
            ExpandCollapseButtonIcon = (StreamGeometry)res;
        }
    }
}

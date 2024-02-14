using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizmoKit.UI.ViewModels
{
    public class NavigationItemTemplate
    {
        public string Label { get; }
        public Type ModelType { get; }
        public StreamGeometry NavItemIcon { get; }
        public StreamGeometry ExpandCollapseButtonIcon { get; }

        public NavigationItemTemplate(Type type, string iconKey)
        {
            ModelType = type;
            Label = type.Name.Replace("PageViewModel", "");

            Application.Current!.TryFindResource(iconKey, out var res);
            NavItemIcon = (StreamGeometry)res;
        }
    }
}

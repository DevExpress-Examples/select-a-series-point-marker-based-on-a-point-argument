using System.Windows;

namespace ArgumentBasedMarkerTypeSelector {
    public partial class App : Application {
        void OnAppStartup_UpdateThemeName(object sender, StartupEventArgs e) {

            DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName();
        }
    }
}

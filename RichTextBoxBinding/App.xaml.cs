using Microsoft.Practices.Unity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RichTextBoxBinding
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private IUnityContainer Container { get; } = new UnityContainer();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory(x => this.Container.Resolve(x));
        }
    }
}

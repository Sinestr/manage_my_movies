using ManageMyMovies.MVVM.Models;
using ManageMyMovies.MVVM.Models.Abstracts;
using ManageMyMovies.Models;
using ManageMyMovies.ViewModels;
using ManageMyMovies.ViewModels.Abstracts;
using ManageMyMovies.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace ManageMyMovies
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            ServiceCollection serviceCollection = new ServiceCollection();

            //Création du contexte de données de l'application.
            serviceCollection.AddSingleton<IDataContext, UserMovieManagerContext>(sp => FileDataContext.Load(@"C:\Temp\data.json", new UserMovieManagerContext(@"C:\Temp\data.json")));
            //Création du vue-modèle principal.
            serviceCollection.AddTransient<IViewModelMain, ViewModelMain>(sp => new ViewModelMain(sp));
            serviceCollection.AddTransient<IViewModelSearch, ViewModelSearch>(sp => new ViewModelSearch(sp.GetService<IDataContext>()));

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            MainWindow window = new MainWindow();
            window.DataContext = serviceProvider.GetService<IViewModelMain>();
            window.Show();
        }
    }
}

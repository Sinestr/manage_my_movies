using ManageMyMovies.MVVM;
using ManageMyMovies.MVVM.Abstracts;
using ManageMyMovies.MVVM.Models.Abstracts;
using ManageMyMovies.MVVM.ViewModels;
using ManageMyMovies.MVVM.ViewModels.Abstracts;
using ManageMyMovies.ViewModels.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using ManageMyMovies.Models;
using ManageMyMovies.MVVM.Models;

namespace ManageMyMovies.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewModelMain : ViewModelList<IObservableObject, IDataContext>, IViewModelMain
    {
        #region Fields
        /// <summary>
        /// Fournisseur de service de l'application.
        /// </summary>
        private readonly IServiceProvider _ServiceProvider;

        /// <summary>
        /// 
        /// </summary>
        private IViewModelSearch _ViewModelSearch;

        /// <summary>
        /// 
        /// </summary>
        private IViewModelMyMovies _ViewModelMyMovies;

        /// <summary>
        /// Commande pour fermer l'application.
        /// </summary>
        private readonly RelayCommand _ExitCommand;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public IViewModelSearch ViewModelSearch 
        { 
            get => this._ViewModelSearch; 
            private set => this.SetProperty(nameof(this.ViewModelSearch), ref this._ViewModelSearch, value); 
        }

        /// <summary>
        /// 
        /// </summary>
        public IViewModelMyMovies ViewModelMyMovies
        {
            get => this._ViewModelMyMovies;
            private set => this.SetProperty(nameof(this.ViewModelMyMovies), ref this._ViewModelMyMovies, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public RelayCommand ExitCommand => this._ExitCommand;

        #endregion

        #region Constructors
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ViewModelMain"/>.
        /// </summary>
        /// <param name="serviceProvider">Fournisseur de service de l'application.</param>
        public ViewModelMain(IServiceProvider serviceProvider) : base(serviceProvider.GetService<IDataContext>())
        {
            this._ServiceProvider = serviceProvider;
            this._ViewModelSearch = this._ServiceProvider.GetService<IViewModelSearch>();
            this._ViewModelMyMovies = this._ServiceProvider.GetService<IViewModelMyMovies>();

            this._ExitCommand = new RelayCommand(this.ExitApplication, this.CanExitApplication);
            this.LoadData();
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.ItemsSource = new ObservableCollection<IObservableObject>(new IObservableObject[]
            { 
                this._ViewModelSearch,
                this._ViewModelMyMovies
            });
            this.SelectedItem = this._ViewModelSearch;
        }

        /// <summary>
        /// Déclenche l'événement <see cref="OnPropertyChanged"/>.
        /// </summary>
        /// <param name="propertyName">Nom de la propriété qui a changée.</param>
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.SelectedItem):
                    (this.SelectedItem as IViewModelList<IDataContext>)?.LoadData();
                break;
                
                default:
                    break;
            }
        }

        #region ExitCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual bool CanExitApplication(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual void ExitApplication(object parameter)
        {
            Environment.Exit(0);
        }
        #endregion

        #endregion
    }
}

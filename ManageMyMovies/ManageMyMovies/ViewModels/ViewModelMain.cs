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
    /// Vue-modèle principal de l'application.
    /// </summary>
    public class ViewModelMain : ViewModelList<IObservableObject, IDataContext>, IViewModelMain
    {
        #region Fields
        /// <summary>
        /// Fournisseur de service de l'application.
        /// </summary>
        private readonly IServiceProvider _ServiceProvider;

        /// <summary>
        /// Vue-modèle de la page de recherche d'un nouveau film à partir de l'api Omdbapi.
        /// </summary>
        private IViewModelSearch _ViewModelSearch;

        /// <summary>
        /// Vue-modèle de la page de gestion de sa liste personnelle de films.
        /// </summary>
        private IViewModelMyMovies _ViewModelMyMovies;

        /// <summary>
        /// Commande pour quitter et fermer l'application.
        /// </summary>
        private readonly RelayCommand _ExitCommand;

        #endregion

        #region Properties
        /// <summary>
        /// Obtient ou définit le vue-modèle de la page de recherche d'un nouveau film à partir de l'api Omdbapi.
        /// </summary>
        public IViewModelSearch ViewModelSearch 
        { 
            get => this._ViewModelSearch; 
            private set => this.SetProperty(nameof(this.ViewModelSearch), ref this._ViewModelSearch, value); 
        }

        /// <summary>
        /// Obtient ou définit le vue-modèle de la page de gestion de sa liste personnelle de films.
        /// </summary>
        public IViewModelMyMovies ViewModelMyMovies
        {
            get => this._ViewModelMyMovies;
            private set => this.SetProperty(nameof(this.ViewModelMyMovies), ref this._ViewModelMyMovies, value);
        }

        /// <summary>
        /// Obtient la commande pour quitter et fermer l'application.
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
            //récupération des services initialisés dans l'app.xml
            this._ServiceProvider = serviceProvider;

            //initialisation des sous vue-modèles du viewModelMain
            this._ViewModelSearch = this._ServiceProvider.GetService<IViewModelSearch>();
            this._ViewModelMyMovies = this._ServiceProvider.GetService<IViewModelMyMovies>();
            
            this._ExitCommand = new RelayCommand(this.ExitApplication, this.CanExitApplication);
            this.LoadData();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Méthode de chargement des données.
        /// </summary>
        public override void LoadData()
        {
            //Ajout des deux vues-modèles qui vont découler du viewModelMain 
            //Ce sont les deux sous-menus
            this.ItemsSource = new ObservableCollection<IObservableObject>(new IObservableObject[]
            { 
                this._ViewModelSearch,
                this._ViewModelMyMovies
            });

            //On sélectionne par défault la page de recherche d'un film à partir de l'api
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
        /// Methode qui détermine si la commande <see cref="ExitCommand"/> peut être exécutée.
        /// </summary>
        /// <param name="parameter">Paramètre de la commande.</param>
        /// <returns>Détermine si la commande peut être exécutée.</returns>
        protected virtual bool CanExitApplication(object parameter) => true;
        
        /// <summary>
        /// Méthode d'exécution de la commande <see cref="ExitCommand"/>.
        /// </summary>
        /// <param name="parameter">Paramètre de la commande.</param>
        protected virtual void ExitApplication(object parameter) => Environment.Exit(0);
        
        #endregion

        #endregion
    }
}

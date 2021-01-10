﻿using ManageMyMovies.MVVM.Abstracts;
using ManageMyMovies.MVVM.Models.Abstracts;
using ManageMyMovies.MVVM.ViewModels.Abstracts;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
using System.Text;

namespace ManageMyMovies.MVVM.ViewModels
{
    /// <summary>
    ///     Vue-modèle de liste dans un contexte de données.
    /// </summary>
    public class ViewModelList<T, U> : ViewModelWithDataContext<U>, IViewModelList<T, U>
        where T : IObservableObject
        where U : IDataContext
    {
        #region Fields

        /// <summary>
        ///     Liste des personnes.
        /// </summary>
        private ObservableCollection<T> _ItemsSource;

        /// <summary>
        ///     Personne sélectionnée.
        /// </summary>
        private T _SelectedItem;

        /// <summary>
        ///     Commande pour ajouter une personne.
        /// </summary>
        private readonly RelayCommand _AddCommand;

        /// <summary>
        ///     Commande pour supprimer une personne passée en paramètre ou la personne sélectionnée.
        /// </summary>
        private readonly RelayCommand _DeleteCommand;

        /// <summary>
        /// 
        /// </summary>
        private readonly RelayCommand _SearchCommand;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient la liste des personnes.
        /// </summary>
        public ObservableCollection<T> ItemsSource
        {
            get => this._ItemsSource;
            protected set => this.SetProperty(nameof(this.ItemsSource), ref this._ItemsSource, value);
        }

        /// <summary>
        ///     Obtient ou définit la personne sélectionnée.
        /// </summary>
        public T SelectedItem
        {
            get => this._SelectedItem;
            set => this.SetProperty(nameof(this.SelectedItem), ref this._SelectedItem, value);
        }

        /// <summary>
        ///     Obtient la commande pour ajouter un élément.
        /// </summary>
        public virtual RelayCommand AddCommand => this._AddCommand;

        /// <summary>
        ///     Obtient la commande pour supprimer un élément passé en paramètre ou l'élément sélectionné.
        /// </summary>
        public virtual RelayCommand DeleteCommand => this._DeleteCommand;

        /// <summary>
        /// 
        /// </summary>
        public virtual RelayCommand SearchCommand => this._SearchCommand;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="ViewModelListT"/>.
        /// </summary>
        /// <param name="dataContext">Contexte de données.</param>
        public ViewModelList(U dataContext)
            : base(dataContext)
        {
            this._AddCommand = new RelayCommand(this.Add, this.CanAdd);
            this._DeleteCommand = new RelayCommand(this.Delete, this.CanDelete);
            this._SearchCommand = new RelayCommand(this.Search, this.CanSearch);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Méthode de chargement des données.
        /// </summary>
        public override void LoadData()
        {
            base.LoadData();
            this.ItemsSource = new ObservableCollection<T>(this.DataContext.GetItems<T>());
        }

        #region AddCommand

        /// <summary>
        ///     Méthode d'exécution de la commande <see cref="Add"/>.
        /// </summary>
        /// <param name="parameter">Paramètre de la commande.</param>
        protected virtual void Add(object parameter)
        {
            T itemToAdd = this.DataContext.CreateItem<T>();
            this.ItemsSource.Insert(0, itemToAdd);
            this.SelectedItem = itemToAdd;
        }

        /// <summary>
        ///     Methode qui détermine si la commande <see cref="Add"/> peut être exécutée.
        /// </summary>
        /// <param name="parameter">Paramètre de la commande.</param>
        /// <returns>Détermine si la commande peut être exécutée.</returns>
        protected virtual bool CanAdd(object parameter) => true;

        #endregion

        #region DeleteCommand

        /// <summary>
        ///     Méthode d'exécution de la commande <see cref="Delete"/>.
        /// </summary>
        /// <param name="parameter">Paramètre de la commande.</param>
        protected virtual void Delete(object parameter)
        {
            T itemToDelete = (T)parameter ?? this.SelectedItem;

            if (itemToDelete != null)
            {
                this.ItemsSource.Remove(itemToDelete);
                this.DataContext.GetItems<T>().Remove(itemToDelete);
            }
        }

        /// <summary>
        ///     Methode qui détermine si la commande <see cref="Delete"/> peut être exécutée.
        /// </summary>
        /// <param name="parameter">Paramètre de la commande.</param>
        /// <returns>Détermine si la commande peut être exécutée.</returns>
        protected virtual bool CanDelete(object parameter) => parameter is T || this._SelectedItem != null;

        #endregion

        #region SearchMoveApi
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual void Search(object parameter)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual bool CanSearch(object parameter) => true;
        #endregion

        #endregion
    }
}

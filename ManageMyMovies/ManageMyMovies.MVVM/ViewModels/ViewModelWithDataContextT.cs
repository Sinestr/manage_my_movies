using ManageMyMovies.MVVM.Models.Abstracts;
using ManageMyMovies.MVVM.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageMyMovies.MVVM.ViewModels
{
    /// <summary>
    ///     Vue-modèle avec un contexte de données.
    /// </summary>
    /// <typeparam name="T">Type du contexte de données.</typeparam>
    public class ViewModelWithDataContext<T> : ObservableObject, IViewModelWithDataContext<T>
        where T : IDataContext
    {
        #region Fields

        /// <summary>
        ///     Contexte de données
        /// </summary>
        private IDataContext _DataContext;

        /// <summary>
        ///     Commande pour sauvegarder les données.
        /// </summary>
        private readonly RelayCommand _SaveCommand;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient le contexte de données.
        /// </summary>
        public IDataContext DataContext { get => this._DataContext; private set => this.SetProperty(nameof(this.DataContext), ref this._DataContext, value); }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="ViewModelWithDataContext{T}"/>.
        /// </summary>
        /// <param name="dataContext">Contexte de données.</param>
        public ViewModelWithDataContext(IDataContext dataContext)
        {
            this._DataContext = dataContext;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Méthode de chargement des données.
        /// </summary>
        public virtual void LoadData()
        {

        }

        #endregion
    }
}

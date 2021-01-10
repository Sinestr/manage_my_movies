using ManageMyMovies.MVVM.Models.Abstracts;
using System;
using System.Text;
using System.Collections.Generic;

namespace ManageMyMovies.MVVM.ViewModels.Abstracts
{
    public interface IViewModelList<T> : IViewModelWithDataContext<T>
        where T : IDataContext
    {
        #region Properties

        /// <summary>
        ///     Obtient la commande pour ajouter une personne.
        /// </summary>
        RelayCommand AddCommand { get; }

        /// <summary>
        ///     Obtient la commande pour supprimer une personne passée en paramètre ou la personne sélectionnée.
        /// </summary>
        RelayCommand DeleteCommand { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     Méthode de chargement des données.
        /// </summary>
        void LoadData();

        #endregion
    }
}

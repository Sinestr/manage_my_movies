using ManageMyMovies.MVVM.Abstracts;
using ManageMyMovies.MVVM.Models.Abstracts;
using System.Collections.ObjectModel;
using System;
using System.Text;
using System.Collections.Generic;

namespace ManageMyMovies.MVVM.ViewModels.Abstracts
{
    public interface IViewModelList<T, U> : IViewModelList<U>
            where T : IObservableObject
            where U : IDataContext
    {
        #region Properties

        /// <summary>
        ///     Obtient la liste des personnes.
        /// </summary>
        ObservableCollection<T> ItemsSource { get; }

        /// <summary>
        ///     Obtient ou définit la personne sélectionnée.
        /// </summary>
        T SelectedItem { get; set; }

        #endregion
    }
}

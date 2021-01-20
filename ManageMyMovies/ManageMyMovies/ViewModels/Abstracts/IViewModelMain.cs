using ManageMyMovies.MVVM.Abstracts;
using ManageMyMovies.MVVM.Models.Abstracts;
using ManageMyMovies.MVVM.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.ViewModels.Abstracts
{
    /// <summary>
    /// Interface du vue-modèle principal de l'application.
    /// </summary>
    public interface IViewModelMain : IViewModelList<IObservableObject, IDataContext>
    {
        #region Propoerties
        /// <summary>
        /// Obtient le vue-modèle de la page de recherche d'un nouveau film à partir de l'api Omdbapi.
        /// </summary>
        public IViewModelSearch ViewModelSearch { get; }

        /// <summary>
        /// Obtient le vue-modèle de la page de gestion de sa liste personnelle de films.
        /// </summary>
        public IViewModelMyMovies ViewModelMyMovies { get; }

        #endregion
    }
}

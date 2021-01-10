using ManageMyMovies.MVVM.Abstracts;
using ManageMyMovies.MVVM.Models.Abstracts;

namespace ManageMyMovies.MVVM.ViewModels.Abstracts
{
    /// <summary>
    ///     Interface d'un vue-modèle avec un contexte de données.
    /// </summary>
    /// <typeparam name="T">Type du contexte de données.</typeparam>
    public interface IViewModelWithDataContext<T> : IObservableObject
        where T : IDataContext
    {
        #region Properties

        /// <summary>
        ///     Obtient le contexte de données.
        /// </summary>
        IDataContext DataContext { get; }

        /// <summary>
        ///     Obtient la commande pour sauvegarder les données.
        /// </summary>
        RelayCommand SaveCommand { get; }

        #endregion
    }
}
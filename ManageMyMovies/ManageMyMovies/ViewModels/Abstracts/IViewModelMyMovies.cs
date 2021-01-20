using ManageMyMovies.Models;
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
    /// Interface du vue-modèle de la page de gestion de sa liste personnelle de films.
    /// </summary>
    public interface IViewModelMyMovies : IViewModelList<UserMovie, IDataContext>
    {

    }
}

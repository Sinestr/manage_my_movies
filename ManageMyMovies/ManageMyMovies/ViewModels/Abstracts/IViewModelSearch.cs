using ManageMyMovies.Models;
using ManageMyMovies.Models.Api;
using ManageMyMovies.MVVM.Abstracts;
using ManageMyMovies.MVVM.Models.Abstracts;
using ManageMyMovies.MVVM.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageMyMovies.ViewModels.Abstracts
{
    /// <summary>
    /// Interface du vue-modèle de la page de recherche de films.
    /// </summary>
    public interface IViewModelSearch : IViewModelList<Search, IDataContext>
    {

    }
}

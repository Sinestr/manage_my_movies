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
    /// 
    /// </summary>
    public interface IViewModelMyMovies : IViewModelList<UserMovieManagerContext, IDataContext>
    {

    }
}

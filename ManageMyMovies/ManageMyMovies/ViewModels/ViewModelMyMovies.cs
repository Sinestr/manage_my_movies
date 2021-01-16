using ManageMyMovies.Models;
using ManageMyMovies.MVVM;
using ManageMyMovies.MVVM.Models;
using ManageMyMovies.MVVM.Models.Abstracts;
using ManageMyMovies.MVVM.ViewModels;
using ManageMyMovies.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.ViewModels
{
    public class ViewModelMyMovies : ViewModelList<UserMovie, IDataContext>, IViewModelMyMovies
    {
        #region Fields

        #endregion

        #region Properties
        /// <summary>
        /// Obtient le titre du vue-modèle
        /// </summary>
        public string Title => "Ma Liste de Films";

        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataContext"></param>
        public ViewModelMyMovies(IDataContext dataContext) : base(dataContext)
        {
            this.LoadData();
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            string dataJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataJson\\my_movies.json");
            UserMovieManagerContext userMovieManager = FileDataContext.Load<UserMovieManagerContext>(dataJsonPath, new UserMovieManagerContext(dataJsonPath));
            this.ItemsSource = new ObservableCollection<UserMovie>(userMovieManager.MyMoviesLibrary);
        }

        #region DeleteCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">ImdbId du film qu'il faut supprimer de la liste</param>
        protected override void Delete(object parameter)
        {
            if (parameter != null && parameter.ToString().Length > 0)
            {
                string imdbId = parameter.ToString();
                UserMovie movieToDelete = this.ItemsSource.ToList().Find(movie => movie.ImdbID == imdbId);
                if (movieToDelete != null)
                {
                    this.ItemsSource.Remove(movieToDelete);
                    this.DataContext.GetItems<UserMovie>().Remove(movieToDelete);

                    string dataJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataJson\\my_movies.json");
                    UserMovieManagerContext userMovieManager = FileDataContext.Load<UserMovieManagerContext>(dataJsonPath, new UserMovieManagerContext(dataJsonPath));
                    userMovieManager.MyMoviesLibrary = this.ItemsSource;
                    userMovieManager.Save();
                }
            }
        }
        #endregion

        #region SearchCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        protected override void Search(object parameter)
        {
            Console.WriteLine("Toto");
        }
        #endregion

        #region SaveUpdateCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        protected override void SaveUpdate(object parameter)
        {
            string dataJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataJson\\my_movies.json");
            UserMovieManagerContext userMovieManager = FileDataContext.Load<UserMovieManagerContext>(dataJsonPath, new UserMovieManagerContext(dataJsonPath));
            userMovieManager.MyMoviesLibrary = this.ItemsSource;
            userMovieManager.Save();
        }
        #endregion

        #endregion
    }
}

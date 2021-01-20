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
    /// <summary>
    /// Vue-modèle de la page de gestion de sa liste personnelle de films.
    /// </summary>
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
        /// Initialise une nouvelle instance de la classe <see cref="ViewModelMyMovies"/>
        /// </summary>
        /// <param name="dataContext"></param>
        public ViewModelMyMovies(IDataContext dataContext) : base(dataContext)
        {
            this.LoadData();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Méthode de chargement de données du vue-modèle
        /// </summary>
        public override void LoadData()
        {
            //chargement des films stockés dans le fichier de sauvegarde Json
            string dataJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataJson\\my_movies.json");
            UserMovieManagerContext userMovieManager = FileDataContext.Load<UserMovieManagerContext>(dataJsonPath, new UserMovieManagerContext(dataJsonPath));
            
            //les données par défaut de cette page sont le films récupérer du ficher de suavegarde Json
            this.ItemsSource = new ObservableCollection<UserMovie>(userMovieManager.MyMoviesLibrary);
            this.SelectedItem = null;
        }

        /// <summary>
        /// Procédure qui vient enregistrer les données d'ItemsSource dans le fichier de sauvegarde
        /// </summary>
        public void SyncSourceAndJsonData()
        {
            string dataJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataJson\\my_movies.json");
            UserMovieManagerContext userMovieManager = FileDataContext.Load<UserMovieManagerContext>(dataJsonPath, new UserMovieManagerContext(dataJsonPath));
            userMovieManager.MyMoviesLibrary = this.ItemsSource;

            //serialisation de la liste des films dans le fichier de sauvegarde
            userMovieManager.Save();
        }

        #region DeleteCommand
        /// <summary>
        /// Methode qui vient retirer un film de sa liste
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
                    this.SyncSourceAndJsonData();
                }
            }
        }
        #endregion

        #region SearchCommand
        /// <summary>
        /// Procédure de recherche d'un film dans liste personnelle de film
        /// </summary>
        /// <param name="parameter"></param>
        protected override void Search(object parameter)
        {
            //recherche de l'utilisateur, récupérée dans la barre de recherche
            //reformatage de la recherche avec Trim qui vient supprimer les caractères non voulus en début et fin de chaine
            string researchTitle = parameter.ToString().ToLower().Trim();

            //check si la recherche par titre est n'est vide
            if (researchTitle != "")
            {
                //on vient filtrer les films qui contiennent la recherche dans leurs titres
                var matchedMovies = this.ItemsSource.Where(movie => movie.Title.ToLower().Contains(researchTitle));
                //mise à jour de la source de données
                this.ItemsSource = new ObservableCollection<UserMovie>(matchedMovies);
            }
            else
            {
                //si la recherche est vide alors on recharge tous les films
                this.LoadData();
            }
        }
        #endregion

        #region SaveUpdateCommand
        /// <summary>
        /// Méthode d'exécution de la commande <see cref="SaveUpdateCommand"/>.
        /// </summary>
        /// <param name="parameter">Paramètre de la commande.</param>
        protected override void SaveUpdate(object parameter)
        {
            this.SyncSourceAndJsonData();
        }
        #endregion

        #endregion
    }
}

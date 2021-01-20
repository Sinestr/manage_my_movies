using ManageMyMovies.MVVM.Abstracts;
using ManageMyMovies.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace ManageMyMovies.Models
{
    /// <summary>
    /// Classe représentant le contexte de données global sur lequel on s'appuie 
    /// pour avoir une liste personnelle de films
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class UserMovieManagerContext : FileDataContext
    {
        #region Fields
        /// <summary>
        /// Collection des films ajoutés par l'utilisateur
        /// </summary>
        private ObservableCollection<UserMovie> _MyMoviesLibrary;

        #endregion

        #region Properties
        /// <summary>
        /// Obtient la collection des films que l'utilisateur a ajouté dans sa liste personnelle
        /// </summary>
        public ObservableCollection<UserMovie> MyMoviesLibrary
        {
            get => this._MyMoviesLibrary;
            set => this.SetProperty(nameof(this.MyMoviesLibrary), ref this._MyMoviesLibrary, value);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="UserMovieManagerContext"/>.
        /// </summary>
        /// <param name="filePath"></param>
        public UserMovieManagerContext(string filePath) : base(filePath)
        {
            this._MyMoviesLibrary = new ObservableCollection<UserMovie>();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Créer un élément du type spécifié et l'ajoute au contexte de données.
        /// Ici seul le UserMovie existe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Retourne un nouvel élément du type UserMovie</returns>
        public override T CreateItem<T>()
        {
            IObservableObject createdItem;

            if (typeof(T) == typeof(UserMovie))
            {
                createdItem = new UserMovie();
                this._MyMoviesLibrary.Add(createdItem as UserMovie);
            }
            else
            {
                throw new Exception("Le type spécifié n'est pas valide");
            }

            return (T)createdItem;
        }

        /// <summary>
        /// Obtient la collection des éléments du type spécifié.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Collection des éléments de UserMovie.</returns>
        public override ObservableCollection<T> GetItems<T>()
        {
            ObservableCollection<T> result;

            if (typeof(T) == typeof(UserMovie))
            {
                result = this.MyMoviesLibrary as ObservableCollection<T>;
            }
            else
            {
                throw new Exception("Le type spécifié n'est pas valide");
            }

            return result;
        }

        #endregion
    }
}

using ManageMyMovies.Models.Api;
using ManageMyMovies.MVVM.Abstracts;
using ManageMyMovies.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.Models
{
    /// <summary>
    /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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

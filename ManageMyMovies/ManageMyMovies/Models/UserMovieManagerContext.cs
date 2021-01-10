using ManageMyMovies.Models.Api;
using ManageMyMovies.MVVM.Abstracts;
using ManageMyMovies.MVVM.Models;
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
    public class UserMovieManagerContext : FileDataContext
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<UserWishlistMovie> _UserWihslistMovies;

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<UserMovie> _UserMovies;

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<MovieApi> _MovieApi;

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<UserWishlistMovie> UserWishlistMovies
        {
            get => this._UserWihslistMovies;
            set => this.SetProperty(nameof(this.UserWishlistMovies), ref this._UserWihslistMovies, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<UserMovie> UserMovies
        {
            get => this._UserMovies;
            set => this.SetProperty(nameof(this.UserMovies), ref this._UserMovies, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<MovieApi> MovieApi
        {
            get => this._MovieApi;
            set => this.SetProperty(nameof(this.MovieApi), ref this._MovieApi, value);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public UserMovieManagerContext(string filePath) : base(filePath)
        {
            this._UserWihslistMovies = new ObservableCollection<UserWishlistMovie>();
            this._UserMovies = new ObservableCollection<UserMovie>();
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
                this.UserMovies.Add(createdItem as UserMovie);
            }
            else if (typeof(T) == typeof(UserWishlistMovie))
            {
                createdItem = new UserWishlistMovie();
                this.UserWishlistMovies.Add(createdItem as UserWishlistMovie);
            }
            else if (typeof(T) == typeof(MovieApi))
            {
                createdItem = new MovieApi();
                this.MovieApi.Add(createdItem as MovieApi);
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
                result = this.UserMovies as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(UserWishlistMovie))
            {
                result = this.UserWishlistMovies as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(MovieApi))
            {
                result = this.MovieApi as ObservableCollection<T>;
            }
            else
            {
                throw new Exception("Le type spécifié n'est pas valide");
            }

            return result;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            /*
            this.BankAccountLines.ToList().ForEach(bal =>
            {
                bal.BankAccount = this.BankAccounts.FirstOrDefault(ba => ba.Identifier == bal.IdentifierBankAccount);
                bal.BankAccount?.BankAccountLines?.Add(bal);
                bal.Category = this.Categories.FirstOrDefault(ba => ba.Identifier == bal.IdentifierCategory);
                bal.Category?.BankAccountLines?.Add(bal);
            });
            */
        }
        #endregion
    }
}

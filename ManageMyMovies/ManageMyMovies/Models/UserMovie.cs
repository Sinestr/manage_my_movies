using ManageMyMovies.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.Models
{
    /// <summary>
    /// 
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class UserMovie : Entity
    {
        #region Fields
        private struct UserMovieData
        {
            /// <summary>
            /// Identifiant de la liste souhaitée, associé au film
            /// </summary>
            public long _IdentifierWishlistMovie { get; set; }

            /// <summary>
            /// Titre du film
            /// </summary>
            public string _Title { get; set; }

            /// <summary>
            /// Année de sortie
            /// </summary>
            public string _Year { get; set; }

            /// <summary>
            /// Genre du film
            /// </summary>
            public string _Genre { get; set; }

            /// <summary>
            /// Poster du film
            /// </summary>
            public string _Poster { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public UserWishlistMovie _WishlistMovie { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        UserMovieData? _BackupUserMovieData;

        /// <summary>
        /// 
        /// </summary>
        UserMovieData _CurrentUserMovieData;

        #endregion

        #region Properties
        /// <summary>
        /// Obtient ou définit l'identifiant du compte bancaire associé.
        /// </summary>
        public long IdentifierWishlistMovie
        {
            get => this._CurrentUserMovieData._IdentifierWishlistMovie;
            set => this.SetProperty(nameof(this.IdentifierWishlistMovie), () => this._CurrentUserMovieData._IdentifierWishlistMovie, (v) => this._CurrentUserMovieData._IdentifierWishlistMovie = v, value);
        }

        /// <summary>
        /// Obtient ou définit le titre du film
        /// </summary>
        public string Title
        {
            get => this._CurrentUserMovieData._Title;
            set => this.SetProperty(nameof(this.Title), () => this._CurrentUserMovieData._Title, (v) => this._CurrentUserMovieData._Title = v, value);
        }


        /// <summary>
        /// Obtient ou définit l'année de sortie du film
        /// </summary>
        public string Year
        {
            get => this._CurrentUserMovieData._Year;
            set => this.SetProperty(nameof(this.Year), () => this._CurrentUserMovieData._Year, (v) => this._CurrentUserMovieData._Year = v, value);
        }

        /// <summary>
        /// Obtient ou définit le genre du film
        /// </summary>
        public string Genre
        {
            get => this._CurrentUserMovieData._Genre;
            set => this.SetProperty(nameof(this.Genre), () => this._CurrentUserMovieData._Genre, (v) => this._CurrentUserMovieData._Genre = v, value);
        }

        /// <summary>
        /// Obtient ou définit la couverture du film
        /// </summary>
        public string Poster
        {
            get => this._CurrentUserMovieData._Poster;
            set => this.SetProperty(nameof(this.Poster), () => this._CurrentUserMovieData._Poster, (v) => this._CurrentUserMovieData._Poster = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public UserWishlistMovie UserWishlistMovie
        {
            get => this._CurrentUserMovieData._WishlistMovie;
            set => this.SetProperty(nameof(this.UserWishlistMovie), () => this._CurrentUserMovieData._WishlistMovie, (v) => this._CurrentUserMovieData._WishlistMovie = v, value);
        }

        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public UserMovie()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public override void BeginEdit()
        {
            if (this._BackupUserMovieData == null)
            {
                this._BackupUserMovieData = this._CurrentUserMovieData;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CancelEdit()
        {
            if (this._BackupUserMovieData != null)
            {
                this._CurrentUserMovieData = this._BackupUserMovieData.Value;
                this._BackupUserMovieData = null;
                this.OnPropertyChanged("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void EndEdit()
        {
            if (this._BackupUserMovieData != null)
            {
                this._BackupUserMovieData = null;
            }
        }
        #endregion
    }
}

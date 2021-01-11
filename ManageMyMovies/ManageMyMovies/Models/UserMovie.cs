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
            [JsonProperty("Id")]
            public long Id { get; set; }

            /// <summary>
            /// Titre du film
            /// </summary>
            [JsonProperty("Title")]
            public string Title { get; set; }

            /// <summary>
            /// Année de sortie
            /// </summary>
            [JsonProperty("Year")]
            public string Year { get; set; }

            /// <summary>
            /// Genre du film
            /// </summary>
            [JsonProperty("Type")]
            public string Type { get; set; }

            /// <summary>
            /// Poster du film
            /// </summary>
            [JsonProperty("Poster")]
            public string Poster { get; set; }
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
        public long Id
        {
            get => this._CurrentUserMovieData.Id;
            set => this.SetProperty(nameof(this.Id), () => this._CurrentUserMovieData.Id, (v) => this._CurrentUserMovieData.Id = v, value);
        }

        /// <summary>
        /// Obtient ou définit le titre du film
        /// </summary>
        public string Title
        {
            get => this._CurrentUserMovieData.Title;
            set => this.SetProperty(nameof(this.Title), () => this._CurrentUserMovieData.Title, (v) => this._CurrentUserMovieData.Title = v, value);
        }


        /// <summary>
        /// Obtient ou définit l'année de sortie du film
        /// </summary>
        public string Year
        {
            get => this._CurrentUserMovieData.Year;
            set => this.SetProperty(nameof(this.Year), () => this._CurrentUserMovieData.Year, (v) => this._CurrentUserMovieData.Year = v, value);
        }

        /// <summary>
        /// Obtient ou définit le genre du film
        /// </summary>
        public string Type
        {
            get => this._CurrentUserMovieData.Type;
            set => this.SetProperty(nameof(this.Type), () => this._CurrentUserMovieData.Type, (v) => this._CurrentUserMovieData.Type = v, value);
        }

        /// <summary>
        /// Obtient ou définit la couverture du film
        /// </summary>
        public string Poster
        {
            get => this._CurrentUserMovieData.Poster;
            set => this.SetProperty(nameof(this.Poster), () => this._CurrentUserMovieData.Poster, (v) => this._CurrentUserMovieData.Poster = v, value);
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

using ManageMyMovies.Models.Api.FullMovie;
using ManageMyMovies.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.Models
{
    /// <summary>
    /// Classe regroupant les données d'un film utilisateur
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class UserMovie : Entity
    {
        #region Fields
        private struct UserMovieData
        {
            [JsonProperty("Title")]
            public string Title { get; set; }

            [JsonProperty("Year")]
            public string Year { get; set; }

            [JsonProperty("Rated")]
            public string Rated { get; set; }

            [JsonProperty("Released")]
            public string Released { get; set; }

            [JsonProperty("Runtime")]
            public string Runtime { get; set; }

            [JsonProperty("Genre")]
            public string Genre { get; set; }

            [JsonProperty("Director")]
            public string Director { get; set; }

            [JsonProperty("Writer")]
            public string Writer { get; set; }

            [JsonProperty("Actors")]
            public string Actors { get; set; }

            [JsonProperty("Plot")]
            public string Plot { get; set; }

            [JsonProperty("Language")]
            public string Language { get; set; }

            [JsonProperty("Country")]
            public string Country { get; set; }

            [JsonProperty("Awards")]
            public string Awards { get; set; }

            [JsonProperty("Poster")]
            public string Poster { get; set; }

            [JsonProperty("Ratings")]
            public ObservableCollection<Rating> Ratings { get; set; }

            [JsonProperty("Metascore")]
            public string Metascore { get; set; }

            [JsonProperty("imdbRating")]
            public string ImdbRating { get; set; }

            [JsonProperty("imdbVotes")]
            public string ImdbVotes { get; set; }

            [JsonProperty("imdbID")]
            public string ImdbID { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("DVD")]
            public string DVD { get; set; }

            [JsonProperty("BoxOffice")]
            public string BoxOffice { get; set; }

            [JsonProperty("Production")]
            public string Production { get; set; }

            [JsonProperty("Website")]
            public string Website { get; set; }

            [JsonProperty("Response")]
            public string Response { get; set; }

            [JsonProperty("Watched")]
            public bool Watched { get; set; }

            [JsonProperty("Favorite")]
            public bool Favorite { get; set; }
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
        /// 
        /// </summary>
        public string Title
        {
            get => this._CurrentUserMovieData.Title;
            set => this.SetProperty(nameof(this.Title), () => this._CurrentUserMovieData.Title, (v) => this._CurrentUserMovieData.Title = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Year
        {
            get => this._CurrentUserMovieData.Year;
            set => this.SetProperty(nameof(this.Year), () => this._CurrentUserMovieData.Year, (v) => this._CurrentUserMovieData.Year = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Rated
        {
            get => this._CurrentUserMovieData.Rated;
            set => this.SetProperty(nameof(this.Rated), () => this._CurrentUserMovieData.Rated, (v) => this._CurrentUserMovieData.Rated = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Released
        {
            get => this._CurrentUserMovieData.Released;
            set => this.SetProperty(nameof(this.Released), () => this._CurrentUserMovieData.Released, (v) => this._CurrentUserMovieData.Released = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Runtime
        {
            get => this._CurrentUserMovieData.Runtime;
            set => this.SetProperty(nameof(this.Runtime), () => this._CurrentUserMovieData.Runtime, (v) => this._CurrentUserMovieData.Runtime = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Genre
        {
            get => this._CurrentUserMovieData.Genre;
            set => this.SetProperty(nameof(this.Genre), () => this._CurrentUserMovieData.Genre, (v) => this._CurrentUserMovieData.Genre = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Director
        {
            get => this._CurrentUserMovieData.Director;
            set => this.SetProperty(nameof(this.Director), () => this._CurrentUserMovieData.Director, (v) => this._CurrentUserMovieData.Director = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Writer
        {
            get => this._CurrentUserMovieData.Writer;
            set => this.SetProperty(nameof(this.Writer), () => this._CurrentUserMovieData.Writer, (v) => this._CurrentUserMovieData.Writer = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Actors
        {
            get => this._CurrentUserMovieData.Actors;
            set => this.SetProperty(nameof(this.Actors), () => this._CurrentUserMovieData.Actors, (v) => this._CurrentUserMovieData.Actors = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Plot
        {
            get => this._CurrentUserMovieData.Plot;
            set => this.SetProperty(nameof(this.Plot), () => this._CurrentUserMovieData.Plot, (v) => this._CurrentUserMovieData.Plot = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Language
        {
            get => this._CurrentUserMovieData.Language;
            set => this.SetProperty(nameof(this.Language), () => this._CurrentUserMovieData.Language, (v) => this._CurrentUserMovieData.Language = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Country
        {
            get => this._CurrentUserMovieData.Country;
            set => this.SetProperty(nameof(this.Country), () => this._CurrentUserMovieData.Actors, (v) => this._CurrentUserMovieData.Country = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Awards
        {
            get => this._CurrentUserMovieData.Awards;
            set => this.SetProperty(nameof(this.Awards), () => this._CurrentUserMovieData.Awards, (v) => this._CurrentUserMovieData.Awards = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Poster
        {
            get => this._CurrentUserMovieData.Poster;
            set => this.SetProperty(nameof(this.Poster), () => this._CurrentUserMovieData.Poster, (v) => this._CurrentUserMovieData.Poster = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Rating> Ratings
        {
            get => this._CurrentUserMovieData.Ratings;
            set => this.SetProperty(nameof(this.Ratings), () => this._CurrentUserMovieData.Ratings, (v) => this._CurrentUserMovieData.Ratings = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Metascore
        {
            get => this._CurrentUserMovieData.Metascore;
            set => this.SetProperty(nameof(this.Metascore), () => this._CurrentUserMovieData.Metascore, (v) => this._CurrentUserMovieData.Metascore = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string ImdbRating
        {
            get => this._CurrentUserMovieData.ImdbRating;
            set => this.SetProperty(nameof(this.ImdbRating), () => this._CurrentUserMovieData.ImdbRating, (v) => this._CurrentUserMovieData.ImdbRating = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string ImdbVotes
        {
            get => this._CurrentUserMovieData.ImdbVotes;
            set => this.SetProperty(nameof(this.ImdbVotes), () => this._CurrentUserMovieData.ImdbVotes, (v) => this._CurrentUserMovieData.ImdbVotes = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string ImdbID
        {
            get => this._CurrentUserMovieData.ImdbID;
            set => this.SetProperty(nameof(this.ImdbID), () => this._CurrentUserMovieData.ImdbID, (v) => this._CurrentUserMovieData.ImdbID = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            get => this._CurrentUserMovieData.Type;
            set => this.SetProperty(nameof(this.Type), () => this._CurrentUserMovieData.Type, (v) => this._CurrentUserMovieData.Type = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string DVD
        {
            get => this._CurrentUserMovieData.DVD;
            set => this.SetProperty(nameof(this.DVD), () => this._CurrentUserMovieData.DVD, (v) => this._CurrentUserMovieData.DVD = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string BoxOffice
        {
            get => this._CurrentUserMovieData.BoxOffice;
            set => this.SetProperty(nameof(this.BoxOffice), () => this._CurrentUserMovieData.BoxOffice, (v) => this._CurrentUserMovieData.BoxOffice = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Production
        {
            get => this._CurrentUserMovieData.Production;
            set => this.SetProperty(nameof(this.Production), () => this._CurrentUserMovieData.Production, (v) => this._CurrentUserMovieData.Production = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Website
        {
            get => this._CurrentUserMovieData.Website;
            set => this.SetProperty(nameof(this.Website), () => this._CurrentUserMovieData.Website, (v) => this._CurrentUserMovieData.Website = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Response
        {
            get => this._CurrentUserMovieData.Response;
            set => this.SetProperty(nameof(this.Response), () => this._CurrentUserMovieData.Response, (v) => this._CurrentUserMovieData.Response = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Watched
        {
            get => this._CurrentUserMovieData.Watched;
            set => this.SetProperty(nameof(this.Watched), () => this._CurrentUserMovieData.Watched, (v) => this._CurrentUserMovieData.Watched = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Favorite
        {
            get => this._CurrentUserMovieData.Favorite;
            set => this.SetProperty(nameof(this.Favorite), () => this._CurrentUserMovieData.Favorite, (v) => this._CurrentUserMovieData.Favorite = v, value);
        }

        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public UserMovie()
        {
            this.Watched = false;
            this.Favorite = false;
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

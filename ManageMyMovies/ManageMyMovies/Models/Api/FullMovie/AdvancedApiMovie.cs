using ManageMyMovies.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.Models.Api.FullMovie
{
    /// <summary>
    /// 
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class AdvancedApiMovie : Entity
    {
        #region Fields
        private struct AdvancedApiMovieData
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
        }

        /// <summary>
        /// 
        /// </summary>
        AdvancedApiMovieData? _BackupAdvancedApiMovie;

        /// <summary>
        /// 
        /// </summary>
        AdvancedApiMovieData _CurrentAdvancedApiMovie;

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get => this._CurrentAdvancedApiMovie.Title;
            set => this.SetProperty(nameof(this.Title), () => this._CurrentAdvancedApiMovie.Title, (v) => this._CurrentAdvancedApiMovie.Title = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Year
        {
            get => this._CurrentAdvancedApiMovie.Year;
            set => this.SetProperty(nameof(this.Year), () => this._CurrentAdvancedApiMovie.Year, (v) => this._CurrentAdvancedApiMovie.Year = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Rated
        {
            get => this._CurrentAdvancedApiMovie.Rated;
            set => this.SetProperty(nameof(this.Rated), () => this._CurrentAdvancedApiMovie.Rated, (v) => this._CurrentAdvancedApiMovie.Rated = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Released
        {
            get => this._CurrentAdvancedApiMovie.Released;
            set => this.SetProperty(nameof(this.Released), () => this._CurrentAdvancedApiMovie.Released, (v) => this._CurrentAdvancedApiMovie.Released = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Runtime
        {
            get => this._CurrentAdvancedApiMovie.Runtime;
            set => this.SetProperty(nameof(this.Runtime), () => this._CurrentAdvancedApiMovie.Runtime, (v) => this._CurrentAdvancedApiMovie.Runtime = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Genre
        {
            get => this._CurrentAdvancedApiMovie.Genre;
            set => this.SetProperty(nameof(this.Genre), () => this._CurrentAdvancedApiMovie.Genre, (v) => this._CurrentAdvancedApiMovie.Genre = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Director
        {
            get => this._CurrentAdvancedApiMovie.Director;
            set => this.SetProperty(nameof(this.Director), () => this._CurrentAdvancedApiMovie.Director, (v) => this._CurrentAdvancedApiMovie.Director = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Writer
        {
            get => this._CurrentAdvancedApiMovie.Writer;
            set => this.SetProperty(nameof(this.Writer), () => this._CurrentAdvancedApiMovie.Writer, (v) => this._CurrentAdvancedApiMovie.Writer = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Actors
        {
            get => this._CurrentAdvancedApiMovie.Actors;
            set => this.SetProperty(nameof(this.Actors), () => this._CurrentAdvancedApiMovie.Actors, (v) => this._CurrentAdvancedApiMovie.Actors = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Plot
        {
            get => this._CurrentAdvancedApiMovie.Plot;
            set => this.SetProperty(nameof(this.Plot), () => this._CurrentAdvancedApiMovie.Plot, (v) => this._CurrentAdvancedApiMovie.Plot = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Language
        {
            get => this._CurrentAdvancedApiMovie.Language;
            set => this.SetProperty(nameof(this.Language), () => this._CurrentAdvancedApiMovie.Language, (v) => this._CurrentAdvancedApiMovie.Language = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Country
        {
            get => this._CurrentAdvancedApiMovie.Country;
            set => this.SetProperty(nameof(this.Country), () => this._CurrentAdvancedApiMovie.Actors, (v) => this._CurrentAdvancedApiMovie.Country = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Awards
        {
            get => this._CurrentAdvancedApiMovie.Awards;
            set => this.SetProperty(nameof(this.Awards), () => this._CurrentAdvancedApiMovie.Awards, (v) => this._CurrentAdvancedApiMovie.Awards = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Poster
        {
            get => this._CurrentAdvancedApiMovie.Poster;
            set => this.SetProperty(nameof(this.Poster), () => this._CurrentAdvancedApiMovie.Poster, (v) => this._CurrentAdvancedApiMovie.Poster = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Rating> Ratings
        {
            get => this._CurrentAdvancedApiMovie.Ratings;
            set => this.SetProperty(nameof(this.Ratings), () => this._CurrentAdvancedApiMovie.Ratings, (v) => this._CurrentAdvancedApiMovie.Ratings = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Metascore
        {
            get => this._CurrentAdvancedApiMovie.Metascore;
            set => this.SetProperty(nameof(this.Metascore), () => this._CurrentAdvancedApiMovie.Metascore, (v) => this._CurrentAdvancedApiMovie.Metascore = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string ImdbRating
        {
            get => this._CurrentAdvancedApiMovie.ImdbRating;
            set => this.SetProperty(nameof(this.ImdbRating), () => this._CurrentAdvancedApiMovie.ImdbRating, (v) => this._CurrentAdvancedApiMovie.ImdbRating = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string ImdbVotes
        {
            get => this._CurrentAdvancedApiMovie.ImdbVotes;
            set => this.SetProperty(nameof(this.ImdbVotes), () => this._CurrentAdvancedApiMovie.ImdbVotes, (v) => this._CurrentAdvancedApiMovie.ImdbVotes = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string ImdbID
        {
            get => this._CurrentAdvancedApiMovie.ImdbID;
            set => this.SetProperty(nameof(this.ImdbID), () => this._CurrentAdvancedApiMovie.ImdbID, (v) => this._CurrentAdvancedApiMovie.ImdbID = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            get => this._CurrentAdvancedApiMovie.Type;
            set => this.SetProperty(nameof(this.Type), () => this._CurrentAdvancedApiMovie.Type, (v) => this._CurrentAdvancedApiMovie.Type = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string DVD
        {
            get => this._CurrentAdvancedApiMovie.DVD;
            set => this.SetProperty(nameof(this.DVD), () => this._CurrentAdvancedApiMovie.DVD, (v) => this._CurrentAdvancedApiMovie.DVD = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string BoxOffice
        {
            get => this._CurrentAdvancedApiMovie.BoxOffice;
            set => this.SetProperty(nameof(this.BoxOffice), () => this._CurrentAdvancedApiMovie.BoxOffice, (v) => this._CurrentAdvancedApiMovie.BoxOffice = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Production
        {
            get => this._CurrentAdvancedApiMovie.Production;
            set => this.SetProperty(nameof(this.Production), () => this._CurrentAdvancedApiMovie.Production, (v) => this._CurrentAdvancedApiMovie.Production = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Website
        {
            get => this._CurrentAdvancedApiMovie.Website;
            set => this.SetProperty(nameof(this.Website), () => this._CurrentAdvancedApiMovie.Website, (v) => this._CurrentAdvancedApiMovie.Website = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Response
        {
            get => this._CurrentAdvancedApiMovie.Response;
            set => this.SetProperty(nameof(this.Response), () => this._CurrentAdvancedApiMovie.Response, (v) => this._CurrentAdvancedApiMovie.Response = v, value);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public AdvancedApiMovie()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public override void BeginEdit()
        {
            if (this._BackupAdvancedApiMovie == null)
            {
                this._BackupAdvancedApiMovie = this._CurrentAdvancedApiMovie;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CancelEdit()
        {
            if (this._BackupAdvancedApiMovie != null)
            {
                this._CurrentAdvancedApiMovie = this._BackupAdvancedApiMovie.Value;
                this._BackupAdvancedApiMovie = null;
                this.OnPropertyChanged("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void EndEdit()
        {
            if (this._BackupAdvancedApiMovie != null)
            {
                this._BackupAdvancedApiMovie = null;
            }
        }
        #endregion
    }
}

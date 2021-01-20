using ManageMyMovies.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.Models.Api
{
    /// <summary>
    /// Classe de données réprésentant la racine de la structure de données d'une recherche par omdbapi
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class MovieApi : Entity
    {
        #region Fields
        private struct MovieApiData
        {
            [JsonProperty("Search")]
            public ObservableCollection<Search> Search { get; set; }

            [JsonProperty("totalResults")]
            public string TotalResults { get; set; }

            [JsonProperty("Response")]
            public string Response { get; set; }
        }

        /// <summary>
        /// Sauvegarde de données au début de l'édition
        /// Notamment utile lors d'utilisation de DataGrid
        /// </summary>
        MovieApiData? _BackupMovieApiData;

        /// <summary>
        /// Données atcuelles 
        /// Notamment utile lors d'utilisation de DataGrid
        /// </summary>
        MovieApiData _CurrentMovieApiData;

        #endregion

        #region Properties
        /// <summary>
        /// Obtient le liste des films retournés par la requête api
        /// </summary>
        public ObservableCollection<Search> Search
        {
            get => this._CurrentMovieApiData.Search;
            set => this.SetProperty(nameof(this.Search), () => this._CurrentMovieApiData.Search, (v) => this._CurrentMovieApiData.Search = v, value);
        }

        /// <summary>
        /// Obtient le nombre total de films retournés par une requête vers l'api
        /// </summary>
        public string TotalResults
        {
            get => this._CurrentMovieApiData.TotalResults;
            set => this.SetProperty(nameof(this.TotalResults), () => this._CurrentMovieApiData.TotalResults, (v) => this._CurrentMovieApiData.TotalResults = v, value);
        }

        /// <summary>
        /// Obtient la réponse de la requête api
        /// </summary>
        public string Response
        {
            get => this._CurrentMovieApiData.Response;
            set => this.SetProperty(nameof(this.Response), () => this._CurrentMovieApiData.Response, (v) => this._CurrentMovieApiData.Response = v, value);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="MovieApi"/>.
        /// </summary>
        public MovieApi() { }
        #endregion

        #region Methods
        /// <summary>
        /// Commence l'édition d'une entité.
        /// </summary>
        public override void BeginEdit()
        {
            if (this._BackupMovieApiData == null)
            {
                this._BackupMovieApiData = this._CurrentMovieApiData;
            }
        }

        /// <summary>
        /// Annule les modifications effectuées sur l'entité.
        /// </summary>
        public override void CancelEdit()
        {
            if (this._BackupMovieApiData != null)
            {
                this._CurrentMovieApiData = this._BackupMovieApiData.Value;
                this._BackupMovieApiData = null;
                this.OnPropertyChanged("");
            }
        }

        /// <summary>
        /// Valide les modifications effectuées sur l'entité.
        /// </summary>
        public override void EndEdit()
        {
            if (this._BackupMovieApiData != null)
            {
                this._BackupMovieApiData = null;
            }
        }
        #endregion
    }
}

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
    /// 
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
        /// 
        /// </summary>
        MovieApiData? _BackupMovieApiData;

        /// <summary>
        /// 
        /// </summary>
        MovieApiData _CurrentMovieApiData;

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Search> Search
        {
            get => this._CurrentMovieApiData.Search;
            set => this.SetProperty(nameof(this.Search), () => this._CurrentMovieApiData.Search, (v) => this._CurrentMovieApiData.Search = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string TotalResults
        {
            get => this._CurrentMovieApiData.TotalResults;
            set => this.SetProperty(nameof(this.TotalResults), () => this._CurrentMovieApiData.TotalResults, (v) => this._CurrentMovieApiData.TotalResults = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Response
        {
            get => this._CurrentMovieApiData.Response;
            set => this.SetProperty(nameof(this.Response), () => this._CurrentMovieApiData.Response, (v) => this._CurrentMovieApiData.Response = v, value);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public MovieApi()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public override void BeginEdit()
        {
            if (this._BackupMovieApiData == null)
            {
                this._BackupMovieApiData = this._CurrentMovieApiData;
            }
        }

        /// <summary>
        /// 
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
        /// 
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

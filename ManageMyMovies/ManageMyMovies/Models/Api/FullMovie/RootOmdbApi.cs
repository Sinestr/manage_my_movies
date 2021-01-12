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
    public class RootOmdbApi : Entity
    {
        #region Fields
        private struct RootOmdbApiData
        {
            public ObservableCollection<AdvancedApiMovie> AdvancedApiMovies { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        RootOmdbApiData? _BackupRootOmdbApiData;
        
        /// <summary>
        /// 
        /// </summary>
        RootOmdbApiData _CurrentRootOmdbApiData;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<AdvancedApiMovie> AdvancedApiMovies
        {
            get => this._CurrentRootOmdbApiData.AdvancedApiMovies;
            set => this.SetProperty(nameof(this.AdvancedApiMovies), () => this._CurrentRootOmdbApiData.AdvancedApiMovies, (v) => this._CurrentRootOmdbApiData.AdvancedApiMovies = v, value);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public RootOmdbApi()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public override void BeginEdit()
        {
            if (this._BackupRootOmdbApiData == null)
            {
                this._BackupRootOmdbApiData = this._CurrentRootOmdbApiData;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CancelEdit()
        {
            if (this._BackupRootOmdbApiData != null)
            {
                this._CurrentRootOmdbApiData = this._BackupRootOmdbApiData.Value;
                this._BackupRootOmdbApiData = null;
                this.OnPropertyChanged("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void EndEdit()
        {
            if (this._BackupRootOmdbApiData != null)
            {
                this._BackupRootOmdbApiData = null;
            }
        }
        #endregion
    }
}

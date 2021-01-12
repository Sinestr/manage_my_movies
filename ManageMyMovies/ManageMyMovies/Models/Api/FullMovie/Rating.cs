using ManageMyMovies.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.Models.Api.FullMovie
{
    /// <summary>
    /// 
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class Rating : Entity
    {
        #region Fields
        private struct RatingData
        {
            [JsonProperty("Source")]
            public string Source { get; set; }

            [JsonProperty("Value")]
            public string Value { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        RatingData? _BackupRatingData;
        
        /// <summary>
        /// 
        /// </summary>
        RatingData _CurrentRatingData;

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string Source
        {
            get => this._CurrentRatingData.Source;
            set => this.SetProperty(nameof(this.Source), () => this._CurrentRatingData.Source, (v) => this._CurrentRatingData.Source = v, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Response
        {
            get => this._CurrentRatingData.Value;
            set => this.SetProperty(nameof(this.Response), () => this._CurrentRatingData.Value, (v) => this._CurrentRatingData.Value = v, value);
        }

        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Rating ()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public override void BeginEdit()
        {
            if (this._BackupRatingData == null)
            {
                this._BackupRatingData = this._CurrentRatingData;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CancelEdit()
        {
            if (this._BackupRatingData != null)
            {
                this._CurrentRatingData = this._BackupRatingData.Value;
                this._BackupRatingData = null;
                this.OnPropertyChanged("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void EndEdit()
        {
            if (this._BackupRatingData != null)
            {
                this._BackupRatingData = null;
            }
        }
        #endregion
    }
}

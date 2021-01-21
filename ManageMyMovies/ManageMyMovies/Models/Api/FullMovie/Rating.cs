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
    /// Classe de données représentant une note d'un film avancé omdbapi
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
        /// Sauvegarde de données au début de l'édition
        /// Notamment utile lors d'utilisation de DataGrid
        /// </summary>
        RatingData? _BackupRatingData;

        /// <summary>
        /// Données atcuelles 
        /// Notamment utile lors d'utilisation de DataGrid
        /// </summary>
        RatingData _CurrentRatingData;

        #endregion

        #region Properties
        /// <summary>
        /// Obtient la source de la notation (quel site, etc...)
        /// </summary>
        public string Source
        {
            get => this._CurrentRatingData.Source;
            set => this.SetProperty(nameof(this.Source), () => this._CurrentRatingData.Source, (v) => this._CurrentRatingData.Source = v, value);
        }

        /// <summary>
        /// Obtient la note du film
        /// </summary>
        public string Value
        {
            get => this._CurrentRatingData.Value;
            set => this.SetProperty(nameof(this.Value), () => this._CurrentRatingData.Value, (v) => this._CurrentRatingData.Value = v, value);
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Rating"/>.
        /// </summary>
        public Rating () { }
        #endregion

        #region Methods
        /// <summary>
        /// Commence l'édition d'une entité.
        /// </summary>
        public override void BeginEdit()
        {
            if (this._BackupRatingData == null)
            {
                this._BackupRatingData = this._CurrentRatingData;
            }
        }

        /// <summary>
        /// Annule les modifications effectuées sur l'entité.
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
        /// Valide les modifications effectuées sur l'entité.
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

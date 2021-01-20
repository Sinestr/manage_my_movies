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
    /// Classe de données réprésentant la racine de la structure de données 
    /// d'une liste de films avancés par omdbapi
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class RootOmdbApi : Entity
    {
        #region Fields
        private struct RootOmdbApiData
        {
            [JsonProperty("AdvancedApiMovies")]
            public ObservableCollection<AdvancedApiMovie> AdvancedApiMovies { get; set; }
        }

        /// <summary>
        /// Sauvegarde de données au début de l'édition
        /// Notamment utile lors d'utilisation de DataGrid
        /// </summary>
        RootOmdbApiData? _BackupRootOmdbApiData;

        /// <summary>
        /// Données atcuelles 
        /// Notamment utile lors d'utilisation de DataGrid
        /// </summary>
        RootOmdbApiData _CurrentRootOmdbApiData;
        #endregion

        #region Properties
        /// <summary>
        /// Obtient la liste des films avancés d'une recherche par omdbapi
        /// </summary>
        public ObservableCollection<AdvancedApiMovie> AdvancedApiMovies
        {
            get => this._CurrentRootOmdbApiData.AdvancedApiMovies;
            set => this.SetProperty(nameof(this.AdvancedApiMovies), () => this._CurrentRootOmdbApiData.AdvancedApiMovies, (v) => this._CurrentRootOmdbApiData.AdvancedApiMovies = v, value);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RootOmdbApi"/>.
        /// </summary>
        public RootOmdbApi() { }
        #endregion

        #region Methods
        /// <summary>
        /// Commence l'édition d'une entité.
        /// </summary>
        public override void BeginEdit()
        {
            if (this._BackupRootOmdbApiData == null)
            {
                this._BackupRootOmdbApiData = this._CurrentRootOmdbApiData;
            }
        }

        /// <summary>
        /// Annule les modifications effectuées sur l'entité.
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
        /// Valide les modifications effectuées sur l'entité.
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

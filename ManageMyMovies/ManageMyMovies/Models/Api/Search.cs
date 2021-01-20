using ManageMyMovies.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.Models.Api
{
    /// <summary>
    /// Classe regroupant les données d'un film recherché sur omdbapi
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class Search
    {
        #region Fields / Properties
        /// <summary>
        /// Titre du film
        /// </summary>
        [JsonProperty("Title")]
        public string Title { get; set; }

        /// <summary>
        /// Année de sortie du film
        /// </summary>
        [JsonProperty("Year")]
        public string Year { get; set; }

        /// <summary>
        /// Identifiant du film
        /// </summary>
        [JsonProperty("imdbID")]
        public string ImdbID { get; set; }

        /// <summary>
        /// Genre du film
        /// </summary>
        [JsonProperty("Type")]
        public string Type { get; set; }

        /// <summary>
        /// Affiche du film
        /// </summary>
        [JsonProperty("Poster")]
        public string Poster { get; set; }
        #endregion
    }
}

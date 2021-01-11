using ManageMyMovies.ViewModels.Abstracts;
using ManageMyMovies.MVVM.Models.Abstracts;
using ManageMyMovies.MVVM.ViewModels;
using ManageMyMovies.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using ManageMyMovies.MVVM;
using System.Collections.ObjectModel;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace ManageMyMovies.ViewModels
{
    /// <summary>
    ///     
    /// </summary>
    public class ViewModelSearch : ViewModelList<Search, IDataContext>, IViewModelSearch
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        const string API_KEY = "5ff6d345";

        /// <summary>
        /// 
        /// </summary>
        const string OMDBAPI_URL = "http://www.omdbapi.com/";

        #endregion

        #region Properties

        /// <summary>
        /// Obtient le titre du vue-modèle
        /// </summary>
        public string Title => "Rechercher un film";

        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataContext"></param>
        public ViewModelSearch(IDataContext dataContext) : base(dataContext)
        {
            this.LoadData();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Méthode de chargement des données.
        /// </summary>
        public override void LoadData()
        {
            this.ItemsSource = new ObservableCollection<Search>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recherche"></param>
        public MovieApi SearchOmdbapiMovie(string recherche)
        {
            string urlQuery = OMDBAPI_URL + "?s=" + recherche + "&apikey=" + API_KEY;

            //Création de la requête pour récupérer les films recherchés par l'utilisateur
            WebRequest query = HttpWebRequest.Create(urlQuery);
            query.Method = "GET";
            query.ContentType = "application/json";

            HttpWebResponse myHttpWebResponse = (HttpWebResponse)query.GetResponse();
            var responseStream = myHttpWebResponse.GetResponseStream();
            var reader = new StreamReader(responseStream);

            MovieApi movieApi = JsonConvert.DeserializeObject<MovieApi>(reader.ReadToEnd());

            return movieApi;
        }

        #region SearchCommand

        /// <summary>
        /// Méthode d'exécution de la commande <see cref="SearchCommand"/>.
        /// </summary>
        /// <param name="parameter">Paramètre de la commande. Ici ça être une chaine de charactère</param>
        protected override void Search(object parameter)
        {
            //recherche de l'utilisateur, récupérée dans la barre de recherche
            //reformatage de la recherche avec Trim qui vient supprimer les caractères non voulus en début et fin de chaine
            string research = parameter.ToString().ToLower().Trim();

            MovieApi resultMovieApi = (research != null && research != "") ? this.SearchOmdbapiMovie(research) : null;

            //on efface l'ancienne recherche avant d'afficher la nouvelle
            if (this.ItemsSource != null && this.ItemsSource.Count > 0)
            {
                this.ItemsSource.Clear();
            }
            this.ItemsSource = resultMovieApi.Search;
        }

        #endregion

        #region AddCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        protected override void Add(object parameter) 
        {

        }
        
        #endregion

        #endregion
    }
}

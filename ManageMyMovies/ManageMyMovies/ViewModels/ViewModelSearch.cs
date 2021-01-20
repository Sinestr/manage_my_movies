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
using ManageMyMovies.Models.Api.FullMovie;
using ManageMyMovies.Models;
using ManageMyMovies.MVVM.Models;

namespace ManageMyMovies.ViewModels
{
    /// <summary>
    /// Vue-modèle de la page de recherche d'un nouveau film à partir de l'api Omdbapi. 
    /// </summary>
    public class ViewModelSearch : ViewModelList<AdvancedApiMovie, IDataContext>, IViewModelSearch
    {
        #region Fields
        /// <summary>
        /// Clé secrète pour pouvoir exécuter une requête sur Omdbapi sans erreur
        /// </summary>
        const string API_KEY = "5ff6d345";

        /// <summary>
        /// Url du site de l'api
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
        /// Initialise une nouvelle instance de la classe <see cref="ViewModelSearch"/>
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
            //les données en arrivant sur cette page sont remises à 0
            this.ItemsSource = new ObservableCollection<AdvancedApiMovie>();
            this.SelectedItem = null;
        }

        #region SearchCommand
        /// <summary>
        /// Méthode d'exécution de la commande <see cref="SearchCommand"/>.
        /// </summary>
        /// <param name="parameter">Paramètre de la commande. Ici ça être une chaine de charactère (ImdbID)</param>
        protected override void Search(object parameter)
        {
            //recherche de l'utilisateur, récupérée dans la barre de recherche
            //reformatage de la recherche avec Trim qui vient supprimer les caractères non voulus en début et fin de chaine
            string research = parameter.ToString().ToLower().Trim();
            
            //execution d'une recherche basique de film (peu d'information sur les films retournés par la requête)
            MovieApi resultBasicMovieApi = (research != null && research != "") ? this.BasicSearchOmdbapiMovie(research) : null;
            //récupération de plus d'informations concernants les films recherchés
            RootOmdbApi rootOmdbApi = (resultBasicMovieApi != null && resultBasicMovieApi.Search != null) ? this.GetAdvancedSearchOmdbapiMovies(resultBasicMovieApi.Search) : null;

            //on efface l'ancienne recherche, avant d'afficher la nouvelle
            if (this.ItemsSource != null && this.ItemsSource.Count > 0)
            {
                this.ItemsSource.Clear();
            }

            //check si une recherche existe bien 
            //check si il y a au moins un film concerné par la recherche de l'utilisateur
            if (research != null && research != "" && rootOmdbApi != null)
            {
                this.ItemsSource = rootOmdbApi.AdvancedApiMovies;
            }
            else
            {
                //vide la collection de films recherchés
                this.LoadData();
            }
        }

        #endregion

        #region AddCommand
        /// <summary>
        /// Méthode d'exécution de la commande <see cref="AddCommand"/>
        /// Ajout du film que l'on veut ajouter à sa liste peronnelle de films
        /// </summary>
        /// <param name="parameter"> Identifiant du film qui veut être ajouté (Type String) </param>
        protected override void Add(object parameter) 
        {
            //vérification que l'identifiant du film à ajouter existe bien
            if (parameter != null && parameter.ToString().Length > 0)
            {
                string imdbId = parameter.ToString();
                //chargement de la liste des films présents dans le fichier de sauvegarde Json
                string dataTempJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataJson\\my_movies.json");
                UserMovieManagerContext userMovieManager = FileDataContext.Load<UserMovieManagerContext>(dataTempJsonPath, new UserMovieManagerContext(dataTempJsonPath)); 

                //check si il y a déjà un film ou non dans la collection de films
                if (userMovieManager != null)
                {
                    var userMovieList = new List<UserMovie>(userMovieManager.MyMoviesLibrary);
                    //check si le film qu'on veut ajouter n'est pas déjà présent dans la collection personelle de films
                    if (userMovieList.Find(movie => movie.ImdbID == imdbId) == null)
                    {
                        //ajout du film à la liste de l'objet à serializer
                        userMovieManager.MyMoviesLibrary.Add((UserMovie)this.GetAdvancedOmdbapiMovieById(imdbId, true));
                        //sérialisation du film à ajouter dans le fichier de sauvegarde
                        userMovieManager.Save();
                    }
                }
            }
        }

        #endregion

        #region ApiMethods
        /// <summary>
        /// Execute une requête de recherche de films sur l'api Omdbapi
        /// Cette recherche est faite par le titre d'un film
        /// Retourne peu d'informations sur les films retounés
        /// </summary>
        /// <param name="recherche">Titre d'un film (Type String)</param>
        public MovieApi BasicSearchOmdbapiMovie(string recherche)
        {
            //construction de l'url à appeler pour requêter Omdbapi et faire une recherche de films
            string urlQuery = OMDBAPI_URL + "?s=" + recherche + "&apikey=" + API_KEY;

            //création de la requête pour récupérer les films recherchés par l'utilisateur
            WebRequest query = HttpWebRequest.Create(urlQuery);
            query.Method = "GET";
            query.ContentType = "application/json";

            //execution de la requête
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)query.GetResponse();
            var responseStream = myHttpWebResponse.GetResponseStream();
            var reader = new StreamReader(responseStream);

            //retourne le résultat de recherche des films sous forme d'objet
            MovieApi movieApi = JsonConvert.DeserializeObject<MovieApi>(reader.ReadToEnd());
            return movieApi;
        }

        /// <summary>
        /// Permet de transformer le résultat de recherche avec des films plus garnis en données
        /// Execute une requête de recherche de films plus avancée sur l'api Omdbapi
        /// Retourne beaucoup d'informations sur les films retounés
        /// </summary>
        /// <param name="BasicMovies"> Collection de films recherché mais avec peu d'information</param>
        /// <returns></returns>
        public RootOmdbApi GetAdvancedSearchOmdbapiMovies(ObservableCollection<Search> BasicMovies)
        {
            //objet qui va contient une collection de films avec beaucoup d'informations
            RootOmdbApi rootOmdbApi = new RootOmdbApi
            {
                AdvancedApiMovies = new ObservableCollection<AdvancedApiMovie>()
            };

            foreach (Search BasicMovie in BasicMovies)
            {
                string imdbId = BasicMovie.ImdbID;
                AdvancedApiMovie advancedApiMovie = (AdvancedApiMovie)this.GetAdvancedOmdbapiMovieById(imdbId);
                rootOmdbApi.AdvancedApiMovies.Add(advancedApiMovie);
            }

            return rootOmdbApi;
        }

        /// <summary>
        /// Execute une requête pour récupérer des informations d'un film sur l'api Omdbapi
        /// Cette récupération de fait par l'idenfiant du film (récupéré notament à l'exécution de BasicSearchOmdbapiMovie)
        /// Donne beaucoup de détails sur un film
        /// </summary>
        /// <param name="imdbId"> Identifiant d'un film (Type string) </param>
        /// <param name="forMyMovies"> Permet de savoir si on retourne un objet pour sa liste de film ou pour la recherche</param>
        /// <returns> UserMovie | AdvancedApiMovie </returns>
        public object GetAdvancedOmdbapiMovieById(string imdbId, bool forMyMovies = false)
        {
            //construction de l'url à appeler pour requêter Omdbapi et récupérer beaucoup d'infos sur un film
            string urlQuery = OMDBAPI_URL + "?i=" + imdbId + "&apikey=" + API_KEY;

            //Création de la requête pour récupérer les films recherchés par l'utilisateur
            WebRequest query = HttpWebRequest.Create(urlQuery);
            query.Method = "GET";
            query.ContentType = "application/json";

            //execution de la requête
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)query.GetResponse();
            var responseStream = myHttpWebResponse.GetResponseStream();
            var reader = new StreamReader(responseStream);

            //en fonction du paramètre forMyMovies on retoune un type d'objet différent
            object result;
            if (forMyMovies)
            {
                //pour afficher sur la page de recherche d'un film
                UserMovie userMovie = JsonConvert.DeserializeObject<UserMovie>(reader.ReadToEnd());
                result = userMovie;
            }
            else
            {
                //pour afficher sur la page de gestion de sa liste personnelle de films
                AdvancedApiMovie advancedApiMovie = JsonConvert.DeserializeObject<AdvancedApiMovie>(reader.ReadToEnd());
                result = advancedApiMovie;
            }

            return result;
        }
        #endregion

        #endregion
    }
}

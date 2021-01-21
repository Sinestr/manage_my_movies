# Présentation générale
**Manage My Movies** est une application de recherche et de gestion de films / séries télévisées.
A travers cette application on retrouve une logique mise en place en `WPF` 
et organisée sur les principes du modèle `MVVM` (Modèle / Vue / Vue-Modèle).

La particularité de cette application c'est qu'elle utilise comme ressource de données, 
le webservice proposé par [Omdbapi.com](http://www.omdbapi.com/).

`ManageMyMovies` est une application `WPF net core 5.0`.

# Dépendances du projet
- [Mahapps.Metro](https://github.com/MahApps/MahApps.Metro) : Librairie graphique `WPF`.
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) : Librairie de sérialisation au format `JSON`.
- [Microsoft.Extensions.DependencyInjection](https://github.com/aspnet/Extensions) : Librairie d'injection de dépendance.
- CoursWPF.MVVM : Librairie `MVVM` pour `WPF` développée lors du cours.

# Architecture
L'architecture du projet repose sur les principes du modèles `MVVM`.
Le modèle définit trois couches :
- **Modèle** : Logique métier et données de l'application développée en langage `C#`
- **Vue** : Interface utilisateur développée en langage `XAML` et `C#`
- **Vue-modèle** : Logique de présentation développée en langage `C#`


## Modèle
En théorie, le modèle `MVVM` découpe la partie modèle en trois partie :
- **Modèle de présentation** : Classe de données compatible avec le système de binding. Prend en charge des éléments de présentation comme par exemple des propriétés calculées ou la validation de données.
- **Modèle de données** : Reflète le système de stockage de données.
- **Data Store** : Magasin de données.

### DataStore de l'application
L'application utilise un fichier de données `my_movies.json` unique au format `JSON`, il représente le `DataStore`.

### Modèle de données de l'application
Le modèle de données utilisé par l'application est découpé en deux parties. 
En effet, dans un premier temps, on trouve tous les models de données associés au données de l'API. 
Puis, on trouve une autre partie pour les données représentants la liste personnelle de films/séries. 
Ce qui donne :

####Modèles Partie API (Basique)
- **`MovieApi` : Représente l'objet d'une recherche classique de films Omdbapi**
  - `Identifier` : Identifiant unique d'un enregistrement
  - `Search` : Collection de films avec peu d'informations dessus
  - `TotalResults` : Nombre total de films/séries retournés par une requête vers Omdbapi
  - `Response` : Réponse de la requête api
  
- **`MovieApi` : Représente un film avec peu d'informations dessus**
    - `Identifier` : Identifiant unique d'un enregistrement
    - `Title` : Titre du film
    - `Year` : Année de sortie du film
    - `ImdbID` : Identifiant unique Omdbapi du film
    - `Type` : Genre du film
    - `Poster` : Affiche du film
    
####Modèles Partie API (Avancée)
- **`RootOmdbApi` : Représente l'objet d'une recherche avancée de films Omdbapi**
  - `Identifier` : Identifiant unique d'un enregistrement
  - `AdvancedApiMovies` : Liste des films avancés d'une recherche par omdbapi
  
- **`AdvancedApiMovie` : Représente un film avec beaucoup d'informations dessus**
    - `Identifier` : Identifiant unique d'un enregistrement
    - `Title` : Titre du film
    - `Year` : Année de sortie
    - `Rated` : Identifiant unique Omdbapi du film
    - `Released` : Date de sortie
    - `Runtime` : Durée en minutes
    - `Genre` : Genre du film
    - `Writer` : Auteur
    - `Actors` : Acteurs
    - `Plot` : Scénario, Courte description
    - `Country` : Pays
    - `Awards` : Récompenses
    - `Poster` : Affiche
    - `Ratings` : Liste des évaluations du film
    - `Metascore` : Metascore
    - `ImdbRating` : Note du film par omdbapi
    - `ImdbVotes` : Nombre de votes pour la note
    - `ImdbID` : Identifiant unique omdbapi du film
    - `Type` : Type
    - `DVD` : DVD
    - `BoxOffice` : Chiffre d'affaire
    - `Production` : Production, Studios ...
    - `Website` : Site web sur lequel on peut trouver le film
    - `Response` : Reponse de la requête (Booléen)
    
- **`Ratings` : Classe de données représentant une note d'un film avancé omdbapi**
    - `Identifier` : Identifiant unique d'un enregistrement
    - `Source` : Source de la notation
    - `Value` : Note sur 10 ou en pourcentage du film
  
  
####Modèles Partie Gestion de sa liste films/séries
- **`UserMovieManagerContext` : Contexte de données global sur lequel on s'appuie pour avoir une liste personnelle de films**
    - `Identifier` : Identifiant unique d'un enregistrement
    - `MyMoviesLibrary` : Collection des films que l'utilisateur a ajouté dans sa liste personnelle
  
- **`UserMovie` : Représente les données d'un film utilisateur**
    - `Identifier` : Identifiant unique d'un enregistrement
    - `Title` : Titre du film
    - `Year` : Année de sortie
    - `Rated` : Identifiant unique Omdbapi du film
    - `Released` : Date de sortie
    - `Runtime` : Durée en minutes
    - `Genre` : Genre du film
    - `Writer` : Auteur
    - `Actors` : Acteurs
    - `Plot` : Scénario, Courte description
    - `Country` : Pays
    - `Awards` : Récompenses
    - `Poster` : Affiche
    - `Ratings` : Liste des évaluations du film
    - `Metascore` : Metascore
    - `ImdbRating` : Note du film par omdbapi
    - `ImdbVotes` : Nombre de votes pour la note
    - `ImdbID` : Identifiant unique omdbapi du film
    - `Type` : Type
    - `DVD` : DVD
    - `BoxOffice` : Chiffre d'affaire
    - `Production` : Production, Studios ...
    - `Website` : Site web sur lequel on peut trouver le film
    - `Response` : Reponse de la requête (Booléen)    
    - `Watched` : Permet de savoir si le film a déjà été regardé
    - `Favorite` : Ajoute le film dans ses favoris
    
    
## Vue-modèle
### Injection des dépendances
Les vues-modèles ont été développés sur le principe de la dépendance faible.
Chaque vue-modèle ne connait donc pas l'instance concrète des autres vues-modèles ainsi que la classe concrète du contexte de données utilisés.
La seule dépendance forte réside dans l'utilisation des classes concrètes du modèles de données.

L'injection de dépendance nécessite pour chaque vue-modèle de déclarer une interface qui décrit le comportement attendu du vue-modèle.

Les vues-modèles sont déclarés dans le répertoire `.\ViewModels\` et les interfaces dans `.\ViewModels\Abstracts\`

L'injection des dépendances est réalisés de deux manières :
- Passage de l'ensemble des dépendances par contructeur
- Passage du `System.IServiceProvider` dans le constructeur pour permettre au vue-modèle de résoudre à tous moment ses dépendances.

#### Passage de l'ensemble des dépendances par contructeur
Par exemple, le vue-modèle `ViewModelSearch` ne dépend que d'un `IDataContext`.
La résolution de cette dépendance n'est pas réalisée par le vue-modèle lui-même mais par la classe qui instancie le vue-modèle.

``` csharp
public ViewModelSearch(IDataContext dataContext) : base(dataContext)
{
    this.LoadData();
}
```

``` csharp
private void Application_Startup(object sender, StartupEventArgs e)
{
    FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
    ServiceCollection serviceCollection = new ServiceCollection();  
    [...]
    serviceCollection.AddTransient<IViewModelSearch, ViewModelSearch>(sp => new ViewModelSearch(sp.GetService<IDataContext>()));
    [...]
}
```

#### Passage du `System.IServiceProvider` dans le constructeur
Par exemple, le vue-modèle `ViewModelMain` dépend que directement d'un `IServiceProvider`.
Ceci permet au vue-modèle ensuite de demander au fournisseur de service de résoudre ses dépendances.

``` csharp
public ViewModelMain(IServiceProvider serviceProvider) : base(serviceProvider.GetService<IDataContext>())
{
    //récupération des services initialisés dans l'app.xml
    this._ServiceProvider = serviceProvider;

    //initialisation des sous vue-modèles du viewModelMain
    this._ViewModelSearch = this._ServiceProvider.GetService<IViewModelSearch>();
    this._ViewModelMyMovies = this._ServiceProvider.GetService<IViewModelMyMovies>();
    
    this._ExitCommand = new RelayCommand(this.ExitApplication, this.CanExitApplication);
    this.LoadData();
}
```

``` csharp
private void Application_Startup(object sender, StartupEventArgs e)
{
    FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
    ServiceCollection serviceCollection = new ServiceCollection();  

    //Création du contexte de données de l'application.
    string dataJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataJson\\my_movies.json");
    serviceCollection.AddSingleton<IDataContext, UserMovieManagerContext>(sp => FileDataContext.Load(dataJsonPath, new UserMovieManagerContext(dataJsonPath)));

    //Création du vue-modèle principal.
    serviceCollection.AddTransient<IViewModelMain, ViewModelMain>(sp => new ViewModelMain(sp));
    [...]
}
```

#### Gestion des instances par le fournisseur de service
L'ensemble des services des vues-modèles sont déclarés avec la méthode `AddTransient`, ce qui signifie qu'à chaque résolution, le fournisseur de service retourne une nouvelle instance du vue-modèle demandé.
Par contre, le contexte de données doit être commun à l'ensemble de l'application, le service est donc déclaré avec la méthode `AddSingleton`, ce qui signifie qu'à chaque résolution, le fournisseur de service retoune l'instance unique du contexte de données.
``` csharp
private void Application_Startup(object sender, StartupEventArgs e)
{
    FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
    ServiceCollection serviceCollection = new ServiceCollection();  
    [...]
    //Création du vue-modèle principal.
    serviceCollection.AddTransient<IViewModelMain, ViewModelMain>(sp => new ViewModelMain(sp));
    serviceCollection.AddTransient<IViewModelSearch, ViewModelSearch>(sp => new ViewModelSearch(sp.GetService<IDataContext>()));
    serviceCollection.AddTransient<IViewModelMyMovies, ViewModelMyMovies>(sp => new ViewModelMyMovies(sp.GetService<IDataContext>()));

    ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

    MainWindow window = new MainWindow();
    window.DataContext = serviceProvider.GetService<IViewModelMain>();
    window.Show();
}
```

### Architecture
Les vues-modèles respectent l'architecture suivante :

``` xml
<ViewModelMain>
  <ViewModelMain.ItemsSource>
    <ViewModelSearch/>
    <ViewModelMyMovies/>
  </ViewModelMain.ItemsSource>    
</ViewModelMain>
```

### Vue-modèle `ViewModelMain`
Ce vue-modèle hérite de la classe `ManageMyMovies.MVVM.ViewModels.ViewModelList<IObservableObject, IDataContext>`.

Il dispose donc d'une collection observable `ItemsSource` et d'un `SelectedItem` de type `IObservableObject` ainsi que du contexte de données.
Ce dernier ne sera pas réèlement utilisé puisque `ViewModelMain` est un vue-modèle structurel (utilisé pour structurer l'interface graphique).

#### Fermeture de l'application
Le vue-modèle expose et implémente la commande `ExitCommand` qui permet de fermer l'application :
``` csharp
public class ViewModelMain : ViewModelList<IObservableObject, IDataContext>, IViewModelMain
{
    #region Fields
    [...]
    private readonly RelayCommand _ExitCommand;

    #endregion

    #region Properties
    [...]
    public RelayCommand ExitCommand => this._ExitCommand;

    #endregion

    #region Constructors

    public ViewModelMain(IServiceProvider serviceProvider)
        : base(serviceProvider.GetService<IDataContext>())
    {
        [...]
        this._ExitCommand = new RelayCommand(this.Exit, this.CanExit);
        [...]
    }

    #endregion

    #region Methods
    [...]
    #region ExitCommand

    protected virtual bool CanExit(object parameter) => true;

    protected virtual void Exit(object parameter)
    {
        App.Current.Shutdown(0);
    }

    #endregion

    #endregion
}
```

La commande est accessible dans le menu principal de l'application.
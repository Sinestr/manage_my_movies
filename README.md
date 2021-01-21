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
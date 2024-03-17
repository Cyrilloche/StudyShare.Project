# StudyShare.Project

StudyShare.Project est un projet en cours de développement réalisé en C# et ASP.NET. Il s'agit d'un gestionnaire de documents électroniques (GED) conçu pour faciliter le partage de ressources pédagogiques entre étudiants.

## Fonctionnalités Principales

- **Authentification** :
  - Les utilisateurs peuvent s'inscrire, se connecter et se déconnecter.
  - Fonctionnalité de récupération de mot de passe en cas d'oubli.

- **Gestion de Profil** :
  - Les utilisateurs peuvent modifier leur profil, y compris leur mot de passe, adresse e-mail, nom, prénom, classe et école.

- **Gestion de Documents** :
  - Les utilisateurs peuvent uploader des documents.
  - Chaque document peut avoir un titre, jusqu'à 10 mots-clés, un ou plusieurs niveaux (ex: CE1 + CE2), une école associée, et peut être ajouté en favoris.
  - Les utilisateurs peuvent supprimer, partager, imprimer et télécharger des documents.
  - Possibilité de modifier la visibilité des documents.

- **Recherche et Filtrage** :
  - Les utilisateurs peuvent rechercher des documents par mots-clés, date, niveau de classe, école, auteur et titre.
  - Possibilité de trier les résultats de recherche par favoris ou récents.

- **Organisation** :
  - Les utilisateurs peuvent créer des dossiers pour organiser leurs documents.

## Installation et Configuration

1. Clonez le dépôt GitHub :

``` git clone https://github.com/Cyrilloche/StudyShare.Project.git ```

2. Ouvrez le projet dans Visual Studio Code.

3. Configurez les paramètres de connexion à la base de données dans le fichier `appsettings.json`.

4. Lancez l'application depuis Visual Studio Code.

## Technologies Utilisées

- C#
- ASP.NET
- Entity Framework Core (pour la gestion de la base de données)



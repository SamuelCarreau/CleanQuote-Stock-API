THE CLEAN QUOTE API
===================

Pour compléter ce test, vous devez implanter une API HTTP REST qui va retourner des données boursières. 

Vous avez çi-joint le fichier `quotes.csv` qui contient les données nécessaires. Pas besoin de vous intégrer avec les services de Google ou Yahoo Finance.

Votre API doit implanter la(es) ressource(s) HTTP REST nécessaire(s) afin de pouvoir servir les fonctionnalités suivantes: 
* Retourner les informations de base sur tous les titres boursiers (ex: symbol, name, price).
* Appliquer un filtre pour retirer les titres qui ont moins de X$ en variation journalière (ex: daily change < 1$).
* Appliquer un filtre pour retirer les titres qui sont en devise différente de la devise spécifiée (ex: currency=USD retire CAD).
* Appliquer un filtre pour retirer les titres qui ont une capitalisation boursière de moins de X milliards de dollars (Market Cap > 100B$).
* Pouvoir appliquer un ou plusieurs des filtres cités plus haut dans une requête.


Voici un exemple d'appel et de réponse pour l'API:
```
curl http://localhost:8080/stock/quotes/?currency=USD
[
    {
        "symbol": "AAPL",
        "name": "APPLE",
        "price": 157.45,
        "date": 2019-01-25
    },
    ...
]
```

Nous vous recommandons fortement d'utiliser un des langages de programmation ou plateformes suivants:
* Node.js
* Python (Flask)
* Java (Jersey)
* Ruby on Rail
* ASP.NET (Web API 2 & C#)

Quelques points importants:
* N'hésitez pas à ajouter des commentaires pour vous assurer que nous pouvons comprendre vos décisions et assumptions. Il est de votre responsabilité de clarifier les points qui ne sont pas évidents en nous posant des questions.
* Les valeurs de capitalisation boursière sont déjà en milliards (Billions) de dollars dans le fichier `quotes.csv`.
* Vous devez lire le fichier quote.csv, par contre, évitez de le relire à chaque fois que vous recevez une requête.

Nous nous attendons que les règles de l'art du génie logiciel seront respectées et vous serez évalué sur les points suivants:
* Le respect des besoins du client.
* L'architecture de la solution.
* La bonne utilisation des concepts de l'orienté objet.
* Les tests automatisés.
* Les standards de qualité du Clean Code.

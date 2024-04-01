# Games Api
An ASP.NET Core API using Entity Framework covering CRUD functionality for games, genres and associated reviews.

## Endpoints - {baseurl}/games

GET - {baseurl}/games :

```
[
    {
        "id": 1,
        "name": "Super Mario Bros.",
        "genre": "Kids and Family",
        "price": 55.0,
        "releaseDate": "1985-11-13"
    },
    {
        "id": 2,
        "name": "Halo",
        "genre": "Fighting",
        "price": 99.0,
        "releaseDate": "2001-11-15"
    },
    {
        "id": 3,
        "name": "Forza",
        "genre": "Racing",
        "price": 58.0,
        "releaseDate": "2005-05-03"
    }
]
```

GET - {baseurl}/games/id :

```
[
    {
        "id": 1,
        "name": "Super Mario Bros.",
        "genre": "Kids and Family",
        "price": 55.0,
        "releaseDate": "1985-11-13"
    },
]
```

POST - {baseurl}/games :

```
[
    {
        "name": "Need for Speed",
        "genre": "Kids and Family",
        "price": 55.0,
        "releaseDate": "1994-08-31"
    }
]
```

PUT - {baseurl}/games/id :

```
[
    {
        "name": "Need for Speed",
        // "genre": "Kids and Family", //
        "genre": "Racing",
        "price": 55.0,
        "releaseDate": "1994-08-31"
    }
]
```

DEL - {baseurl}/games/id

## Endpoints - {baseurl}/genres

GET - {baseurl}/genres :

```
[
    {
        "id": 1,
        "name": "Fighting"
    },
    {
        "id": 2,
        "name": "Roleplaying"
    },
    {
        "id": 3,
        "name": "Sports"
    },
    {
        "id": 4,
        "name": "Racing"
    },
    {
        "id": 5,
        "name": "Kids and Family"
    }
]
```
## Endpoints - Reviews

GET - {baseurl}/games/id/reviews :

```
[
    {
        "id": 1,
        "gameId": 3,
        "stars": 3,
        "description": "Ok"
    },
    {
        "id": 2,
        "gameId": 3,
        "stars": 5,
        "description": "Fantastic"
    },
    {
        "id": 3,
        "gameId": 3,
        "stars": 1,
        "description": "Poor"
    }
]
```

POST - {baseurl}/games/reviews :

```
{
    "gameId":3,
    "stars":3,
    "description":"Good graphics but slow story"
}
```

PUT - {baseurl}/games/reviews/3

```
{
    "gameId":3,
    "stars":4,
    "description":"Good graphics, story gradually gets better"
}

DEL - {baseurl}/games/reviews/3
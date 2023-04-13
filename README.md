# _Message Board API_

#### By _Geoffrey Gao_

#### _An API to track groups and messages_

## Technologies Used

* _C#_
* _ASP.Net Core MVC_
* _Entity Framework Core_
* _MySQL_

## Description

_This repo contains an API that corresponds to a databse of message board groups and messages. The project demonstrates solid understanding of the new concepts from the Building an API coursework including MVC, SQL, and Entity Framework Core._

## Install Tools

_Install the `dotnet -ef` tool by running thef ollowing command in your terminal_

_`dotnet tool install --global dotnet-ef --version 6.0.0`_

## Setup/Installation Requirements

* _Clone this repository_
* _Open your shell (e.g., Terminal or GitBash) and navigate into the "MessageBoardApi.Solution" production directory_
  - _Within the production directory "MessageBoardApi.Solution", create a new file called `appSettings.json`. Within this file, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL_
```JSON
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=messageboard_api;uid=[USERNAME];pwd=[PASSWORD];"
  }
}
```
* _Create the database using the migrations in the MessageBoardApi project. Open your shell (e.g., Terminal or GitBash) to the production directory "MessageBoardApi.Solution", and run `dotnet ef database update`._ 
* _In the terminal, run the program with `dotnet watch run` to start the project in development mode with a watcher_
* _If the application does not automatically launch, open the browser to [https://localhost:5001](https://localhost:5001)_

## Known Bugs

* _N/A_

## License

_MIT_

Copyright (c) _2023_ _Geoffrey Gao_
# Lab: 12 - Intro to EFCore & APIs

Lab: 12 - Intro to EFCore & APIs

*Author: Lami Beach*

----

## Description
This app is to showcase building and deploying a database for a WebApp.
The application is a mock Hotel chain that contains databases of the Hotels: locations, addresses, phone numbers, city, state, and so on.
The application also contains specifics for Hotel Rooms: rooms, amenities, nick names, and whether they're pet friendly or not.
The goal was to build a database of tables and create an API that can do CRUD/REST operations and return the above information to the user.
The application also includes Authorization using JWT Newtonsoft. The only authorized head user is the District Manager. Followed by Property Manager. Followed by Agent.
---

### Getting Started
Clone this repository to your local machine.

```
$ git clone https://github.com/Omac092627/AsyncInn.git
```

### To run the program from Visual Studio:
Select ```File``` -> ```Open``` -> ```Project/Solution```

Next navigate to the location you cloned the Repository.

Double click on the ```AsyncInn``` directory.

Then select and open ```AsyncInn.sln```

Use `Install-Package Microsoft.EntityFrameworkCore.SqlServer` in the project manager console to install SQL server into the project

Use `Install-Package Microsoft.EntityFrameworkCore.Tools` in the project manager console to give you access to the database tools.

---

### Visuals
- ![ERD](/Assets/images/AsyncInn2Flow.png) <sub>Code Fellows Class D11</sub>



![ERD2](/Assets/images/[ERD]AsyncInn.png)

---


### Visuals
- [ERD (pdf)](Assets/AsyncInnERDExplained(1).pdf)


---

### Change Log
- 2.0: Added UnitTesting/SeedAdminData/Roles
- 1.9: Added Authorization
- 1.8: Added RoleInitializers
- 1.7: Added DTOs
- 1.6: Added proper routing
- 1.5: Added interfaces, sources(repositories), changed controller actions
- 1.4: Controllers Created and tested
- 1.3: DB seeded
- 1.2: Model Classes and DbContext Created
- 1.1: Readme and Photos
- 1.0: Repo Setup


------------------------------
For more information on Markdown: https://www.markdownguide.org/cheat-sheet
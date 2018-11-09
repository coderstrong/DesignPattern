# DesignPattern
Design Pattern basic implement

The main purpose of Infrastructure project is to perform database operations. Besides database operations, it can also consume web services, perform IO operations etc. So mainly, Infrastructure project may perform the following operations:

Database operations
Working with WCF and Web Services
IO operations
We can use any database technology to perform database operations. In this post, we are going to use Entity Framework. So we are going to create a database using the Code First approach. In the Code First approach, the database gets created on basis of the classes. Here database will be created on the basis of the Domain entities from the Core Project.

To create the database from the Core project domain entity, we need to perform these tasks:

Create DataContext class
Configure the connection string
Create DataBase Initializer class to seed data in the database
Implement IProductRepsitory interface
 

Adding References

First, let’s add references to the Entity Framework and ProductApp.Core project. To add the Entity Framework, right click on the Infrastructure project and click on Manage Nuget Package. In the Package Manager Window, search for Entity Framework and install the latest stable version.

To add a reference of the ProductApp.Core project, right click on the Infrastructure project and click on Add Reference. In the Reference Window, click on the Project tab and select ProductApp.Core.

DataContext class

The objective of the DataContext class is to create the DataBase in the Entity Framework Code First approach. We pass a connection string in the constructor of DataContext class. By reading the connection string, the Entity Framework creates the database. If a connection string is not specified then the Entity Framework creates the database in a local database server.

In the DataContext class:

Create a DbSet type property. This is responsible for creating the table for the Product entity
In the constructor of the DataContext class, pass the connection string to specify information to create a database, for example, server name, database name, login information etc. We need to pass the name of the connection string. name where the database would be created
If connection string is not passed, Entity Framework creates with the name of data context class in the local database server.
The productdatacontext class inherits the DbContext class
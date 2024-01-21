# Sync Databases

Manage and sync customers data between a SQL DB and a NoSQL DB

## About

The Sync Databases project is an ASP.NET Core application designed to synchronize and display customer data from both MySQL and MongoDB databases. It consists of three main components:

1. **FrontEnd:** An ASP.NET Core MVC application that serves as the user interface for interacting with customer data. It includes functionality to add and display customer data from MySQL and MongoDB, and sync databases.

2. **MySqlController:** A controller responsible for interacting with the MySQL database. It includes methods to retrieve existing customer data, insert and delete customer records.

3. **MongoController:** A controller responsible for interacting with the MongoDB database.

The project aims to showcase integration with both relational (MySQL) and no relational (MongoDB) databases within a single application.

## Features

- Display customer data from MySQL and MongoDB in a unified interface.
- Add customers and synchronize the data across both databases.
- Separate controllers for MySQL and MongoDB database operations.

## Getting Started

### How it works
- You can add a customer filling the form
![Add Customer](https://github.com/DimitriMll/DimitriMll/blob/main/assets/addCustomer.png?raw=true)
- Then it will be displayed as it follows
![Database](https://github.com/DimitriMll/DimitriMll/blob/main/assets/databases.png?raw=true)
- Then you can sync the databases clicking the "Sync Databases" button
![Sync Databases](https://github.com/DimitriMll/DimitriMll/blob/main/assets/syncDatabases.png?raw=true)

### Prerequisites

[<img src="https://github.com/devicons/devicon/blob/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="25" height="25"/>](https://dotnet.microsoft.com/) [.NET Core SDK](https://dotnet.microsoft.com/download)

[<img src="https://github.com/devicons/devicon/blob/master/icons/mongodb/mongodb-original-wordmark.svg" alt="mongo" width="25" height="25"/>](https://www.mongodb.com/try/download/community) [MongoDB](https://www.mongodb.com/try/download/community)

[<img src="https://github.com/devicons/devicon/blob/master/icons/mysql/mysql-original-wordmark.svg" alt="mysql" width="25" height="25"/>](https://dev.mysql.com/downloads/mysql) [MySQL Server](https://dev.mysql.com/downloads/mysql)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/DimitriMll/Project1.git

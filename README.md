# Project1 -> Sync Databases

Manage and sync customers data between a SQL DB and a NoSQL DB

## About

The Sync Databases project is an ASP.NET Core application designed to synchronize and display customer data from both MySQL and MongoDB databases. It consists of three main components:

1. **FrontEnd:** An ASP.NET Core MVC application that serves as the user interface for interacting with customer data. It includes functionality to add, edit and delete customers, display customer data from MySQL and MongoDB, and sync databases.

2. **MySqlController:** A controller responsible for interacting with the MySQL database. It includes methods to retrieve existing customer data, insert and delete customer records.

3. **MongoController:** A controller responsible for interacting with the MongoDB database.

The project aims to showcase integration with both relational (MySQL) and no relational (MongoDB) databases within a single application.

## Features

- Display customer data from MySQL and MongoDB in a unified interface.
- Add, edit and delete customers and synchronize the data across both databases.
- Separate controllers for MySQL and MongoDB database operations.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community)
- [MySQL Server](https://dev.mysql.com/downloads/mysql)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/DimitriMll/Project1.git

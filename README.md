# GoodAPI

GoodAPI is a .NET Core 7.0 web API for registering and managing medicines. It utilizes Entity Framework Core for database interactions and RabbitMQ for message queuing, ensuring efficient processing and management of data.

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Features

- Register, update, delete, and retrieve medicine records.
- Seamless integration with Entity Framework Core for database management.
- Asynchronous processing using RabbitMQ.
- Clear separation of concerns through project structure.

## Technologies

- .NET 7.0
- Entity Framework Core
- SQL Server
- RabbitMQ
- Swagger for API documentation

## Getting Started

### Prerequisites

- [.NET SDK 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [RabbitMQ](https://www.rabbitmq.com/download.html)
- [Postman](https://www.postman.com/) (optional for testing)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/GoodAPI.git
   cd GoodAPI

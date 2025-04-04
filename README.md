# Ecommerce con Clean Architecture en .NET 8 🛒
Este proyecto es un sistema de ecommerce desarrollado con .NET 8, siguiendo los principios de Clean Architecture para garantizar un código modular, mantenible y escalable. Se implementaron tecnologías como Entity Framework Core (para el acceso a datos), JWT (para autenticación) y MediatR (para el patrón Mediator y CQRS).

#

📌 Características Principales

✅ Autenticación JWT (registro, login, autorización por roles).

✅ Gestión de productos (CRUD, búsqueda, filtrado).

✅ Carrito de compras (agregar, eliminar).

✅ Pedidos (creación, historial, actualización de estado).

✅ Patrón CQRS para separar consultas y comandos.

#

⚙️ Estructura del Proyecto (Clean Architecture)

El proyecto está organizado en capas siguiendo Clean Architecture:

1️⃣ Dominio (Domain Layer)

Entidades: User, Product, Order, Cart, Category.

Interfaces de repositorio: IUserRepository, IProductRepository, etc.

2️⃣ Aplicación (Application Layer)

Casos de uso: Implementados como Commands y Queries usando MediatR.

3️⃣ Infraestructura (Infrastructure Layer)

Entity Framework Core: Configuración de DbContext y repositorios.

Identity + JWT: Autenticación con tokens JWT.

4️⃣ Presentación (Presentation Layer - API)

Controladores RESTful: UsersController, ProductsController, OrdersController.

Swagger/OpenAPI: Documentación interactiva.

#

🚀 Tecnologías Utilizadas

.NET 8 (ASP.NET Core Web API)

Entity Framework Core (Code-First + Migrations)

JWT Authentication (Identity + Bearer Tokens)

MediatR (CQRS Pattern)

Swagger/OpenAPI (Documentación)

SQLite (Base de datos)

#

🔐 Autenticación JWT

El sistema usa JWT (JSON Web Tokens) para seguridad:

Registro: POST /api/users/register

Login: POST /api/users/login

Endpoints protegidos: Requieren el header Authorization: Bearer {token}.

#

📚 Documentación de Endpoints

A continuación se detallan todos los endpoints disponibles en la API, organizados por controlador.


🛒 CartController (/api/cart)

Gestiona el carrito de compras de los usuarios.

GET --	/api/cart/{userId} --	Obtiene el carrito de un usuario por su ID.	

POST --	/api/cart --	Agrega un producto al carrito.	

DELETE --	/api/cart --	Elimina un producto del carrito.	


📦 OrderController (/api/order)

Gestiona pedidos de los usuarios.

GET --	/api/order/{userId} --	Obtiene los pedidos de un usuario. 

POST --	/api/order --	Crea un nuevo pedido.	

PUT --	/api/order/{orderId} --	Actualiza el estado de un pedido (solo admin). 


📱 ProductController (/api/products)

Gestiona productos del catálogo.

GET -- 	/api/products	Busca productos por filtros -- (nombre, categoría).

GET --	/api/products/{id} --	Obtiene un producto por su ID.

POST --	/api/products -- Crea un nuevo producto (solo admin).

PUT --	/api/products/{id} -- Actualiza un producto (solo admin).

DELETE --	/api/products/{id} --	Elimina un producto (solo admin).


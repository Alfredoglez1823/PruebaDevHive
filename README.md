# PruebaDevHive

# Introducción:
El proyecto fue desarrollado utilizando tecnologías como ASP.NET MVC para la parte web, ASP.NET Web API para la API RESTful, xUnit para las pruebas unitarias y Azure como plataforma de alojamiento para la base de datos con SQL Server.

# Descripción del Proyecto:
El proyecto consiste en una aplicación web ASP.NET MVC que muestra información sobre inmuebles en la Ciudad de México. La aplicación incluye una página principal que lista todos los inmuebles y una página detallada para cada inmueble que muestra información adicional.

# Implementación de la Aplicación Web ASP.NET MVC:
En la aplicación web, se utiliza ASP.NET MVC para consumir la API RESTful creada. La página principal muestra una lista de todos los inmuebles obtenidos de la API y permite acceder a la página detallada de cada inmueble. Esta página detallada muestra información como el nombre, dirección, teléfono y capacidad de aforo del inmueble seleccionado.

# Implementación de la API RESTful:
La API RESTful fue desarrollada utilizando ASP.NET Web API y alojada en un servidor. Se implementaron las operaciones solicitadas, incluyendo obtener la lista de todos los inmuebles, obtener un inmueble por ID, crear un nuevo inmueble, actualizar un inmueble existente (opcional) y eliminar un inmueble existente (opcional). Además, se utilizó el patrón repository para acceder a la base de datos en Azure mediante Entity Framework. La API cumple con los estándares RESTful y utiliza el protocolo HTTP para enviar y recibir datos. Se configuró CORS para permitir el acceso desde diferentes dominios.

# Pruebas y Validación:
Se realizaron pruebas unitarias utilizando xUnit para garantizar el correcto funcionamiento de la aplicación web y la API. Además, se realizaron pruebas de integración utilizando herramientas como Postman para asegurar que todas las funcionalidades funcionen correctamente.

# Conclusiones:
El proyecto logró cumplir con los requisitos establecidos, utilizando tecnologías modernas y buenas prácticas de desarrollo como el uso de patrones de diseño y pruebas unitarias. Se logró una integración exitosa entre la aplicación web y la API, brindando una experiencia fluida al usuario final y garantizando la confiabilidad y seguridad de los datos.

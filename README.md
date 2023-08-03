# RedarborTechnicalTest
Desarrollo pureba tecnica para la empresa Redarbor

1. Se contruye la aplicación en .Net 6 implementado la arquitectura clean architecture el proyecto tiene el nombre de RedarborTechnicalTest.
2. Se crea un proyecto Web Api "RedarborTechnicalTest.Api" el cual contiene los controladores, Middlewares(para poder realizar las excepciones personalizadas) y un carpeta de contrato para las rutas.
3. Se crea un proyecto de biblioteca de clases "RedarborTechnicalTest.Core" el cual tiene toda la logica del negocio "servicios, interfaces, excepciones, mappings y las entidades de negocio y dtos"
4. Se implementa el patron CQRS para la lectura y escritura de cada metodo, se encuentra el la carpeta services.Commands, services.EventHandles y services.Querys.
5. Se implementa el patron repositorio generico para las consultas y para los metodos de escritura.
6. Se trabaja con EntityFrameworkCore para los metodos de escritura y Dapper para los metodos de lectura (desde la clases GenericRepository).
7. Se realiza 5 pruebas unitarias cada una para un metodo GET, GETById, POST, PUT, DELETE en el proyecto RedarborTechnicalTest.UnitTestApi.

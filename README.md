# Examen T2 - Desarrollo de Servicios Web I
Examen T2 - Desarrollo de Servicios Web I. API RESTful con Arquitectura Hexagonal (.NET 8) y MySQL.

**Alumno:** Lucas Alonso Escalante Delgado
**Curso:** Desarrollo de Servicios Web I
**Evaluación:** T2 (Arquitectura Hexagonal)

## 📋 Descripción del Proyecto

API RESTful desarrollada con **ASP.NET Core 8** y **Entity Framework Core** utilizando **MySQL**.

El proyecto implementa una **Arquitectura Hexagonal** completa, separando el código en capas (Domain, Application, Infrastructure, API) para la gestión de una Biblioteca Universitaria (Libros y Préstamos), cumpliendo con reglas de negocio y patrones de diseño.

## 🛠️ Tecnologías Utilizadas

* **.NET 8.0** (ASP.NET Core Web API)
* **Arquitectura Hexagonal** (Puertos y Adaptadores)
* **Entity Framework Core** (MySQL / Pomelo)
* **AutoMapper** (Mapeo de DTOs)
* **Swagger UI** (Documentación de la API)
* **Patrón Repositorio y Unit of Work**

## 🚀 Instrucciones de Instalación y Ejecución

Siga estos pasos para ejecutar el proyecto correctamente en su entorno local:

### 1. Base de Datos (MySQL)

El sistema requiere una base de datos MySQL llamada `library_db`.

1.  Abra **MySQL Workbench**.
2.  Abra el archivo **`script_database.sql`** que se encuentra en la raíz de este repositorio.
3.  Ejecute todo el script (Rayo ⚡) para crear la base de datos y las tablas necesarias.

### 2. Configuración de la Conexión (appsettings.json)

1.  Abra la solución **`DSW1_T2_EscalanteDelgadoLucasAlonso.sln`** en Visual Studio 2022.
2.  Navegue al proyecto **`Library.API`** y abra el archivo **`appsettings.json`**.
3.  Verifique que la cadena de conexión `DefaultConnection` tenga su usuario y contraseña correctos de MySQL:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=library_db;User=root;Password=SU_CONTRASEÑA;"
}```

### 3. Ejecutar la API
Asegúrese de que el proyecto Library.API esté establecido como proyecto de inicio (clic derecho > Set as Startup Project).

Presione ▶️ Ejecutar (o F5) en Visual Studio.

Se abrirá automáticamente Swagger UI en su navegador (puerto 7065).

URL Local: https://localhost:7065/swagger

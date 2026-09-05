# Cajero automático en C# y SQLite

Aplicación de consola que simula las operaciones básicas de un cajero automático. El proyecto integra una interfaz por menús, lógica de negocio y persistencia de datos con SQLite.

## Funcionalidades

- Acceso y navegación mediante menús.
- Consulta y gestión de operaciones bancarias básicas.
- Persistencia local de datos con SQLite.
- Separación del código en capas de lógica, modelos, base de datos e interfaz.
- Inicialización de la base de datos mediante scripts SQL.

## Tecnologías

- C#
- .NET
- Microsoft.Data.Sqlite
- SQLite

## Estructura principal

- `Base_de_Datos/`: acceso y configuración de datos.
- `Logica/`: reglas y operaciones del sistema.
- `Modelos/`: entidades utilizadas por la aplicación.
- `UI/`: interacción con el usuario.
- `Scripts/`: scripts de inicialización de SQLite.

## Ejecución

Requisitos: Git y el SDK de .NET.

```bash
git clone https://github.com/iCreb2512/cajero-automatico.git
cd cajero-automatico
dotnet restore
dotnet run
```

## Autor

Desarrollado por [Edwin Contreras](https://github.com/iCreb2512) como proyecto académico de programación.

# Mesa de Partes Digital – Prototipo (Windows Forms)

Prototipo académico del curso **Fundamentos de Programación (CIIN1205P)** – UPN.
Desafío: *Del archivador al algoritmo, un prototipo para la mesa de partes digital*.

Aplicación de escritorio en **C# con Windows Forms (.NET 10)** que permite **registrar, validar, buscar,
ordenar y almacenar** expedientes en un archivo de texto.

## Cómo abrirlo

1. Instalar **Visual Studio 2026** (incluye .NET 10) con la carga de trabajo *Desarrollo de escritorio de .NET*.
2. Abrir Visual Studio → *Abrir un proyecto o solución* → elegir `MesaPartesDigital.sln` y presionar **F5** (Iniciar).

También se puede ejecutar con el SDK de .NET 10 en Windows: `dotnet run --project MesaPartesDigital`.

Los registros se guardan en `expedientes.txt`, junto al ejecutable (carpeta `bin/Debug/net10.0-windows/`).
Para probar con datos ficticios, copie `datos_ejemplo/expedientes_ejemplo.txt` a esa carpeta con el nombre `expedientes.txt`.

## Estructura

| Archivo | Contenido |
|---|---|
| `Form1.cs` | Eventos de los botones, validación del formulario y llenado de la tabla |
| `Form1.Designer.cs` | Diseño del formulario (controles y sus nombres) |
| `Validaciones.cs` | Validación y limpieza de cadenas de caracteres |
| `Almacen.cs` | Arreglos paralelos, búsqueda (lineal y binaria) y ordenamiento por selección |
| `Archivos.cs` | Persistencia en archivo de texto (`codigo\|ciudadano\|tipo\|asunto\|fecha\|estado`) |
| `docs/` | Diagramas de flujo y pseudocódigo |

## Controles principales

`txtCodigo`, `txtCiudadano`, `cmbDocumento`, `txtAsunto`, `dtpFecha`, `btnRegistrar`, `txtBuscar`,
`btnBuscar`, `btnMostrarTodos`, `btnOrdenar`, `dgvExpedientes`.

> Usar solo datos ficticios. Este prototipo no reemplaza un sistema institucional (sin usuarios, seguridad ni base de datos).

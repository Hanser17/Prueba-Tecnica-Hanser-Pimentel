# Sistema de Aprobación de Solicitudes

## Descripción

Sistema desarrollado para automatizar el proceso de aprobación de solicitudes de compra dentro de una empresa.

El sistema evalúa automáticamente cada solicitud y determina si:

* La solicitud es aprobada automáticamente.
* La solicitud requiere aprobación manual.
* La solicitud es rechazada.

La solución fue diseñada siguiendo principios de **Clean Architecture** y **SOLID**, especialmente el principio **Open/Closed**, permitiendo agregar nuevas reglas de negocio sin modificar las existentes.

---

# Arquitectura del Proyecto

```text
SRC
│
├── Client
│   └── Aplicación React encargada de la interfaz de usuario.
|   └── Restfull API.
│
├── Domain
│   ├── Entidades
│   ├── Enumeraciones
│   ├── Reglas de negocio
│   ├── Approval Engine
│   └── Objetos de dominio
│
├── Services
│   ├── API ASP.NET Core
│   ├── DTOs
│   ├── Servicios de aplicación
│   └── Configuración de dependencias
│
├── Test
│   └── Pruebas unitarias del dominio
│
└── IntegrationTests
    └── Pruebas de integración utilizando TestServer y WebApplicationFactory.
```

---

# Tecnologías utilizadas

## Backend

* .NET 8
* ASP.NET Core Web API
* Dependency Injection
* xUnit
* Data Anotation

## Frontend

* React
* Vite
* CSS3

## Testing

* xUnit
* Microsoft.AspNetCore.Mvc.Testing
* TestServer
* WebApplicationFactory

---

# Reglas de Negocio

## Regla 1

Si:

```text
Monto > Presupuesto
```

Resultado:

```text
Rechazado
```

---

## Regla 2

Si:

```text
Antigüedad < 1 año
y
Monto > 500
```

Resultado:

```text
Aprobación Manual
```

---

## Regla 3

Si:

```text
Tipo de compra = Equipos
y
Monto > 3000
```

Resultado:

```text
Aprobación Manual
```

---

## Regla 4

Si:

```text
Departamento = Finanzas
y
Monto > 1000
```

Resultado:

```text
Aprobación Manual
```

---

## Regla 5

Si ninguna regla aplica:

```text
Aprobado automáticamente
```

---

## Regla adicional

Si:

```text
Empleado con más de 10 años
y
Monto menor a 2000
y
Presupuesto suficiente
```

Resultado:

```text
Aprobado automáticamente
```

Esta regla fue agregada sin modificar las reglas existentes gracias al uso del patrón de estrategia y al principio Open/Closed.

---

# Flujo de Evaluación

```text
Solicitud
    ↓
Approval Engine
    ↓
Ejecución secuencial de reglas
    ↓
Primera regla aplicable
    ↓
Resultado final
```

---

# Ejemplo de Solicitud

```json
{
  "amount": 1200,
  "department": "Technology",
  "employeeSeniority": 4,
  "purchaseType": "Equipment",
  "availableBudget": 5000
}
```

## Respuesta

```json
{
  "status": "Manual",
  "reason": "Equipment purchases require manual approval."
}
```

---

# Principios de Diseño Aplicados

* Clean Architecture
* Separation of Concerns
* Dependency Injection
* Open/Closed Principle
* Single Responsibility Principle
* Strategy Pattern
* Composition over Inheritance

---

# Ejecución del Proyecto

## Backend

```bash
cd Services
dotnet run
```

La API estará disponible en:

```text
https://localhost:7017/swagger
```

---

## Frontend

```bash
cd Client
npm install
npm run dev
```

La aplicación estará disponible en:

```text
http://localhost:5173
```

---

# Ejecución de Pruebas

## Pruebas Unitarias

```bash
dotnet test Test
```

## Pruebas de Integración

```bash
dotnet test IntegrationTests
```

---

# Autor

Hansel Pimentel

Software Developer | .NET Backend Developer

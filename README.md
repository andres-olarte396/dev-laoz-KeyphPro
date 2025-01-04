# **Keyph Pro**

Un sistema diseñado para registrar, analizar y graficar el progreso físico de los usuarios, enfocado en métricas clave de salud y aptitud física.

---

## **Descripción del Proyecto**

**Keyph Pro** es una solución moderna para entrenadores y usuarios que buscan monitorear los avances físicos de manera efectiva. El sistema proporciona una interfaz sencilla y amigable, respaldada por APIs que permiten registrar y graficar métricas como peso, grasa corporal, masa muscular, medidas corporales, entre otras.

El objetivo principal es ofrecer una herramienta confiable y escalable que pueda integrarse con otras plataformas y brindar análisis detallados en tiempo real.

---

## **Características Principales**

- **Registro de Métricas de Salud y Aptitud Física:**  
  Permite registrar métricas como peso, índice de masa corporal (BMI), grasa corporal, masa muscular, y más.

- **Cálculos Automáticos:**  
  Generación automática del BMI y otras métricas basadas en fórmulas estándar.

- **Gráficos Interactivos:**  
  Visualización de progresos mediante gráficos claros y personalizables.

- **Validaciones Robustas:**  
  Rango permitido para cada métrica con retroalimentación en tiempo real.

- **APIs REST:**  
  Para integración con aplicaciones de terceros.

- **Escalabilidad:**  
  Uso inicial de SQLite con capacidad de migrar a otras bases de datos.

---

## **Índice de Documentación**

La documentación completa del proyecto está disponible en el directorio `docs/`. A continuación, se proporciona un índice:

1. [**Diseño de la Solución**](docs/04-diseno-solucion/)
   - [01 - Arquitectura](docs/04-diseno-solucion/01-arquitectura.md)
   - [02 - Modelo de Datos](docs/04-diseno-solucion/02-modelo-datos.md)
   - [03 - Componentes](docs/04-diseno-solucion/03-componentes.md)
   - [04 - Interfaces de Usuario](docs/04-diseno-solucion/04-interfaces-usuario.md)
   - [05 - Integraciones](docs/04-diseno-solucion/05-integraciones.md)
   - [06 - Diseño de Marca](docs/04-diseno-solucion/06-diseno-de-marca.md)

2. [**Manual de Usuario**](docs/manual-usuario.md) *(Pendiente de desarrollo)*  
3. [**Guía de Contribución**](docs/guia-contribucion.md) *(Pendiente de desarrollo)*

---

## **Requisitos del Sistema**

### **Frontend**

- **Lenguaje:** React, Angular o Blazor.

- **Dependencias:** 

  - Librerías para gráficos (e.g., Chart.js, D3.js).
  - Framework CSS como Tailwind o Bootstrap.

### **Backend**

- **Lenguaje:** .NET Core 7.
- **Framework:** ASP.NET Core Web API.
- **Base de Datos:** SQLite (inicial), con posibilidad de migración a SQL Server o PostgreSQL.

---

## **Instalación**

### **Requisitos Previos**

- .NET SDK 7.0 o superior.
- Node.js y npm (para frontend).
- SQLite instalado (opcional).

### **Instrucciones**

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/usuario/Keyph-pro.git
   cd Keyph-pro
   ```

2. **Configuración del Backend:**
   - Navega al directorio del backend:

     ```bash
     cd KeyphPro.Backend
     ```

   - Restaura las dependencias:

     ```bash
     dotnet restore
     ```

   - Ejecuta las migraciones de la base de datos:

     ```bash
     dotnet ef database update
     ```

   - Inicia la API:

     ```bash
     dotnet run
     ```

3. **Configuración del Frontend:**
   - Navega al directorio del frontend:

     ```bash
     cd KeyphPro.Frontend
     ```

   - Instala las dependencias:

     ```bash
     npm install
     ```

   - Inicia el servidor de desarrollo:

     ```bash
     npm start
     ```

4. **Acceso:**
   - API disponible en `http://localhost:5000/api`.
   - Interfaz web en `http://localhost:3000`.

---

## **Estructura del Proyecto**

```plaintext
KeyphPro/
├── docs/                     # Documentación del proyecto.
├── KeyphPro.Backend/      # Código del backend (.NET).
├── KeyphPro.Frontend/     # Código del frontend.
├── tests/                    # Pruebas automatizadas.
└── README.md                 # Documentación general.
```

---

## **API Endpoints**

### **Usuarios**

- `POST /api/users` - Crear un usuario.
- `GET /api/users/{id}` - Obtener un usuario.

### **Valoraciones**

- `POST /api/assessments` - Registrar una nueva valoración.
- `GET /api/assessments/user/{id}` - Obtener valoraciones por usuario.
- `PUT /api/assessments/{id}` - Actualizar valoración.

### **Gráficos**

- `GET /api/graphs/user/{id}` - Generar gráficos del progreso.

---

## **Contribuciones**

¡Las contribuciones son bienvenidas! Si deseas colaborar, sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una rama para tu funcionalidad:

   ```bash
   git checkout -b feature/nueva-funcionalidad
   ```

3. Realiza tus cambios y haz un commit:

   ```bash
   git commit -m "Agrega nueva funcionalidad"
   ```

4. Envía un pull request.

---

## **Licencia**

Este proyecto está licenciado bajo la licencia MIT. Para más detalles, consulta el archivo `LICENSE`.

---

## **Contacto**

- **Autor:** Andres Olarte
- **Email:** contacto@keyphpro.com
- **GitHub:** [https://github.com/andres-olarte396](https://github.com/andres-olarte396)

¡Gracias por usar Keyph Pro! 🎯

# **Guía de Contribución a Keyph Pro**

¡Gracias por tu interés en contribuir a **Keyph Pro**! Este documento describe las pautas, buenas prácticas y pasos necesarios para colaborar en el desarrollo de este proyecto.

---

## **Índice**

- [**Guía de Contribución a Keyph Pro**](#guía-de-contribución-a-Keyph Pro)
  - [**Índice**](#índice)
  - [**Cómo Contribuir**](#cómo-contribuir)
    - [**Reportar Problemas**](#reportar-problemas)
    - [**Solicitar Nuevas Funcionalidades**](#solicitar-nuevas-funcionalidades)
    - [**Enviar Cambios**](#enviar-cambios)
  - [**Estructura del Proyecto**](#estructura-del-proyecto)
  - [**Estándares de Código**](#estándares-de-código)
  - [**Pruebas**](#pruebas)
  - [**Revisiones de Pull Requests**](#revisiones-de-pull-requests)
  - [**Comunicación**](#comunicación)

---

## **Cómo Contribuir**

### **Reportar Problemas**

Si encuentras un error o tienes alguna idea para mejorar el sistema, sigue estos pasos:

1. **Verifica si el problema ya existe:** Revisa los [issues](https://github.com/usuario/fittrack-pro/issues) antes de abrir uno nuevo.
2. **Crea un nuevo issue:**
   - Describe claramente el problema.
   - Incluye pasos para reproducirlo, si aplica.
   - Adjunta capturas de pantalla o ejemplos, si es posible.

### **Solicitar Nuevas Funcionalidades**

Si deseas sugerir una nueva funcionalidad:

1. Abre un issue etiquetado como `feature request`.
2. Proporciona una descripción detallada de la funcionalidad propuesta.
3. Explica el impacto y beneficio que tendría en el sistema.

### **Enviar Cambios**

Si deseas contribuir con código:

1. Haz un **fork** del repositorio.
2. Crea una rama para tu cambio:

   ```bash
   git checkout -b feature/mi-cambio
   ```

3. Realiza tus cambios y realiza commits:

   - Escribe mensajes de commit claros y concisos.
   - Usa un mensaje estructurado:

     ```plaintext
     [Tipo de Cambio]: Descripción breve
     ```

     Ejemplo: `fix: Corrige validación de peso en la API`.

4. Haz un **pull request** (PR):
   - Explica qué problema resuelve tu PR o qué funcionalidad agrega.
   - Proporciona pruebas, si aplica.
   - Etiqueta tu PR según corresponda (`bug fix`, `feature`, etc.).

---

## **Estructura del Proyecto**

Familiarízate con la organización del proyecto:

```plaintext
FitTrackPro/
├── docs/                     # Documentación del proyecto.
├── FitTrackPro.Backend/      # Código del backend (.NET).
├── FitTrackPro.Frontend/     # Código del frontend.
├── tests/                    # Pruebas automatizadas.
└── README.md                 # Documentación general.
```

---

## **Estándares de Código**

1. **Frontend:**
   - Usa un estilo consistente con **Prettier** o **ESLint**.
   - Nombrado de componentes: Usa `PascalCase`.
   - Incluye documentación y comentarios en tu código.

2. **Backend:**
   - Sigue las pautas de **clean code** y arquitectura limpia.
   - Nombrado de métodos y variables: Usa nombres descriptivos en inglés.
   - Valida tus cambios con `dotnet test` antes de enviar un PR.

3. **Convenciones de Commit:**
   Usa una de las siguientes etiquetas al comienzo del mensaje:
   - `feat`: Nueva funcionalidad.
   - `fix`: Corrección de errores.
   - `docs`: Cambios en la documentación.
   - `style`: Cambios que no afectan la lógica (formato, espacios, etc.).
   - `refactor`: Cambios en el código sin modificar la funcionalidad.
   - `test`: Añadir o modificar pruebas.

---

## **Pruebas**

Antes de enviar tus cambios:

1. **Ejecuta las pruebas existentes:**

   ```bash
   dotnet test
   npm test
   ```

2. **Crea nuevas pruebas:**  
   Si agregaste una nueva funcionalidad o corregiste un error, asegúrate de cubrirlo con pruebas automatizadas.
3. **Revisa la cobertura de pruebas:**  
   Intenta mantener una cobertura alta (>80%).

---

## **Revisiones de Pull Requests**

Tu PR será revisado según los siguientes criterios:

- Adherencia a los estándares de código.
- Claridad y estructura del cambio.
- Impacto en el sistema.
- Cobertura de pruebas adecuada.
- Documentación actualizada.

Una vez aprobado, se integrará en la rama principal.

---

## **Comunicación**

Si tienes preguntas o necesitas ayuda:

- Abre un **issue** con la etiqueta `question`.
- Únete al canal de comunicación del proyecto (e.g., Slack o Discord).
- Contacta al administrador del proyecto en [contacto@fittrackpro.com](mailto:contacto@fittrackpro.com).

---

¡Gracias por tu interés en colaborar con **Keyph Pro**! 🎉  
Tu ayuda es fundamental para mejorar y hacer crecer este proyecto.

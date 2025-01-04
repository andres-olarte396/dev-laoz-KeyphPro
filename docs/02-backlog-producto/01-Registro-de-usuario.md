#### **1. Registro de Usuario**

- **Descripción:** Permitir que los usuarios se registren con nombre, correo electrónico, fecha de nacimiento, género, y fecha de registro.
- **Prioridad:** Alta.
- **Categoría:** Funcional.
- **Estado:** Pendiente.
- **Tareas asociadas:**
  1. Crear el modelo de usuario en el backend.
  2. Diseñar el formulario de registro en la UI.
  3. Implementar validaciones de correo electrónico y otros datos.
  4. Guardar el usuario en la base de datos SQLite.

**Historia de Usuario:**

- **Como** usuario no registrado, 
- **quiero** registrarme en el sistema con mi información personal, 
- **para** poder gestionar y hacer seguimiento de mis métricas físicas.

**Criterios de aceptación:**

1. El formulario de registro debe aceptar nombre, correo, fecha de nacimiento, género.
2. Se debe mostrar un mensaje claro si los datos son inválidos.
3. El registro debe guardar los datos en la base de datos correctamente.

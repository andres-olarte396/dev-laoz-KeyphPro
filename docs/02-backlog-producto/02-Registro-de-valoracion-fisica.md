# **2. Registro de Valoración Física**

- **Descripción:** Permitir registrar las métricas físicas del usuario en una fecha específica.
- **Prioridad:** Alta.
- **Categoría:** Funcional.
- **Estado:** Pendiente.
- **Tareas asociadas:**
  1. Crear el modelo de valoración física en el backend.
  2. Diseñar el formulario de registro de valoraciones.
  3. Implementar cálculos automáticos (e.g., BMI).
  4. Validar los valores ingresados contra los límites establecidos.

**Historia de Usuario:**

- **Como** usuario registrado, 
- **quiero** ingresar mis métricas físicas en un formulario, 
- **para** realizar un seguimiento de mi progreso a lo largo del tiempo.

**Criterios de aceptación:**

1. El sistema debe validar que las métricas ingresadas están dentro de los límites establecidos.
2. El índice de masa corporal (BMI) debe calcularse automáticamente si peso y altura están disponibles.
3. El sistema debe mostrar un mensaje si grasa corporal y masa muscular no suman el 100%.

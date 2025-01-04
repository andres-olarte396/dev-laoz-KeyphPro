# **4. Exportación de Datos**

- **Descripción:** Permitir exportar las métricas y valoraciones en formato CSV o JSON.
- **Prioridad:** Baja.
- **Categoría:** Funcional.
- **Estado:** Pendiente.
- **Tareas asociadas:**
  1. Implementar un endpoint para generar archivos CSV/JSON.
  2. Diseñar un botón de exportación en la UI.
  3. Probar los datos exportados para garantizar consistencia.

**Historia de Usuario:**

- **Como** usuario registrado, 
- **quiero** exportar mis datos en un archivo, 
- **para** usarlos en análisis externos o compartirlos con un profesional de la salud.

**Criterios de aceptación:**

1. Los datos exportados deben incluir todas las valoraciones asociadas al usuario.
2. Los archivos generados deben ser compatibles con herramientas estándar (e.g., Excel).
3. El sistema debe confirmar que la exportación se realizó con éxito.

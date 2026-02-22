# 📚 Documentación - Procesador de Archivos JSON

## 📋 Descripción General
Aplicación Windows Forms para procesar, editar y gestionar archivos JSON de forma visual e intuitiva. Permite manipular datos JSON mediante una interfaz de tabla editable.

---

## 🎯 Características Principales

### ✅ Gestión de Archivos
- Abrir archivos JSON existentes
- Crear nuevos archivos JSON
- Guardar cambios
- Renombrar archivos
- Eliminar archivos

### ✅ Edición de Datos
- Edición visual mediante tabla (DataGridView)
- Edición de texto raw JSON
- Agregar/eliminar filas
- Modificar valores directamente en las celdas

### ✅ Visualización
- Vista de tabla estructurada
- Vista de JSON raw formateado
- Barra de estado con mensajes informativos

---

## 🔘 Guía de Botones

### 1. **Abrir Archivo** 📂
- **Función**: Carga un archivo JSON del disco
- **Cómo usar**: 
  1. Haga clic en el botón
  2. Navegue hasta su archivo JSON
  3. Seleccione el archivo y haga clic en "Abrir"
- **Resultado**: Los datos aparecen en la tabla lista para editar

### 2. **Guardar** 💾
- **Función**: Guarda los cambios en el archivo actual
- **Cómo usar**: 
  1. Edite los datos en la tabla
  2. Haga clic en "Guardar"
- **Resultado**: El archivo se actualiza con los cambios
- **Nota**: Si no hay archivo abierto, abre el diálogo "Guardar Como"

### 3. **Nuevo** ✨
- **Función**: Crea un archivo JSON vacío desde cero
- **Cómo usar**: 
  1. Haga clic en "Nuevo"
  2. Si hay datos sin guardar, confirme si desea guardarlos
- **Resultado**: Tabla vacía con columnas predeterminadas: Id, Nombre, Valor
- **Tip**: Puede agregar filas con el botón "Agregar Fila"

### 4. **Editar JSON** 📝
- **Función**: Edita el JSON en formato texto plano
- **Cómo usar**: 
  1. Haga clic en "Editar JSON"
  2. Se abre una ventana con el JSON en formato texto
  3. Modifique el texto según necesite
  4. Haga clic en "Aplicar Cambios"
- **Resultado**: Los cambios se reflejan en la tabla
- **Advertencia**: El JSON debe ser válido o mostrará error

### 5. **Renombrar** 🏷️
- **Función**: Cambia el nombre del archivo en el disco
- **Cómo usar**: 
  1. Abra un archivo primero
  2. Haga clic en "Renombrar"
  3. Escriba el nuevo nombre
  4. Presione OK
- **Resultado**: El archivo se renombra manteniendo sus datos
- **Nota**: No puede renombrar si el nombre ya existe

### 6. **Eliminar Archivo** 🗑️
- **Función**: Elimina permanentemente el archivo del disco
- **Cómo usar**: 
  1. Abra el archivo a eliminar
  2. Haga clic en "Eliminar Archivo"
  3. Confirme la eliminación
- **Resultado**: El archivo se borra del disco
- **⚠️ ADVERTENCIA**: Esta acción NO se puede deshacer

### 7. **Ver JSON Raw** 👁️
- **Función**: Actualiza la vista de JSON raw con los datos actuales
- **Cómo usar**: 
  1. Edite datos en la tabla
  2. Haga clic en "Ver JSON Raw"
- **Resultado**: El panel inferior muestra el JSON generado
- **Tip**: Útil para previsualizar antes de guardar

### 8. **Agregar Fila** ➕
- **Función**: Añade una fila vacía a la tabla
- **Cómo usar**: 
  1. Haga clic en "Agregar Fila"
  2. Edite los valores en la nueva fila
- **Resultado**: Nueva fila disponible para editar
- **Nota**: Requiere que la tabla tenga columnas definidas

### 9. **Eliminar Fila** ➖
- **Función**: Elimina filas seleccionadas de la tabla
- **Cómo usar**: 
  1. Haga clic en el número de fila (lado izquierdo) para seleccionarla
  2. Puede seleccionar múltiples filas con Ctrl+Clic
  3. Haga clic en "Eliminar Fila"
  4. Confirme la eliminación
- **Resultado**: Las filas desaparecen de la tabla
- **Nota**: Los cambios se guardan al hacer clic en "Guardar"

---

## 🖥️ Componentes de la Interfaz

### DataGridView (Tabla Superior)
- **Propósito**: Muestra y edita los datos JSON en formato tabla
- **Edición**: Haga clic en cualquier celda para editarla
- **Navegación**: Use las flechas del teclado o el mouse
- **Selección múltiple**: Mantenga Ctrl y haga clic en las filas

### TextBox JSON Raw (Panel Inferior)
- **Propósito**: Muestra el JSON en formato texto
- **Características**: 
  - Solo lectura
  - Formato con indentación
  - Fuente monoespaciada (Consolas)
- **Actualización**: Se actualiza al abrir, guardar o hacer clic en "Ver JSON Raw"

### Barra de Estado (Inferior)
- **Propósito**: Muestra mensajes y hora de las operaciones
- **Formato**: `HH:mm:ss - Mensaje`
- **Ejemplos**: 
  - "14:30:45 - Archivo cargado exitosamente: datos.json"
  - "14:32:10 - Nueva fila agregada"

---

## 📝 Métodos Principales Documentados

### `CargarArchivoJson(string rutaArchivo)`
Carga un archivo JSON y lo parsea para mostrarlo en la tabla. Soporta:
- **Arrays de objetos**: `[{}, {}, ...]`
- **Objetos simples**: `{"propiedad": "valor"}`

### `GuardarDatosComoJson(string rutaArchivo)`
Convierte los datos de la tabla a formato JSON y los guarda en disco. Características:
- Formato indentado
- Soporte para caracteres especiales (español)
- Conversión de tipos de datos

### `ObtenerValorJson(JsonElement element)`
Convierte elementos JSON a tipos .NET:
- String → `string`
- Number → `double`
- Boolean → `bool`
- Null → `DBNull.Value`
- Objetos/Arrays → `string` (representación)

### `FormatearJson(string json)`
Formatea una cadena JSON con indentación para mejor legibilidad.

---

## 🎓 Flujo de Trabajo Típico

### Crear un archivo nuevo:
1. Clic en **"Nuevo"**
2. Clic en **"Agregar Fila"** (varias veces)
3. Editar los valores en las celdas
4. Clic en **"Guardar"** → Elegir ubicación y nombre

### Editar un archivo existente:
1. Clic en **"Abrir Archivo"** → Seleccionar archivo
2. Editar directamente en la tabla
3. Clic en **"Guardar"**

### Editar JSON manualmente:
1. Abrir o crear un archivo
2. Clic en **"Editar JSON"**
3. Modificar el texto JSON
4. Clic en **"Aplicar Cambios"**

---

## ⚙️ Formato JSON Soportado

### Array de Objetos (Recomendado):
```json
[
  {
    "Id": 1,
    "Nombre": "Juan Pérez",
    "Email": "juan@ejemplo.com"
  },
  {
    "Id": 2,
    "Nombre": "María García",
    "Email": "maria@ejemplo.com"
  }
]
```

### Objeto Simple:
```json
{
  "nombre": "Juan",
  "edad": 30,
  "ciudad": "Madrid"
}
```

---

## 🛡️ Validaciones y Seguridad

- ✅ Confirmación antes de eliminar archivos
- ✅ Confirmación antes de eliminar filas múltiples
- ✅ Pregunta para guardar cambios antes de crear nuevo archivo
- ✅ Validación de JSON al editar manualmente
- ✅ Verificación de nombres duplicados al renombrar
- ✅ Manejo de errores con mensajes descriptivos

---

## 🐛 Manejo de Errores

La aplicación maneja los siguientes errores:
- Archivo JSON inválido
- Archivo no encontrado
- Permisos de archivo insuficientes
- Nombre de archivo duplicado
- Formato JSON incorrecto

Todos los errores muestran un MessageBox descriptivo con el problema.

---

## 💡 Consejos y Trucos

1. **Previsualizar antes de guardar**: Use "Ver JSON Raw" para ver cómo quedará el JSON
2. **Edición rápida**: Haga doble clic en una celda para editarla
3. **Selección múltiple**: Mantenga Ctrl para seleccionar varias filas
4. **Copiar columnas**: El DataGridView soporta Ctrl+C para copiar datos
5. **Guardar frecuentemente**: Use Ctrl+S (si lo implementa) o el botón Guardar regularmente

---

## 🔧 Requisitos Técnicos

- **.NET**: 8.0
- **Plataforma**: Windows
- **Framework**: Windows Forms
- **Referencias**: 
  - System.Text.Json
  - Microsoft.VisualBasic (para InputBox)

---

## 📞 Soporte

Para problemas o preguntas sobre el uso de la aplicación, consulte:
- La barra de estado para mensajes de error
- Los MessageBox que proporcionan información adicional
- Esta documentación

---

**Versión**: 1.0  
**Última actualización**: 2024

# 🚀 Guía Rápida - Procesador JSON

## 📖 Referencia Rápida de Botones

| Botón | Icono | Función | Atajo |
|-------|-------|---------|-------|
| **Abrir Archivo** | 📂 | Carga un archivo JSON del disco | - |
| **Guardar** | 💾 | Guarda cambios en el archivo actual | - |
| **Nuevo** | ✨ | Crea un archivo vacío con columnas por defecto | - |
| **Editar JSON** | 📝 | Abre editor de texto para modificar JSON raw | - |
| **Renombrar** | 🏷️ | Cambia el nombre del archivo en el disco | - |
| **Eliminar Archivo** | 🗑️ | Borra el archivo del disco (irreversible) | - |
| **Ver JSON Raw** | 👁️ | Actualiza la vista de JSON en el panel inferior | - |
| **Agregar Fila** | ➕ | Añade una nueva fila vacía a la tabla | - |
| **Eliminar Fila** | ➖ | Elimina las filas seleccionadas | - |

---

## 🎯 Casos de Uso Comunes

### Caso 1: Abrir y editar archivo existente
```
1. Clic en "Abrir Archivo"
2. Seleccionar archivo JSON
3. Editar celdas directamente
4. Clic en "Guardar"
```

### Caso 2: Crear archivo desde cero
```
1. Clic en "Nuevo"
2. Clic en "Agregar Fila" (varias veces)
3. Llenar los datos en la tabla
4. Clic en "Guardar"
5. Elegir nombre y ubicación
```

### Caso 3: Editar JSON manualmente
```
1. Abrir archivo
2. Clic en "Editar JSON"
3. Modificar texto JSON
4. Clic en "Aplicar Cambios"
```

### Caso 4: Eliminar filas específicas
```
1. Clic en número de fila (izquierda)
2. Ctrl+Clic para seleccionar múltiples
3. Clic en "Eliminar Fila"
4. Confirmar
5. Clic en "Guardar"
```

---

## 📋 Métodos Principales

### `InicializarDataGridView()`
**Propósito**: Configura el DataGridView al iniciar  
**Cuándo se ejecuta**: Al cargar el formulario  
**Qué hace**: 
- Vincula DataTable al DataGridView
- Habilita edición y agregar/eliminar filas
- Muestra mensaje de bienvenida

---

### `CargarArchivoJson(string rutaArchivo)`
**Propósito**: Lee y parsea un archivo JSON  
**Parámetros**: 
- `rutaArchivo`: Ruta completa del archivo JSON  
**Qué hace**: 
1. Lee el contenido del archivo
2. Intenta parsearlo como array de objetos
3. Si falla, intenta como objeto simple
4. Crea columnas según las propiedades
5. Llena la tabla con los datos

**Excepciones**: 
- Lanza excepción si el JSON es inválido
- El llamador debe manejar el error

---

### `ObtenerValorJson(JsonElement element)`
**Propósito**: Convierte JsonElement a tipo .NET  
**Parámetros**: 
- `element`: Elemento JSON a convertir  
**Retorna**: `object` con el tipo apropiado  
**Conversiones**:
```
JSON String  → string
JSON Number  → double
JSON True    → bool (true)
JSON False   → bool (false)
JSON Null    → DBNull.Value
Otro         → string (ToString())
```

---

### `FormatearJson(string json)`
**Propósito**: Formatea JSON con indentación  
**Parámetros**: 
- `json`: Cadena JSON sin formatear  
**Retorna**: JSON formateado con indentación  
**Nota**: Si falla, retorna el JSON original

---

### `GuardarDatosComoJson(string rutaArchivo)`
**Propósito**: Convierte DataTable a JSON y guarda  
**Parámetros**: 
- `rutaArchivo`: Ruta donde guardar  
**Qué hace**: 
1. Itera cada fila del DataTable
2. Convierte cada fila a Dictionary
3. Serializa a JSON con formato
4. Escribe al archivo
5. Actualiza vista raw

**Opciones de serialización**:
- `WriteIndented = true` (formato legible)
- `UnsafeRelaxedJsonEscaping` (caracteres especiales)

---

### `ActualizarEstado(string mensaje)`
**Propósito**: Actualiza barra de estado  
**Parámetros**: 
- `mensaje`: Texto a mostrar  
**Formato**: `HH:mm:ss - mensaje`  
**Ejemplo**: `14:30:45 - Archivo cargado exitosamente`

---

## 🔧 Variables de Estado

### `currentFilePath` (string)
- **Tipo**: `string`
- **Propósito**: Almacena la ruta del archivo actual
- **Valor inicial**: `string.Empty`
- **Cuándo se actualiza**: 
  - Al abrir un archivo
  - Al guardar por primera vez
  - Al renombrar
  - Al eliminar (se limpia)

### `dataTable` (DataTable)
- **Tipo**: `DataTable`
- **Propósito**: Almacena los datos del JSON
- **Vinculado a**: `dataGridView1.DataSource`
- **Estructura**: Dinámica según el JSON cargado

---

## 🎨 Componentes UI

### `dataGridView1`
- **Tipo**: DataGridView
- **Ubicación**: Panel superior (GroupBox1)
- **Propiedades clave**:
  - `AllowUserToAddRows = true`
  - `AllowUserToDeleteRows = true`
  - `EditMode = EditOnEnter`

### `txtJsonRaw`
- **Tipo**: TextBox
- **Ubicación**: Panel inferior (GroupBox2)
- **Propiedades**:
  - `Multiline = true`
  - `ScrollBars = Both`
  - `Font = Consolas, 9pt`
  - `WordWrap = false`

### `toolStripStatusLabel1`
- **Tipo**: ToolStripStatusLabel
- **Ubicación**: Barra de estado (inferior)
- **Formato**: `HH:mm:ss - Mensaje`

---

## ⚠️ Advertencias Importantes

1. **Eliminar Archivo**: Operación IRREVERSIBLE
2. **Editar JSON Raw**: Debe ser JSON válido o fallará
3. **Guardar**: Sobrescribe el archivo sin confirmación
4. **Renombrar**: No puede deshacer, solo File.Move de vuelta manualmente

---

## 💾 Formato de Datos

### Tabla → JSON
```csharp
DataTable (3 columnas, 2 filas):
Id | Nombre | Email
1  | Juan   | juan@mail.com
2  | María  | maria@mail.com

↓ Convierte a ↓

[
  {"Id": 1, "Nombre": "Juan", "Email": "juan@mail.com"},
  {"Id": 2, "Nombre": "María", "Email": "maria@mail.com"}
]
```

### JSON → Tabla
```csharp
[{key1: val1, key2: val2}, ...]  → Cada objeto = fila
{key1: val1, key2: val2}         → Cada propiedad = fila
```

---

## 🎯 Estados del Archivo

| Estado | `currentFilePath` | Comportamiento |
|--------|-------------------|----------------|
| Sin archivo | `string.Empty` | Guardar → "Guardar Como" |
| Archivo abierto | Ruta válida | Guardar → Sobrescribe |
| Archivo eliminado | Se limpia | Vuelve a estado inicial |
| Archivo renombrado | Se actualiza | Mantiene referencia |

---

## 🔄 Flujo de Datos

```
DISCO ← → MEMORIA ← → UI

Abrir:    Archivo JSON → CargarArchivoJson() → DataTable → DataGridView
Editar:   DataGridView → DataTable (automático)
Guardar:  DataTable → GuardarDatosComoJson() → Archivo JSON
Ver Raw:  DataTable → GuardarDatosComoJson(temp) → txtJsonRaw
```

---

**Tip**: Use esta guía como referencia rápida mientras programa o mantiene el código.

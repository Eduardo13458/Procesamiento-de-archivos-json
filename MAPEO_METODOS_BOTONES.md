# 📌 Mapeo Detallado: Métodos ↔ Botones

## 🎯 Tabla de Relación Método-Botón

| # | Botón (Interfaz) | Nombre del Control | Método Asociado | Event Handler | Tipo de Evento |
|---|------------------|-------------------|-----------------|---------------|----------------|
| 1 | **Abrir Archivo** | `btnAbrir` | `btnAbrir_Click()` | Click | Button.Click |
| 2 | **Guardar** | `btnGuardar` | `btnGuardar_Click()` | Click | Button.Click |
| 3 | **Nuevo** | `btnNuevo` | `btnNuevo_Click()` | Click | Button.Click |
| 4 | **Editar JSON** | `btnEditar` | `btnEditar_Click()` | Click | Button.Click |
| 5 | **Renombrar** | `btnRenombrar` | `btnRenombrar_Click()` | Click | Button.Click |
| 6 | **Eliminar Archivo** | `btnEliminar` | `btnEliminar_Click()` | Click | Button.Click |
| 7 | **Ver JSON Raw** | `btnVerJson` | `btnVerJson_Click()` | Click | Button.Click |
| 8 | **Agregar Fila** | `btnAgregarFila` | `btnAgregarFila_Click()` | Click | Button.Click |
| 9 | **Eliminar Fila** | `btnEliminarFila` | `btnEliminarFila_Click()` | Click | Button.Click |

---

## 📋 Documentación Detallada por Método

### 1️⃣ Método: `InicializarDataGridView()`

**🔗 Relación con Controles:**
- NO está ligado a ningún botón
- Se ejecuta en el constructor `Form1()`

**📍 Ubicación en el código:**
```csharp
public Form1()
{
    InitializeComponent();
    InicializarDataGridView(); // ← Llamado aquí
}
```

**🎯 Propósito:**
Configuración inicial del DataGridView al cargar el formulario.

**⚙️ Qué hace:**
1. Vincula `dataTable` → `dataGridView1.DataSource`
2. Habilita `AllowUserToAddRows = true`
3. Habilita `AllowUserToDeleteRows = true`
4. Configura `EditMode = EditOnEnter`
5. Muestra mensaje inicial en barra de estado

**🔄 Flujo de Ejecución:**
```
Inicio App → Form1() → InitializeComponent() → InicializarDataGridView()
```

---

### 2️⃣ Método: `btnAbrir_Click(object sender, EventArgs e)`

**🔗 Botón Asociado:** `btnAbrir` (Texto: "Abrir Archivo")
**📍 Posición en UI:** Primer botón de la izquierda
**🖱️ Evento:** `Button.Click`

**📍 Vinculación en Form1.Designer.cs:**
```csharp
btnAbrir.Click += btnAbrir_Click;
```

**🎯 Propósito:**
Abrir y cargar un archivo JSON del disco.

**⚙️ Secuencia de Ejecución:**
```
1. Usuario hace clic en botón "Abrir Archivo"
   ↓
2. Se dispara evento Click
   ↓
3. Se ejecuta btnAbrir_Click()
   ↓
4. Muestra OpenFileDialog
   ↓
5. Usuario selecciona archivo
   ↓
6. Guarda ruta en currentFilePath
   ↓
7. Llama a CargarArchivoJson(currentFilePath)
   ↓
8. Actualiza barra de estado
```

**🔗 Métodos Llamados Internamente:**
- `CargarArchivoJson(string rutaArchivo)`
- `ActualizarEstado(string mensaje)`

**📊 Variables Modificadas:**
- `currentFilePath` → Se actualiza con la ruta seleccionada

**📄 Controles Afectados:**
- `dataGridView1` → Se llena con datos del JSON
- `txtRutaArchivo` → Muestra la ruta del archivo
- `txtJsonRaw` → Muestra el JSON formateado
- `toolStripStatusLabel1` → Mensaje de estado

---

### 3️⃣ Método: `CargarArchivoJson(string rutaArchivo)`

**🔗 Relación con Botones:**
- Llamado por: `btnAbrir_Click()`
- Llamado por: `btnEditar_Click()` → Al aplicar cambios

**📍 NO es un Event Handler directo**
Es un método auxiliar llamado por otros métodos.

**🎯 Propósito:**
Parsear archivo JSON y cargar datos en DataTable.

**⚙️ Secuencia de Ejecución:**
```
1. Recibe rutaArchivo como parámetro
   ↓
2. Lee contenido: File.ReadAllText(rutaArchivo)
   ↓
3. Actualiza txtRutaArchivo.Text
   ↓
4. Formatea JSON: FormatearJson()
   ↓
5. Actualiza txtJsonRaw.Text
   ↓
6. Limpia dataTable (Clear() y Columns.Clear())
   ↓
7. INTENTO 1: Deserializar como Array
   ├─ Éxito → Crear columnas y llenar filas
   └─ Falla → INTENTO 2
   ↓
8. INTENTO 2: Deserializar como Objeto
   └─ Crear columnas "Propiedad" y "Valor"
```

**🔗 Métodos Llamados Internamente:**
- `FormatearJson(string json)`
- `ObtenerValorJson(JsonElement element)` (múltiples veces)

**📊 Variables Modificadas:**
- `dataTable` → Se limpia y recarga
- `dataTable.Columns` → Se crean columnas nuevas
- `dataTable.Rows` → Se agregan filas con datos

**📄 Controles Afectados:**
- `txtRutaArchivo` → Ruta del archivo
- `txtJsonRaw` → JSON formateado
- `dataGridView1` → Datos en tabla (indirecto vía dataTable)

**🔄 Formatos JSON Soportados:**

**Formato 1: Array de Objetos**
```json
[
  {"id": 1, "nombre": "Juan"},
  {"id": 2, "nombre": "María"}
]
```
→ Resultado: 2 columnas (id, nombre), 2 filas

**Formato 2: Objeto Simple**
```json
{
  "nombre": "Juan",
  "edad": 30
}
```
→ Resultado: 2 columnas (Propiedad, Valor), 2 filas

---

### 4️⃣ Método: `ObtenerValorJson(JsonElement element)`

**🔗 Relación con Botones:**
- Llamado indirectamente por: `btnAbrir_Click()` → `CargarArchivoJson()`

**📍 NO es un Event Handler**
Es un método de conversión de tipos.

**🎯 Propósito:**
Convertir `JsonElement` a tipo .NET apropiado.

**⚙️ Conversiones Realizadas:**

| Tipo JSON | `JsonValueKind` | Tipo .NET Retornado | Ejemplo |
|-----------|----------------|---------------------|---------|
| `"texto"` | `String` | `string` | "Juan" |
| `123` | `Number` | `double` | 123.0 |
| `true` | `True` | `bool` | true |
| `false` | `False` | `bool` | false |
| `null` | `Null` | `DBNull.Value` | (vacío) |
| `[...]` o `{...}` | Otros | `string` | "[1,2,3]" |

**🔄 Flujo de Uso:**
```
btnAbrir_Click()
  ↓
CargarArchivoJson()
  ↓
foreach (var kvp in jsonArray[0])
  ↓
row[kvp.Key] = ObtenerValorJson(kvp.Value) ← AQUÍ
```

---

### 5️⃣ Método: `FormatearJson(string json)`

**🔗 Relación con Botones:**
- Llamado por: `btnAbrir_Click()` → `CargarArchivoJson()`

**📍 NO es un Event Handler**
Es un método de formato de texto.

**🎯 Propósito:**
Dar formato indentado al JSON para mejor visualización.

**⚙️ Proceso:**
```
JSON sin formato → Deserialize → Serialize con WriteIndented → JSON formateado
```

**Entrada:**
```json
[{"id":1,"nombre":"Juan"},{"id":2,"nombre":"María"}]
```

**Salida:**
```json
[
  {
    "id": 1,
    "nombre": "Juan"
  },
  {
    "id": 2,
    "nombre": "María"
  }
]
```

---

### 6️⃣ Método: `btnGuardar_Click(object sender, EventArgs e)`

**🔗 Botón Asociado:** `btnGuardar` (Texto: "Guardar")
**📍 Posición en UI:** Segundo botón de la izquierda
**🖱️ Evento:** `Button.Click`

**📍 Vinculación en Form1.Designer.cs:**
```csharp
btnGuardar.Click += btnGuardar_Click;
```

**🎯 Propósito:**
Guardar datos actuales de la tabla al archivo JSON.

**⚙️ Secuencia de Ejecución:**
```
1. Usuario hace clic en "Guardar"
   ↓
2. Se dispara evento Click
   ↓
3. Se ejecuta btnGuardar_Click()
   ↓
4. ¿Hay archivo abierto? (currentFilePath != empty)
   ├─ NO → Llama btnGuardarComo()
   └─ SÍ → Continúa
   ↓
5. Llama GuardarDatosComoJson(currentFilePath)
   ↓
6. Actualiza barra de estado
   ↓
7. Muestra MessageBox "Archivo guardado correctamente"
```

**🔗 Métodos Llamados Internamente:**
- `btnGuardarComo()` (si no hay archivo)
- `GuardarDatosComoJson(string rutaArchivo)`
- `ActualizarEstado(string mensaje)`

**📊 Variables Usadas:**
- `currentFilePath` (lectura) → Para saber dónde guardar

**⚠️ Comportamiento Especial:**
Si `currentFilePath` está vacío, redirige a "Guardar Como".

---

### 7️⃣ Método: `btnGuardarComo()`

**🔗 Relación con Botones:**
- Llamado por: `btnGuardar_Click()` (cuando no hay archivo abierto)

**📍 NO es un Event Handler directo**
No hay botón "Guardar Como" visible en la UI.

**🎯 Propósito:**
Mostrar diálogo para guardar en nueva ubicación.

**⚙️ Secuencia de Ejecución:**
```
1. Llamado por btnGuardar_Click()
   ↓
2. Muestra SaveFileDialog
   ↓
3. Usuario elige ubicación y nombre
   ↓
4. Actualiza currentFilePath
   ↓
5. Actualiza txtRutaArchivo.Text
   ↓
6. Llama GuardarDatosComoJson()
   ↓
7. Actualiza barra de estado
```

**🔗 Métodos Llamados Internamente:**
- `GuardarDatosComoJson(string rutaArchivo)`
- `ActualizarEstado(string mensaje)`

**📊 Variables Modificadas:**
- `currentFilePath` → Se actualiza con nueva ruta

---

### 8️⃣ Método: `GuardarDatosComoJson(string rutaArchivo)`

**🔗 Relación con Botones:**
- Llamado por: `btnGuardar_Click()` → `GuardarDatosComoJson()`
- Llamado por: `btnGuardar_Click()` → `btnGuardarComo()` → `GuardarDatosComoJson()`
- Llamado por: `btnVerJson_Click()` (en archivo temporal)

**📍 NO es un Event Handler**
Es un método de conversión y escritura.

**🎯 Propósito:**
Convertir DataTable → JSON y escribir a archivo.

**⚙️ Secuencia de Ejecución:**
```
1. Crear lista vacía: List<Dictionary<string, object>>
   ↓
2. foreach (DataRow row in dataTable.Rows)
   ├─ Si row.RowState == Deleted → Saltar
   ├─ Crear diccionario vacío
   ├─ foreach (DataColumn column)
   │  └─ dict[column] = valor (o null si DBNull)
   └─ Agregar dict a lista
   ↓
3. Serializar lista a JSON
   ├─ WriteIndented = true
   └─ UnsafeRelaxedJsonEscaping
   ↓
4. File.WriteAllText(rutaArchivo, json)
   ↓
5. Actualizar txtJsonRaw.Text = json
```

**🔗 Variables Usadas:**
- `dataTable` (lectura) → Fuente de datos

**📄 Controles Afectados:**
- `txtJsonRaw` → Se actualiza con JSON generado

**📝 Ejemplo de Conversión:**

**DataTable:**
| Id | Nombre | Email |
|----|--------|-------|
| 1 | Juan | juan@mail.com |
| 2 | María | maria@mail.com |

**JSON Generado:**
```json
[
  {
    "Id": 1,
    "Nombre": "Juan",
    "Email": "juan@mail.com"
  },
  {
    "Id": 2,
    "Nombre": "María",
    "Email": "maria@mail.com"
  }
]
```

---

### 9️⃣ Método: `btnNuevo_Click(object sender, EventArgs e)`

**🔗 Botón Asociado:** `btnNuevo` (Texto: "Nuevo")
**📍 Posición en UI:** Tercer botón de la izquierda
**🖱️ Evento:** `Button.Click`

**📍 Vinculación en Form1.Designer.cs:**
```csharp
btnNuevo.Click += btnNuevo_Click;
```

**🎯 Propósito:**
Crear nuevo archivo JSON vacío con columnas predeterminadas.

**⚙️ Secuencia de Ejecución:**
```
1. Usuario hace clic en "Nuevo"
   ↓
2. Se dispara evento Click
   ↓
3. Se ejecuta btnNuevo_Click()
   ↓
4. ¿Hay datos en dataTable?
   └─ SÍ → Pregunta: "¿Guardar cambios?"
       ├─ Yes → Llama btnGuardar_Click()
       ├─ No → Continúa
       └─ Cancel → Salir (return)
   ↓
5. Limpiar todo:
   ├─ dataTable.Clear()
   ├─ dataTable.Columns.Clear()
   ├─ currentFilePath = empty
   ├─ txtRutaArchivo.Clear()
   └─ txtJsonRaw.Clear()
   ↓
6. Crear columnas predeterminadas:
   ├─ "Id"
   ├─ "Nombre"
   └─ "Valor"
   ↓
7. Actualizar barra de estado
```

**🔗 Métodos Llamados Internamente:**
- `btnGuardar_Click()` (si usuario confirma guardar)
- `ActualizarEstado(string mensaje)`

**📊 Variables Modificadas:**
- `dataTable` → Se limpia y recrea
- `currentFilePath` → Se vacía
- `dataTable.Columns` → Se crean 3 columnas nuevas

**📄 Controles Afectados:**
- `dataGridView1` → Tabla vacía con 3 columnas
- `txtRutaArchivo` → Se limpia
- `txtJsonRaw` → Se limpia

---

### 🔟 Método: `btnEditar_Click(object sender, EventArgs e)`

**🔗 Botón Asociado:** `btnEditar` (Texto: "Editar JSON")
**📍 Posición en UI:** Cuarto botón de la izquierda
**🖱️ Evento:** `Button.Click`

**📍 Vinculación en Form1.Designer.cs:**
```csharp
btnEditar.Click += btnEditar_Click;
```

**🎯 Propósito:**
Abrir editor de texto para modificar JSON raw.

**⚙️ Secuencia de Ejecución:**
```
1. Usuario hace clic en "Editar JSON"
   ↓
2. Se dispara evento Click
   ↓
3. Se ejecuta btnEditar_Click()
   ↓
4. ¿Hay datos? (dataTable.Rows.Count > 0)
   └─ NO → Mostrar error y salir
   ↓
5. Crear Form emergente:
   ├─ Tamaño: 800x600
   ├─ Título: "Editar JSON Raw"
   └─ StartPosition: CenterParent
   ↓
6. Crear TextBox editor:
   ├─ Multiline = true
   ├─ ScrollBars = Both
   ├─ Font = Consolas, 10pt
   ├─ Text = txtJsonRaw.Text
   └─ Dock = Fill
   ↓
7. Crear Button "Aplicar Cambios":
   ├─ Dock = Bottom
   └─ Height = 40
   ↓
8. Configurar evento Click del botón:
   └─ Guardar en temp → CargarArchivoJson(temp) → Eliminar temp
   ↓
9. Mostrar Form modal (ShowDialog)
```

**🔗 Métodos Llamados Internamente:**
- `CargarArchivoJson(string rutaArchivo)` (al aplicar cambios)
- `ActualizarEstado(string mensaje)`

**📊 Variables Usadas:**
- `txtJsonRaw.Text` (lectura) → Contenido inicial del editor

**🎨 Controles Creados Dinámicamente:**
- `Form editForm` → Ventana emergente
- `TextBox txtEditor` → Editor de texto
- `Button btnAplicar` → Botón para aplicar

**📄 Controles Afectados:**
- `dataGridView1` → Se actualiza al aplicar cambios
- `txtJsonRaw` → Se actualiza al aplicar cambios

**⚠️ Validación:**
Si el JSON editado no es válido, muestra error y NO cierra la ventana.

---

### 1️⃣1️⃣ Método: `btnRenombrar_Click(object sender, EventArgs e)`

**🔗 Botón Asociado:** `btnRenombrar` (Texto: "Renombrar")
**📍 Posición en UI:** Quinto botón de la izquierda
**🖱️ Evento:** `Button.Click`

**📍 Vinculación en Form1.Designer.cs:**
```csharp
btnRenombrar.Click += btnRenombrar_Click;
```

**🎯 Propósito:**
Renombrar archivo JSON actual en el disco.

**⚙️ Secuencia de Ejecución:**
```
1. Usuario hace clic en "Renombrar"
   ↓
2. Se dispara evento Click
   ↓
3. Se ejecuta btnRenombrar_Click()
   ↓
4. ¿Hay archivo abierto?
   └─ NO → Mostrar error y salir
   ↓
5. Obtener nombreActual y directorio
   ↓
6. Mostrar InputBox con nombre actual
   ↓
7. Usuario ingresa nuevo nombre
   ↓
8. ¿Nombre válido y diferente?
   └─ NO → Salir
   ↓
9. Construir nuevaRuta
   ↓
10. ¿Ya existe archivo con ese nombre?
    └─ SÍ → Mostrar error y salir
   ↓
11. File.Move(currentFilePath, nuevaRuta)
   ↓
12. Actualizar variables:
    ├─ currentFilePath = nuevaRuta
    └─ txtRutaArchivo.Text = nuevaRuta
   ↓
13. Actualizar barra de estado
   ↓
14. Mostrar mensaje de éxito
```

**🔗 Métodos Llamados Internamente:**
- `ActualizarEstado(string mensaje)`
- `Microsoft.VisualBasic.Interaction.InputBox()` (externo)

**📊 Variables Modificadas:**
- `currentFilePath` → Se actualiza con nueva ruta

**📄 Controles Afectados:**
- `txtRutaArchivo` → Muestra nueva ruta

**⚠️ Validaciones:**
1. Debe haber archivo abierto
2. Nombre no puede estar vacío
3. Nombre debe ser diferente al actual
4. No puede existir archivo con ese nombre

---

### 1️⃣2️⃣ Método: `btnEliminar_Click(object sender, EventArgs e)`

**🔗 Botón Asociado:** `btnEliminar` (Texto: "Eliminar Archivo")
**📍 Posición en UI:** Sexto botón de la izquierda
**🖱️ Evento:** `Button.Click`

**📍 Vinculación en Form1.Designer.cs:**
```csharp
btnEliminar.Click += btnEliminar_Click;
```

**🎯 Propósito:**
Eliminar permanentemente archivo JSON del disco.

**⚙️ Secuencia de Ejecución:**
```
1. Usuario hace clic en "Eliminar Archivo"
   ↓
2. Se dispara evento Click
   ↓
3. Se ejecuta btnEliminar_Click()
   ↓
4. ¿Hay archivo abierto?
   └─ NO → Mostrar error y salir
   ↓
5. Mostrar confirmación con MessageBox:
   "¿Está seguro de eliminar archivo?"
   ↓
6. Usuario responde:
   ├─ No → Salir
   └─ Yes → Continúa
   ↓
7. File.Delete(currentFilePath)
   ↓
8. Limpiar todo:
   ├─ dataTable.Clear()
   ├─ dataTable.Columns.Clear()
   ├─ currentFilePath = empty
   ├─ txtRutaArchivo.Clear()
   └─ txtJsonRaw.Clear()
   ↓
9. Actualizar barra de estado
   ↓
10. Mostrar mensaje de éxito
```

**🔗 Métodos Llamados Internamente:**
- `ActualizarEstado(string mensaje)`

**📊 Variables Modificadas:**
- `dataTable` → Se limpia completamente
- `currentFilePath` → Se vacía

**📄 Controles Afectados:**
- `dataGridView1` → Tabla vacía
- `txtRutaArchivo` → Se limpia
- `txtJsonRaw` → Se limpia

**⚠️ ADVERTENCIA:**
Esta operación es IRREVERSIBLE. El archivo se borra del disco.

---

### 1️⃣3️⃣ Método: `btnVerJson_Click(object sender, EventArgs e)`

**🔗 Botón Asociado:** `btnVerJson` (Texto: "Ver JSON Raw")
**📍 Posición en UI:** Séptimo botón de la izquierda
**🖱️ Evento:** `Button.Click`

**📍 Vinculación en Form1.Designer.cs:**
```csharp
btnVerJson.Click += btnVerJson_Click;
```

**🎯 Propósito:**
Actualizar vista JSON raw con datos actuales de la tabla.

**⚙️ Secuencia de Ejecución:**
```
1. Usuario hace clic en "Ver JSON Raw"
   ↓
2. Se dispara evento Click
   ↓
3. Se ejecuta btnVerJson_Click()
   ↓
4. ¿Hay datos? (dataTable.Rows.Count > 0)
   └─ NO → Mostrar error y salir
   ↓
5. Crear archivo temporal: Path.GetTempFileName()
   ↓
6. Llamar GuardarDatosComoJson(tempFile)
   ↓
7. Leer JSON generado: File.ReadAllText(tempFile)
   ↓
8. Actualizar txtJsonRaw.Text = json
   ↓
9. Eliminar archivo temporal: File.Delete(tempFile)
   ↓
10. Actualizar barra de estado
```

**🔗 Métodos Llamados Internamente:**
- `GuardarDatosComoJson(string rutaArchivo)` (con archivo temporal)
- `ActualizarEstado(string mensaje)`

**📊 Variables Usadas:**
- `dataTable` (lectura) → Fuente de datos

**📄 Controles Afectados:**
- `txtJsonRaw` → Se actualiza con JSON generado

**💡 Uso Típico:**
Después de editar datos en la tabla, usar este botón para previsualizar el JSON antes de guardar.

---

### 1️⃣4️⃣ Método: `btnAgregarFila_Click(object sender, EventArgs e)`

**🔗 Botón Asociado:** `btnAgregarFila` (Texto: "Agregar Fila")
**📍 Posición en UI:** Octavo botón de la izquierda
**🖱️ Evento:** `Button.Click`

**📍 Vinculación en Form1.Designer.cs:**
```csharp
btnAgregarFila.Click += btnAgregarFila_Click;
```

**🎯 Propósito:**
Añadir fila vacía al final de la tabla.

**⚙️ Secuencia de Ejecución:**
```
1. Usuario hace clic en "Agregar Fila"
   ↓
2. Se dispara evento Click
   ↓
3. Se ejecuta btnAgregarFila_Click()
   ↓
4. ¿Hay columnas? (dataTable.Columns.Count > 0)
   └─ NO → Mostrar error y salir
   ↓
5. Crear nueva fila: dataTable.NewRow()
   ↓
6. Agregar fila a tabla: dataTable.Rows.Add(newRow)
   ↓
7. Actualizar barra de estado
```

**🔗 Métodos Llamados Internamente:**
- `ActualizarEstado(string mensaje)`

**📊 Variables Modificadas:**
- `dataTable.Rows` → Se agrega nueva fila

**📄 Controles Afectados:**
- `dataGridView1` → Muestra nueva fila vacía

**⚠️ Requisito:**
Debe haber columnas definidas. Si no las hay, usar "Nuevo" primero.

---

### 1️⃣5️⃣ Método: `btnEliminarFila_Click(object sender, EventArgs e)`

**🔗 Botón Asociado:** `btnEliminarFila` (Texto: "Eliminar Fila")
**📍 Posición en UI:** Noveno botón (último a la derecha)
**🖱️ Evento:** `Button.Click`

**📍 Vinculación en Form1.Designer.cs:**
```csharp
btnEliminarFila.Click += btnEliminarFila_Click;
```

**🎯 Propósito:**
Eliminar filas seleccionadas de la tabla.

**⚙️ Secuencia de Ejecución:**
```
1. Usuario hace clic en "Eliminar Fila"
   ↓
2. Se dispara evento Click
   ↓
3. Se ejecuta btnEliminarFila_Click()
   ↓
4. ¿Hay filas seleccionadas? (SelectedRows.Count > 0)
   ├─ NO → Mostrar error y salir
   └─ SÍ → Continúa
   ↓
5. Mostrar confirmación:
   "¿Desea eliminar X fila(s)?"
   ↓
6. Usuario responde:
   ├─ No → Salir
   └─ Yes → Continúa
   ↓
7. foreach (DataGridViewRow row in SelectedRows)
   ├─ ¿Es fila nueva? (row.IsNewRow)
   ├─ NO → dataGridView1.Rows.Remove(row)
   └─ SÍ → Saltar (no eliminar)
   ↓
8. Actualizar barra de estado
```

**🔗 Métodos Llamados Internamente:**
- `ActualizarEstado(string mensaje)`

**📊 Variables Modificadas:**
- `dataTable.Rows` → Se eliminan filas seleccionadas

**📄 Controles Afectados:**
- `dataGridView1` → Filas desaparecen

**📝 Cómo Seleccionar Filas:**
1. Hacer clic en el número de fila (lado izquierdo)
2. Ctrl+Clic para seleccionar múltiples
3. Shift+Clic para rango

**⚠️ Nota:**
Los cambios NO se guardan en archivo hasta hacer clic en "Guardar".

---

### 1️⃣6️⃣ Método: `ActualizarEstado(string mensaje)`

**🔗 Relación con Botones:**
Llamado por TODOS los métodos de botones.

**📍 NO es un Event Handler**
Es un método auxiliar de UI.

**🎯 Propósito:**
Actualizar barra de estado con mensaje y hora.

**⚙️ Implementación:**
```csharp
toolStripStatusLabel1.Text = $"{DateTime.Now:HH:mm:ss} - {mensaje}";
```

**📄 Control Afectado:**
- `toolStripStatusLabel1` → Barra de estado inferior

**📊 Formato:**
```
HH:mm:ss - Mensaje
Ejemplo: 14:30:45 - Archivo cargado exitosamente: datos.json
```

**🔗 Llamado por:**
- `InicializarDataGridView()`
- `btnAbrir_Click()`
- `btnGuardar_Click()`
- `btnNuevo_Click()`
- `btnEditar_Click()`
- `btnRenombrar_Click()`
- `btnEliminar_Click()`
- `btnVerJson_Click()`
- `btnAgregarFila_Click()`
- `btnEliminarFila_Click()`

---

## 🔄 Diagrama de Flujo General

```
┌─────────────────────────────────────────────────────────┐
│                    INICIO APLICACIÓN                     │
└────────────────────┬────────────────────────────────────┘
                     │
                     ▼
            ┌─────────────────┐
            │   Form1()       │
            │   Constructor   │
            └────────┬────────┘
                     │
                     ▼
         ┌──────────────────────┐
         │ InitializeComponent()│
         └──────────┬───────────┘
                     │
                     ▼
       ┌──────────────────────────────┐
       │  InicializarDataGridView()   │
       │  - Vincular DataTable        │
       │  - Configurar propiedades    │
       │  - Mensaje inicial           │
       └──────────────────────────────┘
                     │
                     ▼
        ┌────────────────────────────┐
        │   ESPERANDO INTERACCIÓN    │
        │      DEL USUARIO           │
        └─────────┬──────────────────┘
                  │
        ┌─────────┴──────────────────────────────────────┐
        │                                                 │
        ▼                                                 ▼
┌──────────────┐                                 ┌──────────────┐
│ Botones de   │                                 │ Edición      │
│ Archivo      │                                 │ Directa      │
└──────┬───────┘                                 └──────┬───────┘
       │                                                 │
       ├─► Abrir                                        ├─► Click celda
       ├─► Guardar                                      ├─► Editar valor
       ├─► Nuevo                                        └─► Tab/Enter
       ├─► Renombrar
       └─► Eliminar

        ┌────────────────────────────┐
        │   Botones de Edición       │
        └─────────┬──────────────────┘
                  │
                  ├─► Editar JSON
                  ├─► Ver JSON Raw
                  ├─► Agregar Fila
                  └─► Eliminar Fila
```

---

## 📊 Matriz de Dependencias

| Método | Llama a | Es Llamado por |
|--------|---------|----------------|
| `InicializarDataGridView()` | `ActualizarEstado()` | `Form1()` |
| `btnAbrir_Click()` | `CargarArchivoJson()`, `ActualizarEstado()` | Usuario (Click) |
| `CargarArchivoJson()` | `FormatearJson()`, `ObtenerValorJson()` | `btnAbrir_Click()`, `btnEditar_Click()` |
| `ObtenerValorJson()` | - | `CargarArchivoJson()` |
| `FormatearJson()` | - | `CargarArchivoJson()` |
| `btnGuardar_Click()` | `btnGuardarComo()`, `GuardarDatosComoJson()`, `ActualizarEstado()` | Usuario (Click), `btnNuevo_Click()` |
| `btnGuardarComo()` | `GuardarDatosComoJson()`, `ActualizarEstado()` | `btnGuardar_Click()` |
| `GuardarDatosComoJson()` | - | `btnGuardar_Click()`, `btnGuardarComo()`, `btnVerJson_Click()` |
| `btnNuevo_Click()` | `btnGuardar_Click()`, `ActualizarEstado()` | Usuario (Click) |
| `btnEditar_Click()` | `CargarArchivoJson()`, `ActualizarEstado()` | Usuario (Click) |
| `btnRenombrar_Click()` | `ActualizarEstado()` | Usuario (Click) |
| `btnEliminar_Click()` | `ActualizarEstado()` | Usuario (Click) |
| `btnVerJson_Click()` | `GuardarDatosComoJson()`, `ActualizarEstado()` | Usuario (Click) |
| `btnAgregarFila_Click()` | `ActualizarEstado()` | Usuario (Click) |
| `btnEliminarFila_Click()` | `ActualizarEstado()` | Usuario (Click) |
| `ActualizarEstado()` | - | Todos los métodos |

---

## 🎨 Layout de Botones en la Interfaz

```
┌──────────────────────────────────────────────────────────────────────────────┐
│ [Abrir] [Guardar] [Nuevo] [Editar JSON] [Renombrar] [Eliminar] [Ver JSON]   │
│                                                          [Agregar] [Eliminar] │
├──────────────────────────────────────────────────────────────────────────────┤
│ Archivo actual: [______________________________ruta_del_archivo____________] │
├──────────────────────────────────────────────────────────────────────────────┤
│ ┌─ Vista de Datos (Tabla) ─────────────────────────────────────────────────┐ │
│ │                                                                           │ │
│ │   [DataGridView - Tabla Editable]                                        │ │
│ │                                                                           │ │
│ └───────────────────────────────────────────────────────────────────────────┘ │
├──────────────────────────────────────────────────────────────────────────────┤
│ ┌─ JSON Raw (Solo lectura) ────────────────────────────────────────────────┐ │
│ │                                                                           │ │
│ │   [TextBox - JSON Formateado]                                            │ │
│ │                                                                           │ │
│ └───────────────────────────────────────────────────────────────────────────┘ │
├──────────────────────────────────────────────────────────────────────────────┤
│ 14:30:45 - Archivo cargado exitosamente                    [Barra de Estado] │
└──────────────────────────────────────────────────────────────────────────────┘
```

---

## 📝 Resumen de Event Handlers

```csharp
// ===== EVENT HANDLERS PRINCIPALES =====

// 1. Abrir archivo JSON
private void btnAbrir_Click(object sender, EventArgs e)

// 2. Guardar cambios
private void btnGuardar_Click(object sender, EventArgs e)

// 3. Crear nuevo archivo
private void btnNuevo_Click(object sender, EventArgs e)

// 4. Editar JSON raw
private void btnEditar_Click(object sender, EventArgs e)

// 5. Renombrar archivo
private void btnRenombrar_Click(object sender, EventArgs e)

// 6. Eliminar archivo
private void btnEliminar_Click(object sender, EventArgs e)

// 7. Actualizar vista JSON
private void btnVerJson_Click(object sender, EventArgs e)

// 8. Agregar fila vacía
private void btnAgregarFila_Click(object sender, EventArgs e)

// 9. Eliminar filas seleccionadas
private void btnEliminarFila_Click(object sender, EventArgs e)


// ===== MÉTODOS AUXILIARES =====

// Inicialización
private void InicializarDataGridView()

// Procesamiento JSON
private void CargarArchivoJson(string rutaArchivo)
private object ObtenerValorJson(JsonElement element)
private string FormatearJson(string json)

// Guardado
private void btnGuardarComo()
private void GuardarDatosComoJson(string rutaArchivo)

// UI
private void ActualizarEstado(string mensaje)
```

---

**✅ Esta documentación proporciona el mapeo completo y detallado de cada método con sus botones asociados.**

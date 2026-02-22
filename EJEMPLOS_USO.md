# 📘 Ejemplos Prácticos de Uso

## Ejemplo 1: Gestión de Empleados

### JSON de Entrada:
```json
[
  {
    "Id": 1,
    "Nombre": "Juan Pérez",
    "Puesto": "Desarrollador",
    "Salario": 3500.00,
    "Activo": true
  },
  {
    "Id": 2,
    "Nombre": "María García",
    "Puesto": "Gerente",
    "Salario": 4500.00,
    "Activo": true
  }
]
```

### Flujo de Trabajo:
1. **Abrir** → Seleccionar `empleados.json`
2. La tabla muestra:

| Id | Nombre | Puesto | Salario | Activo |
|----|--------|--------|---------|--------|
| 1 | Juan Pérez | Desarrollador | 3500 | true |
| 2 | María García | Gerente | 4500 | true |

3. **Editar**: Cambiar salario de Juan a 3800
4. **Agregar Fila**: Añadir nuevo empleado
5. **Guardar**: Actualizar archivo

---

## Ejemplo 2: Catálogo de Productos

### Crear desde Cero:

1. **Nuevo** → Crea tabla con columnas predeterminadas
2. **Nota**: Las columnas por defecto son Id, Nombre, Valor
3. Para cambiar columnas, usar **Editar JSON**:

```json
[
  {
    "Codigo": "PROD001",
    "Nombre": "Laptop Dell",
    "Precio": 899.99,
    "Stock": 15,
    "Categoria": "Tecnología"
  }
]
```

4. **Aplicar Cambios** → La tabla se actualiza con nuevas columnas
5. Continuar agregando productos...

---

## Ejemplo 3: Configuración de Aplicación

### JSON Simple (Objeto):
```json
{
  "nombreApp": "Mi Aplicación",
  "version": "1.0.0",
  "puerto": 8080,
  "debug": true,
  "baseDatos": "localhost:5432"
}
```

### Resultado en Tabla:

| Propiedad | Valor |
|-----------|-------|
| nombreApp | Mi Aplicación |
| version | 1.0.0 |
| puerto | 8080 |
| debug | true |
| baseDatos | localhost:5432 |

**Nota**: Para objetos simples, cada propiedad se muestra como una fila.

---

## Ejemplo 4: Edición Masiva con JSON Raw

### Caso de Uso:
Necesitas cambiar un campo en múltiples registros rápidamente.

### Pasos:
1. **Abrir** archivo con 100 registros
2. **Ver JSON Raw** → Muestra el JSON completo
3. **Editar JSON** → Abre el editor
4. Usar Buscar y Reemplazar (Ctrl+H en el editor):
   - Buscar: `"Activo": false`
   - Reemplazar: `"Activo": true`
5. **Aplicar Cambios**
6. **Guardar**

✅ Cambio masivo completado en segundos

---

## Ejemplo 5: Importar Datos de Otra Fuente

### Escenario:
Tienes datos en Excel y quieres convertirlos a JSON.

### Método:
1. Exportar Excel a CSV
2. Usar herramienta online para convertir CSV → JSON
3. Copiar el JSON generado
4. En la app: **Nuevo** → **Editar JSON**
5. Pegar el JSON
6. **Aplicar Cambios**
7. Verificar en la tabla
8. **Guardar** como nuevo archivo

---

## Ejemplo 6: Validación de Datos

### JSON con Errores Comunes:

❌ **Error 1**: Coma extra
```json
[
  {"id": 1, "nombre": "Juan",},  ← Coma después de "Juan"
]
```

❌ **Error 2**: Comillas faltantes
```json
[
  {id: 1, "nombre": "Juan"}  ← 'id' sin comillas
]
```

❌ **Error 3**: Coma faltante
```json
[
  {"id": 1 "nombre": "Juan"}  ← Falta coma entre campos
]
```

### Cómo Detectar:
1. Intentar abrir con **Abrir Archivo**
2. Si falla, mostrará error
3. Abrir el JSON en un editor externo
4. Corregir el error
5. Intentar nuevamente

---

## Ejemplo 7: Backup Antes de Editar

### Flujo Seguro:
```
1. Abrir archivo original: datos.json
2. Guardar copia de seguridad:
   - Renombrar a: datos_backup.json
   - O copiar manualmente el archivo
3. Abrir datos.json
4. Realizar cambios
5. Guardar
6. Si algo sale mal, abrir datos_backup.json
```

---

## Ejemplo 8: Trabajar con Arrays Anidados

### JSON con Arrays:
```json
[
  {
    "id": 1,
    "nombre": "Juan",
    "habilidades": ["C#", "JavaScript", "SQL"]
  }
]
```

### En la Tabla:
| id | nombre | habilidades |
|----|--------|-------------|
| 1 | Juan | ["C#", "JavaScript", "SQL"] |

**Nota**: Los arrays se muestran como texto. Para editarlos:
1. **Editar JSON**
2. Modificar manualmente el array
3. **Aplicar Cambios**

---

## Ejemplo 9: Ordenar y Filtrar Datos

### En el DataGridView:
- **Ordenar**: Clic en el encabezado de columna
  - 1er clic: Orden ascendente ⬆️
  - 2do clic: Orden descendente ⬇️
- **Filtrar**: No soportado directamente
  - **Alternativa**: Editar JSON y eliminar elementos no deseados

---

## Ejemplo 10: Migrar Formato de Datos

### De Formato Antiguo a Nuevo:

**Antes**:
```json
[
  {"emp_id": 1, "emp_name": "Juan", "emp_sal": 3000}
]
```

**Después**:
```json
[
  {"id": 1, "nombre": "Juan", "salario": 3000}
]
```

### Método:
1. Abrir archivo antiguo
2. **Editar JSON**
3. Usar buscar/reemplazar:
   - `emp_id` → `id`
   - `emp_name` → `nombre`
   - `emp_sal` → `salario`
4. **Aplicar Cambios**
5. **Guardar Como** → nuevo formato

---

## 🎓 Consejos Prácticos

### 1. Manejo de Grandes Archivos
- ⚠️ Archivos >1000 registros pueden ser lentos
- **Solución**: Dividir en archivos más pequeños
- Usar "Ver JSON Raw" solo cuando sea necesario

### 2. Edición Eficiente
- **Agregar múltiples filas**: Mantenga clic en "Agregar Fila"
- **Copiar datos**: Seleccione celdas y use Ctrl+C
- **Pegar datos**: Ctrl+V en celdas seleccionadas

### 3. Prevenir Pérdida de Datos
- Guardar frecuentemente (cada 5-10 minutos)
- Hacer backup antes de cambios grandes
- Probar en archivo de prueba primero

### 4. Formato Consistente
- Mantener los mismos nombres de columnas
- Usar tipos de datos consistentes
- Evitar valores null innecesarios

### 5. Validación Manual
- Después de editar, usar **Ver JSON Raw**
- Verificar que el formato es correcto
- Copiar a validator JSON online si hay dudas

---

## 🚨 Errores Comunes y Soluciones

### Error: "No hay datos para mostrar"
**Causa**: Archivo JSON vacío o tabla sin datos  
**Solución**: 
- Verificar que el archivo tiene contenido
- Usar **Nuevo** para crear tabla inicial

### Error: "Error al abrir el archivo"
**Causa**: JSON inválido o corrupto  
**Solución**: 
- Abrir en editor de texto
- Validar en jsonlint.com
- Corregir errores de sintaxis

### Error: "Ya existe un archivo con ese nombre"
**Causa**: Intentar renombrar a nombre existente  
**Solución**: 
- Elegir nombre diferente
- Eliminar archivo existente primero (con precaución)

### Tabla muestra datos incorrectos
**Causa**: Tipo de dato no reconocido  
**Solución**: 
- Usar **Editar JSON** para corregir formato
- Asegurar que números no estén entre comillas

---

## 📊 Casos de Uso Reales

### 1. Gestión de Inventario
```json
[
  {
    "SKU": "PROD-001",
    "Nombre": "Teclado Mecánico",
    "Cantidad": 50,
    "Precio": 89.99,
    "Proveedor": "TechSupply Inc",
    "UltimaActualizacion": "2024-01-15"
  }
]
```

### 2. Lista de Tareas
```json
[
  {
    "ID": 1,
    "Tarea": "Completar documentación",
    "Prioridad": "Alta",
    "Estado": "En Progreso",
    "FechaLimite": "2024-01-20"
  }
]
```

### 3. Contactos
```json
[
  {
    "Nombre": "Juan Pérez",
    "Telefono": "+34 600 123 456",
    "Email": "juan@ejemplo.com",
    "Empresa": "Tech Corp",
    "Notas": "Cliente VIP"
  }
]
```

### 4. Configuración de Servidores
```json
[
  {
    "Servidor": "WEB-01",
    "IP": "192.168.1.10",
    "Puerto": 8080,
    "Activo": true,
    "Ubicacion": "DataCenter-A"
  }
]
```

---

## 🎯 Ejercicios Prácticos

### Ejercicio 1: Crear Base de Datos de Películas
1. Crear archivo nuevo
2. Agregar columnas: Titulo, Director, Año, Genero, Calificacion
3. Agregar 5 películas
4. Guardar como `peliculas.json`
5. Modificar una calificación
6. Agregar 2 películas más
7. Guardar cambios

### Ejercicio 2: Migrar Formato
1. Crear JSON con formato antiguo
2. Usar "Editar JSON" para cambiar estructura
3. Convertir nombres de campos
4. Guardar como nuevo archivo

### Ejercicio 3: Limpieza de Datos
1. Abrir archivo con datos duplicados
2. Identificar registros duplicados
3. Eliminar filas redundantes
4. Verificar con "Ver JSON Raw"
5. Guardar versión limpia

---

**¡Estos ejemplos cubren el 90% de casos de uso comunes!**

using System.Data;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Procesamiento_de_archivos_json
{
 
    public partial class Form1 : Form
    {
        #region Variables de Estado

        // Ruta del archivo JSON actualmente abierto
        private string currentFilePath = string.Empty;

        // Tabla de datos que contiene la información del JSON cargado
        private DataTable dataTable = new DataTable();

        #endregion

        #region Constructor e Inicialización

       
        public Form1()
        {
            InitializeComponent();
            InicializarDataGridView();
        }

       
        private void InicializarDataGridView()
        {
           
            dataGridView1.DataSource = dataTable;

       
            dataGridView1.AllowUserToAddRows = true;

           
            dataGridView1.AllowUserToDeleteRows = true;

            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            ActualizarEstado("Aplicación iniciada. Abra o cree un archivo JSON.");
        }

        #endregion

        #region Event Handlers de Botones - Gestión de Archivos

        #endregion

        #region Event Handlers de Botones - Gestión de Archivos

       
        private void btnAbrir_Click(object sender, EventArgs e)
        {
           
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos JSON (*.json)|*.json|Todos los archivos (*.*)|*.*",
                Title = "Seleccionar archivo JSON"
            };

           
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                 
                    currentFilePath = openFileDialog.FileName;

                   
                    CargarArchivoJson(currentFilePath);

                
                    ActualizarEstado($"Archivo cargado exitosamente: {Path.GetFileName(currentFilePath)}");
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActualizarEstado("Error al cargar archivo.");
                }
            }
        }

        #endregion

        #region Métodos Auxiliares - Procesamiento JSON

      
        
        private void CargarArchivoJson(string rutaArchivo)
        {
            string jsonContent = File.ReadAllText(rutaArchivo);

           
            txtRutaArchivo.Text = rutaArchivo;

           
            txtJsonRaw.Text = FormatearJson(jsonContent);

            
            dataTable.Clear();
            dataTable.Columns.Clear();

            try
            {
               
                var jsonArray = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(jsonContent);

                if (jsonArray != null && jsonArray.Count > 0)
                {
                    
                    foreach (var key in jsonArray[0].Keys)
                    {
                        dataTable.Columns.Add(key);
                    }

                 
                    foreach (var item in jsonArray)
                    {
                        DataRow row = dataTable.NewRow();
                        foreach (var kvp in item)
                        {
                            row[kvp.Key] = ObtenerValorJson(kvp.Value);
                        }
                        dataTable.Rows.Add(row);
                    }
                }
            }
            catch
            {
                
                var jsonObject = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonContent);

                if (jsonObject != null)
                {
                    
                    dataTable.Columns.Add("Propiedad");
                    dataTable.Columns.Add("Valor");

                  
                    foreach (var kvp in jsonObject)
                    {
                        DataRow row = dataTable.NewRow();
                        row["Propiedad"] = kvp.Key;
                        row["Valor"] = ObtenerValorJson(kvp.Value);
                        dataTable.Rows.Add(row);
                    }
                }
            }
        }

        private object ObtenerValorJson(JsonElement element)
        {
            return element.ValueKind switch
            {
                JsonValueKind.String => element.GetString() ?? string.Empty,
                JsonValueKind.Number => element.GetDouble(),
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                JsonValueKind.Null => DBNull.Value,
                _ => element.ToString() 
            };
        }

        
        private string FormatearJson(string json)
        {
            try
            {
                
                var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
                return JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions 
                { 
                    WriteIndented = true 
                });
            }
            catch
            {
                
                return json;
            }
        }

       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
         
            if (string.IsNullOrEmpty(currentFilePath))
            {
                btnGuardarComo();
                return;
            }

            try
            {
               
                GuardarDatosComoJson(currentFilePath);

              
                ActualizarEstado($"Archivo guardado exitosamente: {Path.GetFileName(currentFilePath)}");

                
                MessageBox.Show("Archivo guardado correctamente.", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Métodos Auxiliares - Guardado

        
        private void btnGuardarComo()
        {
      
            using SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos JSON (*.json)|*.json|Todos los archivos (*.*)|*.*",
                Title = "Guardar archivo JSON",
                FileName = "nuevo_archivo.json"
            };

         
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               
                currentFilePath = saveFileDialog.FileName;
                txtRutaArchivo.Text = currentFilePath;

              
                GuardarDatosComoJson(currentFilePath);

          
                ActualizarEstado($"Archivo guardado como: {Path.GetFileName(currentFilePath)}");
            }
        }

       
        private void GuardarDatosComoJson(string rutaArchivo)
        {
         
            var lista = new List<Dictionary<string, object>>();

         
            foreach (DataRow row in dataTable.Rows)
            {
               
                if (row.RowState == DataRowState.Deleted) continue;

          
                var dict = new Dictionary<string, object>();

             
                foreach (DataColumn column in dataTable.Columns)
                {
                    var valor = row[column];
                    
                    dict[column.ColumnName] = valor == DBNull.Value ? null : valor;
                }

           
                if (dict.Count > 0)
                {
                    lista.Add(dict);
                }
            }

          
            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions 
            { 
                WriteIndented = true,
            
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            
            File.WriteAllText(rutaArchivo, json);

         
            txtJsonRaw.Text = json;
        }

       
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            if (dataTable.Rows.Count > 0)
            {
                var result = MessageBox.Show("¿Desea guardar los cambios actuales antes de crear un nuevo archivo?", 
                    "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
              
                    btnGuardar_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                 
                    return;
                }
            }

            dataTable.Clear();
            dataTable.Columns.Clear();
            currentFilePath = string.Empty;
            txtRutaArchivo.Clear();
            txtJsonRaw.Clear();

      
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Valor");

            ActualizarEstado("Nuevo archivo creado. Agregue datos y guarde.");
        }

        
        private void btnEditar_Click(object sender, EventArgs e)
        {
           
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para editar. Abra o cree un archivo primero.", 
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

    
            using var editForm = new Form
            {
                Text = "Editar JSON Raw",
                Width = 800,
                Height = 600,
                StartPosition = FormStartPosition.CenterParent
            };

          
            var txtEditor = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 10),
                Text = txtJsonRaw.Text,
                WordWrap = false
            };

          
            var btnAplicar = new Button
            {
                Text = "Aplicar Cambios",
                Dock = DockStyle.Bottom,
                Height = 40
            };

    
            btnAplicar.Click += (s, ev) =>
            {
                try
                {
           
                    var tempFile = Path.GetTempFileName();
                    File.WriteAllText(tempFile, txtEditor.Text);

             
                    CargarArchivoJson(tempFile);

              
                    File.Delete(tempFile);

                 
                    editForm.Close();

                    ActualizarEstado("JSON editado y aplicado correctamente.");
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show($"Error al aplicar cambios: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            editForm.Controls.Add(txtEditor);
            editForm.Controls.Add(btnAplicar);
            editForm.ShowDialog();
        }

        
        private void btnRenombrar_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(currentFilePath) || !File.Exists(currentFilePath))
            {
                MessageBox.Show("No hay ningún archivo abierto para renombrar.", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            string nombreActual = Path.GetFileName(currentFilePath);
            string directorio = Path.GetDirectoryName(currentFilePath) ?? string.Empty;

         
            string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese el nuevo nombre para el archivo:", 
                "Renombrar archivo", 
                nombreActual);

          
            if (string.IsNullOrWhiteSpace(nuevoNombre) || nuevoNombre == nombreActual)
            {
                return;
            }

            try
            {
               
                string nuevaRuta = Path.Combine(directorio, nuevoNombre);

                
                if (File.Exists(nuevaRuta))
                {
                    MessageBox.Show("Ya existe un archivo con ese nombre.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               
                File.Move(currentFilePath, nuevaRuta);

                
                currentFilePath = nuevaRuta;
                txtRutaArchivo.Text = nuevaRuta;

                ActualizarEstado($"Archivo renombrado a: {nuevoNombre}");
                MessageBox.Show("Archivo renombrado exitosamente.", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al renombrar el archivo: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath) || !File.Exists(currentFilePath))
            {
                MessageBox.Show("No hay ningún archivo abierto para eliminar.", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            var result = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el archivo?\n\n{currentFilePath}\n\nEsta acción no se puede deshacer.", 
                "Confirmar eliminación", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                 
                    File.Delete(currentFilePath);
                    string nombreArchivo = Path.GetFileName(currentFilePath);

                    // Limpiar toda la interfaz
                    dataTable.Clear();
                    dataTable.Columns.Clear();
                    currentFilePath = string.Empty;
                    txtRutaArchivo.Clear();
                    txtJsonRaw.Clear();

                    ActualizarEstado($"Archivo eliminado: {nombreArchivo}");
                    MessageBox.Show("Archivo eliminado exitosamente.", "Éxito", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el archivo: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Event Handlers de Botones - Visualización y Edición

       
        private void btnVerJson_Click(object sender, EventArgs e)
        {
          
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar.", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
            
                var tempFile = Path.GetTempFileName();
                GuardarDatosComoJson(tempFile);

               
                string json = File.ReadAllText(tempFile);
                txtJsonRaw.Text = json;

               
                File.Delete(tempFile);

                ActualizarEstado("JSON actualizado en la vista raw.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar JSON: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnAgregarFila_Click(object sender, EventArgs e)
        {
           
            if (dataTable.Columns.Count == 0)
            {
                MessageBox.Show("Primero debe crear columnas. Use 'Nuevo' para inicializar una tabla.", 
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            DataRow newRow = dataTable.NewRow();
            dataTable.Rows.Add(newRow);

            ActualizarEstado("Nueva fila agregada.");
        }

       
        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
          
            if (dataGridView1.SelectedRows.Count > 0)
            {
               
                var result = MessageBox.Show(
                    $"¿Desea eliminar {dataGridView1.SelectedRows.Count} fila(s) seleccionada(s)?", 
                    "Confirmar", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                 
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        
                        if (!row.IsNewRow)
                        {
                            dataGridView1.Rows.Remove(row);
                        }
                    }
                    ActualizarEstado("Fila(s) eliminada(s).");
                }
            }
            else
            {
                MessageBox.Show("Seleccione al menos una fila para eliminar.", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Métodos Auxiliares - Interfaz de Usuario

        
        private void ActualizarEstado(string mensaje)
        {
            toolStripStatusLabel1.Text = $"{DateTime.Now:HH:mm:ss} - {mensaje}";
        }

        #endregion
    }
}

using System;
using System.IO;
using System.Windows.Forms;

namespace MesaPartesDigital
{
    public partial class Form1 : Form
    {

        const int MAXIMO = 100;
        string[] codigos = new string[MAXIMO];
        string[] ciudadanos = new string[MAXIMO];
        string[] tipos = new string[MAXIMO];
        string[] asuntos = new string[MAXIMO];
        string[] fechas = new string[MAXIMO];
        string[] estados = new string[MAXIMO];
        int cantidad = 0;


        string archivo = Path.Combine(AppContext.BaseDirectory, "expedientes.txt");


        public Form1()
        {
            InitializeComponent();
            ConfigurarTabla();

            cmbDocumento.Items.Add("Solicitud");
            cmbDocumento.Items.Add("Carta");
            cmbDocumento.Items.Add("Reclamo");
            cmbDocumento.Items.Add("Otro");
            cmbDocumento.SelectedIndex = 0;

            CargarArchivo();
            MostrarExpedientes();
        }


        void ConfigurarTabla()
        {
            dgvExpedientes.Columns.Add("colCodigo", "Código");
            dgvExpedientes.Columns.Add("colCiudadano", "Ciudadano");
            dgvExpedientes.Columns.Add("colTipo", "Tipo de documento");
            dgvExpedientes.Columns.Add("colAsunto", "Asunto");
            dgvExpedientes.Columns.Add("colFecha", "Fecha");
            dgvExpedientes.Columns.Add("colEstado", "Estado");

            dgvExpedientes.ReadOnly = true;
            dgvExpedientes.AllowUserToAddRows = false;
            dgvExpedientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpedientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        void MostrarExpedientes()
        {
            dgvExpedientes.Rows.Clear();
            for (int i = 0; i < cantidad; i++)
            {
                AgregarFila(i);
            }
            lblTotal.Text = "Expedientes registrados: " + cantidad;
        }


        void AgregarFila(int i)
        {
            dgvExpedientes.Rows.Add(codigos[i], ciudadanos[i], tipos[i], asuntos[i], fechas[i], estados[i]);
        }


        string LeerCodigo()
        {
            return txtCodigo.Text.Trim().ToUpper().Replace("|", "");
        }


        bool ValidarDatos()
        {
            string codigo = LeerCodigo();

            if (codigo == "")
            {
                MessageBox.Show("Escriba el código del expediente.");
                txtCodigo.Focus();
                return false;
            }
            if (codigo.Length < 4 || !char.IsLetter(codigo[0]))
            {
                MessageBox.Show("El código debe tener al menos 4 caracteres y empezar con una letra. Ejemplo: EXP001");
                txtCodigo.Focus();
                return false;
            }
            if (BuscarPosicion(codigo) != -1)
            {
                MessageBox.Show("Ese código ya existe. Use otro código.");
                txtCodigo.Focus();
                return false;
            }
            if (txtCiudadano.Text.Trim().Length < 5)
            {
                MessageBox.Show("Escriba el nombre y apellido del ciudadano.");
                txtCiudadano.Focus();
                return false;
            }
            if (dtpFecha.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha no puede ser posterior a hoy.");
                dtpFecha.Focus();
                return false;
            }
            if (txtAsunto.Text.Trim() == "")
            {
                MessageBox.Show("Escriba el asunto del trámite.");
                txtAsunto.Focus();
                return false;
            }
            return true;
        }


        int BuscarPosicion(string codigo)
        {
            for (int i = 0; i < cantidad; i++)
            {
                if (codigos[i] == codigo)
                {
                    return i;
                }
            }
            return -1;
        }


        void OrdenarPorCodigo()
        {
            for (int i = 0; i < cantidad - 1; i++)
            {
                for (int j = 0; j < cantidad - 1 - i; j++)
                {
                    if (string.CompareOrdinal(codigos[j], codigos[j + 1]) > 0)
                    {
                        Intercambiar(j, j + 1);
                    }
                }
            }
        }

        void Intercambiar(int a, int b)
        {
            Cambiar(codigos, a, b);
            Cambiar(ciudadanos, a, b);
            Cambiar(tipos, a, b);
            Cambiar(asuntos, a, b);
            Cambiar(fechas, a, b);
            Cambiar(estados, a, b);
        }

        void Cambiar(string[] arreglo, int a, int b)
        {
            string temporal = arreglo[a];
            arreglo[a] = arreglo[b];
            arreglo[b] = temporal;
        }


        void GuardarArchivo()
        {
            try
            {
                string[] lineas = new string[cantidad];
                for (int i = 0; i < cantidad; i++)
                {
                    lineas[i] = codigos[i] + "|" + ciudadanos[i] + "|" + tipos[i] + "|"
                              + asuntos[i] + "|" + fechas[i] + "|" + estados[i];
                }
                File.WriteAllLines(archivo, lineas);
            }
            catch
            {
                MessageBox.Show("No se pudo guardar el archivo.");
            }
        }


        void CargarArchivo()
        {
            if (!File.Exists(archivo))
            {
                return;
            }

            string[] lineas = File.ReadAllLines(archivo);
            for (int i = 0; i < lineas.Length; i++)
            {
                string[] partes = lineas[i].Split('|');
                if (partes.Length == 6 && cantidad < MAXIMO)
                {
                    codigos[cantidad] = partes[0];
                    ciudadanos[cantidad] = partes[1];
                    tipos[cantidad] = partes[2];
                    asuntos[cantidad] = partes[3];
                    fechas[cantidad] = partes[4];
                    estados[cantidad] = partes[5];
                    cantidad++;
                }
            }
        }



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }
            if (cantidad >= MAXIMO)
            {
                MessageBox.Show("Ya no hay espacio para más expedientes.");
                return;
            }
            //gg

            codigos[cantidad] = LeerCodigo();
            ciudadanos[cantidad] = txtCiudadano.Text.Trim().Replace("|", " ");
            tipos[cantidad] = cmbDocumento.Text;
            asuntos[cantidad] = txtAsunto.Text.Trim().Replace("|", " ");
            fechas[cantidad] = dtpFecha.Value.ToString("yyyy-MM-dd");
            estados[cantidad] = "Recibido";
            cantidad++;

            GuardarArchivo();
            MostrarExpedientes();
            LimpiarCampos();
            MessageBox.Show("Expediente registrado correctamente.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtBuscar.Text.Trim().ToUpper();
            int posicion = BuscarPosicion(codigo);

            if (posicion == -1)
            {
                MessageBox.Show("No existe un expediente con ese código.");
            }
            else
            {
                dgvExpedientes.Rows.Clear();
                AgregarFila(posicion);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            MostrarExpedientes();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            OrdenarPorCodigo();
            GuardarArchivo();
            MostrarExpedientes();
        }


        void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtCiudadano.Clear();
            txtAsunto.Clear();
            cmbDocumento.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
            txtCodigo.Focus();
        }
    }
}
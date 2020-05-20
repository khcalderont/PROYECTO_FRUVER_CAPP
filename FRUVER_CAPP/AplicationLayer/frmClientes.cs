using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BusinessLayer;


namespace AplicationLayer
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();

        }

        private int IdClientes = 0;

        private void Form1_Load(object sender, EventArgs e)
        {

            CargarFechas();
            CargarGrilla();
           
            //ProbarConexion();
           
        }

        public void CargarGrilla()
        {

            dtgRegistroClientes.AutoGenerateColumns = false;
            dtgRegistroClientes.DataSource = ClientesBusiness.ObtenerClientes();
        }

        public void guardarBD()
            {
                CargarGrilla();
                ClientesEntity cliente = new ClientesEntity();
                cliente.TipoDocumento = cbTipoDocumento.Text;
                cliente.NumeroDocumento = txtdocumento.Text;
                cliente.Primerombre = txtprimernombre.Text;
                cliente.SegundoNombre = txtsegundonombre.Text;
                cliente.PrimerApellido = txtprimerapellido.Text;
                cliente.SegudoApellido = txtsegundoapellido.Text;
                cliente.Telefono = txtnumero.Text;
                cliente.Email = txtemail.Text;
                cliente.direccion = txtdireccion.Text;
                int auxMes = ConfiguracionFechas(cbmes.Text);
                cliente.FechaNacimiento = Convert.ToDateTime(cbaño.Text + "-" + auxMes + "-" + cbdia.Text);

            if (ClientesBusiness.GuardarCliente(cliente))
            {
                MessageBox.Show("El Cliente se ha guardado con éxito");
            }
    }

        private void LimpiarFormulario() 
        { 
            cbTipoDocumento.Text="";
            txtdocumento.Text = "";
            txtprimernombre.Text = "";
            txtsegundonombre.Text = "";
            txtprimerapellido.Text = "";
            txtsegundoapellido.Text = "";
            txtnumero.Text = "";
            txtemail.Text = "";
            txtdireccion.Text = "";

        }

        private void InhabilitarFormulario()
        {
            cbTipoDocumento.Enabled = false;
            txtdocumento.Enabled = false;
            txtprimernombre.Enabled = false;
            txtsegundonombre.Enabled = false;
            txtprimerapellido.Enabled = false;
            txtsegundoapellido.Enabled = false;
            txtnumero.Enabled = false;
            txtemail.Enabled = false;
            txtdireccion.Enabled = false;

        }

        private void HabilitarFormulario()
        {
            cbTipoDocumento.Enabled = true;
            txtdocumento.Enabled = true;
            txtprimernombre.Enabled = true;
            txtsegundonombre.Enabled = true;
            txtprimerapellido.Enabled = true;
            txtsegundoapellido.Enabled = true;
            txtnumero.Enabled = true;
            txtemail.Enabled = true;
            txtdireccion.Enabled = true;

        }

        private void txtTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sonríe, es gratis..!");
            Application.Exit();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CargarFechas()
        {
            for (int dia = 1; dia <=31;  dia++)
            {
                cbdia.Items.Add(dia);
            }
            
            int aux = DateTime.Now.Year;

            for (int anyo = 1900; anyo <=aux ; anyo++)
            {
                cbaño.Items.Add(anyo);
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (Validacion() == false)
            {
                return;
            }
            else
            {
                int auxClienteInt = 0;
                string auxClienteStr = txtIdCliente.Text;
                Int32.TryParse(auxClienteStr, out auxClienteInt);
                if (auxClienteInt != 0 && txtIdCliente.Text != "")
                {
                    ActualizarUsuario();
                }
                else
                {
                    guardarBD();
                }
            }
        }
        private void ActualizarUsuario()
        {
            ClientesEntity cliente = new ClientesEntity();
            cliente.IdCliente = Convert.ToInt32(txtIdCliente.Text);
            cliente.TipoDocumento = cbTipoDocumento.Text;
            cliente.NumeroDocumento = txtdocumento.Text;
            cliente.Primerombre = txtprimernombre.Text;
            cliente.SegundoNombre = txtsegundonombre.Text;
            cliente.PrimerApellido = txtprimerapellido.Text;
            cliente.SegudoApellido = txtsegundoapellido.Text;
            cliente.Telefono = txtnumero.Text;
            cliente.Email = txtemail.Text;
            cliente.direccion = txtdireccion.Text;
            int auxMes = ConfiguracionFechas(cbmes.Text);
            cliente.FechaNacimiento = Convert.ToDateTime(cbaño.Text + "-" + auxMes + "-" + cbdia.Text);

            if (ClientesBusiness.UpdateCliente(cliente))
            {
                MessageBox.Show("Cliente actualizado con exito");
                CargarGrilla();
            }
        }
        private bool Validacion() 
        {
            if (cbTipoDocumento.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("El tipo de documento es un dato obligatorio","Error de validación",MessageBoxButtons.OK,MessageBoxIcon.Error);
                cbTipoDocumento.Focus();
                return false;
            }
            if(txtdocumento.Text=="")
            {
                MessageBox.Show("El número de documento es un dato obligatorio", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdocumento.Focus();
                return false;
            }
            if(txtprimernombre.Text=="")
            {
                MessageBox.Show("El nombre es un dato obligatorio", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtprimernombre.Focus();
                return false;
            }
            if (txtprimerapellido.Text == "")
            {
                MessageBox.Show("El apellido es un dato obligatorio", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtprimerapellido.Focus();
                return false;
            }
            if (txtdireccion.Text == "")
            {
                MessageBox.Show("El dirección es un dato obligatorio", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdireccion.Focus();
                return false;
            }
            if (txtemail.Text == "")
            {
                MessageBox.Show("El email es un dato obligatorio", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtemail.Focus();
                return false;
            }
            if (txtnumero.Text =="")
            {
                MessageBox.Show("El número de teléfono es un campo obligatorio", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnumero.Focus();
                return false;
            }
            string MesAux = cbmes.Text;
            int YearAux = 0;
            int DiaAux = 0;
            Int32.TryParse(cbaño.Text, out YearAux);
            Int32.TryParse(cbdia.Text, out DiaAux);

            if (YearAux != 0)
            {
                if (DiaAux == 31 && MesAux == "Abril" ||
                    DiaAux == 31 && MesAux == "Junio" ||
                    DiaAux == 31 && MesAux == "Septiembre" ||
                    DiaAux == 31 && MesAux == "Noviembre")
                {
                    MessageBox.Show("Error");
                    return false;
                }
                if (DiaAux > 29 && MesAux == "Febrero")
                {
                    MessageBox.Show("Error");
                    return false;
                }
                if (DiaAux == 29 && MesAux == "Febrero")
                {
                    if (YearAux % 400 == 0 || (YearAux % 4 == 0 && YearAux % 100 != 0))
                    {
                        MessageBox.Show("Fecha Correcta");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Fecha Incorrecta");
                        return false;
                    }
                }

            }
            else
            {
                MessageBox.Show("Error");
                return false;
            }
            
            return true;
        }

            private void txtdocumento_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if(!(char.IsNumber(e.KeyChar))&&(e.KeyChar !=(char)Keys.Back)&&(e.KeyChar !=(char)Keys.Enter))
            {
                MessageBox.Show("Ingrese únicamente números", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

            private void btncancelar_Click(object sender, EventArgs e)
            {

            }

            

            private void btneditar_Click(object sender, EventArgs e)
            {
                HabilitarFormulario();
            }

            private void dtgRegistroClientes_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if(e.RowIndex == -1)
                {
                    return;
                }
                IdClientes = Convert.ToInt32(dtgRegistroClientes.Rows[e.RowIndex].Cells["clm_ID"].Value);
                CargarFormulario(IdClientes);
            }

            private void CargarFormulario(int IdClientes)
            {
                ClientesEntity cliente = new ClientesEntity();
                cliente = ClientesBusiness.ObtenerCliente(IdClientes);
                cbTipoDocumento.Text = cliente.TipoDocumento;
                txtdocumento.Text = cliente.NumeroDocumento;
                txtprimernombre.Text = cliente.Primerombre;
                txtsegundonombre.Text = cliente.SegundoNombre;
                txtprimerapellido.Text = cliente.PrimerApellido;
                txtsegundoapellido.Text = cliente.SegudoApellido;
                txtnumero.Text = cliente.Telefono;
                txtemail.Text = cliente.Email;
                txtdireccion.Text = cliente.direccion;
                txtIdCliente.Text = Convert.ToString(cliente.IdCliente);
                cbdia.Text = cliente.FechaNacimiento.Day.ToString();
                int auxMes = cliente.FechaNacimiento.Month;
                cbmes.Text = ConfiguracionFechasStr(auxMes);
                cbaño.Text = Convert.ToString(cliente.FechaNacimiento.Year);
                InhabilitarFormulario();
            }

            private void btnnuevo_Click(object sender, EventArgs e)
            {
                LimpiarFormulario();
                CargarGrilla();
            }
            private int ConfiguracionFechas(string Mes)
            {
                switch (Mes)
                { 
                    case "Enero":
                        return 1;
                    case "Febreo":
                        return 2;
                    case "Marzo":
                        return 3;
                    case "Abril":
                        return 4;
                    case "Mayo":
                        return 5;
                    case "Junio":
                        return 6;
                    case "Julio":
                        return 7;
                    case "Agosto":
                        return 8;
                    case "Seeptiembre":
                        return 9;
                    case "Octubre":
                        return 10;
                    case "Noviembre":
                        return 11;
                    case "Diciembre":
                        return 12;
                    default:
                        return 0;
                }
            }
            private string ConfiguracionFechasStr(int Mes)
            {
                switch (Mes)
                {
                    case 1:
                        return "Enero";
                    case 2:
                        return "Febreo";
                    case 3 :
                        return "Marzo";
                    case 4 :
                        return "Abril";
                    case 5 :
                        return"Mayo";
                    case 6:
                        return "Junio";
                    case 7:
                        return "Julio";
                    case 8:
                        return "Agosto";
                    case 9:
                        return "Seeptiembre";
                    case 10:
                        return "Octubre";
                    case 11:
                        return "Noviembre";
                    case 12:
                        return "Diciembre";
                    default:
                        return "";
                }
            }
    }
}

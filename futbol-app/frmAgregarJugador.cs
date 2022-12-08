using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using System.IO;
using System.Configuration;

namespace futbol_app
{
    public partial class frmAgregarJugador : Form
    {
        // Variables.
        private Jugador jugador = null;
        private OpenFileDialog archivo;

        // Constructors
        public frmAgregarJugador()
        {
            InitializeComponent();
        }
        public frmAgregarJugador(Jugador jugador)
        {
            InitializeComponent();
            this.jugador = jugador;
        }

        // Events
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            JugadorNegocio negocio = new JugadorNegocio();

            try
            {
                if (jugador == null)
                    jugador = new Jugador();

                jugador.Nombre = txtNombre.Text;
                jugador.Apellido = txtApellido.Text;
                jugador.Edad = int.Parse(txtEdad.Text);
                jugador.Altura = int.Parse(txtAltura.Text);
                jugador.FechaNacimiento = dtpNacimiento.Value.Date;
                jugador.Foto = txtFoto.Text;
                jugador.Nacionalidad = (Nacionalidad)cmbNacionalidad.SelectedItem;
                jugador.Equipo = (Equipo)cmbEquipo.SelectedItem;
                jugador.Posicion = (Posicion)cmbPosicion.SelectedItem;
                
                if(jugador.Id == 0)
                {
                    negocio.addPlayer(jugador);
                    MessageBox.Show("Se agrego el usuario exitosamente");
                }
                else
                {
                    negocio.modPlayer(jugador);
                    MessageBox.Show("Se modifico el usuario correctamente");
                }

                if (archivo != null && !(txtFoto.Text.ToLower().Contains("http")))
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);

                Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void frmAgregarJugador_Load(object sender, EventArgs e)
        {
            EquipoNegocio equipoNegocio = new EquipoNegocio();
            PosicionNegocio posicionNegocio = new PosicionNegocio();
            NacionalidadNegocio nacionalidadNegocio = new NacionalidadNegocio();
            
            try
            {
                cmbEquipo.DataSource = equipoNegocio.listar();
                cmbEquipo.ValueMember = "Id";
                cmbEquipo.DisplayMember = "Nombre";
                cmbPosicion.DataSource = posicionNegocio.listar();
                cmbPosicion.ValueMember = "Id";
                cmbPosicion.DisplayMember = "Nombre";
                cmbNacionalidad.DataSource = nacionalidadNegocio.listar();
                cmbNacionalidad.ValueMember = "Id";
                cmbNacionalidad.DisplayMember = "Nombre";

                if(jugador != null)
                {
                    txtNombre.Text = jugador.Nombre;
                    txtApellido.Text = jugador.Apellido;
                    txtEdad.Text = jugador.Edad.ToString();
                    txtAltura.Text = jugador.Altura.ToString();
                    txtFoto.Text = jugador.Foto;
                    cargarImagen(jugador.Foto);
                    cmbEquipo.SelectedValue = jugador.Equipo.Id;
                    cmbPosicion.SelectedValue = jugador.Posicion.Id;
                    cmbNacionalidad.SelectedValue = jugador.Nacionalidad.Id;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtFoto_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtFoto.Text);
        }

        // Functions
        public void cargarImagen(string url)
        {
            try
            {
                pbFoto.Load(url);
            }
            catch (Exception)
            {
                pbFoto.Load("https://img.freepik.com/vector-premium/icono-avatar-masculino-persona-desconocida-o-anonima-icono-perfil-avatar-predeterminado-usuario-redes-sociales-hombre-negocios-silueta-perfil-hombre-aislado-sobre-fondo-blanco-ilustracion-vectorial_735449-122.jpg");
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";

            if(archivo.ShowDialog() == DialogResult.OK)
            {
                txtFoto.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }
        }
    }
}

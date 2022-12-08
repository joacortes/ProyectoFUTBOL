using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace futbol_app
{
    public partial class frmJugador : Form
    {
        private List<Jugador> listaJugador;
        private List<string> listaCampos = new List<string>() { "Nombre", "Apellido", "Equipo"};
        private List<string> listaCriterio = new List<string>() { "Empieza con", "Termina con", "Contiene" };

        // Constructor
        public frmJugador()
        {
            InitializeComponent();
        }

        // Events
        private void frmJugador_Load(object sender, EventArgs e)
        {
            foreach(var list in listaCampos)
                cmbCampo.Items.Add(list);

            actualizar();
        }
        private void dgvJugadores_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvJugadores.CurrentRow != null)
            {
                Jugador jugadorSeleccionado = (Jugador)dgvJugadores.CurrentRow.DataBoundItem;
                cargarImagen(jugadorSeleccionado.Foto);

            }

        }
        private void btnAgregarJugador_Click(object sender, EventArgs e)
        {
            frmAgregarJugador ventana = new frmAgregarJugador();
            ventana.ShowDialog();
            actualizar();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {

            if(dgvJugadores.CurrentRow != null)
            {
                Jugador seleccionado;

                seleccionado = (Jugador)dgvJugadores.CurrentRow.DataBoundItem;

                frmAgregarJugador mod = new frmAgregarJugador(seleccionado);

                mod.ShowDialog();
                actualizar();
            }
            else
            {
                MessageBox.Show("No se econtro ningún record en la grilla para modificar");
            }
            
        }
        private void btnEliminarJugador_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        private void btnEliminacionLogica_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            JugadorNegocio jugador = new JugadorNegocio();
            try
            {
                if (validarFiltro())
                    return;

                string campo = cmbCampo.SelectedItem.ToString();
                string criterio = cmbCriterio.SelectedItem.ToString();
                string filtro = txtSetFiltro.Text;
                dgvJugadores.DataSource = jugador.filtrar(campo, criterio, filtro);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<Jugador> listaFiltrada;
            string filtro = txtFiltro.Text;

            if (filtro != "")
                listaFiltrada = listaJugador.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
            else
                listaFiltrada = listaJugador;

            dgvJugadores.DataSource = null;
            dgvJugadores.DataSource = listaFiltrada;
            sacarColumnas();
        }
        private void cmbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCampo.SelectedItem != null)
            {
                cmbCriterio.Items.Clear();
                foreach (var list in listaCriterio)
                    cmbCriterio.Items.Add(list);
            }
        }

        // In this place, put in the functions.
        public bool validarFiltro()
        {
            if (cmbCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe ingresar el campo");
                return true;
            }
            if(cmbCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Debe ingresar el criterio");
                return true;
            }

            // En caso de que sea un número, en mi programa no es necsario.

            //if(cmbCampo.SelectedItem.ToString() == "Numero")
            //{
            //    if(string.IsNullOrEmpty(txtSetFiltro.Text))
            //    {
            //        MessageBox.Show("No debe estar vacio");
            //        return true;
            //    }
            //    if (!(isNumber(txtSetFiltro.Text)))
            //    {
            //        MessageBox.Show("Debe ser númerico");
            //        return true;
            //    }
            //}

            return false;
        }
        // Function to validate if it's a number
        //public bool isNumber(string cadena)
        //{
        //    foreach(char caracter in cadena)
        //    {
        //        if (!(char.IsNumber(caracter)))
        //            return false;
        //    }
        //    return true;
        //}
        public void eliminar(bool tipo = false)
        {
            JugadorNegocio negocio = new JugadorNegocio();
            Jugador seleccionado;

            try
            {

                DialogResult respuesta = MessageBox.Show("¿Desea eliminar el jugador?", "Eliminar jugador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Jugador)dgvJugadores.CurrentRow.DataBoundItem;

                    if (tipo)
                        negocio.deleteLogicPlayer(seleccionado.Id);
                    else
                        negocio.deletePlayer(seleccionado.Id);

                    actualizar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbFoto.Load(imagen);
            }
            catch (Exception)
            {
                pbFoto.Load("https://img.freepik.com/vector-premium/icono-avatar-masculino-persona-desconocida-o-anonima-icono-perfil-avatar-predeterminado-usuario-redes-sociales-hombre-negocios-silueta-perfil-hombre-aislado-sobre-fondo-blanco-ilustracion-vectorial_735449-122.jpg");
            }
        }
        public void actualizar()
        {
            JugadorNegocio jugador = new JugadorNegocio();
            try
            {
                listaJugador = jugador.listar();
                dgvJugadores.DataSource = listaJugador;
                sacarColumnas();

                cargarImagen(listaJugador[0].Foto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void sacarColumnas()
        {
            dgvJugadores.Columns["Foto"].Visible = false;
            dgvJugadores.Columns["Id"].Visible = false;
            dgvJugadores.Columns["Activo"].Visible = false;
        }
        
    }
}

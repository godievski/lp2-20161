using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MiColegio.Controlador;
using MiColegio.Modelo;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace MiColegio.Vista
{
    public partial class frmHorario : Form
    {
        private GestorNivel gestorNivel;
        private GestorCurso gestorCurso;
        private GestorProfesor gestorProfesor;
        private GestorHorario gestorHorario;

        private int nroHoraActual;

        public frmHorario()
        {
            InitializeComponent();
            this.gestorNivel = new GestorNivel();
            this.gestorCurso = new GestorCurso();
            this.gestorProfesor = new GestorProfesor();
            this.gestorHorario = new GestorHorario();
            this.nroHoraActual = 1;

            //Cargar datos de los gestores
            this.gestorNivel.CargarDatosXML();
            this.gestorCurso.CargarDatos();
            this.gestorProfesor.CargarDatosXML();
            cmbDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCurso.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDocente.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void frmHorario_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < gestorNivel.Count; i++) 
                this.cmbNivel.Items.Add(gestorNivel[i].Tipo);
            this.habilitarHorasClase(false);
            this.limpiarDatos();
            this.gridHorario.Rows.Clear();
            this.cmbDia.SelectedIndex = 0;
            this.cmbNivel.SelectedIndex = 0;
            this.cmbGrado.SelectedIndex = 0;
            this.cmbSeccion.SelectedIndex = 0;
            this.deserializar();
        }

        private void habilitarHorasClase(bool valor)
        { 
            this.cmbCurso.Enabled = valor;
            this.cmbDocente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
        }

        private void limpiarDatos()
        {
            this.cmbDia.Text = "";
            this.cmbNivel.Text = "";

            this.cmbGrado.Text = "";
            this.cmbGrado.Items.Clear();

            this.cmbSeccion.Text = "";
            this.cmbSeccion.Items.Clear();

            this.limpiarDatosHorasClase();
        }

        private void limpiarDatosHorasClase()
        {
            this.cmbCurso.Text = "";
            this.cmbCurso.Items.Clear();

            this.cmbDocente.Text = "";
            this.cmbDocente.Items.Clear();
            
            this.txtAula.Text = "";
            this.txtNroHora.Text = "";
            this.txtHoraInicio.Text = "";
            this.txtHoraFin.Text = "";
        }

        private void cmbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Borrar el contenido del combo del grado
            this.cmbGrado.Text = "";
            this.cmbGrado.Items.Clear();
            this.cmbSeccion.Text = "";
            this.cmbSeccion.Items.Clear();

            //Cargar grados del nivel
            int index = this.cmbNivel.SelectedIndex;
            Nivel nivel = gestorNivel[index];
            for (int i = 0; i < nivel.NumGrados(); i++)
                this.cmbGrado.Items.Add(nivel[i].NumGrado);
            this.cmbGrado.SelectedIndex = 0;
        }

        private void cmbGrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Borrar el contenido del combo de la seccion
            this.cmbSeccion.Text = "";
            this.cmbSeccion.Items.Clear();

            //Cargar secciones del grado
            int indexNivel = this.cmbNivel.SelectedIndex;
            int indexGrado = this.cmbGrado.SelectedIndex;
            Grado grado = gestorNivel[indexNivel][indexGrado];
            for (int i = 0; i < grado.NumSecciones(); i++)
                this.cmbSeccion.Items.Add(grado[i].IdSeccion);
            this.cmbSeccion.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener indices de los combobox
                int indexNivel = this.cmbNivel.SelectedIndex;
                int indexGrado = this.cmbGrado.SelectedIndex;
                int indexSeccion = this.cmbSeccion.SelectedIndex;
                int indexDia = this.cmbDia.SelectedIndex;

                //Obtener datos de los combobox
                string diaSemana = this.cmbDia.Text;
                string nivel = this.cmbNivel.Text;
                int grado = int.Parse(this.cmbGrado.Text);
                string seccion = this.cmbSeccion.Text;

                //Habilitar los campos del medio y borrar los datos
                this.habilitarHorasClase(true);
                this.limpiarDatosHorasClase();

                /* Cargar cursos segun nivel (el indexNivel funciona porque se añade en el 
                 * orden en el que estan en la lista) */
                this.cmbCurso.Items.Clear(); 
                Nivel datosNivel = this.gestorNivel[indexNivel];
                for (int i = 0; i < gestorCurso.numCursos(); i++)
                    if (gestorCurso[i].Nivel.Tipo == datosNivel.Tipo)
                        this.cmbCurso.Items.Add(gestorCurso[i].Nombre);

                //Cargar docentes
                this.cmbDocente.Items.Clear(); 
                for (int i = 0; i < gestorProfesor.Count; i++)
                    this.cmbDocente.Items.Add(gestorProfesor[i].Nombre);

                //Colocar aula
                this.txtAula.Text = gestorNivel[indexNivel][indexGrado][indexSeccion].Aula.ToString();
                
                //Llenar grilla                
                this.CargarGrilla(diaSemana, nivel, grado, seccion);

                //Obtener numero de hora a partir del cual trabajar
                this.nroHoraActual = this.gestorHorario.ObtenerNumHorarios(diaSemana, nivel, grado, seccion) + 1;
                this.txtNroHora.Text = this.nroHoraActual.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Por favor, seleccione todos los parámetros de búsqueda " +
                    "y asegúrese de que estos parámetros sean válidos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, seleccione todos los parámetros de búsqueda " +
                    "y asegúrese de que estos parámetros sean válidos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNroHora_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int index = int.Parse(this.txtNroHora.Text);
                this.txtHoraInicio.Text = GestorHorario.calcularHoraInicio(index);
                this.txtHoraFin.Text = GestorHorario.calcularHoraFin(index);
            }
            catch (FormatException)
            {
                this.txtHoraInicio.Text = "";
                this.txtHoraFin.Text = "";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener índices de los combobox
                int indexNivel = this.cmbNivel.SelectedIndex;
                int indexGrado = this.cmbGrado.SelectedIndex;
                int indexSeccion = this.cmbSeccion.SelectedIndex;
                int indexDia = this.cmbDia.SelectedIndex;
                int indexDocente = this.cmbDocente.SelectedIndex;

                //Obtener datos de los combobox
                string diaSemana = this.cmbDia.Text;
                string nivel = this.cmbNivel.Text;
                int grado = int.Parse(this.cmbGrado.Text);
                string seccion = this.cmbSeccion.Text;

                //Agregar datos del horario a la lista que corresponde
                Nivel objNivel = this.gestorNivel[indexNivel];
                Grado objGrado = objNivel[indexGrado];
                Seccion objSeccion = objGrado[indexSeccion];
                Profesor docente = this.gestorProfesor[indexDocente];
                Curso curso = this.gestorCurso.BuscarCurso(this.cmbCurso.Text);
                Horario horario = new Horario(diaSemana, objNivel, objGrado, objSeccion, docente, curso,
                    this.nroHoraActual, this.txtHoraInicio.Text, this.txtHoraFin.Text);
                this.gestorHorario.AnadirHorario(horario);

                //Llenar datos a la grilla
                this.CargarGrilla(diaSemana, nivel, grado, seccion);

                //Continuar con la siguiente hora
                ++this.nroHoraActual;
                this.txtNroHora.Text = this.nroHoraActual.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Por favor, asegúrese de que los datos ingresados sean válidos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, seleccione todos los parámetros de búsqueda " +
                    "y asegúrese de que estos parámetros sean válidos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla(string dia, string nivel, int grado, string seccion)
        {
            this.gridHorario.Rows.Clear();
            List<Horario> horarios = this.gestorHorario.ObtenerHorarios(dia, nivel, grado, seccion);
            for (int i = 0; i < horarios.Count; i++)
            {                
                string[] fila = new string[6];
                fila[0] = horarios[i].DiaSemana;
                fila[1] = horarios[i].Docente;
                fila[2] = horarios[i].Curso;
                fila[3] = horarios[i].NumHora.ToString();
                fila[4] = horarios[i].HoraInicio;
                fila[5] = horarios[i].HoraFin;
                this.gridHorario.Rows.Add(fila);
            }
        }

        private void cmbDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btrSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void serializar()
        {
            Stream stream = File.Open("todo.bin", FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, this.gestorHorario);
            stream.Close();
        }
        private void deserializar()
        {
            try
            {
                Stream stream = File.Open("todo.bin", FileMode.Open);
                BinaryFormatter bin = new BinaryFormatter();
                this.gestorHorario = (GestorHorario)bin.Deserialize(stream);
                stream.Close();
            }
            catch (Exception exp)
            {
                //NO HAY ARCHIVO
                //NO CARGA
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.serializar();
        }
    }
}

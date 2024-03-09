using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejer_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            string nombre = txt_Nombre.Text.Trim();
            string correo = txt_Correo.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Agregar una nueva fila al DataGridView
            dataGridView1.Rows.Add(nombre, correo);

            // Limpiar los campos de texto después de agregar la fila
            LimpiarCampos();

            // Devolver el foco al campo Nombre
            txt_Nombre.Focus();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            dataGridView1.Rows.Clear();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LimpiarCampos()
        {
           
            txt_Nombre.Clear();
            txt_Correo.Clear();            
            txt_Nombre.Focus();
        }


        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para eliminar.", "Datos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

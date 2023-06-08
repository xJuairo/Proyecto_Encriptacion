using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Seguridad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void encriptarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Encrypt encriptarForm = new Encrypt();
            this.Hide();
            encriptarForm.ShowDialog();
            this.Show();
        }

        private void desencriptarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Desencriptar desencriptarForm = new Desencriptar();
            this.Hide();
            desencriptarForm.ShowDialog();
            this.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Encrypt encriptarForm = new Encrypt();
            this.Hide();
            encriptarForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Desencriptar desencriptarForm = new Desencriptar();
            this.Hide();
            desencriptarForm.ShowDialog();
            this.Show();
        }
    }
}

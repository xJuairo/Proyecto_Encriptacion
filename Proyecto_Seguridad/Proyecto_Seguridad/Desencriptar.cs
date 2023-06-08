using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Seguridad
{
    public partial class Desencriptar : Form
    {
        public Desencriptar()
        {
            InitializeComponent();
        }

        private void Abrir_archivo_Click(object sender, EventArgs e)
        {
            // Crear un OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
            openFileDialog.Title = "Seleccionar archivo encriptado para abrir";

            // Mostrar el cuadro de diálogo para seleccionar el archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Leer el contenido del archivo seleccionado
                string contenidoArchivo = File.ReadAllText(openFileDialog.FileName);

                // Mostrar el contenido en el cuadro de texto deseado
                inputbox.Text = contenidoArchivo;
            }
        }

        private void Decryptbtn_Click(object sender, EventArgs e)
        {
            string pythonScript = "comparador.py";
            string archivoParametro1 = "audio.wav";
            string archivoParametro2 = "voice.wav";

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "WPy64-31090/python-3.10.9.amd64/python.exe";
            startInfo.Arguments = $"{pythonScript} {archivoParametro1} {archivoParametro2}";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);

            inputbox.Text = output;

            string mensajeEncriptado = inputbox.Text;
            string mensaje;
            if (!string.IsNullOrEmpty(mensajeEncriptado))
                {
                    mensaje=DesencriptarMensaje(mensajeEncriptado);
                    outputbox.Text = mensaje;
                    stepsbox.Text = GenerarPasosDesencriptacion(mensajeEncriptado);
            }
                else
                {
                    MessageBox.Show("No hay mensaje encriptado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private string DesencriptarMensaje(string mensajeEncriptado)
        {
            //// Permutación inversa
            //char[] caracteresDesencriptados = mensajeEncriptado.ToCharArray();
            //Random random = new Random();
            //for (int i = 1; i < caracteresDesencriptados.Length; i++)
            //{
            //    int j = random.Next(i);
            //    char temp = caracteresDesencriptados[i];
            //    caracteresDesencriptados[i] = caracteresDesencriptados[j];
            //    caracteresDesencriptados[j] = temp;
            //}
            //string mensajePermutado = new string(caracteresDesencriptados);

            // Sustitución inversa
            string mensajeDesencriptado = "";
            foreach (char c in mensajeEncriptado)
            {
                int asciiValue = (int)c;
                int decryptedAsciiValue = (asciiValue - 5 + 256) % 256; // Deshacer el desplazamiento y módulo 256
                char decryptedChar = (char)decryptedAsciiValue;
                mensajeDesencriptado += decryptedChar;
            }

            return mensajeDesencriptado;
        }
        private string GenerarPasosDesencriptacion(string mensaje)
        {
            string pasos = "";

            // Lógica para generar los pasos de encriptación
            // Puedes ajustar este algoritmo según tus necesidades

            // Sustitución
            pasos += "Sustitución:\r\n";

            foreach (char c in mensaje)
            {
                int asciiValue = (int)c;
                int decryptedAsciiValue = (asciiValue - 5 + 256) % 256; // Deshacer el desplazamiento y módulo 256
                char decryptedChar = (char)decryptedAsciiValue;
                pasos += string.Format("Carácter '{0}' desencriptado como '{1}'\r\n", c, decryptedChar);
            }



            // Permutación
            //pasos += "\r\nPermutación:\r\n";
            //Random random = new Random();
            //char[] caracteresEncriptados = mensaje.ToCharArray();
            //for (int i = caracteresEncriptados.Length - 1; i > 0; i--)
            //{
            //    int j = random.Next(i + 1);
            //    char temp = caracteresEncriptados[i];
            //    caracteresEncriptados[i] = caracteresEncriptados[j];
            //    caracteresEncriptados[j] = temp;

            //    pasos += string.Format("Carácter '{0}' intercambiado con carácter '{1}'\r\n", caracteresEncriptados[i], caracteresEncriptados[j]);
            //}
            return pasos;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using NAudio.Wave;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Proyecto_Seguridad
{
    public partial class Encrypt : Form

    {
        private WaveFileWriter writer;
        private WaveInEvent waveInEvent;
        private string outputPath;
        public Encrypt()
        {
            InitializeComponent();
            recordingTimer.Tick += recordingTimer_Tick;
        }

        private void Encriptbtn_Click(object sender, EventArgs e)
        {
            string mensaje = inputbox.Text;
            string mensajeEncriptado = EncriptarMensaje(mensaje);
            outputbox.Text = mensajeEncriptado;
            stepsbox.Text = GenerarPasosEncriptacion(mensaje);

            string pythonScript = "script.py";
            string archivoParametro = "audio.wav";
            string cadenaParametro = mensaje;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "C:\\Users\\xjlop\\AppData\\Local\\Microsoft\\WindowsApps\\python.exe";
            startInfo.Arguments = $"{pythonScript} {archivoParametro} \"{cadenaParametro}\"";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);
        }

        private string EncriptarMensaje(string mensaje)
        {
            // Lógica para encriptar el mensaje
            // Puedes ajustar este algoritmo según tus necesidades

            // Sustitución
            string mensajeEncriptado = "";
            foreach (char c in mensaje)
            {
                int asciiValue = (int)c;
                int encryptedAsciiValue = (asciiValue + 5) % 256; // Desplazamiento y módulo 256 para mantenerlo en el rango ASCII
                char encryptedChar = (char)encryptedAsciiValue;
                mensajeEncriptado += encryptedChar;
            }

            //// Permutación
            //char[] caracteresEncriptados = mensajeEncriptado.ToCharArray();
            //Random random = new Random();
            //for (int i = caracteresEncriptados.Length - 1; i > 0; i--)
            //{
            //    int j = random.Next(i + 1);
            //    char temp = caracteresEncriptados[i];
            //    caracteresEncriptados[i] = caracteresEncriptados[j];
            //    caracteresEncriptados[j] = temp;
            //}
            //mensajeEncriptado = new string(caracteresEncriptados);

            return mensajeEncriptado;
        }

        private string GenerarPasosEncriptacion(string mensaje)
        {
            string pasos = "";

            // Lógica para generar los pasos de encriptación
            // Puedes ajustar este algoritmo según tus necesidades

            // Sustitución
            pasos += "Sustitución:\r\n";
            foreach (char c in mensaje)
            {
                int asciiValue = (int)c;
                int encryptedAsciiValue = (asciiValue + 5) % 256; // Desplazamiento y módulo 256 para mantenerlo en el rango ASCII
                char encryptedChar = (char)encryptedAsciiValue;
                pasos += string.Format("Carácter '{0}' encriptado como '{1}'\r\n", c, encryptedChar);
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

        private void Guardar_Click(object sender, EventArgs e)
        {
            string mensajeEncriptado = outputbox.Text;
            // Verificar si el mensaje encriptado está vacío
            if (!string.IsNullOrEmpty(mensajeEncriptado))
            {
                GuardarMensajeEncriptado(mensajeEncriptado);
            }
            else
            {
                MessageBox.Show("No hay mensaje encriptado para guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarMensajeEncriptado(string mensajeEncriptado)
        {
            // Ruta y nombre de archivo donde se guardará el mensaje encriptado
            string rutaArchivo = "mensaje_encriptado.txt";

            // Crear un objeto StreamWriter para escribir en el archivo
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                // Escribir el mensaje encriptado en el archivo
                writer.Write(mensajeEncriptado);
            }

            // Mostrar un mensaje de éxito
            MessageBox.Show("El mensaje encriptado se ha guardado en el archivo " + rutaArchivo, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Ejecutar script de Python
            string rutaPython = "C:\\Users\\xjlop\\AppData\\Local\\Microsoft\\WindowsApps\\python.exe";
            string rutaScript = "";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = rutaPython;
            startInfo.Arguments = rutaScript;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                string resultado = process.StandardOutput.ReadToEnd();
            }

        }

        private void grabar_Click(object sender, EventArgs e)
        {
            if (waveInEvent == null) // Si no se está grabando
            {
                // Generar una ruta de archivo única para guardar la nota de voz
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileName = $"audio.wav";
                outputPath = Path.Combine(Application.StartupPath, fileName);

                // Iniciar la grabación
                waveInEvent = new WaveInEvent();
                waveInEvent.DataAvailable += WaveInEvent_DataAvailable;
                waveInEvent.WaveFormat = new WaveFormat(44100, 1); // 44.1 kHz, mono
                writer = new WaveFileWriter(outputPath, waveInEvent.WaveFormat);

                recordingTimer.Start(); // Iniciar el temporizador de 5 segundos
                waveInEvent.StartRecording();

                grabar.Text = "Detener Grabación";
            }
            else // Si ya se está grabando, detener la grabación
            {
                waveInEvent.StopRecording();
                waveInEvent.Dispose();
                waveInEvent = null;
                writer.Close();
                writer.Dispose();

                recordingTimer.Stop(); // Detener el temporizador
                recordingTimer.Tick -= recordingTimer_Tick;
                grabar.Text = "Iniciar Grabación";

                MessageBox.Show($"La nota de voz se ha guardado en: {outputPath}");
            }
        }
        private void WaveInEvent_DataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void recordingTimer_Tick(object sender, EventArgs e)
        {
            if (waveInEvent != null)
            {
                waveInEvent.StopRecording();
                waveInEvent.Dispose();
                waveInEvent = null;
                writer.Close();
                writer.Dispose();

                recordingTimer.Stop(); // Detener el temporizador

                grabar.Text = "Iniciar Grabación";

                MessageBox.Show($"La nota de voz se ha guardado en: {outputPath}");
            }
        }
    }
}

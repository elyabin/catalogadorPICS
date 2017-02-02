using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Catalogador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSeleccionarRuta_Click(object sender, EventArgs e)
        {
            if (fBDCarpeta.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtRutaEntrada.Text = fBDCarpeta.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fBDCarpeta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRutaSalida.Text = fBDCarpeta.SelectedPath;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {   
            if (string.IsNullOrEmpty(txtRutaEntrada.Text) == false && string.IsNullOrEmpty(txtRutaSalida.Text) == false)
            {
                string rutaEntrada = txtRutaEntrada.Text;               


                List<FileInfo> listadoArchivos = new List<FileInfo>();
                buscarImagenes(rutaEntrada, listadoArchivos);
                procesarSalida(listadoArchivos);
                
                
            }
        }

        private void procesarSalida(List<FileInfo> pListadoArchivos) 
        {
            string rutaSalida = txtRutaSalida.Text;

            string nombreSubCarpeta = "";



            pbArchivos.Maximum = pListadoArchivos.Count;
            pbArchivos.Visible = true;
            int i = 1;

            List<FileInfo> ordenados = (from p in pListadoArchivos
                            orderby p.LastAccessTime
                            select p).ToList<FileInfo>();
                            
            foreach (FileInfo informacionArchivo in ordenados) 
            {

                pbArchivos.Value = i;
                string indiceArchivo = "";

                string fechaArchivo = string.Format("{0}-{1}-{2}", informacionArchivo.LastWriteTime.Day.ToString().PadLeft(2, '0'), informacionArchivo.LastWriteTime.Month.ToString().PadLeft(2, '0'), informacionArchivo.LastWriteTime.Year);

                //crear carpetas en caso de que no exista
                string rutaCarpetaFecha=string.Format(@"{0}\{1}",rutaSalida,fechaArchivo);
                string rutaCarpetaFechaSubCarpeta=string.Format(@"{0}\{1}",rutaCarpetaFecha,nombreSubCarpeta);
                if(Directory.Exists(rutaCarpetaFecha)  == false )
                {
                    Directory.CreateDirectory(rutaCarpetaFecha);                   
                    
                    if(Directory.Exists(rutaCarpetaFechaSubCarpeta)  == false )
                    {
                        Directory.CreateDirectory(rutaCarpetaFechaSubCarpeta);
                    }
                }

                    
                
                
                int indice = 1;
                while (indice != -1) 
                { 
                     
                    string archivoNuevo = string.Format(@"{0}\{1}{2}{3}", rutaCarpetaFechaSubCarpeta, Path.GetFileNameWithoutExtension(informacionArchivo.FullName),indiceArchivo,informacionArchivo.Extension);

                    if (File.Exists(archivoNuevo))
                    {
                        indiceArchivo = indice.ToString();
                        indice++;
                    }
                    else 
                    {
                        File.Copy(informacionArchivo.FullName, archivoNuevo);
                        
                        indice = -1;
                    }
                }
                
            }

            pbArchivos.Visible = false;

            MessageBox.Show("FIN");
        }


        private void buscarImagenes(string pRuta, List<FileInfo> listadoArchivos) 
        {
            string[] carpetas = System.IO.Directory.GetDirectories(pRuta);

            if (carpetas.Count() == 0)
            {
                string[] imagenes = System.IO.Directory.GetFiles(pRuta);
                foreach (string rutaImagen in imagenes) 
                {
                    FileInfo informacionArchivo = new FileInfo(rutaImagen);
                    listadoArchivos.Add(informacionArchivo);
                }
            }
            else 
            {
                for (int i = 0; i < carpetas.Length; i++) 
                {
                    buscarImagenes(carpetas[i], listadoArchivos);
                }
            }
        }
        
    }
}

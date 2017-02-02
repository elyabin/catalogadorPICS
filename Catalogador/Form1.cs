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
                System.Threading.ThreadStart p = new System.Threading.ThreadStart(this.procesarSalida);
                System.Threading.Thread t = new System.Threading.Thread(p);
                t.Start();
            }
        }


        

        private void procesarSalida() 
        {
            string rutaEntrada = txtRutaEntrada.Text;
            List<FileInfo> listadoArchivos = new List<FileInfo>();

            btnIniciar.Invoke(new ModificarControl(this.ModificarControlSeguro), btnIniciar, "Enabled", false);


            mensaje("Obteniendo listado de archivos");
            buscarImagenes(rutaEntrada, listadoArchivos);
            
            mensaje(string.Format("{0} archivos encontrados", listadoArchivos.Count));
            procesarSalida(listadoArchivos);

            btnIniciar.Invoke(new ModificarControl(this.ModificarControlSeguro), btnIniciar, "Enabled", true);
        }

        private void procesarSalida(List<FileInfo> pListadoArchivos)
        {
            string rutaSalida = txtRutaSalida.Text;

            string nombreSubCarpeta = "";
            
            pbArchivos.Invoke(new ModificaBarra(ModificaBarrasSeguro), pbArchivos, "Maximun", pListadoArchivos.Count);            
            pbArchivos.Invoke(new ModificaBarra(ModificaBarrasSeguro), pbArchivos, "Visible", true);

            int i = 1;
            List<FileInfo> ordenados = (from p in pListadoArchivos
                                        orderby p.LastAccessTime
                                        select p).ToList<FileInfo>();

            foreach (FileInfo informacionArchivo in ordenados)
            {                                
                mensaje(string.Format("{0} archivos encontrados.Procesando archivo {1}", pListadoArchivos.Count, i));
                
                pbArchivos.Invoke(new ModificaBarra(ModificaBarrasSeguro), pbArchivos, "Value", i++);
                string indiceArchivo = "";

                string fechaArchivo = string.Format("{0}-{1}-{2}", informacionArchivo.LastWriteTime.Day.ToString().PadLeft(2, '0'), informacionArchivo.LastWriteTime.Month.ToString().PadLeft(2, '0'), informacionArchivo.LastWriteTime.Year);

                //crear carpetas en caso de que no exista
                string rutaCarpetaFecha = string.Format(@"{0}\{1}", rutaSalida, fechaArchivo);
                string rutaCarpetaFechaSubCarpeta = string.Format(@"{0}\{1}", rutaCarpetaFecha, nombreSubCarpeta);
                if (Directory.Exists(rutaCarpetaFecha) == false)
                {
                    Directory.CreateDirectory(rutaCarpetaFecha);

                    if (Directory.Exists(rutaCarpetaFechaSubCarpeta) == false)
                    {
                        Directory.CreateDirectory(rutaCarpetaFechaSubCarpeta);
                    }
                }


                int indice = 1;
                while (indice != -1)
                {

                    string archivoNuevo = string.Format(@"{0}\{1}{2}{3}", rutaCarpetaFechaSubCarpeta, Path.GetFileNameWithoutExtension(informacionArchivo.FullName), indiceArchivo, informacionArchivo.Extension);

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

            pbArchivos.Invoke(new ModificaBarra(ModificaBarrasSeguro), pbArchivos, "Visible", true);

            MessageBox.Show("FIN");
            pbArchivos.Invoke(new ModificaBarra(ModificaBarrasSeguro), pbArchivos, "Visible", false);
            mensaje("");
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


        #region metodos label mensaje
        public delegate void ActualizarTexto(Label plblMensaje , string  pTexto);
        public void mensaje(string pMensaje) 
        {
            
            lblMensaje.Invoke(new ActualizarTexto(this.mensajeSeguro),lblMensaje,  pMensaje );
        }

        public void mensajeSeguro(Label plblMensaje,string pTexto) 
        {
            lblMensaje.Text = pTexto;
        }

        #endregion


        #region metodos progess bar

        
        
        


        public delegate void ModificaBarra(ProgressBar pBarra, string pPropiedad, object valor);

        public void ModificaBarrasSeguro(ProgressBar pBarra, string pPropiedad, object valor)
        {
            if (pPropiedad.Equals("Maximun")) 
            {
                pBarra.Maximum = Convert.ToInt32(valor);
            }
            else if (pPropiedad.Equals("Value")) 
            {
                pBarra.Value = Convert.ToInt32(valor);
            }
            else if (pPropiedad.Equals("Visible"))
            {
                pBarra.Visible = Convert.ToBoolean(valor);
            }
        }

         #endregion

        #region metodo genericos

        public delegate void ModificarControl(Control pControl,string pPropiedad,object pValor);

        public void ModificarControlSeguro(Control pControl,string pPropiedad,object pValor)
        {
            if (pPropiedad.Equals("Enabled")) 
            {
                pControl.Enabled = Convert.ToBoolean (pValor);
            }
        }

        #endregion




    }
}

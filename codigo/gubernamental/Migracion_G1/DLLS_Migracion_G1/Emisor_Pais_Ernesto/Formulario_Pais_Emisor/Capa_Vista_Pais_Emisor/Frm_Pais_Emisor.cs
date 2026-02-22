using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Ernesto Samayoa 0901-22-3415
namespace Capa_Vista_Pais_Emisor
{
    public partial class Frm_Pais_Emisor : Form
    {
        public Frm_Pais_Emisor()
        {
            {
                InitializeComponent();
                //parametros para navegador
                Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView config = new Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView
                {
                    Ancho = 1100,
                    Alto = 200,
                    PosX = 10,
                    PosY = 300,
                    ColorFondo = Color.AliceBlue,
                    TipoScrollBars = ScrollBars.Both,
                    Nombre = "dgv_empleados"
                };

                string[] columnas = {
                "tbl_pais_emisor",
                "Pk_Id_Pais_Emisor",
                "Cmp_Nombre_Pais",
                "Cmp_Codigo_Pais"
            };

                string[] sEtiquetas = {
                "Id Pais Emisor",
                "Nombre Pais",
                "Codigo Pais"
            };



                int id_aplicacion = 312;
                navegador1.IPkId_Modulo = 4;
                navegador1.IPkId_Aplicacion = id_aplicacion;
                navegador1.configurarDataGridView(config);
                navegador1.SNombreTabla = columnas[0];
                navegador1.SAlias = columnas;
                navegador1.SEtiquetas = sEtiquetas;
                navegador1.mostrarDatos();
            }

        }
    }
}

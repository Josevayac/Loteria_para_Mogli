using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoteriaNacionalCR.LoteriaWebService;

namespace LoteriaNacionalCR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            LoteriaWebService.LoteriaNacionalClient oLoteriaWebService = new LoteriaNacionalClient();
            Sorteo oSorteo = new Sorteo();
            oSorteo.Fecha = dateTimePicker1.Value;
            oSorteo.Titulo = txtTitulo.Text;

            oLoteriaWebService.AgregarSorteo(oSorteo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMIDAS
{
    public partial class Form1 : Form
    {
        Comidas oComidas;
        DataTable tCom;

        MeGustan oMeGustan;
        DataTable tGus;

        Personas oPersonas;
        DataTable tPer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oComidas = new Comidas();
            tCom = oComidas.getData();

            oMeGustan = new MeGustan();
            tGus = oMeGustan.getData();

            oPersonas = new Personas();
            tPer = oPersonas.getData();

            cbPersona.DisplayMember = "nombre";
            cbPersona.ValueMember = "dni";
            cbPersona.DataSource = tPer;
        }

        private void cbPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            grilla.Rows.Clear();

            foreach(DataRow fGus in tGus.Rows)
            {
                if (fGus["dni"].ToString()==cbPersona.SelectedValue.ToString())
                {
                    DataRow fCom = tCom.Rows.Find(fGus["comida"]);
                    grilla.Rows.Add(fCom["comida"], fCom["nombre"]);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int id = 0;
            using (var servicioPersona = new ServicePersona.ServicePersonaClient())
            {
                if (!string.IsNullOrEmpty(txtId.Text) && int.TryParse(txtId.Text, out id))
                {
                    var persona = servicioPersona.GetPersona(id);
                    try
                    {
                        MessageBox.Show($"{persona.Nombre} y {persona.Edad} años");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    foreach (var persona in servicioPersona.GetPersonas())
                    {
                        MessageBox.Show($"{persona.Nombre} y {persona.Edad} años");
                    }
                }
            }
        }
    }
}

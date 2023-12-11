using FinalBasesDatosII.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalBasesDatosII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DiccionarioDatos dd = new DiccionarioDatos();
        Servicios servicios = new Servicios();

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string sentenciaUpdate = txtUpdate.Text.Trim();
            sentenciaUpdate = sentenciaUpdate.ToUpper();

            if (servicios.ValidarSintaxis(sentenciaUpdate)) {
            }
                 
        }




   
        
        
        
        private bool Update1column(String sentencia)
        {
            string pattern = @"^UPDATE\s+([\w\d_]+)\s+SET\s+(\w+\s*=\s*[\w\d']+)\s+WHERE\s+(.+);$";
            Match match = Regex.Match(sentencia, pattern);
            if (match.Success)
                return true;
            return false;
        }
        private bool Update2column(String sentencia)
        {
            string pattern = @"^UPDATE\s+([\w\d_]+)\s+SET\s+(\w+\s*=\s*[\w\d']+,\s*\w+\s*=\s*[\w\d']+)\s+WHERE\s+(.+);$";
            Match match = Regex.Match(sentencia, pattern);
            if (match.Success)
                return true;
            return false;
        }
        private bool Update3column(String sentencia)
        {
            string pattern = @"^UPDATE\s+([\w\d_]+)\s+SET\s+(\w+\s*=\s*[\w\d']+,\s*\w+\s*=\s*[\w\d']+,\s*\w+\s*=\s*[\w\d']+)\s+WHERE\s+(.+);$";
            Match match = Regex.Match(sentencia, pattern);
            if (match.Success)
                return true;
            return false;
        }
        private bool Update4column(String sentencia)
        {
            string pattern= @"^UPDATE\s+([\w\d_]+)\s+SET\s+(\w+\s*=\s*[\w\d']+,\s*\w+\s*=\s*[\w\d']+,\s*\w+\s*=\s*[\w\d']+,\s*\w+\s*=\s*[\w\d']+)\s+WHERE\s+(.+);$";
            Match match = Regex.Match(sentencia, pattern);
            if (match.Success)
                return true;
            return false;
        }
    }
}

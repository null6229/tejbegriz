using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace templateNev
{
    public partial class Form1 : Form
    {
        Adatbazis adatbazis = new Adatbazis();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxUpdate();
        }

        private void listBoxUpdate()
        {
            listbox_Template.Items.Clear();
            listbox_Template.Items.AddRange(adatbazis.getAll().ToArray());
        }
    }
}

using System.Windows.Forms;
using DataLib;

namespace HW
{
    public partial class Form1 : Form
    {
        private Data data;
        public Form1()
        {
            data = new Data();
            InitializeComponent();
            panel1.Controls.Clear();

            
        }

        private void графикToolStripMenuItem_Click_1(object sender, System.EventArgs e)
        {
            panel1.Controls.Clear();

            Graph g = new Graph(data.input);

            g.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(g);
        }

        private void таблицаToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            panel1.Controls.Clear();

            DataTable table = new DataTable(data.input);

            table.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(table);
        }
    }
}

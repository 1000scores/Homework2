using System.Windows.Forms;
using DataLib;

namespace HW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Data data = new Data();
            InitializeComponent();
            Graph g = new Graph(data.input);

            g.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(g);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataLib;
using System.Drawing;

namespace HW
{
    public partial class Graph : UserControl
    {
        HashSet<string> names = new HashSet<string>();
        HashSet<int> years = new HashSet<int>();

        int[] mounth_value = new int[12];

        List<Element> current_elements = new List<Element>();

        private string[] Mounths =
        {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрть"
        };

        private List<Element> elements;
        public Graph(List<Element> elements)
        {
            this.elements = elements;
            InitializeComponent();

            foreach (var item in elements)
            {
                names.Add(item.name);
            }

            foreach (var item in names)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void Draw_button_Click(object sender, EventArgs e)
        {

        }

        private void Draw(Graphics gr)
        {
            // Подготовка холста.
            gr.Clear(Color.Azure);

            int xMax = pictureBox1.ClientSize.Width;
            int yMax = pictureBox1.ClientSize.Height;

            int xMinRis = xMax / 10, wRis = xMax * 8 / 10, xMaxRis = xMax * 9 / 10,
                yMinRis = yMax / 10, hRis = yMax * 8 / 10, yMaxRis = yMax * 9 / 10;

            gr.FillRectangle(new SolidBrush(Color.White), xMinRis, yMinRis, wRis, hRis);

            Pen pen1 = new Pen(Color.Black);

            gr.DrawLine(pen1, xMinRis, yMaxRis, xMaxRis, yMaxRis);
            gr.DrawLine(pen1, xMinRis, yMaxRis, xMinRis, yMinRis);

            double alfa;

            int maxRisOfRec = 1;
            for (int i = 0; i<12; i++)
            {
                if (mounth_value[i] > maxRisOfRec)
                    maxRisOfRec = mounth_value[i];
            }

            for (int i = 1; i <= 12; i++)
            {
                float h, w = 10;

                h = 1f*mounth_value[i - 1] / maxRisOfRec;
                h = hRis * h;
                alfa = i / 12f;
                if (mounth_value[i - 1] != 0)
                { 
                    gr.FillRectangle(new SolidBrush(Color.SteelBlue),
                        (int) (xMaxRis * (alfa) + (1 - alfa) * xMinRis) - 4 * wRis / 70, yMaxRis - h, w, h);
                    gr.DrawString(mounth_value[i-1].ToString(),Font,new SolidBrush(Color.Black), 
                        (int)(xMaxRis * (alfa) + (1 - alfa) * xMinRis) - 3*wRis/70, yMaxRis - h);
                }

                gr.DrawString(Mounths[i - 1], Font, new SolidBrush(Color.Black), 
                    (int)(xMaxRis * (alfa) + (1 - alfa) * xMinRis) - 5 * wRis / 70, yMaxRis + hRis / 70);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }



        private void Graph_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            years.Clear();
            comboBox2.Items.Clear();

            foreach (var item in elements)
            {
                if (item.name.Equals(comboBox1.SelectedItem))
                    years.Add(item.year);
            }

            foreach (var item in years)
            {
                comboBox2.Items.Add(item.ToString());
            }

            comboBox2.SelectedIndex = 0;
        }

        private int MounthNumber(string mounth)
        {
            int number = 0;
            for (int i = 0; i < 12; i++)
                if (Mounths[i].Equals(mounth))
                {
                    number = i;
                    break;
                }

            return number;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mounth_value = new int[12];

            foreach (var item in elements)
            {
                if (item.name.Equals(comboBox1.SelectedItem) && item.year == Convert.ToInt32(comboBox2.SelectedItem))
                {
                    mounth_value[MounthNumber(item.month)] = item.numberOfCalls;
                }
            }

            Draw(pictureBox1.CreateGraphics());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataLib;
using System.Drawing;

namespace HW
{
    public partial class Graph : UserControl
    {
        // Set с названиями округов.
        HashSet<string> names = new HashSet<string>();

        // Set с годами для данного округа.
        HashSet<int> years = new HashSet<int>();


        // Показатель каждого месяца.
        int[] mounth_value = new int[12];

        // Массив всех месяцев.
        private string[] Mounths =
        {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрть"
        };

        // Элементы загруженные в usercontrol.
        private List<Element> elements;

        public Graph(List<Element> elements)
        {
            this.elements = elements;
            InitializeComponent();

            // Установка значений первого комбо бокса.
            foreach (var item in elements)
            {
                names.Add(item.name);
            }

            foreach (var item in names)
            {
                comboBox1.Items.Add(item);
            }
        }

        /// <summary>
        /// Рисует график
        /// </summary>
        /// <param name="gr">
        /// Graphics на котором надо рисовать.
        /// </param>
        private void Draw(Graphics gr)
        {
            // Подготовка холста.
            gr.Clear(Color.Azure);

            // Установка размеров.
            int xMax = pictureBox1.ClientSize.Width;
            int yMax = pictureBox1.ClientSize.Height;

            int xMinRis = xMax / 10, wRis = xMax * 8 / 10, xMaxRis = xMax * 9 / 10,
                yMinRis = yMax / 10, hRis = yMax * 8 / 10, yMaxRis = yMax * 9 / 10;

            gr.FillRectangle(new SolidBrush(Color.White), xMinRis, yMinRis, wRis, hRis);

            Pen pen1 = new Pen(Color.Black);

            // Отрисовка координат.
            gr.DrawLine(pen1, xMinRis, yMaxRis, xMaxRis, yMaxRis);
            gr.DrawLine(pen1, xMinRis, yMaxRis, xMinRis, yMinRis);

            // Переменная для прощета процентного соотношения.
            double alfa;

            // Максимально значение для данного графика.
            int maxRisOfRec = 1;

            // Поиск максимума.
            for (int i = 0; i < 12; i++)
            {
                if (mounth_value[i] > maxRisOfRec)
                    maxRisOfRec = mounth_value[i];
            }

            // Отрисовка графика.
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

        /// <summary>
        /// Отрисовка графика.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }


        /// <summary>
        /// Перересовка графика при изменении
        /// размеров формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Graph_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Настройка второго combobox
        /// после выбора первого.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Получает номер месяца.
        /// </summary>
        /// <param name="mounth">
        /// Название месяца.
        /// </param>
        /// <returns>
        /// Номер месяца с 0(счет идет с Января).
        /// </returns>
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

        /// <summary>
        /// Отрисовка графика после выбора
        /// второго combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

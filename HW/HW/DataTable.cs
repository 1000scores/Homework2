using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLib;

namespace HW
{
    public partial class DataTable : UserControl
    {
        private List<Element> elements;
        public DataTable(List<Element> elements)
        {
            InitializeComponent();
            this.Load += new EventHandler(Form_Load);
            this.elements = elements;
        }

        private void Form_Load(Object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        /// <summary>
        /// Настраивает таблицу.
        /// </summary>
        private void PopulateDataGridView()
        {
            dataGridView.DataSource = elements;
            dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.GridColor = Color.Black;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            foreach (DataGridViewTextBoxColumn column in dataGridView.Columns)
            {
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Width = 80;
            }
            dataGridView.Columns[0].HeaderText = "Административный округ";
            dataGridView.Columns[0].Width = 280;
            dataGridView.Columns[1].HeaderText = "Год";
            dataGridView.Columns[2].HeaderText = "Месяц";
            dataGridView.Columns[3].HeaderText = "Количество вызовов";
            dataGridView.Columns[3].Width = 130;
        }

        /// <summary>
        /// Условие сравнения елементов по году.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="otherElement"></param>
        /// <returns>int</returns>
        private int CompareElementsByYear(Element element, Element otherElement)
        {
            if (element.Year > otherElement.Year)
            {
                return 1;
            }
            else if (element.Year == otherElement.Year)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Условие сравнения елементов по количеству вызовов.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="otherElement"></param>
        /// <returns>int</returns>
        private int CompareElementsByCallsCount(Element element, Element otherElement)
        {
            if (element.NumberOfCalls > otherElement.NumberOfCalls)
            {
                return 1;
            }
            else if (element.NumberOfCalls == otherElement.NumberOfCalls)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Условие сравнения елементов по названию округа.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="otherElement"></param>
        /// <returns>int</returns>
        private int CompareElementsByOkrugName(Element element, Element otherElement)
        {
            return String.Compare(element.Name, otherElement.Name);
        }

        private void yearSortButton_Click(object sender, EventArgs e)
        {
            elements.Sort(CompareElementsByYear);
            PopulateDataGridView();
        }

        private void callCountSortButton_Click(object sender, EventArgs e)
        {
            elements.Sort(CompareElementsByCallsCount);
            PopulateDataGridView();
        }

        private void okrugNameSortButton_Click(object sender, EventArgs e)
        {
            elements.Sort(CompareElementsByOkrugName);
            PopulateDataGridView();
        }
    }
}

namespace HW
{
    partial class DataTable
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.yearSortButton = new System.Windows.Forms.Button();
            this.callCountSortButton = new System.Windows.Forms.Button();
            this.okrugNameSortButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(595, 419);
            this.dataGridView.TabIndex = 1;
            // 
            // yearSortButton
            // 
            this.yearSortButton.Location = new System.Drawing.Point(611, 21);
            this.yearSortButton.Name = "yearSortButton";
            this.yearSortButton.Size = new System.Drawing.Size(124, 34);
            this.yearSortButton.TabIndex = 2;
            this.yearSortButton.Text = "Сортировать по году";
            this.yearSortButton.UseVisualStyleBackColor = true;
            this.yearSortButton.Click += new System.EventHandler(this.yearSortButton_Click);
            // 
            // callCountSortButton
            // 
            this.callCountSortButton.Location = new System.Drawing.Point(611, 74);
            this.callCountSortButton.Name = "callCountSortButton";
            this.callCountSortButton.Size = new System.Drawing.Size(124, 53);
            this.callCountSortButton.TabIndex = 3;
            this.callCountSortButton.Text = "Сортировать по количеству вызовов";
            this.callCountSortButton.UseVisualStyleBackColor = true;
            this.callCountSortButton.Click += new System.EventHandler(this.callCountSortButton_Click);
            // 
            // okrugNameSortButton
            // 
            this.okrugNameSortButton.Location = new System.Drawing.Point(611, 143);
            this.okrugNameSortButton.Name = "okrugNameSortButton";
            this.okrugNameSortButton.Size = new System.Drawing.Size(124, 39);
            this.okrugNameSortButton.TabIndex = 4;
            this.okrugNameSortButton.Text = "Сортировать по названию округа";
            this.okrugNameSortButton.UseVisualStyleBackColor = true;
            this.okrugNameSortButton.Click += new System.EventHandler(this.okrugNameSortButton_Click);
            // 
            // DataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.okrugNameSortButton);
            this.Controls.Add(this.callCountSortButton);
            this.Controls.Add(this.yearSortButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "DataTable";
            this.Size = new System.Drawing.Size(757, 421);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button yearSortButton;
        private System.Windows.Forms.Button callCountSortButton;
        private System.Windows.Forms.Button okrugNameSortButton;
    }
}

namespace Dashboard
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            cbFiliais = new ComboBox();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            dateTimePicker2 = new DateTimePicker();
            button1 = new Button();
            graficoPorFilial = new System.Windows.Forms.DataVisualization.Charting.Chart();
            graficoPorMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            graficoValorPorCanal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            GraficoTopClientes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            GraficoTicketMedio = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)graficoPorFilial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)graficoPorMes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)graficoValorPorCanal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GraficoTopClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GraficoTicketMedio).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(225, 25);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Filial :";
            // 
            // cbFiliais
            // 
            cbFiliais.FormattingEnabled = true;
            cbFiliais.Location = new Point(268, 22);
            cbFiliais.Name = "cbFiliais";
            cbFiliais.Size = new Size(74, 23);
            cbFiliais.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(358, 25);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Periodo :";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(418, 22);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(79, 23);
            dateTimePicker1.TabIndex = 3;
            dateTimePicker1.Value = new DateTime(2023, 3, 10, 20, 18, 46, 701);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(503, 25);
            label3.Name = "label3";
            label3.Size = new Size(13, 15);
            label3.TabIndex = 4;
            label3.Text = "á";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(522, 22);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(79, 23);
            dateTimePicker2.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(625, 22);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // graficoPorFilial
            // 
            chartArea1.Name = "ChartArea1";
            graficoPorFilial.ChartAreas.Add(chartArea1);
            graficoPorFilial.Location = new Point(48, 87);
            graficoPorFilial.Name = "graficoPorFilial";
            graficoPorFilial.Size = new Size(849, 300);
            graficoPorFilial.TabIndex = 7;
            graficoPorFilial.Text = "chart1";
            // 
            // graficoPorMes
            // 
            chartArea2.Name = "ChartArea1";
            graficoPorMes.ChartAreas.Add(chartArea2);
            graficoPorMes.Location = new Point(48, 433);
            graficoPorMes.Name = "graficoPorMes";
            graficoPorMes.Size = new Size(849, 300);
            graficoPorMes.TabIndex = 8;
            graficoPorMes.Text = "chart2";
            // 
            // graficoValorPorCanal
            // 
            chartArea3.Name = "ChartArea1";
            graficoValorPorCanal.ChartAreas.Add(chartArea3);
            graficoValorPorCanal.Location = new Point(48, 783);
            graficoValorPorCanal.Name = "graficoValorPorCanal";
            graficoValorPorCanal.Size = new Size(849, 300);
            graficoValorPorCanal.TabIndex = 9;
            graficoValorPorCanal.Text = "chart3";
            // 
            // GraficoTopClientes
            // 
            chartArea4.Name = "ChartArea1";
            GraficoTopClientes.ChartAreas.Add(chartArea4);
            GraficoTopClientes.Location = new Point(48, 1141);
            GraficoTopClientes.Name = "GraficoTopClientes";
            GraficoTopClientes.Size = new Size(849, 300);
            GraficoTopClientes.TabIndex = 10;
            GraficoTopClientes.Text = "chart4";
            // 
            // GraficoTicketMedio
            // 
            chartArea5.Name = "ChartArea1";
            GraficoTicketMedio.ChartAreas.Add(chartArea5);
            GraficoTicketMedio.Location = new Point(48, 1509);
            GraficoTicketMedio.Name = "GraficoTicketMedio";
            GraficoTicketMedio.Size = new Size(849, 300);
            GraficoTicketMedio.TabIndex = 11;
            GraficoTicketMedio.Text = "chart6";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMargin = new Size(0, 10);
            AutoScrollMinSize = new Size(10, 10);
            ClientSize = new Size(953, 650);
            Controls.Add(GraficoTicketMedio);
            Controls.Add(GraficoTopClientes);
            Controls.Add(graficoValorPorCanal);
            Controls.Add(graficoPorMes);
            Controls.Add(graficoPorFilial);
            Controls.Add(button1);
            Controls.Add(dateTimePicker2);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(cbFiliais);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)graficoPorFilial).EndInit();
            ((System.ComponentModel.ISupportInitialize)graficoPorMes).EndInit();
            ((System.ComponentModel.ISupportInitialize)graficoValorPorCanal).EndInit();
            ((System.ComponentModel.ISupportInitialize)GraficoTopClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)GraficoTicketMedio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbFiliais;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private DateTimePicker dateTimePicker2;
        private Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoPorFilial;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoPorMes;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoValorPorCanal;
        private System.Windows.Forms.DataVisualization.Charting.Chart GraficoTopClientes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart5;
        private System.Windows.Forms.DataVisualization.Charting.Chart GraficoTicketMedio;
    }
}
using OpenTK;

namespace GroundStationAdjusted
{
    public partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title16 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title15 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title14 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title13 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OpenGlControl = new OpenTK.GLControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::GroundStationAdjusted.Properties.Resources.stars_space_darkness_night_black_sky_background_hd_space_1280x720;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.chart4);
            this.panel1.Controls.Add(this.chart3);
            this.panel1.Controls.Add(this.chart2);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.OpenGlControl);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1329, 691);
            this.panel1.TabIndex = 6;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.panel1_PreviewKeyDown);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea16.Area3DStyle.Inclination = 20;
            chartArea16.AxisX.LineColor = System.Drawing.Color.Red;
            chartArea16.AxisX.Title = "Zaman";
            chartArea16.AxisX.TitleFont = new System.Drawing.Font("Calibri Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea16.AxisX.TitleForeColor = System.Drawing.Color.Snow;
            chartArea16.AxisX2.LineColor = System.Drawing.Color.Red;
            chartArea16.AxisX2.TitleForeColor = System.Drawing.Color.Red;
            chartArea16.AxisY.LineColor = System.Drawing.Color.Red;
            chartArea16.AxisY.Title = "Sicaklik";
            chartArea16.AxisY.TitleFont = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea16.AxisY.TitleForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea16.AxisY2.LineColor = System.Drawing.Color.Red;
            chartArea16.AxisY2.TitleForeColor = System.Drawing.Color.Red;
            chartArea16.BackColor = System.Drawing.Color.Transparent;
            chartArea16.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea16);
            this.chart1.Location = new System.Drawing.Point(491, 28);
            this.chart1.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.chart1.Name = "chart1";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series16.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series16.LabelForeColor = System.Drawing.Color.White;
            series16.Name = "Sicaklik";
            this.chart1.Series.Add(series16);
            this.chart1.Size = new System.Drawing.Size(420, 250);
            this.chart1.TabIndex = 22;
            this.chart1.Text = "chart1";
            title16.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title16.ForeColor = System.Drawing.Color.DeepSkyBlue;
            title16.Name = "Sicaklik Grafiği";
            title16.Text = "Sicaklik Grafiği";
            this.chart1.Titles.Add(title16);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::GroundStationAdjusted.Properties.Resources.image;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(297, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 37);
            this.button1.TabIndex = 21;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBox2.Location = new System.Drawing.Point(18, 545);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(344, 134);
            this.richTextBox2.TabIndex = 20;
            this.richTextBox2.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(152, 502);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 33);
            this.label11.TabIndex = 19;
            this.label11.Text = "Not Connected";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(12, 502);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 33);
            this.label3.TabIndex = 17;
            this.label3.Text = "Drum:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::GroundStationAdjusted.Properties.Resources.PngItem_804566;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Cursor = System.Windows.Forms.Cursors.Default;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(297, 451);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 37);
            this.button3.TabIndex = 16;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.MenuText;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200",
            "230400",
            "250000"});
            this.comboBox2.Location = new System.Drawing.Point(158, 451);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 37);
            this.comboBox2.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label10.Location = new System.Drawing.Point(12, 451);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 33);
            this.label10.TabIndex = 14;
            this.label10.Text = "Baud Rate:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::GroundStationAdjusted.Properties.Resources.pngegg;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(297, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 37);
            this.button2.TabIndex = 12;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(158, 397);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 37);
            this.comboBox1.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.AliceBlue;
            this.label9.Location = new System.Drawing.Point(378, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 33);
            this.label9.TabIndex = 10;
            this.label9.Text = "30";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SkyBlue;
            this.label8.Location = new System.Drawing.Point(324, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 33);
            this.label8.TabIndex = 9;
            this.label8.Text = "Roll: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.AliceBlue;
            this.label7.Location = new System.Drawing.Point(236, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 33);
            this.label7.TabIndex = 8;
            this.label7.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SkyBlue;
            this.label6.Location = new System.Drawing.Point(167, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 33);
            this.label6.TabIndex = 7;
            this.label6.Text = "Pitch:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.AliceBlue;
            this.label5.Location = new System.Drawing.Point(89, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 33);
            this.label5.TabIndex = 6;
            this.label5.Text = "30";
            // 
            // OpenGlControl
            // 
            this.OpenGlControl.BackColor = System.Drawing.Color.Transparent;
            this.OpenGlControl.Location = new System.Drawing.Point(11, 11);
            this.OpenGlControl.Margin = new System.Windows.Forms.Padding(2);
            this.OpenGlControl.Name = "OpenGlControl";
            this.OpenGlControl.Size = new System.Drawing.Size(432, 324);
            this.OpenGlControl.TabIndex = 0;
            this.OpenGlControl.TabStop = false;
            this.OpenGlControl.VSync = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(12, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 33);
            this.label4.TabIndex = 5;
            this.label4.Text = "Serial Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(34, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Yaw: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(540, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            this.chart2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart2.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea15.Area3DStyle.Inclination = 20;
            chartArea15.AxisX.LineColor = System.Drawing.Color.Red;
            chartArea15.AxisX.Title = "Zaman";
            chartArea15.AxisX.TitleFont = new System.Drawing.Font("Calibri Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea15.AxisX.TitleForeColor = System.Drawing.Color.Snow;
            chartArea15.AxisX2.LineColor = System.Drawing.Color.Red;
            chartArea15.AxisX2.TitleForeColor = System.Drawing.Color.Red;
            chartArea15.AxisY.LineColor = System.Drawing.Color.Red;
            chartArea15.AxisY.Title = "Hız";
            chartArea15.AxisY.TitleFont = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea15.AxisY.TitleForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea15.AxisY2.LineColor = System.Drawing.Color.Red;
            chartArea15.AxisY2.TitleForeColor = System.Drawing.Color.Red;
            chartArea15.BackColor = System.Drawing.Color.Transparent;
            chartArea15.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea15);
            this.chart2.Location = new System.Drawing.Point(491, 316);
            this.chart2.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.chart2.Name = "chart2";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series15.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series15.LabelForeColor = System.Drawing.Color.White;
            series15.Name = "Sicaklik";
            this.chart2.Series.Add(series15);
            this.chart2.Size = new System.Drawing.Size(420, 250);
            this.chart2.TabIndex = 23;
            this.chart2.Text = "chart2";
            title15.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title15.ForeColor = System.Drawing.Color.DeepSkyBlue;
            title15.Name = "Sicaklik";
            title15.Text = "Hız Grafiği";
            this.chart2.Titles.Add(title15);
            // 
            // chart3
            // 
            this.chart3.BackColor = System.Drawing.Color.Transparent;
            this.chart3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart3.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea14.Area3DStyle.Inclination = 20;
            chartArea14.AxisX.LineColor = System.Drawing.Color.Red;
            chartArea14.AxisX.Title = "Zaman";
            chartArea14.AxisX.TitleFont = new System.Drawing.Font("Calibri Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea14.AxisX.TitleForeColor = System.Drawing.Color.Snow;
            chartArea14.AxisX2.LineColor = System.Drawing.Color.Red;
            chartArea14.AxisX2.TitleForeColor = System.Drawing.Color.Red;
            chartArea14.AxisY.LineColor = System.Drawing.Color.Red;
            chartArea14.AxisY.Title = "İvme";
            chartArea14.AxisY.TitleFont = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea14.AxisY.TitleForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea14.AxisY2.LineColor = System.Drawing.Color.Red;
            chartArea14.AxisY2.TitleForeColor = System.Drawing.Color.Red;
            chartArea14.BackColor = System.Drawing.Color.Transparent;
            chartArea14.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea14);
            this.chart3.Location = new System.Drawing.Point(944, 316);
            this.chart3.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.chart3.Name = "chart3";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series14.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series14.LabelForeColor = System.Drawing.Color.White;
            series14.Name = "Sicaklik";
            this.chart3.Series.Add(series14);
            this.chart3.Size = new System.Drawing.Size(420, 250);
            this.chart3.TabIndex = 24;
            this.chart3.Text = "chart3";
            title14.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title14.ForeColor = System.Drawing.Color.DeepSkyBlue;
            title14.Name = "Sicaklik";
            title14.Text = "İvme Grafiği";
            this.chart3.Titles.Add(title14);
            // 
            // chart4
            // 
            this.chart4.BackColor = System.Drawing.Color.Transparent;
            this.chart4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart4.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea13.Area3DStyle.Inclination = 20;
            chartArea13.AxisX.LineColor = System.Drawing.Color.Red;
            chartArea13.AxisX.Title = "Zaman";
            chartArea13.AxisX.TitleFont = new System.Drawing.Font("Calibri Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea13.AxisX.TitleForeColor = System.Drawing.Color.Snow;
            chartArea13.AxisX2.LineColor = System.Drawing.Color.Red;
            chartArea13.AxisX2.TitleForeColor = System.Drawing.Color.Red;
            chartArea13.AxisY.LineColor = System.Drawing.Color.Red;
            chartArea13.AxisY.Title = "Konum";
            chartArea13.AxisY.TitleFont = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea13.AxisY.TitleForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea13.AxisY2.LineColor = System.Drawing.Color.Red;
            chartArea13.AxisY2.TitleForeColor = System.Drawing.Color.Red;
            chartArea13.BackColor = System.Drawing.Color.Transparent;
            chartArea13.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea13);
            this.chart4.Location = new System.Drawing.Point(937, 28);
            this.chart4.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.chart4.Name = "chart4";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series13.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series13.LabelForeColor = System.Drawing.Color.White;
            series13.Name = "Sicaklik";
            this.chart4.Series.Add(series13);
            this.chart4.Size = new System.Drawing.Size(420, 250);
            this.chart4.TabIndex = 25;
            this.chart4.Text = "chart4";
            title13.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title13.ForeColor = System.Drawing.Color.DeepSkyBlue;
            title13.Name = "Sicaklik";
            title13.Text = "Konum Grafiği";
            this.chart4.Titles.Add(title13);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(428, 591);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(222, 53);
            this.button4.TabIndex = 26;
            this.button4.Text = "Eve Dön";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(656, 591);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(222, 53);
            this.button5.TabIndex = 27;
            this.button5.Text = "Görüntü Al";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(884, 591);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(222, 53);
            this.button6.TabIndex = 28;
            this.button6.Text = "Hızlan";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1329, 691);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public OpenTK.GLControl OpenGlControl;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label label3;
        public System.IO.Ports.SerialPort serialPort1;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.RichTextBox richTextBox2;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
    }
}


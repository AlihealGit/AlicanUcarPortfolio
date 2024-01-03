using Assimp.Configs;
using Assimp;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;
using CsvHelper;
using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.IO.Ports;
using System.Globalization;
using System.Linq;

namespace GroundStationAdjusted
{
    public partial class Form1 : Form
    {
        int minchart = 0, maxchart = 20, chartdeno = 1;
        double preTime = 0;
        int counter = 1;
        float[] packet = new float[14];
        public AccurateTimer TimerSerialData;
        ReadSerialPort SerialPortReader;
        float[] paket;
        Viewer3D Viewer;
        bool fullscreenchecker;
        public int RotationType;
        int lastmax1 = 0 ;
        int lastmax2 = 0;
        int lastmax3 = 0;
        int lastmax4 = 0;
        int lastmin1 = 0 ;
        int lastmin2 = 0 ;
        int lastmin3 = 0 ;
        int lastmin4 = 0 ;
        float sum1 = 0;
        float sum2 = 0;
        float sum3 = 0;
        float sum4 = 0;
        float[] lastten1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] lastten2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] lastten3 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] lastten4 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Viewer = new Viewer3D(OpenGlControl, paket, "roketreduced.obj", 1);
            this.OpenGlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.Viewer.MyPaint);
            this.OpenGlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Viewer.MyKeyDown);
            this.OpenGlControl.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Viewer.MyPreviewKwyDown);
            this.chart1.ChartAreas[0].AxisX.LineColor = System.Drawing.Color.Red;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Red;
            this.chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.FloralWhite;

            this.chart1.ChartAreas[0].AxisY.LineColor = System.Drawing.Color.Red;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Red;
            this.chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = System.Drawing.Color.FloralWhite;

            this.chart2.ChartAreas[0].AxisX.LineColor = System.Drawing.Color.Red;
            this.chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Red;
            this.chart2.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.FloralWhite;

            this.chart2.ChartAreas[0].AxisY.LineColor = System.Drawing.Color.Red;
            this.chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Red;
            this.chart2.ChartAreas[0].AxisY.LabelStyle.ForeColor = System.Drawing.Color.FloralWhite;

            this.chart3.ChartAreas[0].AxisX.LineColor = System.Drawing.Color.Red;
            this.chart3.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Red;
            this.chart3.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.FloralWhite;

            this.chart3.ChartAreas[0].AxisY.LineColor = System.Drawing.Color.Red;
            this.chart3.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Red;
            this.chart3.ChartAreas[0].AxisY.LabelStyle.ForeColor = System.Drawing.Color.FloralWhite;

            this.chart4.ChartAreas[0].AxisX.LineColor = System.Drawing.Color.Red;
            this.chart4.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Red;
            this.chart4.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.FloralWhite;

            this.chart4.ChartAreas[0].AxisY.LineColor = System.Drawing.Color.Red;
            this.chart4.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Red;
            this.chart4.ChartAreas[0].AxisY.LabelStyle.ForeColor = System.Drawing.Color.FloralWhite;

            comboBox1.Items.Clear();
            string[] portlar = SerialPort.GetPortNames();
            foreach (string portAdi in portlar)
            {
                comboBox1.Items.Add(portAdi);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!button3.Enabled)
                TimerSerialData.Stop();
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = panel1;
        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((e.KeyCode == Keys.F11) && !fullscreenchecker)
            {
                fullscreenchecker = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else if (e.KeyCode == Keys.F11)
            {
                fullscreenchecker = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                serialPort1.PortName = comboBox1.Text;
                if (!serialPort1.IsOpen)
                {
                    int delay = 1000;
                    TimerSerialData = new AccurateTimer(this, new Action(TimerTick), delay);
                    serialPort1.Open();
                    serialPort1.RtsEnable = true;
                    serialPort1.DtrEnable = true;
                    //MessageBox.Show("BAĞLANTI KURULDU");
                    SerialPortReader = new ReadSerialPort(this, Viewer, serialPort1);
                    button3.Enabled = false;
                    label11.Text = "Connected";
                    label11.ForeColor = System.Drawing.Color.Green;
                    button1.Visible = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("BAĞLANTI KURULAMADI");
                button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] portlar = SerialPort.GetPortNames();
            foreach (string portAdi in portlar)
            {
                comboBox1.Items.Add(portAdi);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            using (var writer = new StreamWriter("output.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(SerialPortReader.telemetriVerileri);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] veri = { 2, 253 };
            SerialPortReader.Writer(veri);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] veri = { 1, 254 };
            SerialPortReader.Writer(veri);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
                byte[] veri = { 3, 252 };
                SerialPortReader.Writer(veri);
            
        }

        private void TimerTick()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    packet = SerialPortReader.serialoku();
                    Viewer.getSerialData(packet, serialPort1.IsOpen);
                    chartdata();
                    OpenGlControl.Refresh();
                    serialPort1.DiscardInBuffer();

                }
                else
                {
                    SerialPortReader.serialportclosed();
                }

            }
            catch
            {

            }
        }

        private float[] shiftarray(float newdata, float[] oldarray) 
        {
            float[] arr = new float[10];
            for (int y = 0; y <= 9; y++)
            {
                if ((y+1)<9)
                    arr[y] = oldarray[y+1];
                else
                    arr[9] = newdata;
            }
            return arr;
        }
        private void chartdata()
        {
            chart1.ChartAreas[0].AxisX.Minimum = minchart;
            chart1.ChartAreas[0].AxisX.Maximum = maxchart;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 40;

            chart2.ChartAreas[0].AxisX.Minimum = minchart;
            chart2.ChartAreas[0].AxisX.Maximum = maxchart;
            chart2.ChartAreas[0].AxisY.Minimum = -20;
            chart2.ChartAreas[0].AxisY.Maximum = +20;

            chart3.ChartAreas[0].AxisX.Minimum = minchart;
            chart3.ChartAreas[0].AxisX.Maximum = maxchart;
            chart3.ChartAreas[0].AxisY.Minimum = -10;
            chart3.ChartAreas[0].AxisY.Maximum = +10;

            chart4.ChartAreas[0].AxisX.Minimum = minchart;
            chart4.ChartAreas[0].AxisX.Maximum = maxchart;
            chart4.ChartAreas[0].AxisY.Minimum = -50;
            chart4.ChartAreas[0].AxisY.Maximum = 100;


            if (chartdeno < 20)
                chart1.ChartAreas[0].AxisX.ScaleView.Zoom(1, 40);
            else
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Zoom(minchart, maxchart);
                maxchart++;
                minchart++;
            }

            if (chartdeno < 20)
                chart2.ChartAreas[0].AxisX.ScaleView.Zoom(1, 40);
            else
            {
                chart2.ChartAreas[0].AxisX.ScaleView.Zoom(minchart, maxchart);
                maxchart++;
                minchart++;
            }

            if (chartdeno < 20)
                chart3.ChartAreas[0].AxisX.ScaleView.Zoom(1, 40);
            else
            {
                chart3.ChartAreas[0].AxisX.ScaleView.Zoom(minchart, maxchart);
                maxchart++;
                minchart++;
            }

            if (chartdeno < 20)
                chart4.ChartAreas[0].AxisX.ScaleView.Zoom(1, 40);
            else
            {
                chart4.ChartAreas[0].AxisX.ScaleView.Zoom(minchart, maxchart);
                maxchart++;
                minchart++;
            }


            if  (packet != null)
            {
                this.chart1.Series["Sicaklik"].Points.AddXY(counter++, packet[13]);
                this.chart4.Series["Sicaklik"].Points.AddXY(counter++, packet[8]);
                this.chart2.Series["Sicaklik"].Points.AddXY(counter++, packet[3]);
                this.chart3.Series["Sicaklik"].Points.AddXY(counter++, packet[4]);
            }
                
        }

    }
}

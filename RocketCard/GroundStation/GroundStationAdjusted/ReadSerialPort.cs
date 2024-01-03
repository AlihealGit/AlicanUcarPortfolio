using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace GroundStationAdjusted
{
    
    internal class ReadSerialPort
    {
        private SerialPort serialPort1;
        private Viewer3D Viewer;
        Form1 F;
        public List<telemetri> telemetriVerileri = new List<telemetri>();
        int waiter = 0;
        public ReadSerialPort(Form1 Ftemp, Viewer3D tempviewer, SerialPort serialporttemp) 
        {
            serialPort1 = serialporttemp;
            Viewer = tempviewer;
            F = Ftemp;
        }

        public float[] serialoku()
        {
          
            if (serialPort1.IsOpen && waiter>2)
            {
                byte[] fileBytes = new byte[52];
                serialPort1.Read(fileBytes, 0, 52);
                uint takım_no = BitConverter.ToUInt16(fileBytes, 0);
                uint paket_no = BitConverter.ToUInt16(fileBytes, 2);
                int zaman = BitConverter.ToInt32(fileBytes, 4);
                float yatay_hız = BitConverter.ToSingle(fileBytes, 8);
                float yatay_ivme = BitConverter.ToSingle(fileBytes, 12);
                float gps_enlem = BitConverter.ToSingle(fileBytes, 16);
                float gps_boylam = BitConverter.ToSingle(fileBytes, 20);
                int gps_yükseklik = BitConverter.ToInt32(fileBytes, 24);
                float yer_degistirme = BitConverter.ToSingle(fileBytes, 28);
                float pitch = BitConverter.ToSingle(fileBytes, 32);
                float roll = BitConverter.ToSingle(fileBytes, 36);
                float yaw = BitConverter.ToSingle(fileBytes, 40);
                float pil = BitConverter.ToSingle(fileBytes, 44);
                float sicaklik = BitConverter.ToSingle(fileBytes, 48);

                System.DateTime dat_Time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                dat_Time = dat_Time.AddSeconds(zaman);
                string tarih = dat_Time.ToShortDateString() + " " + dat_Time.ToShortTimeString();

                    float yıl = dat_Time.Year;
                    float ay = dat_Time.Month;
                    float gün = dat_Time.Day;
                    float saat = dat_Time.Hour;
                    float dakika = dat_Time.Minute;
                    float saniye = dat_Time.Second;

                //Viewer.getSerialData(paket, serialPort1.IsOpen);

                string temp = "Takım No: " + takım_no + "Paket No: " + paket_no + "Tarih: " + tarih
                    + "Yatay Hız: " + yatay_hız + "Yatay İvme: " + yatay_ivme + "GPS Enlem: " + gps_enlem +
                    "GPS Boylam" + gps_boylam + "GPS Yükseklik" + gps_yükseklik + "Yer Değiştirme: " + yer_degistirme +
                    " Pitch: " + pitch + " Roll: " + roll + "Yaw: " + yaw + "Pil: " + pil + "Sıcaklık: " + sicaklik +  System.Environment.NewLine;
                F.richTextBox2.AppendText(temp);
                serialPort1.DiscardInBuffer();

                float[] sonuc = new float[14];

                sonuc[0] = takım_no;
                sonuc[1] = paket_no;
                sonuc[2] = zaman;
                sonuc[3] = yatay_hız;
                sonuc[4] = yatay_ivme;
                sonuc[5] = gps_enlem;
                sonuc[6] = gps_boylam;
                sonuc[7] = gps_yükseklik;
                sonuc[8] = yer_degistirme;
                sonuc[9] = pitch;
                sonuc[10] = roll;
                sonuc[11] = yaw;
                sonuc[12] = pil;
                sonuc[13] = sicaklik;

                telemetriVerileri.Add(new telemetri(sonuc[0], sonuc[1], yıl, ay, gün, saat, dakika, saniye,
                    sonuc[3], sonuc[4], sonuc[5], sonuc[6], sonuc[7], sonuc[8], sonuc[9], sonuc[10],
                    sonuc[11], sonuc[12], sonuc[13], 1.0f));
                return sonuc;
            }
            else
            {
                waiter++;
                return null;
            }
                
        }
        public void serialportclosed()
        {
       
            F.label11.Text = "Not Connected";
            F.label11.ForeColor = System.Drawing.Color.Red;
            F.button3.Enabled = true;
            F.label5.Text = "0";
            F.label7.Text = "0";
            F.label9.Text = "0";
            F.button1.Visible = false;
            F.OpenGlControl.Refresh();
            F.TimerSerialData.Stop();
        }

        public void Writer(byte[] veri)
        {
            serialPort1.Write(veri, 0, 2);
        }


    }
}

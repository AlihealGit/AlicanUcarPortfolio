using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStationAdjusted
{
    internal class telemetri
    {
        public float Takim_No { get; set; }
        public float Paket_No { get; set; }
        public float Yil { get; set; }
        public float Ay { get; set; }
        public float Gun { get; set; }
        public float Saat { get; set; }
        public float Dakika { get; set; }
        public float Saniye { get; set; }
        public float Yatay_Hiz { get; set; }
        public float Yatay_Ivme { get; set; }

        public float GPS_Enlem { get; set; }

        public float GPS_Boylam { get; set; }

        public float GPS_Yukseklik { get; set; }
        public float Yer_Degistirme { get; set; }
        public float Pitch { get; set; }
        public float Roll { get; set; }
        public float Yaw { get; set; }
        public float Pil { get; set; }

        public float Sicaklik { get; set; }
        public float Paket_Dogrulugu { get; set; }

        public telemetri(float takim, float paket, float yıl, float ay, float gün, float saat, float dakika, float saniye
            , float yatayhız, float yatayivme, float enlem, float boylam, float yükseklik, float yerdegistirme,
            float pitch, float roll, float yaw, float pil, float sicaklik,  float paketdog)
        {
            this.Takim_No = takim;
            this.Paket_No= paket;
            this.Yil = yıl;
            this.Ay = ay;
            this.Gun = gün;
            this.Saat = saat;
            this.Dakika = dakika;
            this.Saniye = saniye;
            this.Yatay_Hiz = yatayhız;
            this.Yatay_Ivme = yatayivme;
            this.GPS_Enlem = enlem;
            this.GPS_Boylam = boylam;
            this.GPS_Yukseklik = yükseklik;
            this.Yer_Degistirme = yerdegistirme;
            this.Pitch = pitch;
            this.Roll = roll;
            this.Yaw = yaw;
            this.Pil = pil;
            this.Sicaklik = sicaklik;
            this.Paket_Dogrulugu = paketdog;
        }

        public telemetri(float v1, float v2, float v3, float v4, float v5, float v6, float v7, float v8, float v9, float v10, float v11, float v12, float v13, float v14, float v15)
        {
        }
    }
}

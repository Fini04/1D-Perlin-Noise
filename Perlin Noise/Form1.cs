using System;
using System.Drawing;
using System.Windows.Forms;

namespace Perlin_Noise
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        float[] layer1 = new float[300 + 1];
        float[] layer2 = new float[300 + 1];
        float[] layer3 = new float[300 + 1];
        float[] layerNoise = new float[300 + 1];
        public Form1()
        {
            InitializeComponent();

            Layer(20, layer1, -50, 50, "Layer 1");
            Layer(10, layer2, -25, 25, "Layer 2");
            Layer(5, layer3, -12, 12, "Layer 3");

            for (int i = 0; i < layerNoise.Length; i++)
            {
                layerNoise[i] = (layer1[i] + layer2[i] + layer3[i]) / 3;
            }

        }

        public void Layer(int abstand_in_px, float[] arrayName, int min, int max, string displayName)
        {
            for (int i = 0; i < arrayName.Length; i += abstand_in_px)
            {
                arrayName[i] = rand.Next(min, max + 1);
                WriteLog($"{displayName}: x {i} || y " + arrayName[i]);
            }

            int x = 1;
            int x0 = 0;
            int x1 = abstand_in_px;
            for (int k = 0; k < arrayName.Length / abstand_in_px; k++)
            {
                for (int i = 1; i <= abstand_in_px; i++)
                {
                    arrayName[x] = arrayName[x0] + ((arrayName[x1] - arrayName[x0]) / (x1 - x0)) * (x - x0);
                    x++;
                }
                x0 += abstand_in_px;
                x1 += abstand_in_px;
            }
        }

        public void WriteLog(string logText)
        {
            txtLog.Text = txtLog.Text + $"\r\n {logText}";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        int yMid = 50;
        static int zoomScale = 3;
        Pen normalPen = new Pen(Color.White);
        Pen markerPen1 = new Pen(Color.Red);
        Pen markerPen2 = new Pen(Color.Cyan);
        Pen markerPen3 = new Pen(Color.Yellow);
        Pen markerPenFinal = new Pen(Color.YellowGreen, 3);

        Pen waterPen = new Pen(Color.CornflowerBlue, zoomScale);
        Pen dirtPen = new Pen(Color.FromArgb(150, 75, 0) , zoomScale);
        Pen sandPen = new Pen(Color.BurlyWood, zoomScale);
        Pen grassPen = new Pen(Color.YellowGreen, zoomScale);
        private void pnAnzeige_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            e.Graphics.DrawLine(normalPen, 0, yMid, pnAnzeige.Width, yMid);

            DrawCurve(layer1, 3, markerPen1, e);
            DrawCurve(layer2, 3, markerPen2, e);
            DrawCurve(layer3, 3, markerPen3, e);
            DrawCurve(layerNoise, 3, markerPenFinal, e);
        }

        public void DrawCurve(float[] arrayName, float scale, Pen pen, PaintEventArgs e)
        {
            int x = 0;
            for (float i = 1; i < arrayName.Length * scale - scale; i += scale)
            {
                e.Graphics.DrawLine(pen, i, yMid + arrayName[x], i + scale, yMid + arrayName[x + 1]);
                x++;
            }
        }

        public void DrawEdgeLine(Pen pen, string position, PaintEventArgs e)
        {
            int x = 0;
            for (int i = 0; i < layerNoise.Length * zoomScale - zoomScale; i += zoomScale)
            {
                if (layerNoise[x] + yMid >= yMid && position=="down")
                {
                    e.Graphics.DrawLine(pen, i, yMid + layerNoise[x], i + 3, yMid + layerNoise[x + 1]);
                }
                if (layerNoise[x] + yMid <= yMid && position == "top")
                {
                    e.Graphics.DrawLine(pen, i, yMid + layerNoise[x], i + 3, yMid + layerNoise[x + 1]);
                }
                x++;
            }
        }

        private void pnAnzeigeTerrain_Paint(object sender, PaintEventArgs e)
        {
            int x = 0;
            for (int i = 0; i < layerNoise.Length * 3 - 3; i += 3)
            {
                if (layerNoise[x] + yMid >= yMid)
                {
                    e.Graphics.DrawLine(waterPen, i, yMid, i, yMid + layerNoise[x]);
                }
                if (layerNoise[x] + yMid <= yMid)
                {
                }
                e.Graphics.DrawLine(dirtPen, i, yMid + layerNoise[x], i, 100);
                x++;
            }

            DrawEdgeLine(sandPen, "down", e);
            DrawEdgeLine(grassPen, "top", e);

            //e.Graphics.DrawLine(normalPen, 0, yMid, pnAnzeige.Width, yMid);

            //DrawCurve(layerNoise, 3, markerPenFinal, e);
        }

        private void btnArray_Click(object sender, EventArgs e)
        {
            WriteLog("\r\n Layer1:");
            for (int i = 0; i < layer1.Length; i++)
            {
                WriteLog($"Layer 1: x {i} || y {layer1[i]}");
            }
        }

    }
}

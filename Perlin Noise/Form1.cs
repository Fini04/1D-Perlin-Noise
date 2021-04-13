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

            for (int i = 0; i < layer1.Length; i += 20)
            {
                layer1[i] = rand.Next(-50, 50 + 1);
                WriteLog($"Layer 1: x {i} || y " + layer1[i]);
            }

            for (int i = 0; i < layer2.Length; i += 10)
            {
                layer2[i] = rand.Next(-25, 25 + 1);
                WriteLog($"Layer 2: x {i} || y " + layer2[i]);
            }

            for (int i = 0; i < layer3.Length; i += 5)
            {
                layer3[i] = rand.Next(-12, 12 + 1);
                WriteLog($"Layer 3: x {i} || y " + layer3[i]);
            }

            Layer(20, layer1);
            Layer(10, layer2);
            Layer(5, layer3);

            for (int i = 0; i < layerNoise.Length; i++)
            {
                layerNoise[i] = (layer1[i] + layer2[i] + layer3[i]) / 3;
            }

        }

        public void Layer(int abstand_in_px, float[] arrayName)
        {
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
        Pen normalPen = new Pen(Color.White);
        Pen markerPen1 = new Pen(Color.Red);
        Pen markerPen2 = new Pen(Color.Cyan);
        Pen markerPen3 = new Pen(Color.Yellow);
        Pen markerPenFinal = new Pen(Color.YellowGreen, 3);
        private void pnAnzeige_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            e.Graphics.DrawLine(normalPen, 0, yMid, pnAnzeige.Width, yMid);

            int x = 0;
            for (int i = 1; i < layer1.Length * 3 - 3; i += 3)
            {
                e.Graphics.DrawLine(markerPen1, i, yMid + layer1[x], i + 3, yMid + layer1[x + 1]);
                x++;
            }

            x = 0;
            for (int i = 1; i < layer2.Length * 3 - 3; i += 3)
            {
                e.Graphics.DrawLine(markerPen2, i, yMid + layer2[x], i + 3, yMid + layer2[x + 1]);
                x++;
            }

            x = 0;
            for (int i = 1; i < layer3.Length * 3 - 3; i += 3)
            {
                e.Graphics.DrawLine(markerPen3, i, yMid + layer3[x], i + 3, yMid + layer3[x + 1]);
                x++;
            }

            x = 0;
            for (int i = 1; i < layerNoise.Length * 3 - 3; i += 3)
            {
                e.Graphics.DrawLine(markerPenFinal, i, yMid + layerNoise[x], i + 3, yMid + layerNoise[x + 1]);
                x++;
            }
        }

        private void pnAnzeigeTerrain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(normalPen, 0, yMid, pnAnzeige.Width, yMid);

            int x = 0;
            for (int i = 1; i < layerNoise.Length * 3 - 3; i += 3)
            {
                e.Graphics.DrawLine(markerPenFinal, i, yMid + layerNoise[x], i + 3, yMid + layerNoise[x + 1]);
                x++;
            }
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

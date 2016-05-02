using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using ZedGraph;
using ZedGraph.Web;

namespace GraphGui
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private List<GlobalHotkey> hotKeyList;

        private int graphIndex = 0;
        private int adsrIndex = 3;
        private int octaveIndex = 4;
        private int max = 5;
        private int min = 1;
        private int maxOctave = 7;
        private int durationVal = 2;

        private IntPtr h;

        private List<double> attackPercent;
        private List<double> decayPercent;
        private List<double> sustainPercent;
        private List<double> releasePercent;

        private string lastNoteStr = "";

        public Form1()
        {
            InitializeComponent();
            hotKeyList = new List<GlobalHotkey>();
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.T, this)); //Forward
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.G, this)); //Backward
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.Z, this)); //C Note
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.X, this)); //D Note
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.C, this)); //E Note
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.V, this)); //F Note
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.B, this)); //G Note
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.N, this)); //A Note
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.M, this)); //B Note
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.R, this)); //adsr Raise
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.F, this)); //adsr Lower
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.O, this)); //octave Raise
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.L, this)); //octave Lower
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.E, this)); //duration Raise
            hotKeyList.Add(new GlobalHotkey(Constants.NOMOD, Keys.D, this)); //duration Lower

            attackPercent = new List<double>();
            attackPercent.Add(.7);
            attackPercent.Add(.05);
            attackPercent.Add(.25);
            attackPercent.Add(.05);
            attackPercent.Add(.1);

            decayPercent = new List<double>();
            decayPercent.Add(.1);
            decayPercent.Add(.05);
            decayPercent.Add(.25);
            decayPercent.Add(.05);
            decayPercent.Add(.1);

            sustainPercent = new List<double>();
            sustainPercent.Add(.1);
            sustainPercent.Add(.8);
            sustainPercent.Add(.25);
            sustainPercent.Add(.05);
            sustainPercent.Add(.3);

            releasePercent = new List<double>();
            releasePercent.Add(.1);
            releasePercent.Add(.1);
            releasePercent.Add(.25);
            releasePercent.Add(.05);
            releasePercent.Add(.1);

            graph.IsEnableWheelZoom = false;
            adsrGraph.IsEnableWheelZoom = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < hotKeyList.Count; i++)
            {
                if (!hotKeyList[i].Register())
                {
                    MessageBox.Show("Keys did not register properly!");
                }
            }

            // Setup the graph
            updateGraph();
            updatePanel();
            updateAdsr(adsrGraph);
            // Size the control to fill the form with a margin
            SetSize();
               
        }

        // Build the Chart
        private void CreateSinWave(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;
            myPane.Fill = new Fill(Color.DarkGray);
            myPane.Chart.Fill = new Fill(Color.DarkGray);



            // Set the Titles
            myPane.Title.Text = "Sine Wave";
            myPane.XAxis.Title.Text = "Radians";
            myPane.YAxis.Title.Text = "Amplitude";

            // Make up some data arrays based on the Sine function
            int numTerms = 100;
            double x = 0.0;
            double y;
            double maxX = 4 * Math.PI;
            double increment = maxX / (double)numTerms;

            myPane.XAxis.Scale.Max = maxX;

            PointPairList list = new PointPairList();
            for (int i = 0; i < numTerms; i++)
            {
                y = Math.Sin(x);
                list.Add(x, y);
                x += increment;
            }

            LineItem myCurve = myPane.AddCurve("Sine Wave",
                  list, Color.Green, SymbolType.None);

            myCurve.Line.Width = 4.0F;

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
        }

        // Build the Chart
        private void CreateSquareWave(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;
            myPane.Fill = new Fill(Color.DarkGray);
            myPane.Chart.Fill = new Fill(Color.DarkGray);



            // Set the Titles
            myPane.Title.Text = "Square Wave";
            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = "Amplitude";

            // Make up some data arrays based on the Sine function
            int numTerms = 100;
            double x = 0.0;
            double y;
            double maxX = 4;
            double increment = maxX / (double)numTerms;
            PointPairList list = new PointPairList();

            myPane.XAxis.Scale.Max = maxX;

            for (int i = 0; i < numTerms; i++)
            {
                if (x < 1 || (x > 2) && (x < 3))
                {
                    y = 1;
                }
                else
                {
                    y = -1;
                }
                list.Add(x, y);
                x += increment;
            }

            LineItem myCurve = myPane.AddCurve("Square Wave",
                  list, Color.Blue, SymbolType.None);

            myCurve.Line.Width = 4.0F;

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
        }

        // Build the Chart
        private void CreateSawtoothWave(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;
            myPane.Fill = new Fill(Color.DarkGray);
            myPane.Chart.Fill = new Fill(Color.DarkGray);



            // Set the Titles
            myPane.Title.Text = "Sawtooth Wave";
            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = "Amplitude";

            // Make up some data arrays based on the Sine function
            int numTerms = 100;
            double x = 0.0;
            double y;
            double maxX = 4;
            double increment = maxX / (double)numTerms;
            PointPairList list = new PointPairList();

            myPane.XAxis.Scale.Max = maxX;

            for (int i = 0; i < numTerms; i++)
            {
                if (x < 1)
                {
                    y = x;
                }
                else if (x >= 1 && x < 3)
                {
                    y = x - 2;
                }
                else
                {
                    y = x - 4;
                }
                list.Add(x, y);
                x += increment;
            }

            LineItem myCurve = myPane.AddCurve("Sawtooth Wave",
                  list, Color.Red, SymbolType.None);

            myCurve.Line.Width = 4.0F;

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
        }

        // Build the Chart
        private void updateAdsr(ZedGraphControl zgc)
        {
            zgc.GraphPane.CurveList.Clear();
            zgc.AxisChange();
            zgc.Invalidate();

            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;
            myPane.Fill = new Fill(Color.DarkGray);
            myPane.Chart.Fill = new Fill(Color.DarkGray);



            // Set the Titles
            myPane.Title.Text = "ADSR Envelope";
            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = "Amplitude";

            // Make up some data arrays based on the Sine function
            double x = 0.0;
            double y = 0.0;
            double maxX = 4;
            PointPairList listA = new PointPairList();
            PointPairList listD = new PointPairList();
            PointPairList listS = new PointPairList();
            PointPairList listR = new PointPairList();

            myPane.XAxis.Scale.Max = maxX;

            listA.Add(x,y);
            
            x += attackPercent[adsrIndex-1] * maxX;
            y = 1;
            listA.Add(x,y);
            listD.Add(x, y);
            x += decayPercent[adsrIndex-1] * maxX;
            y = .6;
            listD.Add(x, y);
            listS.Add(x, y);

            x += sustainPercent[adsrIndex-1] * maxX;
            listS.Add(x, y);
            listR.Add(x, y);

            x += releasePercent[adsrIndex-1] * maxX;
            y = 0;
            listR.Add(x, y);

            LineItem myCurveA = myPane.AddCurve("Attack",
                  listA, Color.Red, SymbolType.None);
            LineItem myCurveD = myPane.AddCurve("Decay",
                  listD, Color.Blue, SymbolType.None);
            LineItem myCurveS = myPane.AddCurve("Sustain",
                  listS, Color.Green, SymbolType.None);
            LineItem myCurveR = myPane.AddCurve("Release",
                  listR, Color.Black, SymbolType.None);

            myCurveA.Line.Width = 3.0F;
            myCurveD.Line.Width = 3.0F;
            myCurveS.Line.Width = 3.0F;
            myCurveR.Line.Width = 3.0F;
            
            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
        }

        private Keys GetKey(IntPtr LParam)
        {
            return (Keys)((LParam.ToInt32()) >> 16);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                switch (GetKey(m.LParam))
                {
                    case Keys.T:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("T");
                        if (graphIndex < 2)
                        {
                            graphIndex += 1;
                        }
                        else
                        {
                            graphIndex = 0;
                        }
                        break;

                    case Keys.G:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("G");
                        if (graphIndex > 0)
                        {
                            graphIndex -= 1;
                        }
                        else
                        {
                            graphIndex = 2;
                        }
                        break;

                    case Keys.Z:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("Z");
                        lastNoteStr = "C";
                        break;

                    case Keys.X:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("X");
                        lastNoteStr = "D";
                        break;

                    case Keys.C:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("C");
                        lastNoteStr = "E";
                        break;

                    case Keys.V:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("V");
                        lastNoteStr = "F";
                        break;

                    case Keys.B:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("B");
                        lastNoteStr = "G";
                        break;

                    case Keys.N:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("N");
                        lastNoteStr = "A";
                        break;

                    case Keys.M:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("M");
                        lastNoteStr = "B";
                        break;
                        

                    case Keys.R:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("R");
                        if (adsrIndex < max)
                        {
                            adsrIndex += 1;
                        }
                        else
                        {
                            adsrIndex = max;
                        }
                        break;

                    case Keys.F:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("F");
                        if (adsrIndex > min)
                        {
                            adsrIndex -= 1;
                        }
                        else
                        {
                            adsrIndex = min;
                        }
                        break;

                    case Keys.O:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("O");
                        if(octaveIndex < maxOctave)
                        {
                            octaveIndex += 1;
                        }
                        else
                        {
                            octaveIndex = maxOctave;
                        }
                        break;

                    case Keys.L:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("L");
                        if (octaveIndex > min)
                        {
                            octaveIndex -= 1;
                        }
                        else
                        {
                            octaveIndex = min;
                        }
                        break;

                    case Keys.E:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("E");
                        durationVal += 1;
                        break;

                    case Keys.D:
                        SetForegroundWindow(h);
                        SendKeys.SendWait("D");
                        if (durationVal > min)
                        {
                            durationVal -= 1;
                        }
                        else
                        {
                            durationVal = min;
                        }
                        break;

                    default:
                        break;
                }
                updateGraph();
                updateAdsr(adsrGraph);
                updatePanel();
            }
            base.WndProc(ref m);
        }

        private void updatePanel()
        {
            lastNotelbl.Text = "Last Note: " + lastNoteStr;
            adsrlbl.Text = "ADSR Setting: " + adsrIndex.ToString();
            octavelbl.Text = "Octave: " + octaveIndex.ToString();
            durationlbl.Text = "Duration: " + durationVal.ToString();
        }

        private void updateGraph()
        {
            graph.GraphPane.CurveList.Clear();
            graph.AxisChange();
            graph.Invalidate();
            if (graphIndex == 0)
            {
                CreateSinWave(graph);
            }
            else if (graphIndex == 1)
            {
                CreateSquareWave(graph);
            }
            else if (graphIndex == 2)
            {
                CreateSawtoothWave(graph);
            }
            else
            {
                CreateSinWave(graph);
                graphIndex = 0;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < hotKeyList.Count; i++)
            {
                if (!hotKeyList[i].Unregiser())
                {
                    MessageBox.Show("Keys failed to unregister!");
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        // SetSize() is separate from Resize() so we can 
        // call it independently from the Form1_Load() method
        // This leaves a 10 px margin around the outside of the control
        // Customize this to fit your needs
        private void SetSize()
        {
            graph.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            graph.Size = new Size(ClientRectangle.Width/2 - 20, ClientRectangle.Height - (labelPanel.Height + 30));
            adsrGraph.Location = new Point(ClientRectangle.Width / 2 + 10, 10);
            adsrGraph.Size = new Size(ClientRectangle.Width / 2 - 20, ClientRectangle.Height - (labelPanel.Height + 30));
            labelPanel.Location = new Point(ClientRectangle.Width / 2 - labelPanel.Width / 2, ClientRectangle.Height - (labelPanel.Height + 10));
            connect.Location = new Point(labelPanel.Location.X + labelPanel.Width + 20, labelPanel.Location.Y + labelPanel.Height / 2 - connect.Height / 2 - 20);
            button1.Location = new Point(labelPanel.Location.X + labelPanel.Width + 20, labelPanel.Location.Y + labelPanel.Height / 2 - connect.Height / 2 + 20);
        }

        private void connect_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                Process p = Process.Start(file);
                if (p != null)
                {
                    p.WaitForInputIdle();
                    h = p.MainWindowHandle;
                    connect.Enabled = false;
                    connect.BackColor = Color.DarkGreen;
                }
                else
                {
                    MessageBox.Show("failed to open process");
                    connect.BackColor = Color.DarkRed;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                Process p = Process.Start(file);
                if (p != null)
                {
                    p.WaitForInputIdle();
                    button1.Enabled = false;
                    button1.BackColor = Color.DarkGreen;
                }
                else
                {
                    MessageBox.Show("failed to open process");
                    button1.BackColor = Color.DarkRed;
                }
            }
        }
    } 
}

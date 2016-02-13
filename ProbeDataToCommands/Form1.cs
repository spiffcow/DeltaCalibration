using ProbeDataToCommands.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbeDataToCommands
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtArmLengthInput.Text = (string)Settings.Default["txtArmLengthInput"];
            txtHeightInput.Text = (string)Settings.Default["txtHeightInput"];
            txtRadiusInput.Text = (string)Settings.Default["txtRadiusInput"];
            txtXadjustInput.Text =(string)Settings.Default["txtXadjustInput"];
            txtYAdjustInput.Text = (string)Settings.Default["txtYAdjustInput"];
            txtZAdjustInput.Text = (string)Settings.Default["txtZAdjustInput"];
            txtXEndstopInput.Text = (string)Settings.Default["txtXEndstopInput"];
            txtYEndstopInput.Text = (string)Settings.Default["txtYEndstopInput"];
            txtZEndstopInput.Text = (string)Settings.Default["txtZEndstopInput"];
            radioZProbe.Checked = ((string)Settings.Default["radioZProbe"] == true.ToString());
            radioZProbe.Checked = ((string)Settings.Default["radioZProbe"] == true.ToString());
            txtStepsPerMmInput.Text = (string)Settings.Default["txtStepsPerMmInput"];
            txtBedRadiusInput.Text = (string)Settings.Default["txtBedRadiusInput"];
        }

        private static Regex zCorrectionRegex = new Regex(@"Distortion correction at px:(?<x>[-]?\d+(\.\d+)?) py:(?<y>[-]?\d+(\.\d+)?) zCoorection:(?<z>[-]?\d+(\.\d+)?)", RegexOptions.Compiled);
        private static Regex zProbeRegex = new Regex(@"Z-probe:(?<z>[-]?\d+(\.\d+)?) X:(?<x>[-]?\d+(\.\d+)?) Y:(?<y>[-]?\d+(\.\d+)?)", RegexOptions.Compiled);
        private Regex ParsingRegex
        {
            get
            {
                if (radioZCorrection.Checked)
                    return zCorrectionRegex;
                else if (radioZProbe.Checked)
                    return zProbeRegex;
                else
                    return zCorrectionRegex; // default to z correction        
            }
        }

        private int SignMultiplier
        {
            get
            {
                if (radioZCorrection.Checked)
                    return 1;
                else if (radioZProbe.Checked)
                    return -1;
                else
                    return 1;      
            }
        }

        private object updateLock = new object();
        private void UpdateOutput()
        {
           lock (updateLock)
            {
                try
                {
                    var sb = new StringBuilder();
                    var list = new List<PointError>();
                    foreach (Match match in ParsingRegex.Matches(inputTextBox.Text))
                    {
                        list.Add(new PointError(double.Parse(match.Groups["x"].Value), double.Parse(match.Groups["y"].Value), SignMultiplier * double.Parse(match.Groups["z"].Value)));
                    }

                    double center;
                    if (list.Any(_ => _.X == 0 && _.Y == 0))
                    {
                        center = list.Single(_ => _.X == 0 && _.Y == 0).ZError;
                    }
                    else
                    {
                        var nearest =
                            (
                                from l in list
                                let dist = Math.Sqrt(Math.Pow(l.X, 2) + Math.Pow(l.Y, 2))
                                orderby dist
                                select new { l, dist }
                            )
                            .Take(4);
                        var totalDist = nearest.Sum(_ => _.dist);
                        center = nearest.Sum(_ => _.l.ZError * (_.dist / totalDist));
                    }

                    var cleanList = list.Select(_ => new PointError(_.X, _.Y, _.ZError - center)).ToList();
                    var lines =
                        from item in cleanList
                        select String.Format(@"G33 X{0:0.00} Y{1:0.00} Z{2:0.000}", item.X, item.Y, item.ZError);
                    sb.AppendLine("G33 R0");
                    outputTextBox.Text = "G33 R0\r\n" + String.Join("\r\n", lines);

                    double stepsPerMm = double.Parse(txtStepsPerMmInput.Text);
                    if (stepsPerMm == 0)
                        throw new Exception("Invalid steps per mm");

                    var delta = new Delta(
                        diagonal: double.Parse(txtArmLengthInput.Text),
                        radius: double.Parse(txtRadiusInput.Text),
                        height: double.Parse(txtHeightInput.Text),
                        xstop: double.Parse(txtXEndstopInput.Text) / stepsPerMm,
                        ystop: double.Parse(txtYEndstopInput.Text) / stepsPerMm,
                        zstop: double.Parse(txtZEndstopInput.Text) / stepsPerMm,
                        xadj: double.Parse(txtXadjustInput.Text),
                        yadj: double.Parse(txtYAdjustInput.Text),
                        zadj: double.Parse(txtZAdjustInput.Text)
                    );

                    double bedRadius = double.Parse(txtBedRadiusInput.Text);
                    double bedRadiusSquared = bedRadius * bedRadius;

                    //var invertSigns =
                    //    cleanList
                    //    .Select(_ => new PointError(_.X, _.Y, -1 * _.ZError))
                    //    .ToList();
                    //var result = delta.DoDeltaCalibration(7, invertSigns.ToList(), true);
                    var result = delta.DoDeltaCalibration(7, list.ToList(), true);
                    txtInitialError.Text = String.Format("{0:0.00}", result.Item1);
                    txtAdjustedError.Text = String.Format("{0:0.00}", result.Item2);
                    txtArmLengthOutput.Text = String.Format("{0:0.00}", delta.diagonal);
                    txtHeightOutput.Text = String.Format("{0:0.00}", delta.homedHeight);
                    txtRadiusOutput.Text = String.Format("{0:0.00}", delta.radius);
                    txtXadjustOutput.Text = String.Format("{0:0.00}", delta.xadj);
                    txtYAdjustOutput.Text = String.Format("{0:0.00}", delta.yadj);
                    txtZAdjustOutput.Text = String.Format("{0:0.00}", delta.zadj);
                    txtXEndstopOutput.Text = String.Format("{0:0.00}", delta.xstop * stepsPerMm);
                    txtYEndstopOutput.Text = String.Format("{0:0.00}", delta.ystop * stepsPerMm);
                    txtZEndstopOutput.Text = String.Format("{0:0.00}", delta.zstop * stepsPerMm);
                }
                catch (Exception)
                {
                    txtArmLengthOutput.Text
                        = txtHeightOutput.Text
                        = txtRadiusOutput.Text
                        = txtXadjustOutput.Text
                        = txtYAdjustOutput.Text
                        = txtZAdjustOutput.Text
                        = txtXEndstopOutput.Text
                        = txtYEndstopOutput.Text
                        = txtZEndstopOutput.Text
                        = String.Empty;
                }
            }
        }

        private void CopyOutputValuesToInput_Click(object sender, EventArgs e)
        {
            lock (updateLock)
            {
                txtArmLengthInput.Text = txtArmLengthOutput.Text;
                txtHeightInput.Text = txtHeightOutput.Text;
                txtRadiusInput.Text = txtRadiusOutput.Text;
                txtXadjustInput.Text = txtXadjustOutput.Text;
                txtYAdjustInput.Text = txtYAdjustOutput.Text;
                txtZAdjustInput.Text = txtZAdjustOutput.Text;
                txtXEndstopInput.Text = txtXEndstopOutput.Text;
                txtYEndstopInput.Text = txtYEndstopOutput.Text;
                txtZEndstopInput.Text = txtZEndstopOutput.Text;
            }
        }

        private void radioZCorrection_CheckedChanged(object sender, EventArgs e)
        {
            radioZProbe.Checked = false;
            radioZCorrection.Checked = true;
        }

        private void radioZProbe_CheckedChanged(object sender, EventArgs e)
        {
            radioZProbe.Checked = true;
            radioZCorrection.Checked = false;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            lock (updateLock)
            {
                Settings.Default["txtArmLengthInput"] = txtArmLengthInput.Text;
                Settings.Default["txtHeightInput"] = txtHeightInput.Text;
                Settings.Default["txtRadiusInput"] = txtRadiusInput.Text;
                Settings.Default["txtXadjustInput"] = txtXadjustInput.Text;
                Settings.Default["txtYAdjustInput"] = txtYAdjustInput.Text;
                Settings.Default["txtZAdjustInput"] = txtZAdjustInput.Text;
                Settings.Default["txtXEndstopInput"] = txtXEndstopInput.Text;
                Settings.Default["txtYEndstopInput"] = txtYEndstopInput.Text;
                Settings.Default["txtZEndstopInput"] = txtZEndstopInput.Text;
                Settings.Default["radioZProbe"] = radioZProbe.Checked.ToString();
                Settings.Default["radioZCorrection"] = radioZCorrection.Checked.ToString();
                Settings.Default["txtBedRadiusInput"] = txtBedRadiusInput.Text;
            }
            Properties.Settings.Default.Save();
            UpdateOutput();
        }

        private void generatePointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var generatePoints = new GeneratePoints();
            generatePoints.ShowDialog();
        }
    }
}

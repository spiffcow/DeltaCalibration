using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbeDataToCommands
{
    public partial class GeneratePoints : Form
    {
        public GeneratePoints()
        {
            InitializeComponent();
            txtGeneratePointsRadius.Text = (string)Properties.Settings.Default["txtBedRadiusInput"];
        }

        struct CirclePoint
        {
            public double x;
            public double y;
            public CirclePoint(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private void btnGeneratePoints_Click(object sender, EventArgs e)
        {
            try
            {
                double maxRadius = double.Parse(txtGeneratePointsRadius.Text);
                uint turnCount = uint.Parse(txtGeneratePointsTurns.Text);
                uint pointsPerTurn = uint.Parse(txtGeneratePointsNumberPointsPerTurn.Text);
                double returnZ = double.Parse(txtZReturnHeight.Text);
                double turn = Math.PI / (turnCount + 1);
                double interval = 2.0 * maxRadius / (pointsPerTurn - 1); 
                var list = new List<CirclePoint>() { new CirclePoint(0, 0) };
                for (int i = 0; i < turnCount; i++)
                {
                    var angle = i * turn;
                    for (int j = 0; j < pointsPerTurn; j++)
                    {
                        var rad = -1.0 * maxRadius + (interval * j);
                        list.Add(new CirclePoint(Math.Sin(angle) * rad, Math.Cos(angle) * rad));
                    }   
                }

                var lines =
                    from item in list
                    select String.Format("G1 X{0:0.00} Y{1:0.00} Z{2:0.00}\r\nG30", item.x, item.y, returnZ);

                txtGeneratePointsOutput.Text = 
                    "G33 R0\r\n"
                    + "M322 S3\r\n"
                    + "G28\r\n"
                    + String.Join("\r\n", lines)
                    + "\r\n";
            }
            catch
            {
                txtGeneratePointsOutput.Text = String.Empty;
            }
        }
    }
}

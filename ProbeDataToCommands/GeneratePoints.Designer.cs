namespace ProbeDataToCommands
{
    partial class GeneratePoints
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
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGeneratePointsRadius = new System.Windows.Forms.TextBox();
            this.txtGeneratePointsTurns = new System.Windows.Forms.TextBox();
            this.txtGeneratePointsNumberPointsPerTurn = new System.Windows.Forms.TextBox();
            this.btnGeneratePoints = new System.Windows.Forms.Button();
            this.txtGeneratePointsOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtZReturnHeight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Radius";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Turns";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Points Per Turn";
            // 
            // txtGeneratePointsRadius
            // 
            this.txtGeneratePointsRadius.Location = new System.Drawing.Point(96, 13);
            this.txtGeneratePointsRadius.Name = "txtGeneratePointsRadius";
            this.txtGeneratePointsRadius.Size = new System.Drawing.Size(100, 20);
            this.txtGeneratePointsRadius.TabIndex = 3;
            // 
            // txtGeneratePointsTurns
            // 
            this.txtGeneratePointsTurns.Location = new System.Drawing.Point(96, 39);
            this.txtGeneratePointsTurns.Name = "txtGeneratePointsTurns";
            this.txtGeneratePointsTurns.Size = new System.Drawing.Size(100, 20);
            this.txtGeneratePointsTurns.TabIndex = 4;
            this.txtGeneratePointsTurns.Text = "5";
            // 
            // txtGeneratePointsNumberPointsPerTurn
            // 
            this.txtGeneratePointsNumberPointsPerTurn.Location = new System.Drawing.Point(96, 65);
            this.txtGeneratePointsNumberPointsPerTurn.Name = "txtGeneratePointsNumberPointsPerTurn";
            this.txtGeneratePointsNumberPointsPerTurn.Size = new System.Drawing.Size(100, 20);
            this.txtGeneratePointsNumberPointsPerTurn.TabIndex = 5;
            this.txtGeneratePointsNumberPointsPerTurn.Text = "10";
            // 
            // btnGeneratePoints
            // 
            this.btnGeneratePoints.Location = new System.Drawing.Point(10, 117);
            this.btnGeneratePoints.Name = "btnGeneratePoints";
            this.btnGeneratePoints.Size = new System.Drawing.Size(187, 23);
            this.btnGeneratePoints.TabIndex = 6;
            this.btnGeneratePoints.Text = "Generate Points";
            this.btnGeneratePoints.UseVisualStyleBackColor = true;
            this.btnGeneratePoints.Click += new System.EventHandler(this.btnGeneratePoints_Click);
            // 
            // txtGeneratePointsOutput
            // 
            this.txtGeneratePointsOutput.Location = new System.Drawing.Point(203, 12);
            this.txtGeneratePointsOutput.Multiline = true;
            this.txtGeneratePointsOutput.Name = "txtGeneratePointsOutput";
            this.txtGeneratePointsOutput.ReadOnly = true;
            this.txtGeneratePointsOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGeneratePointsOutput.Size = new System.Drawing.Size(678, 489);
            this.txtGeneratePointsOutput.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Z Return Height";
            // 
            // txtZReturnHeight
            // 
            this.txtZReturnHeight.Location = new System.Drawing.Point(96, 91);
            this.txtZReturnHeight.Name = "txtZReturnHeight";
            this.txtZReturnHeight.Size = new System.Drawing.Size(100, 20);
            this.txtZReturnHeight.TabIndex = 9;
            this.txtZReturnHeight.Text = "40";
            // 
            // GeneratePoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 513);
            this.Controls.Add(this.txtZReturnHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGeneratePointsOutput);
            this.Controls.Add(this.btnGeneratePoints);
            this.Controls.Add(this.txtGeneratePointsNumberPointsPerTurn);
            this.Controls.Add(this.txtGeneratePointsTurns);
            this.Controls.Add(this.txtGeneratePointsRadius);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GeneratePoints";
            this.Text = "GeneratePoints";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGeneratePointsRadius;
        private System.Windows.Forms.TextBox txtGeneratePointsTurns;
        private System.Windows.Forms.TextBox txtGeneratePointsNumberPointsPerTurn;
        private System.Windows.Forms.Button btnGeneratePoints;
        private System.Windows.Forms.TextBox txtGeneratePointsOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtZReturnHeight;
    }
}
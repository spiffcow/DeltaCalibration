namespace ProbeDataToCommands
{
    partial class Form1
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
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtArmLengthInput = new System.Windows.Forms.TextBox();
            this.txtRadiusInput = new System.Windows.Forms.TextBox();
            this.txtHeightInput = new System.Windows.Forms.TextBox();
            this.txtXEndstopInput = new System.Windows.Forms.TextBox();
            this.txtYEndstopInput = new System.Windows.Forms.TextBox();
            this.txtZEndstopInput = new System.Windows.Forms.TextBox();
            this.txtXadjustInput = new System.Windows.Forms.TextBox();
            this.txtYAdjustInput = new System.Windows.Forms.TextBox();
            this.txtZAdjustInput = new System.Windows.Forms.TextBox();
            this.txtStepsPerMmInput = new System.Windows.Forms.TextBox();
            this.txtBedRadiusInput = new System.Windows.Forms.TextBox();
            this.txtArmLengthOutput = new System.Windows.Forms.TextBox();
            this.txtRadiusOutput = new System.Windows.Forms.TextBox();
            this.txtHeightOutput = new System.Windows.Forms.TextBox();
            this.txtXEndstopOutput = new System.Windows.Forms.TextBox();
            this.txtYEndstopOutput = new System.Windows.Forms.TextBox();
            this.txtZEndstopOutput = new System.Windows.Forms.TextBox();
            this.txtXadjustOutput = new System.Windows.Forms.TextBox();
            this.txtYAdjustOutput = new System.Windows.Forms.TextBox();
            this.txtZAdjustOutput = new System.Windows.Forms.TextBox();
            this.CopyOutputValuesToInput = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtInitialError = new System.Windows.Forms.TextBox();
            this.txtAdjustedError = new System.Windows.Forms.TextBox();
            this.radioGroupParsingType = new System.Windows.Forms.GroupBox();
            this.radioZProbe = new System.Windows.Forms.RadioButton();
            this.radioZCorrection = new System.Windows.Forms.RadioButton();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generatePointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioGroupParsingType.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.AcceptsReturn = true;
            this.inputTextBox.AllowDrop = true;
            this.inputTextBox.Location = new System.Drawing.Point(414, 45);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inputTextBox.Size = new System.Drawing.Size(715, 250);
            this.inputTextBox.TabIndex = 0;
            // 
            // outputTextBox
            // 
            this.outputTextBox.AcceptsReturn = true;
            this.outputTextBox.AllowDrop = true;
            this.outputTextBox.Location = new System.Drawing.Point(414, 311);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(715, 250);
            this.outputTextBox.TabIndex = 1;
            this.outputTextBox.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X Endstop";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y Endstop";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Z Endstop";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Height";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Radius";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Arm Length";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Z Adjust";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Y Adjust";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "X Adjust";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Steps per mm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 344);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Bed Radius";
            // 
            // txtArmLengthInput
            // 
            this.txtArmLengthInput.Location = new System.Drawing.Point(79, 45);
            this.txtArmLengthInput.Name = "txtArmLengthInput";
            this.txtArmLengthInput.Size = new System.Drawing.Size(100, 20);
            this.txtArmLengthInput.TabIndex = 13;
            this.txtArmLengthInput.Text = "240";
            // 
            // txtRadiusInput
            // 
            this.txtRadiusInput.Location = new System.Drawing.Point(79, 74);
            this.txtRadiusInput.Name = "txtRadiusInput";
            this.txtRadiusInput.Size = new System.Drawing.Size(100, 20);
            this.txtRadiusInput.TabIndex = 14;
            this.txtRadiusInput.Text = "140";
            // 
            // txtHeightInput
            // 
            this.txtHeightInput.Location = new System.Drawing.Point(79, 104);
            this.txtHeightInput.Name = "txtHeightInput";
            this.txtHeightInput.Size = new System.Drawing.Size(100, 20);
            this.txtHeightInput.TabIndex = 15;
            this.txtHeightInput.Text = "300";
            // 
            // txtXEndstopInput
            // 
            this.txtXEndstopInput.Location = new System.Drawing.Point(79, 133);
            this.txtXEndstopInput.Name = "txtXEndstopInput";
            this.txtXEndstopInput.Size = new System.Drawing.Size(100, 20);
            this.txtXEndstopInput.TabIndex = 16;
            this.txtXEndstopInput.Text = "0";
            // 
            // txtYEndstopInput
            // 
            this.txtYEndstopInput.Location = new System.Drawing.Point(79, 162);
            this.txtYEndstopInput.Name = "txtYEndstopInput";
            this.txtYEndstopInput.Size = new System.Drawing.Size(100, 20);
            this.txtYEndstopInput.TabIndex = 17;
            this.txtYEndstopInput.Text = "0";
            // 
            // txtZEndstopInput
            // 
            this.txtZEndstopInput.Location = new System.Drawing.Point(79, 192);
            this.txtZEndstopInput.Name = "txtZEndstopInput";
            this.txtZEndstopInput.Size = new System.Drawing.Size(100, 20);
            this.txtZEndstopInput.TabIndex = 18;
            this.txtZEndstopInput.Text = "0";
            // 
            // txtXadjustInput
            // 
            this.txtXadjustInput.Location = new System.Drawing.Point(79, 221);
            this.txtXadjustInput.Name = "txtXadjustInput";
            this.txtXadjustInput.Size = new System.Drawing.Size(100, 20);
            this.txtXadjustInput.TabIndex = 19;
            this.txtXadjustInput.Text = "0";
            // 
            // txtYAdjustInput
            // 
            this.txtYAdjustInput.Location = new System.Drawing.Point(79, 250);
            this.txtYAdjustInput.Name = "txtYAdjustInput";
            this.txtYAdjustInput.Size = new System.Drawing.Size(100, 20);
            this.txtYAdjustInput.TabIndex = 20;
            this.txtYAdjustInput.Text = "0";
            // 
            // txtZAdjustInput
            // 
            this.txtZAdjustInput.Location = new System.Drawing.Point(79, 280);
            this.txtZAdjustInput.Name = "txtZAdjustInput";
            this.txtZAdjustInput.Size = new System.Drawing.Size(100, 20);
            this.txtZAdjustInput.TabIndex = 21;
            this.txtZAdjustInput.Text = "0";
            // 
            // txtStepsPerMmInput
            // 
            this.txtStepsPerMmInput.Location = new System.Drawing.Point(79, 308);
            this.txtStepsPerMmInput.Name = "txtStepsPerMmInput";
            this.txtStepsPerMmInput.Size = new System.Drawing.Size(100, 20);
            this.txtStepsPerMmInput.TabIndex = 22;
            this.txtStepsPerMmInput.Text = "80";
            // 
            // txtBedRadiusInput
            // 
            this.txtBedRadiusInput.Location = new System.Drawing.Point(79, 341);
            this.txtBedRadiusInput.Name = "txtBedRadiusInput";
            this.txtBedRadiusInput.Size = new System.Drawing.Size(100, 20);
            this.txtBedRadiusInput.TabIndex = 23;
            this.txtBedRadiusInput.Text = "100";
            // 
            // txtArmLengthOutput
            // 
            this.txtArmLengthOutput.Location = new System.Drawing.Point(185, 45);
            this.txtArmLengthOutput.Name = "txtArmLengthOutput";
            this.txtArmLengthOutput.ReadOnly = true;
            this.txtArmLengthOutput.Size = new System.Drawing.Size(100, 20);
            this.txtArmLengthOutput.TabIndex = 24;
            // 
            // txtRadiusOutput
            // 
            this.txtRadiusOutput.Location = new System.Drawing.Point(185, 74);
            this.txtRadiusOutput.Name = "txtRadiusOutput";
            this.txtRadiusOutput.ReadOnly = true;
            this.txtRadiusOutput.Size = new System.Drawing.Size(100, 20);
            this.txtRadiusOutput.TabIndex = 25;
            // 
            // txtHeightOutput
            // 
            this.txtHeightOutput.Location = new System.Drawing.Point(185, 104);
            this.txtHeightOutput.Name = "txtHeightOutput";
            this.txtHeightOutput.ReadOnly = true;
            this.txtHeightOutput.Size = new System.Drawing.Size(100, 20);
            this.txtHeightOutput.TabIndex = 26;
            // 
            // txtXEndstopOutput
            // 
            this.txtXEndstopOutput.Location = new System.Drawing.Point(185, 133);
            this.txtXEndstopOutput.Name = "txtXEndstopOutput";
            this.txtXEndstopOutput.ReadOnly = true;
            this.txtXEndstopOutput.Size = new System.Drawing.Size(100, 20);
            this.txtXEndstopOutput.TabIndex = 27;
            // 
            // txtYEndstopOutput
            // 
            this.txtYEndstopOutput.Location = new System.Drawing.Point(185, 162);
            this.txtYEndstopOutput.Name = "txtYEndstopOutput";
            this.txtYEndstopOutput.ReadOnly = true;
            this.txtYEndstopOutput.Size = new System.Drawing.Size(100, 20);
            this.txtYEndstopOutput.TabIndex = 28;
            // 
            // txtZEndstopOutput
            // 
            this.txtZEndstopOutput.Location = new System.Drawing.Point(185, 192);
            this.txtZEndstopOutput.Name = "txtZEndstopOutput";
            this.txtZEndstopOutput.ReadOnly = true;
            this.txtZEndstopOutput.Size = new System.Drawing.Size(100, 20);
            this.txtZEndstopOutput.TabIndex = 29;
            // 
            // txtXadjustOutput
            // 
            this.txtXadjustOutput.Location = new System.Drawing.Point(185, 221);
            this.txtXadjustOutput.Name = "txtXadjustOutput";
            this.txtXadjustOutput.ReadOnly = true;
            this.txtXadjustOutput.Size = new System.Drawing.Size(100, 20);
            this.txtXadjustOutput.TabIndex = 30;
            // 
            // txtYAdjustOutput
            // 
            this.txtYAdjustOutput.Location = new System.Drawing.Point(185, 250);
            this.txtYAdjustOutput.Name = "txtYAdjustOutput";
            this.txtYAdjustOutput.ReadOnly = true;
            this.txtYAdjustOutput.Size = new System.Drawing.Size(100, 20);
            this.txtYAdjustOutput.TabIndex = 31;
            // 
            // txtZAdjustOutput
            // 
            this.txtZAdjustOutput.Location = new System.Drawing.Point(185, 280);
            this.txtZAdjustOutput.Name = "txtZAdjustOutput";
            this.txtZAdjustOutput.ReadOnly = true;
            this.txtZAdjustOutput.Size = new System.Drawing.Size(100, 20);
            this.txtZAdjustOutput.TabIndex = 32;
            // 
            // CopyOutputValuesToInput
            // 
            this.CopyOutputValuesToInput.Location = new System.Drawing.Point(155, 538);
            this.CopyOutputValuesToInput.Name = "CopyOutputValuesToInput";
            this.CopyOutputValuesToInput.Size = new System.Drawing.Size(129, 23);
            this.CopyOutputValuesToInput.TabIndex = 33;
            this.CopyOutputValuesToInput.Text = "Output -> Input";
            this.CopyOutputValuesToInput.UseVisualStyleBackColor = true;
            this.CopyOutputValuesToInput.Click += new System.EventHandler(this.CopyOutputValuesToInput_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 372);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Error";
            // 
            // txtInitialError
            // 
            this.txtInitialError.Location = new System.Drawing.Point(79, 372);
            this.txtInitialError.Name = "txtInitialError";
            this.txtInitialError.ReadOnly = true;
            this.txtInitialError.Size = new System.Drawing.Size(100, 20);
            this.txtInitialError.TabIndex = 35;
            // 
            // txtAdjustedError
            // 
            this.txtAdjustedError.Location = new System.Drawing.Point(185, 372);
            this.txtAdjustedError.Name = "txtAdjustedError";
            this.txtAdjustedError.ReadOnly = true;
            this.txtAdjustedError.Size = new System.Drawing.Size(100, 20);
            this.txtAdjustedError.TabIndex = 36;
            // 
            // radioGroupParsingType
            // 
            this.radioGroupParsingType.Controls.Add(this.radioZProbe);
            this.radioGroupParsingType.Controls.Add(this.radioZCorrection);
            this.radioGroupParsingType.Location = new System.Drawing.Point(15, 412);
            this.radioGroupParsingType.Name = "radioGroupParsingType";
            this.radioGroupParsingType.Size = new System.Drawing.Size(269, 73);
            this.radioGroupParsingType.TabIndex = 37;
            this.radioGroupParsingType.TabStop = false;
            this.radioGroupParsingType.Text = "Parsing Mode";
            // 
            // radioZProbe
            // 
            this.radioZProbe.AutoSize = true;
            this.radioZProbe.Location = new System.Drawing.Point(7, 44);
            this.radioZProbe.Name = "radioZProbe";
            this.radioZProbe.Size = new System.Drawing.Size(127, 17);
            this.radioZProbe.TabIndex = 1;
            this.radioZProbe.TabStop = true;
            this.radioZProbe.Text = "Z Probe Output (G30)";
            this.radioZProbe.UseVisualStyleBackColor = true;
            // 
            // radioZCorrection
            // 
            this.radioZCorrection.AutoSize = true;
            this.radioZCorrection.Location = new System.Drawing.Point(7, 20);
            this.radioZCorrection.Name = "radioZCorrection";
            this.radioZCorrection.Size = new System.Drawing.Size(127, 17);
            this.radioZCorrection.TabIndex = 0;
            this.radioZCorrection.TabStop = true;
            this.radioZCorrection.Text = "Z Correction (G33 L0)";
            this.radioZCorrection.UseVisualStyleBackColor = true;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(6, 538);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(129, 23);
            this.btnCalculate.TabIndex = 38;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generatePointsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1141, 24);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generatePointsToolStripMenuItem
            // 
            this.generatePointsToolStripMenuItem.Name = "generatePointsToolStripMenuItem";
            this.generatePointsToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.generatePointsToolStripMenuItem.Text = "Generate Points";
            this.generatePointsToolStripMenuItem.Click += new System.EventHandler(this.generatePointsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 571);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.radioGroupParsingType);
            this.Controls.Add(this.txtAdjustedError);
            this.Controls.Add(this.txtInitialError);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CopyOutputValuesToInput);
            this.Controls.Add(this.txtZAdjustOutput);
            this.Controls.Add(this.txtYAdjustOutput);
            this.Controls.Add(this.txtXadjustOutput);
            this.Controls.Add(this.txtZEndstopOutput);
            this.Controls.Add(this.txtYEndstopOutput);
            this.Controls.Add(this.txtXEndstopOutput);
            this.Controls.Add(this.txtHeightOutput);
            this.Controls.Add(this.txtRadiusOutput);
            this.Controls.Add(this.txtArmLengthOutput);
            this.Controls.Add(this.txtBedRadiusInput);
            this.Controls.Add(this.txtStepsPerMmInput);
            this.Controls.Add(this.txtZAdjustInput);
            this.Controls.Add(this.txtYAdjustInput);
            this.Controls.Add(this.txtXadjustInput);
            this.Controls.Add(this.txtZEndstopInput);
            this.Controls.Add(this.txtYEndstopInput);
            this.Controls.Add(this.txtXEndstopInput);
            this.Controls.Add(this.txtHeightInput);
            this.Controls.Add(this.txtRadiusInput);
            this.Controls.Add(this.txtArmLengthInput);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Convert to commands";
            this.radioGroupParsingType.ResumeLayout(false);
            this.radioGroupParsingType.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtArmLengthInput;
        private System.Windows.Forms.TextBox txtRadiusInput;
        private System.Windows.Forms.TextBox txtHeightInput;
        private System.Windows.Forms.TextBox txtXEndstopInput;
        private System.Windows.Forms.TextBox txtYEndstopInput;
        private System.Windows.Forms.TextBox txtZEndstopInput;
        private System.Windows.Forms.TextBox txtXadjustInput;
        private System.Windows.Forms.TextBox txtYAdjustInput;
        private System.Windows.Forms.TextBox txtZAdjustInput;
        private System.Windows.Forms.TextBox txtStepsPerMmInput;
        private System.Windows.Forms.TextBox txtBedRadiusInput;
        private System.Windows.Forms.TextBox txtArmLengthOutput;
        private System.Windows.Forms.TextBox txtRadiusOutput;
        private System.Windows.Forms.TextBox txtHeightOutput;
        private System.Windows.Forms.TextBox txtXEndstopOutput;
        private System.Windows.Forms.TextBox txtYEndstopOutput;
        private System.Windows.Forms.TextBox txtZEndstopOutput;
        private System.Windows.Forms.TextBox txtXadjustOutput;
        private System.Windows.Forms.TextBox txtYAdjustOutput;
        private System.Windows.Forms.TextBox txtZAdjustOutput;
        private System.Windows.Forms.Button CopyOutputValuesToInput;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtInitialError;
        private System.Windows.Forms.TextBox txtAdjustedError;
        private System.Windows.Forms.GroupBox radioGroupParsingType;
        private System.Windows.Forms.RadioButton radioZProbe;
        private System.Windows.Forms.RadioButton radioZCorrection;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generatePointsToolStripMenuItem;
    }
}


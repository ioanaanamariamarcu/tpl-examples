﻿namespace TplExamples
{
    partial class RenderManyLines
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTpThreads = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDedicated = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 782);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sequential",
            "Parallel",
            "BadLongRunning",
            "GoodLongRunning"});
            this.comboBox1.Location = new System.Drawing.Point(95, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "TP:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTpThreads
            // 
            this.lblTpThreads.AutoSize = true;
            this.lblTpThreads.Location = new System.Drawing.Point(273, 13);
            this.lblTpThreads.Name = "lblTpThreads";
            this.lblTpThreads.Size = new System.Drawing.Size(0, 17);
            this.lblTpThreads.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "D:";
            // 
            // lblDedicated
            // 
            this.lblDedicated.AutoSize = true;
            this.lblDedicated.Location = new System.Drawing.Point(510, 13);
            this.lblDedicated.Name = "lblDedicated";
            this.lblDedicated.Size = new System.Drawing.Size(0, 17);
            this.lblDedicated.TabIndex = 6;
            // 
            // RenderManyLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 837);
            this.Controls.Add(this.lblDedicated);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTpThreads);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "RenderManyLines";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTpThreads;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDedicated;
    }
}


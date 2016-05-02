namespace GraphGui
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.graph = new ZedGraph.ZedGraphControl();
            this.labelPanel = new System.Windows.Forms.Panel();
            this.durationlbl = new System.Windows.Forms.Label();
            this.octavelbl = new System.Windows.Forms.Label();
            this.lastNotelbl = new System.Windows.Forms.Label();
            this.adsrlbl = new System.Windows.Forms.Label();
            this.adsrGraph = new ZedGraph.ZedGraphControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.connect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // graph
            // 
            this.graph.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.graph.Location = new System.Drawing.Point(30, 26);
            this.graph.Name = "graph";
            this.graph.ScrollGrace = 0D;
            this.graph.ScrollMaxX = 0D;
            this.graph.ScrollMaxY = 0D;
            this.graph.ScrollMaxY2 = 0D;
            this.graph.ScrollMinX = 0D;
            this.graph.ScrollMinY = 0D;
            this.graph.ScrollMinY2 = 0D;
            this.graph.Size = new System.Drawing.Size(502, 316);
            this.graph.TabIndex = 1;
            // 
            // labelPanel
            // 
            this.labelPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPanel.Controls.Add(this.durationlbl);
            this.labelPanel.Controls.Add(this.octavelbl);
            this.labelPanel.Controls.Add(this.lastNotelbl);
            this.labelPanel.Controls.Add(this.adsrlbl);
            this.labelPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanel.Location = new System.Drawing.Point(122, 358);
            this.labelPanel.Name = "labelPanel";
            this.labelPanel.Size = new System.Drawing.Size(642, 67);
            this.labelPanel.TabIndex = 2;
            // 
            // durationlbl
            // 
            this.durationlbl.AutoSize = true;
            this.durationlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationlbl.Location = new System.Drawing.Point(476, 25);
            this.durationlbl.Name = "durationlbl";
            this.durationlbl.Size = new System.Drawing.Size(51, 20);
            this.durationlbl.TabIndex = 3;
            this.durationlbl.Text = "label1";
            // 
            // octavelbl
            // 
            this.octavelbl.AutoSize = true;
            this.octavelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.octavelbl.Location = new System.Drawing.Point(215, 27);
            this.octavelbl.Name = "octavelbl";
            this.octavelbl.Size = new System.Drawing.Size(51, 20);
            this.octavelbl.TabIndex = 2;
            this.octavelbl.Text = "label2";
            // 
            // lastNotelbl
            // 
            this.lastNotelbl.AutoSize = true;
            this.lastNotelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNotelbl.Location = new System.Drawing.Point(349, 27);
            this.lastNotelbl.Name = "lastNotelbl";
            this.lastNotelbl.Size = new System.Drawing.Size(51, 20);
            this.lastNotelbl.TabIndex = 1;
            this.lastNotelbl.Text = "label2";
            // 
            // adsrlbl
            // 
            this.adsrlbl.AutoSize = true;
            this.adsrlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adsrlbl.Location = new System.Drawing.Point(48, 28);
            this.adsrlbl.Name = "adsrlbl";
            this.adsrlbl.Size = new System.Drawing.Size(51, 20);
            this.adsrlbl.TabIndex = 0;
            this.adsrlbl.Text = "label1";
            // 
            // adsrGraph
            // 
            this.adsrGraph.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.adsrGraph.Location = new System.Drawing.Point(563, 26);
            this.adsrGraph.Name = "adsrGraph";
            this.adsrGraph.ScrollGrace = 0D;
            this.adsrGraph.ScrollMaxX = 0D;
            this.adsrGraph.ScrollMaxY = 0D;
            this.adsrGraph.ScrollMaxY2 = 0D;
            this.adsrGraph.ScrollMinX = 0D;
            this.adsrGraph.ScrollMinY = 0D;
            this.adsrGraph.ScrollMinY2 = 0D;
            this.adsrGraph.Size = new System.Drawing.Size(502, 316);
            this.adsrGraph.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileD";
            // 
            // connect
            // 
            this.connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.connect.FlatAppearance.BorderSize = 0;
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect.ForeColor = System.Drawing.Color.White;
            this.connect.Location = new System.Drawing.Point(823, 358);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(185, 33);
            this.connect.TabIndex = 4;
            this.connect.Text = "Connect Bluetooth";
            this.connect.UseVisualStyleBackColor = false;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(823, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start Hotkeys";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1094, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.adsrGraph);
            this.Controls.Add(this.labelPanel);
            this.Controls.Add(this.graph);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(270, 290);
            this.Name = "Form1";
            this.Text = "Bluetooth Synthesizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.labelPanel.ResumeLayout(false);
            this.labelPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl graph;
        private System.Windows.Forms.Panel labelPanel;
        private System.Windows.Forms.Label lastNotelbl;
        private System.Windows.Forms.Label adsrlbl;
        private ZedGraph.ZedGraphControl adsrGraph;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label octavelbl;
        private System.Windows.Forms.Label durationlbl;
        private System.Windows.Forms.Button button1;
    }
}


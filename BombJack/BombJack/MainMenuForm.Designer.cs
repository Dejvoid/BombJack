namespace BombJack
{
    partial class MainMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.start_btn = new System.Windows.Forms.Button();
            this.controls_btn = new System.Windows.Forms.Button();
            this.createMap_btn = new System.Windows.Forms.Button();
            this.loadMap_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(12, 12);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(635, 92);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "Start Game";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // controls_btn
            // 
            this.controls_btn.Location = new System.Drawing.Point(12, 110);
            this.controls_btn.Name = "controls_btn";
            this.controls_btn.Size = new System.Drawing.Size(635, 92);
            this.controls_btn.TabIndex = 1;
            this.controls_btn.Text = "Show Controls";
            this.controls_btn.UseVisualStyleBackColor = true;
            // 
            // createMap_btn
            // 
            this.createMap_btn.Location = new System.Drawing.Point(12, 208);
            this.createMap_btn.Name = "createMap_btn";
            this.createMap_btn.Size = new System.Drawing.Size(635, 92);
            this.createMap_btn.TabIndex = 2;
            this.createMap_btn.Text = "Create Map";
            this.createMap_btn.UseVisualStyleBackColor = true;
            this.createMap_btn.Click += new System.EventHandler(this.createMap_btn_Click);
            // 
            // loadMap_btn
            // 
            this.loadMap_btn.Location = new System.Drawing.Point(12, 306);
            this.loadMap_btn.Name = "loadMap_btn";
            this.loadMap_btn.Size = new System.Drawing.Size(635, 92);
            this.loadMap_btn.TabIndex = 3;
            this.loadMap_btn.Text = "Load Map JSON";
            this.loadMap_btn.UseVisualStyleBackColor = true;
            this.loadMap_btn.Click += new System.EventHandler(this.loadMap_btn_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 413);
            this.Controls.Add(this.loadMap_btn);
            this.Controls.Add(this.createMap_btn);
            this.Controls.Add(this.controls_btn);
            this.Controls.Add(this.start_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.Text = "Bomb Jack - Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private Button start_btn;
        private Button controls_btn;
        private Button createMap_btn;
        private Button loadMap_btn;
    }
}
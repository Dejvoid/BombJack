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
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(12, 12);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(98, 23);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "Start Game";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // controls_btn
            // 
            this.controls_btn.Location = new System.Drawing.Point(12, 41);
            this.controls_btn.Name = "controls_btn";
            this.controls_btn.Size = new System.Drawing.Size(98, 23);
            this.controls_btn.TabIndex = 1;
            this.controls_btn.Text = "Show Controls";
            this.controls_btn.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.controls_btn);
            this.Controls.Add(this.start_btn);
            this.Name = "MainMenuForm";
            this.Text = "Bomb Jack - Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private Button start_btn;
        private Button controls_btn;
    }
}
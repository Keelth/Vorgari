namespace Vorgari {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.console_output_rt = new System.Windows.Forms.RichTextBox();
            this.connect_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // console_output_rt
            // 
            this.console_output_rt.Location = new System.Drawing.Point(12, 12);
            this.console_output_rt.Name = "console_output_rt";
            this.console_output_rt.Size = new System.Drawing.Size(367, 321);
            this.console_output_rt.TabIndex = 2;
            this.console_output_rt.Text = "";
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(12, 350);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(367, 23);
            this.connect_btn.TabIndex = 3;
            this.connect_btn.Text = "Connect";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 385);
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.console_output_rt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox console_output_rt;
        private System.Windows.Forms.Button connect_btn;
    }
}


namespace MayinTarlasi.UI
{
    partial class Form1
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
            btnYeniOyun = new Button();
            grpMayinlar = new GroupBox();
            SuspendLayout();

            // 
            // btnYeniOyun
            // 
            btnYeniOyun.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnYeniOyun.Location = new Point(325, 20);
            btnYeniOyun.Name = "btnYeniOyun";
            btnYeniOyun.Size = new Size(150, 40);
            btnYeniOyun.TabIndex = 0;
            btnYeniOyun.Text = "Yeni Oyun";
            btnYeniOyun.UseVisualStyleBackColor = true;
            btnYeniOyun.Click += btnYeniOyun_Click;

            // 
            // grpMayinlar
            // 
            grpMayinlar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            grpMayinlar.Padding = new Padding(10, 25, 10, 10);
            grpMayinlar.Location = new Point(20, 100); // Aşağı kaydırdım
            grpMayinlar.Size = new Size(760, 580);
            grpMayinlar.Text = "MAYIN TARLASI"; // Daha net başlık

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 700);
            Controls.Add(grpMayinlar);
            Controls.Add(btnYeniOyun);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mayın Tarlası Oyunu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnYeniOyun;
        private GroupBox grpMayinlar;
    }
}

﻿
namespace OkulKitapligiAdonet
{
    partial class FormYazarlar
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYazar = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.dataGridViewYazarlar = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnTemizle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYazarlar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yazar Ad Soyad";
            // 
            // txtYazar
            // 
            this.txtYazar.Location = new System.Drawing.Point(132, 34);
            this.txtYazar.Name = "txtYazar";
            this.txtYazar.Size = new System.Drawing.Size(217, 27);
            this.txtYazar.TabIndex = 1;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(355, 32);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(115, 29);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // dataGridViewYazarlar
            // 
            this.dataGridViewYazarlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewYazarlar.Location = new System.Drawing.Point(12, 114);
            this.dataGridViewYazarlar.Name = "dataGridViewYazarlar";
            this.dataGridViewYazarlar.RowHeadersWidth = 51;
            this.dataGridViewYazarlar.RowTemplate.Height = 29;
            this.dataGridViewYazarlar.Size = new System.Drawing.Size(579, 219);
            this.dataGridViewYazarlar.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(476, 34);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(115, 29);
            this.btnTemizle.TabIndex = 6;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = true;
            // 
            // FormYazarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 368);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.dataGridViewYazarlar);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtYazar);
            this.Controls.Add(this.label1);
            this.Name = "FormYazarlar";
            this.Text = "Yazar İşlemleri";
            this.Load += new System.EventHandler(this.FormYazarlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYazarlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYazar;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.DataGridView dataGridViewYazarlar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnTemizle;
    }
}


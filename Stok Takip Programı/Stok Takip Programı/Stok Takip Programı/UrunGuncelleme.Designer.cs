﻿namespace Stok_Takip_Programı
{
    partial class Form7
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Corbel", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(92, 232);
            label4.Name = "label4";
            label4.Size = new Size(101, 23);
            label4.TabIndex = 17;
            label4.Text = "Stok Adedi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Corbel", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(92, 175);
            label3.Name = "label3";
            label3.Size = new Size(147, 23);
            label3.TabIndex = 16;
            label3.Text = "Ürün Satış Fiyatı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Corbel", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(92, 116);
            label2.Name = "label2";
            label2.Size = new Size(135, 23);
            label2.TabIndex = 15;
            label2.Text = "Ürün Alış Fiyatı";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(92, 56);
            label1.Name = "label1";
            label1.Size = new Size(82, 23);
            label1.TabIndex = 14;
            label1.Text = "Ürün Adı";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(113, 310);
            button1.Name = "button1";
            button1.Size = new Size(221, 66);
            button1.TabIndex = 13;
            button1.Text = "Ürünü Güncelle";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox4.Location = new Point(95, 258);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(263, 23);
            textBox4.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(95, 201);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(263, 23);
            textBox3.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(95, 142);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(263, 23);
            textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(92, 82);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(266, 23);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form7";
            Text = "Form7";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}
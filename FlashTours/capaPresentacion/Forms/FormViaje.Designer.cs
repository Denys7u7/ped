namespace capaPresentacion.Forms
{
    partial class FormViaje
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnregistrar = new System.Windows.Forms.Button();
            this.dgvViajes = new System.Windows.Forms.DataGridView();
            this.cmbViajes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajes)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(303, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 40);
            this.label4.TabIndex = 50;
            this.label4.Text = "Asignar personas";
            // 
            // btnregistrar
            // 
            this.btnregistrar.BackColor = System.Drawing.Color.Green;
            this.btnregistrar.FlatAppearance.BorderSize = 0;
            this.btnregistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnregistrar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregistrar.ForeColor = System.Drawing.Color.White;
            this.btnregistrar.Location = new System.Drawing.Point(12, 136);
            this.btnregistrar.Name = "btnregistrar";
            this.btnregistrar.Size = new System.Drawing.Size(112, 37);
            this.btnregistrar.TabIndex = 57;
            this.btnregistrar.Text = "Elegir Viaje";
            this.btnregistrar.UseVisualStyleBackColor = false;
            this.btnregistrar.Click += new System.EventHandler(this.btnregistrar_Click);
            // 
            // dgvViajes
            // 
            this.dgvViajes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvViajes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViajes.BackgroundColor = System.Drawing.Color.White;
            this.dgvViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViajes.Location = new System.Drawing.Point(12, 191);
            this.dgvViajes.Name = "dgvViajes";
            this.dgvViajes.Size = new System.Drawing.Size(811, 211);
            this.dgvViajes.TabIndex = 56;
            // 
            // cmbViajes
            // 
            this.cmbViajes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViajes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbViajes.FormattingEnabled = true;
            this.cmbViajes.Location = new System.Drawing.Point(151, 146);
            this.cmbViajes.Name = "cmbViajes";
            this.cmbViajes.Size = new System.Drawing.Size(268, 21);
            this.cmbViajes.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(147, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 21);
            this.label1.TabIndex = 59;
            this.label1.Text = "Seleccionar viaje";
            // 
            // FormViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 463);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbViajes);
            this.Controls.Add(this.btnregistrar);
            this.Controls.Add(this.dgvViajes);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormViaje";
            this.Text = "FormViaje";
            this.Load += new System.EventHandler(this.FormViaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnregistrar;
        private System.Windows.Forms.DataGridView dgvViajes;
        private System.Windows.Forms.ComboBox cmbViajes;
        private System.Windows.Forms.Label label1;
    }
}
namespace A9_Bidwell___Pinata {
	partial class ModifierForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
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
		private void InitializeComponent () {
			this.tblMain = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbBatLength = new System.Windows.Forms.ComboBox();
			this.cbBatMaterial = new System.Windows.Forms.ComboBox();
			this.cbPinataMaterial = new System.Windows.Forms.ComboBox();
			this.tblMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tblMain
			// 
			this.tblMain.ColumnCount = 2;
			this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblMain.Controls.Add(this.label1, 0, 0);
			this.tblMain.Controls.Add(this.label2, 0, 1);
			this.tblMain.Controls.Add(this.label3, 0, 2);
			this.tblMain.Controls.Add(this.cbBatMaterial, 1, 1);
			this.tblMain.Controls.Add(this.cbPinataMaterial, 1, 0);
			this.tblMain.Controls.Add(this.cbBatLength, 1, 2);
			this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblMain.Location = new System.Drawing.Point(0, 0);
			this.tblMain.Name = "tblMain";
			this.tblMain.RowCount = 3;
			this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tblMain.Size = new System.Drawing.Size(431, 406);
			this.tblMain.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(231)))), ((int)(((byte)(37)))));
			this.label1.Location = new System.Drawing.Point(34, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(178, 135);
			this.label1.TabIndex = 0;
			this.label1.Text = "Piñata material:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(231)))), ((int)(((byte)(37)))));
			this.label2.Location = new System.Drawing.Point(65, 135);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(147, 135);
			this.label2.TabIndex = 0;
			this.label2.Text = "Bat material:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(231)))), ((int)(((byte)(37)))));
			this.label3.Location = new System.Drawing.Point(82, 270);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(130, 136);
			this.label3.TabIndex = 0;
			this.label3.Text = "Bat length:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbBatLength
			// 
			this.cbBatLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbBatLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cbBatLength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbBatLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(231)))), ((int)(((byte)(37)))));
			this.cbBatLength.FormattingEnabled = true;
			this.cbBatLength.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
			this.cbBatLength.Location = new System.Drawing.Point(218, 318);
			this.cbBatLength.Name = "cbBatLength";
			this.cbBatLength.Size = new System.Drawing.Size(210, 39);
			this.cbBatLength.TabIndex = 1;
			this.cbBatLength.Text = "5";
			// 
			// cbBatMaterial
			// 
			this.cbBatMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbBatMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cbBatMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbBatMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(231)))), ((int)(((byte)(37)))));
			this.cbBatMaterial.FormattingEnabled = true;
			this.cbBatMaterial.Items.AddRange(new object[] {
            "Aluminum",
            "Titanium",
            "Zinc",
            "Silver",
            "Gold",
            "Iridium"});
			this.cbBatMaterial.Location = new System.Drawing.Point(218, 190);
			this.cbBatMaterial.Name = "cbBatMaterial";
			this.cbBatMaterial.Size = new System.Drawing.Size(210, 39);
			this.cbBatMaterial.TabIndex = 1;
			this.cbBatMaterial.Text = "Zinc";
			// 
			// cbPinataMaterial
			// 
			this.cbPinataMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPinataMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cbPinataMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbPinataMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(231)))), ((int)(((byte)(37)))));
			this.cbPinataMaterial.FormattingEnabled = true;
			this.cbPinataMaterial.Items.AddRange(new object[] {
            "Aluminum",
            "Titanium",
            "Zinc",
            "Silver",
            "Gold",
            "Iridium"});
			this.cbPinataMaterial.Location = new System.Drawing.Point(218, 55);
			this.cbPinataMaterial.Name = "cbPinataMaterial";
			this.cbPinataMaterial.Size = new System.Drawing.Size(210, 39);
			this.cbPinataMaterial.TabIndex = 1;
			this.cbPinataMaterial.Text = "Gold";
			// 
			// ModifierForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.ClientSize = new System.Drawing.Size(431, 406);
			this.Controls.Add(this.tblMain);
			this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "ModifierForm";
			this.Text = "Mods";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModifierForm_FormClosing);
			this.tblMain.ResumeLayout(false);
			this.tblMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tblMain;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbBatLength;
		private System.Windows.Forms.ComboBox cbBatMaterial;
		private System.Windows.Forms.ComboBox cbPinataMaterial;
	}
}
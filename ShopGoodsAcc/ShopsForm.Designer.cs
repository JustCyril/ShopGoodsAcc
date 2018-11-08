namespace ShopGoodsAcc
{
    partial class ShopsForm
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
            this.tlpShops = new System.Windows.Forms.TableLayoutPanel();
            this.dGVShops = new System.Windows.Forms.DataGridView();
            this.flpShops = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShopsDelete = new System.Windows.Forms.Button();
            this.btnShopsChange = new System.Windows.Forms.Button();
            this.btnShopsAdd = new System.Windows.Forms.Button();
            this.shop_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shop_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpShops.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVShops)).BeginInit();
            this.flpShops.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpShops
            // 
            this.tlpShops.ColumnCount = 4;
            this.tlpShops.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpShops.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tlpShops.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tlpShops.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpShops.Controls.Add(this.dGVShops, 1, 1);
            this.tlpShops.Controls.Add(this.flpShops, 2, 3);
            this.tlpShops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShops.Location = new System.Drawing.Point(0, 0);
            this.tlpShops.Name = "tlpShops";
            this.tlpShops.RowCount = 5;
            this.tlpShops.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpShops.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84F));
            this.tlpShops.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpShops.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpShops.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpShops.Size = new System.Drawing.Size(800, 450);
            this.tlpShops.TabIndex = 0;
            // 
            // dGVShops
            // 
            this.dGVShops.AllowUserToAddRows = false;
            this.dGVShops.AllowUserToDeleteRows = false;
            this.dGVShops.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVShops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVShops.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shop_name,
            this.shop_address});
            this.tlpShops.SetColumnSpan(this.dGVShops, 2);
            this.dGVShops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVShops.Location = new System.Drawing.Point(11, 12);
            this.dGVShops.Name = "dGVShops";
            this.dGVShops.Size = new System.Drawing.Size(778, 372);
            this.dGVShops.TabIndex = 0;
            // 
            // flpShops
            // 
            this.flpShops.Controls.Add(this.btnShopsDelete);
            this.flpShops.Controls.Add(this.btnShopsChange);
            this.flpShops.Controls.Add(this.btnShopsAdd);
            this.flpShops.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpShops.Location = new System.Drawing.Point(403, 399);
            this.flpShops.Name = "flpShops";
            this.flpShops.Size = new System.Drawing.Size(385, 39);
            this.flpShops.TabIndex = 1;
            // 
            // btnShopsDelete
            // 
            this.btnShopsDelete.Location = new System.Drawing.Point(292, 3);
            this.btnShopsDelete.Name = "btnShopsDelete";
            this.btnShopsDelete.Size = new System.Drawing.Size(90, 35);
            this.btnShopsDelete.TabIndex = 0;
            this.btnShopsDelete.Text = "Удалить";
            this.btnShopsDelete.UseVisualStyleBackColor = true;
            // 
            // btnShopsChange
            // 
            this.btnShopsChange.Location = new System.Drawing.Point(196, 3);
            this.btnShopsChange.Name = "btnShopsChange";
            this.btnShopsChange.Size = new System.Drawing.Size(90, 35);
            this.btnShopsChange.TabIndex = 1;
            this.btnShopsChange.Text = "Изменить";
            this.btnShopsChange.UseVisualStyleBackColor = true;
            this.btnShopsChange.Click += new System.EventHandler(this.btnShopsChange_Click);
            // 
            // btnShopsAdd
            // 
            this.btnShopsAdd.Location = new System.Drawing.Point(100, 3);
            this.btnShopsAdd.Name = "btnShopsAdd";
            this.btnShopsAdd.Size = new System.Drawing.Size(90, 35);
            this.btnShopsAdd.TabIndex = 2;
            this.btnShopsAdd.Text = "Добавить";
            this.btnShopsAdd.UseVisualStyleBackColor = true;
            this.btnShopsAdd.Click += new System.EventHandler(this.btnShopsAdd_Click);
            // 
            // shop_name
            // 
            this.shop_name.HeaderText = "Название";
            this.shop_name.Name = "shop_name";
            this.shop_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // shop_address
            // 
            this.shop_address.HeaderText = "Адрес";
            this.shop_address.Name = "shop_address";
            // 
            // ShopsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpShops);
            this.Name = "ShopsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Магазины";
            this.tlpShops.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVShops)).EndInit();
            this.flpShops.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpShops;
        private System.Windows.Forms.DataGridView dGVShops;
        private System.Windows.Forms.FlowLayoutPanel flpShops;
        private System.Windows.Forms.Button btnShopsDelete;
        private System.Windows.Forms.Button btnShopsChange;
        private System.Windows.Forms.Button btnShopsAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn shop_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn shop_address;
    }
}
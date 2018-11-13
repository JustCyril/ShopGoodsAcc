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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shop_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shop_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpShops = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShopsDelete = new System.Windows.Forms.Button();
            this.btnShopsChange = new System.Windows.Forms.Button();
            this.btnShopsAdd = new System.Windows.Forms.Button();
            this.tlpShops.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVShops)).BeginInit();
            this.flpShops.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpShops
            // 
            this.tlpShops.ColumnCount = 4;
            this.tlpShops.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpShops.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpShops.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpShops.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpShops.Controls.Add(this.dGVShops, 1, 1);
            this.tlpShops.Controls.Add(this.flpShops, 2, 3);
            this.tlpShops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShops.Location = new System.Drawing.Point(0, 0);
            this.tlpShops.Name = "tlpShops";
            this.tlpShops.RowCount = 5;
            this.tlpShops.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpShops.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShops.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpShops.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpShops.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpShops.Size = new System.Drawing.Size(800, 461);
            this.tlpShops.TabIndex = 0;
            // 
            // dGVShops
            // 
            this.dGVShops.AllowUserToAddRows = false;
            this.dGVShops.AllowUserToDeleteRows = false;
            this.dGVShops.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVShops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVShops.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.shop_name,
            this.shop_address});
            this.tlpShops.SetColumnSpan(this.dGVShops, 2);
            this.dGVShops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVShops.Location = new System.Drawing.Point(8, 8);
            this.dGVShops.MultiSelect = false;
            this.dGVShops.Name = "dGVShops";
            this.dGVShops.ReadOnly = true;
            this.dGVShops.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVShops.Size = new System.Drawing.Size(784, 395);
            this.dGVShops.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.FillWeight = 22.84264F;
            this.ID.HeaderText = "№";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // shop_name
            // 
            this.shop_name.FillWeight = 138.5787F;
            this.shop_name.HeaderText = "Название";
            this.shop_name.Name = "shop_name";
            this.shop_name.ReadOnly = true;
            this.shop_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // shop_address
            // 
            this.shop_address.FillWeight = 138.5787F;
            this.shop_address.HeaderText = "Адрес";
            this.shop_address.Name = "shop_address";
            this.shop_address.ReadOnly = true;
            // 
            // flpShops
            // 
            this.flpShops.Controls.Add(this.btnShopsDelete);
            this.flpShops.Controls.Add(this.btnShopsChange);
            this.flpShops.Controls.Add(this.btnShopsAdd);
            this.flpShops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpShops.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpShops.Location = new System.Drawing.Point(403, 414);
            this.flpShops.Name = "flpShops";
            this.flpShops.Size = new System.Drawing.Size(389, 39);
            this.flpShops.TabIndex = 1;
            // 
            // btnShopsDelete
            // 
            this.btnShopsDelete.Location = new System.Drawing.Point(296, 3);
            this.btnShopsDelete.Name = "btnShopsDelete";
            this.btnShopsDelete.Size = new System.Drawing.Size(90, 35);
            this.btnShopsDelete.TabIndex = 0;
            this.btnShopsDelete.Text = "Удалить";
            this.btnShopsDelete.UseVisualStyleBackColor = true;
            // 
            // btnShopsChange
            // 
            this.btnShopsChange.Location = new System.Drawing.Point(200, 3);
            this.btnShopsChange.Name = "btnShopsChange";
            this.btnShopsChange.Size = new System.Drawing.Size(90, 35);
            this.btnShopsChange.TabIndex = 1;
            this.btnShopsChange.Text = "Изменить";
            this.btnShopsChange.UseVisualStyleBackColor = true;
            this.btnShopsChange.Click += new System.EventHandler(this.btnShopsChange_Click);
            // 
            // btnShopsAdd
            // 
            this.btnShopsAdd.Location = new System.Drawing.Point(104, 3);
            this.btnShopsAdd.Name = "btnShopsAdd";
            this.btnShopsAdd.Size = new System.Drawing.Size(90, 35);
            this.btnShopsAdd.TabIndex = 2;
            this.btnShopsAdd.Text = "Добавить";
            this.btnShopsAdd.UseVisualStyleBackColor = true;
            this.btnShopsAdd.Click += new System.EventHandler(this.btnShopsAdd_Click);
            // 
            // ShopsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.tlpShops);
            this.MinimumSize = new System.Drawing.Size(800, 500);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn shop_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn shop_address;
    }
}
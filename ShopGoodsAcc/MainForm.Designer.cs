namespace ShopGoodsAcc
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.dGVProducts = new System.Windows.Forms.DataGridView();
            this.ProdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flMainForBtns = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMainDelete = new System.Windows.Forms.Button();
            this.btnMainChange = new System.Windows.Forms.Button();
            this.btnMainAdd = new System.Windows.Forms.Button();
            this.btnMainRefresh = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMainShops = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProducts)).BeginInit();
            this.flMainForBtns.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpMain.Controls.Add(this.dGVProducts, 1, 1);
            this.tlpMain.Controls.Add(this.flMainForBtns, 2, 3);
            this.tlpMain.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpMain.Size = new System.Drawing.Size(900, 469);
            this.tlpMain.TabIndex = 0;
            // 
            // dGVProducts
            // 
            this.dGVProducts.AllowUserToAddRows = false;
            this.dGVProducts.AllowUserToDeleteRows = false;
            this.dGVProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProdName,
            this.Description,
            this.Amount,
            this.Shop});
            this.tlpMain.SetColumnSpan(this.dGVProducts, 2);
            this.dGVProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVProducts.Location = new System.Drawing.Point(12, 12);
            this.dGVProducts.Name = "dGVProducts";
            this.dGVProducts.ReadOnly = true;
            this.dGVProducts.Size = new System.Drawing.Size(876, 387);
            this.dGVProducts.TabIndex = 2;
            // 
            // ProdName
            // 
            this.ProdName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProdName.HeaderText = "Название";
            this.ProdName.Name = "ProdName";
            this.ProdName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Описание";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.HeaderText = "Кол-во";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Shop
            // 
            this.Shop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Shop.HeaderText = "Магазин";
            this.Shop.Name = "Shop";
            this.Shop.ReadOnly = true;
            // 
            // flMainForBtns
            // 
            this.flMainForBtns.Controls.Add(this.btnMainDelete);
            this.flMainForBtns.Controls.Add(this.btnMainChange);
            this.flMainForBtns.Controls.Add(this.btnMainAdd);
            this.flMainForBtns.Controls.Add(this.btnMainRefresh);
            this.flMainForBtns.Dock = System.Windows.Forms.DockStyle.Right;
            this.flMainForBtns.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flMainForBtns.Location = new System.Drawing.Point(503, 414);
            this.flMainForBtns.Name = "flMainForBtns";
            this.flMainForBtns.Size = new System.Drawing.Size(385, 40);
            this.flMainForBtns.TabIndex = 1;
            // 
            // btnMainDelete
            // 
            this.btnMainDelete.Location = new System.Drawing.Point(292, 3);
            this.btnMainDelete.Name = "btnMainDelete";
            this.btnMainDelete.Size = new System.Drawing.Size(90, 35);
            this.btnMainDelete.TabIndex = 2;
            this.btnMainDelete.Text = "Удалить";
            this.btnMainDelete.UseVisualStyleBackColor = true;
            // 
            // btnMainChange
            // 
            this.btnMainChange.Location = new System.Drawing.Point(196, 3);
            this.btnMainChange.Name = "btnMainChange";
            this.btnMainChange.Size = new System.Drawing.Size(90, 35);
            this.btnMainChange.TabIndex = 1;
            this.btnMainChange.Text = "Изменить";
            this.btnMainChange.UseVisualStyleBackColor = true;
            this.btnMainChange.Click += new System.EventHandler(this.btnMainChange_Click);
            // 
            // btnMainAdd
            // 
            this.btnMainAdd.Location = new System.Drawing.Point(100, 3);
            this.btnMainAdd.Name = "btnMainAdd";
            this.btnMainAdd.Size = new System.Drawing.Size(90, 35);
            this.btnMainAdd.TabIndex = 0;
            this.btnMainAdd.Text = "Добавить";
            this.btnMainAdd.UseVisualStyleBackColor = true;
            this.btnMainAdd.Click += new System.EventHandler(this.btnMainAdd_Click);
            // 
            // btnMainRefresh
            // 
            this.btnMainRefresh.Location = new System.Drawing.Point(4, 3);
            this.btnMainRefresh.Name = "btnMainRefresh";
            this.btnMainRefresh.Size = new System.Drawing.Size(90, 35);
            this.btnMainRefresh.TabIndex = 3;
            this.btnMainRefresh.Text = "Обновить";
            this.btnMainRefresh.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMainShops);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 414);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 40);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnMainShops
            // 
            this.btnMainShops.Location = new System.Drawing.Point(3, 3);
            this.btnMainShops.Name = "btnMainShops";
            this.btnMainShops.Size = new System.Drawing.Size(90, 35);
            this.btnMainShops.TabIndex = 4;
            this.btnMainShops.Text = "Магазины";
            this.btnMainShops.UseVisualStyleBackColor = true;
            this.btnMainShops.Click += new System.EventHandler(this.btnMainShops_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 469);
            this.Controls.Add(this.tlpMain);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Все товары";
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVProducts)).EndInit();
            this.flMainForBtns.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.FlowLayoutPanel flMainForBtns;
        private System.Windows.Forms.Button btnMainDelete;
        private System.Windows.Forms.Button btnMainChange;
        private System.Windows.Forms.Button btnMainAdd;
        private System.Windows.Forms.DataGridView dGVProducts;
        private System.Windows.Forms.Button btnMainRefresh;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMainShops;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shop;
    }
}


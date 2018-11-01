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
            this.lbMain = new System.Windows.Forms.ListBox();
            this.flMainForBtns = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMainDelete = new System.Windows.Forms.Button();
            this.btnMainChange = new System.Windows.Forms.Button();
            this.btnMainAdd = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.flMainForBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMain.Controls.Add(this.lbMain, 1, 1);
            this.tlpMain.Controls.Add(this.flMainForBtns, 1, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.Size = new System.Drawing.Size(900, 469);
            this.tlpMain.TabIndex = 0;
            // 
            // lbMain
            // 
            this.lbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMain.FormattingEnabled = true;
            this.lbMain.Items.AddRange(new object[] {
            "Товар1",
            "Товар2",
            "Товар3"});
            this.lbMain.Location = new System.Drawing.Point(48, 49);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(804, 322);
            this.lbMain.TabIndex = 0;
            // 
            // flMainForBtns
            // 
            this.flMainForBtns.Controls.Add(this.btnMainDelete);
            this.flMainForBtns.Controls.Add(this.btnMainChange);
            this.flMainForBtns.Controls.Add(this.btnMainAdd);
            this.flMainForBtns.Dock = System.Windows.Forms.DockStyle.Right;
            this.flMainForBtns.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flMainForBtns.Location = new System.Drawing.Point(434, 377);
            this.flMainForBtns.Name = "flMainForBtns";
            this.flMainForBtns.Size = new System.Drawing.Size(418, 89);
            this.flMainForBtns.TabIndex = 1;
            // 
            // btnMainDelete
            // 
            this.btnMainDelete.Location = new System.Drawing.Point(325, 3);
            this.btnMainDelete.Name = "btnMainDelete";
            this.btnMainDelete.Size = new System.Drawing.Size(90, 35);
            this.btnMainDelete.TabIndex = 2;
            this.btnMainDelete.Text = "Удалить";
            this.btnMainDelete.UseVisualStyleBackColor = true;
            // 
            // btnMainChange
            // 
            this.btnMainChange.Location = new System.Drawing.Point(229, 3);
            this.btnMainChange.Name = "btnMainChange";
            this.btnMainChange.Size = new System.Drawing.Size(90, 35);
            this.btnMainChange.TabIndex = 1;
            this.btnMainChange.Text = "Изменить";
            this.btnMainChange.UseVisualStyleBackColor = true;
            this.btnMainChange.Click += new System.EventHandler(this.btnMainChange_Click);
            // 
            // btnMainAdd
            // 
            this.btnMainAdd.Location = new System.Drawing.Point(133, 3);
            this.btnMainAdd.Name = "btnMainAdd";
            this.btnMainAdd.Size = new System.Drawing.Size(90, 35);
            this.btnMainAdd.TabIndex = 0;
            this.btnMainAdd.Text = "Добавить";
            this.btnMainAdd.UseVisualStyleBackColor = true;
            this.btnMainAdd.Click += new System.EventHandler(this.btnMainAdd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 469);
            this.Controls.Add(this.tlpMain);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Все товары";
            this.tlpMain.ResumeLayout(false);
            this.flMainForBtns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.ListBox lbMain;
        private System.Windows.Forms.FlowLayoutPanel flMainForBtns;
        private System.Windows.Forms.Button btnMainDelete;
        private System.Windows.Forms.Button btnMainChange;
        private System.Windows.Forms.Button btnMainAdd;
    }
}


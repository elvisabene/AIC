
namespace AppInformer
{
    partial class MenuForm
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
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.ListApp = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chooseOptionComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExecuteButton.Location = new System.Drawing.Point(6, 56);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(200, 55);
            this.ExecuteButton.TabIndex = 0;
            this.ExecuteButton.Text = "Получить список приложений";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // ListApp
            // 
            this.ListApp.BackColor = System.Drawing.Color.SkyBlue;
            this.ListApp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.VersionColumn});
            this.ListApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListApp.FullRowSelect = true;
            this.ListApp.GridLines = true;
            this.ListApp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListApp.HideSelection = false;
            this.ListApp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ListApp.Location = new System.Drawing.Point(255, 56);
            this.ListApp.Name = "ListApp";
            this.ListApp.Size = new System.Drawing.Size(1105, 685);
            this.ListApp.TabIndex = 1;
            this.ListApp.UseCompatibleStateImageBehavior = false;
            this.ListApp.View = System.Windows.Forms.View.Details;
            this.ListApp.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListApp_ColumnWidthChanging);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 482;
            // 
            // VersionColumn
            // 
            this.VersionColumn.Text = "Version";
            this.VersionColumn.Width = 462;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseOptionComboBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1382, 32);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chooseOptionComboBox
            // 
            this.chooseOptionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseOptionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.chooseOptionComboBox.Items.AddRange(new object[] {
            "Просмотр приложений",
            "Сравнить"});
            this.chooseOptionComboBox.Name = "chooseOptionComboBox";
            this.chooseOptionComboBox.Size = new System.Drawing.Size(200, 28);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.ListApp);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1400, 800);
            this.MinimumSize = new System.Drawing.Size(1400, 800);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.ListView ListApp;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox chooseOptionComboBox;
        private System.Windows.Forms.ColumnHeader VersionColumn;
    }
}


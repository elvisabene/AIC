
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
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.compNamesComboBox = new System.Windows.Forms.ComboBox();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExecuteButton.Location = new System.Drawing.Point(3, 3);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(226, 70);
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
            this.ListApp.Size = new System.Drawing.Size(1115, 685);
            this.ListApp.TabIndex = 1;
            this.ListApp.UseCompatibleStateImageBehavior = false;
            this.ListApp.View = System.Windows.Forms.View.Details;
            this.ListApp.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListApp_ColumnWidthChanging);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Название приложения";
            this.NameColumn.Width = 482;
            // 
            // VersionColumn
            // 
            this.VersionColumn.Text = "Версия приложения";
            this.VersionColumn.Width = 401;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.Color.Blue;
            this.buttonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.buttonsPanel.Controls.Add(this.ExecuteButton);
            this.buttonsPanel.Location = new System.Drawing.Point(13, 56);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(236, 685);
            this.buttonsPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Sitka Text", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выбрать компьютер:";
            // 
            // compNamesComboBox
            // 
            this.compNamesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compNamesComboBox.Font = new System.Drawing.Font("Sitka Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.compNamesComboBox.FormattingEnabled = true;
            this.compNamesComboBox.Location = new System.Drawing.Point(264, 6);
            this.compNamesComboBox.Name = "compNamesComboBox";
            this.compNamesComboBox.Size = new System.Drawing.Size(484, 32);
            this.compNamesComboBox.TabIndex = 4;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.compNamesComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.ListApp);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1400, 800);
            this.MinimumSize = new System.Drawing.Size(1400, 800);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.ListView ListApp;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader VersionColumn;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox compNamesComboBox;
    }
}


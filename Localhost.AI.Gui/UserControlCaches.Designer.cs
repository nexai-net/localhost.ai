namespace Localhost.AI.Gui
{
    partial class UserControlCaches
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EntitiesSearchButton = new Button();
            addButton = new Button();
            searchTextBox = new TextBox();
            dataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // EntitiesSearchButton
            // 
            EntitiesSearchButton.Location = new Point(1068, 11);
            EntitiesSearchButton.Name = "EntitiesSearchButton";
            EntitiesSearchButton.Size = new Size(75, 23);
            EntitiesSearchButton.TabIndex = 7;
            EntitiesSearchButton.Text = "Search";
            EntitiesSearchButton.UseVisualStyleBackColor = true;
            EntitiesSearchButton.Click += EntitiesSearchButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(1149, 10);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 6;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(28, 11);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(1034, 23);
            searchTextBox.TabIndex = 5;
            // 
            // dataGrid
            // 
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.BorderStyle = BorderStyle.None;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.GridColor = SystemColors.Window;
            dataGrid.Location = new Point(26, 48);
            dataGrid.Name = "dataGrid";
            dataGrid.ReadOnly = true;
            dataGrid.Size = new Size(1852, 659);
            dataGrid.TabIndex = 8;
            dataGrid.CellDoubleClick += dataGrid_CellDoubleClick;
            // 
            // UserControlCaches
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGrid);
            Controls.Add(EntitiesSearchButton);
            Controls.Add(addButton);
            Controls.Add(searchTextBox);
            Name = "UserControlCaches";
            Size = new Size(1904, 732);
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EntitiesSearchButton;
        private Button addButton;
        private TextBox searchTextBox;
        private DataGridView dataGrid;
    }
}

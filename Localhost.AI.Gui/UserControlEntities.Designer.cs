namespace Localhost.AI.Gui
{
    partial class UserControlEntities
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
            label1 = new Label();
            searchTextBox = new TextBox();
            dataGrid = new DataGridView();
            addButton = new Button();
            EntitiesSearchButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 0;
            label1.Text = "Entities management";
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(22, 28);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(1034, 23);
            searchTextBox.TabIndex = 1;
            // 
            // dataGrid
            // 
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.BorderStyle = BorderStyle.None;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.GridColor = SystemColors.Window;
            dataGrid.Location = new Point(22, 56);
            dataGrid.Name = "dataGrid";
            dataGrid.ReadOnly = true;
            dataGrid.Size = new Size(1852, 659);
            dataGrid.TabIndex = 2;
            dataGrid.CellDoubleClick += dataGrid_CellDoubleClick;
            // 
            // addButton
            // 
            addButton.Location = new Point(1143, 27);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 3;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += button1_Click;
            // 
            // EntitiesSearchButton
            // 
            EntitiesSearchButton.Location = new Point(1062, 28);
            EntitiesSearchButton.Name = "EntitiesSearchButton";
            EntitiesSearchButton.Size = new Size(75, 23);
            EntitiesSearchButton.TabIndex = 4;
            EntitiesSearchButton.Text = "Search";
            EntitiesSearchButton.UseVisualStyleBackColor = true;
            EntitiesSearchButton.Click += EntitiesSearchButton_Click;
            // 
            // UserControlEntities
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BackgroundPanelMain;
            Controls.Add(EntitiesSearchButton);
            Controls.Add(addButton);
            Controls.Add(dataGrid);
            Controls.Add(searchTextBox);
            Controls.Add(label1);
            MaximumSize = new Size(1904, 732);
            MinimumSize = new Size(1904, 732);
            Name = "UserControlEntities";
            Size = new Size(1904, 732);
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox searchTextBox;
        private DataGridView dataGrid;
        private Button addButton;
        private Button EntitiesSearchButton;
    }
}

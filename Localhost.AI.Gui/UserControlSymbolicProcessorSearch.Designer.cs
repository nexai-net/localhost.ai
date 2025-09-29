namespace Localhost.AI.Gui
{
    partial class UserControlSymbolicProcessorSearch
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
            dataGrid = new DataGridView();
            TextBoxSearch = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // EntitiesSearchButton
            // 
            EntitiesSearchButton.Location = new Point(1066, 23);
            EntitiesSearchButton.Name = "EntitiesSearchButton";
            EntitiesSearchButton.Size = new Size(75, 23);
            EntitiesSearchButton.TabIndex = 8;
            EntitiesSearchButton.Text = "Search";
            EntitiesSearchButton.UseVisualStyleBackColor = true;
            EntitiesSearchButton.Click += EntitiesSearchButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(1147, 22);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 7;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // dataGrid
            // 
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.BorderStyle = BorderStyle.None;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.GridColor = SystemColors.Window;
            dataGrid.Location = new Point(26, 51);
            dataGrid.Name = "dataGrid";
            dataGrid.Size = new Size(1852, 659);
            dataGrid.TabIndex = 6;
            dataGrid.CellDoubleClick += dataGrid_CellDoubleClick;
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Location = new Point(26, 23);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(1034, 23);
            TextBoxSearch.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 1);
            label1.Name = "label1";
            label1.Size = new Size(148, 15);
            label1.TabIndex = 9;
            label1.Text = "Symbolic Processor Search";
            // 
            // UserControlSymbolicProcessorSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(EntitiesSearchButton);
            Controls.Add(addButton);
            Controls.Add(dataGrid);
            Controls.Add(TextBoxSearch);
            MaximumSize = new Size(1904, 732);
            MinimumSize = new Size(1904, 732);
            Name = "UserControlSymbolicProcessorSearch";
            Size = new Size(1904, 732);
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EntitiesSearchButton;
        private Button addButton;
        private DataGridView dataGrid;
        private TextBox TextBoxSearch;
        private Label label1;
    }
}

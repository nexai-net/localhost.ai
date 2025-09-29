namespace Localhost.AI.Gui
{
    partial class UserControlSymbolicProcessor
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
            groupBox1 = new GroupBox();
            textBoxShould = new TextBox();
            groupBox2 = new GroupBox();
            textBoxMust = new TextBox();
            groupBox3 = new GroupBox();
            textBoxMustNot = new TextBox();
            groupBox4 = new GroupBox();
            textBoxShouldNot = new TextBox();
            checkBoxDialog = new CheckBox();
            checkBoxSearch = new CheckBox();
            checkBoxFeedback = new CheckBox();
            checkBoxDreamer = new CheckBox();
            groupBox6 = new GroupBox();
            textBoxReflex = new TextBox();
            groupBox7 = new GroupBox();
            textBoxThinking = new TextBox();
            groupBox8 = new GroupBox();
            textBoxQuestions = new TextBox();
            groupBox9 = new GroupBox();
            textBoxExpectations = new TextBox();
            buttonSave = new Button();
            button1 = new Button();
            textBoxName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox9.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 13);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Symbolic Processor";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxShould);
            groupBox1.Location = new Point(48, 146);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(352, 200);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Should";
            // 
            // textBoxShould
            // 
            textBoxShould.Location = new Point(16, 31);
            textBoxShould.Multiline = true;
            textBoxShould.Name = "textBoxShould";
            textBoxShould.Size = new Size(319, 149);
            textBoxShould.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxMust);
            groupBox2.Location = new Point(415, 146);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(352, 200);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Must";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // textBoxMust
            // 
            textBoxMust.Location = new Point(22, 31);
            textBoxMust.Multiline = true;
            textBoxMust.Name = "textBoxMust";
            textBoxMust.Size = new Size(319, 149);
            textBoxMust.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxMustNot);
            groupBox3.Location = new Point(787, 146);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(352, 200);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Must not";
            // 
            // textBoxMustNot
            // 
            textBoxMustNot.Location = new Point(17, 31);
            textBoxMustNot.Multiline = true;
            textBoxMustNot.Name = "textBoxMustNot";
            textBoxMustNot.Size = new Size(319, 149);
            textBoxMustNot.TabIndex = 1;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBoxShouldNot);
            groupBox4.Location = new Point(1158, 146);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(352, 200);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Should not";
            // 
            // textBoxShouldNot
            // 
            textBoxShouldNot.Location = new Point(16, 31);
            textBoxShouldNot.Multiline = true;
            textBoxShouldNot.Name = "textBoxShouldNot";
            textBoxShouldNot.Size = new Size(319, 149);
            textBoxShouldNot.TabIndex = 2;
            // 
            // checkBoxDialog
            // 
            checkBoxDialog.AutoSize = true;
            checkBoxDialog.Location = new Point(605, 384);
            checkBoxDialog.Name = "checkBoxDialog";
            checkBoxDialog.Size = new Size(60, 19);
            checkBoxDialog.TabIndex = 5;
            checkBoxDialog.Text = "Dialog";
            checkBoxDialog.UseVisualStyleBackColor = true;
            checkBoxDialog.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBoxSearch
            // 
            checkBoxSearch.AutoSize = true;
            checkBoxSearch.Location = new Point(695, 384);
            checkBoxSearch.Name = "checkBoxSearch";
            checkBoxSearch.Size = new Size(61, 19);
            checkBoxSearch.TabIndex = 6;
            checkBoxSearch.Text = "Search";
            checkBoxSearch.UseVisualStyleBackColor = true;
            // 
            // checkBoxFeedback
            // 
            checkBoxFeedback.AutoSize = true;
            checkBoxFeedback.Location = new Point(787, 384);
            checkBoxFeedback.Name = "checkBoxFeedback";
            checkBoxFeedback.Size = new Size(76, 19);
            checkBoxFeedback.TabIndex = 7;
            checkBoxFeedback.Text = "Feedback";
            checkBoxFeedback.UseVisualStyleBackColor = true;
            // 
            // checkBoxDreamer
            // 
            checkBoxDreamer.AutoSize = true;
            checkBoxDreamer.Location = new Point(892, 384);
            checkBoxDreamer.Name = "checkBoxDreamer";
            checkBoxDreamer.Size = new Size(71, 19);
            checkBoxDreamer.TabIndex = 8;
            checkBoxDreamer.Text = "Dreamer";
            checkBoxDreamer.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(textBoxReflex);
            groupBox6.Location = new Point(48, 432);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(352, 200);
            groupBox6.TabIndex = 9;
            groupBox6.TabStop = false;
            groupBox6.Text = "Reflex";
            // 
            // textBoxReflex
            // 
            textBoxReflex.Location = new Point(16, 35);
            textBoxReflex.Multiline = true;
            textBoxReflex.Name = "textBoxReflex";
            textBoxReflex.Size = new Size(319, 149);
            textBoxReflex.TabIndex = 1;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(textBoxThinking);
            groupBox7.Location = new Point(415, 432);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(352, 200);
            groupBox7.TabIndex = 10;
            groupBox7.TabStop = false;
            groupBox7.Text = "Thinking";
            // 
            // textBoxThinking
            // 
            textBoxThinking.Location = new Point(22, 35);
            textBoxThinking.Multiline = true;
            textBoxThinking.Name = "textBoxThinking";
            textBoxThinking.Size = new Size(319, 149);
            textBoxThinking.TabIndex = 2;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(textBoxQuestions);
            groupBox8.Location = new Point(785, 432);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(352, 200);
            groupBox8.TabIndex = 11;
            groupBox8.TabStop = false;
            groupBox8.Text = "Questions";
            // 
            // textBoxQuestions
            // 
            textBoxQuestions.Location = new Point(19, 35);
            textBoxQuestions.Multiline = true;
            textBoxQuestions.Name = "textBoxQuestions";
            textBoxQuestions.Size = new Size(319, 149);
            textBoxQuestions.TabIndex = 3;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(textBoxExpectations);
            groupBox9.Location = new Point(1158, 432);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(352, 200);
            groupBox9.TabIndex = 12;
            groupBox9.TabStop = false;
            groupBox9.Text = "Expectations";
            // 
            // textBoxExpectations
            // 
            textBoxExpectations.Location = new Point(16, 35);
            textBoxExpectations.Multiline = true;
            textBoxExpectations.Name = "textBoxExpectations";
            textBoxExpectations.Size = new Size(319, 149);
            textBoxExpectations.TabIndex = 4;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(1158, 651);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(352, 64);
            buttonSave.TabIndex = 13;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // button1
            // 
            button1.Location = new Point(785, 651);
            button1.Name = "button1";
            button1.Size = new Size(352, 64);
            button1.TabIndex = 14;
            button1.Text = "Create a variant";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxName.Location = new Point(490, 67);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(588, 29);
            textBoxName.TabIndex = 0;
            textBoxName.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(764, 37);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 15;
            label2.Text = "Name (optionnal)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1085, 75);
            label3.Name = "label3";
            label3.Size = new Size(16, 15);
            label3.TabIndex = 16;
            label3.Text = "...";
            // 
            // UserControlSymbolicProcessor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxName);
            Controls.Add(button1);
            Controls.Add(buttonSave);
            Controls.Add(groupBox9);
            Controls.Add(groupBox8);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(checkBoxDreamer);
            Controls.Add(checkBoxFeedback);
            Controls.Add(checkBoxSearch);
            Controls.Add(checkBoxDialog);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "UserControlSymbolicProcessor";
            Size = new Size(1904, 732);
            Load += UserControlSymbolicProcessor_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private CheckBox checkBoxDialog;
        private CheckBox checkBoxSearch;
        private CheckBox checkBoxFeedback;
        private CheckBox checkBoxDreamer;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private GroupBox groupBox8;
        private GroupBox groupBox9;
        private Button buttonSave;
        private Button button1;
        private TextBox textBoxName;
        private Label label2;
        private TextBox textBoxShould;
        private TextBox textBoxMust;
        private TextBox textBoxMustNot;
        private TextBox textBoxShouldNot;
        private TextBox textBoxReflex;
        private TextBox textBoxThinking;
        private TextBox textBoxQuestions;
        private TextBox textBoxExpectations;
        private Label label3;
    }
}

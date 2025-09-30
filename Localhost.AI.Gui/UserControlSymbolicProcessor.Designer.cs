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
            buttonSave = new Button();
            textBoxComment = new TextBox();
            label2 = new Label();
            label3 = new Label();
            comboBoxMode = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            textBoxGeneratedTags = new TextBox();
            label6 = new Label();
            textBoxGeneratedPromptSystem = new TextBox();
            label7 = new Label();
            textBoxGeneratedSentence = new TextBox();
            label8 = new Label();
            textBoxRegexPatterns = new TextBox();
            labelName = new Label();
            textBoxProcessorName = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
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
            groupBox1.Location = new Point(47, 368);
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
            groupBox2.Location = new Point(414, 368);
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
            groupBox3.Location = new Point(786, 368);
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
            groupBox4.Location = new Point(1157, 368);
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
            checkBoxDialog.Location = new Point(93, 151);
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
            checkBoxSearch.Location = new Point(183, 151);
            checkBoxSearch.Name = "checkBoxSearch";
            checkBoxSearch.Size = new Size(61, 19);
            checkBoxSearch.TabIndex = 6;
            checkBoxSearch.Text = "Search";
            checkBoxSearch.UseVisualStyleBackColor = true;
            // 
            // checkBoxFeedback
            // 
            checkBoxFeedback.AutoSize = true;
            checkBoxFeedback.Location = new Point(275, 151);
            checkBoxFeedback.Name = "checkBoxFeedback";
            checkBoxFeedback.Size = new Size(76, 19);
            checkBoxFeedback.TabIndex = 7;
            checkBoxFeedback.Text = "Feedback";
            checkBoxFeedback.UseVisualStyleBackColor = true;
            // 
            // checkBoxDreamer
            // 
            checkBoxDreamer.AutoSize = true;
            checkBoxDreamer.Location = new Point(380, 151);
            checkBoxDreamer.Name = "checkBoxDreamer";
            checkBoxDreamer.Size = new Size(71, 19);
            checkBoxDreamer.TabIndex = 8;
            checkBoxDreamer.Text = "Dreamer";
            checkBoxDreamer.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(1158, 689);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(352, 26);
            buttonSave.TabIndex = 13;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // textBoxComment
            // 
            textBoxComment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxComment.Location = new Point(308, 108);
            textBoxComment.Name = "textBoxComment";
            textBoxComment.Size = new Size(1186, 29);
            textBoxComment.TabIndex = 0;
            textBoxComment.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(241, 116);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 15;
            label2.Text = "Comment";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 676);
            label3.Name = "label3";
            label3.Size = new Size(16, 15);
            label3.TabIndex = 16;
            label3.Text = "...";
            // 
            // comboBoxMode
            // 
            comboBoxMode.FormattingEnabled = true;
            comboBoxMode.Items.AddRange(new object[] { "In", "Out", "Intra" });
            comboBoxMode.Location = new Point(93, 113);
            comboBoxMode.Name = "comboBoxMode";
            comboBoxMode.Size = new Size(121, 23);
            comboBoxMode.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 116);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 18;
            label4.Text = "Mode";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(294, 584);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 19;
            label5.Text = "Generated tags";
            // 
            // textBoxGeneratedTags
            // 
            textBoxGeneratedTags.Location = new Point(294, 602);
            textBoxGeneratedTags.Multiline = true;
            textBoxGeneratedTags.Name = "textBoxGeneratedTags";
            textBoxGeneratedTags.Size = new Size(319, 23);
            textBoxGeneratedTags.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(635, 605);
            label6.Name = "label6";
            label6.Size = new Size(145, 15);
            label6.TabIndex = 21;
            label6.Text = "Generated Prompt System";
            // 
            // textBoxGeneratedPromptSystem
            // 
            textBoxGeneratedPromptSystem.Location = new Point(786, 602);
            textBoxGeneratedPromptSystem.Name = "textBoxGeneratedPromptSystem";
            textBoxGeneratedPromptSystem.Size = new Size(720, 23);
            textBoxGeneratedPromptSystem.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(668, 634);
            label7.Name = "label7";
            label7.Size = new Size(112, 15);
            label7.TabIndex = 23;
            label7.Text = "Generated Sentence";
            label7.Click += label7_Click;
            // 
            // textBoxGeneratedSentence
            // 
            textBoxGeneratedSentence.Location = new Point(786, 631);
            textBoxGeneratedSentence.Name = "textBoxGeneratedSentence";
            textBoxGeneratedSentence.Size = new Size(720, 23);
            textBoxGeneratedSentence.TabIndex = 24;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(49, 203);
            label8.Name = "label8";
            label8.Size = new Size(86, 15);
            label8.TabIndex = 25;
            label8.Text = "Regex/Patterns";
            // 
            // textBoxRegexPatterns
            // 
            textBoxRegexPatterns.Location = new Point(141, 203);
            textBoxRegexPatterns.Multiline = true;
            textBoxRegexPatterns.Name = "textBoxRegexPatterns";
            textBoxRegexPatterns.Size = new Size(1351, 149);
            textBoxRegexPatterns.TabIndex = 26;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(57, 57);
            labelName.Name = "labelName";
            labelName.Size = new Size(34, 15);
            labelName.TabIndex = 27;
            labelName.Text = "Nom";
            // 
            // textBoxProcessorName
            // 
            textBoxProcessorName.Location = new Point(93, 54);
            textBoxProcessorName.Name = "textBoxProcessorName";
            textBoxProcessorName.Size = new Size(1399, 23);
            textBoxProcessorName.TabIndex = 28;
            // 
            // UserControlSymbolicProcessor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxProcessorName);
            Controls.Add(labelName);
            Controls.Add(textBoxRegexPatterns);
            Controls.Add(label8);
            Controls.Add(textBoxGeneratedSentence);
            Controls.Add(label7);
            Controls.Add(textBoxGeneratedPromptSystem);
            Controls.Add(label6);
            Controls.Add(textBoxGeneratedTags);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBoxMode);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxComment);
            Controls.Add(buttonSave);
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
            Size = new Size(1532, 732);
            Load += UserControlSymbolicProcessor_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private Button buttonSave;
        private TextBox textBoxComment;
        private Label label2;
        private TextBox textBoxShould;
        private TextBox textBoxMust;
        private TextBox textBoxMustNot;
        private TextBox textBoxShouldNot;
        private Label label3;
        private ComboBox comboBoxMode;
        private Label label4;
        private Label label5;
        private TextBox textBoxGeneratedTags;
        private Label label6;
        private TextBox textBoxGeneratedPromptSystem;
        private Label label7;
        private TextBox textBoxGeneratedSentence;
        private Label label8;
        private TextBox textBoxRegexPatterns;
        private Label labelName;
        private TextBox textBoxProcessorName;
    }
}

namespace Localhost.AI.Gui
{
    partial class CacheEditForm
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
            label1 = new Label();
            textBoxPrompt = new TextBox();
            textBoxCompletion = new TextBox();
            label2 = new Label();
            comboBoxLanguage = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            textBoxModelName = new TextBox();
            label5 = new Label();
            textBoxChatMode = new TextBox();
            label6 = new Label();
            textBoxParentId = new TextBox();
            textBoxTagsMust = new TextBox();
            label7 = new Label();
            label8 = new Label();
            textBoxShould = new TextBox();
            label9 = new Label();
            textBoxShouldNot = new TextBox();
            label10 = new Label();
            textBoxMustNot = new TextBox();
            panel1 = new Panel();
            label11 = new Label();
            panel2 = new Panel();
            label14 = new Label();
            textBoxGeneratedSystemPrompt = new TextBox();
            label13 = new Label();
            textBoxGeneratedTags = new TextBox();
            label12 = new Label();
            buttonCacheSaved = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 28);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Prompt";
            // 
            // textBoxPrompt
            // 
            textBoxPrompt.Location = new Point(24, 46);
            textBoxPrompt.Multiline = true;
            textBoxPrompt.Name = "textBoxPrompt";
            textBoxPrompt.Size = new Size(682, 175);
            textBoxPrompt.TabIndex = 1;
            textBoxPrompt.TextChanged += textBox1_TextChanged;
            // 
            // textBoxCompletion
            // 
            textBoxCompletion.Location = new Point(790, 46);
            textBoxCompletion.Multiline = true;
            textBoxCompletion.Name = "textBoxCompletion";
            textBoxCompletion.Size = new Size(701, 175);
            textBoxCompletion.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(790, 28);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 2;
            label2.Text = "Completion";
            // 
            // comboBoxLanguage
            // 
            comboBoxLanguage.FormattingEnabled = true;
            comboBoxLanguage.Items.AddRange(new object[] { "FR", "EN", "DE", "NL" });
            comboBoxLanguage.Location = new Point(94, 241);
            comboBoxLanguage.Name = "comboBoxLanguage";
            comboBoxLanguage.Size = new Size(56, 23);
            comboBoxLanguage.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 245);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 5;
            label3.Text = "Language";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(174, 245);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 6;
            label4.Text = "Model";
            // 
            // textBoxModelName
            // 
            textBoxModelName.Location = new Point(221, 241);
            textBoxModelName.Name = "textBoxModelName";
            textBoxModelName.Size = new Size(168, 23);
            textBoxModelName.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(408, 245);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 8;
            label5.Text = "Mode";
            // 
            // textBoxChatMode
            // 
            textBoxChatMode.Location = new Point(452, 241);
            textBoxChatMode.Name = "textBoxChatMode";
            textBoxChatMode.Size = new Size(100, 23);
            textBoxChatMode.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(790, 244);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 10;
            label6.Text = "Parent Id";
            // 
            // textBoxParentId
            // 
            textBoxParentId.Location = new Point(842, 241);
            textBoxParentId.Name = "textBoxParentId";
            textBoxParentId.Size = new Size(649, 23);
            textBoxParentId.TabIndex = 11;
            // 
            // textBoxTagsMust
            // 
            textBoxTagsMust.Location = new Point(19, 28);
            textBoxTagsMust.Multiline = true;
            textBoxTagsMust.Name = "textBoxTagsMust";
            textBoxTagsMust.Size = new Size(697, 65);
            textBoxTagsMust.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 10);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 13;
            label7.Text = "Must";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(750, 10);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 15;
            label8.Text = "Should";
            // 
            // textBoxShould
            // 
            textBoxShould.Location = new Point(750, 28);
            textBoxShould.Multiline = true;
            textBoxShould.Name = "textBoxShould";
            textBoxShould.Size = new Size(697, 65);
            textBoxShould.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(750, 104);
            label9.Name = "label9";
            label9.Size = new Size(65, 15);
            label9.TabIndex = 19;
            label9.Text = "Should not";
            // 
            // textBoxShouldNot
            // 
            textBoxShouldNot.Location = new Point(750, 122);
            textBoxShouldNot.Multiline = true;
            textBoxShouldNot.Name = "textBoxShouldNot";
            textBoxShouldNot.Size = new Size(697, 60);
            textBoxShouldNot.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(19, 104);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 17;
            label10.Text = "Must not";
            // 
            // textBoxMustNot
            // 
            textBoxMustNot.Location = new Point(19, 122);
            textBoxMustNot.Multiline = true;
            textBoxMustNot.Name = "textBoxMustNot";
            textBoxMustNot.Size = new Size(697, 60);
            textBoxMustNot.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxTagsMust);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBoxShouldNot);
            panel1.Controls.Add(textBoxMustNot);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(textBoxShould);
            panel1.Location = new Point(27, 292);
            panel1.Name = "panel1";
            panel1.Size = new Size(1464, 200);
            panel1.TabIndex = 20;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(726, 283);
            label11.Name = "label11";
            label11.Size = new Size(51, 15);
            label11.TabIndex = 21;
            label11.Text = "Receiver";
            // 
            // panel2
            // 
            panel2.Controls.Add(label14);
            panel2.Controls.Add(textBoxGeneratedSystemPrompt);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(textBoxGeneratedTags);
            panel2.Location = new Point(29, 515);
            panel2.Name = "panel2";
            panel2.Size = new Size(1462, 115);
            panel2.TabIndex = 22;
            panel2.Paint += panel2_Paint;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(748, 18);
            label14.Name = "label14";
            label14.Size = new Size(147, 15);
            label14.TabIndex = 22;
            label14.Text = "Generated prompt system ";
            // 
            // textBoxGeneratedSystemPrompt
            // 
            textBoxGeneratedSystemPrompt.Location = new Point(748, 36);
            textBoxGeneratedSystemPrompt.Multiline = true;
            textBoxGeneratedSystemPrompt.Name = "textBoxGeneratedSystemPrompt";
            textBoxGeneratedSystemPrompt.Size = new Size(697, 65);
            textBoxGeneratedSystemPrompt.TabIndex = 21;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(17, 18);
            label13.Name = "label13";
            label13.Size = new Size(86, 15);
            label13.TabIndex = 20;
            label13.Text = "Generated tags";
            // 
            // textBoxGeneratedTags
            // 
            textBoxGeneratedTags.Location = new Point(17, 36);
            textBoxGeneratedTags.Multiline = true;
            textBoxGeneratedTags.Name = "textBoxGeneratedTags";
            textBoxGeneratedTags.Size = new Size(697, 65);
            textBoxGeneratedTags.TabIndex = 13;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(726, 506);
            label12.Name = "label12";
            label12.Size = new Size(33, 15);
            label12.TabIndex = 23;
            label12.Text = "Send";
            // 
            // buttonCacheSaved
            // 
            buttonCacheSaved.Location = new Point(1215, 644);
            buttonCacheSaved.Name = "buttonCacheSaved";
            buttonCacheSaved.Size = new Size(276, 23);
            buttonCacheSaved.TabIndex = 24;
            buttonCacheSaved.Text = "Save";
            buttonCacheSaved.UseVisualStyleBackColor = true;
            buttonCacheSaved.Click += buttonCacheSaved_Click;
            // 
            // button1
            // 
            button1.Location = new Point(933, 644);
            button1.Name = "button1";
            button1.Size = new Size(276, 23);
            button1.TabIndex = 25;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CacheEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1503, 678);
            Controls.Add(button1);
            Controls.Add(buttonCacheSaved);
            Controls.Add(label12);
            Controls.Add(panel2);
            Controls.Add(label11);
            Controls.Add(panel1);
            Controls.Add(textBoxParentId);
            Controls.Add(label6);
            Controls.Add(textBoxChatMode);
            Controls.Add(label5);
            Controls.Add(textBoxModelName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBoxLanguage);
            Controls.Add(textBoxCompletion);
            Controls.Add(label2);
            Controls.Add(textBoxPrompt);
            Controls.Add(label1);
            Name = "CacheEditForm";
            Text = "CacheEditForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxPrompt;
        private TextBox textBoxCompletion;
        private Label label2;
        private ComboBox comboBoxLanguage;
        private Label label3;
        private Label label4;
        private TextBox textBoxModelName;
        private Label label5;
        private TextBox textBoxChatMode;
        private Label label6;
        private TextBox textBoxParentId;
        private TextBox textBoxTagsMust;
        private Label label7;
        private Label label8;
        private TextBox textBoxShould;
        private Label label9;
        private TextBox textBoxShouldNot;
        private Label label10;
        private TextBox textBoxMustNot;
        private Panel panel1;
        private Label label11;
        private Panel panel2;
        private Label label12;
        private Label label13;
        private TextBox textBoxGeneratedTags;
        private Label label14;
        private TextBox textBoxGeneratedSystemPrompt;
        private Button buttonCacheSaved;
        private Button button1;
    }
}
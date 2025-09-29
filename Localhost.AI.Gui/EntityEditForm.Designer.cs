namespace Localhost.AI.Gui
{
    partial class EntityEditForm
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
            lblEntityName = new Label();
            txtBoxEntityName = new TextBox();
            label2 = new Label();
            textBoxOtherNames = new TextBox();
            label1 = new Label();
            comboBoxEntityType = new ComboBox();
            label3 = new Label();
            textBoxShortDescription = new TextBox();
            label4 = new Label();
            textBoxFullDescription = new TextBox();
            label5 = new Label();
            textBoxRelatedEntities = new TextBox();
            trackBarJoy = new TrackBar();
            label6 = new Label();
            label7 = new Label();
            trackBarFear = new TrackBar();
            label8 = new Label();
            trackBarAnger = new TrackBar();
            label9 = new Label();
            trackBarSadness = new TrackBar();
            label10 = new Label();
            trackBarDisgust = new TrackBar();
            dateTimeFrom = new DateTimePicker();
            label11 = new Label();
            label12 = new Label();
            dateTimeTo = new DateTimePicker();
            label13 = new Label();
            textBoxHowTo = new TextBox();
            textBoxWithWhat = new TextBox();
            label14 = new Label();
            textBoxWithout = new TextBox();
            label15 = new Label();
            textBoxWhere = new TextBox();
            label16 = new Label();
            textBoxWhen = new TextBox();
            label17 = new Label();
            button1 = new Button();
            buttonDeleteEntity = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBarJoy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarFear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAnger).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSadness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarDisgust).BeginInit();
            SuspendLayout();
            // 
            // lblEntityName
            // 
            lblEntityName.AutoSize = true;
            lblEntityName.Location = new Point(22, 12);
            lblEntityName.Name = "lblEntityName";
            lblEntityName.Size = new Size(39, 15);
            lblEntityName.TabIndex = 0;
            lblEntityName.Text = "Name";
            // 
            // txtBoxEntityName
            // 
            txtBoxEntityName.Location = new Point(67, 9);
            txtBoxEntityName.Name = "txtBoxEntityName";
            txtBoxEntityName.Size = new Size(394, 23);
            txtBoxEntityName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(475, 12);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 2;
            label2.Text = "others names";
            // 
            // textBoxOtherNames
            // 
            textBoxOtherNames.Location = new Point(594, 9);
            textBoxOtherNames.Name = "textBoxOtherNames";
            textBoxOtherNames.Size = new Size(893, 23);
            textBoxOtherNames.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 52);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 4;
            label1.Text = "Type";
            // 
            // comboBoxEntityType
            // 
            comboBoxEntityType.FormattingEnabled = true;
            comboBoxEntityType.Items.AddRange(new object[] { "PERSON", "LOCATION", "ORGANIZATION", "DATE", "TIME", "COMPANY", "THEORY", "MONEY", "CURRENCY", "APPLICATION", "AGENT", "APP" });
            comboBoxEntityType.Location = new Point(67, 49);
            comboBoxEntityType.Name = "comboBoxEntityType";
            comboBoxEntityType.Size = new Size(394, 23);
            comboBoxEntityType.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(475, 52);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 6;
            label3.Text = "Short description";
            // 
            // textBoxShortDescription
            // 
            textBoxShortDescription.Location = new Point(594, 49);
            textBoxShortDescription.Name = "textBoxShortDescription";
            textBoxShortDescription.Size = new Size(893, 23);
            textBoxShortDescription.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 99);
            label4.Name = "label4";
            label4.Size = new Size(89, 15);
            label4.TabIndex = 8;
            label4.Text = "Full Description";
            // 
            // textBoxFullDescription
            // 
            textBoxFullDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxFullDescription.Location = new Point(29, 120);
            textBoxFullDescription.Multiline = true;
            textBoxFullDescription.Name = "textBoxFullDescription";
            textBoxFullDescription.Size = new Size(432, 507);
            textBoxFullDescription.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(475, 102);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 10;
            label5.Text = "Related Entities";
            // 
            // textBoxRelatedEntities
            // 
            textBoxRelatedEntities.Location = new Point(594, 94);
            textBoxRelatedEntities.Name = "textBoxRelatedEntities";
            textBoxRelatedEntities.Size = new Size(893, 23);
            textBoxRelatedEntities.TabIndex = 11;
            // 
            // trackBarJoy
            // 
            trackBarJoy.Cursor = Cursors.IBeam;
            trackBarJoy.LargeChange = 1;
            trackBarJoy.Location = new Point(547, 166);
            trackBarJoy.Name = "trackBarJoy";
            trackBarJoy.Size = new Size(288, 45);
            trackBarJoy.TabIndex = 100;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(679, 139);
            label6.Name = "label6";
            label6.Size = new Size(24, 15);
            label6.TabIndex = 13;
            label6.Text = "Joy";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(677, 223);
            label7.Name = "label7";
            label7.Size = new Size(29, 15);
            label7.TabIndex = 101;
            label7.Text = "Fear";
            // 
            // trackBarFear
            // 
            trackBarFear.Cursor = Cursors.IBeam;
            trackBarFear.LargeChange = 10;
            trackBarFear.Location = new Point(547, 250);
            trackBarFear.Maximum = 100;
            trackBarFear.Name = "trackBarFear";
            trackBarFear.Size = new Size(288, 45);
            trackBarFear.SmallChange = 10;
            trackBarFear.TabIndex = 102;
            trackBarFear.TickStyle = TickStyle.Both;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(672, 307);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 103;
            label8.Text = "Anger";
            // 
            // trackBarAnger
            // 
            trackBarAnger.Cursor = Cursors.IBeam;
            trackBarAnger.LargeChange = 1;
            trackBarAnger.Location = new Point(547, 334);
            trackBarAnger.Name = "trackBarAnger";
            trackBarAnger.Size = new Size(288, 45);
            trackBarAnger.TabIndex = 104;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(667, 391);
            label9.Name = "label9";
            label9.Size = new Size(49, 15);
            label9.TabIndex = 105;
            label9.Text = "Sadness";
            // 
            // trackBarSadness
            // 
            trackBarSadness.Cursor = Cursors.IBeam;
            trackBarSadness.LargeChange = 1;
            trackBarSadness.Location = new Point(547, 418);
            trackBarSadness.Name = "trackBarSadness";
            trackBarSadness.Size = new Size(288, 45);
            trackBarSadness.TabIndex = 106;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(668, 475);
            label10.Name = "label10";
            label10.Size = new Size(46, 15);
            label10.TabIndex = 107;
            label10.Text = "Disgust";
            // 
            // trackBarDisgust
            // 
            trackBarDisgust.Cursor = Cursors.IBeam;
            trackBarDisgust.LargeChange = 1;
            trackBarDisgust.Location = new Point(547, 502);
            trackBarDisgust.Name = "trackBarDisgust";
            trackBarDisgust.Size = new Size(288, 45);
            trackBarDisgust.TabIndex = 108;
            // 
            // dateTimeFrom
            // 
            dateTimeFrom.Location = new Point(594, 561);
            dateTimeFrom.Name = "dateTimeFrom";
            dateTimeFrom.Size = new Size(200, 23);
            dateTimeFrom.TabIndex = 109;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(526, 567);
            label11.Name = "label11";
            label11.Size = new Size(62, 15);
            label11.TabIndex = 110;
            label11.Text = "Date From";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(526, 607);
            label12.Name = "label12";
            label12.Size = new Size(47, 15);
            label12.TabIndex = 112;
            label12.Text = "Date To";
            // 
            // dateTimeTo
            // 
            dateTimeTo.Location = new Point(594, 601);
            dateTimeTo.Name = "dateTimeTo";
            dateTimeTo.Size = new Size(200, 23);
            dateTimeTo.TabIndex = 111;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(913, 139);
            label13.Name = "label13";
            label13.Size = new Size(46, 15);
            label13.TabIndex = 113;
            label13.Text = "How to";
            // 
            // textBoxHowTo
            // 
            textBoxHowTo.Location = new Point(913, 166);
            textBoxHowTo.Multiline = true;
            textBoxHowTo.Name = "textBoxHowTo";
            textBoxHowTo.Size = new Size(574, 60);
            textBoxHowTo.TabIndex = 114;
            // 
            // textBoxWithWhat
            // 
            textBoxWithWhat.Location = new Point(913, 262);
            textBoxWithWhat.Multiline = true;
            textBoxWithWhat.Name = "textBoxWithWhat";
            textBoxWithWhat.Size = new Size(574, 60);
            textBoxWithWhat.TabIndex = 116;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(913, 235);
            label14.Name = "label14";
            label14.Size = new Size(63, 15);
            label14.TabIndex = 115;
            label14.Text = "With What";
            // 
            // textBoxWithout
            // 
            textBoxWithout.Location = new Point(913, 356);
            textBoxWithout.Multiline = true;
            textBoxWithout.Name = "textBoxWithout";
            textBoxWithout.Size = new Size(574, 60);
            textBoxWithout.TabIndex = 118;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(913, 329);
            label15.Name = "label15";
            label15.Size = new Size(50, 15);
            label15.TabIndex = 117;
            label15.Text = "Without";
            // 
            // textBoxWhere
            // 
            textBoxWhere.Location = new Point(913, 456);
            textBoxWhere.Multiline = true;
            textBoxWhere.Name = "textBoxWhere";
            textBoxWhere.Size = new Size(574, 60);
            textBoxWhere.TabIndex = 120;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(913, 429);
            label16.Name = "label16";
            label16.Size = new Size(41, 15);
            label16.TabIndex = 119;
            label16.Text = "Where";
            // 
            // textBoxWhen
            // 
            textBoxWhen.Location = new Point(913, 567);
            textBoxWhen.Multiline = true;
            textBoxWhen.Name = "textBoxWhen";
            textBoxWhen.Size = new Size(574, 60);
            textBoxWhen.TabIndex = 122;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(913, 540);
            label17.Name = "label17";
            label17.Size = new Size(38, 15);
            label17.TabIndex = 121;
            label17.Text = "When";
            // 
            // button1
            // 
            button1.Location = new Point(1180, 643);
            button1.Name = "button1";
            button1.Size = new Size(307, 23);
            button1.TabIndex = 123;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SaveButton_Click;
            // 
            // buttonDeleteEntity
            // 
            buttonDeleteEntity.Location = new Point(1034, 643);
            buttonDeleteEntity.Name = "buttonDeleteEntity";
            buttonDeleteEntity.Size = new Size(75, 23);
            buttonDeleteEntity.TabIndex = 124;
            buttonDeleteEntity.Text = "Delete";
            buttonDeleteEntity.UseVisualStyleBackColor = true;
            buttonDeleteEntity.Click += buttonDeleteEntity_Click;
            // 
            // EntityEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BackgroundPanelMain;
            ClientSize = new Size(1503, 678);
            Controls.Add(buttonDeleteEntity);
            Controls.Add(button1);
            Controls.Add(textBoxWhen);
            Controls.Add(label17);
            Controls.Add(textBoxWhere);
            Controls.Add(label16);
            Controls.Add(textBoxWithout);
            Controls.Add(label15);
            Controls.Add(textBoxWithWhat);
            Controls.Add(label14);
            Controls.Add(textBoxHowTo);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(dateTimeTo);
            Controls.Add(label11);
            Controls.Add(dateTimeFrom);
            Controls.Add(label10);
            Controls.Add(trackBarDisgust);
            Controls.Add(label9);
            Controls.Add(trackBarSadness);
            Controls.Add(label8);
            Controls.Add(trackBarAnger);
            Controls.Add(label7);
            Controls.Add(trackBarFear);
            Controls.Add(label6);
            Controls.Add(trackBarJoy);
            Controls.Add(textBoxRelatedEntities);
            Controls.Add(label5);
            Controls.Add(textBoxFullDescription);
            Controls.Add(label4);
            Controls.Add(textBoxShortDescription);
            Controls.Add(label3);
            Controls.Add(comboBoxEntityType);
            Controls.Add(label1);
            Controls.Add(textBoxOtherNames);
            Controls.Add(label2);
            Controls.Add(txtBoxEntityName);
            Controls.Add(lblEntityName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximumSize = new Size(1519, 717);
            MinimumSize = new Size(1519, 717);
            Name = "EntityEditForm";
            Load += EntityEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)trackBarJoy).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarFear).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAnger).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSadness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarDisgust).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label lblEntityName;
        private TextBox txtBoxEntityName;
        private Label label2;
        private TextBox textBoxOtherNames;
        private Label label1;
        private ComboBox comboBoxEntityType;
        private Label label3;
        private TextBox textBoxShortDescription;
        private Label label4;
        private TextBox textBoxFullDescription;
        private Label label5;
        private TextBox textBoxRelatedEntities;
        private Label label6;
        private Label label7;
        private TrackBar trackBarFear;
        private Label label8;
        private TrackBar trackBarAnger;
        private Label label9;
        private TrackBar trackBarSadness;
        private Label label10;
        private TrackBar trackBarDisgust;
        private DateTimePicker dateTimeFrom;
        private Label label11;
        private Label label12;
        private DateTimePicker dateTimeTo;
        private Label label13;
        private TextBox textBoxHowTo;
        private TextBox textBoxWithWhat;
        private Label label14;
        private TextBox textBoxWithout;
        private Label label15;
        private TextBox textBoxWhere;
        private Label label16;
        public TrackBar trackBarJoy;
        private TextBox textBoxWhen;
        private Label label17;
        private Button button1;
        private Button buttonDeleteEntity;
    }
}
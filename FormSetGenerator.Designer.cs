namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    partial class FormSetGenerator
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Duplicate = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Accept = new System.Windows.Forms.Button();
            this.button_Hide = new System.Windows.Forms.Button();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.textBox_Impedance_Static_Im = new System.Windows.Forms.TextBox();
            this.textBox_Impedance_Static_Re = new System.Windows.Forms.TextBox();
            this.checkBox_Impedance_Static = new System.Windows.Forms.CheckBox();
            this.textBox_Voltage_Static_Im = new System.Windows.Forms.TextBox();
            this.textBox_Voltage_Static_Re = new System.Windows.Forms.TextBox();
            this.checkBox_Voltage_Static = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.kryptonNavigator1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(984, 521);
            this.splitContainer1.SplitterDistance = 420;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button_Delete);
            this.splitContainer2.Panel2.Controls.Add(this.button_Duplicate);
            this.splitContainer2.Panel2.Controls.Add(this.button_Add);
            this.splitContainer2.Panel2.Controls.Add(this.button_Accept);
            this.splitContainer2.Panel2.Controls.Add(this.button_Hide);
            this.splitContainer2.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer2.Size = new System.Drawing.Size(560, 521);
            this.splitContainer2.SplitterDistance = 268;
            this.splitContainer2.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(288, 319);
            this.comboBox1.TabIndex = 0;
            // 
            // button_Delete
            // 
            this.button_Delete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Delete.Location = new System.Drawing.Point(0, 406);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(288, 23);
            this.button_Delete.TabIndex = 10;
            this.button_Delete.Text = "Usuń";
            this.button_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Duplicate
            // 
            this.button_Duplicate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Duplicate.Location = new System.Drawing.Point(0, 429);
            this.button_Duplicate.Name = "button_Duplicate";
            this.button_Duplicate.Size = new System.Drawing.Size(288, 23);
            this.button_Duplicate.TabIndex = 9;
            this.button_Duplicate.Text = "Duplikuj";
            this.button_Duplicate.UseVisualStyleBackColor = true;
            // 
            // button_Add
            // 
            this.button_Add.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Add.Location = new System.Drawing.Point(0, 452);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(288, 23);
            this.button_Add.TabIndex = 8;
            this.button_Add.Text = "Dodaj";
            this.button_Add.UseVisualStyleBackColor = true;
            // 
            // button_Accept
            // 
            this.button_Accept.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Accept.Location = new System.Drawing.Point(0, 475);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(288, 23);
            this.button_Accept.TabIndex = 7;
            this.button_Accept.Text = "Zatwierdź";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // button_Hide
            // 
            this.button_Hide.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Hide.Location = new System.Drawing.Point(0, 498);
            this.button_Hide.Name = "button_Hide";
            this.button_Hide.Size = new System.Drawing.Size(288, 23);
            this.button_Hide.TabIndex = 6;
            this.button_Hide.Text = "Anuluj";
            this.button_Hide.UseVisualStyleBackColor = true;
            this.button_Hide.Click += new System.EventHandler(this.button_Hide_Click);
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
            this.kryptonNavigator1.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2});
            this.kryptonNavigator1.SelectedIndex = 1;
            this.kryptonNavigator1.Size = new System.Drawing.Size(420, 521);
            this.kryptonNavigator1.TabIndex = 1;
            this.kryptonNavigator1.Text = "Parametry Ogólne";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.AutoScroll = true;
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(419, 494);
            this.kryptonPage1.Text = "Parametry Ogólne";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "3FB0EAAF3EC4444886B2CAD61FC059DA";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.AutoScroll = true;
            this.kryptonPage2.Controls.Add(this.textBox_Voltage_Static_Im);
            this.kryptonPage2.Controls.Add(this.textBox_Voltage_Static_Re);
            this.kryptonPage2.Controls.Add(this.checkBox_Voltage_Static);
            this.kryptonPage2.Controls.Add(this.textBox_Impedance_Static_Im);
            this.kryptonPage2.Controls.Add(this.textBox_Impedance_Static_Re);
            this.kryptonPage2.Controls.Add(this.checkBox_Impedance_Static);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(418, 494);
            this.kryptonPage2.Text = "Parametry Elektryczne";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "A7FE1DEDC3CE4DE008B73A110407DD9A";
            // 
            // textBox_Impedance_Static_Im
            // 
            this.textBox_Impedance_Static_Im.Enabled = false;
            this.textBox_Impedance_Static_Im.Location = new System.Drawing.Point(204, 17);
            this.textBox_Impedance_Static_Im.Name = "textBox_Impedance_Static_Im";
            this.textBox_Impedance_Static_Im.Size = new System.Drawing.Size(40, 20);
            this.textBox_Impedance_Static_Im.TabIndex = 5;
            // 
            // textBox_Impedance_Static_Re
            // 
            this.textBox_Impedance_Static_Re.Enabled = false;
            this.textBox_Impedance_Static_Re.Location = new System.Drawing.Point(158, 17);
            this.textBox_Impedance_Static_Re.Name = "textBox_Impedance_Static_Re";
            this.textBox_Impedance_Static_Re.Size = new System.Drawing.Size(40, 20);
            this.textBox_Impedance_Static_Re.TabIndex = 4;
            // 
            // checkBox_Impedance_Static
            // 
            this.checkBox_Impedance_Static.AutoSize = true;
            this.checkBox_Impedance_Static.Location = new System.Drawing.Point(11, 20);
            this.checkBox_Impedance_Static.Name = "checkBox_Impedance_Static";
            this.checkBox_Impedance_Static.Size = new System.Drawing.Size(141, 17);
            this.checkBox_Impedance_Static.TabIndex = 3;
            this.checkBox_Impedance_Static.Text = "Wymuś opór elektryczny";
            this.checkBox_Impedance_Static.UseVisualStyleBackColor = true;
            this.checkBox_Impedance_Static.CheckedChanged += new System.EventHandler(this.checkBox_Impedance_Static_CheckedChanged);
            // 
            // textBox_Voltage_Static_Im
            // 
            this.textBox_Voltage_Static_Im.Enabled = false;
            this.textBox_Voltage_Static_Im.Location = new System.Drawing.Point(204, 40);
            this.textBox_Voltage_Static_Im.Name = "textBox_Voltage_Static_Im";
            this.textBox_Voltage_Static_Im.Size = new System.Drawing.Size(40, 20);
            this.textBox_Voltage_Static_Im.TabIndex = 8;
            // 
            // textBox_Voltage_Static_Re
            // 
            this.textBox_Voltage_Static_Re.Enabled = false;
            this.textBox_Voltage_Static_Re.Location = new System.Drawing.Point(158, 40);
            this.textBox_Voltage_Static_Re.Name = "textBox_Voltage_Static_Re";
            this.textBox_Voltage_Static_Re.Size = new System.Drawing.Size(40, 20);
            this.textBox_Voltage_Static_Re.TabIndex = 7;
            // 
            // checkBox_Voltage_Static
            // 
            this.checkBox_Voltage_Static.AutoSize = true;
            this.checkBox_Voltage_Static.Location = new System.Drawing.Point(11, 43);
            this.checkBox_Voltage_Static.Name = "checkBox_Voltage_Static";
            this.checkBox_Voltage_Static.Size = new System.Drawing.Size(104, 17);
            this.checkBox_Voltage_Static.TabIndex = 6;
            this.checkBox_Voltage_Static.Text = "Wymuś napięcie";
            this.checkBox_Voltage_Static.UseVisualStyleBackColor = true;
            this.checkBox_Voltage_Static.CheckedChanged += new System.EventHandler(this.checkBox_Voltage_Static_CheckedChanged);
            // 
            // FormSetGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 521);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormSetGenerator";
            this.Text = "FormSetGenerator";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            this.kryptonPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Duplicate;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.Button button_Hide;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private System.Windows.Forms.TextBox textBox_Voltage_Static_Im;
        private System.Windows.Forms.TextBox textBox_Voltage_Static_Re;
        private System.Windows.Forms.CheckBox checkBox_Voltage_Static;
        private System.Windows.Forms.TextBox textBox_Impedance_Static_Im;
        private System.Windows.Forms.TextBox textBox_Impedance_Static_Re;
        private System.Windows.Forms.CheckBox checkBox_Impedance_Static;
    }
}
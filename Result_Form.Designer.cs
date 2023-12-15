namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    partial class Result_Form
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
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.button_Save_Result = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Result
            // 
            this.textBox_Result.Location = new System.Drawing.Point(12, 12);
            this.textBox_Result.Multiline = true;
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.Size = new System.Drawing.Size(776, 386);
            this.textBox_Result.TabIndex = 0;
            // 
            // button_Save_Result
            // 
            this.button_Save_Result.Location = new System.Drawing.Point(12, 404);
            this.button_Save_Result.Name = "button_Save_Result";
            this.button_Save_Result.Size = new System.Drawing.Size(75, 34);
            this.button_Save_Result.TabIndex = 1;
            this.button_Save_Result.Text = "Zapisz wynik";
            this.button_Save_Result.UseVisualStyleBackColor = true;
            // 
            // Result_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Save_Result);
            this.Controls.Add(this.textBox_Result);
            this.Name = "Result_Form";
            this.Text = "Result_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.Button button_Save_Result;
    }
}
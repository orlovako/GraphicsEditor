namespace GraphicsEditor1
{
    partial class NewFile
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
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.heightBox = new System.Windows.Forms.NumericUpDown();
            this.widthBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(28, 200);
            this.okBtn.Margin = new System.Windows.Forms.Padding(4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(100, 28);
            this.okBtn.TabIndex = 35;
            this.okBtn.Text = "&OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(176, 200);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(100, 28);
            this.cancelBtn.TabIndex = 34;
            this.cancelBtn.Text = "&Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Height:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Width:";
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(116, 109);
            this.heightBox.Margin = new System.Windows.Forms.Padding(4);
            this.heightBox.Maximum = new decimal(new int[] {
            550,
            0,
            0,
            0});
            this.heightBox.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(160, 22);
            this.heightBox.TabIndex = 29;
            this.heightBox.Value = new decimal(new int[] {
            458,
            0,
            0,
            0});
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(116, 49);
            this.widthBox.Margin = new System.Windows.Forms.Padding(4);
            this.widthBox.Maximum = new decimal(new int[] {
            1040,
            0,
            0,
            0});
            this.widthBox.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(160, 22);
            this.widthBox.TabIndex = 28;
            this.widthBox.Value = new decimal(new int[] {
            780,
            0,
            0,
            0});
            // 
            // NewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 259);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.widthBox);
            this.MaximumSize = new System.Drawing.Size(321, 306);
            this.MinimumSize = new System.Drawing.Size(321, 306);
            this.Name = "NewFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewFile";
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown heightBox;
        private System.Windows.Forms.NumericUpDown widthBox;
    }
}
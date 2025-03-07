namespace FileAnalyzer_Winform
{
    partial class FormMain
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
            this.combFileTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.listResult = new System.Windows.Forms.ListBox();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // combFileTypes
            // 
            this.combFileTypes.FormattingEnabled = true;
            this.combFileTypes.Location = new System.Drawing.Point(331, 124);
            this.combFileTypes.Name = "combFileTypes";
            this.combFileTypes.Size = new System.Drawing.Size(203, 24);
            this.combFileTypes.TabIndex = 0;
            this.combFileTypes.SelectedIndexChanged += new System.EventHandler(this.combFileTypes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(271, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 52);
            this.label1.TabIndex = 8;
            this.label1.Text = "File Analyzer";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(25, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "Please choose an file extension";
            // 
            // btnLoad
            // 
            this.btnLoad.Enabled = false;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoad.Location = new System.Drawing.Point(612, 114);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 37);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // listResult
            // 
            this.listResult.FormattingEnabled = true;
            this.listResult.ItemHeight = 16;
            this.listResult.Location = new System.Drawing.Point(52, 206);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(700, 212);
            this.listResult.TabIndex = 13;
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(331, 169);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(401, 18);
            this.prgBar.TabIndex = 14;
            // 
            // labelFilePath
            // 
            this.labelFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelFilePath.Location = new System.Drawing.Point(48, 421);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(704, 29);
            this.labelFilePath.TabIndex = 15;
            this.labelFilePath.Text = "Please choose an file extension";
            this.labelFilePath.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 538);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.listResult);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combFileTypes);
            this.Name = "FormMain";
            this.Text = "formApp";
            this.Load += new System.EventHandler(this.formApp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox combFileTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ListBox listResult;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.Label labelFilePath;
    }
}
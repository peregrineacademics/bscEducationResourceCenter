namespace EFCodeGenerator
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
            this.listBoxSource = new System.Windows.Forms.ListBox();
            this.buttonMoveRight = new System.Windows.Forms.Button();
            this.buttonMoveRightAll = new System.Windows.Forms.Button();
            this.buttonMoveLeftAll = new System.Windows.Forms.Button();
            this.buttonMoveLeft = new System.Windows.Forms.Button();
            this.listBoxDestination = new System.Windows.Forms.ListBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelSource = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.buttonBrowseProjectFile = new System.Windows.Forms.Button();
            this.textBoxProjectFile = new System.Windows.Forms.TextBox();
            this.labelProjectFile = new System.Windows.Forms.Label();
            this.openFileDialogBrowse = new System.Windows.Forms.OpenFileDialog();
            this.labelRequiredOutput = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxGenerate = new System.Windows.Forms.GroupBox();
            this.labelStep2 = new System.Windows.Forms.Label();
            this.labelStep1 = new System.Windows.Forms.Label();
            this.groupBoxGenerate.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxSource
            // 
            this.listBoxSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSource.FormattingEnabled = true;
            this.listBoxSource.ItemHeight = 16;
            this.listBoxSource.Location = new System.Drawing.Point(20, 33);
            this.listBoxSource.Name = "listBoxSource";
            this.listBoxSource.Size = new System.Drawing.Size(223, 260);
            this.listBoxSource.Sorted = true;
            this.listBoxSource.TabIndex = 6;
            this.listBoxSource.SelectedIndexChanged += new System.EventHandler(this.listBoxSource_SelectedIndexChanged);
            this.listBoxSource.DoubleClick += new System.EventHandler(this.listBoxSource_DoubleClick);
            // 
            // buttonMoveRight
            // 
            this.buttonMoveRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveRight.Location = new System.Drawing.Point(261, 72);
            this.buttonMoveRight.Name = "buttonMoveRight";
            this.buttonMoveRight.Size = new System.Drawing.Size(42, 41);
            this.buttonMoveRight.TabIndex = 9;
            this.buttonMoveRight.Text = ">";
            this.buttonMoveRight.UseVisualStyleBackColor = true;
            this.buttonMoveRight.Click += new System.EventHandler(this.buttonMoveRight_Click);
            // 
            // buttonMoveRightAll
            // 
            this.buttonMoveRightAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveRightAll.Location = new System.Drawing.Point(261, 119);
            this.buttonMoveRightAll.Name = "buttonMoveRightAll";
            this.buttonMoveRightAll.Size = new System.Drawing.Size(42, 41);
            this.buttonMoveRightAll.TabIndex = 10;
            this.buttonMoveRightAll.Text = ">>";
            this.buttonMoveRightAll.UseVisualStyleBackColor = true;
            this.buttonMoveRightAll.Click += new System.EventHandler(this.buttonMoveRightAll_Click);
            // 
            // buttonMoveLeftAll
            // 
            this.buttonMoveLeftAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveLeftAll.Location = new System.Drawing.Point(261, 166);
            this.buttonMoveLeftAll.Name = "buttonMoveLeftAll";
            this.buttonMoveLeftAll.Size = new System.Drawing.Size(42, 41);
            this.buttonMoveLeftAll.TabIndex = 11;
            this.buttonMoveLeftAll.Text = "<<";
            this.buttonMoveLeftAll.UseVisualStyleBackColor = true;
            this.buttonMoveLeftAll.Click += new System.EventHandler(this.buttonMoveLeftAll_Click);
            // 
            // buttonMoveLeft
            // 
            this.buttonMoveLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveLeft.Location = new System.Drawing.Point(261, 213);
            this.buttonMoveLeft.Name = "buttonMoveLeft";
            this.buttonMoveLeft.Size = new System.Drawing.Size(42, 41);
            this.buttonMoveLeft.TabIndex = 12;
            this.buttonMoveLeft.Text = "<";
            this.buttonMoveLeft.UseVisualStyleBackColor = true;
            this.buttonMoveLeft.Click += new System.EventHandler(this.buttonMoveLeft_Click);
            // 
            // listBoxDestination
            // 
            this.listBoxDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDestination.FormattingEnabled = true;
            this.listBoxDestination.ItemHeight = 16;
            this.listBoxDestination.Location = new System.Drawing.Point(322, 33);
            this.listBoxDestination.Name = "listBoxDestination";
            this.listBoxDestination.Size = new System.Drawing.Size(223, 260);
            this.listBoxDestination.TabIndex = 8;
            this.listBoxDestination.SelectedIndexChanged += new System.EventHandler(this.listBoxDestination_SelectedIndexChanged);
            this.listBoxDestination.DoubleClick += new System.EventHandler(this.listBoxDestination_DoubleClick);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerate.Location = new System.Drawing.Point(413, 417);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(96, 41);
            this.buttonGenerate.TabIndex = 14;
            this.buttonGenerate.Text = "&Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(515, 417);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(77, 41);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "E&xit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSource.Location = new System.Drawing.Point(22, 14);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(54, 16);
            this.labelSource.TabIndex = 5;
            this.labelSource.Text = "Source:";
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDestination.Location = new System.Drawing.Point(324, 14);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(49, 16);
            this.labelDestination.TabIndex = 6;
            this.labelDestination.Text = "Output:";
            // 
            // buttonBrowseProjectFile
            // 
            this.buttonBrowseProjectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowseProjectFile.Location = new System.Drawing.Point(510, 46);
            this.buttonBrowseProjectFile.Name = "buttonBrowseProjectFile";
            this.buttonBrowseProjectFile.Size = new System.Drawing.Size(82, 25);
            this.buttonBrowseProjectFile.TabIndex = 3;
            this.buttonBrowseProjectFile.Text = "Browse...";
            this.buttonBrowseProjectFile.UseVisualStyleBackColor = true;
            this.buttonBrowseProjectFile.Click += new System.EventHandler(this.buttonBrowseProjectFile_Click);
            // 
            // textBoxProjectFile
            // 
            this.textBoxProjectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProjectFile.Location = new System.Drawing.Point(104, 47);
            this.textBoxProjectFile.Name = "textBoxProjectFile";
            this.textBoxProjectFile.ReadOnly = true;
            this.textBoxProjectFile.Size = new System.Drawing.Size(387, 22);
            this.textBoxProjectFile.TabIndex = 2;
            // 
            // labelProjectFile
            // 
            this.labelProjectFile.AutoSize = true;
            this.labelProjectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProjectFile.Location = new System.Drawing.Point(23, 50);
            this.labelProjectFile.Name = "labelProjectFile";
            this.labelProjectFile.Size = new System.Drawing.Size(78, 16);
            this.labelProjectFile.TabIndex = 1;
            this.labelProjectFile.Text = "Project File:";
            // 
            // openFileDialogBrowse
            // 
            this.openFileDialogBrowse.Filter = "Project File (*.csproj)|*.csproj;";
            // 
            // labelRequiredOutput
            // 
            this.labelRequiredOutput.AutoSize = true;
            this.labelRequiredOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRequiredOutput.ForeColor = System.Drawing.Color.Red;
            this.labelRequiredOutput.Location = new System.Drawing.Point(370, 15);
            this.labelRequiredOutput.Name = "labelRequiredOutput";
            this.labelRequiredOutput.Size = new System.Drawing.Size(13, 16);
            this.labelRequiredOutput.TabIndex = 15;
            this.labelRequiredOutput.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(494, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "*";
            // 
            // groupBoxGenerate
            // 
            this.groupBoxGenerate.Controls.Add(this.labelSource);
            this.groupBoxGenerate.Controls.Add(this.labelRequiredOutput);
            this.groupBoxGenerate.Controls.Add(this.listBoxSource);
            this.groupBoxGenerate.Controls.Add(this.buttonMoveRight);
            this.groupBoxGenerate.Controls.Add(this.buttonMoveRightAll);
            this.groupBoxGenerate.Controls.Add(this.labelDestination);
            this.groupBoxGenerate.Controls.Add(this.buttonMoveLeftAll);
            this.groupBoxGenerate.Controls.Add(this.buttonMoveLeft);
            this.groupBoxGenerate.Controls.Add(this.listBoxDestination);
            this.groupBoxGenerate.Location = new System.Drawing.Point(26, 103);
            this.groupBoxGenerate.Name = "groupBoxGenerate";
            this.groupBoxGenerate.Size = new System.Drawing.Size(565, 306);
            this.groupBoxGenerate.TabIndex = 17;
            this.groupBoxGenerate.TabStop = false;
            // 
            // labelStep2
            // 
            this.labelStep2.AutoSize = true;
            this.labelStep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStep2.Location = new System.Drawing.Point(17, 87);
            this.labelStep2.Name = "labelStep2";
            this.labelStep2.Size = new System.Drawing.Size(276, 16);
            this.labelStep2.TabIndex = 18;
            this.labelStep2.Text = "2. Select objects to generate or update";
            // 
            // labelStep1
            // 
            this.labelStep1.AutoSize = true;
            this.labelStep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStep1.Location = new System.Drawing.Point(15, 19);
            this.labelStep1.Name = "labelStep1";
            this.labelStep1.Size = new System.Drawing.Size(367, 16);
            this.labelStep1.TabIndex = 19;
            this.labelStep1.Text = "1. Browse for the Visual Studio Project File (*.csproj)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 478);
            this.Controls.Add(this.labelStep1);
            this.Controls.Add(this.labelStep2);
            this.Controls.Add(this.groupBoxGenerate);
            this.Controls.Add(this.buttonBrowseProjectFile);
            this.Controls.Add(this.textBoxProjectFile);
            this.Controls.Add(this.labelProjectFile);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "EF Code Generator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBoxGenerate.ResumeLayout(false);
            this.groupBoxGenerate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSource;
        private System.Windows.Forms.Button buttonMoveRight;
        private System.Windows.Forms.Button buttonMoveRightAll;
        private System.Windows.Forms.Button buttonMoveLeftAll;
        private System.Windows.Forms.Button buttonMoveLeft;
        private System.Windows.Forms.ListBox listBoxDestination;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.Button buttonBrowseProjectFile;
        private System.Windows.Forms.TextBox textBoxProjectFile;
        private System.Windows.Forms.Label labelProjectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogBrowse;
        private System.Windows.Forms.Label labelRequiredOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxGenerate;
        private System.Windows.Forms.Label labelStep2;
        private System.Windows.Forms.Label labelStep1;
    }
}


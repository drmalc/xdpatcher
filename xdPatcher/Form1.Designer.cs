namespace xdPatcher
{
    partial class Form1
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btCreatePatch = new System.Windows.Forms.Button();
            this.btBrowseTarget = new System.Windows.Forms.Button();
            this.textBoxTargetPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btBrowseNew = new System.Windows.Forms.Button();
            this.textBoxNewPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btBrowseOld = new System.Windows.Forms.Button();
            this.textBoxOldPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btStop = new System.Windows.Forms.Button();
            this.btBrowseChoosePatch = new System.Windows.Forms.Button();
            this.textBoxApplyPatch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btBrowseOutdated = new System.Windows.Forms.Button();
            this.textBoxApplyOld = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btBrowsePatchedTarget = new System.Windows.Forms.Button();
            this.textBoxApplyTarget = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btApplyStop = new System.Windows.Forms.Button();
            this.btApplyPatch = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(460, 202);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btApplyStop);
            this.tabPage1.Controls.Add(this.btApplyPatch);
            this.tabPage1.Controls.Add(this.btBrowsePatchedTarget);
            this.tabPage1.Controls.Add(this.textBoxApplyTarget);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btBrowseOutdated);
            this.tabPage1.Controls.Add(this.textBoxApplyOld);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btBrowseChoosePatch);
            this.tabPage1.Controls.Add(this.textBoxApplyPatch);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(452, 176);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Apply a patch";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btStop);
            this.tabPage2.Controls.Add(this.btCreatePatch);
            this.tabPage2.Controls.Add(this.btBrowseTarget);
            this.tabPage2.Controls.Add(this.textBoxTargetPath);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btBrowseNew);
            this.tabPage2.Controls.Add(this.textBoxNewPath);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btBrowseOld);
            this.tabPage2.Controls.Add(this.textBoxOldPath);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(452, 176);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create a patch";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btCreatePatch
            // 
            this.btCreatePatch.Location = new System.Drawing.Point(6, 142);
            this.btCreatePatch.Name = "btCreatePatch";
            this.btCreatePatch.Size = new System.Drawing.Size(98, 23);
            this.btCreatePatch.TabIndex = 9;
            this.btCreatePatch.Text = "Create patch";
            this.btCreatePatch.UseVisualStyleBackColor = true;
            this.btCreatePatch.Click += new System.EventHandler(this.Form1_CreatePatchButtonClicked);
            // 
            // btBrowseTarget
            // 
            this.btBrowseTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseTarget.Location = new System.Drawing.Point(371, 94);
            this.btBrowseTarget.Name = "btBrowseTarget";
            this.btBrowseTarget.Size = new System.Drawing.Size(75, 23);
            this.btBrowseTarget.TabIndex = 8;
            this.btBrowseTarget.Text = "Browse...";
            this.btBrowseTarget.UseVisualStyleBackColor = true;
            this.btBrowseTarget.Click += new System.EventHandler(this.Form1_BrowseButtonClicked);
            // 
            // textBoxTargetPath
            // 
            this.textBoxTargetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTargetPath.Location = new System.Drawing.Point(9, 97);
            this.textBoxTargetPath.Name = "textBoxTargetPath";
            this.textBoxTargetPath.Size = new System.Drawing.Size(356, 20);
            this.textBoxTargetPath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Where to save the patch ?";
            // 
            // btBrowseNew
            // 
            this.btBrowseNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseNew.Location = new System.Drawing.Point(371, 55);
            this.btBrowseNew.Name = "btBrowseNew";
            this.btBrowseNew.Size = new System.Drawing.Size(75, 23);
            this.btBrowseNew.TabIndex = 5;
            this.btBrowseNew.Text = "Browse...";
            this.btBrowseNew.UseVisualStyleBackColor = true;
            this.btBrowseNew.Click += new System.EventHandler(this.Form1_BrowseButtonClicked);
            // 
            // textBoxNewPath
            // 
            this.textBoxNewPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewPath.Location = new System.Drawing.Point(9, 58);
            this.textBoxNewPath.Name = "textBoxNewPath";
            this.textBoxNewPath.Size = new System.Drawing.Size(356, 20);
            this.textBoxNewPath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "New version directory";
            // 
            // btBrowseOld
            // 
            this.btBrowseOld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseOld.Location = new System.Drawing.Point(371, 16);
            this.btBrowseOld.Name = "btBrowseOld";
            this.btBrowseOld.Size = new System.Drawing.Size(75, 23);
            this.btBrowseOld.TabIndex = 2;
            this.btBrowseOld.Text = "Browse...";
            this.btBrowseOld.UseVisualStyleBackColor = true;
            this.btBrowseOld.Click += new System.EventHandler(this.Form1_BrowseButtonClicked);
            // 
            // textBoxOldPath
            // 
            this.textBoxOldPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOldPath.Location = new System.Drawing.Point(9, 19);
            this.textBoxOldPath.Name = "textBoxOldPath";
            this.textBoxOldPath.Size = new System.Drawing.Size(356, 20);
            this.textBoxOldPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old version directory";
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Location = new System.Drawing.Point(12, 249);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(456, 131);
            this.logTextBox.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 220);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(456, 23);
            this.progressBar.TabIndex = 2;
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(110, 142);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 10;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btBrowseChoosePatch
            // 
            this.btBrowseChoosePatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseChoosePatch.Location = new System.Drawing.Point(371, 16);
            this.btBrowseChoosePatch.Name = "btBrowseChoosePatch";
            this.btBrowseChoosePatch.Size = new System.Drawing.Size(75, 23);
            this.btBrowseChoosePatch.TabIndex = 5;
            this.btBrowseChoosePatch.Text = "Browse...";
            this.btBrowseChoosePatch.UseVisualStyleBackColor = true;
            this.btBrowseChoosePatch.Click += new System.EventHandler(this.Form1_BrowseButtonClicked);
            // 
            // textBoxApplyPatch
            // 
            this.textBoxApplyPatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxApplyPatch.Location = new System.Drawing.Point(9, 19);
            this.textBoxApplyPatch.Name = "textBoxApplyPatch";
            this.textBoxApplyPatch.Size = new System.Drawing.Size(356, 20);
            this.textBoxApplyPatch.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Select a .xdpatch directory";
            // 
            // btBrowseOutdated
            // 
            this.btBrowseOutdated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseOutdated.Location = new System.Drawing.Point(371, 55);
            this.btBrowseOutdated.Name = "btBrowseOutdated";
            this.btBrowseOutdated.Size = new System.Drawing.Size(75, 23);
            this.btBrowseOutdated.TabIndex = 8;
            this.btBrowseOutdated.Text = "Browse...";
            this.btBrowseOutdated.UseVisualStyleBackColor = true;
            this.btBrowseOutdated.Click += new System.EventHandler(this.Form1_BrowseButtonClicked);
            // 
            // textBoxApplyOld
            // 
            this.textBoxApplyOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxApplyOld.Location = new System.Drawing.Point(9, 58);
            this.textBoxApplyOld.Name = "textBoxApplyOld";
            this.textBoxApplyOld.Size = new System.Drawing.Size(356, 20);
            this.textBoxApplyOld.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Original version directory";
            // 
            // btBrowsePatchedTarget
            // 
            this.btBrowsePatchedTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowsePatchedTarget.Location = new System.Drawing.Point(371, 94);
            this.btBrowsePatchedTarget.Name = "btBrowsePatchedTarget";
            this.btBrowsePatchedTarget.Size = new System.Drawing.Size(75, 23);
            this.btBrowsePatchedTarget.TabIndex = 11;
            this.btBrowsePatchedTarget.Text = "Browse...";
            this.btBrowsePatchedTarget.UseVisualStyleBackColor = true;
            this.btBrowsePatchedTarget.Click += new System.EventHandler(this.Form1_BrowseButtonClicked);
            // 
            // textBoxApplyTarget
            // 
            this.textBoxApplyTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxApplyTarget.Location = new System.Drawing.Point(9, 97);
            this.textBoxApplyTarget.Name = "textBoxApplyTarget";
            this.textBoxApplyTarget.Size = new System.Drawing.Size(356, 20);
            this.textBoxApplyTarget.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Where to save the patched version ?";
            // 
            // btApplyStop
            // 
            this.btApplyStop.Location = new System.Drawing.Point(110, 142);
            this.btApplyStop.Name = "btApplyStop";
            this.btApplyStop.Size = new System.Drawing.Size(75, 23);
            this.btApplyStop.TabIndex = 13;
            this.btApplyStop.Text = "Stop";
            this.btApplyStop.UseVisualStyleBackColor = true;
            this.btApplyStop.Click += new System.EventHandler(this.btApplyStop_Click);
            // 
            // btApplyPatch
            // 
            this.btApplyPatch.Location = new System.Drawing.Point(6, 142);
            this.btApplyPatch.Name = "btApplyPatch";
            this.btApplyPatch.Size = new System.Drawing.Size(98, 23);
            this.btApplyPatch.TabIndex = 12;
            this.btApplyPatch.Text = "Apply patch";
            this.btApplyPatch.UseVisualStyleBackColor = true;
            this.btApplyPatch.Click += new System.EventHandler(this.Form1_ApplyPatchButtonClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 392);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(500, 430);
            this.Name = "Form1";
            this.Text = "xdPatcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBrowseOld;
        private System.Windows.Forms.TextBox textBoxOldPath;
        private System.Windows.Forms.Button btBrowseNew;
        private System.Windows.Forms.TextBox textBoxNewPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCreatePatch;
        private System.Windows.Forms.Button btBrowseTarget;
        private System.Windows.Forms.TextBox textBoxTargetPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btBrowseChoosePatch;
        private System.Windows.Forms.TextBox textBoxApplyPatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btBrowsePatchedTarget;
        private System.Windows.Forms.TextBox textBoxApplyTarget;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btBrowseOutdated;
        private System.Windows.Forms.TextBox textBoxApplyOld;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btApplyStop;
        private System.Windows.Forms.Button btApplyPatch;
    }
}


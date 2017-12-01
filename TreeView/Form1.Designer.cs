namespace TreeView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Tree = new System.Windows.Forms.TreeView();
            this.List = new System.Windows.Forms.ListView();
            this.Path = new System.Windows.Forms.TextBox();
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // Tree
            // 
            this.Tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Tree.ImageIndex = 0;
            this.Tree.ImageList = this.imageListSmall;
            this.Tree.Location = new System.Drawing.Point(1, 2);
            this.Tree.Name = "Tree";
            this.Tree.SelectedImageIndex = 0;
            this.Tree.Size = new System.Drawing.Size(245, 530);
            this.Tree.TabIndex = 0;
            // 
            // List
            // 
            this.List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.List.LargeImageList = this.imageListLarge;
            this.List.Location = new System.Drawing.Point(252, 28);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(736, 504);
            this.List.SmallImageList = this.imageListSmall;
            this.List.TabIndex = 1;
            this.List.UseCompatibleStateImageBehavior = false;
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(252, 2);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(736, 20);
            this.Path.TabIndex = 2;
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "file.png");
            this.imageListSmall.Images.SetKeyName(1, "folder.png");
            this.imageListSmall.Images.SetKeyName(2, "hard-drive.png");
            this.imageListSmall.Images.SetKeyName(3, "laptop.png");
            // 
            // imageListLarge
            // 
            this.imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLarge.Images.SetKeyName(0, "file (1).png");
            this.imageListLarge.Images.SetKeyName(1, "folder (1).png");
            this.imageListLarge.Images.SetKeyName(2, "hard-drive (1).png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 532);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.List);
            this.Controls.Add(this.Tree);
            this.Name = "Form1";
            this.Text = "Проводник";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView Tree;
        private System.Windows.Forms.ListView List;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ImageList imageListLarge;
    }
}


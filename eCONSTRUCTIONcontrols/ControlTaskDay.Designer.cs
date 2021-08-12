
namespace eCONSTRUCTIONcontrols
{
    partial class ControlTaskDay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlTaskDay));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse();
            this.labelTaskName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelField = new System.Windows.Forms.Label();
            this.labelProject = new System.Windows.Forms.Label();
            this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip();
            this.buttonAddSupplier = new Bunifu.UI.WinForms.BunifuImageButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // labelTaskName
            // 
            this.labelTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTaskName.Font = new System.Drawing.Font("Century Gothic", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaskName.Location = new System.Drawing.Point(3, 0);
            this.labelTaskName.Name = "labelTaskName";
            this.labelTaskName.Padding = new System.Windows.Forms.Padding(10, 4, 0, 0);
            this.labelTaskName.Size = new System.Drawing.Size(194, 31);
            this.labelTaskName.TabIndex = 0;
            this.labelTaskName.Text = "Task Name";
            this.bunifuToolTip1.SetToolTip(this.labelTaskName, "");
            this.bunifuToolTip1.SetToolTipIcon(this.labelTaskName, null);
            this.bunifuToolTip1.SetToolTipTitle(this.labelTaskName, "");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Controls.Add(this.labelTaskName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelField, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelProject, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddSupplier, 2, 1);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(269, 95);
            this.tableLayoutPanel1.TabIndex = 2;
            this.bunifuToolTip1.SetToolTip(this.tableLayoutPanel1, "Double click to complete task");
            this.bunifuToolTip1.SetToolTipIcon(this.tableLayoutPanel1, null);
            this.bunifuToolTip1.SetToolTipTitle(this.tableLayoutPanel1, "");
            this.tableLayoutPanel1.Click += new System.EventHandler(this.tableLayoutPanel1_Click);
            this.tableLayoutPanel1.DoubleClick += new System.EventHandler(this.tableLayoutPanel1_DoubleClick);
            // 
            // labelField
            // 
            this.labelField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelField.Font = new System.Drawing.Font("Century Gothic", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelField.Location = new System.Drawing.Point(3, 31);
            this.labelField.Name = "labelField";
            this.labelField.Padding = new System.Windows.Forms.Padding(10, 4, 0, 0);
            this.labelField.Size = new System.Drawing.Size(194, 31);
            this.labelField.TabIndex = 1;
            this.labelField.Text = "Field";
            this.bunifuToolTip1.SetToolTip(this.labelField, "");
            this.bunifuToolTip1.SetToolTipIcon(this.labelField, null);
            this.bunifuToolTip1.SetToolTipTitle(this.labelField, "");
            // 
            // labelProject
            // 
            this.labelProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProject.Font = new System.Drawing.Font("Century Gothic", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProject.Location = new System.Drawing.Point(3, 62);
            this.labelProject.Name = "labelProject";
            this.labelProject.Padding = new System.Windows.Forms.Padding(10, 2, 0, 0);
            this.labelProject.Size = new System.Drawing.Size(194, 31);
            this.labelProject.TabIndex = 2;
            this.labelProject.Text = "Field";
            this.bunifuToolTip1.SetToolTip(this.labelProject, "");
            this.bunifuToolTip1.SetToolTipIcon(this.labelProject, null);
            this.bunifuToolTip1.SetToolTipTitle(this.labelProject, "");
            this.labelProject.Click += new System.EventHandler(this.labelProject_Click);
            // 
            // bunifuToolTip1
            // 
            this.bunifuToolTip1.Active = true;
            this.bunifuToolTip1.AlignTextWithTitle = false;
            this.bunifuToolTip1.AllowAutoClose = false;
            this.bunifuToolTip1.AllowFading = true;
            this.bunifuToolTip1.AutoCloseDuration = 5000;
            this.bunifuToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.bunifuToolTip1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.bunifuToolTip1.ClickToShowDisplayControl = false;
            this.bunifuToolTip1.ConvertNewlinesToBreakTags = true;
            this.bunifuToolTip1.DisplayControl = null;
            this.bunifuToolTip1.EntryAnimationSpeed = 350;
            this.bunifuToolTip1.ExitAnimationSpeed = 200;
            this.bunifuToolTip1.GenerateAutoCloseDuration = false;
            this.bunifuToolTip1.IconMargin = 6;
            this.bunifuToolTip1.InitialDelay = 0;
            this.bunifuToolTip1.Name = "bunifuToolTip1";
            this.bunifuToolTip1.Opacity = 1D;
            this.bunifuToolTip1.OverrideToolTipTitles = false;
            this.bunifuToolTip1.Padding = new System.Windows.Forms.Padding(10);
            this.bunifuToolTip1.ReshowDelay = 100;
            this.bunifuToolTip1.ShowAlways = true;
            this.bunifuToolTip1.ShowBorders = false;
            this.bunifuToolTip1.ShowIcons = true;
            this.bunifuToolTip1.ShowShadows = true;
            this.bunifuToolTip1.Tag = null;
            this.bunifuToolTip1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuToolTip1.TextForeColor = System.Drawing.Color.White;
            this.bunifuToolTip1.TextMargin = 2;
            this.bunifuToolTip1.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bunifuToolTip1.TitleForeColor = System.Drawing.Color.White;
            this.bunifuToolTip1.ToolTipPosition = new System.Drawing.Point(0, 0);
            this.bunifuToolTip1.ToolTipTitle = null;
            // 
            // buttonAddSupplier
            // 
            this.buttonAddSupplier.ActiveImage = null;
            this.buttonAddSupplier.AllowAnimations = true;
            this.buttonAddSupplier.AllowBuffering = false;
            this.buttonAddSupplier.AllowToggling = false;
            this.buttonAddSupplier.AllowZooming = true;
            this.buttonAddSupplier.AllowZoomingOnFocus = false;
            this.buttonAddSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddSupplier.BackColor = System.Drawing.Color.Transparent;
            this.buttonAddSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddSupplier.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonAddSupplier.ErrorImage = ((System.Drawing.Image)(resources.GetObject("buttonAddSupplier.ErrorImage")));
            this.buttonAddSupplier.FadeWhenInactive = false;
            this.buttonAddSupplier.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.buttonAddSupplier.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddSupplier.Image")));
            this.buttonAddSupplier.ImageActive = null;
            this.buttonAddSupplier.ImageLocation = null;
            this.buttonAddSupplier.ImageMargin = 0;
            this.buttonAddSupplier.ImageSize = new System.Drawing.Size(25, 24);
            this.buttonAddSupplier.ImageZoomSize = new System.Drawing.Size(26, 25);
            this.buttonAddSupplier.InitialImage = ((System.Drawing.Image)(resources.GetObject("buttonAddSupplier.InitialImage")));
            this.buttonAddSupplier.Location = new System.Drawing.Point(240, 34);
            this.buttonAddSupplier.Name = "buttonAddSupplier";
            this.buttonAddSupplier.Rotation = 0;
            this.buttonAddSupplier.ShowActiveImage = true;
            this.buttonAddSupplier.ShowCursorChanges = true;
            this.buttonAddSupplier.ShowImageBorders = false;
            this.buttonAddSupplier.ShowSizeMarkers = false;
            this.buttonAddSupplier.Size = new System.Drawing.Size(26, 25);
            this.buttonAddSupplier.TabIndex = 19;
            this.bunifuToolTip1.SetToolTip(this.buttonAddSupplier, "");
            this.bunifuToolTip1.SetToolTipIcon(this.buttonAddSupplier, null);
            this.buttonAddSupplier.ToolTipText = "";
            this.bunifuToolTip1.SetToolTipTitle(this.buttonAddSupplier, "");
            this.buttonAddSupplier.WaitOnLoad = false;
            this.buttonAddSupplier.Zoom = 0;
            this.buttonAddSupplier.ZoomSpeed = 10;
            this.buttonAddSupplier.Click += new System.EventHandler(this.buttonAddSupplier_Click);
            // 
            // ControlTaskDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(161)))), ((int)(((byte)(10)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ControlTaskDay";
            this.Size = new System.Drawing.Size(269, 95);
            this.bunifuToolTip1.SetToolTip(this, "");
            this.bunifuToolTip1.SetToolTipIcon(this, null);
            this.bunifuToolTip1.SetToolTipTitle(this, "");
            this.Load += new System.EventHandler(this.controlTaskDay_Load);
            this.DoubleClick += new System.EventHandler(this.controlTaskDay_DoubleClick);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label labelTaskName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelField;
        private System.Windows.Forms.Label labelProject;
        private Bunifu.UI.WinForms.BunifuToolTip bunifuToolTip1;
        private Bunifu.UI.WinForms.BunifuImageButton buttonAddSupplier;
    }
}

namespace ProjektBudzetLacza
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.QuitButton = new System.Windows.Forms.Button();
            this.InstructioinButton = new System.Windows.Forms.Button();
            this.CalcButton = new System.Windows.Forms.Button();
            this.DataBaseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.językiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.engToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            resources.ApplyResources(this.QuitButton, "QuitButton");
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // InstructioinButton
            // 
            resources.ApplyResources(this.InstructioinButton, "InstructioinButton");
            this.InstructioinButton.Name = "InstructioinButton";
            this.InstructioinButton.UseVisualStyleBackColor = true;
            // 
            // CalcButton
            // 
            resources.ApplyResources(this.CalcButton, "CalcButton");
            this.CalcButton.Name = "CalcButton";
            this.CalcButton.UseVisualStyleBackColor = true;
            this.CalcButton.Click += new System.EventHandler(this.CalcButton_Click);
            // 
            // DataBaseButton
            // 
            resources.ApplyResources(this.DataBaseButton, "DataBaseButton");
            this.DataBaseButton.Name = "DataBaseButton";
            this.DataBaseButton.UseVisualStyleBackColor = true;
            this.DataBaseButton.Click += new System.EventHandler(this.DataBaseButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Name = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.językiToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // językiToolStripMenuItem
            // 
            this.językiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.polToolStripMenuItem,
            this.engToolStripMenuItem});
            resources.ApplyResources(this.językiToolStripMenuItem, "językiToolStripMenuItem");
            this.językiToolStripMenuItem.Name = "językiToolStripMenuItem";
            // 
            // polToolStripMenuItem
            // 
            this.polToolStripMenuItem.Name = "polToolStripMenuItem";
            resources.ApplyResources(this.polToolStripMenuItem, "polToolStripMenuItem");
            this.polToolStripMenuItem.Click += new System.EventHandler(this.polToolStripMenuItem_Click);
            // 
            // engToolStripMenuItem
            // 
            this.engToolStripMenuItem.CheckOnClick = true;
            this.engToolStripMenuItem.Name = "engToolStripMenuItem";
            resources.ApplyResources(this.engToolStripMenuItem, "engToolStripMenuItem");
            this.engToolStripMenuItem.Click += new System.EventHandler(this.engToolStripMenuItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjektBudzetLacza.Properties.Resources._4882066;
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.InstructioinButton);
            this.Controls.Add(this.CalcButton);
            this.Controls.Add(this.DataBaseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button InstructioinButton;
        private System.Windows.Forms.Button CalcButton;
        private System.Windows.Forms.Button DataBaseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem językiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem engToolStripMenuItem;
    }
}


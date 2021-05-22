namespace Klient
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.DataBaseButton = new System.Windows.Forms.Button();
            this.CalcButton = new System.Windows.Forms.Button();
            this.InstructioinButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(134, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Budżet Łącza";
            // 
            // DataBaseButton
            // 
            this.DataBaseButton.Location = new System.Drawing.Point(167, 168);
            this.DataBaseButton.Name = "DataBaseButton";
            this.DataBaseButton.Size = new System.Drawing.Size(111, 43);
            this.DataBaseButton.TabIndex = 1;
            this.DataBaseButton.Text = "Baza Danych";
            this.DataBaseButton.UseVisualStyleBackColor = true;
            // 
            // CalcButton
            // 
            this.CalcButton.Location = new System.Drawing.Point(167, 232);
            this.CalcButton.Name = "CalcButton";
            this.CalcButton.Size = new System.Drawing.Size(111, 51);
            this.CalcButton.TabIndex = 2;
            this.CalcButton.Text = "Kalkulator";
            this.CalcButton.UseVisualStyleBackColor = true;
            // 
            // InstructioinButton
            // 
            this.InstructioinButton.Location = new System.Drawing.Point(167, 302);
            this.InstructioinButton.Name = "InstructioinButton";
            this.InstructioinButton.Size = new System.Drawing.Size(111, 46);
            this.InstructioinButton.TabIndex = 3;
            this.InstructioinButton.Text = "Instrukcja";
            this.InstructioinButton.UseVisualStyleBackColor = true;
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(371, 426);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 4;
            this.QuitButton.Text = "Wyjdź";
            this.QuitButton.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 461);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.InstructioinButton);
            this.Controls.Add(this.CalcButton);
            this.Controls.Add(this.DataBaseButton);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DataBaseButton;
        private System.Windows.Forms.Button CalcButton;
        private System.Windows.Forms.Button InstructioinButton;
        private System.Windows.Forms.Button QuitButton;
    }
}


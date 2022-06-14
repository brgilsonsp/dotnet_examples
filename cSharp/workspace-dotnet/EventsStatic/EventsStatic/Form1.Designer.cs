namespace EventsStatic
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.startTick = new System.Windows.Forms.Button();
            this.stopTick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startTick
            // 
            this.startTick.Location = new System.Drawing.Point(12, 12);
            this.startTick.Name = "startTick";
            this.startTick.Size = new System.Drawing.Size(75, 23);
            this.startTick.TabIndex = 0;
            this.startTick.Text = "Start";
            this.startTick.UseVisualStyleBackColor = true;
            this.startTick.Click += new System.EventHandler(this.startTick_Click);
            // 
            // stopTick
            // 
            this.stopTick.Location = new System.Drawing.Point(94, 11);
            this.stopTick.Name = "stopTick";
            this.stopTick.Size = new System.Drawing.Size(75, 23);
            this.stopTick.TabIndex = 1;
            this.stopTick.Text = "Stop";
            this.stopTick.UseVisualStyleBackColor = true;
            this.stopTick.Click += new System.EventHandler(this.stopTick_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 51);
            this.Controls.Add(this.stopTick);
            this.Controls.Add(this.startTick);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startTick;
        private System.Windows.Forms.Button stopTick;
    }
}


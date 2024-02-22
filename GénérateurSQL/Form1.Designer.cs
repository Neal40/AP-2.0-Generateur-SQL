namespace GénérateurSQL
{
    partial class FrmGen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnSauv = new System.Windows.Forms.Button();
            this.btnScriptSQL = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.lbxSauvegarde = new System.Windows.Forms.ListBox();
            this.lbxFichier = new System.Windows.Forms.ListBox();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.lbxScript = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            this.btnSauv.Location = new System.Drawing.Point(577, 369);
            this.btnSauv.Name = "btnSauv";
            this.btnSauv.Size = new System.Drawing.Size(111, 23);
            this.btnSauv.TabIndex = 0;
            this.btnSauv.Text = "Sauvegarder";
            this.btnSauv.UseVisualStyleBackColor = true;
            this.btnSauv.Click += new System.EventHandler(this.btnSauv_Click);
            this.btnScriptSQL.Location = new System.Drawing.Point(316, 369);
            this.btnScriptSQL.Name = "btnScriptSQL";
            this.btnScriptSQL.Size = new System.Drawing.Size(145, 23);
            this.btnScriptSQL.TabIndex = 1;
            this.btnScriptSQL.Text = "Créer un script SQL";
            this.btnScriptSQL.UseVisualStyleBackColor = true;
            this.btnScriptSQL.Click += new System.EventHandler(this.btnScriptSQL_Click);
            this.btnOpenFile.Location = new System.Drawing.Point(58, 369);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(137, 23);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "Ouvrir un fichier";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            this.lbxSauvegarde.FormattingEnabled = true;
            this.lbxSauvegarde.ItemHeight = 15;
            this.lbxSauvegarde.Location = new System.Drawing.Point(577, 44);
            this.lbxSauvegarde.Name = "lbxSauvegarde";
            this.lbxSauvegarde.Size = new System.Drawing.Size(204, 319);
            this.lbxSauvegarde.TabIndex = 3;
            this.lbxFichier.FormattingEnabled = true;
            this.lbxFichier.ItemHeight = 15;
            this.lbxFichier.Location = new System.Drawing.Point(58, 44);
            this.lbxFichier.Name = "lbxFichier";
            this.lbxFichier.Size = new System.Drawing.Size(201, 319);
            this.lbxFichier.TabIndex = 4;
            this.lbxFichier.SelectedIndexChanged += new System.EventHandler(this.lbxFichier_SelectedIndexChanged);
            this.OFD.FileName = "openFileDialog1";
            this.lbxScript.FormattingEnabled = true;
            this.lbxScript.ItemHeight = 15;
            this.lbxScript.Location = new System.Drawing.Point(316, 44);
            this.lbxScript.Name = "lbxScript";
            this.lbxScript.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxScript.Size = new System.Drawing.Size(224, 319);
            this.lbxScript.TabIndex = 5;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 452);
            this.Controls.Add(this.lbxScript);
            this.Controls.Add(this.lbxFichier);
            this.Controls.Add(this.lbxSauvegarde);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnScriptSQL);
            this.Controls.Add(this.btnSauv);
            this.Name = "FrmGen";
            this.Text = "Générateur SQL";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnSauv;
        private Button btnScriptSQL;
        private Button btnOpenFile;
        private ListBox lbxSauvegarde;
        private ListBox lbxFichier;
        private OpenFileDialog OFD;
        private SaveFileDialog SFD;
        private FolderBrowserDialog FBD;
        private ListBox lbxScript;
    }
}
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;


namespace GénérateurSQL
{
    public partial class FrmGen : Form
    {
        String[] valeursFichier;
        String nomsFichier = "";
        String request = "";

        public FrmGen()
        {
            InitializeComponent();
            btnSauv.Enabled = false;//permet de ne pas autoriser de rien enregistrer
            //Le code si dessous permet d'afficher les dossiers déjà enregistrer
            String path, valeur, ligne;
            path = "..\\..\\..\\save.txt";
            if (File.Exists(path))
            {
            }
            else
            {
                File.Create(path);
            }
            lbxSauvegarde.Items.Clear();
            StreamReader SR = new StreamReader(path);
            while ((valeur = SR.ReadLine()) != null)
            {
                ligne = Convert.ToString(valeur);
                lbxSauvegarde.Items.Add(ligne + "\n");
            }
            SR.Close();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)//La fonction permet de sélectionner un dossier et d'afficher les fichiers stocké à l'interieur.
        {
            try
            {

                if (FBD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lbxFichier.Items.Clear();
                    String path = FBD.SelectedPath;
                    lbxScript.Items.Add(path);
                    DirectoryInfo dir = new DirectoryInfo(FBD.SelectedPath);
                    FileInfo[] fichiers = dir.GetFiles();
                    foreach (FileInfo fichier in fichiers)
                    {
                        lbxFichier.Items.Add(fichier.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lecture du dossier impossible "+ ex.Message);
            }
        }

        private void btnSauv_Click(object sender, EventArgs e)//La fonction permet d'enregistrer le script SQL dans un fichier sql
        {
            try
            {


                SFD.InitialDirectory = @"c:\";
                SFD.DefaultExt = "sql";//le fichier d'enregistre par défaut en .sql
                SFD.ShowDialog();
                SFD.CheckFileExists = true;

                if (SFD.FileName != "")
                {
                    StreamWriter fsWriter = new StreamWriter(SFD.OpenFile());
                    fsWriter.Write(request);
                    lbxScript.Items.Add(request);
                    fsWriter.Close();
                    fsWriter.Dispose();
                }
                lbxSauvegarde.Items.Add(nomsFichier+".sql");
                String path = "..\\..\\..\\save.txt";
                String content = nomsFichier + ".sql" + "\n";
                if (File.Exists(path))
                {
                    File.AppendAllText(path, content);
                }
                else
                {
                    File.Create(path);
                    File.AppendAllText(path, content);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur "+ex.Message);
            }
            btnSauv.Enabled = false;
        }

        private void lbxFichier_SelectedIndexChanged(object sender, EventArgs e)//La fonction permet de prendre en valeur le fichier sélectionner dans la listbox Fichier.
        {
            String ligne, valeur;
            try
            {
                String path = FBD.SelectedPath + "\\";
                lbxScript.Items.Clear();
                String newpath = path + lbxFichier.SelectedItem.ToString();
                StreamReader SR = new StreamReader(newpath);
                nomsFichier = lbxFichier.SelectedItem.ToString();//Récupérer nom fichier 
                int index = nomsFichier.IndexOf(".");
                nomsFichier = nomsFichier.Substring(0, index);
                int cptLigne = 0;
                valeursFichier = new String[0];
                while ((valeur = SR.ReadLine()) != null)
                {
                    ligne = Convert.ToString(valeur);
                    lbxScript.Items.Add(ligne + "\n");

                    cptLigne++;
                    Array.Resize(ref valeursFichier, cptLigne);
                    valeursFichier[cptLigne-1] = ligne;

                }
                SR.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: Lecture du fichier impossible "+ ex.Message);
            }
        }

        private void btnScriptSQL_Click(object sender, EventArgs e)//La fonction permet de convertir un fichier avec des données structurer en script SQL
        {
            btnSauv.Enabled = true;
            InsertSql sql = new InsertSql();

            String table = nomsFichier;
            try
            {
                sql.setTable(table);   //Défini le nom de la table
                sql.setChamps(valeursFichier[0]);  //Défini la valeur des champs
                sql.setValeurs(valeursFichier);    //Défini la chaine de caractère des données à importer
                request = sql.requestSql();   //Assemble la requête SQL

                MessageBox.Show(request);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    //En cas de problème, affiche l'erreur
            }
        }
    }
}
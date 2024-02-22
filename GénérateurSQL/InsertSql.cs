using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GénérateurSQL
{
    internal class InsertSql
    {
        //Attributs privés
        private String table;   //Correspond au nom de la table
        private String lesChamps;   //Correspond au(x) champ(s) de la table
        private String valeurs;   //Correspond aux données à insérer


        //Accesseurs
        public void setTable(String ptable)
        {
            this.table = ptable;
        }

        public String getTable()
        {
            return this.table;
        }

        public void setChamps(String pchamps)
        {
            String[] unChamp = pchamps.Split(';'); //On récupère dans unChamp sous forme de tableau les champs contenu dans la chaine de caractère pchamps

            String lesChamps = "";

            for (int i = 0; i < unChamp.Length; i++)    //On concatène chaque champ pour qu'ils puissent être inséré dans une requête sql
            {
                if (i < unChamp.Length - 1)
                {
                    lesChamps = lesChamps + "`" + unChamp[i] + "`" + ",";
                }
                else
                {
                    lesChamps = lesChamps + "`" + unChamp[i] + "`";
                }
            }

            this.lesChamps = lesChamps; //On enregistre les champs prêt à être utilisé dans l'attribut lesChamps
        }

        public String getlesChamps()
        {
            return this.lesChamps;
        }

        public void setValeurs(String[] valeurs)
        {
            String lesValeurs = "";  // Contiendra les valeurs finales

            /* Le foreach nous a empêché de mettre certaines restrictions, pour faciliter ce cas de figure, on a 
             * préféré une boucle "for" classique.*/

            for (int k = 0; k < valeurs.Length; k++)
            {
                String valeur = valeurs[k];
                if (valeur != valeurs[0]) //La première cellule de valeurs contient le nom des champs, on évite de les insérer comme des valeurs.
                {
                    String[] uneValeur = valeur.Split(';'); //On sépare une ligne en colonnes
                    if (k != valeurs.Length - 1)    //Tant qu'on est pas dans le dernier enregistrement, on m
                    {
                        lesValeurs += "(";
                        for (int j = 0; j < uneValeur.Length; j++)  //On concatène chaque donnée pour former un enregistrement pour qu'il puisse être inséré dans une requête sql
                        {
                            if (j < uneValeur.Length - 1)
                            {
                                lesValeurs += "\"" + uneValeur[j] + "\""  + ", ";
                            }
                            else
                            {
                                lesValeurs += "\"" + uneValeur[j] + "\"";
                            }
                        }
                        lesValeurs += "), ";
                    }
                    else   //Sinon, c'est le dernier enregistrement, alors on ne met pas la dernière virgule
                    {
                        lesValeurs += "(";
                        for (int j = 0; j < uneValeur.Length; j++)
                        {
                            if (j < uneValeur.Length - 1)
                            {
                                lesValeurs += "\"" + uneValeur[j] + "\"" + ", ";
                            }
                            else
                            {
                                lesValeurs += "\"" + uneValeur[j] + "\"";
                            }
                        }
                        lesValeurs += ") ";
                    }
                }
            }

            this.valeurs = lesValeurs; //Renvoie les données concaténées, prête à être inséré dans une requête sql
        }

        public String getValeurs()
        {
            return this.valeurs;
        }

        //Méthodes
        public String requestSql()
        {
            try
            {
                String requeteSql = "INSERT INTO " + this.table + " (" + this.lesChamps + ") VALUES " + this.valeurs + ";"; //Concatène les différents objets courant pour former la requête

                return requeteSql; //Renvoie la chaine de caractère qui compose la requête sql
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "Echec";
            }
        }
    }
}

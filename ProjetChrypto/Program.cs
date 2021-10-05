using System;

namespace ProjetChrypto
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Entrez votre message");
            string input = Console.ReadLine();

            Console.WriteLine("Clé de cryptage");
            int key = int.Parse(Console.ReadLine());
            
            string simple = supprime_interdit(input);
            Console.WriteLine("message simplifié : " + simple);

            string crypte = cryptage_chaine(simple, key);
            Console.WriteLine("message crypté : " + crypte);

            decrypte_brut(crypte);
        }

        /// <summary>
        /// Convertie la chaine en minuscule
        /// </summary>
        /// <param name="s">chaine qui va être transformé</param>
        /// <returns>renvoie la chaine s en miniscule</returns>
        public static string Lower(string s)
        {
            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c >= 'A' && c <= 'Z')
                {
                    char nC = (char) (c + 32);
                    res = res + nC;
                }
                else
                {
                    res = res + c;
                }
            }

            return res;
        }
        
        /// <summary>
        /// renvoie une chaine de caractère composé seulement des 26 lettres de l'alphabet en minuscule.
        /// </summary>
        /// <param name="s">chaine de caractère qui va être modifier</param>
        /// <returns>variable "s" sans les caractère interdit</returns>
        public static string supprime_interdit(string s)
        {
            string us = Lower(s);
            string res = "";
            int size = us.Length;
            for (int i = 0; i < size; i++)
            {
                if (us[i] >= 'a' && us[i] <= 'z')
                {
                    res = res + us[i];
                }
            }
            return res;
        }

        /// <summary>
        /// Renvoie le message crypté par rapport à la clé.
        /// </summary>
        /// <param name="s">Chaine qui va être cryptée</param>
        /// <param name="key">clé de cryptage (décalage des caractères de key fois)</param>
        /// <returns>Retourne la chaine cryptée</returns>
        public static string cryptage_chaine(string s, int key)
        {
            int size = s.Length;
            string res = "";
            for (int i = 0; i < size; i++)
            {
                char newChar = (char) (s[i] + key);
                if (newChar > 'z')
                {
                    newChar = (char) (('a' - 1) + (newChar - 'z'));
                }
                res = res + newChar;
            }

            return res;
        }

        public static string decryptage_chaine(string s, int key)
        {
            int size = s.Length;
            string res = "";
            for (int i = 0; i < size; i++)
            {
                char newChar = (char) (s[i] - key);
                if (newChar < 'a')
                {
                    newChar = (char) (('z' + 1) - ('a' - newChar));
                }
                res = res + newChar;
            }

            return res;
        }

        public static void decrypte_brut(string s)
        {
            int key = 0;
            int good = 0;
            Console.WriteLine("Début -> décryptage");

            while (good == 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Décryptage avec la clé : " + key);
                Console.WriteLine("result -> " + decryptage_chaine(s, key));
                Console.WriteLine("La clé est elle correcte ? (1=oui/0=non)");
                good = int.Parse(Console.ReadLine());
                if (good != 0 && good != 1)
                {
                    good = 0;
                }
                if (good == 0)
                {
                    key++;
                }
            }

            Console.WriteLine("Decryptage du message : " + decryptage_chaine(s, key));
        }

        public static int nb_occurrence(string s, char c)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    count++;
                }
            }
            return count;
        }

        public static char lettre_maximum_nb_occurrence(string s, string already)
        {
            char more = s[0];
            int nb = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char cc = s[i];
                int nbOcc = nb_occurrence(s, cc);
                if (nb_occurrence(s, cc) > nb)
                {
                    bool al = false;
                    for (int j = 0; j < already.Length && !al; i++)
                    {
                        if (already[j] == cc)
                        {
                            al = true;
                        }
                    }

                    if (al)
                    {
                        nb = nbOcc;
                        more = cc;   
                    }
                }
            }

            return more;
        }
    }
}
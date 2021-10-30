using System;
using System.Collections.Generic;


namespace ApplicationMiniLoterie
{
    internal class Program
    {
        static void Main(string[] args)
        {            
           Program program = new();
            program.MessageBienvenue();
            program.Jouer();                       
        }
        // Fonction qui demarre le jeu aussi lontemps que l'utilisateur veut jouer
        private void Jouer()
        {
            List<int> generateur = GeneratorIntegerNumber1To200();
            List<int> utilisateur = Saisir5IntegerNumber();
            Resultat(utilisateur,generateur);
        }
        // Fonction qui affiche un message de bienvenue dans la console
        private void MessageBienvenue()
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("*************** Bienvenue dans le jeu Lotterie Cookie *********************");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine();
            Console.WriteLine();
        }
        // Fonction qui genere 100 nombres aleatoire  distincts compris entre 1 et 200
        // et qui retourne la liste
        private List<int> GeneratorIntegerNumber1To200()
        {
            int indice = 0;            
            List<int> liste = new();
            Random random = new Random();
            while(indice < 200)
            {
                int valeur = random.Next(1,201);
                if(!liste.Exists(x => x == valeur) && liste.Count< 100) // si le nombre n'existe pas on on l'ajoute
                {

                    liste.Add(valeur);
                }
                indice++;
            }
            return liste;
        }
        //Fonction qui permet de saisir 5 nombres entiers valide entre 1 et 200
        private List<int> Saisir5IntegerNumber()
        {
            List<int> liste = new List<int>();
            Console.WriteLine("***** Veuillez saisir vos 5 nombres en 1 et 200 ***");
            while (liste.Count < 5)
            {
                Console.WriteLine("Entrer un nombre et appuyer sur entrer: ");
                string SaisieUtilisateur = Console.ReadLine();
                bool resultat = int.TryParse(SaisieUtilisateur, out int valeur);

                if (resultat && Validation(valeur))
                {
                    liste.Add(valeur);
                }
                else
                {
                    MessageUtilisateur();
                }
            }
            return liste;
        }
        // Fonction qui valide le nombre saisie par l'utilisateur 
        // qui doit etre compris entre 1 et 200
        private bool Validation(int valeur)
        {
             return  valeur >= 1 && valeur <= 200;
        }
        // Fonction qui affiche un message Utilisateur sur la console
        private void MessageUtilisateur()
        {
            Console .WriteLine("Veuillez entrer un nombre compris entre 1 et 200 seulement");
        }
        // Fonction qui valide le resultat de la lotterie 
        // Et qui affiche les numeros  obtenu par  l'Utilisateur
        private void Resultat(List<int> liste1, List<int> liste2)
        {
            Console.WriteLine("***************** Résultat **********************");
            string choice;
            List<int> resulat = new();
            foreach (int val in liste1)
            {
                if (liste2.Exists(x => x == val))
                    resulat.Add(val);
            }
            Console.WriteLine("Vous avez obtenu les "+ resulat.Count+ " numéros suivants:");
            foreach (int items in resulat)
            {
                Console.WriteLine(items);
            }
            // On demande a l'utilsateur s'il desire jouer à une nouvelle partie
            Console.WriteLine();
            Console.WriteLine("Voullez-vous encore jouer (O/N) ?");
            choice = Console.ReadLine().ToLower();
            while (!choice.Equals("o") && !choice.Equals("n"))
            {
                Console.WriteLine("Voullez-vous encore jouer (O/N) ?");
                choice = Console.ReadLine();
            }
            switch (choice)
            {
                case "o":
                    Jouer();
                    break;
                case "n":
                    Environment.Exit(0);
                    break;
            }
            
        }
        
    }
}

using System;

// ref devant variables de fonction = référence à une variable
// in = lecture seule

namespace App
{
    // Classe parente
    abstract class Oeuvre
    {
        // Structure
        protected string Titre { get; set; }

        public Oeuvre(string Titre) {
            this.Titre = Titre;
        }

    }

    // Classe enfant de la classe Oeuvre
    class Album : Oeuvre
    {
        // Structure
        public string Artiste { get; set; }
        public int Annee { get; set; }
        public int NombreTracks { get; set; }
        public int Duree { get; set; }

        // Constructeur
        public Album(string Titre, string Artiste, int Annee, int NombreTracks, int Duree) : base(Titre)
        {
            this.Titre = Titre;
            this.Artiste = Artiste;
            this.Annee = Annee;
            this.NombreTracks = NombreTracks;
            this.Duree = Duree;
        }

        // Fonction ToString, permet d'effectuer un write sur un album
        public override string ToString()
        {
            string texte = "Titre : " + this.Titre + "\n";
            texte += "Artiste : " + this.Artiste + "\n";
            texte += "Année : " + this.Annee + "\n";
            texte += "Nombre de tracks : " + this.NombreTracks + "\n";
            texte += "Durée : " + this.Duree + " minutes";
            return(texte);
        }

        // Fonction +, permet d'ajouter deux albums
        public static Album operator +(Album a, Album b)
        {
            string nouveauTitre = a.Titre + " & " + b.Titre;
            string nouvelArtiste = a.Artiste + " & " + b.Artiste;
            int nouvelleAnne = Math.Min(a.Annee, b.Annee);
            int nouveauNombre = a.NombreTracks + b.NombreTracks;
            int nouvelleDuree = a.Duree + b.Duree;
            Album ab = new Album(nouveauTitre, nouvelArtiste, nouvelleAnne, nouveauNombre, nouvelleDuree);
            return(ab);
        }

        // Fonctions true et false, permettent de vérifier si un album est vrai
        public static bool operator true(Album a) => a.Duree > 0;
        public static bool operator false(Album a) => a.Duree <= 0;
    }

    // Classe principale main
    class Program
    {
        static void Main(string[] args) {
            Album album1 = new Album("Black Holes & Revelations", "Muse", 2006, 12, 45);
            Album album2 = new Album("Forever (Deluxe Edition)", "Don Diablo", 2021, 28, 82);
            Album mixTape = album1 + album2;

            System.Console.WriteLine("Album 1 :\n" + album1 + "\n");
            System.Console.WriteLine("Album 2 :\n" + album2 + "\n");
            System.Console.WriteLine("Mixtape :\n" + mixTape + "\n");
        }
    }
}


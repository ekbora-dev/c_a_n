using System;
using System.Text;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
class projet
{
	static void Main()
	{

		Dictionary<string,Dictionary<string,int>> jourA =creerlg();
		Dictionary<string,Dictionary<string,int>> jourB =creergl();
		Dictionary<string,Dictionary<string,int>> jourC =creerqlep();
		Dictionary<string,Dictionary<string,int>> jourD =creerleq();
		menu(jourA, jourB,jourC, jourD);
	}
	public struct Pass //structure d'un passager
	{
		public string nom;
		public string prenom;
		public string categorie;
		public Pass(string n, string p , string c)
		{
			nom=n;
			prenom=p;
			categorie=c;
		}
	}
	public struct Ve  // structure d'un vehicule 
	{
		public string categorie;
		public int quantite;
		public Ve(string cat, int quant)
		{
			categorie=cat;
			quantite=quant;
		}
	}
	public struct Res // structure de la reservation
	{
		public string nomfam;
		public int liaison;
		public string date;
		public string heure;
		public Res(string n,string h,string d, int l)
		{
			nomfam=n;
			liaison=l;
			date=d;
			heure=h;
		}
	}
	public static Dictionary<string,Dictionary<string,int>> creerlg()
	/*
        Une fonction qui permet de créer le tableau des possibilités de réservations pour chacun des trajets.
        Chaque trajet est représenté par un dictionnaire de dictionnaires qui contient les jours, les horaires et un compteur.
        Exemples :
        >>> reservation()
        >>> reservation()
       
        Description : Charge les horaires de traversée depuis un fichier texte (logroix.txt) 
                    et les convertit en une structure de données exploitable
        
        Fonctionnement : 
         - Lit le fichier ligne par ligne à l'aide d'un StreamReader 
         - Utilise des séparateurs (';' et '|') pour extraire les dates et les horaires
         - Initialise le nombre de places disponibles à 30 pour chaque créneau 
         
        Paramètres : Aucun.
         
        Retour : Un dictionnaire imbriqué (Dictionary<string, Dictionary<string, int>>) 
                  - Clé principale : La date du trajet (string).
                  - Valeur : Un dictionnaire associant l'heure (string) au nombre de places (int)
        */

	{
		Dictionary<string,Dictionary<string,int>> jourA = new Dictionary<string,Dictionary<string,int>>();	
                // création d'un dictionnaire pour la première traversée
                        // ouverture d'un fichier rempli avec les horaires en mode lecture
			string path="logroix.txt";
                	FileStream fs = new FileStream("logroix.txt", FileMode.Open, FileAccess.Read);
                	StreamReader logroix = new StreamReader(path);
                	if(File.Exists("logroix.txt"))
                	{
                	        while(!logroix.EndOfStream)
                	        {
					// création du dictionnaire contenant tous les horaires et les places restantes
                	                string ligne =logroix.ReadLine();
                	                char[] separateur =new char[] {';'};
                	                string[] temp =ligne.Split(separateur);
					char[] separateur2 =new char[] {'|'};
                	                string[] temp2 =ligne.Split(separateur2);
					// utilisation d'un dictionnaire temporaire pour l'imbriquer dans jourA
					Dictionary<string,int> tempdik1 = new Dictionary<string,int>();
					//remplissage de jourA
					for(int i =1; i<=temp2.Length-1; i++)
					{
						tempdik1.Add(temp2[i],30);
					}
					jourA.Add(temp[0],tempdik1);
				}
				

			}
			//fermeture du fichier txt
			logroix.Close();
			return jourA;
	}
	// la fonction prend en paramètre jour A, B, C ou D afin de n’avoir qu’une seule fonction pour les quatre horaires
	public static void afficherhoraire(Dictionary<string,Dictionary<string,int>> jour)
		// cette fonction met dans une chaîne de caractères les lignes du tableau et les affiche au fur et à mesure 
	{
		//on parcourt les jours 
		foreach(string j in jour.Keys)
                {
   	             string chaine = j+"  ";
		     //on parcourt les horaires
                     foreach(string k in jour[j].Keys)
                     {
  	                   chaine+= k +"  "+ jour[j][k]+"  ";
                     }
                     Console.WriteLine(" "+chaine+" ");
                }
	}
	public static Dictionary<string,Dictionary<string,int>> creerqlep()
		// fonction pour créer un deuxième tableau (aller voir L65 pour plus de précision)
	{
		 Dictionary<string,Dictionary<string,int>> jourB = new Dictionary<string,Dictionary<string,int>>();	
               		string path="quibelait.txt";
                	FileStream fs = new FileStream("quibelait.txt", FileMode.Open, FileAccess.Read);
                	StreamReader quibelait = new StreamReader(path);
                	if(File.Exists("quibelait.txt"))
                	{
                	        while(!quibelait.EndOfStream)
                	        {
                	                string ligne =quibelait.ReadLine();
                	                char[] separateur =new char[] {';'};
                	                string[] temp =ligne.Split(separateur);
                	                char[] separateur2 =new char[] {'|'};
                	                string[] temp2 =ligne.Split(separateur2);
                	                Dictionary<string,int> tempdik2 = new Dictionary<string,int>();
                	                for(int i =1; i<=temp2.Length-1; i++)
                	                {
                	                        tempdik2.Add(temp2[i],30);
                	                }
                	                jourB.Add(temp[0],tempdik2);
                	        }
			}
		quibelait.Close();
		return jourB;	
	}
	public static Dictionary<string,Dictionary<string,int>> creergl()
	{
		// fonction pour créer un troisième tableau (aller voir L65 pour plus de précision)
		 Dictionary<string,Dictionary<string,int>> jourC = new Dictionary<string,Dictionary<string,int>>();
                	string path="groalo.txt";
                	FileStream fs = new FileStream("groalo.txt", FileMode.Open, FileAccess.Read);
                	StreamReader groalo = new StreamReader(path);
                	if(File.Exists("groalo.txt"))
                	{
                	        while(!groalo.EndOfStream)
                	        {
                	                string ligne =groalo.ReadLine();
                	                char[] separateur =new char[] {';'};
                	                string[] temp =ligne.Split(separateur);
                	                char[] separateur2 =new char[] {'|'};
                	                string[] temp2 =ligne.Split(separateur2);
                	                Dictionary<string,int> tempdik3 = new Dictionary<string,int>();
                	                for(int i =1; i<=temp2.Length-1; i++)
                	                {
                	                        tempdik3.Add(temp2[i],30);
                	                }
                	                jourC.Add(temp[0],tempdik3);
                	        }
			}
		groalo.Close();
		return jourC;
	}
	public static Dictionary<string,Dictionary<string,int>> creerleq()
		// fonction pour créer un quatrième tableau (aller voir L65 pour plus de précision)
	{
		Dictionary<string,Dictionary<string,int>> jourD = new Dictionary<string,Dictionary<string,int>>();
                	string path="lepaquiberon.txt";
               		FileStream fs = new FileStream("lepaquiberon.txt", FileMode.Open, FileAccess.Read);
                	StreamReader lepaquiberon= new StreamReader(path);
                	if(File.Exists("lepaquiberon.txt"))
                	{
                	        while(!lepaquiberon.EndOfStream)
                	        {
                       		        string ligne =lepaquiberon.ReadLine();
                               		char[] separateur =new char[] {';'};
                                	string[] temp =ligne.Split(separateur);
                                	char[] separateur2 =new char[] {'|'};
                                	string[] temp2 =ligne.Split(separateur2);
                                	Dictionary<string,int> tempdik4 = new Dictionary<string,int>();
                                	for(int i =1; i<=temp2.Length-1; i++)
                                	{
                                	        tempdik4.Add(temp2[i],30);
                                	}
                                	jourD.Add(temp[0],tempdik4);
                        	}
				lepaquiberon.Close();
			}
		lepaquiberon.Close();	
		return jourD;
	}
	public static void reservation(Dictionary<string,Dictionary<string,int>> jour)
		// fonction pour décrémenter les places sur le bateau 
	{
		// demande à l'utilisateur les modalités de son voyage
		afficherhoraire(jour);
		Console.WriteLine("Quel jour souhaitez-vous réserver ? (Veuillez copier exactement tel qu'affiché) :\n");
		string choixjour = Console.ReadLine().Trim();
		if(jour.ContainsKey(choixjour))
		{
			 Console.WriteLine("Quel horaire souhaitez-vous réserver ?\n");
                         string choixhoraire = Console.ReadLine().Trim();
			 Console.WriteLine("Combien de passagers et de véhicules y a-t-il pour cette réservation ?\n");
                         int nbpersonne = int.Parse(Console.ReadLine().Trim());
			 //décrémentation du tableau 
		         jour[choixjour][choixhoraire] -= nbpersonne;
		}
	}


	public static void menu(Dictionary<string,Dictionary<string,int>> jourA, Dictionary<string,Dictionary<string,int>> jourB,Dictionary<string,Dictionary<string,int>> jourC,Dictionary<string,Dictionary<string,int>> jourD)
	{
		// le menu est la plus grande fonction : elle gère le déroulement de la réservation
		if(File.Exists("final.json"))
		{
			// ouverture d'un fichier en mode écriture (il aura été vidé de tout test avant le rendu)
			FileStream fs = new FileStream("final.json",FileMode.Create, FileAccess.Write);
			StreamWriter final = new StreamWriter(fs);
			final.WriteLine("[{");
			// demande à l'utilisateur ce qu'il souhaite faire 
		Console.WriteLine("Que souhaitez-vous effectuer ? Veuillez saisir le chiffre correspondant à votre choix\n1) Voir les horaires de traversée\n2) Voir les tarifs\n3) Réserver une traversée\n0) Quitter\n");
		int n=int.Parse(Console.ReadLine().Trim());
		//choix de consultation des horaires
		if(n==1)
		{
			// demande quels horaires il souhaite voir
			Console.WriteLine("De quelle traversée souhaitez-vous consulter les horaires et disponibilités ? Veuillez saisir le chiffre correspondant à la traversée\n1) Lorient -> Groix\n2) Groix -> Lorient\n3) Quiberon -> Le Palais\n4) Le Palais -> Quiberon\n");
			int m=int.Parse(Console.ReadLine().Trim());
			// en fonction de la réponse, on appelle afficherHoraire avec un paramètre différent

			if(m==1)
			{
				afficherhoraire(jourA);
			}
			else if(m==2)
			{
				afficherhoraire(jourB);
			}
			else if(m==3)
			{
				afficherhoraire(jourC);
			}
			else if(m==4)
			{
				afficherhoraire(jourD);
			}
			
		}
		//choix de voir les horaires 
		else if(n==2)
		{
			// voir la fin du code pour la fonction afficherTarifs 
			affichertarifs();
		}
		//choix de faire une reservation 
		else if(n==3)
		{
			// demande pour quelle traversée et horaire il souhaite faire une réservation 
			Console.WriteLine("Quelle traversée souhaitez-vous réserver ? Veuillez saisir le chiffre correspondant à la traversée\n1) Lorient -> Groix \n2) Groix -> Lorient \n3) Quiberon -> Le palais \n4) Le palais -> Quiberon\n");
                        int m=int.Parse(Console.ReadLine().Trim());
			
                        if(m==1)
                        {
                                reservation(jourA);
				// récupération de la date locale de l'ordi
				DateTime localdate = DateTime.Now;
				//demande de précision
				Console.WriteLine("Veuillez entrer votre nom de famille, s’il vous plaît : ");
                                string nomfam = Console.ReadLine().Trim();
                                Console.WriteLine("Veuillez confirmer le jour :");
                                string choixjour = Console.ReadLine().Trim();
                                Console.WriteLine("Veuillez confirmer l’heure de la réservation :");
                                string choixhoraire = Console.ReadLine().Trim();
				//création de l'objet resa1 de type reservation
                                Res resa1 = new Res(nomfam, choixhoraire, choixjour, 1);
				//ajout dans le fichier json
				final.WriteLine("	\"reservation\":\n		{\n			\"nom\":\""+resa1.nomfam+"\",\n			\"idLiaison\":1,\n			\"date\":\""+resa1.date+"\",\n			\"heure\":\""+resa1.heure+"\",\n			\"horodatage\":\""+localdate+"\"\n		},");
				Console.WriteLine("Veuillez à nouveau préciser le nombre de passagers et de véhicules : ");
                                int nbpers = int.Parse(Console.ReadLine().Trim());
                                double apayer=0;
				Console.WriteLine("Combien de personnes y a-t-il dans ce total ?");
				int nbgens = int.Parse(Console.ReadLine().Trim());
				final.WriteLine("	\"passagers\": [");
                                for(int i=0; i<nbgens; i++)
                                {
				        // en fonction du type de la personne, on va créer le passager et l'ajouter dans le JSON tout en incrémentant le total à payer 
                 	               Console.WriteLine("À quelle catégorie appartient le passager n° "+(i+1)+" ? Veuillez saisir l’un des codes suivants : \n- adu26p (adulte de 26 ans et plus)\n- je1825 (jeune de 18 à 25 an INCLUS) \n- enf417 (enfant de 4 à 17 ans INCLUS)\n- bebe (bébé de moins de 4 ans)\n- ancomp (animal de compagnie)\n");
                                       string type = Console.ReadLine().Trim().ToLower();
                                       if(type == "adu26p")
                                       {
						Console.WriteLine("Veuillez saisir son nom de famille : ");
                                       		string nompers=Console.ReadLine().Trim();
                                       		Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                       		string prenompers=Console.ReadLine().Trim();
                                       		Pass personne = new Pass(nompers, prenompers, type);
                                       		apayer += 18.75;
						final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
					}
                                               else if(type == "je1825")
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 13.80;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else if(type == "bebe")
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }                                   
                                                else if(type == "enf417")	
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 11.25;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
						else
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 3.35;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                 }
					if(i==nbgens-1)
					{
						final.WriteLine("		}");
					}
					else
					{
						final.WriteLine("		},");
					}
					}
					Console.WriteLine("Voici les différentes catégories de véhicules acceptés à bord :\n- trottinette électrique\n- vélo ou remorque à vélo \n- vélo électrique \n- vélo cargo ou tandem \n- deux-roues <= 125 cm3 \n- moto (deux-roues > 125 cm3) \n- voiture de moins de 4 m \n- voiture de 4 m à 4.39 m \n- voiture de 4.40 m à 4.79 m \n- voiture de 4.80 m et plus \n- camping-car/véhicule de plus de 2.10 m de haut\nVeuillez saisir le nombre de véhicules de types DIFFERENTS de votre réservation en suivant l'exemple suivant :\nExemple : sur 12 véhicules => 3 sont des trottinettes électriques, 4 sont des vélos, 5 sont des voitures de moins de 4 m\nJe rentre donc 3.\nVeuillez saisir le nombre de types de véhicules différents dans votre réservation : ");
					int nbvoit = int.Parse(Console.ReadLine().Trim());
					final.WriteLine("	],");
					final.WriteLine("	\"vehicules\": [");
					for(int i=0; i<nbvoit; i++)
						//pareil pour les vehicules 
					{
						Console.WriteLine("Enregistrement par type de véhicule (et non par nombre) :\n Quel est le type n°"+(i+1)+" de véhicule à enregistrer pour votre réservation ? Veuillez saisir l’un des codes suivants :\n- trot (trottinette électrique)\n- velo (vélo ou remorque à vélo) \n- velelec (vélo électrique) \n- cartand (vélo cargo ou tandem) \n- mobil (deux-roues <= 125 cm3) \n-moto (deux-roues > 125 cm3) \n- cat1 (voiture moins de 4 m) \n- cat2 (voiture de 4 m à 4.39 m) \n- cat3 (voiture de 4.40 m à 4.79 m) \n- cat4 (voiture 4.80 m et plus) \n- camp (camping-car/véhicule plus de 2.10 m de haut)\n");
                                                string type = Console.ReadLine().Trim().ToLower();
                                                if(type == "trot")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de trottinettes électriques à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 4.70*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
						}
                                                else if(type == "velo")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de vélos ou de remorques à vélo à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 8.20*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "velelec")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de vélos électriques à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 11*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cartand")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de vélos cargo ou de tandems à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 16.45*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "mobil")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de deux-roues de 125 cm³ ou moins à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 23.10*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "moto")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de deux-roues de plus de 125 cm³ à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 66.05*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cat1")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de moins de 4 m à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 96.05*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cat2")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de 4 m à 4,39 m à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 114.80*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cat3")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de 4,40 m à 4,79 m à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 174.45*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":"+bagnole.quantite);
                                                }
                                                 else if(type == "cat4")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de 4,80 m et plus à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 210.90*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "camp")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de camping-cars/véhicules plus de 2.10 m de haut à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 330.20*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":"+bagnole.quantite);
                                                }
					 if(i==nbvoit-1)
                                        {
                                                final.WriteLine("		}");
                                        }
                                        else
                                        {
                                                final.WriteLine("		},");
                                        }
					}
					final.WriteLine(	"]");
					//on renvoie le total à payer
					Console.WriteLine("Le montant à payer s'élève à " + apayer + " €");
			}
                        else if(m==2)
				// même chose pour un horaire différent (voir L265)
                        {
                                reservation(jourB);
				DateTime localdate = DateTime.Now;
				Console.WriteLine("Veuillez entrer votre nom de famille, s’il vous plaît : ");
                                string nomfam = Console.ReadLine().Trim();
                                Console.WriteLine("Veuillez confirmer le jour : ");
                                string choixjour = Console.ReadLine().Trim();
                                Console.WriteLine("Veuillez confirmer l’heure de la réservation : ");
                                string choixhoraire = Console.ReadLine().Trim();
                                Res resa2 = new Res(nomfam, choixhoraire, choixjour, 2);
				final.WriteLine("       \"reservation\":\n          {\n                  \"nom\":\""+resa2.nomfam+"\",\n                  \"idLiaison\":2,\n                  \"date\":\""+resa2.date+"\",\n                  \"heure\":\""+resa2.heure+"\",\n                  \"horodatage\":\""+localdate+"\"\n            },");
				Console.WriteLine("Veuillez à nouveau préciser le nombre de passagers et de véhicules : ");
                                int nbpers = int.Parse(Console.ReadLine().Trim());
                                double apayer=0;
				Console.WriteLine("Combien de personnes y a-t-il dans ce total ? ");
                                int limite = int.Parse(Console.ReadLine().Trim());
				final.WriteLine("       \"passagers\": [");
                                for(int i=0; i<nbpers; i++)
                                {
                                        Console.WriteLine("Enregistrement :\nPour enregistrer un passager (personne ou véhicule), veuillez saisir son type :\n - personne\n - vehicule \n");
                                        string binairetype=Console.ReadLine().Trim().ToLower();
                                        if(binairetype == "personne")
                                        {
                                                Console.WriteLine("À quelle catégorie appartient-elle ? Veuillez saisir l’un des codes suivants : \n- adu26p (adulte de 26 ans et plus)\n- je1825 (jeune de 18 à 25 an INCLUS) \n- enf417 (enfant de 4 à 17 ans INCLUS)\n- bebe (bébé de moins de 4 ans)\n- ancomp (animal de compagnie)\n");
                                                string type = Console.ReadLine().Trim().ToLower();
                                                if(type == "adu26p")
                                                {
							Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
							apayer += 18.75;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n		        \"codeCategorie\":\""+personne.categorie+"\"");
						}
                                                else if(type == "je1825")
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 13.80;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else if(type == "bebe")
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille :");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else if(type == "enf417")
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 11.25;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 3.35;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                              	if(i==limite-1)
                                        	{
                                                	final.WriteLine("		}");
                                        	}
                                        	else
                                        	{
                                                	final.WriteLine("		},");
                                        	}
					
                                        }
                                        else
                                        {
						final.WriteLine("	],");
                                                final.WriteLine("	\"vehicules\": [");
						for(int j=i; j<nbpers; j++)
						{
						i+=1;
                                                Console.WriteLine("Quel est le type du véhicule ? Veuillez saisir l’un des codes suivants :\n- trot (trottinette électrique)\n- velo (vélo ou remorque à vélo) \n- velelec (vélo électrique) \n- cartand (vélo cargo ou tandem) \n- mobil (deux-roues <= 125 cm3) \n- moto (deux-roues > 125 cm3) \n- cat1 (voiture moins de 4 m) \n- cat2 (voiture de 4 m à 4.39 m) \n- cat3 (voiture de 4.40 m à 4.79 m) \n- cat4 (voiture 4.80 m et plus) \n- camp (camping-car/véhicule plus de 2.10 m de haut)\n");
                                                string type = Console.ReadLine().Trim().ToLower();
                                                if(type == "trot")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de trottinettes électriques à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 4.70*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "velo")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de vélos ou de remorques à vélo à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 8.20*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "velelec")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de vélos électriques à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 11*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cartand")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de vélos cargo ou de tandems à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 16.45*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "mobil")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de deux-roues de 125 cm³ ou moins à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 23.10*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "moto")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de deux-roues de plus de 125 cm³ à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 66.05*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cat1")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de moins de 4 m à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 96.05*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cat2")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de 4 m à 4,39 m à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 114.80*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cat3")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de 4,40 m à 4,79 m à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 174.45*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                 else if(type == "cat4")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de 4,80 m et plus à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 210.90*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "camp")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de camping-cars/véhicules plus de 2.10 m de haut à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 330.20*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
					if(i==nbpers-1)
                                        {
                                                final.WriteLine("		},");
                                        }
                                        else
                                        {
                                                final.WriteLine("		}");
                                        }
						}
                                        }
                                }
				final.WriteLine("	]");
				Console.WriteLine("Le montant à payer s'élève à " + apayer + " €");
			}
                        else if(m==3)
                        {
				// même chose pour un horaire différent (voir L265)
                                reservation(jourC);
				DateTime localdate = DateTime.Now;
				Console.WriteLine("Veuillez entrer votre nom de famille, s’il vous plaît :");
                                string nomfam = Console.ReadLine().Trim();
                                Console.WriteLine("Veuillez confirmer le jour :");
                                string choixjour = Console.ReadLine().Trim();
                                Console.WriteLine("Veuillez confirmer l’heure de la réservation :");
                                string choixhoraire = Console.ReadLine().Trim();
                                Res resa3 = new Res(nomfam, choixhoraire, choixjour, 3);
				final.WriteLine("       \"reservation\":\n          	{\n			\"nom\":\""+resa3.nomfam+"\",\n			\"idLiaison\":3,\n			\"date\":\""+resa3.date+"\",\n			\"heure\":\""+resa3.heure+"\",\n			\"horodatage\":\""+localdate+"\"\n		},");
				Console.WriteLine("Veuillez à nouveau préciser le nombre de passagers et de véhicules :");
                                int nbpers = int.Parse(Console.ReadLine().Trim());
                                double apayer=0;
				Console.WriteLine("Combien de personnes y a-t-il dans ce total ?");
				int limite = int.Parse(Console.ReadLine().Trim());
				final.WriteLine("       \"passagers\": [");
                                for(int i=0; i<nbpers; i++)
                                {
                                        Console.WriteLine("Enregistrement :\n Pour enregistrer un passager (personne ou véhicule), veuillez saisir son type :\n - personne\n - vehicule \n?");
                                        string binairetype=Console.ReadLine().Trim().ToLower();
                                        if(binairetype == "personne")
                                        {
                                                Console.WriteLine("À quelle catégorie appartient-elle ? Veuillez saisir l’un des codes suivants : \n- adu26p (adulte de 26 ans et plus)\n- je1825 (jeune de 18 à 25 an INCLUS) \n- enf417 (enfant de 4 à 17 ans INCLUS)\n- bebe (bébé de moins de 4 ans)\n- ancomp (animal de compagnie)\n");
                                                string type = Console.ReadLine().Trim().ToLower();
                                                if(type == "adu26p")
                                                {
							Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 18.8;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
						}
                                               else if(type == "je1825")
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 14.1;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else if(type == "bebe")
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else if(type == "enf417")
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 11.65;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom : ");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 3.35;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
					if(i==limite-1)
                                        {
                                                final.WriteLine("		}");
                                        }
                                        else
                                        {
                                                final.WriteLine("		},");
                                        }
                                        }
                                        else
                                        {
						final.WriteLine("	],");
                                                final.WriteLine("	\"vehicules\": [");
						for(int j=i; j<nbpers; j++)
						{
						i+=1;
                                                Console.WriteLine("Quel est le type du véhicule ? Veuillez saisir l’un des codes suivants :\n- trot (trottinette électrique)\n- velo (vélo ou remorque à vélo) \n- velelec (vélo électrique) \n- cartand (vélo cargo ou tandem) \n- mobil (deux-roues <= 125 cm3) \n- moto (deux-roues > 125 cm3) \n- cat1 (voiture moins de 4 m) \n- cat2 (voiture de 4 m à 4.39 m) \n- cat3 (voiture de 4.40 m à 4.79 m) \n- cat4 (voiture 4.80 m et plus) \n- camp (camping-car/véhicule plus de 2.10 m de haut)\n");
                                                string type = Console.ReadLine().Trim().ToLower();
                                                if(type == "trot")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de trottinettes électriques à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 4.70*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "velo")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de vélos ou de remorques à vélo à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 8.20*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "velelec")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de vélos électriques à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 11*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cartand")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de vélos cargo ou de tandems à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 16.45*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "mobil")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de deux-roues de 125 cm³ ou moins à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 23.35*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "moto")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de deux-roues de plus de 125 cm³ à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 66.40*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cat1")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de moins de 4 m à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 98.50*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cat2")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de 4 m à 4,39 m à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 117.20*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "cat3")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de 4,40 m à 4,79 m à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 176.90*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                 else if(type == "cat4")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de voitures de 4,80 m et plus à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 213.35*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
                                                else if(type == "camp")
                                                {
                                                        Console.WriteLine("Veuillez préciser la quantité de camping-cars/véhicules plus de 2.10 m de haut à enregistrer pour cette réservation : ");
                                                        int nbveh = int.Parse(Console.ReadLine().Trim());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 332.70*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                }
					if(i==nbpers-1)
                                        {
                                                final.WriteLine("		},");
                                        }
                                        else
                                        {
                                                final.WriteLine("		}");
                                        }
						}
                                        }
                                }
				final.WriteLine("	]");
				Console.WriteLine("Le montant à payer s'élève à " + apayer + " €");
			}
                        else if(m==4)
                        {
				// même chose pour un horaire différent (voir L265)
                                reservation(jourD);
				DateTime localdate = DateTime.Now;
				Console.WriteLine("Veuillez entrer votre nom de famille, s’il vous plaît :");
                                string nomfam = Console.ReadLine().Trim();
                                Console.WriteLine("Veuillez confirmer le jour :");
                                string choixjour = Console.ReadLine().Trim();
                                Console.WriteLine("Veuillez confirmer l’heure de la réservation :");
                                string choixhoraire = Console.ReadLine().Trim();
                                Res resa4 = new Res(nomfam, choixhoraire, choixjour, 4);
				final.WriteLine("       \"reservation\":\n		{\n			\"nom\":\""+resa4.nomfam+"\",\n			\"idLiaison\":4,\n			\"date\":\""+resa4.date+"\",\n			\"heure\":\""+resa4.heure+"\",\n			\"horodatage\":\""+localdate+"\"\n		},");

				Console.WriteLine("Veuillez à nouveau préciser le nombre de passagers et de véhicules :");
				int nbpers = int.Parse(Console.ReadLine().Trim());
				double apayer=0;
				Console.WriteLine("Combien de personnes y a-t-il dans ce total ?");
				int limite =int.Parse(Console.ReadLine().Trim());
				final.WriteLine("       \"passagers\": [");
				for(int i=0; i<nbpers; i++)
				{
					Console.WriteLine("Enregistrement :\n Pour enregistrer un passager (personne ou véhicule), veuillez saisir son type :\n - personne\n - vehicule \n");
					string binairetype=Console.ReadLine().Trim().ToLower();
					if(binairetype == "personne")
					{
						Console.WriteLine("À quelle catégorie appartient-elle ? Veuillez saisir l’un des codes suivants : \n- adu26p (adulte de 26 ans et plus)\n- je1825 (jeune de 18 à 25 an INCLUS) \n- enf417 (enfant de 4 à 17 ans INCLUS)\n- bebe (bébé de moins de 4 ans)\n- ancomp (animal de compagnie)\n");
						string type = Console.ReadLine().Trim().ToLower();
						if(type == "adu26p")
						{
							Console.WriteLine("Veuillez saisir son nom de famille : ");
							string nompers=Console.ReadLine().Trim();
							Console.WriteLine("Veuillez ensuite saisir son prénom :");
                                                        string prenompers=Console.ReadLine().Trim();
							Pass personne = new Pass(nompers, prenompers, type);
							apayer += 18.8;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
								
						}
						else if(type == "je1825")
						{
							Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom :");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 14.1;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
						}
						else if(type == "enf417")
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom :");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 11.65;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
						else if(type == "bebe")
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom :");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
						else
                                                {
                                                        Console.WriteLine("Veuillez saisir son nom de famille : ");
                                                        string nompers=Console.ReadLine().Trim();
                                                        Console.WriteLine("Veuillez ensuite saisir son prénom :");
                                                        string prenompers=Console.ReadLine().Trim();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 3.35;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
					if(i==limite-1)
                                        {
                                                final.WriteLine("		}");
                                        }
                                        else
                                        {
                                                final.WriteLine("		},");
                                        }
					}
					else
					{
						final.WriteLine("	],");
                                                final.WriteLine("       \"vehicules\": [");
						for(int j=i; j<nbpers; j++)
						{
                                                        i+=1;
                                                        Console.WriteLine("Quel est le type du véhicule ? Veuillez saisir l’un des codes suivants :\n- trot (trottinette électrique)\n- velo (vélo ou remorque à vélo) \n- velelec (vélo électrique) \n- cartand (vélo cargo ou tandem) \n- mobil (deux-roues <= 125 cm3) \n- moto (deux-roues > 125 cm3) \n- cat1 (voiture moins de 4 m) \n- cat2 (voiture de 4 m à 4.39 m) \n- cat3 (voiture de 4.40 m à 4.79 m) \n- cat4 (voiture 4.80 m et plus) \n- camp (camping-car/véhicule plus de 2.10 m de haut)\n");
                                                        string type = Console.ReadLine().Trim().ToLower();
                                                        if(type == "trot")
                                                        {
                                                                Console.WriteLine("Veuillez préciser la quantité de trottinettes électriques à enregistrer pour cette réservation : ");
                                                                int nbveh = int.Parse(Console.ReadLine().Trim());
                                                                Ve bagnole = new Ve(type,nbveh);
                                                                apayer += 4.70*nbveh;
                                                                final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                        }
                                                        else if(type == "velo")
                                                        {
                                                                Console.WriteLine("Veuillez préciser la quantité de vélos ou de remorques à vélo à enregistrer pour cette réservation : ");
                                                                int nbveh = int.Parse(Console.ReadLine().Trim());
                                                                Ve bagnole = new Ve(type,nbveh);
                                                                apayer += 8.20*nbveh;
                                                                final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                        }
                                                        else if(type == "velelec")
                                                        {
                                                                Console.WriteLine("Veuillez préciser la quantité de vélos électriques à enregistrer pour cette réservation : ");
                                                                int nbveh = int.Parse(Console.ReadLine().Trim());
                                                                Ve bagnole = new Ve(type,nbveh);
                                                                apayer += 11*nbveh;
                                                                final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                        }
                                                        else if(type == "cartand")
                                                        {
                                                                Console.WriteLine("Veuillez préciser la quantité de vélos cargo ou de tandems à enregistrer pour cette réservation : ");
                                                                int nbveh = int.Parse(Console.ReadLine().Trim());
                                                                Ve bagnole = new Ve(type,nbveh);
                                                                apayer += 16.45*nbveh;
                                                                final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                        }
                                                        else if(type == "mobil")
                                                        {
                                                                Console.WriteLine("Veuillez préciser la quantité de deux-roues de 125 cm³ ou moins à enregistrer pour cette réservation : ");
                                                                int nbveh = int.Parse(Console.ReadLine().Trim());
                                                                Ve bagnole = new Ve(type,nbveh);
                                                                apayer += 23.35*nbveh;
                                                                final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                        }
                                                        else if(type == "moto")
                                                        {
                                                                Console.WriteLine("Veuillez préciser la quantité de deux-roues de plus de 125 cm³ à enregistrer pour cette réservation : ");
                                                                int nbveh = int.Parse(Console.ReadLine().Trim());
                                                                Ve bagnole = new Ve(type,nbveh);
                                                                apayer += 66.40*nbveh;
                                                                final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                        }
                                                        else if(type == "cat1")
                                                        {
                                                                Console.WriteLine("Veuillez préciser la quantité de voitures de moins de 4 m à enregistrer pour cette réservation : ");
                                                                int nbveh = int.Parse(Console.ReadLine().Trim());
                                                                Ve bagnole = new Ve(type,nbveh);
                                                                apayer += 98.50*nbveh;
                                                                final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                        }
                                                        else if(type == "cat2")
                                                        {
                                                                Console.WriteLine("Veuillez préciser la quantité de voitures de 4 m à 4,39 m à enregistrer pour cette réservation : ");
                                                                int nbveh = int.Parse(Console.ReadLine().Trim());
                                                                Ve bagnole = new Ve(type,nbveh);
                                                                apayer += 117.20*nbveh;
                                                                final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                        }
                                                        else if(type == "cat3")
                                                        {
                                                                Console.WriteLine("Veuillez préciser la quantité de voitures de 4,40 m à 4,79 m à enregistrer pour cette réservation : ");
                                                                int nbveh = int.Parse(Console.ReadLine().Trim());
                                                                Ve bagnole = new Ve(type,nbveh);
                                                                apayer += 176.90*nbveh;
                                                                final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                        }
                                                        else if(type == "cat4")
                                                        {
                                                                Console.WriteLine("Veuillez préciser la quantité de voitures de 4,80 m et plus à enregistrer pour cette réservation : ");
                                                                int nbveh = int.Parse(Console.ReadLine().Trim());
                                                                Ve bagnole = new Ve(type,nbveh);
                                                                apayer += 213.35*nbveh;
                                                                final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                        }
                                                        else if(type == "camp")
                                                        {
                                                                Console.WriteLine("Veuillez préciser la quantité de camping-cars/véhicules plus de 2.10 m de haut à enregistrer pour cette réservation : ");
                                                                int nbveh = int.Parse(Console.ReadLine().Trim());
                                                                Ve bagnole = new Ve(type,nbveh);
                                                                apayer += 332.70*nbveh;
                                                                final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":"+bagnole.quantite);
                                                        }
                                                        if(i==nbpers-1)
                                                {
                                                        final.WriteLine("		},");
                                                }
                                                else
                                                {
                                                        final.WriteLine("		}");
                                                }
                                                        }
                                                }
					final.WriteLine("	]");
					Console.WriteLine("Le montant à payer s'élève à " + apayer + " €");
				}
			}
		}
		// on demande si la personne souhaite s'arrêter ; dans ce cas, on ferme le fichier, sinon on relance le menu 
			Console.WriteLine("\nVoulez vous quitter ? Taper O pour OUI et N pour NON\n");
                        string test=Console.ReadLine().Trim().ToUpper();
                        if(test=="N")
                        {
				final.Close();
				menu(jourA, jourB, jourC, jourD);
                        }
			else
			{
				final.WriteLine("}]");
				final.Close();
			}
		}

	}
        // fonction pour afficher la grille des tarifs au début 
	public static void affichertarifs()
	{
                int largeurTotale = 70; // Largeur du bloc d'affichage

                Console.WriteLine("\n"); 

                // SECTION PASSAGERS
                string titreP = "TARIFS PASSAGERS 2025 - Compagnie Alsacienne de Navigation : \n";
                //centrage du titre : on ajoute des espaces à gauche pour le placer au milieu
                Console.WriteLine(titreP.PadLeft((largeurTotale + titreP.Length) / 2));

                // Utilisation de PadRight pour que chaque colonne commence au même endroit
                // tarifs
                Console.WriteLine("  ".PadRight(32) + "Groix :".PadRight(15) + "Belle-Ile :");
                Console.WriteLine("  " + "Catégorie (Code) :\n");
                Console.WriteLine("  " + "Adulte (adu26p)".PadRight(30) + "18,75 €".PadRight(15) + "18,80 €");
                Console.WriteLine("  " + "Jeune (jeu1825)".PadRight(30) + "13,80 €".PadRight(15) + "14,10 €");
                Console.WriteLine("  " + "Enfant (enf417)".PadRight(30) + "11,25 €".PadRight(15) + "11,65 €");
                Console.WriteLine("  " + "Bébé (bebe)".PadRight(30) + "Gratuit".PadRight(15) + "Gratuit");
                Console.WriteLine("  " + "Animal (ancomp)".PadRight(30) + "3,35 €".PadRight(15) + "3,35 €");

                Console.WriteLine("\n"); // Espace entre les deux blocs

                // SECTION VÉHICULES
                string titreV = "TARIFS VÉHICULES 2025 - Compagnie Alsacienne de Navigation : \n";
                Console.WriteLine(titreV.PadLeft((largeurTotale + titreV.Length) / 2));

                //tarifs 
                Console.WriteLine("   ".PadRight(33) + "Groix :".PadRight(15) + "Belle-Ile :");
                Console.WriteLine("   " + "Catégorie (Code) :\n");
                Console.WriteLine("   " + "Trottinette (trot)".PadRight(30) + "4,70 €".PadRight(15) + "4,70 €");
                Console.WriteLine("   " + "Vélo (velo)".PadRight(30) + "8,20 €".PadRight(15) + "8,20 €");
                Console.WriteLine("   " + "Vélo élec (velelec)".PadRight(30) + "11,00 €".PadRight(15) + "11,00 €");
                Console.WriteLine("   " + "Tandem (cartand)".PadRight(30) + "16,45 €".PadRight(15) + "16,45 €");
                Console.WriteLine("   " + "Moto <= 125 (mobil)".PadRight(30) + "23,10 €".PadRight(15) + "23,35 €");
                Console.WriteLine("   " + "Moto >125 (moto)".PadRight(30) + "66,05 €".PadRight(15) + "66,40 €");
                Console.WriteLine("   " + "Voiture < 4m (cat1)".PadRight(30) + "96,05 €".PadRight(15) + "98,50 €");
                Console.WriteLine("   " + "Voiture 4m-4.39m (cat2)".PadRight(30) + "114,80 €".PadRight(15) + "117,20 €");
                Console.WriteLine("   " + "Voiture 4.4m-4.79m (cat3)".PadRight(30) + "174,45 €".PadRight(15) + "176,90 €");
                Console.WriteLine("   " + "Voiture >= 4.80m (cat4)".PadRight(30) + "210,90 €".PadRight(15) + "213,35 €");
                Console.WriteLine("   " + "Camping-car (camp)".PadRight(30) + "330,20 €".PadRight(15) + "332,70 €");

                Console.WriteLine("\n"); 
        }



}
	


	

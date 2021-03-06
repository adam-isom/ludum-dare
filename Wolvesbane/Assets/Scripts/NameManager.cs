using UnityEngine;
using System.Collections;

public class NameManager : MonoBehaviour {
	public static string[] surnames = new string[] {"Branton", "Bennett", "Darlington", "Dilworth", "Forsythe", "Gerret", "Jones", "Penock", "Seale", "Holier", "Weston", "Morris", "Jeffers", "Marshal", "Logan", "Broomer", "Gibbons", "Barnett", "Mote", "Pyle", "Ward", "Cox", "Clark", "Gertliff", "Shanklin", "Thornsbury", "Moore", "Morrison", "Cuttle", "Chandler", "Mendenhall", "Windle", "Black", "Lockard", "Whitaker", "Buffington", "Foster", "Beakem", "Word", "Taylor", "Gutry", "Johnston", "Bond", "Davis", "Finney", "Richards", "Caster", "Doan", "Buller", "Crisman", "Culbertson", "Green", "Devlin", "Dugan", "Miles", "Lewis", "Anderson", "Ash", "Byers", "Batten", "Culbertson", "Coffer", "Kennedy", "Powel", "Christy", "Elton", "Fisher", "Freeman", "Greer", "Walker", "Elliott", "Stanley", "Temple", "Arthurs", "Hagerdy", "Wild", "Wells", "Whisler", "Little", "Sheldrick", "Roseter", "Hickman", "Longstretch", "Staggers", "Knittels", "Stickles", "Ivory", "Thomking", "Goldwin", "Swink", "Pepper", "Wolf", "Upperman", "Lewelling", "Knowles", "Huntsberger", "Wilkinson", "Ash", "Hardeman", "Rhinehart", "Longacre", "Browler", "Botwin", "Worley", "Yells", "Visler", "Bartholemew", "Buckwalter", "Shimer", "Root", "Emry", "Branam", "Rankin", "Ditlow", "Merideth", "Souder", "Custard", "Brown", "Patterson", "High", "Acker", "Imhooft", "Hollis", "Carter", "Isham", "Savage", "Blackwell", "Steel", "Filson", "Scouk", "Huddleston", "Woodrow", "Messer", "Way", "Vernon", "Meloney", "Windle", "Nedrey", "Paxton", "Ingram", "Reed", "Robeson", "Morrow", "Brandan", "Shoemaker", "Thornton", "Cashady", "Gamble", "Humphreys", "Edgeworth", "Blackburn"};
	public static string [] female_names = new string[] {"Agnes", "Adele", "Adeline", "Alice", "Ann", "Anne", "Anna", "Annabel", "Annice", "Arabella", "Barbara", "Bertha", "Camilla", "Cassandra", "Catherine", "Cecilia", "Cecily", "Christina", "Clare", "Clarice", "Clementia", "Dorothea", "Edith", "Eleanor", "Elizabeth", "Ella", "Ellen", "Emma", "Emmeline", "Emily", "Estrilda", "Eulalia", "Euphemia", "Felicia", "Flora", "Gertrude", "Grace", "Griselda", "Helen", "Hilda", "Isabel", "Jane", "Janet", "Janetta", "Jenny", "Joanna", "Johanna", "Joyce", "Julia", "Julian", "Jillian", "Katherine", "Lavinia", "Leanna", "Leonora", "Letitia", "Lillian", "Lora", "Loretta", "Lucy", "Mahald", "Margaret", "Marina", "Mary", "Matilda", "Mildred", "Mirabel", "Nancy", "Oliva", "Paulina", "Rosa", "Rose", "Rosalind", "Rosamond", "Sarah", "Sidony", "Tamsin", "Thomasina", "Valerie", "Winifred", "Anne", "Catherine", "Charlotte", "Eleanor", "Elizabeth", "Isabella", "Jane", "Mary", "Abi", "Abiah", "Abigail", "Alva", "Asenath", "Barzilla", "Beersheba", "Bethabara", "Bethany", "Beulah", "Candice", "Chloe", "Deborah", "Delilah", "Dinah", "Drusilla", "Elizabeth", "Esther", "Eunice", "Eve", "Hannah", "Huldah", "Jemima", "Jeriah", "Johanna", "Julia", "Keturah", "Keziah", "Leah", "Lois", "Lydia", "Mahala", "Martha", "Mary", "Miriam", "Naomi", "Orpha", "Penninah", "Phoebe", "Priscilla", "Rachel", "Rebecca", "Rebekah", "Rhoda", "Ruth", "Sarah", "Susannah", "Tabitha", "Tamar", "Tirzah", "Zemira", "Zillah", "Alethea", "Charity", "Chastity", "Comfort", "Constance", "Delight", "Dorothea", "Faith", "Grace", "Honor", "Hope", "Joy", "Joyce", "Obedience", "Patience", "Providence", "Prudence", "Tace", "Temperance", "Theodocia", "Verity", "Albina", "Althea", "Almira", "Amanda", "Amaryllis", "Amelia", "Angeline", "Amynta", "Artemesia", "Aurelia", "Belinda", "Bithiah", "Caledonia", "Camilla", "Celia", "Cinderella", "Clarinda", "Clarissa", "Clementina", "Cora", "Cordelia", "Corinna", "Cynthia", "Delia", "Delicia", "Diana", "Dorinda", "Elvira", "Esmerelda", "Estrilda", "Estrildis", "Eurydice", "Fatima", "Fidelia", "Frances", "Harriet", "Irena", "Laura", "Louisa", "Louise", "Lucinda", "Lucretia", "Malvina", "Melissa", "Melinda", "Minerva", "Miranda", "Myra", "Octavia", "Olivia", "Ophelia", "Palmyra", "Pamela", "Parthenia", "Penelope", "Sabrina", "Safronia", "Selima", "Selina", "Selinda", "Sophia", "Sylvania", "Sylvia", "Tranquilla", "Vesta", "Adelaide", "Almetta", "Analiese", "Bertha", "Elsa", "Elsina", "Elzina", "Jensine", "Johanna", "Marlena", "Rosina", "Seraphina", "Serena", "Serilda", "Albertina", "Anna", "Appollonia", "Barbara", "Catharina", "Christina", "Dorothea", "Elisabetha", "Elisa", "Eva", "Frederica", "Gertraud", "Hannah", "Helena", "Juditha", "Juiliana", "Licetta", "Magdalena", "Marcreta", "Margaretha", "Maria", "Sara", "Sophia", "Susanna", "Theresa", "Wilhelmina ", "Mahala", "Pheraby", "Feraby", "Fariba", "Selima", "Semira", "Saluda", "Sedilia", "Wady", "Amarilla", "Lily", "Narcissa", "Olive", "Rose", "Violet", "Eugenie", "Josephine", "Belvadere", "Lorena", "Araminta", "Arlena", "Artelia", "Cena", "Cenia", "Dorthula", "Dovey", "Fredonia", "Jincey", "Gincey", "Lagenia", "Ludelia", "Ludema", "Ludicia", "Luticia", "Luella", "Luvena", "Marticia", "Mathursa", "Orlena", "Perlina", "Permelia", "Pheraby", "Feraby", "Plutina", "Rosinda", "Saletta", "Sena", "Senia", "Thursey", "Verlitia		", "Kizzy", "Lena", "Arlena", "Orlena", "Marlena", "Letty", "Lethy", "Lindy", "Locky", "Ludy", "Manda", "Marilla", "Mattie", "Mazy", "Media", "Melia", "Milly", "Mintha", "Mira", "Molly", "Nancy", "Nelly", "Olly", "Orilla", "Patty", "Peggy", "Penny", "Polly", "Reba", "Rilla", "Rinda", "Sabra", "Sally", "Sena", "Sheby", "Silla", "Sinda", "Sintha", "Sissa", "Sophy", "Tamsey", "Theny", "Thursey", "Tempy", "Tenny", "Tilda", "Vina", "Winnie", "Zibby", "Aby", "Addy", "Aisley", "Aldonia", "Ally", "Alphia", "Alzy", "Arilla", "Arty", "Atty", "Barbry", "Betsy", "Bitha", "Callie", "Cassie", "Cena", "Clemmie", "Delana", "Delia", "Dilly", "Dicey", "Docey", "Donia", "Dora", "Dovey", "Drucy", "Edie", "Edny", "Effy", "Ellie", "Elsy", "Ettie", "Evie", "Fanny", "Gilly", "Ginny", "Hattie", "Hessy", "Hiley", "Ibby", "Ina", "Jilly", "Jinny", "Vengia", "Avarica"};
	public static string [] male_names = new string[] {"Bernardus", "Caleb", "Amos", "William", "Edward", "John", "Abraham", "James", "Isaac", "Thomas", "Samuel", "Philip", "Andrew", "Jacob", "Joseph", "William", "Joshua", "Hugh", "Francis", "Leo", "Elisha", "Enoch", "Abel", "Nathanel", "Daniel", "Theophiles", "Henry", "Yost", "Conard", "Sam", "Lewelling", "Matthias", "Frederick", "Abram", "Peter", "George", "Alex", "Michael", "Boston", "Martin", "Casper", "Richard", "Henry", "Rodolph", "Laurence", "Nathan", "Benjamin", "Jesse", "Robert", "Patrick", "David", "Edward", "Ellis", "Aaron", "Quintin", "Simon", "Herman", "Teunis", "Ralph", "Milton", "Will", "Garret", "Jeremiah", "Cornelius", "Albert", "Dirk", "Cliff", "Franz", "Elias", "Abraham", "Ellis"};
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string generateRandomName() {
		System.Random rand = new System.Random();
		if (rand.Next(0,2) == 0) {
			return male_names[rand.Next(0,male_names.Length)] + " " + surnames[rand.Next(0,surnames.Length)];
		} else {
			return female_names[rand.Next(0,female_names.Length)] + " " + surnames[rand.Next(0,surnames.Length)];
		}
	}

	public string getName(string creatureName) {
		switch (creatureName) {
		case "Boss Werewolf":
			return "Mosi Thewtam";
		case "Boss Vampire":
			return "Turharmac Slilm";
		case "Boss Gargoyle":
			return "Drephesh Mejas";
		case "Boss Homunculus":
			return "Mosi Dama";
		case "Boss Ghost":
			return "The Inevitability Of Death";
		case "Player":
			return "Amurial";
		default:
			return generateRandomName() + " the " + creatureName;
		}
	}
}

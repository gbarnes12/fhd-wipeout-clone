using UnityEngine;
using System.Collections;

public class GuiHighscoreData : MonoBehaviour  {

	private static ArrayList _scoreList;
	private static string _prefName = "playerScore";
	private static int _maxScoreItems = 10;
	public static int _actPoints = 0;

	//Static Konstruktor initialisiert die Static Variablen
	static GuiHighscoreData () {


		_scoreList = new ArrayList ();
		
		//Erstbelegung
		AddScoreItem("Herbert",1000,false);
		AddScoreItem("Luie",857,false);
		AddScoreItem("Heinz",752,false);
		AddScoreItem("Fred",658,false);
		AddScoreItem("Marie",555,false);
		AddScoreItem("Karl",457,false);
		AddScoreItem("John",436,false);
		AddScoreItem("Jenny",378,false);
		AddScoreItem("Zoro",372,false);
		AddScoreItem("Paul",365,false);
		
		
		//Von Festplatte laden
		//LoadOldScoreList ();
		
		SortScoreList ();

	}


	// Update is called once per frame
	private void Update () {
		Debug.Log ("Points in Data: "+_actPoints);
	}
	
	//Alte Highscores laden aus Registry
	private static void LoadOldScoreList (){
		
		bool loadFinish = false;
		int count = 0;
		
		//Nicht mehr als Max laden
		while (loadFinish != true || count > _maxScoreItems){
			
			//Key Name um neuen Count erweitern
			string playerKey = _prefName + count;
			string playerKeyInt = "a"+playerKey;
			string playerKeyString = "b"+playerKey;
			string player = "";
			int points = 0;

			//gibt es diesen Key mit der Nummer noch?
			if(PlayerPrefs.HasKey(playerKeyString)){

				player = PlayerPrefs.GetString(playerKeyString);

				if(PlayerPrefs.HasKey(playerKeyInt)){

					points = PlayerPrefs.GetInt(playerKeyInt);

				}

				//Alten Eintrag neu Anlegen
				AddScoreItem(player,points,false);

			} else {
				
				//letzten Score geladen
				loadFinish = true;
			}

		}
	}
	
	//Alte Highscores speichern in Registry
	private static void SaveNewScoreList (){
		
		
		for (int b = 0; b < _scoreList.Count; b++) {
			
			//Key Name um neuen Count erweitern
			string playerKey = _prefName + b;
			string playerKeyInt = "a"+playerKey;
			string playerKeyString = "b"+playerKey;

			//Objekt holen
			HighScoreItem item = _scoreList[b] as HighScoreItem;
			
			//Namen und Score speichern
			PlayerPrefs.SetInt(playerKeyInt, item.score);
			PlayerPrefs.SetString(playerKeyString, item.name);
		}
		
	}


	
	public static bool IsNewHighscore(int score){
	
		//Ist die Akt Länge kleiner als die Beschränkung
		if (_scoreList.Count < _maxScoreItems ) {

			return true;
		} else if (score > GetItemScore (_maxScoreItems-1)) {

			return true;
		}


		return false;
	}

	public static int GetScoreListCount (){
		return _scoreList.Count;
	}
	
	//Neuen Highscore eintrag verfassen
	public static bool AddScoreItem(string p_name, int p_score, bool saveScore = true){

		
		int lastItem = _maxScoreItems-1;
		bool newHighscore = false;


		
		//Ist die Akt Länge kleiner als die Beschränkung
		if (_scoreList.Count < _maxScoreItems) {

			HighScoreItem item = new HighScoreItem (p_name, p_score);
			
			//In highscore liste speichern
			_scoreList.Add (item);
			
			newHighscore = true;
			
		} else if(p_score > GetItemScore(lastItem)) { // Schon alle Plätze belegt dann wenn größer letzten austauschen


			HighScoreItem item = new HighScoreItem (p_name, p_score);
			
			//In highscore liste letztes Element ersetzten
			_scoreList.Insert(lastItem,item);
			
			newHighscore = true;
			
		}

		_actPoints = 0;

		//Sortieren
		SortScoreList ();

		if(saveScore){

			//SaveNewScoreList();
		}
		
		return newHighscore;
	}
	
	//Nach Score Werten Sortieren und auf Max. beschneiden wenn länger
	private static void SortScoreList (){
		
		ObjSort objSort = new ObjSort ();
		
		_scoreList.Sort (objSort);
		
		
		//Abschneiden wenn länger als erlaubt
		if(_scoreList.Count > _maxScoreItems){
			
			_scoreList = _scoreList.GetRange(0,(_maxScoreItems-1));
		}
	}
	
	
	
	public class HighScoreItem {
		
		public int score;
		public string name;
		
		public HighScoreItem(string p_name, int p_score){
			
			//Neues Objekt mit Werten erzeugen
			score = p_score;
			name = p_name;
		}
	}
	
	public static string GetItemName (int a){
		HighScoreItem item = _scoreList [a] as HighScoreItem;
		return item.name;
	}
	
	public static int GetItemScore (int a){
		HighScoreItem item = _scoreList [a] as HighScoreItem;
		return item.score;
	}
	
	
	//Eigene Sortier Funktion
	public class ObjSort : IComparer {
		
		public int Compare(object x, object y)
		{
			HighScoreItem itemX = x as HighScoreItem;
			HighScoreItem itemY = y as HighScoreItem;
			
			return itemY.score.CompareTo(itemX.score);
		}
		
	}
}

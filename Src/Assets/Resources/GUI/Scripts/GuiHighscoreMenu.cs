using UnityEngine;
using System.Collections;

public class GuiHighscoreMenu : MonoBehaviour {
	
	
	private Texture2D _texScoreBorderTop;
	private Texture2D _texScoreBorderBottom;
	private Texture2D _texScoreBorderBackground;
	private Texture2D _texScoreLabel;

	private GuiHighscoreData _scoreData;

	private float _highscoreWidth;
	
	
	private float _positionGuiX = 0.0f;
	private float _speed = 300.0f;
	private bool _startMenu = false;
	private bool _clickMenuBack = false;

	

	
	// Use this for initialization
	private void Awake () {

	
		
		//Texturen und Fonts laden
		_texScoreBorderTop = Resources.Load<Texture2D> ("GUI/Textures/TexGuiBorderTop");
		_texScoreBorderBottom = Resources.Load<Texture2D> ("GUI/Textures/TexGuiBorderBottom");
		_texScoreBorderBackground = Resources.Load<Texture2D> ("GUI/Textures/TexGuiScoreBackground");
		_texScoreLabel = Resources.Load<Texture2D> ("GUI/Textures/TexGuiScoreLabel");
		
		
		//Texture assigned?
		if (!_texScoreBorderTop) {
			Debug.LogError("Can't find Texture 'TexGuiBorderTop' on path 'Resources/GUI/Textures' ");
			return;
		}
		
		//Texture assigned?
		if (!_texScoreBorderBottom) {
			Debug.LogError("Can't find Texture 'TexGuiBorderBottom' on path 'Resources/GUI/Textures' ");
			return;
		}
		
		//Texture assigned?
		if (!_texScoreBorderBackground) {
			Debug.LogError("Can't find Texture 'TexGuiScoreBackground' on path 'Resources/GUI/Textures' ");
			return;
		}

		//Texture assigned?
		if (!_texScoreLabel) {
			Debug.LogError("Can't find Texture 'TexGuiScoreLabel' on path 'Resources/GUI/Textures' ");
			return;
		}
		
		
		
	}
	
	// Update is called once per frame
	private void Update () {

	}
	
	
	
	float GetAspectRatioHW (Texture2D aTexture){
		
		return ((float)aTexture.height  / (float)aTexture.width );
	}
	
	float GetAspectRatioWH (Texture2D aTexture){
		
		return ((float)aTexture.width / (float)aTexture.height);
	}
	
	
	public Rect DrawScoreBackground (float faktWidth, float faktHeight){
		
		//Max Breite nach Prozent von dem Bilschirm
		float backgrW = Screen.width * faktWidth;
		
		//AspektRatio von Hintergrund
		float backgrAspRatio =  GetAspectRatioHW (_texScoreBorderTop);
		
		//Die Höhe errechnen anhand der Breite
		float backgrH = backgrW * backgrAspRatio;
		
		//Prüfen ob Höhe zu groß für den Bildschirm ist
		if (backgrH > (Screen.height * faktHeight)) {
			
			//Dann Höhe auf Max Bildschirm Höhe setzen
			backgrH = Screen.height * faktHeight;
			
			//AspektRatio neu Berechnen um Breite zu bestimmen
			backgrAspRatio = GetAspectRatioWH (_texScoreBorderTop);
			
			//Breite des Hintergrundes neu berechnen
			backgrW = backgrH * backgrAspRatio;
			
		}
		
		//Rahmen Oben
		GUI.DrawTexture(new Rect((Screen.width) - _positionGuiX ,0.0f, backgrW,backgrH), _texScoreBorderTop, ScaleMode.ScaleToFit, true, 0.0f);


		//Rahmen Unten
		GUI.DrawTexture(new Rect((Screen.width) - _positionGuiX,Screen.height - backgrH, backgrW,backgrH), _texScoreBorderBottom, ScaleMode.ScaleToFit, true, 0.0f);
		


		//Bereich/Platz für Inhalt berechnen
		Rect contentRect = new Rect ();
		
		//Freier Platz + den Rahmen
		contentRect.y = backgrH;
		
		//Linker Rand des Bildschirms
		contentRect.x = Screen.width - _positionGuiX;
		
		//Die Breite des Verfügbaren Inhalts ohne Rand
		contentRect.width = backgrW;
		
		//Die Höhe des Verfügbaren Inhalts ohne Rand
		contentRect.height = (Screen.height - (2 * backgrH));

		//Texture auf Repeat anstelle von Verzerren stellen
		_texScoreBorderBackground.wrapMode = TextureWrapMode.Repeat;

		//Textur in Content Bereich malen in kleinen Blöcken der Textur
		GUI.DrawTextureWithTexCoords(contentRect, _texScoreBorderBackground, new Rect(0, 0, contentRect.width / (_texScoreBorderBackground.width/2.5f), contentRect.height / (_texScoreBorderBackground.height/2.5f)));

		//Eigene Größe Speichern
		_highscoreWidth = contentRect.width;

		return contentRect;
		
	}

	public void DrawHighscoreItems(Rect content){

		//Es sollen 10 Einträge auf die Höhe passen
		float itemH = content.height / 10 ;

		//Ein wenig Abstand oben und unten von den Einträgen
		float itemFreeVSpace = (itemH * 0.1f);
		itemH = itemH * 0.9f;


		//Ein Eintrag hat die ganze Breite des Contents zur Verfügung
		float itemW = content.width;


		//Stimmt die Schriftgröße
		int fontSize = (int)( itemH * 0.7f) ;
		
		if(fontSize > 0){
			
			GUI.skin.label.fontSize = fontSize;
		}


		float rankLabelW = itemW * 0.1f;
		float nameLabelW = itemW * 0.4f;
		float pointsLabelW = itemW * 0.4f;
		float itemFreeHSpace = (itemW * 0.1f) / 4;
	

		string player = "";

		GUI.skin.label.normal.textColor = new Color (0.364f,0.850f,0.341f);

		// Die ersten 10 Hgihscores anzeigen
		for (int x = 0; x < 10; x++){

			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			GUI.Label(new Rect(content.x + itemFreeHSpace,content.y + (itemH * x)+ (itemFreeVSpace * (x+1)) ,rankLabelW,itemH),(x+1).ToString()+".");


			player = GuiHighscoreData.GetItemName(x);
			GUI.Label(new Rect(content.x + rankLabelW + (itemFreeHSpace * 2),content.y + (itemH * x)+ (itemFreeVSpace * (x+1)),nameLabelW,itemH),player);

			GUI.skin.label.alignment = TextAnchor.UpperRight;
			player = GuiHighscoreData.GetItemScore(x).ToString();
			GUI.Label(new Rect(content.x + rankLabelW + nameLabelW +(itemFreeHSpace * 3),content.y + (itemH * x)+ (itemFreeVSpace * (x+1)),pointsLabelW,itemH),player);
		}

		GUI.skin.label.alignment = TextAnchor.UpperLeft;

	
		


	}

	public void DrawBackButton () {

		float buttonW = Screen.width * 0.1f;
		float buttonH = buttonW * 0.543f;

		if (GUI.Button (new Rect ((Screen.width) - (_positionGuiX + buttonW), 0.0f, buttonW, buttonH), "Back")) {

			if(_startMenu) {
				_clickMenuBack = true;

			}

		}

	}

	public bool StartMenuHighscore(float speedMenu){
	

		_speed = speedMenu;

		//Highscore
		Rect scoreContent = DrawScoreBackground (0.5f, 0.4f);
		DrawHighscoreItems (scoreContent);


		if(!_startMenu){

			//In den Screen Animieren
			AnimateHighscoreOnScreen ();

		}

		if(_startMenu && _clickMenuBack){

			return AnimateHighscoreOffScreen ();


		} else if(_startMenu) {
			DrawBackButton ();
		}

		return false;
	}




	public void AnimateHighscoreOnScreen (){
	


		if(_positionGuiX < _highscoreWidth) {
				_positionGuiX += _speed * Time.deltaTime;
		}
			
		if(_positionGuiX > _highscoreWidth){
				_startMenu = true;
				_positionGuiX = _highscoreWidth;

		}



	}

	public bool AnimateHighscoreOffScreen (){
		

		if(_positionGuiX > 0) {
			_positionGuiX -= _speed * Time.deltaTime;
		}
			
		if (_positionGuiX <= 0) {

			_positionGuiX = 0.0f;
			_startMenu = false;
			_clickMenuBack = false;
			return true;
				
		} else {

			return false;
		}
			

	}



	
	
}

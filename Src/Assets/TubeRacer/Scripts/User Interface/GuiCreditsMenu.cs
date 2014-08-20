using UnityEngine;
using System.Collections;

public class GuiCreditsMenu : MonoBehaviour {
	
	
	private Texture2D _texScoreBorderTop;
	private Texture2D _texScoreBorderBottom;
	private Texture2D _texScoreBorderBackground;
	private Texture2D _texScoreLabel;



	private float _creditsWidth;
	
	
	private float _positionGuiX = 0.0f;
	private float _speed = 300.0f;
	private bool _startMenu = false;
	private bool _exitMenu = false;


	
	

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
	
	
	
	public float GetAspectRatioHW (Texture2D aTexture){
		
		return ((float)aTexture.height  / (float)aTexture.width );
	}

	public float GetAspectRatioWH (Texture2D aTexture){
		
		return ((float)aTexture.width / (float)aTexture.height);
	}
	
	
	public Rect DrawCreditsBackground (float faktWidth, float faktHeight){
		
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
		_creditsWidth = contentRect.width;

		return contentRect;
		
	}

	public void DrawCreditItems(Rect content){

		//Es sollen 20 Einträge auf die Höhe passen
		float itemH = content.height / 8 ;

		//Ein wenig Abstand oben und unten von den Einträgen
		float itemFreeVSpace = (itemH * 0.1f);
		itemH = itemH * 0.9f;


		//Ein Eintrag hat die ganze Breite des Contents zur Verfügung
		float itemW = content.width;


		//Stimmt die Schriftgröße
		int fontSize = (int)( itemH * 0.3f) ;
		
		if(fontSize > 0){
			
			GUI.skin.label.fontSize = fontSize;
		}





		GUI.skin.label.normal.textColor = new Color (0.364f,0.850f,0.341f);


		GUI.skin.label.alignment = TextAnchor.UpperCenter;



		GUI.Label(new Rect(content.x,content.y + (itemH * 0)+ (itemFreeVSpace * 1) ,itemW,itemH),"Stephan Brenig\nKonzept,Hardware\n,Programmierung,Modellierung");
		
		
		GUI.Label(new Rect(content.x,content.y + (itemH * 1)+ (itemFreeVSpace * 2) ,itemW,itemH),"Alexandros Delas\nDokumentation,Präsentation\n,Sound, 3D-Kamera");

		GUI.Label(new Rect(content.x,content.y + (itemH * 2)+ (itemFreeVSpace * 3) ,itemW,itemH),"Gavin B.\nHardware,Programmierung\n(Röhren- und Hindernisse)");

		GUI.Label(new Rect(content.x,content.y + (itemH * 3)+ (itemFreeVSpace * 4) ,itemW,itemH),"Minh N.\nModellierung,Programmierung\n,(Röhren- und Hindernisse)");

		GUI.Label(new Rect(content.x,content.y + (itemH * 4)+ (itemFreeVSpace * 5) ,itemW,itemH),"Marc F.\nModellierung (Hindernisse)\n,Grafik (Partikel, Röhren)");

		GUI.Label(new Rect(content.x,content.y + (itemH * 5)+ (itemFreeVSpace * 6) ,itemW,itemH),"Marc Wackerbarth\nGui (Texturierung,Idee,Programmierung)\n,Hauptmenu,Restartmenu");
		
		GUI.Label(new Rect(content.x,content.y + (itemH * 6)+ (itemFreeVSpace * 7) ,itemW,itemH),"Vivian Buttkereit\nScripting,Kollision\n");

		GUI.Label(new Rect(content.x,content.y + (itemH * 7)+ (itemFreeVSpace * 8) ,itemW,itemH),"Stefan Buttchereit\nScripting\n");
		

		
		}



	public bool StartMenuCredits(float speedMenu){
	

		_speed = speedMenu;

		//Highscore
		Rect creditsContent = DrawCreditsBackground(0.5f, 0.4f);
		DrawCreditItems (creditsContent);


		if(!_startMenu){

			//In den Screen Animieren
			AnimateHighscoreOnScreen ();

		}

		if(_startMenu && !_exitMenu){

			_exitMenu = true;
			Invoke("ExitGame",10.0f);

		}


		return false;
	}


	public void ExitGame(){
		Application.Quit ();
	}

	public void AnimateHighscoreOnScreen (){
	


		if(_positionGuiX < _creditsWidth) {
				_positionGuiX += _speed * Time.deltaTime;
		}
			
		if(_positionGuiX >= _creditsWidth){
			_startMenu = true;
			_positionGuiX = _creditsWidth;

		}



	}




	
	
}

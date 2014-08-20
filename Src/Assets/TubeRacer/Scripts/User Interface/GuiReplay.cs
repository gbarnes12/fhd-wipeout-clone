
using UnityEngine;
using System.Collections;



public class GuiReplay : MonoBehaviour {


	private Texture2D _texMenuBackground;
	private Texture2D _texMenuButton;
	private Texture2D _texMenuButtonHover;
	private Texture2D _texMenuTextfield;
	private Texture2D _texMenuBackground2;
	private Font _font;

	private float _positionGuiX = 0.0f;

	private GuiHighscoreMenu _highscore;
	private GuiCreditsMenu _credits;
	private float _menuWidth;
	private float _speed = 800.0f;

	private string _playerName = "";
	public bool _showMenuReplay = false;
	private bool _isNewHighscore = false;

	public string _gameScene = "Scn_Wrld_Game";
	public string _menuScene = "Scn_Gui_MainMenu";





	// Use this for initialization
	private void Awake () {

		//StartMenuReplay ();
	

		//Andere Menu teile laden
		_highscore = this.GetComponent <GuiHighscoreMenu> ();
		_credits = this.GetComponent <GuiCreditsMenu> ();

		//Texturen und Fonts laden
		_texMenuBackground = Resources.Load<Texture2D> ("GUI/Textures/TexGuiBackground");
		_texMenuButton = Resources.Load<Texture2D> ("GUI/Textures/TexGuiButton");
		_texMenuButtonHover = Resources.Load<Texture2D> ("GUI/Textures/TexGuiButtonHover");
		_texMenuTextfield = Resources.Load<Texture2D> ("GUI/Textures/TexGuiTextfield");
		_texMenuBackground2 = Resources.Load<Texture2D> ("GUI/Textures/TexGuiScoreBackground");
		_font = Resources.Load <Font> ("GUI/Fonts/FntDigitalNumbers");


		//Texture assigned?
		if (!_texMenuBackground) {
			Debug.LogError("Can't find Texture 'TexGuiBackground' on path 'Resources/GUI/Textures' ");
			return;
		}
		
		//Texture assigned?
		if (!_texMenuButton) {
			Debug.LogError("Can't find Texture 'TexGuiButton' on path 'Resources/GUI/Textures' ");
			return;
		}
		
		//Texture assigned?
		if (!_texMenuButtonHover) {
			Debug.LogError("Can't find Texture 'TexGuiButtonHover' on path 'Resources/GUI/Textures' ");
			return;
		}

		//Texture assigned?
		if (!_texMenuTextfield) {
			Debug.LogError("Can't find Texture 'TexGuiTextfield' on path 'Resources/GUI/Textures' ");
			return;
		}

		//Texture assigned?
		if (!_texMenuBackground2) {
			Debug.LogError("Can't find Texture 'TexGuiScoreBackground' on path 'Resources/GUI/Textures' ");
			return;
		}


		//Font assigned?
		if (!_font) {
			Debug.LogError("Can't find Font 'FntDigitalNumbers' on path 'Resources/GUI/Textures'");
			return;
		}


	}
	
	// Update is called once per frame
	private void Update () {
	
	
	}

	private void SetGuiSkin (){
	
		//Font and Font Size for Label
		GUI.skin.font = _font;
		GUI.skin.label.fontSize = 50;
		GUI.skin.button.normal.background = _texMenuButton;
		GUI.skin.button.normal.textColor = new Color (0.129f, 0.321f, 0.384f);
		GUI.skin.button.hover.background = _texMenuButtonHover;
		GUI.skin.button.hover.textColor = new Color (0.619f, 0.878f, 0.462f);
		GUI.skin.button.active.background =  _texMenuButtonHover;
		GUI.skin.button.active.textColor = new Color (0.819f, 0.878f, 0.462f);
		GUI.skin.button.fixedWidth = 0;
		GUI.skin.button.fixedHeight = 0;
		GUI.skin.button.fontSize = 50;
		GUI.skin.button.border.top = 0;
		GUI.skin.button.border.bottom = 0;
		GUI.skin.button.border.left = 0;
		GUI.skin.button.border.right = 0;
		GUI.skin.textField.normal.background = _texMenuTextfield;
		GUI.skin.textField.active.background = _texMenuTextfield;
		GUI.skin.textField.hover.background = _texMenuTextfield;
		GUI.skin.textField.focused.background = _texMenuTextfield;

		GUI.skin.textField.focused.textColor = new Color (0.129f, 0.321f, 0.384f);

	}

	float GetAspectRatioHW (Texture2D aTexture){
	
		return ((float)aTexture.height  / (float)aTexture.width );
	}

	float GetAspectRatioWH (Texture2D aTexture){
		
		return ((float)aTexture.width / (float)aTexture.height);
	}


	private void OnGUI () {


		if(_showMenuReplay){

		
			SetGuiSkin ();

			Rect menuContent = DrawBackground (0.3f);

			DrawMenuButtons (menuContent,0.8f,300.0f, 20.0f);

			AnimateMenuOnScreen (true);

		}



	}


	private Rect DrawBackground(float faktWidth){

		//Max Breite nach Prozent von dem Bilschirm
		float backgrW = Screen.width * faktWidth;

		//AspektRatio von Hintergrund
		float backgrAspRatio =  GetAspectRatioHW (_texMenuBackground);

		//Die Höhe errechnen anhand der Breite
		float backgrH = backgrW * backgrAspRatio;

		//Prüfen ob Höhe zu groß für den Bildschirm ist
		if (backgrH > Screen.height) {
		
			//Dann Höhe auf Max Bildschirm Höhe setzen
			backgrH = Screen.height;

			//AspektRatio neu Berechnen um Breite zu bestimmen
			backgrAspRatio = GetAspectRatioWH (_texMenuBackground);

			//Breite des Hintergrundes neu berechnen
			backgrW = backgrH * backgrAspRatio;

		}

		//Oberen und Unteren Abstand berechnen
		float backgrFreeVSpace = (Screen.height - backgrH) / 2;



		GUI.DrawTexture(new Rect(0.0f - backgrW + _positionGuiX,backgrFreeVSpace, backgrW,backgrH), _texMenuBackground, ScaleMode.ScaleToFit, true, 0.0f);


		//Breite des Menus speichern
		_menuWidth = backgrW;

		//Bereich/Platz für Inhalt berechnen
		Rect contentRect = new Rect ();

		//Freier Platz + den Rahmen
		contentRect.y = (backgrH * 0.05f) + backgrFreeVSpace;

		//Linker Rand des Bildschirms
		contentRect.x = 0.0f - backgrW+ _positionGuiX;

		//Die Breite des Verfügbaren Inhalts ohne Rand
		contentRect.width = backgrW * 0.95f;

		//Die Höhe des Verfügbaren Inhalts ohne Rand
		contentRect.height = backgrH * 0.9f;

		//Texture auf Repeat anstelle von Verzerren stellen
		_texMenuBackground2.wrapMode = TextureWrapMode.Repeat;
		
		//Textur in Content Bereich malen in kleinen Blöcken der Textur
		GUI.DrawTextureWithTexCoords(contentRect, _texMenuBackground2, new Rect(0, 0, contentRect.width / (_texMenuBackground2.width/2.5f), contentRect.height / (_texMenuBackground2.height/2.5f)));


		return contentRect;
	}



	private void DrawMenuButtons (Rect content, float faktWidth, float minWidth, float minSpace) {
	
		//Breite nach Prozent von dem Content
		float buttonW = content.width * faktWidth;

		//Volle Breite von Content wenn kleiner als min
		if(buttonW < minWidth){

			buttonW = content.width;
		}

		//AspektRatio von Button
		float buttonAspRatio = GetAspectRatioHW (_texMenuButton);

		//Die Höhe errechnen anhand der Breite
		float buttonH = buttonW * buttonAspRatio;

		//Prüfen ob alle 3 Buttons mit Platz dazwischen in Content passen
		if (((buttonH * 3) + (minSpace * 4)) > content.height) {

			//Höhe auf Resthöhe nach Abzug des MindestAbstandes
			buttonH = (content.height - (4 * minSpace)) / 3;

			//AspektRatio neu Berechnen um Breite zu bestimmen
			buttonAspRatio = GetAspectRatioWH (_texMenuButton);
			
			//Breite des Button neu berechnen
			buttonW = buttonH * buttonAspRatio;
		}

		//Zwischen Abstand der Buttons berechnen
		float buttonFreeVSpace = (content.height - (buttonH * 3)) / 4;
		float buttonFreeHSpace = (content.width - buttonW) / 2;


		GUI.skin.textField.padding.left = (int)(buttonW * 0.2f);
		GUI.skin.textField.padding.right = (int)(buttonW * 0.2f);
		GUI.skin.textField.padding.top = (int)(buttonH * 0.1f);
		GUI.skin.textField.padding.bottom = (int)(buttonH * 0.1f);


		//Stimmt die Schriftgröße
		int fontSize = (int)( buttonH * 0.3f) ;

		if(fontSize > 0){

			GUI.skin.button.fontSize = fontSize;

		}



		if (GUI.Button (new Rect (content.x + buttonFreeHSpace, content.y + (buttonFreeVSpace * 2) + (buttonH * 1), buttonW, buttonH), "Replay")) 
		{


				SaveNewHighscore();

				Application.LoadLevel(_gameScene);

				

		}

		if (GUI.Button (new Rect (content.x + buttonFreeHSpace, content.y + (buttonFreeVSpace * 3) + (buttonH * 2), buttonW, buttonH), "Menu"))
		{


				SaveNewHighscore();

				Application.LoadLevel(_menuScene);

			


		}

		GUI.skin.label.fontSize =  (int)(fontSize * 0.8f);
		GUI.skin.textField.fontSize = (int)(fontSize * 0.8f);



		if(_isNewHighscore){
			GUI.Label (new Rect (content.x + buttonFreeHSpace, content.y + (buttonFreeVSpace * 1) + (buttonH * 0), buttonW, buttonH / 2), "Neuer Highscore");
			_playerName = GUI.TextField (new Rect (content.x + buttonFreeHSpace, content.y + (buttonFreeVSpace * 1) + (buttonH * 0.5f), buttonW, buttonH/2), "" + _playerName, 8);
			

		} else {
			GUI.Label (new Rect (content.x + buttonFreeHSpace, content.y + (buttonFreeVSpace * 1) + (buttonH * 0), buttonW, buttonH / 2), "Kein Highscore");
			GUI.TextField (new Rect (content.x + buttonFreeHSpace, content.y + (buttonFreeVSpace * 1) + (buttonH * 0.5f), buttonW, buttonH/2), "", 8);
			


		}


	}

	private void SaveNewHighscore(){
	
		if (_isNewHighscore) {

			if(_playerName.Length <= 0){
				_playerName = "Player";
			}

			GuiHighscoreData.AddScoreItem(_playerName, GuiHighscoreData._actPoints);
			GuiHighscoreData._actPoints = 0;
			

		} 

	}

	public void StartMenuReplay(){

		_isNewHighscore = GuiHighscoreData.IsNewHighscore (GuiHighscoreData._actPoints);
		_showMenuReplay = true;
	}



	public void AnimateMenuOnScreen (bool onScreen){
		

		
		if (onScreen) { //In den Screen bewegen
			
			if(_positionGuiX < _menuWidth) {
				_positionGuiX += _speed * Time.deltaTime;
			}
			
			if(_positionGuiX >= _menuWidth){
				
				_positionGuiX = _menuWidth;
				
				
			}
			
		} else { //Aus dem Screen raus bewegen
			
			if(_positionGuiX > 0.0f) {
				_positionGuiX -= _speed * Time.deltaTime;
			}
			
			if(_positionGuiX <= 0.0f){
				
				_positionGuiX = 0.0f;
				
				
			}
			
		}
		
	}







}

	
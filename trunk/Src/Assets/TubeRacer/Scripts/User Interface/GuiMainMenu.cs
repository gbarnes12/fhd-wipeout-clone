using UnityEngine;
using System.Collections;


//Aufzählungstyp (Konstanten die für Zahlen stehen)
public enum ActiveMenu
{
	START,
	PLAY,
	HIGHSCORE,
	QUIT,
	NONE
}


public class GuiMainMenu : MonoBehaviour {


	private Texture2D _texMenuBackground;
	private Texture2D _texMenuButton;
	private Texture2D _texMenuButtonHover;
	private Texture2D _texMetalDoorTop;
	private Texture2D _texMetalDoorBottom;
	private Texture2D _texGuiBackground;
	private Texture2D _texMenuBackground2;
	private Font _font;

	private float _positionGuiX = 0.0f;

	private GuiHighscoreMenu _highscore;
	private GuiCreditsMenu _credits;
	private ActiveMenu _activeMenu;
	private float _menuWidth;
	private float _speed = 800.0f;

	//Metal Türen Position Y
	private float _metalDoorTopPosY = 0.0f;
	private float _metalDoorBottomPosY = 0.0f;

	public string _gameScene = "Scn_Wrld_Game";


	// Use this for initialization
	private void Awake () {

		//Aktives Menu auf Standard einstellen
		_activeMenu = ActiveMenu.START;

		//Andere Menu teile laden
		_highscore = this.GetComponent <GuiHighscoreMenu> ();
		_credits = this.GetComponent <GuiCreditsMenu> ();

		//Texturen und Fonts laden
		_texMenuBackground = Resources.Load<Texture2D> ("GUI/Textures/TexGuiBackground");
		_texMenuButton = Resources.Load<Texture2D> ("GUI/Textures/TexGuiButton");
		_texMenuButtonHover = Resources.Load<Texture2D> ("GUI/Textures/TexGuiButtonHover");
		_texMetalDoorTop = Resources.Load<Texture2D> ("GUI/Textures/TexGuiMetalDoorTop");
		_texMetalDoorBottom = Resources.Load<Texture2D> ("GUI/Textures/TexGuiMetalDoorBottom");
		_font = Resources.Load <Font> ("GUI/Fonts/FntDigitalNumbers");
		_texGuiBackground = Resources.Load<Texture2D> ("GUI/Textures/TexGuiBackground2");
		_texMenuBackground2 = Resources.Load<Texture2D> ("GUI/Textures/TexGuiScoreBackground");

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
		if (!_texMetalDoorTop) {
			Debug.LogError("Can't find Texture 'TexGuiMetalDoorTop' on path 'Resources/GUI/Textures' ");
			return;
		}

		//Texture assigned?
		if (!_texMetalDoorBottom) {
			Debug.LogError("Can't find Texture 'TexGuiMetalDoorBottom' on path 'Resources/GUI/Textures' ");
			return;
		}

		//Texture assigned?
		if (!_texGuiBackground) {
			Debug.LogError("Can't find Texture 'TexGuiBackground2' on path 'Resources/GUI/Textures' ");
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
	
		//Programm beenden mit Esc in der Menu Scene
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}

	}

	private void SetGuiSkin (){
	
		//Font and Font Size for Label
		GUI.skin.font = _font;
		GUI.skin.label.fontSize = 50;
		GUI.skin.button.normal.background = _texMenuButton;
		GUI.skin.button.normal.textColor = new Color (0.129f, 0.321f, 0.384f);
		GUI.skin.button.hover.background = _texMenuButtonHover;
		GUI.skin.button.hover.textColor = new Color (0.619f, 0.878f, 0.462f);
		GUI.skin.button.active.background = _texMenuButtonHover;
		GUI.skin.button.active.textColor = new Color (0.819f, 0.878f, 0.462f);
		GUI.skin.button.fixedWidth = 0;
		GUI.skin.button.fixedHeight = 0;
		GUI.skin.button.fontSize = 50;
		GUI.skin.button.border.top = 0;
		GUI.skin.button.border.bottom = 0;
		GUI.skin.button.border.left = 0;
		GUI.skin.button.border.right = 0;

	}

	float GetAspectRatioHW (Texture2D aTexture){
	
		return ((float)aTexture.height  / (float)aTexture.width );
	}

	float GetAspectRatioWH (Texture2D aTexture){
		
		return ((float)aTexture.width / (float)aTexture.height);
	}


	private void OnGUI () {

		SetGuiSkin ();

		//Gui Hintergrund komplett
		GUI.DrawTextureWithTexCoords(new Rect(0.0f,0.0f,Screen.width,Screen.height), _texGuiBackground,new Rect(0, 0, Screen.width / (_texGuiBackground.width/1.0f), Screen.height / (_texGuiBackground.height/1.0f)));

		Rect menuContent = DrawBackground (0.3f);

		DrawMenuButtons (menuContent,0.8f,300.0f, 20.0f);


		switch(_activeMenu){
		
			case ActiveMenu.PLAY:
				Application.LoadLevel(_gameScene);
				break;
			case ActiveMenu.HIGHSCORE:
				AnimateMenuOnScreen (false);

				//Wenn das Menu intern geschlossen wird, wieder Standard Menu setzen
				if(_highscore.StartMenuHighscore(_speed)){
					_activeMenu = ActiveMenu.NONE;
				}
			    break;
			case ActiveMenu.QUIT:
				AnimateMenuOnScreen (false);
				_credits.StartMenuCredits(_speed);
				break;
			case ActiveMenu.NONE:
				AnimateMenuOnScreen (true);

				break;
			case ActiveMenu.START:
				
				DrawMetalDoor();
				break;

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
		contentRect.height = backgrH * 0.90f;

		//Texture auf Repeat anstelle von Verzerren stellen
		_texMenuBackground2.wrapMode = TextureWrapMode.Repeat;
		
		//Textur in Content Bereich malen in kleinen Blöcken der Textur
		GUI.DrawTextureWithTexCoords(contentRect, _texMenuBackground2, new Rect(0, 0, contentRect.width / (_texMenuBackground2.width/2.5f), contentRect.height / (_texMenuBackground2.height/2.5f)));


		GUI.DrawTexture(new Rect(0.0f - backgrW + _positionGuiX,backgrFreeVSpace, backgrW,backgrH), _texMenuBackground, ScaleMode.ScaleToFit, true, 0.0f);
		


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

		//Stimmt die Schriftgröße
		int fontSize = (int)( buttonH * 0.3f) ;

		if(fontSize > 0){

			GUI.skin.button.fontSize = fontSize;
		}


		if (GUI.Button (new Rect (content.x + buttonFreeHSpace, content.y + (buttonFreeVSpace * 1) + (buttonH * 0), buttonW, buttonH), "PLAY")) {

			if(_activeMenu == ActiveMenu.NONE){
				
				_activeMenu = ActiveMenu.PLAY;
				
			}
		}

		if (GUI.Button (new Rect (content.x + buttonFreeHSpace, content.y + (buttonFreeVSpace * 2) + (buttonH * 1), buttonW, buttonH), "Highscore"))
		{
			if(_activeMenu == ActiveMenu.NONE){

				_activeMenu = ActiveMenu.HIGHSCORE;
			
			}

		}
		if (GUI.Button (new Rect (content.x + buttonFreeHSpace, content.y + (buttonFreeVSpace * 3) + (buttonH * 2), buttonW, buttonH), "Quit")) {
		
			if(_activeMenu == ActiveMenu.NONE){
				
				_activeMenu = ActiveMenu.QUIT;
				
			}
		
		}

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

	private void DrawMetalDoor(){

	

		float doorTopH = Screen.height * 0.56f;
		float doorBottomH = Screen.height * 0.50f;


		//Bildschirm Offen also Menu zeigen
		if(_metalDoorBottomPosY >= doorBottomH && _metalDoorTopPosY <= (0.0f - doorTopH)){
			
			_activeMenu = ActiveMenu.NONE;
		}

		if(_metalDoorTopPosY > (0.0f - doorTopH)){

			_metalDoorTopPosY -= 50.0f * Time.deltaTime;

		} 

		if(_metalDoorBottomPosY < doorBottomH){
			
			_metalDoorBottomPosY += 50.0f * Time.deltaTime;
			
		}  

		GUI.DrawTexture(new Rect(0.0f,_metalDoorTopPosY, Screen.width,doorTopH), _texMetalDoorTop, ScaleMode.StretchToFill, true, 0.0f);
		GUI.DrawTexture(new Rect(0.0f,_metalDoorBottomPosY + Screen.height * 0.5f, Screen.width,doorBottomH), _texMetalDoorBottom, ScaleMode.StretchToFill, true, 0.0f);



	}





}

	
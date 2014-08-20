using UnityEngine;
using System.Collections;

public class GuiPoints : MonoBehaviour {


	private Texture2D _texGuiPoints;
	private Font _font;
	private int _points = 0;

	//Getter and Setter from points
	public int Points{

		get{
			return _points;
		}

		set{
			if(value >= 0){

				GuiHighscoreData._actPoints = value;
				_points = value;
			}
		}
	}

	// Use this for initialization
	private void Awake () {
	
		_texGuiPoints = Resources.Load<Texture2D> ("GUI/Textures/TexGuiPoints");
		_font = Resources.Load <Font> ("GUI/Fonts/FntDigitalNumbers");


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

	private void OnGUI () {

		//Texture assigned?
		if (!_texGuiPoints) {
			Debug.LogError("Can't find Texture 'TexGuiPoints' on path 'Resources/GUI/Textures' ");
			return;
		}

		//Font assigned?
		if (!_font) {
			Debug.LogError("Can't find Font 'FntDigitalNumbers' on path 'Resources/GUI/Textures'");
			return;
		}

		float scaleX = Screen.width * 0.3f;
		float scaleY = scaleX * GetAspectRatioHW (_texGuiPoints);

		GUI.DrawTexture(new Rect((Screen.width - (scaleX * 0.85f)),0.0f - (scaleX * 0.15f), scaleX, scaleY), _texGuiPoints, ScaleMode.ScaleToFit, true, 0.0f);

		//Font and Font Size for Label
		GUI.skin.font = _font;
		GUI.skin.label.fontSize = (int) (scaleY * 0.4f);

		//Calculate the Width of the Label with the skin Attributes
		Vector2 labelSize = GUI.skin.label.CalcSize (new GUIContent (_points.ToString()));


		GUI.Label (new Rect ((Screen.width - labelSize.x - (scaleX * 0.1f)), (scaleX * 0.1f), labelSize.x,scaleY * 0.45f), _points.ToString());
	}
}

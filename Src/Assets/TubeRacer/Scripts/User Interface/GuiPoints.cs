using UnityEngine;
using System.Collections;

public class GuiPoints : MonoBehaviour 
{
	#region Private Members
	private Texture2D _texGuiPoints;
	private Font _font;
	private int _points = 0;
	private int CountdownTime = -1;
	#endregion
	
	#region Public Members
	public int Points{
		get{ return _points;}
		
		set{
			if(value >= 0)
			{
				GuiHighscoreData._actPoints = value;
				_points = value;
			}
		}
	}
	
	public bool Enable3D;
	#endregion
	
	#region Unity Methods
	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake () 
	{
		_texGuiPoints = Resources.Load<Texture2D> ("GUI/Textures/TexGuiPoints");
		_font = Resources.Load <Font> ("GUI/Fonts/FntDigitalNumbers");
	}
	
	
	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI () 
	{
		//Texture assigned?
		if (!_texGuiPoints) 
		{
			Debug.LogError("Can't find Texture 'TexGuiPoints' on path 'Resources/GUI/Textures' ");
			return;
		}
		
		//Font assigned?
		if (!_font) 
		{
			Debug.LogError("Can't find Font 'FntDigitalNumbers' on path 'Resources/GUI/Textures'");
			return;
		}
		
		float scaleX = Screen.width * 0.3f;
		float scaleY = scaleX * GetAspectRatioHW (_texGuiPoints);
		
		GUI.DrawTexture(new Rect((Screen.width - (scaleX )),0.0f - (scaleX * 0.15f), scaleX, scaleY), _texGuiPoints, ScaleMode.ScaleToFit, true, 0.0f);
		if(this.Enable3D)
			GUI.DrawTexture(new Rect((Screen.width * 0.5f - (scaleX )),0.0f - (scaleX * 0.15f), scaleX, scaleY), _texGuiPoints, ScaleMode.ScaleToFit, true, 0.0f);
		
		//Font and Font Size for Label
		GUI.skin.font = _font;
		GUI.skin.label.fontSize = (int) (scaleY * 0.4f);
		
		//Calculate the Width of the Label with the skin Attributes
		Vector2 labelSize = GUI.skin.label.CalcSize (new GUIContent (_points.ToString()));
		
		
		GUI.Label(new Rect ((Screen.width - labelSize.x - (scaleX * 0.25f)), (scaleX * 0.1f), labelSize.x,scaleY * 0.45f), _points.ToString());
		if(this.Enable3D)
			GUI.Label(new Rect ((Screen.width * 0.5f - labelSize.x - (scaleX * 0.25f)), (scaleX * 0.1f), labelSize.x,scaleY * 0.45f), _points.ToString());
		
		//Display countdown
		GUI.skin.GetStyle("Label").alignment = TextAnchor.UpperCenter;
		GUI.skin.label.fontSize  = (int) (Screen.height * 0.4f);
		
		if (CountdownTime > 0)
		{
			if(this.Enable3D)
			{	
				GUI.Label (new Rect (0, Screen.height * 0.25f , Screen.width * 0.5f, Screen.height), CountdownTime.ToString ());
				GUI.Label (new Rect (Screen.width * 0.5f, Screen.height * 0.25f, Screen.width * 0.5f, Screen.height), CountdownTime.ToString ());
			}else
				GUI.Label (new Rect (Screen.width * 0.25f, Screen.height * 0.25f , Screen.width * 0.5f, Screen.height), CountdownTime.ToString ());
		}
		
		if (CountdownTime == 0) 
		{
			if(this.Enable3D)
			{
				GUI.Label (new Rect (0, Screen.height * 0.25f, Screen.width * 0.5f, Screen.height), "Start");
				GUI.Label(new Rect(Screen.width * 0.5f, Screen.height * 0.25f, Screen.width * 0.5f, Screen.height), "Start");
			}else
				GUI.Label (new Rect (Screen.width * 0.25f, Screen.height * 0.25f, Screen.width * 0.5f, Screen.height), "Start");
		}
	}
	#endregion
	
	#region Private Methods
	
	/// <summary>
	/// Gets the aspect ratio H.
	/// </summary>
	/// <returns>The aspect ratio H.</returns>
	/// <param name="aTexture">A texture.</param>
	private float GetAspectRatioHW (Texture2D aTexture)
	{
		return ((float)aTexture.height  / (float)aTexture.width );
	}
	
	/// <summary>
	/// Gets the aspect ratio W.
	/// </summary>
	/// <returns>The aspect ratio W.</returns>
	/// <param name="aTexture">A texture.</param>
	private float GetAspectRatioWH (Texture2D aTexture)
	{
		return ((float)aTexture.width / (float)aTexture.height);
	}
	#endregion
	
	#region Public Methods
	/// <summary>
	/// Starts the countdown.
	/// </summary>
	/// <returns>The countdown.</returns>
	/// <param name="countdownTime">Countdown time.</param>
	public IEnumerator StartCountdown(int time)
	{
		CountdownTime = time;
		
		for(int i = this.CountdownTime; i >= 0; i--)
		{
			this.audio.Play ();
			yield return new WaitForSeconds(1);
			this.CountdownTime -= 1;
		}
	}
	#endregion
	
}

using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	#region Private Members
	private int _currentFrame = 0;
	private int _points = 0;
	private GuiPoints _guiPoints;
	#endregion

	#region Unity Methods
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() 
	{
		newGame ();

		//Game Object mit dem Tag GUI_Points finden
		_guiPoints = GameObject.FindGameObjectWithTag ("GUI").GetComponent<GuiPoints>();

		if (_guiPoints == null)
		{
			Debug.LogError("There is no GuiPoints script in the scene!");
			return;
		}
	
	}

	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate () 
	{
		if (Gameplay.World.WorldSpawnManager.Instance.GameRunning) {
			_currentFrame++;
			CountPoints();
		}
	}
	#endregion

	#region Private Methods
	/// <summary>
	/// //Wenn die Runde STARTET wird newGame() aufgerufen
	/// </summary>
	private void newGame() 
	{
		_currentFrame = 0;
		_points = 0;
	}

	/// <summary>
	/// Counts the points.
	/// </summary>
	private void CountPoints() 
	{
		if (_currentFrame % 10 == 0) {
			_points++;
		
			//Punkte an die Gui übertragen
			_guiPoints.Points = _points;
		}
	}
	#endregion
}

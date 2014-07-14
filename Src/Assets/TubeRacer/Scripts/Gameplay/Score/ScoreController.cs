using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {



	//Wenn die Runde ENDET wird gameRunning auf false gesetzt
	public bool gameRunning;



	//Wenn die Runde STARTET wird newGame() aufgerufen
	public void newGame() {
		gameRunning = true;
		currentFrame = 0;
		points = 0;
	}




	private int currentFrame = 0;
	private int points = 0;
	private GuiPoints guiPoints;

	void Start() {
		newGame ();

		//Game Object mit dem Tag GUI_Points finden
		GameObject guiHeadUp = GameObject.FindGameObjectWithTag ("GUI_Points");
		if (guiHeadUp == null)
		{
			Debug.LogError("There is no Gui_Points object in the scene!");
			return;
		}

		//Instanz des Scripts GuiPoints auf dem GameObject finden, Zugriff ermöglichen
		guiPoints = guiHeadUp.GetComponent <GuiPoints>();



	}

	void FixedUpdate () {
		if (gameRunning) {
			currentFrame++;
			CountPoints();
		}
	}

	private void CountPoints() {
		if (currentFrame % 10 == 0) {
			points++;
		
			//Punkte an die Gui übertragen
			guiPoints.Points = points;
		}

	}





}

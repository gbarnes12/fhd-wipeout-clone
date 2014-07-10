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

	void Start() {
		newGame ();
	}

	void Update () {
		if (gameRunning) {
			currentFrame++;
			CountPoints();
		}
	}

	private void CountPoints() {
		if (currentFrame % 10 == 0) {
			points++;
			Debug.Log (points);
		}

	}

	void OnGUI() {
			GUI.Box (new Rect (10, 10, 50, 40), "Points" + "\n" + points);

	}




}

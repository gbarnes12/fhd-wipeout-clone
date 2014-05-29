using UnityEngine;
using System.Collections;

public class VehicleSound : MonoBehaviour {

	//------------------
	//FINAL

	private float currentSpeed = 100.0f;
	public float mediaSpeed = 100.0f; //speed at which the audio pitch is 1.0


	void Update () {
		EngineSound ();
	}


	
	void EngineSound() {
		//TO-DO: Get Speed of Current Tube
		//currentSpeed = getCurrentSpeed();
		audio.pitch = currentSpeed / mediaSpeed;
	}



}

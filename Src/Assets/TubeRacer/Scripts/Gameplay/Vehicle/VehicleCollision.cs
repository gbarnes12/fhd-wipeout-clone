using UnityEngine;
using System.Collections;
using Gameplay.Vehicle;

public class VehicleCollision : MonoBehaviour 
{

	public Transform explosion;
	public Transform fire;
	public AudioSource vehicleExplosion;

	private VehicleController vehicleController;
	private VehicleSound vehicleSound;
	private ScoreController scoreController;
	private GuiReplay guiReplay;

	private GameObject player;
	private GameObject vehicle;
	private GameObject thruster;


	void Start(){
		guiReplay = GameObject.FindGameObjectWithTag ("GUI_Replay").GetComponent<GuiReplay>(); 
		scoreController = GameObject.FindGameObjectWithTag ("WorldManager").GetComponent<ScoreController> ();
		thruster = GameObject.FindGameObjectWithTag ("Thruster");
		player = GameObject.FindGameObjectWithTag ("Player");

		vehicleSound = player.GetComponent<VehicleSound> ();
		vehicleController = player.GetComponent<VehicleController>();

		vehicleSound.GameRunning = true;

	}

	void OnCollisionEnter(Collision other){

		if (!other.gameObject.name.Equals("Prfb_Lvl_Tube")) {

				vehicleExplosion.Play();

				vehicleSound.GameRunning = false;
				scoreController.gameRunning = false;
				vehicleController.GameRunning = false;

				
				guiReplay.StartMenuReplay();

				//Vector3 posRacer = gameObject.transform.position+new Vector3(0,0,-13.5f);

				//Object exp = Instantiate(explosion, posRacer, Quaternion.identity);
				//Object flames = Instantiate(fire, posRacer, Quaternion.identity);

				Debug.Log ("Collision bla with " + other.gameObject.name);

		}
	}
	
}
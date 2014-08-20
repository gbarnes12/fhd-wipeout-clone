using UnityEngine;
using System.Collections;
using Gameplay.World;

namespace Gameplay.Vehicle
{
	public class VehicleCollision : MonoBehaviour 
	{
		#region Public Inspector Members
		public WorldSpawnManager worldSpawnManager;

		public Transform explosion;
		public Transform fire;
		public AudioSource vehicleExplosion;
		#endregion

		#region Private Members
		private VehicleController vehicleController;
		private VehicleSound vehicleSound;
		private ScoreController scoreController;
		private GuiReplay guiReplay;

		private GameObject player;
		private GameObject vehicle;
		private GameObject thruster;
		#endregion

		#region Unity Methods
		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start(){
			guiReplay = GameObject.FindGameObjectWithTag ("GUI_Replay").GetComponent<GuiReplay>(); 
			worldSpawnManager = GameObject.FindGameObjectWithTag ("WorldManager").GetComponent<WorldSpawnManager> ();
			scoreController = worldSpawnManager.gameObject.GetComponent<ScoreController>();
			thruster = GameObject.FindGameObjectWithTag ("Thruster");
			player = GameObject.FindGameObjectWithTag ("Player");

			vehicleSound = player.GetComponent<VehicleSound> ();
			vehicleController = player.GetComponent<VehicleController>();

		}

		/// <summary>
		/// Raises the collision enter event.
		/// </summary>
		/// <param name="other">Other.</param>
		void OnCollisionEnter(Collision other){

			if (other.gameObject.tag == "Obstacle") 
			{
					vehicleSound.PassBySound.Stop();
					vehicleExplosion.Play();

					worldSpawnManager.GameRunning = false;
					
					guiReplay.StartMenuReplay();

					//Vector3 posRacer = gameObject.transform.position+new Vector3(0,0,-13.5f);

					//Object exp = Instantiate(explosion, posRacer, Quaternion.identity);
					//Object flames = Instantiate(fire, posRacer, Quaternion.identity);

					Debug.Log ("Collision bla with " + other.gameObject.name);
			}
		}
		#endregion
	}
}
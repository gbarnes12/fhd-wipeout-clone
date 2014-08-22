using UnityEngine;
using System.Collections;
using Gameplay.World;

namespace Gameplay.Vehicle
{
	public class VehicleCollision : MonoBehaviour 
	{
		#region Public Inspector Members
		//public Transform explosion;
		//public Transform fire;
		//public AudioSource vehicleExplosion;
		public GameObject Vehicle;
		public GameObject VehicleFragments;
		#endregion

		#region Private Members
		private VehicleController vehicleController;
		private VehicleSound vehicleSound;
		private ScoreController scoreController;
		private GuiReplay guiReplay;

		private GameObject player;
		private GameObject vehicle;
		#endregion

		#region Unity Methods
		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start(){
			guiReplay = GameObject.FindGameObjectWithTag ("GUI").GetComponent<GuiReplay>(); 
			scoreController = Gameplay.World.WorldSpawnManager.Instance.GetComponent<ScoreController>();
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
				//explode vehicle
				GameObject fragments = (GameObject)Instantiate(this.VehicleFragments, this.Vehicle.transform.position,this.Vehicle.transform.rotation);
				fragments.GetComponent<VehicleExplosion>().Explode(vehicleController.MoveDirection);

				Destroy(this.Vehicle);

				//deactivate thrusters
				vehicleController.LeftThruster.gameObject.SetActive(false);
				vehicleController.RightThruster.gameObject.SetActive(false);
				vehicleSound.PassBySound.Stop();
				//vehicleExplosion.Play();

				Gameplay.World.WorldSpawnManager.Instance.GameRunning = false;
				
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
using UnityEngine;
using System.Collections;


namespace Gameplay.Vehicle 
{
	/// <summary>
	/// Vehicle sound.
	/// </summary>
	public class VehicleSound : MonoBehaviour 
	{
		//------------------
		//FINAL
		
		#region Public Inspector Members
		public float MediaSpeed = 250.0f; //speed at which the audio pitch is 1.0
		public AudioSource VehicleEngine;
		public AudioSource VehicleEvade;
		public AudioSource PassBySound;
		#endregion

		#region Unity Methods
		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update () 
		{
			if (!Gameplay.World.WorldSpawnManager.Instance.GameRunning) {
				VehicleEngine.Stop();
				VehicleEvade.Stop();
			}else{
				EngineSound ();
				EvadeSound ();
			}			
		}
		
		/// <summary>
		/// Engines the sound.
		/// </summary>
		void EngineSound() 
		{
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			VehicleController controller = player.GetComponent<VehicleController> ();
			float currentSpeed = controller.Speed;
			if (currentSpeed < 100)
				currentSpeed = 100;
			else if (currentSpeed > 1200)
				currentSpeed = 1200;
			VehicleEngine.pitch = currentSpeed / this.MediaSpeed;
		}
		
		/// <summary>
		/// Plays the evade sound.
		/// </summary>
		void EvadeSound() 
		{
			if (Input.GetButtonDown ("Horizontal")) {
				VehicleEvade.loop = true;
				VehicleEvade.Play ();
				
			}
			if (Input.GetButtonUp("Horizontal")) {
				VehicleEvade.loop = false;
				VehicleEvade.Stop();
			}
		}
		#endregion
	}
}

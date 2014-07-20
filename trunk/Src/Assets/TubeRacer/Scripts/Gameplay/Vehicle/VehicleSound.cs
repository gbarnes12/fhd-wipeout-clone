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
		public AudioSource vehicleEngine;
		public AudioSource vehicleEvade;

		public bool GameRunning = true;
		#endregion
		
		#region Private Members
		#endregion
		
		#region Unity Methods
		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update () 
		{

			EngineSound ();
			EvadeSound ();

			if (!GameRunning) {
				vehicleEngine.audio.Stop();
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
			vehicleEngine.pitch = currentSpeed / this.MediaSpeed;
		}
		
		/// <summary>
		/// Plays the evade sound.
		/// </summary>
		void EvadeSound() 
		{
			if (Input.GetButtonDown ("Horizontal")) {
				vehicleEvade.loop = true;
				vehicleEvade.Play ();
				
			}
			if (Input.GetButtonUp("Horizontal")) {
				vehicleEvade.loop = false;
				vehicleEvade.Stop();
			}
		}
		#endregion
	}
}

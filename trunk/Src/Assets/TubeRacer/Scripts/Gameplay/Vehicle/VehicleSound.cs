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
		public float MediaSpeed = 100.0f; //speed at which the audio pitch is 1.0
		public AudioSource vehicleEngine;
		public AudioSource vehicleEvade;
		#endregion

		#region Private Members
		private float _currentSpeed = 100.0f;
		#endregion

		#region Unity Methods
		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update () 
		{
			EngineSound ();
			EvadeSound ();

		}

		/// <summary>
		/// Engines the sound.
		/// </summary>
		void EngineSound() 
		{
			//TO-DO: Get Speed of Current Tube
			//currentSpeed = getCurrentSpeed();
			vehicleEngine.pitch = this._currentSpeed / this.MediaSpeed;
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

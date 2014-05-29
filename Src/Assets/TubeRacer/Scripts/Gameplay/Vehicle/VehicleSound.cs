using UnityEngine;
using System.Collections;


namespace Gameplay.Vehicle 
{
	public class VehicleSound : MonoBehaviour 
	{
		//------------------
		//FINAL

		#region Public Inspector Members
		public float MediaSpeed = 100.0f; //speed at which the audio pitch is 1.0
		#endregion

		#region Private Members
		private float _currentSpeed = 100.0f;
		#endregion

		#region Unity Methods
		void Update () 
		{
			EngineSound ();
		}

		void EngineSound() 
		{
			//TO-DO: Get Speed of Current Tube
			//currentSpeed = getCurrentSpeed();
			audio.pitch = this._currentSpeed / this.MediaSpeed;
		}
		#endregion
	}
}

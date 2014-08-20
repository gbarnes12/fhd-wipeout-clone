using UnityEngine;
using System.Collections;

namespace Gameplay.World
{
	public class WorldObstacle : MonoBehaviour {

		#region Public Inspector Members
		public float PassByPitch = 1.0f;
		#endregion

		#region Protected Members
		protected Transform _cachedTransform;
		protected Transform _obstaclesParent;
		#endregion

		#region Private Members
		private Transform _vehicle;
		private Vehicle.VehicleSound _vehicleSound;
		private bool _passByPlayed = false;
		#endregion

		#region Unity Methods
		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start () 
		{
			_cachedTransform = this.transform;
			_obstaclesParent = _cachedTransform.parent;

			WorldSpawnManager.Instance.RegisterObstacle(this);
			this.gameObject.SetActive(false);

			this._vehicle = GameObject.FindGameObjectWithTag("Player").transform;
			this._vehicleSound = this._vehicle.gameObject.GetComponent<Vehicle.VehicleSound>();
		}

		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update()
		{
			if(this._cachedTransform.position.z - this._vehicle.position.z <= 60)
			{
				if(!_passByPlayed)
				{
					this._vehicleSound.PassBySound.pitch = this.PassByPitch;
					_passByPlayed = true;
					this._vehicleSound.PassBySound.Play();
				}
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Attachs to chunk.
		/// </summary>
		/// <param name="chunk">Chunk.</param>
		public virtual void AttachToChunk(WorldTubeChunk chunk)
		{
			this._passByPlayed = false;
			this._cachedTransform.parent = chunk.transform;
			this._cachedTransform.localPosition = Vector3.zero;
			
			float rndRot = Random.Range(0.0f, 360.0f);
			this._cachedTransform.eulerAngles = new Vector3(this._cachedTransform.eulerAngles.x, this._cachedTransform.eulerAngles.y, rndRot);
		}

		/// <summary>
		/// Detachs from chunk.
		/// </summary>
		public virtual void DetachFromChunk()
		{
			this._cachedTransform.parent = _obstaclesParent;
			this._cachedTransform.localPosition = Vector3.zero;
			this._cachedTransform.eulerAngles = new Vector3(this._cachedTransform.eulerAngles.x, this._cachedTransform.eulerAngles.y, 0.0f);
		}

		#endregion
	}
}

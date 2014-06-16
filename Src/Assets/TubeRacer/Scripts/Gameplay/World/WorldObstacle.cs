using UnityEngine;
using System.Collections;

namespace Gameplay.World
{
	public class WorldObstacle : MonoBehaviour {

		#region Public Members
		public enum ObstacleType
		{
			Ventilator,
			Steelbar,
			ClosingDoor,
			Door,
			Wall,
			Generator
		}

		public ObstacleType Type;
		#endregion

		#region Private Members
		private Transform _cachedTransform;
		private Transform _obstaclesParent;
		#endregion

		#region Unity Methods
		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start () 
		{
			_cachedTransform = this.transform;
			_obstaclesParent = _cachedTransform.parent;

			WorldSpawnManager.Instance.RegisterObstacle(this);
			this.gameObject.SetActive(false);
		}

		#endregion

		#region Public Methods
		/// <summary>
		/// Initialize the specified type.
		/// </summary>
		/// <param name="type">Type.</param>
		public void Initialize()
		{
			this.gameObject.SetActive(true);

			switch(this.Type){
			case ObstacleType.Ventilator:
				break;
			case ObstacleType.Steelbar:
				break;
			case ObstacleType.ClosingDoor:
				break;
			case ObstacleType.Door:
				break;
			case ObstacleType.Wall:
				break;
			case ObstacleType.Generator:
				break;
			}
		}

		/// <summary>
		/// Attachs to chunk.
		/// </summary>
		/// <param name="chunk">Chunk.</param>
		public void AttachToChunk(WorldTubeChunk chunk)
		{
			this._cachedTransform.parent = chunk.transform;
			this._cachedTransform.localPosition = Vector3.zero;
			
			float rndRot = Random.Range(0.0f, 360.0f);
			this._cachedTransform.eulerAngles = new Vector3(this._cachedTransform.eulerAngles.x, this._cachedTransform.eulerAngles.y, rndRot);
		}

		/// <summary>
		/// Detachs from chunk.
		/// </summary>
		public void DetachFromChunk()
		{
			this._cachedTransform.parent = _obstaclesParent;
			this._cachedTransform.localPosition = Vector3.zero;
			this._cachedTransform.eulerAngles = new Vector3(this._cachedTransform.eulerAngles.x, this._cachedTransform.eulerAngles.y, 0.0f);
		}
		#endregion

	}
}

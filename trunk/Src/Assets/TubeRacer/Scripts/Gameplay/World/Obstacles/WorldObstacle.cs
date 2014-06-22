using UnityEngine;
using System.Collections;

namespace Gameplay.World
{
	public class WorldObstacle : MonoBehaviour {

		#region Protected Members
		protected Transform _cachedTransform;
		protected Transform _obstaclesParent;
		#endregion

		#region Unity Methods
		/// <summary>
		/// Start this instance.
		/// </summary>
		public virtual void Start () 
		{
			_cachedTransform = this.transform;
			_obstaclesParent = _cachedTransform.parent;

			WorldSpawnManager.Instance.RegisterObstacle(this);
			this.gameObject.SetActive(false);
		}
		#endregion

		#region Public Methods
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

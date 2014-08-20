using UnityEngine;
using System.Collections;

namespace Gameplay.World
{
	public class ObstacleSteelbar : WorldObstacle {

		#region Public Inspector Members
		public Transform[] Steelbars;
		#endregion

		#region Private Members
		private int _randomSteelbar;
		private float _cachedSteelbarRotZ;
		#endregion

		#region Unity Methods
		// Use this for initialization

		#endregion

		#region Public Methods
		/// <summary>
		/// Attachs to chunk.
		/// </summary>
		/// <param name="chunk">Chunk.</param>
		public override void AttachToChunk(WorldTubeChunk chunk)
		{
			base.AttachToChunk(chunk);

			//Set a random steelbar to a random local rotation
			this._randomSteelbar = Random.Range(0, Steelbars.Length);
			float rotationZ = Random.Range(0.0f, 360.0f);
			this._cachedSteelbarRotZ = this.Steelbars[this._randomSteelbar].localEulerAngles.z;
			this.Steelbars[this._randomSteelbar].localEulerAngles = new Vector3(0, 0, rotationZ);

		}

		/// <summary>
		/// Detachs from chunk.
		/// </summary>
		public override void DetachFromChunk()
		{
			base.DetachFromChunk();

			//Reset rotation of previously random chosen steelbar
			this.Steelbars[this._randomSteelbar].localEulerAngles = new Vector3(0, 0, this._cachedSteelbarRotZ);
		}
		#endregion
	}
}
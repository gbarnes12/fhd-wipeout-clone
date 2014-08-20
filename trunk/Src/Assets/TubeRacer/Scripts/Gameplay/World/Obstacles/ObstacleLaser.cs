using UnityEngine;
using System.Collections;

namespace Gameplay.World
{
	public class ObstacleLaser : WorldObstacle {

		#region Public Inspector Members
		public Transform[] Lasers;
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
			
			//Set random local rotation for each laser
			foreach(Transform laser in Lasers)
			{
				float rndRotZ = Random.Range(0.0f, 360.0f);
				laser.localEulerAngles = new Vector3(0,0, rndRotZ);
			}
		}
		#endregion
	}
}

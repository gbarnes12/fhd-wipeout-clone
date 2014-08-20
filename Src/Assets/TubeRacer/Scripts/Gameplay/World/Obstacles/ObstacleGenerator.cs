using UnityEngine;
using System.Collections;

namespace Gameplay.World
{
	public class ObstacleGenerator : WorldObstacle {

		#region Public Inspector Members
		public Transform[] Generators;
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
			
			//Set random local rotation for each generator
			foreach(Transform generator in Generators)
			{
				float rndRotZ = Random.Range(0.0f, 360.0f);
				generator.RotateAround(Vector3.zero, Vector3.forward, rndRotZ);
			}
		}
		#endregion
	}
}
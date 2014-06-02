using UnityEngine;
using System.Collections;

namespace Gameplay.World
{
    /// <summary>
    /// Represents a piece of the entire world racing track.
	/// This is necessary in order to determine when the player vehicle
	/// leaves the tube. It will be also used to determine how long this
	/// specific tube piece is!
    /// </summary>
    public class WorldTubeChunk : MonoBehaviour
    {
		#region Unity Methods
		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start() 
		{
		}
		#endregion

		#region Private Events
		/// <summary>
		/// Raises the exit trigger event.
		/// </summary>
		/// <param name="other">Other.</param>
        void OnTriggerExit(Collider other)
        {
            if (!other.tag.Equals("Player"))
                return;

            StartCoroutine(WorldSpawnManager.Instance.AddChunkToQueue(this));
        }
		#endregion
    }
}

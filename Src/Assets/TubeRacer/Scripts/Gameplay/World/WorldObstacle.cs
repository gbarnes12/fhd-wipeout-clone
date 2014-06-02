using UnityEngine;
using System.Collections;

namespace Gameplay.World
{
	public class WorldObstacle : MonoBehaviour {

		#region Unity Methods
		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start () 
		{
			WorldSpawnManager.Instance.RegisterObstacle(this);
			this.gameObject.SetActive(false);
		}
		#endregion
	}
}

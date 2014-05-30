using UnityEngine;
using System.Collections;
using Utilities;
using System.Collections.Generic;


namespace Gameplay.World
{
    /// <summary>
    /// The class is used in order to move the world and spawn new items,
	/// thus the racing track seems to be infinite. This is achieved by 
	/// replacing the tubes at the end of the track once we passed them!
    /// </summary>
    public class WorldSpawnManager : Singleton<WorldSpawnManager>
    {
        #region Inner Class
        /// <summary>
        /// 
        /// </summary>
        private class WorldChunkSorter : IComparer<WorldTubeChunk>
        {
            /// <summary>
            /// Compares two world tube chunk elements by it's z component!
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(WorldTubeChunk x, WorldTubeChunk y)
            {
                return x.transform.position.z.CompareTo(y.transform.position.z);
            }
        }
        #endregion

        #region Private Members
        private LinkedList<WorldTubeChunk> _tubeChunksList;
        private List<WorldTubeChunk> _tubeChunksQueue;
		private float _vehicleSpeed;
        #endregion

        #region Construct
        /// <summary>
        /// Protected in order to prevent copying!
        /// </summary>
        protected WorldSpawnManager() 
        {
            this._tubeChunksQueue = new List<WorldTubeChunk>();
			this._vehicleSpeed = 400.0f;
        }
        #endregion

        #region Unity Methods
        /// <summary>
        /// Initializes the world.
        /// </summary>
        void Start()
        {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			if (player == null) 
			{
				Debug.LogError("There is no player object in the scene!");
				return;
			}

			VehicleController controller = player.GetComponent<VehicleController> ();
			this._vehicleSpeed = controller.Speed;

            GameObject levelObject = GameObject.FindGameObjectWithTag("World");
            if (levelObject == null)
            {
                Debug.LogError("There is no world object in the scene please add one!");
                return;
            }

            WorldTubeChunk[] chunks = levelObject.GetComponentsInChildren<WorldTubeChunk>();
            if (chunks.Length == 0)
            {
                Debug.LogError("There are no world tube chunk elements!");
                return;
            }

            List<WorldTubeChunk> temporaryChunkList = new List<WorldTubeChunk>();
            foreach (WorldTubeChunk chunk in chunks)
                temporaryChunkList.Add(chunk);

            temporaryChunkList.Sort(new WorldChunkSorter());
            this._tubeChunksList = new LinkedList<WorldTubeChunk>(temporaryChunkList);
        }

        /// <summary>
        /// Moves the tubes!
        /// </summary>
        void Update()
        {
            foreach(WorldTubeChunk tube in this._tubeChunksList)
            {
				tube.transform.Translate(new Vector3(0.0f, 0.0f, -1.0f * Time.deltaTime * this._vehicleSpeed));
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Spawns the queued chunks after we have collected three! This is used as a coroutine!
        /// </summary>
        /// <returns></returns>
        private IEnumerator SpawnTubeChunks()
        {
            List<WorldTubeChunk> copiedList = new List<WorldTubeChunk>(this._tubeChunksQueue);

            foreach(WorldTubeChunk chunk in copiedList)
            {
                yield return null;

                LinkedListNode<WorldTubeChunk> lastNode = this._tubeChunksList.Last;
                chunk.transform.position = new Vector3(chunk.transform.position.x, chunk.transform.position.y, lastNode.Value.transform.position.z + 350);
                this._tubeChunksList.AddLast(chunk);
                this._tubeChunksQueue.Remove(chunk);
				chunk.gameObject.SetActive(true);
            }

            copiedList.Clear();
            yield break;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds the chunk to the queue in order to respawn it.
        /// </summary>
        /// <param name="chunk">The chunk</param>
        public void AddChunkToQueue(WorldTubeChunk chunk)
        {
			if (chunk == null)
				return;

            this._tubeChunksList.Remove(chunk);
            this._tubeChunksQueue.Add(chunk);
			chunk.gameObject.SetActive(false);

             if(this._tubeChunksQueue.Count >= 3)
                 StartCoroutine("SpawnTubeChunks");
        }
        #endregion

    }
}

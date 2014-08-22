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
		private List<WorldObstacle> _obstaclesList;
		private float _vehicleSpeed;
		private VehicleController _controller;
		#endregion
		
		#region Public Members
		public bool GameRunning = false;
		public float FOVStrength = 100;
		
		#endregion
		
		#region Construct
		/// <summary>
		/// Protected in order to prevent copying!
		/// </summary>
		protected WorldSpawnManager()
		{
			this._tubeChunksQueue = new List<WorldTubeChunk>();
		}
		#endregion
		
		#region Unity Methods
		/// <summary>
		/// Initializes the world.
		/// </summary>
		IEnumerator Start()
		{
			yield return StartCoroutine(StartCameraSequence());

			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			if (player == null)
			{
				Debug.LogError("There is no player object in the scene!");
				yield break;
			}
			
			_controller  = player.GetComponent<VehicleController> ();
			this._vehicleSpeed = _controller.Speed;
			
			GameObject levelObject = GameObject.FindGameObjectWithTag("World");
			if (levelObject == null)
			{
				Debug.LogError("There is no world object in the scene please add one!");
				yield break;
			}
			
			WorldTubeChunk[] chunks = levelObject.GetComponentsInChildren<WorldTubeChunk>();
			if (chunks.Length == 0)
			{
				Debug.LogError("There are no world tube chunk elements!");
				yield break;
			}
			
			List<WorldTubeChunk> temporaryChunkList = new List<WorldTubeChunk>();
			foreach (WorldTubeChunk chunk in chunks)
				temporaryChunkList.Add(chunk);
			
			temporaryChunkList.Sort(new WorldChunkSorter());
			this._tubeChunksList = new LinkedList<WorldTubeChunk>(temporaryChunkList);

			_controller.Speed = 200f;
			_controller.LeftThruster.gameObject.SetActive(true);
			_controller.RightThruster.gameObject.SetActive(true);

			this.GameRunning = true;
		}
		
		/// <summary>
		/// Moves the tubes!
		/// </summary>
		void Update()
		{
			if(this.GameRunning)
			{
				this._vehicleSpeed = _controller.Speed;
				foreach(WorldTubeChunk tube in this._tubeChunksList)
				{
					tube.transform.Translate(new Vector3(0.0f, 0.0f, -1.0f * Time.deltaTime * this._vehicleSpeed));
				}
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
				AddRandomObstacleToChunk(chunk);
				chunk.gameObject.SetActive(true);
			}
			
			copiedList.Clear();
			yield break;
		}
		
		/// <summary>
		/// Adds the random obstacle.
		/// </summary>
		/// <returns>The random obstacle.</returns>
		private void AddRandomObstacleToChunk(WorldTubeChunk chunk)
		{
			if(_obstaclesList == null)
			{
				Debug.Log("There are no obstacles in the scene! Please activate or add obstacles to scene");
				return;
			}
			
			int rndObstacle = (int)Random.Range(0, _obstaclesList.Count);
			WorldObstacle obstacle = (rndObstacle > _obstaclesList.Count)? _obstaclesList[rndObstacle-1] : _obstaclesList[rndObstacle];
			
			if(obstacle.gameObject.activeSelf)
				return;
			
			obstacle.AttachToChunk(chunk);
			obstacle.gameObject.SetActive(true);
		}
		
		/// <summary>
		/// Removes the obstacles from chunk.
		/// </summary>
		/// <param name="chunk">Chunk.</param>
		private IEnumerator RemoveObstaclesFromChunk(WorldTubeChunk chunk)
		{
			WorldObstacle[] obstacles = chunk.transform.GetComponentsInChildren<WorldObstacle>();
			foreach(WorldObstacle obstacle in obstacles)
			{
				obstacle.DetachFromChunk();
				obstacle.gameObject.SetActive(false);
				yield return null;
			}
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		/// Adds the chunk to the queue in order to respawn it.
		/// </summary>
		/// <param name="chunk">The chunk</param>
		public IEnumerator AddChunkToQueue(WorldTubeChunk chunk)
		{
			if (chunk == null)
				yield break;
			
			this._tubeChunksList.Remove(chunk);
			this._tubeChunksQueue.Add(chunk);
			
			StartCoroutine(RemoveObstaclesFromChunk(chunk));
			
			chunk.gameObject.SetActive(false);
			
			if(this._tubeChunksQueue.Count >= 3)
				StartCoroutine("SpawnTubeChunks");
		}
		
		/// <summary>
		/// Registers the obstacle.
		/// </summary>
		/// <param name="obstacle">Obstacle.</param>
		public void RegisterObstacle(WorldObstacle obstacle)
		{
			if(_obstaclesList == null)
				_obstaclesList = new List<WorldObstacle>();
			
			if(obstacle == null)
				return;
			
			this._obstaclesList.Add (obstacle);
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Starts the camera sequence.
		/// </summary>
		/// <returns>The camera sequence.</returns>
		private IEnumerator StartCameraSequence()
		{
			//Move camera to show vehicle
			float lerpTime = 0;
			while(Camera.main.transform.localPosition.z > -35)
			{
				 
				Camera.main.transform.localPosition = new Vector3 (Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y,
				                                                   Mathf.Lerp(0, -35, Mathf.SmoothStep(0, 1, lerpTime)));
				lerpTime += Time.deltaTime;
				yield return null;
			}

			StartCoroutine(GameObject.FindGameObjectWithTag("GUI").GetComponent<GuiPoints>().StartCountdown(3));

			yield return new WaitForSeconds(3);

			StartCoroutine(FOVAccelarionEffect());
		}

		/// <summary>
		/// Cameras the FOV accelarion effect.
		/// </summary>
		/// <returns>The FOV accelarion effect.</returns>
		private IEnumerator FOVAccelarionEffect()
		{
			float lerpTime = 0;
			float startFOV = Camera.main.fieldOfView;
			while(Camera.main.fieldOfView < FOVStrength)
			{
				Camera.main.fieldOfView = Mathf.Lerp(startFOV, FOVStrength, Mathf.SmoothStep(0, 1, lerpTime));
				lerpTime += Time.deltaTime;
				yield return null;
			}

			lerpTime = 0;

			while(Camera.main.fieldOfView > startFOV + 15)
			{
				Camera.main.fieldOfView = Mathf.Lerp(FOVStrength, startFOV + 15, Mathf.SmoothStep(0, 1, lerpTime));
				lerpTime += Time.deltaTime;
				yield return null;
			}
		}
		#endregion
	}
}
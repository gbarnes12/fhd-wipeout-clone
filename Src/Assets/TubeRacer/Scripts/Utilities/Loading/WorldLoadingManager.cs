using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utilities;
using Utilities.Loading.Processors;

namespace Utilities.Loading
{
    #region Event Types
	/// <summary>
	/// World loading finished event.
	/// </summary>
    public class WorldLoadingFinishedEvent {}
	/// <summary>
	/// World loading failed event.
	/// </summary>
    public class WorldLoadingFailedEvent
    {
        public string Reason;

		/// <summary>
		/// Initializes a new instance of the <see cref="Utilities.Loading.WorldLoadingFailedEvent"/> class.
		/// </summary>
		/// <param name="reason">Reason.</param>
        public WorldLoadingFailedEvent(string reason)
        {
            this.Reason = reason;
        }
    }
    #endregion

    /// <summary>
    /// The world loading manager can be used to load 
    /// a new level with the necessary steps!
    /// </summary>
    public class WorldLoadingManager : Singleton<WorldLoadingManager>
    {
        #region Private Members
        private List<WorldLoadingProcessor> _processors;
        private WorldLoadingProcessor _activeLoader;
        private WorldLoadingProcessor _previousLoader;
        private bool _isLoading;
        private string _sceneFile;
        private int _i;
        #endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Utilities.Loading.WorldLoadingManager"/> class.
		/// </summary>
		protected WorldLoadingManager() 
        {
            this._processors = new List<WorldLoadingProcessor>();
            this._isLoading = false;
            this._activeLoader = null;
            this._previousLoader = null;
            this._sceneFile = null;
        }
        #endregion

        #region Unity Methods
		/// <summary>
		/// Update this instance.
		/// </summary>
        void Update()
        {
            if (!this._isLoading)
                return;

            if (this._sceneFile == null)
                return;

            if (this._processors.Count == 0)
                return;

            if (!this._activeLoader.Run(this._previousLoader))
                return;

            // increment the counter!
            this._i++;

            if(this._processors.Count == this._i)
            {
                this._processors.Clear();
                this._isLoading = false;
                this._i = 0;
                this._previousLoader = null;
                this._activeLoader = null;

				GameObject guiManager = GameObject.Find ("Loading UI Root");
                if (guiManager == null) 
                {
                    EventSystem.EventSystem.getInstance().executeEvent<WorldLoadingFailedEvent>(
                                               new WorldLoadingFailedEvent("No Loading Screen UI root found!"),
                                               EventSystem.EventSystem.ExecuteMode.Immediate);
                }
				
                GameObject.Destroy(guiManager);

                EventSystem.EventSystem.getInstance().executeEvent<WorldLoadingFinishedEvent>(
                                new WorldLoadingFinishedEvent(), 
                                EventSystem.EventSystem.ExecuteMode.Immediate);

                return;
            }

            this._previousLoader = this._activeLoader;
            this._activeLoader = this._processors[this._i];
            this._activeLoader.Start(this._sceneFile);

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Loads a new level with all the necessary networking steps!
        /// </summary>
        /// <param name="name"></param>
        public void LoadLevel(string name)
        {
            if (this._isLoading)
            {
                EventSystem.EventSystem.getInstance().executeEvent<WorldLoadingFailedEvent>(
                                                new WorldLoadingFailedEvent("Manager is already loading!"), 
                                                EventSystem.EventSystem.ExecuteMode.Immediate);
                return;
            }
            
            this._processors.Clear();
            this._i = 0;
 
            // load the loading scene!
            Application.LoadLevel("Scn_Glbl_Loading");

            this._sceneFile = name;
            this._isLoading = true;

            // create processors
            this._processors.Add(new SceneLoadingProcessor());

            // if there is no active loader yet
            this._activeLoader = _processors[this._i];
            this._activeLoader.Start(this._sceneFile);
        }
        #endregion
    }
}

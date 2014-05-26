using UnityEngine;
using System.Collections;

namespace Utilities.Loading.Processors
{
    /// <summary>
    /// 
    /// </summary>
    public class SceneLoadingProcessor : WorldLoadingProcessor 
    {
        private AsyncOperation _operation = null;
		private float _start;
		private bool _isLoading;
		private string _sceneFile;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool Run(WorldLoadingProcessor previousProcessor)
        {
			float deltaTime = Time.realtimeSinceStartup - this._start;
			if (deltaTime >= 3.0f && !_isLoading) 
			{ 
				_isLoading = true;
				_operation = Application.LoadLevelAdditiveAsync (_sceneFile);
			}

			if (_operation == null)
				return false;

			if (!_operation.isDone)
				return false;


			return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SceneFile"></param>
        /// <returns></returns>
        public override bool Start(string SceneFile)
        {
			this._sceneFile = SceneFile;
			this._isLoading = false;
            this.IsRunning = true;
			this._start = Time.realtimeSinceStartup;
            return true;
        }

    }
}

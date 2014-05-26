using UnityEngine;
using System.Collections;

namespace Utilities.Loading
{
    public abstract class WorldLoadingProcessor
    {
        public bool IsRunning
        {
            get;
            set;
        }

        public abstract bool Start(string SceneFile);
        public abstract bool Run(WorldLoadingProcessor previousProcessor);
    }
}

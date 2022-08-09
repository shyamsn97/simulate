using System.Collections.Generic;

namespace SimEnv {
    /// <summary>
    /// Helper class if you only want to override some methods.
    /// </summary>
    public abstract class PluginBase : IPlugin {
        public virtual void OnCreated() { }
        public virtual void OnReleased() { }
        public virtual void OnSceneInitialized(Dictionary<string, object> kwargs) { }
        public virtual void OnBeforeStep(EventData eventData) { }
        public virtual void OnStep(EventData eventData) { }
        public virtual void OnReset() { }
        public virtual void OnBeforeSceneUnloaded() { }
    }
}
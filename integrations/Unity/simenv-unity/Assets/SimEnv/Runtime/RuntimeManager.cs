using UnityEngine;
using SimEnv.GLTF;
using System.Collections.Generic;
using UnityEngine.Events;
namespace SimEnv {
    [CreateAssetMenu(fileName = "RuntimeManager", menuName = "SimEnv/Runtime Manager")]
    public class RuntimeManager : SingletonScriptableObject<RuntimeManager> {
        static int frameRate = 30;
        const int FRAME_SKIP = 10;
        static float frameInterval => 1f / frameRate;
        GameObject root = null;
        GameObject agent = null;
        Agent agentScript = null;
        public void BuildSceneFromBytes(byte[] bytes) {
            Physics.autoSimulation = false;
            root = Importer.LoadFromBytes(bytes);
            Debug.Log("environment built");
            agent = GameObject.FindWithTag("Agent");

            if (agent) {
                Debug.Log("found agent");
                agentScript = agent.GetComponent<Agent>();
            }

        }
        public void Step(List<float> action) {
            
            if (agentScript) {
                Debug.Log("stepping agent");
                agentScript.SetAction(action);
            } else {
                Debug.Log("Warning, attempting to step environment with an agent");
            }
            // Step the agent for a number of timesteps
            for (int i = 0; i < FRAME_SKIP; i++) {
                if (agentScript) {
                    agentScript.AgentUpdate();
                }
                Physics.Simulate(frameInterval);
            }
        }

        public void GetObservation(UnityAction<string> callback) {
            // Calculate the agent's observation and send to python with callback
            agentScript.ObservationCoroutine(callback);
        }
    }
}
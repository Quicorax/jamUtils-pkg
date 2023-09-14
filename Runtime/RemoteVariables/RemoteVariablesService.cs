using System.Collections.Generic;
using Services.Runtime.ServiceManagement;
using UnityEngine;

namespace Services.Runtime.RemoteVariables
{
    public class RemoteVariablesService : IService
    {
        private class RemoteVariableType
        {
            public string Type;
            public string Value;
        }

        private const string DataPath = "RemoteData/RemoteVariables";

        private readonly Dictionary<string, string> _remoteVariables = new();

        public string GetString(string variableKey) => Get(variableKey);
        public int GetInt(string variableKey) => int.Parse(Get(variableKey));
        public float GetFloat(string variableKey) => float.Parse(Get(variableKey));

        public void Initialize()
        {
            var rawData = Resources.Load(DataPath).ToString();
            var serializedData = JsonUtility.FromJson<RemoteVariables>(rawData);

            foreach (var remoteVariable in serializedData.data)
            {
                _remoteVariables.Add(remoteVariable.VariableKey, remoteVariable.Value);
            }
        }

        public void Clear()
        {
            _remoteVariables.Clear();
        }

        private string Get(string variableKey)
        {
            if (!_remoteVariables.ContainsKey(variableKey))
            {
                Debug.LogError($"Remote Variable with key {variableKey} is not defined!");
                return null;
            }

            return _remoteVariables[variableKey];
        }
    }
}

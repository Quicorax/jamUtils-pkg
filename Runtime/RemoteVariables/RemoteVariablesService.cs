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

        private readonly Dictionary<string, RemoteVariableType> _remoteVariables = new();

        public string GetString(string variableKey) => (string)Get("string", variableKey);
        public int GetInt(string variableKey) => (int)Get("int", variableKey);
        public float GetFloat(string variableKey) => (float)Get("float", variableKey);

        public void Initialize()
        {
            var rawData = Resources.Load(DataPath).ToString();
            var serializedData = JsonUtility.FromJson<RemoteVariables>(rawData);

            foreach (var remoteVariable in serializedData.data)
            {
                _remoteVariables.Add(remoteVariable.VariableKey,
                    new RemoteVariableType { Type = remoteVariable.Type, Value = remoteVariable.Value });
            }
        }

        public void Clear()
        {
            _remoteVariables.Clear();
        }

        private object Get(string type, string variableKey)
        {
            if (!_remoteVariables.ContainsKey(variableKey))
            {
                Debug.LogError($"Remote Variable with key {variableKey} is not defined!");
                return null;
            }

            var remoteVariable = _remoteVariables[variableKey];
            return remoteVariable.Type switch
            {
                "int" => int.Parse(remoteVariable.Value),
                "float" => float.Parse(remoteVariable.Value),
                "string" => remoteVariable.Value,
                _ => null
            };
        }
    }
}

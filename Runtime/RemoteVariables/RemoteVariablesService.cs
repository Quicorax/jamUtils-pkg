using System.Collections.Generic;
using Services.Runtime.ServiceManagement;
using UnityEngine;

namespace Services.Runtime.RemoteVariables
{
    public class RemoteVariablesService : IService
    {
        private const string DataPath = "RemoteData/RemoteVariables";

        private readonly Dictionary<string, object> _remoteVariables = new();

        public object GetVariable(string variableKey)
        {
            var remoteVariable = _remoteVariables[variableKey];

            if (remoteVariable == null)
            {
                Debug.LogError($"Remote Variable with key {variableKey} is not defined!");
                return null;
            }

            return remoteVariable;
        }

        public void Initialize()
        {
            var rawData = Resources.Load(DataPath).ToString();
            var serializedData = JsonUtility.FromJson<RemoteVariables>(rawData);

            foreach (var remoteVariable in serializedData.data)
            {
                object value = remoteVariable.Type switch
                {
                    "int" => int.Parse(remoteVariable.Value),
                    "float" => float.Parse(remoteVariable.Value),
                    "string" => remoteVariable.Value,
                    _ => null
                };

                _remoteVariables.Add(remoteVariable.VariableKey, value);
            }
        }

        public void Clear()
        {
        }
    }
}
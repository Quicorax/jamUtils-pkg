using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Services.Editor.RemoteVariables
{
    public class RemoteVariablesUpdater
    {
        private const string URL =
            "https://script.google.com/macros/s/AKfycbwNefU_9V5ZkPvYJTgnzFio7YpnmdqX1IvrMk8tYmxGdSvpLA4KPV1lRlHSwY6tKraNUA/exec";

        [MenuItem("Quicorax/UpdateRemoteVariables")]
        public static void UpdateRemoteVariables()
        {
            Debug.Log("UPDATING Remote Variables...");

            var request = new UnityWebRequest(URL, "GET", new DownloadHandlerBuffer(), null);
            request.SendWebRequest().completed += _ =>
            {
                if (request.error != null)
                {
                    Debug.Log(request.error);
                    return;
                }

                Debug.Log("Remote Variables updated! -> " + request.downloadHandler.text);

                var remoteVariables = JsonUtility.FromJson<Runtime.RemoteVariables.RemoteVariables>(request.downloadHandler.text);

                File.WriteAllText(Application.dataPath + "/Resources/RemoteData/RemoteVariables.json", JsonUtility.ToJson(remoteVariables));
                AssetDatabase.Refresh();
            };
        }
    }
}
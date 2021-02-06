using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityWebRequestDemo
{
    public class WebRequestManager : MonoBehaviour
    {
        private static WebRequestManager instance = null;
        private float progress = 0;

        [HideInInspector]
        public string fetchedData = null;
        [HideInInspector]
        public bool isDataFetched = false;
        [HideInInspector]
        public bool isFetchingData = false;

        public delegate void FetchingCompleteAction(string fetchedData);
        public static event FetchingCompleteAction OnFetchComplete;

        public delegate void FetchingFailedAction(string fetchedData);
        public static event FetchingFailedAction OnFetchingFailed;

        public static WebRequestManager Instance
        {
            get
            {
                return instance;
            }
        }

        public float Progress
        {
            get
            {
                return progress;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(this);
            }
        }

        public void FatchData(string url = null)
        {
            if(!isDataFetched)
            {
                StartCoroutine(GetRequest(url == null ? Global.cloudDataUri : url));
            }
        }

        IEnumerator GetRequest(string url)
        {
            if (!isFetchingData)
            {
                isFetchingData = true;

                UnityWebRequest uwr = UnityWebRequest.Get(url);
                UnityWebRequestAsyncOperation op1 = uwr.SendWebRequest();

                while (!op1.isDone)
                {
                    progress = op1.progress;
                    yield return null;
                }

                progress = 1;

                if (uwr.isNetworkError)
                {
                    isFetchingData = false;
                    isDataFetched = false;
                    Debug.LogError("Error While Sending: " + uwr.error);
                }
                else
                {
                    isFetchingData = false;
                    isDataFetched = true;
                    fetchedData = uwr.downloadHandler.text;
                    OnFetchComplete?.Invoke(fetchedData);
                }
            }
        }
    }
}

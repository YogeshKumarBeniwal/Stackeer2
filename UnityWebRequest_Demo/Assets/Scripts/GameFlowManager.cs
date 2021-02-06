using UnityEngine;
using YogeshBen.Stackeer;

namespace UnityWebRequestDemo
{
    public class GameFlowManager : MonoBehaviour
    {
        [SerializeField]
        private ButtonViewManager buttonViewManager;

        private void Start()
        {
            FatchData();
        }

        public void FatchData()
        {
            Stackeer.ClearAllCachedFiles();
            Stackeer.Get().Load(Global.cloudDataUri).SetContentType(CONTENT_TYPE.JSON).WithJsonLoadedAction(OnJsonLoaded).SetEnableLog(true).StartStackeer();
        }

        public void OnJsonLoaded(string data)
        {
            Global.loadedServerData = JsonConverter.DeserializeObject<CloudImageData>(data);
        }

    }
}

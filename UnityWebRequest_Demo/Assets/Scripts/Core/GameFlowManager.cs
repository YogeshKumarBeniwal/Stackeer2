using UnityEngine;
using YogeshBen.Stackeer;

namespace UnityWebRequestDemo
{
    public class GameFlowManager : MonoBehaviour
    {
        [SerializeField]
        private bool clearCacheOnStart = false;
        [SerializeField]
        private DataViewManager dataViewManager;
        [SerializeField]
        private ButtonViewManager buttonViewManager;

        private void OnEnable()
        {
            ButtonViewManager.OnCloudDataReady += ShowDataView;
        }

        private void OnDisable()
        {
            ButtonViewManager.OnCloudDataReady -= ShowDataView;
        }

        private void Start()
        {
            if (clearCacheOnStart)
                Stackeer.ClearAllCachedFiles();

            ShowButtonView();
        }

        private void ShowButtonView()
        {
            buttonViewManager.gameObject.SetActive(true);
            dataViewManager.gameObject.SetActive(false);

            buttonViewManager.SetView();
        }

        private void ShowDataView()
        {
            buttonViewManager.gameObject.SetActive(false);
            dataViewManager.gameObject.SetActive(true);

            dataViewManager.SetView();
        }
    }
}

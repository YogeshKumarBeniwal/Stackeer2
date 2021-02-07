using System.Collections.Generic;
using UnityEngine;

namespace UnityWebRequestDemo
{
    public class DataViewManager : MonoBehaviour
    {
        [SerializeField]
        private CloudImagePrefabManager cloudImagePrefab;
        [SerializeField]
        private RectTransform prefabContainer;

        private bool isSetting = false;

        public void SetView()
        {
            if (!isSetting)
            {
                isSetting = true;

                if (Global.loadedServerData == null)
                {
                    if (Global.isDebuging)
                        Debug.LogError("Failed to set DataView!");

                    return;
                }

                List<CloudImageData> cloudImages = Global.loadedServerData.CloudImageData;
                int childCount = prefabContainer.childCount;

                CloudImagePrefabManager tempObj;
                int i = 0;

                for (i = 0; i < cloudImages.Count; i++)
                {
                    if (i < childCount)
                    {
                        tempObj = prefabContainer.GetChild(i).GetComponent<CloudImagePrefabManager>();
                        tempObj.SetPrefab(cloudImages[i]);
                        continue;
                    }

                    tempObj = Instantiate(cloudImagePrefab, prefabContainer);
                    tempObj.SetPrefab(cloudImages[i]);
                }

                if (i < childCount)
                {
                    for (int j = i; j < childCount; j++)
                    {
                        prefabContainer.GetChild(i).gameObject.SetActive(false);
                    }
                }

                isSetting = false;
            }
        }
    }
}

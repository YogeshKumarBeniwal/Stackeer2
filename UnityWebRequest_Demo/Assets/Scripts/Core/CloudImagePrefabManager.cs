using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YogeshBen.Stackeer;

namespace UnityWebRequestDemo
{
    public class CloudImagePrefabManager : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private SpriteContainerSO spriteContainer;
        [SerializeField]
        private TextMeshProUGUI nameText;
        [SerializeField]
        private TextMeshProUGUI InterestIDText;
        [SerializeField]
        private TextMeshProUGUI languageText;

        public void SetPrefab(CloudImageData cloudImage)
        {
            this.gameObject.SetActive(true);

            nameText.text = cloudImage.Name;
            InterestIDText.text = cloudImage.InterestID.ToString();
            languageText.text = cloudImage.Language;

            Stackeer.Get().Load(cloudImage.PictureUrl)
                .SetWebRequestType(WEB_REQUEST_TYPE.GET_TEXTURE)
                .SetLoadingPlaceholder(spriteContainer.loadingSprite)
                .SetErrorPlaceholder(spriteContainer.errorSprite)
                .SetEnableLog(true).Into(image)
                .StartStackeer();
        }
    }
}

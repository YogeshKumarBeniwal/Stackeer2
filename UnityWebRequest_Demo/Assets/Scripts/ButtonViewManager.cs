using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YogeshBen.Stackeer;

namespace UnityWebRequestDemo
{
    public class ButtonViewManager : MonoBehaviour
    {
        [SerializeField]
        private Button actionButton;
        [SerializeField]
        private TextMeshPro progressText;

        private void Start()
        {
            SetView();
        }

        public void SetView()
        {
            if(Stackeer.IsFileAlreadyExists(Global.cloudDataUri))
            {
                actionButton.onClick.AddListener(() =>
                {

                });
            }
            else
            {

            }
        }

        private void LoadData()
        {
            
        }

    }
}

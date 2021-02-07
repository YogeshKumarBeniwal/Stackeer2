using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System;

namespace UnityWebRequestDemo
{
    [RequireComponent(typeof(ScrollRect))]
    public class PullToRefreshBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float pullLimit = -100f;
        [SerializeField]
        private float delayBetweenRefresh = 3f;

        public UnityEvent OnRefresh;

        private ScrollRect scRect;
        private bool canRefresh = true;

        //TODO: Fix this class
        private void Awake()
        {
            scRect = this.gameObject.GetComponent<ScrollRect>();
            scRect.onValueChanged.AddListener(OnValueChange);
        }

        private void OnValueChange(Vector2 vector)
        {
            if(scRect.content.anchoredPosition.y < pullLimit)
            {
                //For vertical scroll
                if (canRefresh)
                {
                    canRefresh = false;
                    StartCoroutine(DelayedCall(delayBetweenRefresh, () => canRefresh = true));

                    if (Global.isDebuging)
                        Debug.Log("Refreshing content!");

                    OnRefresh?.Invoke();
                }
            }
        }

        private IEnumerator DelayedCall(float waitTime, Action action)
        {
            yield return new WaitForSeconds(waitTime);
            action?.Invoke();
        }

    }
}

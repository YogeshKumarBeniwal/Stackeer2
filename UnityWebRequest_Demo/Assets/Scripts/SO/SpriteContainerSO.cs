using UnityEngine;

namespace UnityWebRequestDemo
{
    [CreateAssetMenu(fileName = "SpriteContainer", menuName = "UnityWebRequestDemo/SO/SpriteContainer")]
    public class SpriteContainerSO : ScriptableObject
    {
        public Texture2D errorSprite,
            loadingSprite;
    }
}

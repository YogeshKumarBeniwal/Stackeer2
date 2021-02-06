using UnityEngine;

namespace UnityWebRequestDemo
{
    public class JsonConverter
    {
        /// <summary>
        /// Method to convert Json into provided object type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string jsonData)
        {
            return JsonUtility.FromJson<T>("{\"CloudImageData\":" + jsonData +"}");
        }

        /// <summary>
        /// Method to convert a object into json.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="dataToConvert">Data you want to convert into JSON</param>
        /// <returns></returns>
        public static string SerializeObject<T>(T dataToConvert)
        {
            return JsonUtility.ToJson(dataToConvert);
        }
    }
}

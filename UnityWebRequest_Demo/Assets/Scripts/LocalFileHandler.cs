using System;
using System.IO;
using UnityEngine;

namespace UnityWebRequestDemo
{
    public class LocalFileHandler
    {
        public static bool IsFileAlreadyExists(string fileName)
        {
            if (!Directory.Exists(Global.LocalDataPath))
                return false;

            return File.Exists(Global.LocalDataPath + fileName);
        }

        public static void SaveFile(string fileName, string dataToSave)
        {
            string path = Global.LocalDataPath + fileName;

            if (!Directory.Exists(Global.LocalDataPath))
                Directory.CreateDirectory(Global.LocalDataPath);

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            try
            {
                File.WriteAllText(path, dataToSave);
            }
            catch (Exception e)
            {
                if(Global.isDebuging)
                    Debug.LogWarning("Failed To Save Data Error: " + e.Message);
            }

        }
    }
}

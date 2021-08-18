using System;
using UnityEngine;

namespace Loader
{
    class Load : MonoBehaviour
    {
        public static GameObject newGameObject;
        public static void CreateGameObject()
        {
            newGameObject = new GameObject();
            UnityEngine.Object.DontDestroyOnLoad(newGameObject);
            newGameObject.AddComponent<AssetBundleLoader>();
            newGameObject.AddComponent<Menu>();
            newGameObject.AddComponent<Main>();
            //newGameObject.AddComponent<Aimbot>();
            newGameObject.AddComponent<Helper>();
            newGameObject.AddComponent<Chams>();
        }
    }
}

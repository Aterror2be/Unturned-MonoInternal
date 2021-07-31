using System;
using UnityEngine;

class AssetBundleLoader  : MonoBehaviour
{
    public static AssetBundle assetBundle;
    public static Shader chamsShader;
    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string folder = "/AssetBundles/cheat";

    public void Start()
    {
        assetBundle = AssetBundle.LoadFromFile(path + folder);
        chamsShader = assetBundle.LoadAsset<Shader>("WireFrameChams");
    }
}
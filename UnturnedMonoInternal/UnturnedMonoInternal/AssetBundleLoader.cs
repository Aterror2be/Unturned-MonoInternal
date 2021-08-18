using System;
using UnityEngine;

class AssetBundleLoader : MonoBehaviour
{
    public static AssetBundle assetBundle;
    public static Shader chamsShader;
    public static GUISkin skin = null;
    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string folder = "/AssetBundles/cheat";

    public void Start()
    {
        assetBundle = AssetBundle.LoadFromFile(path + folder);
        skin = assetBundle.LoadAsset<GUISkin>("MenuSkin");
        chamsShader = assetBundle.LoadAsset<Shader>("WireFrameChams");
    }
}
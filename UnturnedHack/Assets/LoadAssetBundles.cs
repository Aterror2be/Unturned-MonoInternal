using UnityEngine;
using System;

public class LoadAssetBundles : MonoBehaviour
{

    AssetBundle myLoadedAssetBundle;
    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string folder = "/AssetBundles/cheat";
    public string assetName;

	void Start ()
    {
        LoadAssetBundle(path + folder);
        LoadFromBundle(assetName);
	}

	void LoadAssetBundle(string bundleurl)
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile(bundleurl);
        if(myLoadedAssetBundle == null)
        {
            Debug.Log("Could Not Load AssetBundle");
        }
        else
        {
            Debug.Log("AssetBundle Loaded");
        }
    }

    void LoadFromBundle(string assetName)
    {
        var prefab = myLoadedAssetBundle.LoadAsset(assetName);
        Instantiate(prefab);
    }
}

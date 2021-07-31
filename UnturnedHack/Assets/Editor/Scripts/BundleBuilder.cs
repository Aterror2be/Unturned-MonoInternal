using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BundleBuilder : Editor
{
    private const string OutputPath = @"C:\Users\rjnob\OneDrive\Desktop\AssetBundles";

    [MenuItem("Assets/ Build AssetBundles")]

    static void BuildAssetBundle()
    {
        BuildPipeline.BuildAssetBundles(OutputPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }
}

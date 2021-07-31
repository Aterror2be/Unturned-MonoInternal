using SDG.Unturned;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Threading;

class Chams : MonoBehaviour
{
    public static SteamPlayer[] ConnectedPlayers;
    public static List<ESPObj> EObjects = new List<ESPObj>();
    public static Dictionary<string, Shader> Shaders = new Dictionary<string, Shader>();
    bool chams = true;

    public void Update()
    {
        if(Provider.isConnected && chams)
        {
            StartCoroutine(UpdateESPObjects());
            chams = false;
        }
    }

    public static void ApplyChams(ESPObj gameObject)
    {
        ApplyShader(AssetBundleLoader.chamsShader, gameObject.GObject);
    }

    public static void ApplyShader(Shader shader, GameObject pgo)
    {
        if (shader == null) return;

        Renderer[] rds = pgo.GetComponentsInChildren<Renderer>();

        for (int j = 0; j < rds.Length; j++)
        {
            Material[] materials = rds[j].materials;

            for (int k = 0; k < materials.Length; k++)
            {
                materials[k].shader = shader;
            }
        }
    }

    IEnumerator UpdateESPObjects()
    {
        if (1 == 1)
        {
            List<SteamPlayer> TempPlayers = new List<SteamPlayer>();
            List<ESPObj> TempObjects = new List<ESPObj>();

            if (1 == 1)
            {
                foreach (InteractableItem i in FindObjectsOfType<InteractableItem>())
                {
                    ESPObj obj = new ESPObj(0, i, i.gameObject);
                    TempObjects.Add(obj);
                    ApplyChams(obj);
                }
            }

            foreach (SteamPlayer i in Provider.clients)
            {
                if (1 == 1)
                {
                    ESPObj obj = new ESPObj(0, i, i.player.gameObject);
                    TempObjects.Add(obj);
                    ApplyChams(obj);
                    TempPlayers.Add(i);
                }
            }
            ConnectedPlayers = TempPlayers.ToArray();
            EObjects = TempObjects;

        }
        yield return new WaitForSeconds(2f);
        chams = true;
    }
}

public class ESPObj
{
    public enum ESPObject
    {
        Player,
        Vehicle,
        Item,
        Zombie,
        Storage,
        Bed,
        Flag
    }
    public ESPObject Target;
    public object Object;
    public GameObject GObject;

    public ESPObj(ESPObject t, object o, GameObject go)
    {
        Target = t;
        Object = o;
        GObject = go;
    }
}

using SDG.Unturned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using Random = System.Random;

class Helper : MonoBehaviour
{
    public static Vector3 GetLimbPosition(Transform target, string objName)
    {
        var componentsInChildren = target.transform.GetComponentsInChildren<Transform>();
        var result = Vector3.zero;

        if (componentsInChildren == null) return result;

        foreach (var transform in componentsInChildren)
        {
            if (transform.name.Trim() != objName) continue;

            result = transform.position + new Vector3(0f, 0.4f, 0f);
            break;
        }

        return result;
    }

    public static void AimAt(Vector3 pos)
    {
        Player.player.transform.LookAt(pos);
        Player.player.transform.eulerAngles = new Vector3(0f, Player.player.transform.rotation.eulerAngles.y, 0f);
        Camera.main.transform.LookAt(pos);
        float x = Camera.main.transform.localRotation.eulerAngles.x;
        if (x <= 90f && x <= 270f)
        {
            x = Camera.main.transform.localRotation.eulerAngles.x + 90f;
        }
        else if (x >= 270f && x <= 360f)
        {
            x = Camera.main.transform.localRotation.eulerAngles.x - 270f;
        }
        Player.player.look.GetType().GetField("_pitch", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.look, x);
        Player.player.look.GetType().GetField("_yaw", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.look, Player.player.transform.rotation.eulerAngles.y);
    }

    public static bool VisibleFromCamera(Vector3 pos)
    {
        Vector3 dir = (pos - MainCamera.instance.transform.position).normalized;
        Physics.Raycast(MainCamera.instance.transform.position, dir, out RaycastHit result, Mathf.Infinity, RayMasks.DAMAGE_CLIENT);
        return DamageTool.getPlayer(result.transform);
    }

    public static float? GetGunDistance()
    {
        ItemGunAsset currentGun = Player.player?.equipment?.asset as ItemGunAsset;
        return currentGun?.range ?? 15.5f;
    }

    public static InteractableItem GetNearestItem(int? pixelfov = null)
    {
        InteractableItem returnitem = null;

        Collider[] array = Physics.OverlapSphere(Player.player.transform.position, 19f, RayMasks.ITEM);
        for (int i = 0; i < array.Length; i++)
        {
            Collider collider = array[i];
            if (collider == null || collider.GetComponent<InteractableItem>() == null || collider.GetComponent<InteractableItem>().asset == null) continue;
            InteractableItem item = collider.GetComponent<InteractableItem>();

            Vector3 ScreenPoint1 = Camera.main.WorldToScreenPoint(item.transform.position);
            if (ScreenPoint1.z <= 0)
                continue;

            int ToLoopPlayerPixels = (int)Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(ScreenPoint1.x, ScreenPoint1.y));
            if (pixelfov != null && ToLoopPlayerPixels > pixelfov)
                continue;

            if (returnitem == null) { returnitem = item; continue; }
            Vector3 ScreenPoint2 = Camera.main.WorldToScreenPoint(returnitem.transform.position);
            int ToReturnPlayerPixels = (int)Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(ScreenPoint2.x, ScreenPoint2.y));

            if (pixelfov != null && ToReturnPlayerPixels > pixelfov)
                returnitem = null;

            if (ToLoopPlayerPixels < ToReturnPlayerPixels)
                returnitem = item;
        }
        return returnitem;
    }

    public static void OverrideMethod(Type defaultClass, Type overrideClass, string method, BindingFlags bindingflag1, BindingFlags bindingflag2, BindingFlags overrideflag1, BindingFlags overrideflag2)
    {
        string overriddenmethod = "OV_" + method;

        var MethodToOverride = defaultClass.GetMember(method, MemberTypes.Method, bindingflag1 | bindingflag2).Cast<MethodInfo>();

        OverrideHelper.RedirectCalls(MethodToOverride.ToArray()[0], overrideClass.GetMethod(overriddenmethod, overrideflag1 | overrideflag2));
    }

    public static System.Random Random = new System.Random();
    // the hwid sent to the server
    public static byte[] OV_getHwid()
    {
        List<byte> IdentifierBytes = new List<byte>();

        // instead of sending a random hwid each time you join a new server, which might not look legit, keep one hwid and let the user change it
        for (int i = 0; i < 20; i++)
            IdentifierBytes.Add((byte)Random.Next(0, 100));

        typeof(LocalHwid).GetField("cachedHwid", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, IdentifierBytes.ToArray());
        return IdentifierBytes.ToArray();
    }


    public static AudioClip BonkClip;
    bool hm;

    void Start()
    {
        BonkClip = AssetBundleLoader.assetBundle.LoadAsset<AudioClip>("neverlose");
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            hm = !hm;
        }
        if(hm)
        {
            BonkClip = AssetBundleLoader.assetBundle.LoadAsset<AudioClip>("neverlose");
        }
        else
        {
            BonkClip = AssetBundleLoader.assetBundle.LoadAsset<AudioClip>("arena_switch_press_02");
        }
    }

    public static void OV_hitmark(int index, Vector3 point, bool worldspace, EPlayerHit newHit)
    {
        if (index < 0 || index >= PlayerLifeUI.hitmarkers.Length)
        {
            return;
        }
        if (!Provider.modeConfigData.Gameplay.Hitmarkers)
        {
            return;
        }
        HitmarkerInfo hitmarkerInfo = PlayerLifeUI.hitmarkers[index];
        hitmarkerInfo.lastHit = Time.realtimeSinceStartup;
        hitmarkerInfo.hit = newHit;
        hitmarkerInfo.point = point;
        hitmarkerInfo.worldspace = (worldspace || OptionsSettings.hitmarker);

        if (newHit == EPlayerHit.CRITICAL)//if hit
        {
            if (1 == 1)
            {
                MainCamera.instance.GetComponent<AudioSource>().PlayOneShot(BonkClip, 2);
            }
            else
            {
                //Camera.main.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/General/Hit"), 0.5f);
            }
        }
    }
}

public class OverrideHelper
{
    [DllImport("mono.dll", CallingConvention = CallingConvention.FastCall, EntryPoint = "mono_domain_get")]
    private static extern IntPtr mono_domain_get();

    [DllImport("mono.dll", CallingConvention = CallingConvention.FastCall, EntryPoint = "mono_method_get_header")]
    private static extern IntPtr mono_method_get_header(IntPtr method);

    public static void RedirectCalls(MethodInfo from, MethodInfo to)
    {
        var fptr1 = from.MethodHandle.GetFunctionPointer();
        var fptr2 = to.MethodHandle.GetFunctionPointer();
        PatchJumpTo(fptr1, fptr2);
    }

    private static void RedirectCall(MethodInfo from, MethodInfo to)
    {

        IntPtr methodPtr1 = from.MethodHandle.Value;
        IntPtr methodPtr2 = to.MethodHandle.Value;

        from.MethodHandle.GetFunctionPointer();
        to.MethodHandle.GetFunctionPointer();

        IntPtr domain = mono_domain_get();
        unsafe
        {
            byte* jitCodeHash = ((byte*)domain.ToPointer() + 0xE8);
            long** jitCodeHashTable = *(long***)(jitCodeHash + 0x20);
            uint tableSize = *(uint*)(jitCodeHash + 0x18);

            void* jitInfoFrom = null, jitInfoTo = null;

            long mptr1 = methodPtr1.ToInt64();
            uint index1 = ((uint)mptr1) >> 3;
            for (long* value = jitCodeHashTable[index1 % tableSize];
                value != null;
                value = *(long**)(value + 1))
            {
                if (mptr1 == *value)
                {
                    jitInfoFrom = value;
                    break;
                }
            }

            long mptr2 = methodPtr2.ToInt64();
            uint index2 = ((uint)mptr2) >> 3;
            for (long* value = jitCodeHashTable[index2 % tableSize];
                value != null;
                value = *(long**)(value + 1))
            {
                if (mptr2 == *value)
                {
                    jitInfoTo = value;
                    break;
                }
            }
            if (jitInfoFrom == null || jitInfoTo == null)
            {
                Debug.Log("Could not find methods");
                return;
            }

            ulong* fromPtr, toPtr;
            fromPtr = (ulong*)jitInfoFrom;
            toPtr = (ulong*)jitInfoTo;
            *(fromPtr + 2) = *(toPtr + 2);
            *(fromPtr + 3) = *(toPtr + 3);
        }
    }

    private static void PatchJumpTo(IntPtr site, IntPtr target)
    {
        unsafe
        {
            byte* sitePtr = (byte*)site.ToPointer();
            *sitePtr = 0x49; // mov r11, target
            *(sitePtr + 1) = 0xBB;
            *((ulong*)(sitePtr + 2)) = (ulong)target.ToInt64();
            *(sitePtr + 10) = 0x41; // jmp r11
            *(sitePtr + 11) = 0xFF;
            *(sitePtr + 12) = 0xE3;
        }

    }

    private static void RedirectCallIL(MethodInfo from, MethodInfo to)
    {

        IntPtr methodPtr1 = from.MethodHandle.Value;
        IntPtr methodPtr2 = to.MethodHandle.Value;

        mono_method_get_header(methodPtr2);

        unsafe
        {
            byte* monoMethod1 = (byte*)methodPtr1.ToPointer();
            byte* monoMethod2 = (byte*)methodPtr2.ToPointer();

            *((IntPtr*)(monoMethod1 + 40)) = *((IntPtr*)(monoMethod2 + 40));
        }
    }

}

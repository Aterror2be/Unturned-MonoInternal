using SDG.Unturned;
using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class Main : MonoBehaviour
{
    public static float maxdistance = 1000f;

    public static void ToggleFreecam()
    {
        if (!Provider.isConnected)
            return;

        if (Provider.clients.Count < 1)
            return;

        if (Player.player == null)
            return;

        Player.player.look.isOrbiting = !Player.player.look.isOrbiting;
        if (!Player.player.look.isTracking)
        {
            if (Player.player.look.isOrbiting && !Player.player.look.isTracking && !Player.player.look.isLocking && !Player.player.look.isFocusing)
            {
                Player.player.look.isTracking = true;
                Player.player.look.orbitSpeed = 20f; //Prevent freecam from turning into a snail
            }
        }
        else
            Player.player.look.isTracking = false;
    }

    public static void UnlockAchievements()
    {
        for (uint p = 0; p < Steamworks.SteamUserStats.GetNumAchievements();)
            Steamworks.SteamUserStats.SetAchievement(Steamworks.SteamUserStats.GetAchievementName(p++));

        Steamworks.SteamUserStats.StoreStats();
    }

    public void Start()
    {
        Helper.OverrideMethod(typeof(LocalHwid), typeof(Helper), "getHwid", BindingFlags.Static, BindingFlags.Public, BindingFlags.Public, BindingFlags.Static); //LocalHwid
        Helper.OverrideMethod(typeof(PlayerUI), typeof(Helper), "hitmark", BindingFlags.Static, BindingFlags.Public, BindingFlags.Public, BindingFlags.Static); //PlayerUI
        UnlockAchievements();
    }
    public bool freecam;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            freecam = !freecam;
        }
        if(freecam)
        {
            if (Player.player)
            {
                Player.player.look.isOrbiting = true;
                Player.player.look.orbitSpeed = 40f;
                Player.player.look.isTracking = true;
            }
            else
            {
                Player.player.look.isOrbiting = false;
                Player.player.look.isTracking = false;
            }
            //ToggleFreecam();
        }

        ItemGunAsset gun = (ItemGunAsset)Player.player?.equipment?.asset;
        //no spread
        gun.spreadAim = 0f;
        gun.spreadHip = 0f;
        //no recoil
        gun.recoilMax_x = 0f;
        gun.recoilMax_y = 0f;
        gun.recoilMin_x = 0f;
        gun.recoilMin_y = 0f;
        //no sway
        Player.player.animator.viewSway = Vector3.zero;

    }

    public void OnGUI()
    {

        foreach (Player player in UnityEngine.Object.FindObjectsOfType(typeof(Player)) as Player[])
        {
            if(!player.life.isDead)
            {
                float distance = Vector3.Distance(MainCamera.instance.transform.position, player.transform.position);
                int distanceToint = (int)distance;
                GUIStyle style = new GUIStyle
                {
                    alignment = TextAnchor.MiddleCenter, 
                    fontSize = 11
                };
                style.normal.textColor = Color.white;
                Vector3 w2s = MainCamera.instance.WorldToScreenPoint(player.transform.position);
                if (w2s.z > 0)
                {
                    GUI.Label(new Rect(w2s.x, (float)Screen.height - w2s.y, 0f, 0f), player.name + " [" + distanceToint + "m]", style);//Name Esp
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractableItem i = Helper.GetNearestItem(50);
            if (i != null)
                i.use();
        }
    }
}

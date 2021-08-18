using UnityEngine;
using System.Collections;
using System;

public class test : MonoBehaviour
{

    #region MenuVars
    Rect menuRect = new Rect(20, 20, 750, 500);
    bool showmenu = false;
    int currentTab = 1;
    int currentVisualTab = 1;
    public GUISkin skin = null;
    #endregion
    #region AimlockVars
    bool keySelection;
    bool aimLock;
    bool predictDrop;
    bool fovLimit;
    float Fov = 100;
    bool drawFov;
    bool open;
    string hitbox = "Skull";
    public string aimlockText;
    public KeyCode aimkey = KeyCode.Insert;
    #endregion
    #region SilentAimVars
    bool SkeySelection;
    bool SsilentAim;
    bool SpredictDrop;
    bool SlimitFov;
    bool SdrawFov;
    float Sfov = 100.00f;
    float SextendHitbox = 1f;
    bool Sopen;
    public KeyCode Saimkey = KeyCode.Insert;
    public string Stext;
    string Shitbox = "Skull";
    #endregion
    #region WeaponVars
    bool noRecoil;
    bool noSpread;
    bool noSway;
    bool noShake;
    bool bulletTracers;
    bool customHitmarkers;
    bool hitmarkerOpen;
    string hitsound = "L4D2 Area Switch";
    #endregion
    #region VisualVars

    #region Player
    bool playerEsp;
    float playerMaxDistance = 500;
    bool playerBoxEsp;
    bool playerSnaplines;
    bool playerName;
    bool playerDistance;
    bool playerHands;
    bool playerChams;
    bool playerOpen;
    string playerList = "WireFrame Shader";
    #endregion
    #region Zombie
    bool zombieEsp;
    float zombieMaxDistance = 100;
    bool zombieBoxEsp;
    bool zombieSnaplines;
    bool zombieName;
    bool zombieDistance;
    bool zombieChams;
    bool zombieOpen;
    string zombieList = "WireFrame Shader";
    #endregion
    #region Vehical
    bool vehicalEsp;
    float vehicalMaxDistance = 500;
    bool vehicalBoxEsp;
    bool vehicalSnaplines;
    bool vehicalName;
    bool vehicalDistance;
    bool vehicalLockState;
    bool vehicalChams;
    bool vehicalOpen;
    string vehicalList = "WireFrame Shader";
    #endregion
    #region Loot
    bool lootEsp;
    float lootMaxDistance = 100;
    bool lootBoxEsp;
    bool lootSnaplines;
    bool lootName;
    bool lootDistance;
    bool lootChams;
    bool lootOpen;
    string lootList = "WireFrame Shader";
    #endregion
    #region Bed
    bool bedEsp;
    float bedMaxDistance = 500;
    bool bedBoxEsp;
    bool bedSnaplines;
    bool bedName;
    bool bedDistance;
    #endregion
    #region Storage
    bool storageEsp;
    float storageMaxDistance = 500;
    bool storageBoxEsp;
    bool storageSnaplines;
    bool storageName;
    bool storageDistance;
    bool storageChams;
    bool storageOpen;
    string storageList = "WireFrame Shader";
    #endregion
    #region ClaimFlag
    bool claimflagEsp;
    float claimflagMaxDistance = 500;
    bool claimflagBoxEsp;
    bool claimflagSnaplines;
    bool claimflagName;
    bool claimflagDistance;
    #endregion

    #endregion
    #region MiscVars
    bool miscVehicalNoClip;
    bool miscFreeCam;
    bool miscFlyHack;
    bool miscSpeedHack;
    float miscSpeedHackVal = 5;
    bool miscHighJump;
    float miscHighJumpVal = 5;
    bool miscCustomTime;
    float miscCustomTimeVal = 12;
    bool miscCustomSkyBox;
    bool miscOpen;
    string miscList = "Cosmic Cool Cloud";
    #endregion
    #region GuiStyle
    int R = 255, B, G;
    public static GUIStyle guiStyle = new GUIStyle();
    public static GUIStyle normalstyle = new GUIStyle();
    public static GUIStyle notificationStyle = new GUIStyle();
    public static GUIStyle mainButtons = new GUIStyle();
    public static GUIStyle configStyle = new GUIStyle();
    public static GUIStyle hitboxStyle = new GUIStyle();
    #endregion

    void Start()
    {
        #region SetGuiVars
        guiStyle.fontSize = 22;

        normalstyle.fontSize = 15;
        normalstyle.fontStyle = FontStyle.Bold;
        normalstyle.normal.textColor = new Color(24, 184, 24, 255);

        notificationStyle.fontSize = 15;
        notificationStyle.fontStyle = FontStyle.Bold;
        notificationStyle = skin.customStyles[0];

        mainButtons.fontStyle = FontStyle.Bold;
        mainButtons = skin.customStyles[1];

        configStyle = skin.customStyles[2];

        hitboxStyle.fontStyle = FontStyle.Bold;
        hitboxStyle.fontSize = 15;
        hitboxStyle.normal.textColor = new Color(255, 255, 255, 255);
        #endregion
    }
    private void Update()
    {
        #region openMenu
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            showmenu = !showmenu;
        }
        #endregion
        #region RGBFont
        guiStyle.normal.textColor = new Color32((byte)R, (byte)G, (byte)B, 255);
        if (R > 0 && B == 0)
        {
            R--;
            G++;
        }
        if (G > 0 && R == 0)
        {
            G--;
            B++;
        }
        if (B > 0 && G == 0)
        {
            B--;
            R++;
        }
        #endregion
    }
    void OnGUI()
    {
        GUI.skin = skin;
        #region Watermark
        GUI.Label(new Rect(10f, 0f, (float)Screen.width, 30f), "<b>Amplitude<size=15>.cc</size></b>", guiStyle);
        #endregion
        #region Notifications
        GUI.Label(new Rect(0, Screen.height / 2 - 200, 250, 70), "You've been spied!", notificationStyle);
        GUI.Label(new Rect(0, Screen.height / 2 - 100, 250, 70), "Weapon Range: 200m", notificationStyle);
        GUI.Label(new Rect(0, Screen.height / 2, 250, 70), "PlayerName: 999m", notificationStyle);
        #endregion
        #region ShowMenu
        if (showmenu)
        {
            menuRect = GUI.Window(0, menuRect, DrawWindow, "");
        }
        #endregion
    }

    void DrawWindow(int windowID)
    {
        #region WaterMarkMenu
        GUI.Label(new Rect(10f, 0f, (float)Screen.width, 30f), "<b>Amplitude<size=15>.cc</size></b>", guiStyle);
        GUI.Label(new Rect(0f, 6, (float)Screen.width, 30f), "__________________________________________________________", guiStyle);
        #endregion
        #region Tabs
        if (GUI.Button(new Rect(0, 35, 160, 50f), "Aimbot", mainButtons))
        {
            currentTab = 1;
        }
        if (GUI.Button(new Rect(0, 85, 160, 50f), "Weapons", mainButtons))
        {
            currentTab = 2;
        }
        if (GUI.Button(new Rect(0, 135, 160, 50f), "Visuals", mainButtons))
        {
            currentTab = 3;
        }
        if (GUI.Button(new Rect(0, 185, 160, 50f), "Players", mainButtons))
        {
            currentTab = 4;
        }
        if (GUI.Button(new Rect(0, 235, 160, 50f), "Misc", mainButtons))
        {
            currentTab = 5;
        }

        GUI.Label(new Rect(40, 450, 80, 25f), "Config", configStyle);
        GUI.Label(new Rect(0, 450, 200, 25f), "____________", guiStyle);

        if (GUI.Button(new Rect(85, 475, 80, 25f), "Save", configStyle))
        {
            
        }
        if (GUI.Button(new Rect(5, 475, 80, 25f), "Load", configStyle))
        {
            
        }
        #endregion
        #region TabCode
        switch (currentTab)
        {
            case 1:
                #region AimLock
                GUILayout.BeginArea(new Rect(170, 35, 280, 500), style: "box");
                GUI.Label(new Rect(8, 2, 10, 30f), "Aimbot", normalstyle);
                GUILayout.Space(25);
                aimLock = GUILayout.Toggle(aimLock, "AimLock");
                #region KeySelection
                if (GUILayout.Button(aimlockText, "KeySelection"))
                {
                    keySelection = true;
                }
                if (keySelection)
                {
                    aimlockText = "Press Any Key";
                    foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKey(vKey))
                        {
                            aimkey = vKey;
                            keySelection = false;

                        }
                    }
                }
                else
                {
                    aimlockText = "Aim Key: " + aimkey;
                }
                #endregion
                GUILayout.Label("Hitbox");
                if (GUILayout.Button(hitbox))
                {
                    open = true;
                }
                GUILayout.Space(5);
                if (open == false)
                {
                    predictDrop = GUILayout.Toggle(predictDrop, "Predict Drop");
                    fovLimit = GUILayout.Toggle(fovLimit, "Fov Limit");
                    GUILayout.Label("Fov: " + (int)Fov);
                    Fov = GUILayout.HorizontalSlider(Fov, 0, 1200);
                    drawFov = GUILayout.Toggle(drawFov, "Draw Fov");
                }
                if (open)
                {
                    GUILayout.BeginArea(new Rect(0, 111, 125, 343), style: "Dropdown");
                    GUI.Label(new Rect(8, 2, 10, 30f), "", normalstyle);
                    if (GUILayout.Button(""))
                    {

                    }
                    if (GUILayout.Button("Skull"))
                    {
                        hitbox = "Skull";
                        open = false;
                    }
                    if (GUILayout.Button("Spine"))
                    {
                        hitbox = "Spine";
                        open = false;
                    }
                    if (GUILayout.Button("Left_Arm"))
                    {
                        hitbox = "Left_Arm";
                        open = false;
                    }
                    if (GUILayout.Button("Left_Hand"))
                    {
                        hitbox = "Left_Hand";
                        open = false;
                    }
                    if (GUILayout.Button("Right_Arm"))
                    {
                        hitbox = "Right_Arm";
                        open = false;
                    }
                    if (GUILayout.Button("Right_Hand"))
                    {
                        hitbox = "Right_Hand";
                        open = false;
                    }
                    if (GUILayout.Button("Left_Leg"))
                    {
                        hitbox = "Left_Leg";
                        open = false;
                    }
                    if (GUILayout.Button("Left_Foot"))
                    {
                        hitbox = "Left_Foot";
                        open = false;
                    }
                    if (GUILayout.Button("Right_Hand"))
                    {
                        hitbox = "Right_Hand";
                        open = false;
                    }
                    if (GUILayout.Button("Right_Foot"))
                    {
                        hitbox = "Right_Foot";
                        open = false;
                    }
                    if (GUILayout.Button("Random"))
                    {
                        hitbox = "Random";
                        open = false;
                    }
                    GUILayout.EndArea();
                }
                GUILayout.EndArea();
                #endregion
                #region SilentAimbot
                GUILayout.BeginArea(new Rect(460, 35, 280, 500), style: "box");
                GUI.Label(new Rect(8, 2, 10, 30f), "Silent Aimbot", normalstyle);
                GUILayout.Space(25);
                SsilentAim = GUILayout.Toggle(SsilentAim, "Silent Aimbot");
                #region KeySelection
                if (GUILayout.Button(Stext, "KeySelection"))
                {
                    SkeySelection = true;
                }
                if (SkeySelection)
                {
                    Stext = "Press Any Key";
                    foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKey(vKey))
                        {
                            Saimkey = vKey;
                            SkeySelection = false;

                        }
                    }
                }
                else
                {
                    Stext = "Aim Key: " + Saimkey;
                }
                #endregion
                GUILayout.Label("Hitbox");
                if (GUILayout.Button(Shitbox))
                {
                    Sopen = true;
                }
                GUILayout.Space(5);
                if(Sopen == false)
                {
                    SpredictDrop =  GUILayout.Toggle(SpredictDrop, "Predict Drop");
                    SlimitFov =  GUILayout.Toggle(SlimitFov, "Limit Fov");
                    GUILayout.Label("Fov: " + (int)Sfov);
                    Sfov = (float)GUILayout.HorizontalSlider(Sfov, 0, 1200);
                    SdrawFov =  GUILayout.Toggle(SdrawFov, "Draw Fov");
                    GUILayout.Label("Extended Hitbox: " + (int)SextendHitbox);
                    SextendHitbox = GUILayout.HorizontalSlider(SextendHitbox, 0, 15);
                }
                if (Sopen)
                {
                    GUILayout.BeginArea(new Rect(0, 111, 125, 343), style: "Dropdown");
                    GUI.Label(new Rect(8, 2, 10, 30f), "", normalstyle);
                    if (GUILayout.Button(""))
                    {

                    }
                    if (GUILayout.Button("Skull"))
                    {
                        Shitbox = "Skull";
                        Sopen = false;
                    }
                    if (GUILayout.Button("Spine"))
                    {
                        Shitbox = "Spine";
                        Sopen = false;
                    }
                    if (GUILayout.Button("Left_Arm"))
                    {
                        Shitbox = "Left_Arm";
                        Sopen = false;
                    }
                    if (GUILayout.Button("Left_Hand"))
                    {
                        Shitbox = "Left_Hand";
                        Sopen = false;
                    }
                    if (GUILayout.Button("Right_Arm"))
                    {
                        Shitbox = "Right_Arm";
                        Sopen = false;
                    }
                    if (GUILayout.Button("Right_Hand"))
                    {
                        Shitbox = "Right_Hand";
                        Sopen = false;
                    }
                    if (GUILayout.Button("Left_Leg"))
                    {
                        Shitbox = "Left_Leg";
                        Sopen = false;
                    }
                    if (GUILayout.Button("Left_Foot"))
                    {
                        Shitbox = "Left_Foot";
                        Sopen = false;
                    }
                    if (GUILayout.Button("Right_Hand"))
                    {
                        Shitbox = "Right_Hand";
                        Sopen = false;
                    }
                    if (GUILayout.Button("Right_Foot"))
                    {
                        Shitbox = "Right_Foot";
                        Sopen = false;
                    }
                    if (GUILayout.Button("Random"))
                    {
                        Shitbox = "Random";
                        Sopen = false;
                    }
                    GUILayout.EndArea();
                }
                GUILayout.EndArea();
                #endregion
                break;
            case 2:
                #region Weapon
                GUILayout.BeginArea(new Rect(170, 35, 570, 500), style: "box");
                GUI.Label(new Rect(8, 2, 10, 30f), "Weapon", normalstyle);
                GUILayout.Space(25);
                noRecoil = GUILayout.Toggle(noRecoil, "No Recoil");
                noSpread =  GUILayout.Toggle(noSpread, "No Spread");
                noSway = GUILayout.Toggle(noSway, "No Sway");
                noShake = GUILayout.Toggle(noShake, "No Shake");
                bulletTracers = GUILayout.Toggle(bulletTracers, "Bullet Tracers");
                customHitmarkers = GUILayout.Toggle(customHitmarkers, "Custom Hitmarker");
                GUILayout.Label("Hitmarker Sounds");
                if (GUILayout.Button(hitsound, "KeySelection"))
                {
                    hitmarkerOpen = true;
                }
                if (hitmarkerOpen)
                {
                    GUILayout.BeginArea(new Rect(0, 190, 195, 109), style: "DropdownL");
                    GUI.Label(new Rect(8, 2, 10, 30f), "", normalstyle);
                    if (GUILayout.Button("", "KeySelectionL"))
                    {

                    }
                    if (GUILayout.Button("L4D2 Area Switch", "KeySelectionL"))
                    {
                        hitsound = "L4D2 Area Switch";
                        hitmarkerOpen = false;
                    }
                    if (GUILayout.Button("Neverlose Hitmarker", "KeySelectionL"))
                    {
                        hitsound = "Neverlose Hitmarker";
                        hitmarkerOpen = false;
                    }
                    if (GUILayout.Button("Rust HeadShot", "KeySelectionL"))
                    {
                        hitsound = "Rust HeadShot";
                        hitmarkerOpen = false;
                    }
                    GUILayout.EndArea();
                }
                GUILayout.EndArea();
                #endregion
                break;
            case 3:
                #region Visuals
                GUILayout.BeginArea(new Rect(170, 35, 570, 500), style: "box");
                GUI.Label(new Rect(8, 2, 10, 30f), "Visuals", normalstyle);
                GUILayout.Space(25);
                #region Tabs
                if (GUI.Button(new Rect(0, 23, 81, 30f), "Players", "VisualButtons"))
                {
                    currentVisualTab = 1;
                }
                if (GUI.Button(new Rect(81, 23, 81, 30f), "Zombies", "VisualButtons"))
                {
                    currentVisualTab = 2;
                }
                if (GUI.Button(new Rect(162, 23, 81, 30f), "Vehical", "VisualButtons"))
                {
                    currentVisualTab = 3;
                }
                if (GUI.Button(new Rect(243, 23, 81, 30f), "Loot", "VisualButtons"))
                {
                    currentVisualTab = 4;
                }
                if (GUI.Button(new Rect(324, 23, 81, 30f), "Bed", "VisualButtons"))
                {
                    currentVisualTab = 5;
                }
                if (GUI.Button(new Rect(406, 23, 81, 30f), "Storage", "VisualButtons"))
                {
                    currentVisualTab = 6;
                }
                if (GUI.Button(new Rect(488, 23, 81f, 30f), "Claim Flag", "VisualButtons"))
                {
                    currentVisualTab = 7;
                }
                #endregion
                switch (currentVisualTab)
                {
                    case 1:
                        #region Player
                        GUILayout.Space(25);
                        playerEsp = GUILayout.Toggle(playerEsp,"Players Esp");
                        GUILayout.Label("Max Distance: "+ (int)playerMaxDistance);
                        playerMaxDistance = GUILayout.HorizontalSlider(playerMaxDistance, 0, 1500, GUILayout.MaxWidth(240));
                        playerBoxEsp = GUILayout.Toggle(playerBoxEsp, "Box Esp");
                        playerSnaplines = GUILayout.Toggle(playerSnaplines, "Snaplines");
                        playerName = GUILayout.Toggle(playerName, "Name");
                        playerDistance = GUILayout.Toggle(playerDistance, "Distance");
                        playerHands = GUILayout.Toggle(playerHands, "Hands");
                        playerChams = GUILayout.Toggle(playerChams, "Enable Chams");
                        if (GUILayout.Button(playerList, "KeySelection"))
                        {
                            playerOpen = true;
                        }
                        if (playerOpen)
                        {
                            GUILayout.BeginArea(new Rect(0, 253, 195, 109), style: "DropdownL");
                            GUI.Label(new Rect(8, 2, 10, 30f), "", normalstyle);
                            if (GUILayout.Button("", "KeySelectionL"))
                            {

                            }
                            if (GUILayout.Button("WireFrame Shader", "KeySelectionL"))
                            {
                                playerList = "WireFrame Shader";
                                playerOpen = false;
                            }
                            if (GUILayout.Button("Flat Shader", "KeySelectionL"))
                            {
                                playerList = "Flat Shader";
                                playerOpen = false;
                            }
                            if (GUILayout.Button("Normal Shader", "KeySelectionL"))
                            {
                                playerList = "Normal Shader";
                                playerOpen = false;
                            }
                            GUILayout.EndArea();
                        }
                        #endregion
                        break;
                    case 2:
                        #region Zombie
                        GUILayout.Space(25);
                        zombieEsp = GUILayout.Toggle(zombieEsp, "Zombie Esp");
                        GUILayout.Label("Max Distance: " + (int)zombieMaxDistance);
                        zombieMaxDistance = GUILayout.HorizontalSlider(zombieMaxDistance, 0, 400, GUILayout.MaxWidth(240));
                        zombieBoxEsp = GUILayout.Toggle(zombieBoxEsp, "Box Esp");
                        zombieSnaplines = GUILayout.Toggle(zombieSnaplines, "Snaplines");
                        zombieName = GUILayout.Toggle(zombieName, "Name");
                        zombieDistance = GUILayout.Toggle(zombieDistance, "Distance");
                        zombieChams = GUILayout.Toggle(zombieChams, "Enable Chams");
                        if (GUILayout.Button(zombieList, "KeySelection"))
                        {
                            zombieOpen = true;
                        }
                        if (zombieOpen)
                        {
                            GUILayout.BeginArea(new Rect(0, 231, 195, 109), style: "DropdownL");
                            GUI.Label(new Rect(8, 2, 10, 30f), "", normalstyle);
                            if (GUILayout.Button("", "KeySelectionL"))
                            {

                            }
                            if (GUILayout.Button("WireFrame Shader", "KeySelectionL"))
                            {
                                zombieList = "WireFrame Shader";
                                zombieOpen = false;
                            }
                            if (GUILayout.Button("Flat Shader", "KeySelectionL"))
                            {
                                zombieList = "Flat Shader";
                                zombieOpen = false;
                            }
                            if (GUILayout.Button("Normal Shader", "KeySelectionL"))
                            {
                                zombieList = "Normal Shader";
                                zombieOpen = false;
                            }
                            GUILayout.EndArea();
                        }
                        #endregion
                        break;
                    case 3:
                        #region Vehical
                        GUILayout.Space(25);
                        vehicalEsp = GUILayout.Toggle(vehicalEsp, "Vehical Esp");
                        GUILayout.Label("Max Distance: " + (int)vehicalMaxDistance);
                        vehicalMaxDistance = GUILayout.HorizontalSlider(vehicalMaxDistance, 0, 1500, GUILayout.MaxWidth(240));
                        vehicalBoxEsp = GUILayout.Toggle(vehicalBoxEsp, "Box Esp");
                        vehicalSnaplines = GUILayout.Toggle(vehicalSnaplines, "Snaplines");
                        vehicalName = GUILayout.Toggle(vehicalName, "Name");
                        vehicalDistance = GUILayout.Toggle(vehicalDistance, "Distance");
                        vehicalLockState = GUILayout.Toggle(vehicalLockState, "Lock State");
                        vehicalChams = GUILayout.Toggle(vehicalChams, "Enable Chams");
                        if (GUILayout.Button(vehicalList, "KeySelection"))
                        {
                            vehicalOpen = true;
                        }
                        if (vehicalOpen)
                        {
                            GUILayout.BeginArea(new Rect(0, 253, 195, 109), style: "DropdownL");
                            GUI.Label(new Rect(8, 2, 10, 30f), "", normalstyle);
                            if (GUILayout.Button("", "KeySelectionL"))
                            {

                            }
                            if (GUILayout.Button("WireFrame Shader", "KeySelectionL"))
                            {
                                vehicalList = "WireFrame Shader";
                                vehicalOpen = false;
                            }
                            if (GUILayout.Button("Flat Shader", "KeySelectionL"))
                            {
                                vehicalList = "Flat Shader";
                                vehicalOpen = false;
                            }
                            if (GUILayout.Button("Normal Shader", "KeySelectionL"))
                            {
                                vehicalList = "Normal Shader";
                                vehicalOpen = false;
                            }
                            GUILayout.EndArea();
                        }
                        #endregion
                        break;
                    case 4:
                        #region Loot
                        GUILayout.Space(25);
                        lootEsp = GUILayout.Toggle(lootEsp, "Loot Esp");
                        GUILayout.Label("Max Distance: " + (int)lootMaxDistance);
                        lootMaxDistance = GUILayout.HorizontalSlider(lootMaxDistance, 0, 200, GUILayout.MaxWidth(240));
                        lootBoxEsp = GUILayout.Toggle(lootBoxEsp, "Box Esp");
                        lootSnaplines = GUILayout.Toggle(lootSnaplines, "Snaplines");
                        lootName = GUILayout.Toggle(lootName, "Name");
                        lootDistance = GUILayout.Toggle(lootDistance, "Distance");
                        lootChams = GUILayout.Toggle(lootChams, "Enable Chams");
                        if (GUILayout.Button(lootList, "KeySelection"))
                        {
                            lootOpen = true;
                        }
                        if (lootOpen)
                        {
                            GUILayout.BeginArea(new Rect(-1, 231, 196, 109), style: "DropdownL");
                            GUI.Label(new Rect(8, 2, 10, 30f), "", normalstyle);
                            if (GUILayout.Button("", "KeySelectionL"))
                            {

                            }
                            if (GUILayout.Button("WireFrame Shader", "KeySelectionL"))
                            {
                                lootList = "WireFrame Shader";
                                lootOpen = false;
                            }
                            if (GUILayout.Button("Flat Shader", "KeySelectionL"))
                            {
                                lootList = "Flat Shader";
                                lootOpen = false;
                            }
                            if (GUILayout.Button("Normal Shader", "KeySelectionL"))
                            {
                                lootList = "Normal Shader";
                                lootOpen = false;
                            }
                            GUILayout.EndArea();
                        }
                        #endregion
                        break;
                    case 5:
                        #region Bed
                        GUILayout.Space(25);
                        bedEsp = GUILayout.Toggle(bedEsp, "Bed Esp");
                        GUILayout.Label("Max Distance: " + (int)bedMaxDistance);
                        bedMaxDistance = GUILayout.HorizontalSlider(bedMaxDistance, 0, 1000, GUILayout.MaxWidth(240));
                        bedBoxEsp = GUILayout.Toggle(bedBoxEsp, "Box Esp");
                        bedSnaplines = GUILayout.Toggle(bedSnaplines, "Snaplines");
                        bedName = GUILayout.Toggle(bedName, "Name");
                        bedDistance = GUILayout.Toggle(bedDistance, "Distance");
                        #endregion
                        break;
                    case 6:
                        #region Storage
                        GUILayout.Space(25);
                        storageEsp = GUILayout.Toggle(storageEsp, "Storage Esp");
                        GUILayout.Label("Max Distance: " + (int)storageMaxDistance);
                        storageMaxDistance = GUILayout.HorizontalSlider(storageMaxDistance, 0, 1000, GUILayout.MaxWidth(240));
                        storageBoxEsp = GUILayout.Toggle(storageBoxEsp, "Box Esp");
                        storageSnaplines = GUILayout.Toggle(storageSnaplines, "Snaplines");
                        storageName = GUILayout.Toggle(storageName, "Name");
                        storageDistance = GUILayout.Toggle(storageDistance, "Distance");
                        storageChams = GUILayout.Toggle(storageChams, "Enable Chams");
                        if (GUILayout.Button(storageList, "KeySelection"))
                        {
                            storageOpen = true;
                        }
                        if (storageOpen)
                        {
                            GUILayout.BeginArea(new Rect(0, 231, 195, 109), style: "DropdownL");
                            GUI.Label(new Rect(8, 2, 10, 30f), "", normalstyle);
                            if (GUILayout.Button("", "KeySelectionL"))
                            {

                            }
                            if (GUILayout.Button("WireFrame Shader", "KeySelectionL"))
                            {
                                storageList = "WireFrame Shader";
                                storageOpen = false;
                            }
                            if (GUILayout.Button("Flat Shader", "KeySelectionL"))
                            {
                                storageList = "Flat Shader";
                                storageOpen = false;
                            }
                            if (GUILayout.Button("Normal Shader", "KeySelectionL"))
                            {
                                storageList = "Normal Shader";
                                storageOpen = false;
                            }
                            GUILayout.EndArea();
                        }
                        #endregion
                        break;
                    case 7:
                        #region ClaimFlag
                        GUILayout.Space(25);
                        claimflagEsp = GUILayout.Toggle(claimflagEsp, "Claim Flag Esp");
                        GUILayout.Label("Max Distance: " + (int)claimflagMaxDistance);
                        claimflagMaxDistance = GUILayout.HorizontalSlider(claimflagMaxDistance, 0, 1000, GUILayout.MaxWidth(240));
                        claimflagBoxEsp = GUILayout.Toggle(claimflagBoxEsp, "Box Esp");
                        claimflagSnaplines = GUILayout.Toggle(claimflagSnaplines, "Snaplines");
                        claimflagName = GUILayout.Toggle(claimflagName, "Name");
                        claimflagDistance = GUILayout.Toggle(claimflagDistance, "Distance");
                        #endregion
                        break;

                }
                GUILayout.EndArea();
                #endregion
                break;
            case 4:
                #region Player
                //Do Later!!!!!!!!!!!
                //code here
                GUILayout.BeginArea(new Rect(170, 35, 570, 500), style: "box");
                GUI.Label(new Rect(8, 2, 10, 30f), "Players", normalstyle);
                GUILayout.Space(25);
                GUILayout.EndArea();
                //Do Later!!!!!!!!!!!
                #endregion
                break;
            case 5:
                #region Misc
                GUILayout.BeginArea(new Rect(170, 35, 570, 500), style: "box");
                GUI.Label(new Rect(8, 2, 10, 30f), "Misc", normalstyle);
                GUILayout.Space(25);
                miscVehicalNoClip = GUILayout.Toggle(miscVehicalNoClip, "Vehical Noclip");
                miscFreeCam = GUILayout.Toggle(miscFreeCam, "FreeCam");
                miscFlyHack = GUILayout.Toggle(miscFlyHack, "FlyHack");
                miscSpeedHack = GUILayout.Toggle(miscSpeedHack, "SpeedHack: " + (int)miscSpeedHackVal);
                miscSpeedHackVal = GUILayout.HorizontalSlider(miscSpeedHackVal, 0, 24, GUILayout.MaxWidth(240));
                miscHighJump = GUILayout.Toggle(miscHighJump, "High Jump: " + (int)miscHighJumpVal);
                miscHighJumpVal = GUILayout.HorizontalSlider(miscHighJumpVal, 0, 24, GUILayout.MaxWidth(240));
                miscCustomTime = GUILayout.Toggle(miscCustomTime, "Custom Time: " + (int)miscCustomTimeVal);
                miscCustomTimeVal = GUILayout.HorizontalSlider(miscCustomTimeVal, 0, 24, GUILayout.MaxWidth(240));
                miscCustomSkyBox = GUILayout.Toggle(miscCustomSkyBox, "Custom Skybox");
                if (GUILayout.Button(miscList, "KeySelection"))
                {
                    miscOpen = true;
                }
                if (miscOpen)
                {
                    GUILayout.BeginArea(new Rect(0, 231, 195, 109), style: "DropdownL");
                    GUI.Label(new Rect(8, 2, 10, 30f), "", normalstyle);
                    if (GUILayout.Button("", "KeySelectionL"))
                    {

                    }
                    if (GUILayout.Button("Cosmic Cool Cloud", "KeySelectionL"))
                    {
                        miscList = "Cosmic Cool Cloud";
                        miscOpen = false;
                    }
                    if (GUILayout.Button("Dark Storm", "KeySelectionL"))
                    {
                        miscList = "Dark Storm";
                        miscOpen = false;
                    }
                    if (GUILayout.Button("UnearthlyRed", "KeySelectionL"))
                    {
                        miscList = "UnearthlyRed";
                        miscOpen = false;
                    }
                    GUILayout.EndArea();
                }
                GUILayout.EndArea();
                #endregion
                break;
        }
        #endregion
        GUI.DragWindow();
    }
}

using UnityEngine;
using System.Collections;
using System;
using System.Timers;

public class test : MonoBehaviour
{
    Rect menuRect = new Rect(20, 20, 750, 500);
    bool yes;
    public Texture fish;
    bool showmenu = false;
    public GUISkin skin = null;
    public int x = 10;
    public int y = 10;
    int R, B, G;
    int currentTab = 1;
    public static GUIStyle guiStyle = new GUIStyle();
    public static GUIStyle normalstyle = new GUIStyle();
    public static GUIStyle notificationStyle = new GUIStyle();
    public static GUIStyle mainButtons = new GUIStyle();
    public static GUIStyle configStyle = new GUIStyle();
    public int x1, y1, x2, y2, x3, y3;

    void Start()
    {
        R = 255;
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
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            showmenu = !showmenu;
        }

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
        if(yes)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    Debug.Log(vKey);
                    yes = false;

                }
            }
        }
    }
    public int i = -300;
    public bool canIncrease = true;
    public bool canDecrease;
    public bool spied = false;
    Timer t = new Timer();
    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(10f, 0f, (float)Screen.width, 30f), "<b>Amplitude<size=15>.cc</size></b>", guiStyle);
        if (GUI.Button(new Rect(300f, 300f, 100, 100f), "test"))
        {

        }

        GUI.Label(new Rect(0, Screen.height / 2 - 200, 250, 70), "You've been spied!", notificationStyle);
        GUI.Label(new Rect(0, Screen.height / 2 - 100, 250, 70), "Weapon Range: 200m", notificationStyle);
        GUI.Label(new Rect(0, Screen.height / 2, 250, 70), "PlayerName: 999m", notificationStyle);

        if (showmenu)
        {
            menuRect = GUI.Window(0, menuRect, DoMyWindow, "");
        }
    }
    void DoMyWindow(int windowID)
    {
        GUI.Label(new Rect(10f, 0f, (float)Screen.width, 30f), "<b>Amplitude<size=15>.cc</size></b>", guiStyle);
        GUI.Label(new Rect(0f, 6, (float)Screen.width, 30f), "__________________________________________________________", guiStyle);

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
        if (GUI.Button(new Rect(0, 285, 160, 50f), "Settings", mainButtons))
        {
            currentTab = 6;
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
                //code here
                GUILayout.BeginArea(new Rect(170, 35, 260, 250), style: "box");
                GUI.Label(new Rect(8, 2, 10, 30f), "Aimbot", normalstyle);
                GUILayout.Space(25);

                yes = GUILayout.Toggle(yes, "AimLock");
                
                if (GUILayout.Button("Aim Key: "))
                {

                }
                GUILayout.Toggle(yes, "Fov Limit");
                GUILayout.Label("Fov: " + i);
                GUILayout.HorizontalSlider(0, 0, 1200);
                GUILayout.Toggle(yes, "Draw Fov");
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(170, 250, 260, 285), style: "box");
                GUI.Label(new Rect(8, 2, 10, 30f), "SilentAimbot", normalstyle);

                GUILayout.Space(25);
                GUILayout.Toggle(yes, "SilentAimbot");
                if (GUILayout.Button("Aim Key: "))
                {

                }
                GUILayout.Toggle(yes, "Fov Limit");
                GUILayout.Label("Fov: " + i);
                GUILayout.HorizontalSlider(0, 0, 1200);
                GUILayout.Toggle(yes, "Draw Fov");
                GUILayout.Label("Extended Hitbox: " + i + " m");
                GUILayout.HorizontalSlider(0, 0, 15);

                GUILayout.EndArea();


                GUILayout.BeginArea(new Rect(440, 35, 300, 500), style: "box");
                GUI.Label(new Rect(8, 2, 10, 30f), "Hitbox Selection", normalstyle);
                GUILayout.Space(25);
                GUI.DrawTexture(new Rect(10, 30, 290, 250), fish, ScaleMode.StretchToFill, true, 10.0F);
                GUILayout.EndArea();
                break;
            case 2:
                //code here
                GUILayout.BeginArea(new Rect(170, 35, 550, 500), style: "box");
                GUI.Label(new Rect(8, 2, 10, 30f), "Weapon", normalstyle);
                GUILayout.Space(25);
                GUILayout.EndArea();
                break;
            case 3:
                //code here
                break;
            case 4:
                //code here
                break;
            case 5:
                //code here
                break;
            case 6:
                //code here
                break;
        }
        #endregion
        GUI.DragWindow();
    }
}

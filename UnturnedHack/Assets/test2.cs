using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class test2 : MonoBehaviour
{
    int Tab;
    public Vector2 scrollPosition = Vector2.zero;
    float yes2 = 322;
    bool yes;
    public static string yeet = "text field";
    public static Color GUIColor;
    public GUISkin skin;
    public static List<GUIContent> buttons = new List<GUIContent>();
    // Use this for initialization
    void Start()
    {
        GUIColor = GUI.color;

    }

    public int i = -40;
    bool sex = false;
    void OnGUI()
    {
        if (GUI.Button(new Rect(200, 200, 20, 30), "openmenu"))
        {
            if (sex == false)
            {
                sex = true;
            }
            else
            {
                sex = false;
                i = -40;
            }
        }

        if (sex == false)
            return;
        GUIStyle guiStyle = new GUIStyle("label");
        guiStyle.margin = new RectOffset(10, 10, 0, 5);
        guiStyle.fontSize = 22;
        if (i < 0)
        {
            i++;
        }
        GUI.skin = skin;
        GUILayout.BeginArea(new Rect(0, i, Screen.width, 40), style: "NavBox");
        GUILayout.BeginHorizontal();
        GUILayout.Label("<b>EgguWare</b> <size=15>v1.0.3</size>", guiStyle);
        GUI.color = GUIColor;
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    
}
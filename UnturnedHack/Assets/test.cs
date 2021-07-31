using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
    public Rect menuRect = new Rect(20, 20, 700, 450);
    bool yes;
    public Texture fish;
    bool showmenu = false;
    public GUISkin skin = null;
    public int x = 341;
    public int y = 277;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            showmenu = !showmenu;
        }

    }
    void OnGUI()
    {
        GUI.skin = skin;
        if (showmenu)
        {
            menuRect = GUI.Window(0, menuRect, DoMyWindow, "My Window");
        }
    }

    void DoMyWindow(int windowID)
    {
        GUILayout.Space(0);
        GUILayout.BeginArea(new Rect(10, 35, 260, 400), style: "box", text: "Silent Aimbot");
        //yes = GUI.Toggle(new Rect(10, 35, 20, 40), yes, "asdasd");
        yes = GUILayout.Toggle(yes, "asdasd");
        //yes = GUILayout.Toggle(yes, "asdasd");
        //yes = GUILayout.Toggle(yes, "asdasd");
        if (GUILayout.Button("Hello World"))
        {
            print("Got a click in window " + windowID);
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(280, 35, 300, 400), style: "box", text: "HitBox Selection");
        GUI.DrawTexture(new Rect(10, 30, x, y), fish, ScaleMode.StretchToFill, true, 10.0F);
        GUILayout.EndArea();
        GUI.DragWindow();
    }
}

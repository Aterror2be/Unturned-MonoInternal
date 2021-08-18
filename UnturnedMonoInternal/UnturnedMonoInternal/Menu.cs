using System;
using UnityEngine;

class Menu : MonoBehaviour
{
    public void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 100, 100), "Testing I dont know why this is not working");
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material Stars;
    public Material Cloulds;
    public Material Mars;

	// Use this for initialization
	void Start () {
        RenderSettings.skybox = Stars;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

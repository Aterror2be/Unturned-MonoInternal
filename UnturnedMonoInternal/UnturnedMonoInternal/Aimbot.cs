using UnityEngine;
using SDG.Unturned;
using System;

public class Aimbot : MonoBehaviour
{
    float t;
    String b = "Visibility";
    String a = "Null";
    Vector3 AimTarget = Vector3.zero;
    Player player1;
    Vector3 line = Vector3.zero;
    public int Radius = 200;

    public void OnGUI()
    {
        if (true)
        {
            //Drawing.DrawCircle(Color.white, new Vector2(Screen.width / 2, Screen.height / 2), Radius);
            if (!player1.life.isDead)
            {
                Drawing.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(line.x, (float)Screen.height - line.y), Color.red, 1f);
            }
        }
        GUI.Label(new Rect(220f, 80f, 200f, 20f), "Nearest Player: " + t.ToString());
        GUI.Label(new Rect(220f, 100f, 200f, 20f), "Visibility: " + b.ToString());
        GUI.Label(new Rect(220f, 120f, 200f, 20f), "Weapon Range: " + a.ToString());
    }

    public void Update()
    {
        float minDist = 99999;
        foreach (Player player in UnityEngine.Object.FindObjectsOfType(typeof(Player)) as Player[])
        {
            Vector3 w2s = Camera.main.WorldToScreenPoint(Helper.GetLimbPosition(player.transform, "Skull"));
            float distance = Vector3.Distance(MainCamera.instance.transform.position, player.transform.position);

            if (w2s.z > 0f)
            {
                float dist = System.Math.Abs(Vector2.Distance(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2((Screen.width / 2), (Screen.height / 2))));

                if (dist < minDist)
                {
                    minDist = dist;
                    t = minDist;
                    b = Helper.VisibleFromCamera(player.transform.position).ToString();
                    a = Helper.GetGunDistance().ToString();
                    line = w2s;
                    player1 = player;
                    if (distance < Main.maxdistance)
                    {
                        AimTarget = Helper.GetLimbPosition(player.transform, "Skull");
                    }
                }
/*                if (dist < Radius)
                {
                }*/
            }
        }
        if (AimTarget != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Player.player.look.aim.position = AimTarget;
                Ray ray = new Ray(Player.player.look.aim.position, Player.player.look.aim.forward);
                RaycastInfo raycastInfo = DamageTool.raycast(ray, 2f, RayMasks.DAMAGE_CLIENT);
                if ((UnityEngine.Object)raycastInfo.player != (UnityEngine.Object)null)
                    Player.player.input.sendRaycast(raycastInfo, ERaycastInfoUsage.Gun);
                //Helper.AimAt(AimTarget);
            }
        }
    }

}


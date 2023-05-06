using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Vector3 cameraDir;
    public Enemies enemies;
    public RedImp imp;
    public Cacodemon demon;

    void Update()
    {
        if (imp != null)
        {
            if (enemies.playerDetected || imp.stayCountdown > 0)
            {
                imp.transform.LookAt(enemies.player.transform.position);
            }
        }

        if (demon != null)
        {
            if (enemies.playerDetected || demon.stayCountdown > 0)
            {
                demon.transform.LookAt(enemies.player.transform.position);
            }
        }
    }
}

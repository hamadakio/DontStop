using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroudScrool : MonoBehaviour
{
    public float VelociadeScrool;
    public Renderer MaterialAttached;
    public Vector2 offset;

    public BackgroudScrool(float velS, Renderer MatAt)
    {
        VelociadeScrool = velS;
        MaterialAttached = MatAt;

    }

    public void Movescrool()
    {
        offset = new Vector2(0, VelociadeScrool * Time.deltaTime);
        MaterialAttached.material.mainTextureOffset += offset;
    }

    public float SetVelocity(float vel, bool add)
    {


        if (add)
        {
            VelociadeScrool += vel;
        }
        else if (!add)
        {
            VelociadeScrool = vel;
        }

        return VelociadeScrool;

    }
}

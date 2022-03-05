using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Hitable : MonoBehaviour
{
    [Header("Dependency")]
    [SerializeField] Rigidbody2D body;
    [SerializeField] Life life;

    [Header("Info")]
    [SerializeField] bool stun = false;
    [SerializeField] float stunDur = 0.1f;
    [SerializeField] bool invicibility = false;
    [SerializeField] float invicibilityDur = 0.1f;

    public bool Stun
    {
        get { return stun; }
        set
        {
            if (value && !stun)
            {
                Invoke("CDStun", stunDur);
            }
            stun = value;
        }
    }
    public void CDStun()
    {
        stun = true;
    }
    public void CDInvicibility()
    {
        invicibility = false;
    }
    public void TempInvici(float dur)
    {
        invicibility = true;
        Invoke("CDInvicibility", invicibilityDur);
    }
    public void Hit(Vector2 dir, float dist)
    {
        if (invicibility) return;

        life.GetHit();
        body.AddForce(dir * dist * 100 * body.mass, ForceMode2D.Force);
        TempInvici(0.2f);
    }
}

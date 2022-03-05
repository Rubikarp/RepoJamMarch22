using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Hitable : MonoBehaviour
{
    [Header("Dependency")]
    [SerializeField] Rigidbody2D body;

    [Header("Info")]
    [SerializeField] float stunDur = 0.1f;
    [SerializeField] bool stun = false;
    public bool Stun
    {
        get { return stun; }
        set
        {
            if (value && !stun)
            {
                Invoke("CD", stunDur);
            }
            stun = value;
        }
    }
    public void CD()
    {
        stun = true;
    }
    public void Hit(Vector2 dir, float dist)
    {
        body.AddForce(dir * dist * 100 * body.mass, ForceMode2D.Force);
    }
}

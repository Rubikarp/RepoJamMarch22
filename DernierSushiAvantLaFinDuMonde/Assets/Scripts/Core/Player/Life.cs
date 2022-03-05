using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField] int lifePoint = 3;
    public int LifePoint
    {
        get { return lifePoint; }
        set
        {
            lifePoint = value;
            if(lifePoint <= 0)
            {
                onDie?.Invoke();
            }
        }
    }
    public UnityEvent onDie;
    public UnityEvent onHit;

    public void GetHit()
    {
        LifePoint--;
        onHit?.Invoke();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuguEnemy : Ennemy
{
    private Vector2 position;
    public float giveUpTime = 50;
    public float speed;
    bool alerted;
    bool outOfSight;
    float timeOutOfSight;
    bool inRange;
    float explosionTime;
    GameObject explosionPrefab;
    Transform target;

    private void FixedUpdate()
    {
        GiveUp();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            StartCoroutine(Explosion());
            target = collision.transform;
            inRange = true;
            outOfSight = false;
        }
    }

    void GiveUp()
    {
        if (!alerted && outOfSight)
        {
            if (timeOutOfSight < giveUpTime)
            {
                timeOutOfSight++;
            }
            else
            {
                alerted = false;
                timeOutOfSight = 0;
            }
        }
        else
        {
            timeOutOfSight = 0;
        }
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(explosionTime);


    }
}

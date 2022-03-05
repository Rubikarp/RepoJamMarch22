using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEnemy : Ennemy
{
    private Vector2 position;
    public float giveUpTime = 50;
    public float speed;
    public bool alerted;
    public bool outOfSight;
    public float timeOutOfSight;
    Transform target;
    void Update()
    {
        if (alerted)
        {
            transform.Translate(((Vector2)target.position - (Vector2)transform.position).normalized * speed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        GiveUp();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            target = collision.transform;
            alerted = true;
            outOfSight = false;
        }
        else
        {
            outOfSight = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            outOfSight = true;
        }
    }

    void GiveUp()
    {
        if (outOfSight)
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
}

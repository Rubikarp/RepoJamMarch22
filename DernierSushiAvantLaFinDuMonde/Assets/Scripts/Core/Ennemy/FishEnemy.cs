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
    float initSpeed;
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

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Hitable>().Hit((collision.transform.position - transform.position).normalized, 1.5f);
            FallBack(0.5f);
        }
    }

    public void FallBack(float fallBackForce)
    {
        speed = -initSpeed * fallBackForce;
    }
}

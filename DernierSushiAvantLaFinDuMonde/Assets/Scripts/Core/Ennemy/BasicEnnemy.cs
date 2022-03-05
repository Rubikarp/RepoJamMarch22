using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnnemy : Ennemy
{
    private Vector2 position;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate((position-(Vector2)transform.position).normalized * speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            position = collision.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            position = sushiPos.position;
        }
    }
}

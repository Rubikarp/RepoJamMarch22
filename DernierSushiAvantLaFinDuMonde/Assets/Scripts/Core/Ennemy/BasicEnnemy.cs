using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnnemy : Ennemy
{
    private Vector2 position;
    public float speed;
    private float initSpeed;
    private void Start()
    {
        initSpeed = speed;
    }
    void Update()
    {
        if (initSpeed > speed)
            speed += Time.deltaTime;
        else
            speed = initSpeed;
        transform.Translate((position-(Vector2)transform.position).normalized * speed * Time.deltaTime);
    }
    internal override void Init(EnnemyPoolManager _poolManager, int _index, Transform _sushiPos)
    {
        base.Init(_poolManager, _index, _sushiPos);
        position = sushiPos.position;
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if(collision.gameObject.layer == 7)
        {
            //do damage to player
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 )
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

    public void FallBack(float fallBackForce)
    {
        speed = -initSpeed*fallBackForce;
    }
}

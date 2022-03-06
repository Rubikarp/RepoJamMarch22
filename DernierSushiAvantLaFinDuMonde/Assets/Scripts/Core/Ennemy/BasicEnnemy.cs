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
    void FixedUpdate()
    {
        if (initSpeed > speed)
            speed += Time.deltaTime;
        else
            speed = initSpeed;
        var Direction = (position - (Vector2)transform.position).normalized;
        transform.Translate(Direction * speed * Time.deltaTime);
        spriteRenderer.flipX = Direction.x > 0 ?  true :  false;
        if (Vector2.Distance(transform.position, sushiPos.position) < 1)
        {
            sushiPos.GetComponent<SushiBarLife>().TakeDamage(1);
            FallBack(2.5f);
        }
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
            collision.gameObject.GetComponent<Hitable>().Hit((collision.transform.position- transform.position).normalized,1.5f);
            FallBack(0.5f);
        }
    }
    public override void TakeDamage()
    {
        base.TakeDamage();
        FallBack(0.5f);
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

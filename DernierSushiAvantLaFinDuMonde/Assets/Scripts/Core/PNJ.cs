using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{
    private Vector2 sushiPosition;
    public Vector2 GunPos;
    private bool isMoving;
    private bool isWaiting;
    private PNJManager PnjManager;
    private bool waitForFood;
    [HideInInspector]
    public float waitingTime;
    public GameObject Bullet;
    public float bulletCooldwon;
    public float movingSpeed;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public void Init(PNJManager _manager, float _waiting, Vector2 _gunPos)
    {
        PnjManager = _manager;
        waitingTime = _waiting;
        GunPos = _gunPos;
        GetGun();
    }
    public void Move(float direction)
    {
        rigidbody2D.velocity = GunPos.normalized * direction * movingSpeed;
        isMoving = true;
        isWaiting = false;
        animator.SetBool("Walk",true);
        animator.SetBool("Wait", false);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isWaiting = true;
            animator.SetBool("Wait", true);
            collision.gameObject.GetComponent<SushiBarBehavior>().CreatRecepe(this);
        }
        //chek collision with sushiShop and call it ShowRecep
       else if (collision.gameObject.layer == 10 && isMoving)
        {
            PnjManager.Unselect();
            animator.SetBool("Walk", false);
        }
        rigidbody2D.velocity = Vector2.zero;
        isMoving = false;
        //Chek collision WIth GUn and call get GUn
    }

    private void GetGun()
    {
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        var _bullet =Instantiate(Bullet, transform.position, Quaternion.identity);
        _bullet.GetComponent<Rigidbody2D>().velocity = GunPos.normalized;
        yield  return new WaitForSeconds(bulletCooldwon);
        if (!isMoving && !isWaiting)
        {
            StartCoroutine(Fire());
        }
    }
    public void Death()
    {
        PnjManager.DeathOfPnj(this);
        animator.SetTrigger("Death");
        GetComponent<SpriteRenderer>().color = Color.black;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}

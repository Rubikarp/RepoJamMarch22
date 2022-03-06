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
    public Animator canonAnimator;
    public void Init(PNJManager _manager, float _waiting, GameObject _gunPos)
    {
        PnjManager = _manager;
        waitingTime = _waiting;
        GunPos = _gunPos.transform.position;
        canonAnimator = _gunPos.GetComponentInChildren<Animator>();
        canonAnimator.speed = 1 / bulletCooldwon;
    }
    public void Move(float direction)
    {
        rigidbody2D.velocity = GunPos.normalized * direction * movingSpeed;
        isMoving = true;
        isWaiting = false;
        animator.SetBool("Walk",true);
        canonAnimator.SetBool("Firing",false);
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
            canonAnimator.SetBool("Firing", false);
            animator.SetBool("Walk", false);
        }
        rigidbody2D.velocity = Vector2.zero;
        isMoving = false;
        //Chek collision WIth GUn and call get GUn
    }

    
    public void Death()
    {
        PnjManager.DeathOfPnj(this);
        animator.SetTrigger("Death");
        GetComponent<SpriteRenderer>().color = Color.black;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}

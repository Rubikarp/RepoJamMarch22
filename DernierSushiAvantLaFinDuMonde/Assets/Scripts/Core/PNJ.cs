using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{
    private Vector2 sushiPosition;
    public Vector2 GunPos;
    private float isMoving;
    private bool isFiring;

    private PNJManager PnjManager;
    private bool waitForFood;
    private float waitingTime;
    private Vector2 firingDirection;
    public GameObject Bullet;

    public void Init(PNJManager _manager, float _waiting, Vector2 _firingDirection)
    {
        PnjManager = _manager;
        waitingTime = _waiting;
        firingDirection = _firingDirection;
    }
    public void Move()
    {
        //activate movement
        //desactived firing
    }
    public void Moving(Vector2 position)
    {
        //moving toward pos
    }
    private void Update()
    {
        if (isMoving > 1)
            Moving(sushiPosition);
        else if (isMoving < -1)
            Moving(GunPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //chek collision with sushiShop and call it ShowRecep
        isMoving = 0;
        //Chek collision WIth GUn and call get GUn
    }

    private void GetGun()
    {
        //Lunch a recursive coroutine to Fire
    }
    IEnumerator Fire()
    {
        //recursive function firing bullets in a direction
        yield  break;
    }
}

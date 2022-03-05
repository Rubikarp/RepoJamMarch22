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
    public float explosionTime;
    public GameObject explosionPrefab;
    public float explosionDuration;
    Transform target;

    private void Update()
    {
        if (alerted)
        {
            transform.Translate(((Vector2)target.position - (Vector2)transform.position).normalized * speed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            alerted = true;
            StartCoroutine(Explosion());
            target = collision.transform;
            inRange = true;
            outOfSight = false;
        }
    }


    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(explosionTime);
        Destroy(Instantiate(explosionPrefab, transform.position, Quaternion.identity),explosionDuration);
        Destroy(gameObject);
    }
}

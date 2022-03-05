using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFugu : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            collision.GetComponent<Hitable>().Hit((transform.position-collision.transform.position).normalized,1.5f);
        }
    }
}

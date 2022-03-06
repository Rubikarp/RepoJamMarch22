using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFire : MonoBehaviour
{
    public GameObject bullet;
    public void Fire()
    {
        var _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
        _bullet.GetComponent<Rigidbody2D>().velocity = transform.position.normalized;
    }
}

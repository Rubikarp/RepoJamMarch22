using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    private EnnemyPoolManager poolManager;
    private int index;
    internal Transform sushiPos;
    public float life;
    [Range(0,100)]
    public float purcentageOfDrop;
    public GameObject ingredientToDrop;
    public bool canBeTargeted;

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            life--;
            collision.gameObject.GetComponent<Bullet>().Destruction();
            //anim of Damage
            if (life == 0)
                Death();
        }
    }
    internal virtual void Init(EnnemyPoolManager _poolManager, int _index, Transform _sushiPos)
    {
        poolManager = _poolManager;
        index = _index;
        sushiPos = _sushiPos;
    }
    internal virtual void Death()
    {
        //anim of Death
        var random = Random.Range(0, 100);
        if(random<purcentageOfDrop)
            Instantiate(ingredientToDrop, transform.position, Quaternion.identity);
        poolManager.OnDeath(index);
        Destroy(gameObject);
    }
}

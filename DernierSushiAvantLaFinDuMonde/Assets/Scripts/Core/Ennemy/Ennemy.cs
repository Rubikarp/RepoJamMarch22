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
    public GameObject[] ingredientToDrop;
    public bool cantBeTargeted;
    
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            life--;
            collision.gameObject.GetComponent<Bullet>().Destruction();
            //anim of Damage
            if (life == 0)
                Death();
        }
    }

    public virtual void TakeDamage()
    {
        life--;
        //anim of Damage
        if (life == 0)
            Death(true);
    }
    internal virtual void Init(EnnemyPoolManager _poolManager, int _index, Transform _sushiPos)
    {
        poolManager = _poolManager;
        index = _index;
        sushiPos = _sushiPos;
    }
    /// <summary>
    /// death normal, will not drop item
    /// </summary>
    internal virtual void Death()
    {
        //anim of Death
        poolManager.OnDeath(index);
        Destroy(gameObject);
    }
    /// <summary>
    /// need to be call when the player attacke an ennemy
    /// </summary>
    /// <param name="loot"></param>
    internal virtual void Death(bool loot)
    {
        //anim of Death
        var random = Random.Range(0, 100);
        if (random < purcentageOfDrop)
        {
            var r2 = Random.Range(0, ingredientToDrop.Length - 1);
            Instantiate(ingredientToDrop[r2], transform.position, Quaternion.identity);
        }
        ScoreSystem.instance.AddScore(100);
        poolManager.OnDeath(index);
        Destroy(gameObject);
    }
}

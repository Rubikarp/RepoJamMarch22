using UnityEngine;
using UnityEditor;

public class Bullet : MonoBehaviour
{
    public SpriteRenderer sprite;
    public LayerMask mask;
    private Transform target;
    public float speed;

    public float lifeTime;
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destruction();
        if(!target)
        {
           var collider = Physics2D.OverlapCircleAll(transform.position, 10f, mask);
            if (collider.Length>0)
            {
                for (int i = 0; i < collider.Length; i++)
                {
                    if (!collider[i].GetComponent<Ennemy>().cantBeTargeted)
                    {
                        target = collider[i].transform;
                        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        collider[i].GetComponent<Ennemy>().cantBeTargeted = true;
                        return;
                    }
                }
                
            }
        }
        else
        {
            transform.Translate((target.position- transform.position ).normalized * Time.deltaTime * speed);
        }
    }

    public void Destruction()
    {
        if (target)
            target.GetComponent<Ennemy>().cantBeTargeted = false;
        //instantiate explosion
        Destroy(gameObject);
    }
}

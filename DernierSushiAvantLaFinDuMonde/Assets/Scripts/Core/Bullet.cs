using UnityEngine;

public class Bullet : MonoBehaviour
{
    public SpriteRenderer sprite;
    public LayerMask mask;
    private Transform target;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (!sprite.isVisible)
            Destruction();
        if(!target)
        {
           var collider = Physics2D.OverlapCircle(transform.position, 2f, mask);
            if (collider)
            {
                if (!collider.GetComponent<Ennemy>().canBeTargeted)
                {
                    target = collider.transform;
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    collider.GetComponent<Ennemy>().canBeTargeted = true;
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
        //instantiate explosion
        Destroy(gameObject);
    }
}

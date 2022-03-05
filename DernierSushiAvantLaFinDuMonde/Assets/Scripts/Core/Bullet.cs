using UnityEngine;

public class Bullet : MonoBehaviour
{
    public SpriteRenderer sprite;

    void Update()
    {
        if (!sprite.isVisible)
            Destruction();
    }

    public void Destruction()
    {
        //instantiate explosion
        Destroy(gameObject);
    }
}

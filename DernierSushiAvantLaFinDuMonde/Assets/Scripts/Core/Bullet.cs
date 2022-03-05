using UnityEngine;

public class Bullet : MonoBehaviour
{
    public SpriteRenderer sprite;

    // Update is called once per frame
    void Update()
    {
        if (!sprite.isVisible)
            Destruction();
    }

    private void Destruction()
    {
        //instantiate explosion
        Destroy(gameObject);
    }
}

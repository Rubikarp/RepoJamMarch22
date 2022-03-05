using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Header("Dependency")]
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D body;
    [SerializeField] PlayerMovement mouv;

    void Update()
    {
        if(mouv.lastDir.x < 0)
        {
            //Regard gauche
            renderer.flipX = true;
        }
        else
        {
            //regard Droite
            renderer.flipX = false;
        }

        animator.SetFloat("OrientY", mouv.lastDir.y);
        animator.SetFloat("Speed", body.velocity.magnitude);
    }
}

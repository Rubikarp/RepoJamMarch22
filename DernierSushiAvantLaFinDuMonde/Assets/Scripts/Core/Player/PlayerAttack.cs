using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using NaughtyAttributes;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerAttack : MonoBehaviour
{
    [Header("Dependency")]
    [SerializeField] Transform self;
    [SerializeField] PlayerMovement mouv;

    [Header("Info")]
    [SerializeField] LayerMask layerHit;
    [Tag]
    [SerializeField] string aimedTag;
    [SerializeField] float range = 5f;
    [SerializeField] float strenght = 5f;
    [SerializeField] float coolDown = 0.2f;
    [SerializeField] bool canAttack = true;
    public bool CanAttack
    {
        get { return canAttack; }
        set
        {
            if(!value && canAttack)
            {
                Invoke("CD", 0.2f);
            }
            canAttack = value;
        }
    }


    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && canAttack)
        {
            CanAttack = false;
            Attack(mouv.lastDir);
        }
    }

    public void CD()
    {
        canAttack = true;
    }

    public void Attack(Vector2 dir)
    {
        Vector2 attackDir;
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            attackDir = dir.x < 0 ? Vector2.left : Vector2.right;
        }
        else
        {
            attackDir = dir.y < 0 ? Vector2.down : Vector2.up;
        }

        Collider2D[] collHit = Physics2D.OverlapCircleAll(transform.position, range, layerHit);
        foreach (Collider2D coll in collHit)
        {
            if (coll.tag != aimedTag)
            { continue; }
            if (coll.isTrigger)
            { continue; }

            Vector2 MeToColider = coll.transform.position - transform.position;
            if (Vector2.Dot(MeToColider, attackDir) >= 0)
            {
                Debug.Log("Hit " + coll.gameObject.name);
                //Bim!
                coll.gameObject.GetComponent<Ennemy>().TakeDamage();
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        using (new Handles.DrawingScope(Color.magenta))
        {
            Handles.Label(transform.position + Vector3.up * (range+0.2f), "attackRange");
            Handles.DrawWireDisc(transform.position, Vector3.back, range);
        }
    }
#endif
}

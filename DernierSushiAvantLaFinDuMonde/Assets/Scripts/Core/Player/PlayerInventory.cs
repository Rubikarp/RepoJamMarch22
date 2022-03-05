using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Ingredient> inventory = new List<Ingredient>();
    public int maxSized = 5;

    [NaughtyAttributes.Tag]
    [SerializeField] string foodTag;
    public void RecupItem()
    {
        if(inventory.Count >= maxSized) 
            return;

        Collider2D[] collHit = Physics2D.OverlapCircleAll(transform.position, 3f);
        foreach (Collider2D coll in collHit)
        {
            if (coll.tag != foodTag)
            { continue; }

            inventory.Add(coll.gameObject.GetComponent<FoodItem>().ingredient);
            Destroy(coll.gameObject);
            return;
        }
    }

    public void DropItem()
    {
        if (inventory.Count <= 0) 
            return;

        inventory.Remove(inventory.Last());
    }
}

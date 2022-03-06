using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Ingredient> inventory = new List<Ingredient>();
    public int maxSized = 5;
    private SushiBarBehavior sushiBar;
    [NaughtyAttributes.Tag]
    [SerializeField] string foodTag;
    public void RecupItem()
    {
        if (sushiBar)
            if (sushiBar.ServeRecepe(inventory))
                inventory.Clear();

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!sushiBar && collision.gameObject.layer == 6)
             collision.TryGetComponent<SushiBarBehavior>(out sushiBar);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (sushiBar && collision.gameObject.layer == 6)
            sushiBar = null;
    }
    public void DropItem()
    {
        if (inventory.Count <= 0) 
            return;

        inventory.Remove(inventory.Last());
    }
    public void DropInventory()
    {
        inventory.Clear();
    }
}

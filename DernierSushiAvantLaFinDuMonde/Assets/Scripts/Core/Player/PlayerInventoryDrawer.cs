using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryDrawer : MonoBehaviour
{
    [SerializeField] PlayerInventory inventory;
    [SerializeField] List<GameObject> slots;
    [SerializeField] List<Image> slotsImage;
    [SerializeField] GameObject inventorySlotTemplate;
    [SerializeField] Sprite empty;
    [NaughtyAttributes.Button]
    void Update()
    {
        if (slots.Count < inventory.maxSized)
        {
            do
            {
                GameObject temp = Instantiate(inventorySlotTemplate, transform);
                slots.Add(temp);
                slotsImage.Add(temp.transform.GetChild(0).GetComponent<Image>());
            } while (slots.Count < inventory.maxSized);
        }
        if (slots.Count > inventory.maxSized)
        {
            do
            {
                GameObject temp = slots.Last();
                slots.Remove(temp);
                slotsImage.Remove(slotsImage.Last());
                Destroy(temp);
            } while (slots.Count > inventory.maxSized);
        }

        for (int i = 0; i < slotsImage.Count; i++)
        {
            if (i < inventory.inventory.Count)
            {
                slotsImage[i].sprite = inventory.inventory[i].ingredientSprite;
            }
            else
            {
                slotsImage[i].sprite = empty;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public Ingredient ingredient;
    [SerializeField] SpriteRenderer render;

    private void Start()
    {
        render.sprite = ingredient.ingredientSprite;
    }
}

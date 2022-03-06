using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recepe 
{
    private List<Ingredient>ingredients ;

    public Recepe(List<Ingredient> _ingredients)
    {
        ingredients =  _ingredients;
    }

    /// <summary>
    /// return true if the ingrdient are the good one no matter the order
    /// </summary>
    /// <param name="_ingredients"></param>
    /// <returns></returns>
    public bool CheckRecepe(List<Ingredient> _ingredients)
    {
        var tempList = ingredients;
        foreach (var ingredient in _ingredients)
        {
            if (ingredients.Contains(ingredient)) tempList.Remove(ingredient);
        }
        if (tempList.Count == 0)
            return true;
        return false;
    }
}

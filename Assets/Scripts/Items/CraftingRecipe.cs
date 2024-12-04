using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemNumbers
{
    public ItemData Item;
    [Range(1, 100)]
    public int amount;
}
[CreateAssetMenu(fileName = "newRecipe", menuName = "Recipe", order = 1)]
public class CraftingRecipe : ScriptableObject {

    public string recipeName;
    public Sprite icon;
    public List<ItemNumbers> recipeIngredients;
    public List<ItemNumbers> recipeResults;

    public bool CanCraft(InventoryHandler inventory)
    {
        for(int i = 0; i < recipeIngredients.Count; i++)
        {
            if(!inventory.HasItem(recipeIngredients[i].Item, recipeIngredients[i].amount))
            {
                return false;
            }
        }
        return true;
    }

    public void CraftItem(InventoryHandler inventory)
    {
        if(CanCraft(inventory))
        {
            for (int i = 0; i < recipeIngredients.Count; i++)
            {
                inventory.RemoveItem(recipeIngredients[i].Item, recipeIngredients[i].amount);
            }
            for (int j = 0; j < recipeIngredients.Count; j++)
            {
                inventory.AddItem(recipeResults[j].Item, recipeResults[j].amount);
            }
        }
    }

}

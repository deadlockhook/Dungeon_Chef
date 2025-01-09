using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    // Ingredient Scriptable Objects. Add here if you create a new ingredient
    public Ingredient carrot;
    public Ingredient sugar;
    
    //Singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Holds ingredient and its quantity
    [System.Serializable]
    public class IngredientSlot
    {
        public Ingredient ingredient;
        public int quantity;
    }

    public List<IngredientSlot> ingredientSlots = new List<IngredientSlot>();

    public void AddIngredient(Ingredient ingredient, int amount)
    {
        // Finds the ingredient slot with the matching ingredient, or null if its not found
        var slot = ingredientSlots.Find(s => s.ingredient == ingredient);
        if (slot != null)
        {
            slot.quantity += amount;
        }
        else
        {
            // Adds a new slot if the ingredient is not found
            ingredientSlots.Add(new IngredientSlot { ingredient = ingredient, quantity = amount });
        }
    }

    public bool RemoveIngredient(Ingredient ingredient, int amount)
    {
        // Finds the ingredient slot with the matching ingredient, or null if its not found
        var slot = ingredientSlots.Find(s => s.ingredient == ingredient);
        if (slot != null && slot.quantity >= amount)
        {
            slot.quantity -= amount;
            if (slot.quantity == 0)
            {
                ingredientSlots.Remove(slot);
            }
            return true;
        }
        return false;
    }
}
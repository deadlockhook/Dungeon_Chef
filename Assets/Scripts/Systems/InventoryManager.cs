using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Singleton
    public static InventoryManager Instance { get; private set; }
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

    // Enums for ingredients and dishes
    public enum IngredientList
    {
        IngredientOne = 0, // Ex: Carrot
        IngredientTwo = 1  // Ex: Flour
    }

    public enum DishList
    {
        DishOne = 0 // Ex: Carrot Cake
    }

    // Ingredient struct
    public struct Ingredient
    {
        public string Name;
        public int IngredientIndex;

        public Ingredient(string name, int index)
        {
            Name = name;
            IngredientIndex = index;
        }
    }

    // Dish struct
    public struct Dish
    {
        public string Name;
        public int DishIndex;
        public List<KeyValuePair<int, int>> IngredientsRequired;

        public Dish(string name, int index, List<KeyValuePair<int, int>> ingredientsRequired)
        {
            Name = name;
            DishIndex = index;
            IngredientsRequired = ingredientsRequired;
        }
    }

    // Lists for ingredients and dishes
    private List<Ingredient> ingredients = new List<Ingredient>();
    private List<Dish> dishes = new List<Dish>();

    // Unlocked dishes
    private List<Dish> unlockedDishes = new List<Dish>();

    // Add an ingredient to the inventory
    public int AddIngredient(int index)
    {
        ingredients.Add(new Ingredient(((IngredientList)index).ToString(), index));
        return ingredients.Count;
    }

    // Remove an ingredient from the inventory
    public int RemoveIngredient(int index)
    {
        var ingredient = ingredients.Find(i => i.IngredientIndex == index);
        if (ingredient.Name != null)
        {
            ingredients.Remove(ingredient);
        }
        return ingredients.Count;
    }

    // Add a dish to the inventory
    public int AddDish(int index)
    {
        dishes.Add(new Dish(((DishList)index).ToString(), index, new List<KeyValuePair<int, int>>()));
        return dishes.Count;
    }

    // Remove a dish from the inventory
    public int RemoveDish(int index)
    {
        var dish = dishes.Find(d => d.DishIndex == index);
        if (dish.Name != null)
        {
            dishes.Remove(dish);
        }
        return dishes.Count;
    }

    private void RemoveIngredientForADish(Dish dish)
    {
        foreach (var requirement in dish.IngredientsRequired)
        {
            for (int i = 0; i < requirement.Value; i++)
            {
                RemoveIngredient(requirement.Key);
            }
        }
    }

    // Check if a dish can be unlocked
    public bool IsDishUnlockable(Dish providedDish)
    {
        foreach (var requirement in providedDish.IngredientsRequired)
        {
            int ingredientIndex = requirement.Key;
            int requiredCount = requirement.Value;

            int availableCount = ingredients.FindAll(i => i.IngredientIndex == ingredientIndex).Count;

            if (availableCount < requiredCount)
                return false;
        }
        return true;
    }

    // Research a dish
    public int ResearchDish(Dish providedDish)
    {
        if (IsDishUnlockable(providedDish))
        {
            unlockedDishes.Add(providedDish);

            // Remove ingredients from inventory
            foreach (var requirement in providedDish.IngredientsRequired)
            {
                int ingredientIndex = requirement.Key;
                int requiredCount = requirement.Value;

                for (int i = 0; i < requiredCount; i++)
                {
                    RemoveIngredient(ingredientIndex);
                }
            }
            return unlockedDishes.Count;
        }
        return -1;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CookingManager : MonoBehaviour
{
    private InventoryManager invenManager;
    private List<InventoryManager.Dish> cookedDishes;
    void Start()
    {
        cookedDishes = new List<InventoryManager.Dish>();
        invenManager = FindAnyObjectByType<InventoryManager>();
    }

    void CookDish(InventoryManager.Dish dish)
    {
        if (invenManager.IsDishUnlockable(dish))
        {
            cookedDishes.Add(dish);
        }
    }

    void Update()
    {
        
    }
}

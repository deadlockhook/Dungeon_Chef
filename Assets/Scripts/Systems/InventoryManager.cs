using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    // Ingredient Scriptable Objects. Add here if you create a new ingredient
    public Ingredient carrot;
    public Ingredient sugar;
    public Food cake;
    
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

    // Holds item and its quantity
    [System.Serializable]
    public class InventorySlot
    {
        public ScriptableObject item;
        public int quantity;
    }

    public List<InventorySlot> inventorySlots = new List<InventorySlot>();

    public void AddItem(ScriptableObject item, int amount)
    {
        // Finds the item slot with the matching iitem, or null if its not found
        var slot = inventorySlots.Find(s => s.item == item);
        if (slot != null)
        {
            slot.quantity += amount;
        }
        else
        {
            // Adds a new slot if the item is not found
            inventorySlots.Add(new InventorySlot { item = item, quantity = amount });
        }
    }

    public bool RemoveItem(ScriptableObject item, int amount)
    {
        // Finds the item slot with the matching item, or null if its not found
        var slot = inventorySlots.Find(s => s.item == item);
        if (slot != null && slot.quantity >= amount)
        {
            slot.quantity -= amount;
            if (slot.quantity == 0)
            {
                inventorySlots.Remove(slot);
            }
            return true;
        }
        return false;
    }
}
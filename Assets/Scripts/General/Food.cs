using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Inventory/Food")]
public class Food : ScriptableObject

{
    public string foodName;
    public Sprite icon;
}

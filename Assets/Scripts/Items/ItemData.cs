using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "Item", order = 1)]
public class ItemData : ScriptableObject {
    
    public string itemName;
    public string itemDescription;
    public Sprite icon;

}

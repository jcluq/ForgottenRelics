using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Potion Item", menuName = "Inventory System/Items/Potion")]
public class PotionObject : ItemObject
{
    // Start is called before the first frame update
    public int hpRes;
    public void Awake()
    {
       // type = ItemType.Potion;
    }
}

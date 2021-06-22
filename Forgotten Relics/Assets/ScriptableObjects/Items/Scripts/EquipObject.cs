using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equip Item", menuName = "Inventory System/Items/Equip")]
public class EquipObject : ItemObject
{
    // Start is called before the first frame update
    public int STR;
    public int DEX;
    public int INT;
    public int DEF;
    public int ATK;
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}

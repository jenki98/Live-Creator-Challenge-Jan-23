using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoreMenu", menuName = "ScriptableObjects/NewStore Item", order = 1)]
public class ItemSO : ScriptableObject
{
    public string ItemName;
    public string Description;
    public int Price;
    public string ItemIcon;
}

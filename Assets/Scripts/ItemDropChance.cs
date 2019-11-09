using UnityEngine;
using System;

[Serializable]
public class ItemDropChance
{
    public Item item;
    [Range(0,100)]
    public float dropChance;
}

using System.Collections.Generic;
using UnityEngine;

public class LootData : MonoBehaviour
{
    public LootUI lootUI;
    public List<ItemDropChance> droppableItems;
    public List<Item> currentItems;

    private void Awake() {
        SetCurrentItems();
    }

    public void SetCurrentItems() {
        for (int i = 0; i < droppableItems.Count; i++) { 
            float randomNum =  Random.Range(0f, 100f);

            if(randomNum <= droppableItems[i].dropChance) {
                currentItems.Add(droppableItems[i].item);
            }
        }
    }

    private void OnMouseDown() {
        if(lootUI.target != gameObject) {
            lootUI.Display(currentItems);
            lootUI.SetTarget(gameObject);
        }else{
            lootUI.Clear();
        }
    }
}

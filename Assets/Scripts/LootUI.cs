using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootUI : MonoBehaviour
{   
    public Camera mainCamera;
    public RectTransform scrollView;
    public RectTransform scrollViewContent;
    public GameObject itemUIPrefab;
    public GameObject target;

    private void Awake() {
        scrollView.gameObject.SetActive(false);
    }

    public void Display(List<Item> currentItems) {
        scrollView.gameObject.SetActive(true);
        foreach(Item item in currentItems) {
            GameObject clone = Instantiate(itemUIPrefab, scrollViewContent);
            clone.GetComponent<Image>().sprite = item.art;
        }
    }

    public void Clear() {
        scrollView.gameObject.SetActive(false);
        foreach(Transform item in scrollViewContent) {
            Destroy(item.gameObject);
        }
        target = null;
    }

    public void SetTarget(GameObject target) {
        this.target = target;
    }
}  

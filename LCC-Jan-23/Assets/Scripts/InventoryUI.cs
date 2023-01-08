using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject texts;
    public Transform textParent;
    private List<string> items = new List<string>();

    private void Start()
    {
       
        
       
    }


    public void ShowInventory()
    {
        foreach (Item i in InventoryManager.Instance.items)
        {

            GameObject inventory = Instantiate(texts, textParent);
            TMP_Text text = inventory.GetComponent<TMP_Text>();
            text.text = i.Name;
        }
    }

}

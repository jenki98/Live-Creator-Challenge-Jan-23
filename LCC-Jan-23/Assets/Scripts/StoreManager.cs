using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private int gems;
    [SerializeField] private TMP_Text gemsUI;
    [SerializeField] private ItemSO[] itemSO;
    [SerializeField] private Transform templateParent;
    [SerializeField] private GameObject templatePrefab;
    [SerializeField] private List<Button> purchaseBtns;
    [SerializeField] private GameObject popUpPanel;
    private StoreTemplate storeTemplate;


    void Start()
    {
        UpdateGemsUI();
        CheckPurchasable();
        LoadItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckPurchasable()
    {
        for (int i = 0; i < itemSO.Length; i++)
        {
            if (gems >= itemSO[i].Price)
            {
                //purchaseBtns[i].interactable = true;
            }
            else
            {
               // purchaseBtns[i].interactable = false;

            }
        }
    }

    void UpdateGemsUI()
    {
        gemsUI.text = "Gems: " + gems.ToString();
    }


    public void PurchaseItems(ItemSO item)
    {
        if (gems >= item.Price)
        {
            //add listener to add to inventory
            gems = gems - item.Price;
            InventoryManager.Instance.AddInventoryItem(item);
            
        }else if(gems < item.Price)
        {
            //SetActive pop up to buy more gems
            popUpPanel.SetActive(true);
        }
        UpdateGemsUI();
    }

    private void LoadItems()
    {
        foreach(ItemSO item in itemSO)
        {
            GameObject items = Instantiate(templatePrefab, templateParent);
            storeTemplate = items.GetComponent<StoreTemplate>();
            Button btn = items.GetComponentInChildren<Button>();
            btn.onClick.AddListener(() => { PurchaseItems(item); });
            storeTemplate.itemTxt.text = item.ItemName;
            storeTemplate.descriptionTxt.text = item.Description;
            storeTemplate.priceText.text = "Gems: " + item.Price.ToString();
            storeTemplate.icon. = Resources.Load(item.ItemIcon) as Sprite;
            purchaseBtns.Add(btn);
        }

       
    }
       
 }


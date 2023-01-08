using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private int gems;
    [SerializeField] private TMP_Text gemsUI;
    [SerializeField] private TMP_Text messageUI;
    [SerializeField] private ItemSO[] itemSO;
    [SerializeField] private Transform templateParent;
    [SerializeField] private GameObject templatePrefab;
    [SerializeField] private List<Button> purchaseBtns;
    [SerializeField] private GameObject popUpPanel;
    private StoreTemplate storeTemplate;


    void Start()
    {
       // UpdateGemsUI();
        LoadItems();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGemsUI();
    }


 

    void UpdateGemsUI()
    {
        gemsUI.text = " " + gems.ToString();
    }

    public void PurchaseMoreGems(int amount)
    {
        gems = gems + amount;
    }
    public void PurchaseItems(ItemSO item)
    {
        if (gems >= item.Price)
        {
            //add listener to add to inventory
            gems = gems - item.Price;
            InventoryManager.Instance.AddInventoryItem(item);
            messageUI.text = item.ItemName + " Purchased";
            
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
            storeTemplate.priceText.text = "" + item.Price.ToString();
            storeTemplate.icon.sprite = Resources.Load(item.ItemIcon, typeof(Sprite)) as Sprite;
           
            purchaseBtns.Add(btn);
        }

       
    }
       
 }


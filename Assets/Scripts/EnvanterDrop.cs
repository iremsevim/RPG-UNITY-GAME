using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnvanterDrop : MonoBehaviour,IDropHandler
{
    public static EnvanterDrop instance;
    public Image usingitemımage;
    public void Awake()
    {
        instance = this;
    }
    public void OnDrop(PointerEventData eventData)
    {
     CharackterController.instance.charackterusingitem = eventData.selectedObject.GetComponent<EnvanterSlot>().itemID;
       GameData.ItemProfil findedprofil= GameData.instance.allitems.Find(x => x.items == eventData.selectedObject.GetComponent<EnvanterSlot>().itemID);
    
        foreach (Transform item in CharackterController.instance.gunpoint)
        {
            Destroy(item.gameObject);
        }
        GameObject createditem = Instantiate(findedprofil.itempprefab, CharackterController.instance.gunpoint.position, Quaternion.identity);
        createditem.transform.SetParent(CharackterController.instance.gunpoint);
        usingitemımage.sprite = findedprofil.itemicon;
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

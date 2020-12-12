using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnvanterSlot : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Image ımage;
    public Text counttext;
    public Vector3 firstpos;
    public AllItem itemID;
  
   
    public void OnBeginDrag(PointerEventData eventData)
    {
        firstpos = transform.position;
        transform.SetParent(EnvanterDrop.instance.transform);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = firstpos;
        transform.SetParent(GameData.instance.uı_data.envanterslotcarrier);
    }

    private void OnMouseUpAsButton()
    {
        
    }




    public void SetUp(Sprite sprite,int count,AllItem ıd)
    {
        ımage.sprite = sprite;
        counttext.text = count.ToString();
        itemID = ıd;
    }

   
}

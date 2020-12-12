using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvanterSystem : MonoBehaviour
{
    public List<EnvanterProfil> envanterProfil;   


    public void İtemEkleme(int addcount,AllItem ID)
    {

       EnvanterProfil newitem= envanterProfil.Find(x=>x.ID==ID);
        if (newitem == null)
        {
            EnvanterProfil newenvanter = new EnvanterProfil(ID,addcount);
            envanterProfil.Add(newenvanter);
            
        }
        else
        {
            newitem.itemcount += addcount;
        } 

    }
    public void İtemÇıkartma(int item_2,AllItem ID)
    {

        EnvanterProfil newitem = envanterProfil.Find(x => x.ID == ID);
         
        if(newitem==null)
        {
            return;
        }
        else
        {
            if (item_2 >= newitem.itemcount) return;

            newitem.itemcount -= item_2;
            if(newitem.itemcount==0)
            {
                envanterProfil.Remove(newitem);
            }
        }

    }

   [System.Serializable]
   public class EnvanterProfil
    {
        public AllItem ID;
        public int itemcount;
      
        public EnvanterProfil(AllItem _ID,int _itemcount)
        {
            ID = _ID;
            itemcount = _itemcount;
        }

    }
}

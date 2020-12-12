using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Worker
{

    public static void UI_ShowEnvanter()
    {
        GameData.instance.uı_data.maingamewindowbase.SetActive(false);
        GameData.instance.uı_data.envanterwindowcarrier.gameObject.SetActive(true);
        foreach (EnvanterSystem.EnvanterProfil item in CharackterController.instance.envanterSystem.envanterProfil)
        {
            GameObject ceratedslot = GameData.Instantiate(GameData.instance.uı_data.envanterslotprefab,Vector3.zero, Quaternion.identity, GameData.instance.uı_data.envanterslotcarrier);
            GameData.ItemProfil itemprofil  =GameData.instance.allitems.Find(x => x.items == item.ID);
            ceratedslot.GetComponent<EnvanterSlot>().SetUp(itemprofil.itemicon,item.itemcount,item.ID);
        }


    }
    public static void UIHideInventory()
    {
        GameData.instance.uı_data.envanterwindowcarrier.gameObject.SetActive(false);
        GameData.instance.uı_data.maingamewindowbase.SetActive(true);

    }
    public static void SwordHit(this Transform HitPoint,LayerMask enemymask,float radius,System.Action<Transform> kılıçvuruncaolcaklar, float Angle)
    {
        HitPoint.RadialRaycastBase(enemymask, radius,((Transform değilen) =>
        {
            Vector3 dir = değilen.transform.position - HitPoint.position; // find enemy direction
            dir.y = HitPoint.forward.y;
            if (Vector3.Angle(dir, HitPoint.forward) <= Angle)
            {
               //  Debug.Log("Açı"+ Vector3.Angle(dir, HitPoint.forward));
                kılıçvuruncaolcaklar.Invoke(değilen.transform);
            }
        }));
    }

    public static void RadialRaycastBase(this Transform HitPoint, LayerMask enemymask, float radius,System.Action<Transform> VuruncaOlacaklar)
    {
        // get colliders inside range:
        Collider[] cols = Physics.OverlapSphere(HitPoint.position, radius, enemymask);
        foreach (Collider col in cols)
        {
            VuruncaOlacaklar.Invoke(col.transform);
        }

    }

    public static void LookatTarget_Y(this Transform Tran, Vector3 Position, float Speed)
    {
        Quaternion targetRotation = Quaternion.LookRotation(Position - Tran.position);
        targetRotation.x = 0;
        targetRotation.z = 0;
        // Smoothly rotate towards the target point.
        Tran.rotation = Quaternion.Slerp(Tran.rotation, targetRotation, Speed * Time.deltaTime);
    }

}
public static class AudioWorker
{
    public static void PlayAudio(this string ID,Vector3 pos)
    {
     AudioData findedaudio=GameData.instance.AllAudios.Find(x => x.ID == ID);
        GameObject createdaudio = new GameObject();
        createdaudio.transform.position = pos;
        createdaudio.AddComponent<AudioSource>();
        createdaudio.GetComponent<AudioSource>().PlayOneShot(findedaudio.clip);
        GameData.Destroy(createdaudio.gameObject,findedaudio.clip.length);
    }
}

public static class ParticleWorker
{
   public static void ShowParticle(this string ID,Vector3 pos)
    {
      ParticleData findedparticle=GameData.instance.allparticles.Find(x => x.ID == ID);
        GameObject createdparticle = GameData.Instantiate(findedparticle.particle, pos, Quaternion.identity);
        GameData.Destroy(createdparticle.gameObject,3f);
    }
}
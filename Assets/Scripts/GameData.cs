using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GameData : MonoBehaviour
{
    public static GameData instance;
    public List<ItemProfil> allitems;
    public List<AudioData> AllAudios;
    public List<ParticleData> allparticles;
    public UI_Data uı_data;
    private void Awake()
    {
        instance = this;
    }

    [System.Serializable]
    public class ItemProfil
    {
        public string ıtemname;
        public AllItem items;
        public Sprite itemicon;
        public GameObject itempprefab;
        public int damageamount;
    }
    [System.Serializable]
    public class UI_Data
    {
        public Transform envanterwindowcarrier;
        public GameObject maingamewindowbase;
        public Transform envanterslotcarrier;
        public GameObject envanterslotprefab;
        public Image UI_HealthBar;
        
    }
}
[System.Serializable]
public class AudioData
{
    public string ID;
    public AudioClip clip;
}
[System.Serializable]
public class ParticleData
{
    public string ID;
    public GameObject particle;
}
   

public enum AllItem
{
    sword=0,axe=1
}

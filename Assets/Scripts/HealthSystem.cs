using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int maxhealth;
    public System.Action OnDamaged;
    public System.Action OnDead;



    public void GetDamage(int damage)
    {
        if (health <= 0) return;
        health -= damage;
        OnDamaged?.Invoke();
        if(health<=0)
        {
            OnDead?.Invoke();
        }
    }

}

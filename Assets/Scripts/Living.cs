using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]



public class Living : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public HealthSystem healthSystem;
    public ParticleSystem bloodparticul;
    public ParticleSystem soul;
    public string DamageSound;
    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
       
    }

    public virtual void Movement()
    {

    }
    
   
}

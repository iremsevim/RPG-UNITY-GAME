using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Living
{
    public static List<EnemyController> Allenemies = new List<EnemyController>();
    public EnemyState state;
    public float attackingdistance = 2f;
    public float timer = 3f;
    public float attackrate = 3f;
    public Transform hitpoint;
    public LayerMask charackermask;
    public float attackradius;
    public int damageamount;
    public string EnemyDeadSoundID;
    public string laughingSoundID;

    public void Awake()
    {
        Allenemies.Add(this);
    }
    public void OnDestroy()
    {
        Allenemies.Remove(this);
    }

    private void Start()
    {
        healthSystem.OnDamaged = () =>
          {
              animator.SetTrigger("gethit");
              if (bloodparticul!=null)
              {
                  bloodparticul?.Play();
              }
             
              DamageSound.PlayAudio(transform.position);
          };
        healthSystem.OnDead = () =>
          {
              animator.SetTrigger("dead");
              agent.isStopped = true;
              Destroy(gameObject, 2f);
              EnemyDeadSoundID.PlayAudio(transform.position);

          };
    }

    public void Update()
    {
        if (healthSystem.health <= 0 || CharackterController.instance.healthSystem.health<=0) return;
        if(state==EnemyState.yürüme)
        {
            agent.isStopped = false;
            agent.SetDestination(CharackterController.instance.transform.position);
        }
        else
        {
            agent.isStopped = true;
        }
        EnemyAttack();


    }
    public void AttackHitController()
    {
        int rand = Random.Range(0, 10);
        if(rand<5)
        {
            laughingSoundID.PlayAudio(transform.position);
        }
       
        Worker.SwordHit(hitpoint, charackermask, attackradius, (Transform degılen) => 
        {
            if(degılen.GetComponent<CharackterController>())
            {
                degılen.GetComponent<CharackterController>().healthSystem.GetDamage(damageamount);

            }
            Debug.Log(degılen.transform.name);

        }, 60);
    }

    public void EnemyAttack()
    {
         transform.LookatTarget_Y(CharackterController.instance.transform.position,90f);
        
       
        if (Vector3.Distance(transform.position, CharackterController.instance.transform.position) < attackingdistance)
        {
            state = EnemyState.saldırı;
            

        }
        else
        {
            state = EnemyState.yürüme;
            animator.SetBool("run", true);
        }


        if(state==EnemyState.saldırı)
        {
            animator.SetBool("run", false);
            timer -= Time.deltaTime;
            if(timer<=0)
            {
               animator.SetTrigger("attack");
               timer = attackrate;
            }
        }
       
    }
}

public enum EnemyState
{
    yürüme=0,saldırı=1
}

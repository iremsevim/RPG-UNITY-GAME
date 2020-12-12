using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharackterController : Living
{
    public static CharackterController instance;
    public LayerMask groundmask;
    public EnvanterSystem envanterSystem;
    public AllItem charackterusingitem;
    public Transform gunpoint;
    public AnimationEvent animationEvent;
    public Transform hitpoint;
    public LayerMask enemymask;
    public float attackradius;
    public int damageamount = 10;
    public bool CanStrike = false;


    private void Awake()
    {
        instance = this;
        
    }
    public override void Start()
    {
        base.Start();
        healthSystem.OnDamaged = () =>
        {
            bloodparticul.Play();
            animator.SetTrigger("hit");
            ApplyHealthtoUI();
            DamageSound.PlayAudio(transform.position);
        };
        healthSystem.OnDead = () =>
        {
            animator.SetTrigger("death");
            Debug.Log("öldüm");
            ("playerdead").PlayAudio(transform.position);
            agent.isStopped = true;
        };
       
    }
    public void SwordAttackController()
    {
        Debug.Log("hitted");
        Worker.SwordHit(hitpoint, enemymask, attackradius, (Transform vurulan) =>
        {
            if(vurulan.GetComponent<EnemyController>())
            {

                ("swordcut").PlayAudio(transform.position);

                vurulan.GetComponent<EnemyController>().healthSystem.GetDamage(damageamount); 
            }
            Debug.Log(vurulan.name);
        },60f);
    }
    public float PercentHealth
    {
        get
        {
            return (float)healthSystem.health / (float)healthSystem.maxhealth;
        }
    }
    public void ApplyHealthtoUI()
    {
        GameData.instance.uı_data.UI_HealthBar.fillAmount= PercentHealth;


    }
    public void Death()
    {
        soul.Play();
    }
   

    public void Update()
    {
        if (healthSystem.health <= 0) return;
        Movement();
        if(Input.GetKeyDown(KeyCode.Space) && CanStrike)
        {
            agent.angularSpeed = 0;
            ("Sword").PlayAudio(transform.position);
            FocusEnemy();
            animator.SetTrigger("attack");
            CanStrike = false;
        }
    }
    public void StrikeEnd()
    {
        agent.angularSpeed = 180;
        CanStrike = true;
    }
    public override void Movement()
    {
        base.Movement();
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            RaycastHit hit;
            if(Physics.Raycast(ray.origin,ray.direction,out hit,100f,groundmask))
            {

                Vector3 destination = hit.point;
                ("hit").ShowParticle(hit.point);
                agent.SetDestination(destination);
                this.animator.SetBool("moving", true);
            }
        }

        else
        {
            if(Vector3.Distance(transform.position,agent.destination)<2f)
            {
                animator.SetBool("moving", false);
               
            }
        }

    }
    public void FocusEnemy()
    {
        bool IsFar = false;                                     
        EnemyController enyakın = EnemyController.Allenemies[0];
        List<EnemyController> other = EnemyController.Allenemies.FindAll(x => x != enyakın);
        
        for (int i = 0; i < other.Count; i++)
        {
            if (Vector3.Distance(transform.position,other[i].transform.position)<Vector3.Distance(transform.position,enyakın.transform.position))
            {
                enyakın = EnemyController.Allenemies[i];
            }
        }

        if (Vector3.Distance(transform.position, enyakın.transform.position) < attackradius * 4f)
        {
            transform.LookatTarget_Y(enyakın.transform.position, 180);
        }
       

    }
    
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

abstract public class Enemyclass : CharacterMechanics
{
    protected GameObject m_target;
    public float m_minRange = 0.0f;
    public float m_AttackSpeed = 2;

    protected NavMeshAgent m_NavMeshAgent;
    protected float m_maxTimer = 2f;

    protected float m_targetFindTimer = 1f;

    protected List<GameObject> m_validTargets;
    protected virtual GameObject GetNearestTarget()
    {
        IEnumerable<GameObject> currentValidTargets = m_validTargets.Where(target => target != null && (target.GetType() != typeof(Cow) 
                                                                        || Vector3.Distance(target.transform.position, transform.position) < 20.0f))
                                                                  .OrderBy(target => Vector3.Distance(target.transform.position, transform.position));
        return currentValidTargets.First();
    }

    protected virtual void Awake()
    {
        m_validTargets = new List<GameObject>(from cow in FindObjectsOfType<Cow>() select cow.gameObject);        
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_validTargets.Add(FindObjectOfType<CharacterMotor>().gameObject);
        m_target = GetNearestTarget();
        m_NavMeshAgent.speed = 10.0f;
    }

    protected float counter = 0.0f;
    protected override void Update()
    {
        base.Update();
        counter += Time.deltaTime;
        if(counter >= m_targetFindTimer)
        {
            counter -= m_targetFindTimer;
            m_target = GetNearestTarget();
        }
        ProcessMove();
        ProcessAttack();
    }


    virtual protected void ProcessMove()
    {        
        if(m_target != null)
        {            
            Vector3 aimDirection = m_target.transform.position - transform.position;
            aimDirection.Set(aimDirection.x, 0f, aimDirection.z);
            transform.forward = aimDirection;

            if(Vector3.Distance(transform.position, m_target.transform.position) > m_minRange)
            {
                m_NavMeshAgent.SetDestination(m_target.transform.position);// Auslagern in Externe Funktion (mit Parameter übergeben       
            }
            //else if(m_NavMeshAgent.)
            //{

            //}
        }
    }
    abstract protected void ProcessAttack();

    // SendDamage
   /* void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hallo bin da");
       if (Attack)
        {
            if (other.gameObject.tag == PlayerTag || other.gameObject.tag == CowTag)
            {
                other.gameObject.SendMessage("TakeDamage", m_Damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (Attack)
        {
            Debug.Log("Ich stehe in dir");
            if (other.gameObject.tag == PlayerTag || other.gameObject.tag == CowTag)
            {
                other.gameObject.SendMessage("TakeDamage", m_Damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }*/




     
   
    
}

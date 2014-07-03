using UnityEngine;
using System.Collections;

abstract public class Enemyclass : CharacterMechanics
{
    public GameObject m_Cow;
    public GameObject m_Target;
    public float m_minRange;
    public float m_AttackSpeed = 2;
    public string CowTag = "Cow";
    public string PlayerTag = "Player";

    protected NavMeshAgent m_NavMeshAgent;
    protected float m_maxTimer = 2f;

    private bool isTargetCow = false;
    private float m_MaxRangeCow = 20f;
    


    protected virtual void Awake()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    protected override void Update()
    {
        base.Update();
        ProcessMove();
        
    }

    virtual protected void ProcessMove()
    {

        float distencePlayer = Vector3.Distance(m_Target.transform.position, transform.position);
        float distenceCow = Vector3.Distance(m_Cow.transform.position, transform.position);
        if (distenceCow < m_MaxRangeCow && distenceCow > m_minRange)
        {
            m_NavMeshAgent.speed = 10f;
            isTargetCow = true;
            transform.forward = m_Cow.transform.position - transform.position;// Auslagern in Externe Funktion (mit Parameter übergeben
            m_NavMeshAgent.SetDestination(m_Cow.transform.position); // Auslagern in Externe Funktion (mit Parameter übergeben
            ProcessAttack();
            

        }
        else if(distencePlayer > m_minRange && !isTargetCow)
        {
            m_NavMeshAgent.speed = 10f;
            transform.forward = m_Target.transform.position - transform.position; // Auslagern in Externe Funktion (mit Parameter übergeben
            m_NavMeshAgent.SetDestination(m_Target.transform.position);// Auslagern in Externe Funktion (mit Parameter übergeben
            ProcessAttack();
        }
        else
        {
            if (!isTargetCow)
            {
                transform.forward = m_Target.transform.position - transform.position; // Auslagern in Externe Funktion (mit Parameter übergeben
            }
           // m_NavMeshAgent.Stop();
            ProcessAttack();
            m_NavMeshAgent.speed = 0;
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

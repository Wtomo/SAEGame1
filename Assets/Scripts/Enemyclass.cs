using UnityEngine;
using System.Collections;

public class Enemyclass : CharacterHPMechanics
{
    public GameObject m_Cow;
    public GameObject m_Target;
    public float m_Health = 100.0f;
    public float m_Damage = 0f;
    


    protected NavMeshAgent m_NavMeshAgent;
    protected float m_distenceCow;
    protected float m_distencePlayer;
    

    void Start()
    {
        
    }

    protected virtual void Awake()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        ProcessMove();
        ProcessAttack();
        
    }

    virtual protected void ProcessMove()
    {
        m_distenceCow = Vector3.Distance(m_Cow.transform.position, transform.position);
        if (m_distenceCow < 20)
        {
            m_NavMeshAgent.SetDestination(m_Cow.transform.position);
        }
        else
        {
            m_NavMeshAgent.SetDestination(m_Target.transform.position);
        }

        // Ab Hier testen :P
        m_distencePlayer = Vector3.Distance(m_Target.transform.position, transform.position);
        if (tag == "Melee")
        {
            if (m_distenceCow < 2 || m_distencePlayer < 2)
            {

                Debug.Log("Hey");
                m_NavMeshAgent.Stop();
                ProcessAttack();

            }

        }
        if (tag == "Fern")
        {
            if (m_distenceCow < 7 || m_distencePlayer < 7)
            {
                Debug.Log("Funktioniert es?");
                m_NavMeshAgent.Stop();
                ProcessAttack();
            }
        }


    }
    virtual protected void ProcessAttack() // Soll abstract sein
    {

    }
}

using UnityEngine;
using System.Collections;

public class Enemyclass : CharacterHPMechanics
{
    public GameObject m_Cow;
    public GameObject m_Target;
    public float m_Health = 100.0f;
    public float m_Damage = 0f;
    public float m_minRange;
    


    protected NavMeshAgent m_NavMeshAgent;
    private bool isTargetCow = false;

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
        float distencePlayer = Vector3.Distance(m_Target.transform.position, transform.position);
        float distenceCow = Vector3.Distance(m_Cow.transform.position, transform.position);
        if (distenceCow < 20 && distenceCow > 10)
        {
            isTargetCow = true;
            Debug.Log("kein STOPPPP");
            m_NavMeshAgent.SetDestination(m_Cow.transform.position);

        }
        else if(distencePlayer > 10 && !isTargetCow)
        {
                m_NavMeshAgent.SetDestination(m_Target.transform.position);  
                Debug.Log("Bin ich Hier");
        }
        else
        {
            m_NavMeshAgent.Stop();
            Debug.Log("STOPPPPPPPPPPPP");
        }

        /* Ab Hier testen :P
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
        }*/


    }
    virtual protected void ProcessAttack() // Soll abstract sein
    {

    }
}

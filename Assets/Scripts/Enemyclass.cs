using UnityEngine;
using System.Collections;

public class Enemyclass : MonoBehaviour 
{
    public GameObject m_Target;
    public float m_Health = 100.0f;
    private NavMeshAgent m_NavMeshAgent;
    
	void Start () 
    {
	
	}
	
	protected virtual void Awake ()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }
	void Update () 
    {
        m_NavMeshAgent.SetDestination(m_Target.transform.position);
	}

    void ProcessMove()
    {}

    void ProcessAttack()
    {}
}

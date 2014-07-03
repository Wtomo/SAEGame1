using UnityEngine;
using System.Collections;

public class RangeEnemy : Enemyclass 
{
    public GameObject m_BulletPrefab;
    public Transform m_CannonPoint;
    public float m_BulletSpeed = 5000f;
    
    

    protected override void ProcessMove()
    {
        m_minRange = 20f;
        base.ProcessMove();


    }

    protected override void ProcessAttack()
    {
        //float Target      
        if (m_AttackSpeed >= 0)
        {
            
            m_AttackSpeed -= Time.deltaTime;            
        }
        else if (m_AttackSpeed <= 0)
        {
            GameObject bullet = (GameObject)Instantiate(m_BulletPrefab, m_CannonPoint.position, transform.rotation);
            bullet.rigidbody.AddForce(transform.forward * m_BulletSpeed);
            m_AttackSpeed = m_maxTimer;
            
        }
        
    }
    

}

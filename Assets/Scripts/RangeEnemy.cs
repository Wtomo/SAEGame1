using UnityEngine;
using System.Collections;

public class RangeEnemy : Enemyclass 
{
    public GameObject m_BulletPrefab;
    public Transform m_CannonPoint;
    public float m_BulletSpeed = 5000f;

    protected override void Awake()
    {
        base.Awake();
        m_MaxHP = 75f;
        m_Damage = 5;
        m_Armor = 0f;
        m_AttackSpeed = 2f;
    }

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
            GameObject bullet = Instantiate(m_BulletPrefab, m_CannonPoint.position, transform.rotation) as GameObject;
            Bullet damage = bullet.GetComponent<Bullet>();
            damage.SetDamageEnemy(m_Damage);
            bullet.rigidbody.AddForce(transform.forward * m_BulletSpeed);
            m_AttackSpeed = m_maxTimer;
            
        }
        
    }
    

}

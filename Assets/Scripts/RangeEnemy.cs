using UnityEngine;
using System.Collections;

public class RangeEnemy : Enemyclass 
{
    public GameObject m_BulletPrefab;
    public Transform m_CannonPoint;
    public float m_BulletSpeed = 50f;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void ProcessMove()
    {
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
            Bullet bullet = ((GameObject)Instantiate(m_BulletPrefab, m_CannonPoint.position, transform.rotation)).GetComponent<Bullet>();
            bullet.SetDamage(m_Damage);
            bullet.SetBulletspeed(m_BulletSpeed);
            bullet.SetTarget(Bullet.BulletTarget.Player);
            m_AttackSpeed = m_maxTimer;            
        }        
    }
}

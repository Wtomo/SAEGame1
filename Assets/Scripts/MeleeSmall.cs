using UnityEngine;
using System.Collections;

public class MeleeSmall : Enemyclass
{
    
	// Use this for initialization

    protected override void ProcessMove()
    {
        m_minRange = 4f;   
        base.ProcessMove();
        

    }
    
    protected override void ProcessAttack()
    {
               
            if (m_AttackSpeed >= 0)
            {               
                m_AttackSpeed -= Time.deltaTime;
            }
            else if (m_AttackSpeed <= 0)
            {
                //damage
            }       
    }

}

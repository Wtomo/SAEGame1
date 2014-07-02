using UnityEngine;
using System.Collections;

public class MeleeSmall : Enemyclass
{
    
	// Use this for initialization

    protected override void ProcessMove()
    {
        m_minRange = 3f;   
        base.ProcessMove();
        

    }

    protected override void ProcessAttack()
    {
        if (m_Attackspeed >= 0)
        {
            m_Attackspeed -= Time.deltaTime;            
        }
        else if (m_Attackspeed <= 0)
        {
            // damage
        }
        
    }
}

using UnityEngine;
using System.Collections;

public class MeleeSmall : Enemyclass
{
    
	// Use this for initialization

    protected override void ProcessMove()
    {
        m_minRange = 10f;   
        base.ProcessMove();
        

    }

    protected override void ProcessAttack()
    {
        
    }
}

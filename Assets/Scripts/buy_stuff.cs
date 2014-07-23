using UnityEngine;
using System.Collections;

public class buy_stuff : MonoBehaviour
{
    private CharacterMechanics m_CharMech;
    private CharacterMotor m_CharMotor;
    public int _costHP;
    public int _costArmor;
    public int _costSpeed;
    public int _costDesert;
    public int _costAssault;
    public int _costLMG;
    public int _costShotgun;
    public int _costCow;
    public int _hpboost;
    public int _armorboost;
    public float _speedboost;
    public int _cowarmorboost;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	 /*void Awake () 
    {
        m_CharMech = FindObjectOfType<CharacterMechanics>();

        m_CharMotor = FindObjectOfType<CharacterMotor>();
        
	}

    public void BuyHP()
    {
        if (m_CharMech.CanBuy(_costHP))
        {
            m_CharMech.m_HP += _hpboost;

        }
    }
    public void BuyArmor()
    {
       if (m_CharMech.CanBuy(_costArmor))
        {
            m_CharMech.m_Armor += _armorboost;
        }
    }
    public void BuySpeed()
    {
        if (m_CharMech.CanBuy(_costSpeed))
        {
            m_CharMech.m_Speed+= _speedboost;

        }
    }   
    public void BuyDesert()
    {
       if (m_CharMech.CanBuy(_costDesert))
       {
        m_CharMotor.giveWeapon(CharacterMotor.WeaponType.DesertEagle);

       }
    }
    public void BuyAssault()
    {
        if (m_CharMech.CanBuy(_costAssault))
        {
            m_CharMotor.giveWeapon(CharacterMotor.WeaponType.AssaultRifle);

        }
    }
    public void BuyLMG()
    {
        if (m_CharMech.CanBuy(_costLMG))
        {
            m_CharMotor.giveWeapon(CharacterMotor.WeaponType.LMG);

        }
    }
    public void BuyShotgun()
    {
        if (m_CharMech.CanBuy(_costShotgun))
        {
            m_CharMotor.giveWeapon(CharacterMotor.WeaponType.Shotgun);

        }
    }
    public void BuyCowArmor()
    {
        if (m_CharMech.CanBuy(_costCow))
        {
            m_CharMech._cowarmor += _cowarmorboost;

        }
    }*/
}

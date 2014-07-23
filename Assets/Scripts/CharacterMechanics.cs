using UnityEngine;
using System.Collections;

public class CharacterMechanics : MonoBehaviour
{
    public float m_BaseSpeed;
    public float m_Speed;
    public float m_MaxHP; //Maximale HP der Einheit

    protected UITexture m_uiTexture = null;
    protected float m_uiTextureWidth;

    public float HP 
    {
        get 
        {
            return m_hp;
        }
        set
        {
            m_hp = value;
            
            if (m_uiTexture != null)
            {
                m_uiTexture.width = (int) (m_hp / m_MaxHP * m_uiTextureWidth);
            }
        }
    } //Aktuelle HP der Einheit
    protected float m_hp;

    public float m_RegHP; //HP5, s.h.: Menge an HP die alle 5 Sekunden generiert wird
    public float m_Armor; //Rüstung die die Einheit besitzt, wird direkt von dem eingehenden Schaden abgezogen (Keine Rüstungsdurchdringung)
    public int m_Damage;
    public bool m_IsAlive = true; //Gibt an ob die Einheit lebt oder nicht

    //Upgrade Levels für Horst
    public int m_HutLevel = 0;
    public int m_StiefelLevel = 0;
    public int m_WesteLevel = 0;

    protected bool Attack = false;
    private float timer = 0f; //Timer für HP5

    //Funktion für die Levelsteigerung des Hutes
    public void Hut()
    {
        switch (m_HutLevel)
        {
            case 0:
                return;
            case 1:
                m_MaxHP += 5f;
                return;
            case 2:
                m_MaxHP += 15f;
                return;
            case 3:
                m_MaxHP += 30f;
                return;
            case 4:
                m_MaxHP += 40f;
                return;
            case 5:
                m_MaxHP += 50f;
                return;
        }
    }

    //Funktion für die Levelsteigerung der Lederweste
    public void Weste()
    {
        switch (m_WesteLevel)
        {
            case 0:
                return;
            case 1:
                m_Armor = 1f;
                return;
            case 2:
                m_Armor = 2f;
                return;
            case 3:
                m_Armor = 3f;
                return;
            case 4:
                m_Armor = 4f;
                return;
            case 5:
                m_Armor = 5f;
                return;
        }
    }

    //Funktion für die Levelsteigerung der Stiefel
    public void Stiefel()
    {
        switch (m_StiefelLevel)
        {
            case 0:
                return;
            case 1:
                m_Speed = m_BaseSpeed * 1.05f;
                return;
            case 2:
                m_Speed = m_BaseSpeed * 1.10f;
                return;
            case 3:
                m_Speed = m_BaseSpeed * 1.15f;
                return;
            case 4:
                m_Speed = m_BaseSpeed * 1.20f;
                return;
            case 5:
                m_Speed = m_BaseSpeed * 1.25f;
                return;
        }
    }

    //Take Damage Funktion
    public void TakeDamage(int damage)
    {
        float trueDamage = damage - m_Armor; //Armor wird direkt vom Schaden abgezogen, true Damage ist der Wert der im Endeffekt von den HP abgezogen wird
        HP -= trueDamage;
        if (HP <= 0f) //Abfrage ob HP auf 0 gesunken sind
        {
            Debug.Log(HP);
            HP = 0f;
            m_IsAlive = false;
            FindObjectOfType<E_spawner>()._EnemyCounter--;
            if (gameObject.tag != "Player")
            {
                Destroy(gameObject);
            }
        }
        return;
    }

    // Use this for initialization
    protected virtual void Start()
    {
        //Setzt die aktuellen HP auf die Maximal-HP der Einheit hoch, wird nur beim Start aufgerufen
        HP = m_MaxHP;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Regelt die HP-Regeneration
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            HP += m_RegHP;
            timer = 0f;
            return;
        }

    }

}


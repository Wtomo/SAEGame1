using UnityEngine;
using System.Collections;

public class CharacterHPMechanics : MonoBehaviour 
{
    public float m_MaxHP; //Maximale HP der Einheit
    private float m_HP; //Aktuelle HP der Einheit
    public float m_RegHP; //HP5, s.h.: Menge an HP die alle 5 Sekunden generiert wird
    public float m_Armor; //Rüstung die die Einheit besitzt, wird direkt von dem eingehenden Schaden abgezogen (Keine Rüstungsdurchdringung)
    public bool m_IsAlive = true; //Gibt an ob die Einheit lebt oder nicht
    private float timer = 0f; //Timer für HP5

    //Take Damage Funktion
    public void TakeDamage(int damage)
    {
        float trueDamage = damage - m_Armor; //Armor wird direkt vom Schaden abgezogen, true Damage ist der Wert der im Endeffekt von den HP abgezogen wird
        m_HP -= trueDamage;
        if(m_HP <= 0f) //Abfrage ob HP auf 0 gesunken sind
        {
            m_HP = 0f;
            m_IsAlive = false;
        }
        return;
    }

	// Use this for initialization
	void Start () 
    {
        //Setzt die aktuellen HP auf die Maximal-HP der Einheit hoch, wird nur beim Start aufgerufen
        m_HP = m_MaxHP;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Regelt die HP-Regeneration
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            m_HP += m_RegHP;
            timer = 0f;
            return;
        }
        
	}
}

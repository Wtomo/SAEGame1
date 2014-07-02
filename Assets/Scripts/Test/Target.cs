using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public float m_MaxHP = 10f;
    // Autoproperty
    // public float CurrentHP { get; private set; }
    private float m_currentHP = 10f;

    public float CurrentHP
    {
        get
        {
            return m_currentHP;
        }

        set
        {
            if (value != m_currentHP)
            {
                m_currentHP = value;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        CurrentHP = m_MaxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
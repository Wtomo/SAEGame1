using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public bool m_PlayerBullet = true;

    private int m_damageEnemy = 5;
    private int m_damagePlayer = 15;

    private Vector3 m_Origin;

    // Use this for initialization
    void Start()
    {
        m_Origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
    }

    void CheckForPlayer()
    {
        Vector3 dir = (m_Origin - transform.position).normalized;
        float distance = Vector3.Distance(m_Origin, transform.position);

        RaycastHit hit;
        Ray ray = new Ray(transform.position, dir);

        if (m_PlayerBullet)
        {
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy bekommt schaden");
                RangeEnemy enemy = hit.transform.gameObject.GetComponent<RangeEnemy>();
                enemy.TakeDamage(m_damagePlayer);
                Destroy(gameObject);
            }
        }
        else
        {
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Player")
            {
                Debug.Log("ICh bekommt schaden");
                CharacterMotor CharMotor = hit.transform.gameObject.GetComponent<CharacterMotor>();
                CharMotor.TakeDamage(m_damageEnemy);
                Destroy(gameObject);
            }
        }
    }

    public void SetDamageEnemy(int _damage)
    {
        m_damageEnemy = _damage;
    }
    public void SetDamagePlayer(int _damage)
    {
        m_damagePlayer = _damage;
    }
        
}

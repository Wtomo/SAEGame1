using UnityEngine;
using System.Collections;

public class BulletEnemy : MonoBehaviour
{
    private int m_damage = 5;

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

        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy bekommt schaden");
            RangeEnemy enemy = hit.transform.gameObject.GetComponent<RangeEnemy>();
            enemy.TakeDamage(m_damage);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int _damage)
    {
        m_damage = _damage;
    }

}
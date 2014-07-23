using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public enum BulletTarget
    {
        Player,
        Enemy
    }

    private BulletTarget m_bulletTarget;
    private int m_damage;
    private float m_bulletSpeed = 20.0f;
    private Vector3 m_lastPos;

    // Use this for initialization
    void Start()
    {
        m_lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * m_bulletSpeed * Time.deltaTime;

        Vector3 rayDir = -transform.forward;
        float distance = Vector3.Distance(m_lastPos, transform.position);

        RaycastHit hit;
        Ray ray = new Ray(transform.position, rayDir);

        if(Physics.Raycast(ray, out hit, distance))
        {
            if(hit.transform.tag != "Player" && hit.transform.tag != "Enemy" && hit.transform.tag != "Cow")
            { Destroy(gameObject); }
            else if(m_bulletTarget == BulletTarget.Player && (hit.transform.tag == "Player" || hit.transform.tag == "Cow")
            || m_bulletTarget == BulletTarget.Enemy && hit.transform.tag == "Enemy")
            {                
                CharacterMechanics target = hit.transform.GetComponent<CharacterMechanics>();
                Debug.Log(hit.transform.tag + " bekommt schaden (noch " + target.HP + " HP)");
                target.TakeDamage(m_damage);                
                Destroy(gameObject);
            }            
        }
        m_lastPos = transform.position;
    }

    public void SetDamage(int _damage)
    {
        m_damage = _damage;
    }

    public void SetTarget(BulletTarget bulletTarget)
    {
        m_bulletTarget = bulletTarget;
    }

    public void SetBulletspeed(float bulletSpeed)
    {
        m_bulletSpeed = bulletSpeed;
    }
}

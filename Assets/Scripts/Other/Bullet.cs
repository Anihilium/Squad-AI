using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Duration = 2f;
    public int damage = 2;

    void Start()
    {
        Destroy(gameObject, Duration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damagedAgent = collision.gameObject.GetComponentInParent<IDamageable>();
        if (damagedAgent == null)
            damagedAgent = collision.gameObject.GetComponent<IDamageable>();
        damagedAgent?.AddDamage(damage);

        Destroy(gameObject);
    }
}

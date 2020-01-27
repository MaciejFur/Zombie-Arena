
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem bloodSplash;
    public void TakeDamage (float amount)
    {
        health -= amount;
        bloodSplash.Play();
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die ()
    {
        Destroy(gameObject);
    }
}

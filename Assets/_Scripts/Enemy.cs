
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int totalHealth = 500;
    public int health;

    public ParticleSystem bloodSplash;
    //public ParticleSystem deathScene;

    private int dmgTaken;
    private float critChance;

    public AudioSource chickenDead;
    public Transform stage;

    //Grenade damage received
    public bool isHit = false;

    private void Awake()
    {
        health = totalHealth;
    }
    private void Update()
    {
        if (isHit == true)
        {
            
            dmgTaken = Random.Range(150, 300);
            TakeDamage(dmgTaken);
            isHit = false;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.CompareTag("Weapon"))
        {
            
            dmgTaken = Random.Range(8, 12);
            critChance = Random.Range(1f, 100f);
            if (critChance < 6f)
                TakeDamage(dmgTaken * 2);
            else
                TakeDamage(dmgTaken);
        }
        
    }
    public void TakeDamage(int dmgTaken)
    {
        health -= dmgTaken;
        bloodSplash.Play();
        //Debug.Log((dmgTaken < 12 ? " " : "CRITICAL ") + dmgTaken + " OF " + health);
        if (health <= 0f)
        {
            chickenDead.pitch = Random.Range(.7f, 3f);
            chickenDead.Play(0);
            stage.GetComponent<AIMovement>().isRunning = false;
            stage.GetComponent<AIMovement>().isWalking = false;
            Die();
        }
    }
    void Die()
    {
        
        Destroy(gameObject,0.4f);
    }

}

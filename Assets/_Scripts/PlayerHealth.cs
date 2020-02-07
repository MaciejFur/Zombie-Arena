using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text playerHp;
    public static int playerHealth;
    public AudioSource pain;
    public Collider col;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        playerHp.text = playerHealth.ToString();
        if (playerHealth < 1)
        {
            PlayerDead();
        }
    }
    void PlayerDead()
    {
        Time.timeScale = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            playerHealth -= 5;
            
            pain.pitch = Random.Range(.8f, 5f);
            pain.Play(0);
        }
    }
}

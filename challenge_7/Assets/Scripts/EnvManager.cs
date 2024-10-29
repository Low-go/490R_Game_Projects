using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvManager : MonoBehaviour
{
    public static EnvManager Instance;
    private int maxHealth = 100;
    private int health;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void setHealth(int damage)
    {
        health += damage;
        if (health <= 0) { SceneManager.LoadScene(0); }
        else if (health > 100) { health = 100; }
    }

    public int getHealth()
    {
        return health;
    }

}

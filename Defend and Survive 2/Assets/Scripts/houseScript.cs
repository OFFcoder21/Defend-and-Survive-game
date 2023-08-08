using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class houseScript : MonoBehaviour
{
    public float health = 100f;
    //[SerializeField] int maxHealth = 100;

    public HealthBar healthbar;
    public GameObject player;
    

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.SetHealth(health);
        if (health < 0) health = 0;
     //   DeathMenuFunc();
        Invoke("DeathMenuFunc", 2);
    }

    public void DeathMenuFunc()
    {
        if (health <= 0)
        {
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
            StarterAssets.StarterAssetsInputs starterAssetsInputs = player.GetComponent<StarterAssets.StarterAssetsInputs>();
            starterAssetsInputs.SetCursorState(false);
#endif
            SceneManager.LoadScene(4);
            Debug.Log("Finished");
        }
    }
}

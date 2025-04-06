using UnityEngine;

public class Enemyhealth : MonoBehaviour
{

    public float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Debug.Log("enemy dead");
        }
        
    }
}

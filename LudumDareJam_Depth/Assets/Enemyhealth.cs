using UnityEngine;
public class Enemyhealth : MonoBehaviour
{
    public float health;
    private Animator anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the animator component
        anim = GetComponent<Animator>();
        if (anim == null) {
            Debug.LogWarning("No Animator component found on this enemy!");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Debug.Log("enemy dead");
            if (anim != null) {
                anim.SetBool("isDead", true);
            }
        }
    }
}
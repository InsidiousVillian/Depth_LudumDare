using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
            //when player collides - player position will be set to respawn position
           player.transform.position = respawnPoint.position;
        }
    }
}

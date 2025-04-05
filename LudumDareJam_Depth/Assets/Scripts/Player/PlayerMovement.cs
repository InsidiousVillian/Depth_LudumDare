using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] float speed = 5f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D body;
    

    // Update is called once per frame
    void Update()
    {
        //returns value of -1 or 1 depending on direction we are moving
        horizontal = Input.GetAxisRaw("Horizontal");
        //call flip method
        Flip();

    }
    private void FixedUpdate(){
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
    }
    private void Flip(){
        /*chekc if player is movinh left or right or is facing in both directions
        if either conditiuon is true then flips character object*/
        if (isFacingRight && horizontal < 0f || isFacingRight && horizontal > 0f){
            //toggles boolean to cinsider new direction
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

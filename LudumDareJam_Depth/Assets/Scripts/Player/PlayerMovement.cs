using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] float speed = 5f;
    private bool isFacingRight = true;

    public float jumpForce = 5f;

    [SerializeField] private Rigidbody2D body;

    public Vector2 boxSize;

    public float castDistance;

    public LayerMask groundLayer;
    

    // Update is called once per frame
    void Update()
    {
        //returns value of -1 or 1 depending on direction we are moving
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            body.AddForce(new Vector2(body.velocity.x, jumpForce * 20));
        }
        else{
            Debug.Log("is Grounded constant");
        }

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

    public bool isGrounded(){
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance,groundLayer)){
            return true;
        }
        else{
            return false;
        }
    }
    void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

}

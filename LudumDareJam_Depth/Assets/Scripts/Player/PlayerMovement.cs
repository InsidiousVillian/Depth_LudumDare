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

    [SerializeField] private Animator animator;

    public GameObject attackPoint;
    public float radius;

    public LayerMask enemies;

    //public float damage = 20;
    
    

    
    

    // Update is called once per frame
    void Update()
    {
        //returns value of -1 or 1 depending on direction we are moving
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            body.AddForce(new Vector2(body.linearVelocity.x, jumpForce * 20));
            animator.SetBool("isJumping", true);
        }
        else{
           
            animator.SetBool("isJumping", false);
        }

        if(horizontal != 0){
            animator.SetBool("isRunning", true);
        }
        else{
            animator.SetBool("isRunning", false);
        }

        if(Input.GetMouseButtonDown(0)){
            animator.SetBool("isAttacking", true);
        }


        //call flip method
        Flip();

    }
    private void FixedUpdate(){
        body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);
    }
    private void Flip(){
        // Flip only when direction doesn't match facing
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f)){
        // Toggle the boolean
        isFacingRight = !isFacingRight;
        
        // Flip the sprite
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

     void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(" Hit the obstacle!");
        }
    }
    
    void Die(){
        Destroy(this.gameObject);
    }

    public void endAttack(){
        animator.SetBool("isAttacking", false);
    }

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach(Collider2D enemyGameobject in enemy){
            Debug.Log("enemy hit");
            enemyGameobject.GetComponent<Enemyhealth>().health -= 10;
        }               
    }

    private void OnDrawGizmos(){
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

}
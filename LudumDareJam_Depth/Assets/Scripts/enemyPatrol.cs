using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D body;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    private bool isFacingRight = true;

    // Start is called once before the first execution of Update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform; // Start at pointB
        anim.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction to the current point
        Vector2 direction = currentPoint.position - transform.position;

        // Move the enemy towards the current point
        body.velocity = new Vector2(direction.x * speed, body.velocity.y);

        // If close to the current point, switch to the next one
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            if (currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform; // Switch to pointA
            }
            else
            {
                currentPoint = pointB.transform; // Switch to pointB
            }
        }

        // Call Flip() to change the sprite direction
        Flip(direction.x);
    }

    private void Flip(float horizontal)
    {
        // Flip only when direction doesn't match facing
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            // Toggle the boolean
            isFacingRight = !isFacingRight;

            // Flip the sprite by changing the localScale on the X-axis
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
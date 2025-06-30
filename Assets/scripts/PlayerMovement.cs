using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    [SerializeField] private float speed = 5f; 
    private Rigidbody2D body;
    private Animator walk;
    private bool grounded;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        walk = GetComponent<Animator>();


    }
    private void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);
        if(HorizontalInput > 0.1f)
        {
           transform.localScale = new Vector3(0.148339152f, 0.165352643f, 0.0849399716f);
        }
        else if (HorizontalInput < -0.1f)
        {
            transform.localScale = new  Vector3(-0.148339152f, 0.165352643f, 0.0849399716f);
        }

        if (Input.GetKey(KeyCode.Space) && grounded )
        {
            jump();
        }
        walk.SetBool("walk", HorizontalInput != 0);
    }
    private void jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed*2);
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}

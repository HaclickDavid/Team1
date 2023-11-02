using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] float movespeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    public HeartCount myHeartCount;
    
    public GameObject heart;

    // Start is called before the first frame update
    private void Start()
    {
        myHeartCount.finishHeartNow = 0;
        myHeartCount.heartThisStage = 0;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        myHeartCount.stageNow = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationUpdate();
    }       

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Trigger")){
            Debug.Log("Enter");
            ShootHeart(other.gameObject.transform.position);
        }
    }
    
    public void ShootHeart(Vector3 t){
        if(myHeartCount.allHeartNow>0){
            myHeartCount.allHeartNow --;
            Debug.Log("Shoot");
            var g = Instantiate(heart);
            g.transform.position = this.gameObject.transform.position;
            g.GetComponent<heartTrigger>().HeartMove(t);

        }
    }
}

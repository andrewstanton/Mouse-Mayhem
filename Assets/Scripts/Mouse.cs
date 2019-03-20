using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{
    public float jumpSpeed = 10f;

    public Rigidbody2D body2D;

    
    // Jumping Params
    public bool isJumping = false;
    // Number Of Jumps
    public int numOfJumps = 2;
    // Delay In Between Jumps
    public float jumpDelay = .2f;
    
    // Marks Last Jump Time
    private float lastJumpTime = 0;
    private int jumpsRemaining = 0;


    protected virtual void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Delay Jump Movement
    public void DelayJump(double delayAmount) {
        Debug.Log(this.jumpsRemaining);
        // If Jumping
        if (!this.isJumping)
        {
            this.isJumping = true;
            this.jumpsRemaining = numOfJumps - 1;
        }
        // If Delay Gone And Number Of Jumps Avaiable
        else if (this.jumpsRemaining > 0 && (Time.time - lastJumpTime > jumpDelay))
        {
            this.jumpsRemaining = numOfJumps - 1;
        }
        // Else Not
        else {
            return;
        }

        // Prevent Jumping By Setting This To True
        this.lastJumpTime = Time.time;
        StartCoroutine(Jump(delayAmount));
    }

    // Jump
    IEnumerator Jump(double delayAmount) {
        yield return new WaitForSeconds((float)delayAmount);

        var vel = body2D.velocity;
        body2D.velocity = new Vector2(vel.x, jumpSpeed);
    }
}

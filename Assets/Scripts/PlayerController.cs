using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
    private float moveSpeed00;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestone00;
    private float speedMilestoneCount;
    private float speedMilestoneCount00;
    
	public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;
    private bool canDoublejump;


	public Rigidbody2D myRigidbody;
	public bool grounded;
	public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    public popupText popupText;
    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource spikeSound;

	//private Collider2D myCollider;
	
    public GameManager theGameManager;

    private CameraController thecam;

    public GameObject[] hp;
    public int damage;
    
    public Transform lastGround;
    public AudioSource relaxMusic;
   

    
	
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		//myCollider = GetComponent<Collider2D>();
		
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeed00 = moveSpeed;
        speedMilestoneCount00 = speedMilestoneCount;
        speedIncreaseMilestone00 = speedIncreaseMilestone;
        stoppedJumping = true;
        canDoublejump = true;
        thecam = FindObjectOfType<CameraController>();
        damage = hp.Length ;



		
	}


   
	// Update is called once per frame
	void Update () {
		
		//grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }
		myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);
		
		if(Input.GetKeyDown(KeyCode.Space)  || Input.GetMouseButtonDown(0) )
		 {
            
			if(grounded)
			{
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
				jumpSound.volume = Random.Range(0.05f, 0.15f);
				jumpSound.pitch = Random.Range(0.40f, 0.60f);
                jumpSound.Play();
                thecam.zoomIN();
                
                
			}

            if (!grounded && canDoublejump)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
                jumpTimeCounter = jumpTime;
                canDoublejump = false;
				jumpSound.volume = Random.Range(0.05f, 0.15f);
                jumpSound.pitch = Random.Range(0.40f, 0.90f);
                jumpSound.Play();
                thecam.zoomIN();
                
            }

           
		 }
		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,jumpForce);
                jumpTimeCounter -= Time.deltaTime;
                thecam.zoomIN();
               
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            thecam.ZoomOut();

            
        }
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoublejump = true;
            thecam.ZoomOut();
        }
		
       ;
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spikes" || other.gameObject.tag == "killbox")
        {
           

            if (damage > 0)
            {
                hp[damage - 1].gameObject.SetActive(false);
                spikeSound.pitch = Random.Range(0.1f, 0.30f);
                spikeSound.Play();
                damage--;
            }
            if (other.gameObject.tag == "killbox" && damage > 0)
            {
                theGameManager.fallen();
            }

               
            
            if (damage == 0)
            {
                
                relaxMusic.Stop();
                PlayerDead();
            }
        }
        if (other.gameObject.name.Contains("Platform"))
        {
            lastGround = other.gameObject.transform;
        }
    }
    public void PlayerDead()
    {
        deathSound.pitch = Random.Range(0.52f, 0.85f);
        deathSound.Play();
      
        theGameManager.RestartGame();
        if (theGameManager.powerupReset)
        {
            
            moveSpeed = moveSpeed00;
            speedMilestoneCount = speedMilestoneCount00;
            speedIncreaseMilestone = speedIncreaseMilestone00;
        }
        }
    

}

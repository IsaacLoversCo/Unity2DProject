using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

	public float maxSpeed = 6f;
	bool facingRight = true;

	Animator anim;

	private Rigidbody2D rigi;
	public TextMesh text_tap;
	//Jump variables
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public float doubleJumpForce = 400f;

	public bool firstJump;
	public static bool isDebut = true;


	void Awake()
	{
		rigi = GetComponent<Rigidbody2D>();
		text_tap = GameObject.Find ("FailText").GetComponent<TextMesh> ();
		

	}

	void Start()
	{
		anim = GetComponent<Animator> ();
		if(isDebut)
		 text_tap.gameObject.SetActive(false);

	}
	void Update()
	{
		if (grounded)
			firstJump = true;
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool("Ground", false);
			rigi.velocity.y.Equals(0);
			rigi.AddForce(new Vector2(0, jumpForce));
			firstJump = true;
		}
		else if (!grounded && Input.GetKeyDown (KeyCode.Space) && firstJump) {
			anim.SetBool("Ground", false);
			rigi.velocity.y.Equals(0);
			rigi.AddForce(new Vector2(0, doubleJumpForce));
			firstJump = false;
		}
		if (rigi.position.x < -10) {
			rigi.transform.position.x.Equals (-5.83);
			rigi.transform.position.y.Equals (-2.49);
		}
	}

	void FixedUpdate()
	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rigi.velocity.y);

		if (!grounded)
			return;

		float move = Input.GetAxis("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rigi.velocity = new Vector2 (move * maxSpeed, rigi.velocity.y);
	if (move > 0 && facingRight)
			Flip ();
	else if (move < 0 && !facingRight)
			Flip ();

		isDebut = false;

	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		text_tap.gameObject.SetActive(false);

	}

}
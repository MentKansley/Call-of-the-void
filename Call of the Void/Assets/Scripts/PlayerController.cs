using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Variables
	public Rigidbody rb;

	public float Speed = 7.0f;
	public float jumpForce = 5.0f;

	bool jumpKey = false;

	// Used for ground detection
	public CapsuleCollider col;
	public LayerMask groundLayers;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		col = GetComponent<CapsuleCollider>();
	}

	void Update()
	{
		float Movement = Input.GetAxis("Horizontal") * Speed;
		Movement *= Time.deltaTime;

		transform.Translate(Movement, 0, 0);

		if (Input.GetButtonDown("Jump"))
		{
			jumpKey = true;
		}

	}

	void FixedUpdate()
	{
		if (jumpKey == true && isGrounded())
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			jumpKey = false;
		}
	}

	private bool isGrounded()
	{
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
	}

}

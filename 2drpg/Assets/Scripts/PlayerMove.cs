using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

    private Animator animator;
    private Vector2 lastmove;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        Move();

    }

    void Move()
    {

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed, 0f, 0f));
            lastmove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        } else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed, 0f));
            lastmove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animator.SetFloat("LastMoveX", lastmove.x);
        animator.SetFloat("LastMoveY", lastmove.y);
        animator.SetBool("isMoving", Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

    private Animator animator;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.SetInteger("direction", 1);
    }
	
	// Update is called once per frame
	void Update () {

        Move(GetDirection());

    }

    Vector3 GetDirection()
    {
        Vector3 dir = new Vector3();

        if (Input.GetKey(KeyCode.A))
        {
            dir = Vector3.left;
            animator.SetInteger("direction", 4);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir = Vector3.right;
            animator.SetInteger("direction", 2);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            dir = Vector3.up;
            animator.SetInteger("direction", 3);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir = Vector3.down;
            animator.SetInteger("direction", 1);
        }

        return dir;
    }


    void Move(Vector3 dir)
    {
        transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);
    }



}

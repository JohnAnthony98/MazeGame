using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Vector3[] movementVectors;

    private GameObject movementChecker;

    private float timeMoveStart;
    private float move_u;
    private float walkSpeed;
    bool moving;

    protected float lookSens;


    private void Awake()
    {
        walkSpeed = 0.05f;
        moving = false;

        lookSens = 2;

        movementChecker = Instantiate(Resources.Load("Prefabs/MoveChecker")) as GameObject;

        movementVectors = new Vector3[2];
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            Move();
        }
        else
        {
            ControlMovement();
        }
        Look();
    }

    private void ControlMovement()
    {
        float theta = -1;
        bool gotInput = false;
        if (Input.GetKey("w"))
        {
            if (Input.GetKey("a"))
            {
                gotInput = true;
                theta = this.transform.eulerAngles.y - 45;
            }
            else if (Input.GetKey("d"))
            {
                gotInput = true;
                theta = this.transform.eulerAngles.y + 45;
            }
            else
            {
                gotInput = true;
                theta = this.transform.eulerAngles.y;
            }
        }
        else if (Input.GetKey("s"))
        {
            if (Input.GetKey("a"))
            {
                gotInput = true;
                theta = this.transform.eulerAngles.y - 135;
            }
            else if (Input.GetKey("d"))
            {
                gotInput = true;
                theta = this.transform.eulerAngles.y + 135;
            }
            else
            {
                gotInput = true;
                theta = this.transform.eulerAngles.y - 180;
            }
        }
        else if (Input.GetKey("a"))
        {
            gotInput = true;
            theta = this.transform.eulerAngles.y - 90;
        }
        else if (Input.GetKey("d"))
        {
            gotInput = true;
            theta = this.transform.eulerAngles.y + 90;
        }

        if (gotInput)
        {
            movementVectors[0] = this.transform.position;

            movementVectors[1].x += Mathf.Sin(Mathf.Deg2Rad * theta) * 0.25f;
            movementVectors[1].y = 2;
            movementVectors[1].z += Mathf.Cos(Mathf.Deg2Rad * theta) * 0.25f;

            timeMoveStart = Time.time;

            movementChecker.transform.position = movementVectors[1];
            movementChecker.transform.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * theta) * 0.25f, 0, Mathf.Cos(Mathf.Deg2Rad * theta) * 0.25f);
            if (movementChecker.GetComponent<MoveChecker>().IsGoodMove())
            {
                moving = true;
            }
            else
            {
                moving = false;
                movementVectors[1] = this.transform.position;
            }
        }
    }

    private void Move()
    {
        move_u = (Time.time - timeMoveStart) / walkSpeed;
        if (move_u >= 1)
        {
            move_u = 1;
            moving = false;

            //get rid of rounding errors
            transform.position = movementVectors[1];
            return;
        }

        Vector3 p01;
        p01 = (1 - move_u) * movementVectors[0] + move_u * movementVectors[1];

        this.transform.position = p01;
    }

    private void Look()
    {
        float dVert = Input.GetAxis("Vertical");
        float dHorz = Input.GetAxis("Horizontal");

        this.transform.eulerAngles += new Vector3(-dVert * Time.deltaTime * lookSens, dHorz * Time.deltaTime * lookSens, 0);
    }
}

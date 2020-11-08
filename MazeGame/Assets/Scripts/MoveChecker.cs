using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChecker : MonoBehaviour
{
    public bool goodMove;

    private void Awake()
    {
        goodMove = true;
    }

    public bool IsGoodMove()
    {
        return goodMove;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            //Debug.Log("Enter Wall");
            goodMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            //Debug.Log("exit Wall");
            goodMove = true;
        }
    }
}

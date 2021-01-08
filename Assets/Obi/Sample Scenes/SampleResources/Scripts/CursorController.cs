using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class CursorController : MonoBehaviour {

	ObiRopeCursor cursor;
	ObiRope rope;
	public float minLength = 0.1f;
    public float maxLength = 1f;
    public float ropeSpeed;

	// Use this for initialization
	void Start () {
		cursor = GetComponentInChildren<ObiRopeCursor>();
		rope = cursor.GetComponent<ObiRope>();
        PlayerAndJoystickController.Instance.RopeSize += RopeSizeController;
	}

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    if (rope.RestLength > minLength)
        //        cursor.ChangeLength(rope.RestLength - 1f * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    if (rope.RestLength < maxLength)
        //        cursor.ChangeLength(rope.RestLength + 1f * Time.deltaTime);
        //}

    }

    //Controls the length of rope, it get it's orders from the Action<bool> RopeSize
    public void RopeSizeController(bool direction)
    {
        if (direction)
        {
            print("Front");
            if (rope.RestLength > minLength)
                cursor.ChangeLength(rope.RestLength - 1f * ropeSpeed * Time.deltaTime);
        }
        else
        {
            print("Back");
            if (rope.RestLength < maxLength)
                cursor.ChangeLength(rope.RestLength + 1f * Time.deltaTime * ropeSpeed);
        }
    }
}

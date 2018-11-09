using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float move_sp = 0.09f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.0f, 5.2f), Mathf.Clamp(transform.position.y, -4, 5), Mathf.Clamp(transform.position.z, 0, 0));
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(move_sp, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-move_sp, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, move_sp, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -move_sp, 0);
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModule : SampleScript
{
    public float x1;
    public float y1;
    public float z1;

    public float speed;

    public bool Done;

    [ContextMenu("Переместить")]
    public override void Use()
    {
        Done = true;
    }

    private void Move()
    {
        Vector3 direction = new Vector3(x1, y1, z1) - transform.position;

        if (direction.magnitude > 0.3f)
        {
            transform.forward = direction;
            transform.position += direction.normalized * Time.deltaTime * speed;
        }

        else
        {
            Done = false;
        }
    }

    private void Update()
    {
        if (Done == true)
        {
            Move();
        }
    }
    /*private void Start()
    {
        Application.targetFrameRate = 60;
    }*/

}

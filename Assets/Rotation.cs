using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour //прописать родительский SampleScript
{

    [SerializeField]
    private float cx = 1;

    [SerializeField]
    private float cy = 1;

    [SerializeField]
    private float cz = 1;

    [SerializeField]
    private float speed = 1;

    private float t;

    private Quaternion startRotation;

    private Quaternion targetRotation;

    private void Awake()
    {
        t = -1;
    }
    // Update is called once per frame
    private void Update()
    {
        Go();
    }

    private void Go()
    {
        if (t >= 0)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            if (t > 1)
            {
                t = -1;
            }
        }
    }

    [ContextMenu("Вращаемся")]
    public /*override*/ void Use()
    {
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(new Vector3(cx, cy, cz));
        t = 0;
    }


    /*[ContextMenu("Stop")]
    public void Stop()
    {
        StopAllCoroutines();

    }
    private IEnumerator Inf()
    {
            float t = 0;
            while (t == 0)
            {
                transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(cx, cy, cz) * speed * Time.deltaTime);
                yield return null;
            }
    }*/
}

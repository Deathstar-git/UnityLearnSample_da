using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_script : SampleScript
{
    [SerializeField]
    Transform transformTarget;

    Vector3 targetScaleVector = new Vector3(0.2f, 0.2f, 0.2f);
    float animationSpeed = 0.8f;

    List<Transform> childList = new List<Transform>();

    [ContextMenu("Запуск")]
    public override void Use()
    {
        StartCoroutine(deleteChildsCoroutine(childList));
    }

    IEnumerator deleteChildsCoroutine(List<Transform> childList)
    {
        foreach (var child in childList)
        {
            Vector3 start = child.lossyScale;
            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime * animationSpeed;
                child.localScale = Vector3.Lerp(start, targetScaleVector, t);
            }
            child.localScale = targetScaleVector;
            yield return new WaitForSeconds(0.05f);
        }

        foreach (var child in childList)
        {
            Destroy(child.gameObject);
        }

        yield break;
    }

    void Start()
    {
        foreach (Transform child in transformTarget)
        {
            childList.Add(child);
        }
    }
}

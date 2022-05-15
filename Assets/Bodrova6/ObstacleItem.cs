using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [SerializeField]
    private float currentValue = 1;

    public UnityEvent onDestroyObstacle;

    private void Start()
    {
        onDestroyObstacle.AddListener(() => Destroy(transform.gameObject));
    }
    public void GetDamage(float value)
    {
        if (currentValue > 0)
        {
            float newValue = 1;
            currentValue -= value;
            newValue -= currentValue;
            transform.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, newValue);
        }
        else
        {
            currentValue = 0;
            onDestroyObstacle?.Invoke();
        }
    }
}


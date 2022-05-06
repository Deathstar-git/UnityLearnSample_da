using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : SampleScript
{
    [SerializeField]
    private GameObject prefab; //Сначала создать объект. Потом повесить на него скрпт. сюда перетащить объект который мы создали и появится он справа в окне инспектор
    [SerializeField]
    [Range(0, 100)] 
    private int repeat; //сколько раз копировать объект

    [SerializeField]
    private float distance; //шаг он же расстояние

    private int count = 0; //количество копий

    private bool isActive = false; // для запуска и не совсем правильно

    public override void Use()
    {
        isActive = true; //просто активирует 
    }

    private void Update()
    {
        if (isActive)
        {
            if (count < repeat)
            {
                Instantiate(prefab, gameObject.transform.position + new Vector3(0, distance, 0) * (count + 1), Quaternion.identity);
                count++; //Instantiate это метод для создния копий объекта. Первый параметр в нём префаб то что нужно копировать(Объект). Потом его позиция то есть место и третий пармет его поворот (угол)
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : SampleScript
{
    [SerializeField]
    private GameObject prefab; //������� ������� ������. ����� �������� �� ���� �����. ���� ���������� ������ ������� �� ������� � �������� �� ������ � ���� ���������
    [SerializeField]
    [Range(0, 100)] 
    private int repeat; //������� ��� ���������� ������

    [SerializeField]
    private float distance; //��� �� �� ����������

    private int count = 0; //���������� �����

    private bool isActive = false; // ��� ������� � �� ������ ���������

    public override void Use()
    {
        isActive = true; //������ ���������� 
    }

    private void Update()
    {
        if (isActive)
        {
            if (count < repeat)
            {
                Instantiate(prefab, gameObject.transform.position + new Vector3(0, distance, 0) * (count + 1), Quaternion.identity);
                count++; //Instantiate ��� ����� ��� ������� ����� �������. ������ �������� � �� ������ �� ��� ����� ����������(������). ����� ��� ������� �� ���� ����� � ������ ������ ��� ������� (����)
            }
        }
        
    }
}

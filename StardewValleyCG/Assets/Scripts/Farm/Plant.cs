using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

//������ ���� �ʿ� �� �� �������̰� �̻۰ɷ�
public class Plant : ScriptableObject
{
    public string plantName;
    public int growTime;

    public bool isOneCultivate;
    public int adultPoint; //��� �� �ٽ� ���ư��� ����

    public Sprite[] stepSprite;
    public Sprite deathSprite;
    public int[] stepTime;
    //public ����
    //public ��Ӿ�����
}

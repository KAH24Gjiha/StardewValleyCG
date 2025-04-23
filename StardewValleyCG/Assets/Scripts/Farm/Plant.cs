using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

//변수명 변경 필요 좀 더 직관적이고 이쁜걸로
public class Plant : ScriptableObject
{
    public string plantName;
    public int growTime;

    public bool isOneCultivate;
    public int adultPoint; //재배 후 다시 돌아가는 기점

    public Sprite[] stepSprite;
    public Sprite deathSprite;
    public int[] stepTime;
    //public 계절
    //public 드롭아이템
}

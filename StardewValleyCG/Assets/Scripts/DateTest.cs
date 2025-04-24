using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DateTest : MonoBehaviour
{
    public int date;

    [SerializeField] private TMP_Text dateText;
    private CropManager cropManager;

    // Start is called before the first frame update
    void Start()
    {
        cropManager = CropManager.Instance;
        dateText.text = date.ToString();
    }

    public void ChangeDate()
    {
        cropManager.DateChange();
        date++;
        dateText.text = date.ToString();
    }
    
}

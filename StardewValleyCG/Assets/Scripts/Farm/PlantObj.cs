using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantObj : MonoBehaviour
{
    public int plantIndex;
    public bool isAdult;

    [SerializeField] private Plant plant;
    [SerializeField] private CropManager cropManager;

    private SpriteRenderer plantImage;
    private Sprite[] stepSprite;

    private int onTime = 0;

    private bool isWatering;
    private bool isDeath;

    void Start()
    {
        stepSprite = plant.stepSprite;

        plantImage = this.GetComponent<SpriteRenderer>();
        cropManager = CropManager.Instance;

        cropManager.AddPlant(this);
    }

    public void WateringPlant() 
    {
        isWatering = true;
        plantImage.color = Color.blue;
    }
    
    public void GrowPlant()
    {
        onTime++;

        if (isWatering && !isDeath)
        {
            isWatering = false;
            plantImage.color = Color.white;

            if (onTime >= plant.growTime)
            {
                CompleteGrow();
            }
            for (int i = 0; i < plant.stepTime.Length; i++)
            {
                if (onTime == plant.stepTime[i])
                {
                    plantImage.sprite = stepSprite[plant.stepTime[i]];
                }
            }
        }
        else 
        {
            DeathPlant();
        }
        
    }
    public void DropItem()
    {
        //아이템 드롭 (SetActive로 오브젝트 풀링?)
        Destroy(this.gameObject);
    }
    private void CompleteGrow()
    {
        isAdult = true;
    }
    private void DeathPlant()
    {
        plantImage.sprite = plant.deathSprite;

        cropManager.plantObjs.Remove(cropManager.plantObjs[plantIndex]);
    }
}

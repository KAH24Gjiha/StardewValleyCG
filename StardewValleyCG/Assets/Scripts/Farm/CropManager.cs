using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantData
{
    private int lastDate;
    private bool isDeath;
}

public class CropManager : MonoBehaviour
{
    static GameObject container;

    static CropManager instance;
    public static CropManager Instance
    {
        get
        {
            if (!instance)
            {
                container = new GameObject();
                container.name = "CropManager";

                instance = container.AddComponent(typeof(CropManager)) as CropManager;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }

    public List<PlantObj> plantObjs = new List<PlantObj>();

    public void AddPlant(PlantObj plant)
    {
        plant.plantIndex = plantObjs.Count;
        plantObjs.Add(plant);
    }

    public void DateChange()
    {
        for (int i = plantObjs.Count - 1; i >= 0; i--)
        {
            plantObjs[i].GrowPlant();
        }
        for (int i = 0; i < plantObjs.Count; i++)
        {
            plantObjs[i].plantIndex = i;
        }
    }
}

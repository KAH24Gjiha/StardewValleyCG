using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public enum ItemType
{
    Hoe,
    Axe,
    WateringCan,
    Scythe,
    Pickaxe,
    Seed,
    Vegetable,
    None
}

public class PlayerCrop : MonoBehaviour
{
    [SerializeField] private Transform plantMap;
    [SerializeField] private Tilemap fieldMap;
    [SerializeField] private TileBase plowingTile;
    [SerializeField] private GameObject[] seeds;

    [SerializeField] private TMP_Text toolText;

    private ItemType playerItem;

    void Start()
    {
        playerItem = ItemType.Hoe;
        toolText.text = "Hoe";
    }

    private void Update()
    {
        //수정 예정
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            playerItem = ItemType.None;
            toolText.text = "None";
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerItem = ItemType.Hoe;
            toolText.text = "Hoe";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerItem = ItemType.WateringCan;
            toolText.text = "WateringCan";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerItem = ItemType.Seed;
            toolText.text = "seed1";
        }

        if (Input.GetMouseButtonDown(0))
        {
            switch (playerItem)
            {
                case ItemType.Hoe:
                    {
                        PlowingField();
                        break;
                    }
                case ItemType.WateringCan:
                    {
                        Watering();
                        break;
                    }
                case ItemType.Seed:
                    {
                        PlantingSeed();
                        break;
                    }
                default:
                    {
                        Culturing();
                        break;
                    }
            }
        }
    }

    private void PlowingField()
    {
        Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPos.z = 0;

        Vector3Int selectTilePosition = WorldToIGrid(clickPos);

        fieldMap.SetTile(selectTilePosition, plowingTile);
    }
    private void PlantingSeed()
    {
        Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(clickPos, Vector2.zero, LayerMask.GetMask("Field"));

        if (hit)
        {
            if (hit.transform.CompareTag("Field"))
            {
                Vector3 selectTilePosition = WorldToIGrid(clickPos);
                selectTilePosition += new Vector3(0.5f, 0.5f, 0);

                Instantiate(seeds[0], selectTilePosition, Quaternion.identity, plantMap);
            }
        }
    }
    private void Watering()
    {
        Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(clickPos, Vector2.zero, LayerMask.GetMask("Field"));

        if (hit)
        {
            if (hit.transform.CompareTag("Plant"))
            {
                hit.transform.GetComponent<PlantObj>().WateringPlant();
            }
        }
    }
    private void Culturing()
    {
        Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(clickPos, Vector2.zero, LayerMask.GetMask("Field"));

        if (hit)
        {
            if (hit.transform.CompareTag("Plant"))
            {
                PlantObj plant =  hit.transform.GetComponent<PlantObj>();
                if (plant.isAdult)
                {
                    plant.DropItem();
                }
            }
        }
    }


    private Vector3Int WorldToIGrid(Vector3 worldPos)
    {
        int X = Mathf.RoundToInt((worldPos.x));
        int Y = Mathf.RoundToInt((worldPos.y));

        return new Vector3Int(X, Y, 0);  // Z는 2D 환경에서 0으로 설정
    }
}

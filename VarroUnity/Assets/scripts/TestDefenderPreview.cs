using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestDefenderPreview : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public DefenderSpawner defSpawn;
    public GameObject previewOBJ;
    public SpriteRenderer spr;
    public Sprite[] sprites;
    public int spriteIndex;

    //public bool turnOn = false;

    // Start is called before the first frame update
    void Start()
    {
        //spr.sprite = defSpawn.initialDefender.gameObject.sprite
    }

    // Update is called once per frame
    void Update()
    {

        

        if (spr.enabled)
        {
            Vector2 poo = GetSquareClicked();
            previewOBJ.transform.position = new Vector3(poo.x, poo.y, 0);
        }

    }



    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        spr.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        spr.enabled = true;
        //turnOn = true;
    }

    public void SetPreSpri(int ind)
    {
        spr.sprite = sprites[ind];
    }
}

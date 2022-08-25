using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DefenderSpawner : MonoBehaviour, IPointerClickHandler
{
    public Defender initialDefender;
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    public int currentDefenderCost; //for display purposes only
    public int energy = 0;//whats used to buy new towers
    public TextMeshProUGUI energyAmountText;

    

    


    private void Start()
    {
        energyAmountText = GameObject.Find("EnergyAmount").GetComponent<TextMeshProUGUI>();

        CreateDefenderParent();
        SetSelectedDefender(initialDefender);
        ChangeEnergyAmountText(energy);
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    /*
    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());

    //now using onpointerclick using eventsystems and ipointerclick handler

    }
    */


    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
        currentDefenderCost = defenderToSelect.cost;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        
        if(energy - defender.cost >= 0)
        {
            SpawnDefender(gridPos);
            energy -= defender.cost;
            ChangeEnergyAmountText(energy);
        }
        else
        {
            Debug.Log("too expensive!!");
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


    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }


    public void ChangeEnergyAmountText(int amt)
    {
        if (energyAmountText)
            energyAmountText.text = "Energy: " + amt.ToString();
        else
            Debug.Log("no text mesh pro text asigned as energy reader");
    }

    public void AddEnergy(int amt)
    {
        energy += amt;
        ChangeEnergyAmountText(energy);
    }

    public Defender GetDefender()
    {
        return defender;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }
}
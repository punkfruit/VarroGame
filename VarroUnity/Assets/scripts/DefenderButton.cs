using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    //public CanvasController cc;
    public int numb; 
    [SerializeField] Defender defenderPrefab;

    public int costDisplay;

    private void Start()
    {
        //LabelButtonWithCost();
        //cc = FindObjectOfType<CanvasController>();

        //costDisplay = defenderPrefab.GetComponent<Defender>().cost;
    }

    private void LabelButtonWithCost()
    {
       /* Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError(name + " has no cost text, add some!");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
       */
    }

    private void OnMouseDown()
    {
        /*
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        */
    }

    public void ButtonParty(bool destroy)
    {
        
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        //FindObjectOfType<DefenderSpawner>().currentDefenderCost = defenderPrefab.GetComponent<Defender>().cost;

        //cc.NubControl(numb);

        GameManager.instance.destroyTower = destroy;
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugAdventurerUI : MonoBehaviour
{
    public GameObject debugAdventurerUI;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void CloseAdventurerDebug() {
        debugAdventurerUI.SetActive(false);
    }

    public void DebugMoveToAdventure() {
        //Debug.Log("debugmovetoadventure");
        //selectedAdventurer.DebugSetDestination(adventurePatronSpot[Random.Range(0, vendorPatronSpot.Length)].transform.position);
    }

    public void DebugMoveToVendor() {
        //Debug.Log("debugmovetovendor");
        //selectedAdventurer.DebugSetDestination(vendorPatronSpot[Random.Range(0, vendorPatronSpot.Length)].transform.position);
    }

    public void DebugMoveToGuildHall() {
        //Debug.Log("debugmovetovendor");
        //selectedAdventurer.DebugSetDestination(guildHallPatronSpot[Random.Range(0, guildHallPatronSpot.Length)].transform.position);
    }
}

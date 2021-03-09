using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] adventurePatronSpot;
    public GameObject[] vendorPatronSpot;
    public GameObject[] guildHallPatronSpot;

    // public Adventurer selectedAdventurer;

    // Debug Adventurer
    public GameObject debugAdventurerUI;
    public Text debugAdventurerNameText;

    void Awake() {
        if(instance == null)
            instance = this;
    }
    private void Start() {
        // debugAdventurerUI.SetActive(false);
        // AdventurerDebug(selectedAdventurer);
    }

    public void Update() {
        /*
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("clicked");
        }
        */
    }

    // 

    public void RequestButtonPressed(Adventurer adventurer) {
        Debug.Log("Request from : " + adventurer.name + " for : " + "cheese");
    }

    public Vector3 GetDestinationForThirst() {
        return vendorPatronSpot[Random.Range(0, vendorPatronSpot.Length)].transform.position;
    }

    /*
    // Adventurer Debug Area
    public void AdventurerDebug(Adventurer adventurer) {
        selectedAdventurer = adventurer;
        debugAdventurerUI.SetActive(true);
        debugAdventurerNameText.text = adventurer.name;
    }

    public void CloseAdventurerDebug() {
        debugAdventurerUI.SetActive(false);
    }

    public void DebugMoveToAdventure() {
        //Debug.Log("debugmovetoadventure");
        selectedAdventurer.DebugSetDestination(adventurePatronSpot[Random.Range(0, vendorPatronSpot.Length)].transform.position);
    }

    public void DebugMoveToVendor() {
        //Debug.Log("debugmovetovendor");
        selectedAdventurer.DebugSetDestination(vendorPatronSpot[Random.Range(0, vendorPatronSpot.Length)].transform.position);
    }

    public void DebugMoveToGuildHall() {
        //Debug.Log("debugmovetovendor");
        selectedAdventurer.DebugSetDestination(guildHallPatronSpot[Random.Range(0, guildHallPatronSpot.Length)].transform.position);
    }
    */
}

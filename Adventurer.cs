using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Adventurer : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    DebugAdventurerUI debugUI;

    private enum State { Idle, Moving, Waiting };
    State state;
    private Vector3 destination; // = new Vector3(0f, 0f, 0f);
    public GameObject requestPopup;
    // public GameObject debug_adventurer_prefab;

    // NEEDS
    struct Need
    {
        public float currentValue;
        public int valueCap;
        public float valueMultiplier;
        public int valueThreshhold;

        public Need(int valueThreshhold, int valueCap) {
            this.currentValue = 0;
            this.valueCap = valueCap;
            this.valueMultiplier = 10;
            this.valueThreshhold = valueThreshhold;
        }
    }
    Need[] need = new Need[3];
    Need drink = new Need(50, 100);
    Need rest = new Need(70, 100);
    Need food = new Need(60, 100);
    Need adventure = new Need(100, 100);

    private bool needsMet = false;
    // timers
    float waiting;

    private void Start() {
        state = State.Idle;
        // navMeshAgent = this.GetComponentInChildren<NavMeshAgent>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        destination = gameObject.transform.position;
        requestPopup.SetActive(false);

        need[0] = drink;
        need[1] = rest;
        need[2] = food;
        // need[3] = adventure;
    }

    public void Update() {
        // keeps request pop up facing forward
        var rotation = Quaternion.LookRotation(Vector3.forward, Vector3.forward);
        requestPopup.transform.rotation = rotation;
        // debug_adventurer_prefab.transform.rotation = rotation;

        // moves navmeshagent
        navMeshAgent.SetDestination(destination);

        // adventure need can only go up when other needs are below threshhold
        // update needs
        for(int i = 0; i < need.Length; i++) {
            // update current value
            need[i].currentValue += Time.deltaTime * need[i].valueMultiplier;

            // check threshold
            if(need[i].currentValue > need[i].valueThreshhold) {
                needsMet = false;
                // threshold met, do stuff

                // cap the current value
                if(need[i].currentValue >= need[i].valueCap) {
                    need[i].currentValue = need[i].valueCap;
                }
            }

            // zero/bottom out current value
            if(need[i].currentValue <= 0) {
                need[i].currentValue = 0;
            }
        }

        if(needsMet) {
            adventure.valueMultiplier = 10f;
        } else adventure.valueMultiplier = -10f;


        /*
        if(state == State.Idle) {
            destination = GameManager.instance.GetDestinationForThirst();
        }
        */
    }

    public void RequestButtonPressed() {
        GameManager.instance.RequestButtonPressed(gameObject.GetComponent<Adventurer>());
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log(other.tag);

        // tags
        // food and drink collider
        // rest collider

        // set need multipliers based on Tag collided with
        switch(other.tag) {
            case "Adventure Spot Trigger":
                // hungerMultiplier = -10;
                break;
            case "Guild Hall Spot Trigger":
                // restMultiplier = -10;
                break;
            case "Vendor Patron Spot Trigger":
                Debug.Log("test");
                // thirstMultiplier = -10;
                break;
            default:
                //thirstMultiplier = 10;
                //restMultiplier = 10;
                //hungerMultiplier = 10;
                break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        // stop moving
        navMeshAgent.SetDestination(gameObject.transform.position);
        // open request
        requestPopup.SetActive(true);

        switch(other.name) {
            case "Adventure Spot Trigger":
                break;
            case "Guild Hall Spot Trigger":
                break;
            case "Vendor Spot Trigger":
                break;
        }
    }

    private void OnTriggerExit(Collider other) {
        // set all requests popups to false
        requestPopup.SetActive(false);
    }

    /*
    public void DebugButtonPressed() {
        GameManager.instance.AdventurerDebug(gameObject.GetComponent<Adventurer>());
    }
    */

    public void AdventurerButtonPressed() {
        Debug.Log("enturerButtonPressed");
    }

    public void DebugSetDestination(Vector3 debugDestination) {
        Debug.Log("Adventurer().debug set destination");
        destination = debugDestination;
    }
}

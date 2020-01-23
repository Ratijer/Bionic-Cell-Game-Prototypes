using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    //For test purposes only
    public TextMeshProUGUI abilityMeter;    //When filled up to 100 (maximum), player can fire all items
    public TextMeshProUGUI playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        abilityMeter.text = "Meter: " + WeaponSelection.instance.abilityMeterFill.ToString();
        playerHealth.text = "Health: " + PlayerController.playerHealth.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHamster : MonoBehaviour, IButtonListener
{
    [SerializeField]
    GravityControl hamsterControl;
    public void ButtonHeld(ButtonInfo heldInfo) => hamsterControl.MT();
    public void ButtonPressed(ButtonInfo pressedInfo) => hamsterControl.DownAcceleration();

    public void ButtonReleased(ButtonInfo releasedInfo) => hamsterControl.RegularAcceleration();
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerInputs>().RegisterListener(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

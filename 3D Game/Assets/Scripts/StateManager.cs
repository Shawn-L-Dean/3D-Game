using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currState;

    // Update is called once per frame
    void Update()
    {
        RunStateMachine(); 
    }

    private void RunStateMachine()
    {
        State nextState = currState?.RunCurrentState();
        
        if(nextState != null)
        {
            Debug.Log("Switching State");
            SwitchToState(nextState); //Switch to the next state.
        }
    }

    private void SwitchToState(State nextState)
    {
        currState = nextState;
    }
}

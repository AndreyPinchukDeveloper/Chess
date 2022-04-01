using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupState : State
{
    private ChosenFigure _chosenFigure;

    public PickupState(ChosenFigure chosenFigure)
    {
        _chosenFigure = chosenFigure;//it's our access to figure's scripts;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("I'm holding it !");
        _chosenFigure.anim.CrossFade("Idle", 0.1f);//we can connection any animation or something else
    }

    public override void Exit()
    {
        base.Exit();
        Debug.LogError("I haven't hold it anymore !");
    }
}

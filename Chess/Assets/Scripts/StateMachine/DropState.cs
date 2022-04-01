using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropState : State
{
    private ChosenFigure _chosenFigure;

    public DropState(ChosenFigure chosenFigure)
    {
        _chosenFigure = chosenFigure;//it's our access to figure's scripts;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("I'm droping it !");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.LogError("I have done it !");
    }
}

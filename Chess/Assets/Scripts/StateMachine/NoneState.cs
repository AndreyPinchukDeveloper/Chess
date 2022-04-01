using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneState : State
{
    private ChosenFigure _chosenFigure;

    public NoneState(ChosenFigure chosenFigure)
    {
        _chosenFigure = chosenFigure;//it's our access to figure's scripts;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("I'm nothing to do !");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.LogError("I have stoped nothing to do !");
    }
}

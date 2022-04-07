using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragState : State
{
    private ChosenFigure _chosenFigure;

    public DragState(ChosenFigure chosenFigure)
    {
        _chosenFigure = chosenFigure;//it's our access to figure's scripts;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("I've draged that !");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.LogError("I haven't drag it anymore !");
    }

    public override void Update()
    {
        base.Update();
        Debug.LogError("I'm dragging that !");
        _chosenFigure.transform.position = new Vector3//connecting a move mechanic while dragging
            (_chosenFigure.transform.position.x, _chosenFigure.transform.position.y + 100 * Time.deltaTime);
    }
}

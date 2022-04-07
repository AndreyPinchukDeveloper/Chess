using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ChosenFigure : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textPlayer;
    public TextMeshProUGUI TextPlayer => _textPlayer;
    public Animator anim;
    private StateMachine _sm;

    private PickupState _pickupState;
    /*private DropState _dropState;
    private DragState _dragState;
    private NoneState _noneState;*/

    void Start()
    {
        _sm = new StateMachine();
        _pickupState = new PickupState(this);
        _sm.Initialize(new NoneState(this));
    }

    void Update()
    {
        _sm.CurrentState.Update();

        if (Input.GetKeyDown(KeyCode.R))
        {
            _sm.ChangeState(_pickupState);//use "this" only if you used constructor !
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            _sm.ChangeState(new DragState(this));
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            _sm.ChangeState(new DropState(this));
        }
    }
}

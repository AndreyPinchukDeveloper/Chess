using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

class DragAndDrop
{
    enum State
    {
        none,
        pickup,
        drag,
        drop
    }

    State state;
    GameObject item;

    public DragAndDrop()
    {
        state = State.none;
        item = null;
    }

    public bool Action()
    {
        switch (state)
        {
            case State.none:
                break;
            case State.pickup:
                break;
            case State.drag:
                break;
            case State.drop:
                break;
            default:
                break;
        }
        return false;
    }

}

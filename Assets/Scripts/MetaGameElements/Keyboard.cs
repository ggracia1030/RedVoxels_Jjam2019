using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] Key w, a, s, d, space, esc;
    // Start is called before the first frame update
    public bool IsPressed(Key.KeyType _type)
    {
        switch(_type)
        {
            case Key.KeyType.W:
                return w.isPressed;
            case Key.KeyType.S:
                return s.isPressed;
            case Key.KeyType.A:
                return a.isPressed;
            case Key.KeyType.D:
                return d.isPressed;
            case Key.KeyType.Space:
                return space.isPressed;
            case Key.KeyType.Esc:
                return esc.isPressed;
        }
        return false;
    }
}

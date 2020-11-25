using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bool_Event : UnityEvent<bool> { }

public class EventManager
{
    public static Bool_Event OnLightToggle = new Bool_Event();
}

using System;
using UnityEngine;

public class EventBus
{
    private static EventBus _instance;
    private static EventBus Instance
    {
        get
        {
            if (_instance == null)
                _instance = new EventBus();
            return _instance;
        }
    }

    public Action ImHide;
}

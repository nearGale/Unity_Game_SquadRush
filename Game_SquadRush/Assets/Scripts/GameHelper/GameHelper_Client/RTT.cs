using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RushRush
{
    public static partial class GameHelper_Client
    {
        public static float GetRTT()
        {
            return ClientTimerSystem.Instance.GetRTTValue();
        }
    }
}
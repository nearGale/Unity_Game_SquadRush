using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RushRush
{
    public static partial class GameHelper_Client
    {
        public static string GetLocalPlayerName()
        {
            return EX_A_PlayerPanel.Instance.inputFieldPlayerName.text;
        }
    }
}
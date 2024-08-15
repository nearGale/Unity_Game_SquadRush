using Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test
{
    public class LobbyLogController : MonoSingleton<LobbyLogController> 
    {
        private Text _textLog;

        void Start()
        {
            _textLog = GetComponent<Text>();
        }

        public void AppendLog(string str)
        {
            _textLog.text += str + "\n";
            Debug.Log(str);
        }
    }
}
using Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace RushRush
{
    public class EX_A_PlayerPanel : MonoSingleton<EX_A_PlayerPanel>
    {
        /// <summary> 帧号</summary>
        public Text textTick;

        /// <summary> 连接状态 </summary>
        public Text textState;
        
        /// <summary> 记录log </summary>
        public Text textLog;

        public InputField inputFieldPlayerName;
        public Button btnBattleStart;
        public Button btnBattleStop;
        public Button btnPause;
        public Button btnResume;
        public Button btnModify;

        private void Start()
        {
            btnBattleStart.onClick.AddListener(OnBtnBattleStartClick);
            btnBattleStop.onClick.AddListener(OnBtnBattleStopClick);
            btnPause.onClick.AddListener(OnBtnPauseClick);
            btnResume.onClick.AddListener(OnBtnResumeClick);
            btnModify.onClick.AddListener(OnBtnModifyClick);
        }

        private void Update()
        {
            var ct = GameHelper_Client.GetClientTick();
            var st = GameHelper_Client.GetBattleServerTick();
            var rtt = (int)(GameHelper_Client.GetRTT() * 1000);
            textTick.text = $"client:{ct} \n server:{st} \n delta:{st - ct} \n rtt:{rtt}";

            var clientInRoomState = ClientRoomSystem.Instance.GetClientInRoomState();

            textState.text = $"连接状态:{clientInRoomState} ";
            if(clientInRoomState == ERoomState.InBattle)
            {
                textState.text += "\n" + $"暂停状态:{ClientRoomSystem.Instance.battlePause}";
            }
        }

        public void OnBtnBattleStartClick()
        {
            Msg_BattleStart_Req msg = new Msg_BattleStart_Req();
            NetworkClient.Send(msg);
        }

        public void OnBtnBattleStopClick()
        {
            Msg_BattleStop_Req msg = new Msg_BattleStop_Req();
            NetworkClient.Send(msg);
        }

        public void OnBtnPauseClick()
        {
            Msg_BattlePause_Req msg = new Msg_BattlePause_Req();
            NetworkClient.Send(msg);
        }

        public void OnBtnResumeClick()
        {
            Msg_BattleResume_Req msg = new Msg_BattleResume_Req();
            NetworkClient.Send(msg);
        }

        public void OnBtnModifyClick()
        {
            Msg_Command_Req msg = new Msg_Command_Req()
            {
                eCommand = ECommand.Modify
            };
            NetworkClient.Send(msg);
        }

        public void AppendLog(string str)
        {
            textLog.text += str + "\n";
        }
    }
}
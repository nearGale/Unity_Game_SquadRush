using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace RushRush
{
    /// <summary>
    /// 此处放置 客户端 运行逻辑
    /// </summary>
    public class ClientInputSystem : Singleton<ClientInputSystem>, IClientSystem
    {
        #region system func
        public void OnClientConnect()
        {
        }

        public void OnClientDisconnect()
        {
        }

        public void Start()
        {
        }

        public void Update()
        {
            var clientInRoomState = ClientRoomSystem.Instance.GetClientInRoomState();
            if (clientInRoomState != ERoomState.Lobby) return;

            if (Input.GetMouseButtonDown(1) && !GameHelper_Client.IsMousePosAboveUI())
            {
                if (GameHelper_Client.GetMouseClickPos(out var mousePos))
                {
                    ClientRoomSystem.Instance.localPlayerController.targetPos = mousePos;
                }
            }
        }

        public void LogicUpdate()
        {

        }
#endregion


    }
}
using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace RushRush
{
    // 简单测试一下大厅同步
    public class PlayerController : NetworkBehaviour
    {
        #region 数据同步

        [SyncVar(hook = nameof(PlayerIdChanged))]
        public int id;

        void PlayerIdChanged(int oldVal, int newVal)
        {
            id = newVal;
            GameHelper_Common.UILog($"id:{oldVal} -> {newVal}");
        }

        [ClientRpc]
        void SetData(int val)
        {
            id = val;
        }

        #endregion

        private void Start()
        {
        }

        private void Update()
        {
            if (isLocalPlayer)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    //pos = transform.position + Vector3.left;
                    //LobbyLogController.Instance.AppendLog($"localmove");
                    transform.position = transform.position + Vector3.left;

                    SetData(Random.Range(0, 10));
                }
            }

        }

    }
}
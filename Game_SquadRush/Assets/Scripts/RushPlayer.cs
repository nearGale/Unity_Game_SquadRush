using System.Linq;
using UnityEngine;
using Mirror;

namespace RushRush
{
    public class RushPlayer : NetworkBehaviour
    {
        #region Server
        /// <summary>
        /// 当 NetworkBehaviour 对象在服务器上处于活动状态时，会调用此函数。
        /// （仅服务器触发）
        /// 这可能是由NetworkServer触发的。Listen（）用于场景中的对象，或通过NetworkServer。Spawn（）用于动态创建的对象
        /// 这将用于“主机”上的对象以及专用服务器上的对象
        /// </summary>
        public override void OnStartServer()
        {
            base.OnStartServer();

            Msg_PlayerConnect_Rsp msgRsp = new();
            netIdentity.connectionToClient.Send(msgRsp);

            GameHelper_Common.UILog($"Server: OnPlayerConnect");

            // 检测到有客户端连接，接下来进入ID验证环节
            // 验证通过：
            //    => 广播给所有人，有新人登录服务器 Msg_Join_Ntf

        }
        #endregion

        #region Client

        public Vector3 targetPos;

        #region 数据同步

        [SyncVar(hook = nameof(PlayerPosChanged))]
        public Vector3 pos;

        void PlayerPosChanged(Vector3 oldVal, Vector3 newVal)
        {
            transform.position = pos;
        }

        [SyncVar(hook = nameof(PlayerForwardChanged))]
        public Vector3 forward;

        void PlayerForwardChanged(Vector3 oldVal, Vector3 newVal)
        {
            transform.forward = forward;
        }

        #endregion 数据同步

        private void Start()
        {
            if(isLocalPlayer)
                ClientRoomSystem.Instance.localPlayerController = this;
        }

        private void Update()
        {
            if (isLocalPlayer)
            {
                if(targetPos != Vector3.zero)
                {
                    var speed = 0.02f;
                    var dir = targetPos - transform.position;
                    if(dir.magnitude < speed)
                    {
                        transform.position = targetPos;
                    }
                    else
                    {
                        var nextPos = transform.position + dir.normalized * speed;
                        Ray ray = new Ray(nextPos + Vector3.up * 10, Vector3.down);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit))
                        {
                            transform.position = hit.point;
                        }
                        else
                        {
                            transform.position = nextPos;
                        }
                        transform.LookAt(targetPos);
                    }
                    pos = transform.position;
                    forward = transform.forward;
                }
            }
        }


        #endregion Client
    }
}
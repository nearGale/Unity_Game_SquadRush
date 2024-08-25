using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RushRush
{
    public interface ISystem
    {
        void Start();
        void Update();
        void LogicUpdate();
    }

    public interface IClientSystem : ISystem 
    {
        void OnClientConnect();
        void OnClientDisconnect();
    }

    public interface IServerSystem : ISystem
    {
        void OnStartServer();
        void OnStopServer();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RushRush
{
    public class GameEntry: MonoBehaviour
    {
        void Start()
        {
            GameFacade.isServer = false;
            GameFacade.startTime = DateTime.Now;

            foreach (var system in GameFacade.serverSystems)
            {
                system.Start();
            }

            foreach (var system in GameFacade.clientSystems)
            {
                system.Start();
            }
        }

        void Update()
        {
            if (GameFacade.isServer)
            {
                foreach (var system in GameFacade.serverSystems)
                {
                    system.Update();
                }
            }

            foreach (var system in GameFacade.clientSystems)
            {
                system.Update();
            }
        }

        private void FixedUpdate()
        {
            if (GameFacade.isServer)
            {
                foreach (var system in GameFacade.serverSystems)
                {
                    system.LogicUpdate();
                }
            }

            foreach (var system in GameFacade.clientSystems)
            {
                system.LogicUpdate();
            }
        }
    }
}
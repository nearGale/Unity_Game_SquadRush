using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace RushRush
{
    public static partial class GameHelper_Client
    {
        /// <summary>
        /// ��ȡ�������λ��
        /// </summary>
        /// <returns></returns>
        public static bool GetMouseClickPos(out Vector3 pos)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // �����������ཻ������������¼�
                GameObject clickedObject = hit.collider.gameObject;

                pos = hit.point;
                return true;
            }

            pos = Vector3.zero;
            return false;
        }

        public static bool IsMousePosAboveUI()
        {
            var aboveUI = false;
#if IPHONE || ANDROID
            aboveUI = EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
#else
            aboveUI = EventSystem.current.IsPointerOverGameObject();
#endif

            return aboveUI;
        }
    }
}
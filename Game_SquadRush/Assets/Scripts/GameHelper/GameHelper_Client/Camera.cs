using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace RushRush
{
    public static partial class GameHelper_Client
    {
        /// <summary>
        /// 获取鼠标点击的位置
        /// </summary>
        /// <returns></returns>
        public static bool GetMouseClickPos(out Vector3 pos)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // 射线与物体相交，处理鼠标点击事件
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
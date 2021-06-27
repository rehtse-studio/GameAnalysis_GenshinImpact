using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RehtseStudio.MonoSingleton
{

    public class RS_MonoSingleton<T> : MonoBehaviour where T : RS_MonoSingleton<T>
    {

        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    Debug.Log(typeof(T).ToString() + " is NULL");

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this as T;

            Init();
        }

        public virtual void Init()
        {

        }

    }

}



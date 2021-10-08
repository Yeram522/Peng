#region Using statements

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#endregion

namespace Bitgem.VFX.StylisedWater
{
    public class WateverVolumeFloater : MonoBehaviour
    {
        #region Public fields

        public WaterVolumeHelper WaterVolumeHelper = null;

        #endregion

        #region MonoBehaviour events
        void Update()
        {
            
            var instance = WaterVolumeHelper ? WaterVolumeHelper : WaterVolumeHelper.Instance;
            if (!instance)
            {
                
                return;
            }
            if(Input.anyKey) return;
            
            
            transform.position = new Vector3(transform.position.x, instance.GetHeight(transform.position) ?? transform.position.y, transform.position.z);
        }

        private void OnTriggerEnter(Collider other)//충돌하는 순간
        {
            if(other.tag != "water") return;
            Debug.Log("swimming");
            GetComponent<Animator>().SetBool("isMoving",false);
            GetComponent<Animator>().SetBool("isInWater",true);
        }

        private void OnTriggerExir(Collider other)//충돌하는 순간
        {
            if(other.tag != "water") return;
            //Debug.Log("swimming");
            GetComponent<Animator>().SetBool("isInWater",false);
        }

      

        #endregion
    }
}
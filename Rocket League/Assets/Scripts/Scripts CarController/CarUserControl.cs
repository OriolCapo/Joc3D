using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
		public float jumpForce = 300000.0f;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
			if(PlayerPrefs.GetInt("onPlay")==1){
	            // pass the input to the car!
	            float h = CrossPlatformInputManager.GetAxis("Horizontal");
	            float v = CrossPlatformInputManager.GetAxis("Vertical");
	            m_Car.Move(h, v, v, 0f);
				//float jump = CrossPlatformInputManager.GetAxis ("Jump");
				if (Input.GetKeyDown(KeyCode.Minus)) {
					m_Car.Jump (jumpForce);
				}
				if (transform.up [1] < -0.9f && transform.up [1] > -1.0f) {
					//PlayerPrefs.SetInt ("onPlay", 0);
					transform.Translate(Vector3.up*2);
					transform.Rotate(transform.forward*180.0f);
				} else if (transform.position.y < 0) {
					float dist = transform.position.y;
					transform.Translate (Vector3.up * (dist + 1.0f));
				}
			}
        }
    }
}

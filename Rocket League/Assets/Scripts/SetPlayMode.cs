using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayMode : MonoBehaviour {

    public void SetPlayerMode(int mode)
    {
        PlayerPrefs.SetInt("Mode", mode);
        PlayerPrefs.SetInt("SelectedCar", 1);
    }

	
}

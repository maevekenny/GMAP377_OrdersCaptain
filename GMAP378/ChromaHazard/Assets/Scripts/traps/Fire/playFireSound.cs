using UnityEngine;
using System.Collections;

public class playFireSound : MonoBehaviour {

	public void playFire(){
		SoundManager.instance.PlaySound ("fire");
	}
}

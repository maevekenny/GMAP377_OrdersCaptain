using UnityEngine;
using System.Collections;

public class pressurePlateSound : MonoBehaviour {

	public void playCrusherSound(){
		SoundManager.instance.PlaySound ("crusher");
	}
}

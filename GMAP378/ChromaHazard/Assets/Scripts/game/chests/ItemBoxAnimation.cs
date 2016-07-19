using UnityEngine;
using System.Collections;

public class ItemBoxAnimation : MonoBehaviour {

	public string animationState; //idle, spawning, destroying
	public float startTime;
	public float startingScaleUpSpeed;
	public float startingScaleDownSpeed;
	public float idleSpeed;
	public float idleTime;
	public float destroyingSpeed;
	public float exitTime;

	private bool idlingUp;
	private float initialIdleTime;
	private Vector3 initialScale;
	private float initialYpos;

	// Use this for initialization
	void Start () {
		initialIdleTime = idleTime;
		initialScale = this.gameObject.transform.localScale;
		initialYpos = this.gameObject.transform.position.y;

		animationState = "spawning";
		this.gameObject.transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (animationState == "spawning") {
			this.gameObject.transform.localScale += new Vector3 (startingScaleUpSpeed, startingScaleUpSpeed, 0f);
			if (this.gameObject.transform.localScale.x >= initialScale.x * 1.6) {
				animationState = "spawning up";
			}
			print ("spawning up");
		}

		if (animationState == "spawning up") {
			this.gameObject.transform.localScale -= new Vector3 (startingScaleDownSpeed, startingScaleDownSpeed, 0f);
			print ("spawning down");
			if (this.gameObject.transform.localScale.x <= initialScale.x) {
				this.gameObject.transform.localScale = initialScale;
				animationState = "idle";
			}
		}

		if (animationState == "idle") {
			if (!idlingUp) {
				this.gameObject.transform.position -= new Vector3 (0f, idleSpeed, 0f);

				idleTime -= Time.deltaTime;
				if (idleTime <= 0) {
					idleTime = initialIdleTime;
					idlingUp = true;
				}
			} else if (idlingUp) {
				this.gameObject.transform.position += new Vector3 (0f, idleSpeed, 0f);

				idleTime -= Time.deltaTime;
				if (idleTime <= 0) {
					idleTime = initialIdleTime;
					idlingUp = false;
				}
			}


		}

		if (animationState == "destroying") {
			this.gameObject.transform.localScale -= new Vector3 (destroyingSpeed, destroyingSpeed, 0f);

			if (this.gameObject.transform.localScale.x <= 0) {
				Destroy (this.gameObject);
			}
		}
			
	}
}

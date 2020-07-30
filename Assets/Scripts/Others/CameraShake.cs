using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	//Set camera shake On Weapon Fire
	public static bool shouldCameraShake;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.1f;

	Vector3 originalPos;

	void Start()
	{
		originalPos = transform.localPosition;
	}

	void Update()
	{
		if(shouldCameraShake == true)
        {
			StartCoroutine(DoCameraShakeOnce());
		}
	}

    IEnumerator DoCameraShakeOnce()
	{
		transform.localPosition = originalPos + new Vector3(0, Random.Range(-1, 1) * shakeAmount, 0);
		yield return new WaitForSeconds(.1f);
		shouldCameraShake = false;
		transform.localPosition = originalPos;
	}
}
using FMODUnity;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
	[SerializeField] EventReference FootStepEvent;
	[SerializeField] float rate;
	[SerializeField] GameObject player;
	[SerializeField] FPS_Controller controller;

	float time;

	public void PlayFootStep()
	{
		RuntimeManager.PlayOneShotAttached(FootStepEvent, player);
	}
	void Update ()
	{
		time += Time.deltaTime;
		if (controller.isWalking)
		{
			Debug.Log("footsteps play now");

			if (time >= rate)
			{
				PlayFootStep();
				time = 0;
			}
		}
	}
}
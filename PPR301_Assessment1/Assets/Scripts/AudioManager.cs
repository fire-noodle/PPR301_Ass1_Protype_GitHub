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
	void update ()
	{
		time += Time.deltaTime;
		//if (controller.isWalking) 
			// there needs to be a public varabile called "is walking" in the FPS_Controller. something public and exposed
			// stating the player is actively moving. 
		{
			if (time >= rate)
			{
				PlayFootStep();
				time = 0;
			}
		}
	}
}
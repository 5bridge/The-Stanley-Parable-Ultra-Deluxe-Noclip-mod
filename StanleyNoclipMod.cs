using System;
using MelonLoader;
using UnityEngine;

namespace StanleyNoclipMod
{
	public class StanleyNoclipMod : MelonMod
	{
		public override void OnApplicationStart()
		{
			base.OnApplicationStart();
			this.noclipUse = 0;
			this.tempBucket = false;
		}

		public override void OnUpdate()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			GameObject gameObject2 = GameObject.Find("Main Camera");
			bool hasbucket = BucketController.HASBUCKET;
			StanleyController stanleyController = Object.FindObjectOfType<StanleyController>();
			bool motionFrozen = stanleyController.motionFrozen;
			Rigidbody component = gameObject.GetComponent<Rigidbody>();
			if (Input.GetKeyDown(118))
			{
				int num = this.noclipUse;
				if (num != 0)
				{
					if (num != 1)
					{
						MelonLogger.Msg("ERROR");
					}
					else
					{
						this.noclipUse = 0;
						stanleyController.motionFrozen = false;
						if (this.tempBucket)
						{
							this.tempBucket = false;
						}
						component.useGravity = true;
					}
				}
				else
				{
					this.noclipUse = 1;
					stanleyController.motionFrozen = true;
					if (hasbucket)
					{
						this.tempBucket = true;
					}
					component.useGravity = false;
				}
			}
			float num2;
			if (Input.GetKey(304))
			{
				num2 = 0.05f;
			}
			else
			{
				num2 = 0.03f;
			}
			if (this.noclipUse == 1)
			{
				if (Input.GetKey(119))
				{
					gameObject.transform.Translate(Vector3.forward * num2, gameObject2.transform);
				}
				if (Input.GetKey(115))
				{
					gameObject.transform.Translate(Vector3.back * num2, gameObject2.transform);
				}
				if (Input.GetKey(97))
				{
					gameObject.transform.Translate(Vector3.left * num2, gameObject2.transform);
				}
				if (Input.GetKey(100))
				{
					gameObject.transform.Translate(Vector3.right * num2, gameObject2.transform);
				}
				if (Input.GetKey(32))
				{
					gameObject.transform.Translate(Vector3.up * num2);
				}
				if (Input.GetKey(306))
				{
					gameObject.transform.Translate(Vector3.down * num2);
				}
			}
		}

		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			base.OnSceneWasLoaded(buildIndex, sceneName);
			this.noclipUse = 0;
			MelonLogger.Msg("scene: " + sceneName + " : " + this.noclipUse.ToString());
		}

		public int noclipUse;

		public bool tempBucket;
	}
}

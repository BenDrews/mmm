using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Manager : MonoBehaviour {

	  public float scrollDelay;
		public float verticalScrollSpeed;
		public float verticalScrollHeight;

    public GameObject staticAnimation;
    public GameObject kidAnimation;
    public GameObject momAnimation;
		public GameObject dadAnimation;

		public GameObject leftDialog;
		public GameObject rightDialog;

		private GameObject currAnimation;
		private String momDialogL = "This is Mrs. ✖✖. She left  ████  when she was ⓧⓧ years old, studied ☻ at ████ University, and entered the System in 19✖✖ for a better life. She currently does ✪ research at ████ Labs. She swears by the Dr. Jart+ Cicapair Tiger Grass Color Correcting Treatment SPF 30 for her daily skincare regimen and loves her new Zojirushi NSRNC10FZ rice cooker. She just wants Little ✖✖ to be happy.";
		private String momDialogR = "COMMON SIDE EFFECTS \n- Supplanting place of offspring at Harvard.\n- Early elimination of competition in Math Science / Fine Arts Sector. \n- Relaying information to the System(s) overseas.\n- Chicken feet.";

		private String dadDialogL = "This is Mr. ✖✖. He left ██████ when he was ⓧⓧ years old, studied ☻ at ████ University, and entered the System in 19✖✖ for a better life. He is currently a software engineer for ████ Corporation. His financially stable life, loving family, and brand new BMW X5 brings him happiness. He just wants Little ✖✖ to succeed.";
		private String dadDialogR = "PRODUCT DESCRIPTION \nThe Model M is the category of Yellow units operating within the System. The Model M function solely for support in the Math and Science sectors. Units function for approximately 65 years, after which productivity declines. The Model M Series: Li, Kim, Ito.";
		private String kidDialogL = "This is Little ✖✖. Little ✖✖ likes dogs, bikes, and Hollywood. Little ✖✖ doesn’t really know what’s going on; they just want to play outside.";
		private String kidDialogR = "SAFETY INSTRUCTIONS\n- Keep away from agency \n- Do not keep plugged in around personal capital. \n- Restrict units from congregating (invasion will ensue). \nWARNING: The Model M requires a significant amount of ©APITAL. This is necessary to keep units running quietly and to ensure that Black and Brown M units remain in designated levels within the ___System.";

		private bool canTransition = true;
		private float initialTextY;


    // Use this for initialization
    void Start () {
			currAnimation = Instantiate(staticAnimation, Vector3.zero, Quaternion.identity);
			initialTextY = leftDialog.transform.position.y;
    }

		public void SetMom() {
			if(canTransition) {
			  Debug.Log("Setting mom");
			  Destroy(currAnimation);
				leftDialog.transform.position = new Vector3(leftDialog.transform.position.x, initialTextY, leftDialog.transform.position.z);
				rightDialog.transform.position = new Vector3(rightDialog.transform.position.x, initialTextY, rightDialog.transform.position.z);
			  currAnimation = Instantiate(momAnimation, Vector3.zero, Quaternion.identity);
			  StartScrollingMom();
		  }
		}

		public void SetDad() {
			if(canTransition) {
			  Destroy(currAnimation);
				leftDialog.transform.position = new Vector3(leftDialog.transform.position.x, initialTextY, leftDialog.transform.position.z);
				rightDialog.transform.position = new Vector3(rightDialog.transform.position.x, initialTextY, rightDialog.transform.position.z);
			  currAnimation = Instantiate(dadAnimation, Vector3.zero, Quaternion.identity);
				StartScrollingDad();
			}
		}

		public void SetKid() {
			if(canTransition) {
			  Destroy(currAnimation);
				leftDialog.transform.position = new Vector3(leftDialog.transform.position.x, initialTextY, leftDialog.transform.position.z);
				rightDialog.transform.position = new Vector3(rightDialog.transform.position.x, initialTextY, rightDialog.transform.position.z);
			  currAnimation = Instantiate(kidAnimation, Vector3.zero, Quaternion.identity);
				StartScrollingKid();
		  }
		}

		public void SetStatic() {
			if(canTransition) {
			  Destroy(currAnimation);
				leftDialog.GetComponent<Text>().text = "";
				rightDialog.GetComponent<Text>().text = "";
			  currAnimation = Instantiate(staticAnimation, Vector3.zero, Quaternion.identity);
		  }
		}

		public void StartScrollingMom() {
			Debug.Log("Scrolling mom");
			canTransition = false;
			leftDialog.GetComponent<Text>().text = "";
			StartCoroutine("ScrollMom");
		}

		IEnumerator ScrollMom() {
			Text ld = leftDialog.GetComponent<Text>();
			Text rd = rightDialog.GetComponent<Text>();
			for(int i = 0; i <= momDialogL.Length || i <= momDialogR.Length; i++) {
				if(i <= momDialogL.Length) {
				  ld.text = momDialogL.Substring(0, i);
			  }
				if(i <= momDialogR.Length) {
				  rd.text = momDialogR.Substring(0, i);
			  }
				if(i > 0 && i % 38 == 0) {
					if(i <= momDialogL.Length - 1) {
						StartCoroutine("MoveLeftTextUp");
					}
					if(i <= momDialogR.Length - 5) {
						StartCoroutine("MoveRightTextUp");
					}
				}
				if(i >= momDialogL.Length && i >= momDialogR.Length) {
					canTransition = true;
				}
				yield return new WaitForSeconds(scrollDelay);
			}
		}


				public void StartScrollingDad() {
					canTransition = false;
					leftDialog.GetComponent<Text>().text = "";
					StartCoroutine("ScrollDad");
				}

				IEnumerator ScrollDad() {
					Text ld = leftDialog.GetComponent<Text>();
					Text rd = rightDialog.GetComponent<Text>();
					for(int i = 0; i <= dadDialogL.Length || i <= dadDialogR.Length; i++) {
						if(i <= dadDialogL.Length) {
						  ld.text = dadDialogL.Substring(0, i);
					  }
						if(i <= dadDialogR.Length) {
						  rd.text = dadDialogR.Substring(0, i);
					  }
						if(i > 0 && i % 38 == 0) {
							if(i <= dadDialogL.Length - 1) {
								StartCoroutine("MoveLeftTextUp");
							}
							if(i <= dadDialogR.Length - 4) {
								StartCoroutine("MoveRightTextUp");
							}
						}
						if(i >= dadDialogL.Length && i >= dadDialogR.Length) {
							canTransition = true;
						}
						yield return new WaitForSeconds(scrollDelay);
					}
				}

public void StartScrollingKid() {
	canTransition = false;
	leftDialog.GetComponent<Text>().text = "";
	StartCoroutine("ScrollKid");
}

IEnumerator ScrollKid() {
	Text ld = leftDialog.GetComponent<Text>();
	Text rd = rightDialog.GetComponent<Text>();
	for(int i = 0; i <= kidDialogL.Length || i <= kidDialogR.Length; i++) {
		if(i <= kidDialogL.Length) {
			ld.text = kidDialogL.Substring(0, i);
		}
		if(i <= kidDialogR.Length) {
			rd.text = kidDialogR.Substring(0, i);
		}
		if(i > 0 && i % 34 == 0) {
			if(i <= kidDialogR.Length - 35) {
				StartCoroutine("MoveRightTextUp");
			}
		}
		if(i > 0 && i % 38 == 0) {
			if(i <= kidDialogL.Length) {
				StartCoroutine("MoveLeftTextUp");
			}

		}
		if(i >= kidDialogL.Length && i >= kidDialogR.Length) {
			canTransition = true;
		}
		yield return new WaitForSeconds(scrollDelay);
	}
}



		IEnumerator MoveLeftTextUp(){
			Debug.Log("Moving left text up");
			Transform lt = leftDialog.transform;
			float targetY = lt.position.y + verticalScrollHeight;
			while(lt.position.y < targetY) {
				Debug.Log("corout");
				lt.position = new Vector3(lt.position.x, Mathf.Min(lt.position.y + verticalScrollSpeed, targetY), lt.position.z);
				yield return null;
			}
		}

		IEnumerator MoveRightTextUp(){
			Transform rt = rightDialog.transform;
			float targetY = rt.position.y + verticalScrollHeight;
			while(rt.position.y < targetY) {
				rt.position = new Vector3(rt.position.x, Mathf.Min(rt.position.y + verticalScrollSpeed, targetY), rt.position.z);
				yield return null;
			}
		}

    // Update is called once per frame
    void Update () {

    }


}

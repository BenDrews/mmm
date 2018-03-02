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
		private String momDialogL = "asidjfpiopjedsioajpfioeiopjedsioajpfioeiopjedsioajpfioeiopjedsioajpfioeiopjedsioajpfioeiopjedsioajpfioeiopjedsioajpfioeiopjedsioajpfioeiopjedsioajpfioefjpw";
		private String momDialogR = "But in response lets not talkjfpiopjedsioajpfioeiopjedsioajpfioeiopjedsioajpfioeiopjedsioajpfioeiopjedsioajpfioeiopjedsioajpfio";

		private String dadDialogL = "This is Mr. ✖✖. He left ██████ when he was ⓧⓧ years old, studied☻ at ████ University, and entered the System in 19✖✖. He is currently a software engineer for ████ Corporation. His financially stable life, loving family, and brand new [sports car] brings him happiness. He just wants Little ✖✖ to go to a good college.";
		private String dadDialogR = "dad on the right!";
		private String kidDialogL = "left kid is left out";
		private String kidDialogR = "right kid is correct";

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
				if(i > 0 && i % 54 == 0) {
					if(i <= momDialogL.Length) {
						StartCoroutine("MoveLeftTextUp");
					}
					if(i <= momDialogR.Length) {
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
						if(i > 0 && i % 54 == 0) {
							if(i <= dadDialogL.Length) {
								StartCoroutine("MoveLeftTextUp");
							}
							if(i <= dadDialogR.Length) {
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
		if(i > 0 && i % 54 == 0) {
			if(i <= kidDialogL.Length) {
				StartCoroutine("MoveLeftTextUp");
			}
			if(i <= kidDialogR.Length) {
				StartCoroutine("MoveRightTextUp");
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

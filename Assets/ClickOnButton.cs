using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class ClickOnButton : MonoBehaviour {
	
	public static int AdsCount = 0;

	public int i;
	public float size;

	public Color start;
	public Color end;

	public GameObject[] ass;
	private GameObject musobj;

	private bool iSCLickOnButton;
	private bool iSAds;

	void Start()
	{





		iSAds = true;
		if (Advertisement.isSupported) 
			Advertisement.Initialize ("1584613",false);

		i = 0;
		ass = new GameObject[2000];

	}




	public void SizeButton(string name )
	{
		ass[i] = GameObject.Find (name);
			ass[i].GetComponent<Image> ().color = end;
		i++;
		AdsCount++;
	}

	public void Musics(string name1)
	{
		musobj = GameObject.Find (name1);
			musobj.GetComponent<AudioSource>().Play ();
		Debug.Log (musobj.GetComponent<AudioSource> ().time);
		iSCLickOnButton = true;

	


	}

	public void ParticlNum(string name2)
	{
		GameObject.Find (name2).GetComponent<ParticleSystem> ().Play ();
	}


	void Update()
	{

		if (iSCLickOnButton == true) {
			
			if (musobj.GetComponent<AudioSource> ().isPlaying == false) {

				for (int j = 0; j < i; j++) {
					ass [j].GetComponent<Image> ().color = start;

				}
				iSCLickOnButton = false;
				i = 0;
			}
		
		}


		if (iSCLickOnButton == false && AdsCount / 10 == 1) {
			StartCoroutine ("ShowADS");

			AdsCount = 0;
		}
	}

	IEnumerator ShowADS(){

		yield return new WaitForSeconds (0.01f);
		while (!Advertisement.IsReady ())
			yield return null;
		Advertisement.Show ();

	}


}

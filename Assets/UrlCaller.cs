using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniGLTF;

public class UrlCaller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log (Application.persistentDataPath);
		//Debug.Log(android.content.Context.getExternalFilesDir);
		StartCoroutine(ImportObject());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator ImportObject () {

		WWW www = new WWW ("https://s3.ap-south-1.amazonaws.com/unitear/models/20190328145644.glb");
		yield return www;

	
		if (!string.IsNullOrEmpty(www.error)) {
		
			Debug.Log(www.error);
		
		}else
			{
			string write_path = Application.persistentDataPath + "Model.glb";

			System.IO.File.WriteAllBytes (write_path, www.bytes);

			Debug.Log ("Wrote to path");

			var path = write_path; // this must lead to the location of the glb file

			var context = gltfImporter.Load(path);
			context.ShowMeshes();

			GameObject root = context.Root;
			root.transform.SetParent (this.gameObject.transform);
			//Transform[] t = this.gameObject.GetComponentsInChildren<Transform> ();
			RestartAnim();
		}
	}

	void RestartAnim(){
		//to work around the bug of animation not playing, find current loaded animation clip in the animation component and play it again
		this.transform.GetChild (0).gameObject.GetComponent<Animation>().Play(this.transform.GetChild (0).gameObject.GetComponent<Animation>().clip.name);
	

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniGLTF;

public class gltfLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// this path will probably need to point to the location in the device running the UniteAR app where the glb file is fetched from the link to the db
		// It could also simply be a https link and could be used with a parser..not tested.
		var path = "C:\\Users\\asus\\Desktop\\GltfCovertedFiles\\Junkrt.glb"; // gltf, glb or zip(include gltf)

		var context = gltfImporter.Load(path);
		context.ShowMeshes();

		GameObject root = context.Root;
		root.transform.SetParent (this.gameObject.transform);
		//Transform[] t = this.gameObject.GetComponentsInChildren<Transform> ();
		RestartAnim();
	
	}

	void RestartAnim(){
	//to work around the bug of animation not playing.Find current loaded animation clip in the animation component and play it again
		//this may not be required when using an animator
		if (this.transform.GetChild (0).gameObject.GetComponent<Animation> () != null) {
			AnimationClip a = this.transform.GetChild (0).gameObject.GetComponent<Animation> ().clip;
			string animationToPlay = a.name;
			this.transform.GetChild (0).gameObject.GetComponent<Animation> ().Play (animationToPlay);
		}
	
	}
	

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frag : MonoBehaviour {

	public Mesh mesh;
	public Material material;

	private int depth;
	public int maxDepth;

	public float childScale;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<MeshFilter> ().mesh = mesh;
		gameObject.AddComponent<MeshRenderer> ().material = material;
		GetComponent<MeshRenderer>().material.color =
			Color.Lerp(Color.white, Color.yellow, (float)depth / maxDepth);
		if (depth < maxDepth) {
			StartCoroutine (createChildren ());
		}
	}	

	private IEnumerator createChildren(){
		yield return new WaitForSeconds(0.5f);
		new GameObject ("Child").AddComponent<Frag> ().initialize (this, Vector3.up, Quaternion.identity);
		yield return new WaitForSeconds(0.5f);
		new GameObject ("Child").AddComponent<Frag> ().initialize (this, Vector3.down, Quaternion.Euler(0f,0f,90f));
		yield return new WaitForSeconds(0.5f);
		new GameObject ("Child").AddComponent<Frag> ().initialize (this, Vector3.left,Quaternion.Euler(0f,0f,-90f));

	}
	private void initialize(Frag parent, Vector3 direction, Quaternion orientation){
	
		mesh = parent.mesh;
		material = parent.material;
		depth = parent.depth + 1;
		maxDepth = parent.maxDepth;
		transform.parent = parent.transform;
		childScale = parent.childScale;
		transform.localScale = Vector3.one * childScale;
		transform.localPosition = direction * (0.5f + 0.5f * childScale);
		transform.localRotation = orientation;
	}

	// Update is called once per frame
	void Update () {
		
	}
}

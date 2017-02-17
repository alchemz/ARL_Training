using UnityEngine;
using System.Collections;

public class Fragment : MonoBehaviour {
	public Mesh mesh;
	public Material material;
	private int depth;
	public int maxDepth;
	public float childScale;
	void Start(){
		gameObject.AddComponent<MeshFilter> ().mesh = mesh;
		gameObject.AddComponent<MeshRenderer>().material = material;
		if (depth < maxDepth) {
			StartCoroutine(createChild());
		}
		GetComponent<MeshRenderer> ().material.color =
			Color.Lerp (Color.white, Color.yellow, (float)depth/maxDepth);
	}

	private IEnumerator createChild()
	{
		for (int i = 0; i < childDirection.Length; i++) {
			yield return new WaitForSeconds (1f);
			new GameObject ("Child").AddComponent<Fragment> ().initialize (this, i);
		}
	}

	private static Vector3[] childDirection = {
		Vector3.up,
		Vector3.down,
		Vector3.left
	};
	private static Quaternion[] childOrientation = {
		Quaternion.identity,
		Quaternion.Euler(0f,0f,90f),
		Quaternion.Euler(0f,0f,-90f)
	};
	private void initialize(Fragment parent, int childIndex){
		mesh = parent.mesh;
		material = parent.material;
		depth = parent.depth + 1;
		maxDepth = parent.maxDepth;
		transform.parent = parent.transform;
		childScale = parent.childScale;
		transform.localPosition = childDirection[childIndex]*(0.5f+0.5f*childScale);
		transform.localScale = Vector3.one * childScale;
		transform.localRotation = childOrientation[childIndex];
	}
}

/*
 * Copyright (c) 2015 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

  public float acceleration;
  public float maxSpeed;

  private Rigidbody rigidBody;
  private KeyCode[] inputKeys;
  private Vector3[] directionsForKeys;

	void Start () {
    inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    directionsForKeys = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
    rigidBody = GetComponent<Rigidbody>();
	}
	
  void FixedUpdate () {
    for (int i = 0; i < inputKeys.Length; i++){
      var key = inputKeys[i];

      if(Input.GetKey(key)) {
        Vector3 movement = directionsForKeys[i] * acceleration * Time.deltaTime;
        movePlayer(movement);
      }
    }
  }

  void movePlayer(Vector3 movement) {
    if(rigidBody.velocity.magnitude * acceleration > maxSpeed) {
      rigidBody.AddForce(movement * -1);
    }
    else {
      rigidBody.AddForce(movement);
    }
  }

}

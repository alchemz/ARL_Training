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
using System;

public class GameController : MonoBehaviour {

  public EnemyProducer enemyProducer;
  public GameObject playerPrefab;

	void Start () {
    var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    player.onPlayerDeath += onPlayerDeath;
	}
	
  void onPlayerDeath(Player player) {
    enemyProducer.SpawnEnemies(false);
    Destroy(player.gameObject);

    Invoke("restartGame", 3);
  }

  void restartGame() {
    var enemies = GameObject.FindGameObjectsWithTag("Enemy");
    foreach (var enemy in enemies)
    {
      Destroy(enemy);
    }

    var playerObject = Instantiate(playerPrefab, new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
    var cameraRig = Camera.main.GetComponent<CameraRig>();
    cameraRig.target = playerObject;
    enemyProducer.SpawnEnemies(true);
    playerObject.GetComponent<Player>().onPlayerDeath += onPlayerDeath;
  }
}

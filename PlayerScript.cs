using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    public int speed;
    private bool canEncounter = true;
    public bool GetCanEncounter() { return canEncounter; }
    public void SetCanEncounter(bool canEncounter_) { canEncounter = canEncounter_; }
    
    void Start () {

        if (SceneManager.GetActiveScene().name == "World") {
            transform.position = new Vector2(PlayerPrefs.GetFloat("playerX"), PlayerPrefs.GetFloat("playerY"));
        }
        StartCoroutine(IFrames());
	}
    
    void Update() {

        if (Input.GetKey(KeyCode.W)) {

            Vector3 Dir = new Vector3(0, speed, 0);
            transform.position += Dir * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) {

            Vector3 Dir = new Vector3(0, -speed, 0);
            transform.position += Dir * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) {

            Vector3 Dir = new Vector3(speed, 0, 0);
            transform.position += Dir * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) {

            Vector3 Dir = new Vector3(-speed, 0, 0);
            transform.position += Dir * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "bullet") {

            PlayerPrefs.SetFloat("playerX", 0.0f);
            PlayerPrefs.SetFloat("playerY", 0.0f);
            SceneManager.LoadScene(4);
        }
    }

    private IEnumerator IFrames() {

        SetCanEncounter(false);
        yield return new WaitForSeconds(2);
        SetCanEncounter(true);
        StopAllCoroutines();
    }
}

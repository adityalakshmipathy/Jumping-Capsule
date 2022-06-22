using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool dead = false;
    [SerializeField] AudioSource deathSound;

    void Update() {
        if (transform.position.y < -1f && !dead) {
            Die();   
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy Body")) {
             GetComponent<MeshRenderer>().enabled = false; // hide player
            GetComponent<Rigidbody>().isKinematic = true; // fix position of player
            GetComponent<PlayerMovement>().enabled = false; // disable movement of player
            Die();
        }
    }

    void Die() {
        Invoke(nameof(RestoreLevel), 1.3f);
        dead = true;
        deathSound.Play();
    }

    void RestoreLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

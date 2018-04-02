using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public Text deadText;
	public int startHealth = 3;
	public int currentHealth;
	public float flashSpeed = 5f;
	public Color flashColor = new Color (1f, 0f, .1f);
	public Image damageImage;
	public Slider healthSlider;
	//public GameObject button;
	bool isDead;
	bool damaged;
	Player_movement playerMovement;
	//Fire playerShooting;

	// Use this for initialization
	void Start () {
		currentHealth = startHealth;
		playerMovement = GetComponent <Player_movement> ();
		deadText.text = " ";
		//button.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageImage.color = flashColor;
		} 
		else 
		{
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	void OnCollisionEnter(Collision hit)
	{
		if (hit.gameObject.tag == "Enemy")
			TakeDamage (1);
	}

	public void TakeDamage(int amount)
	{
		amount = 1;
		damaged = true;

		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

//	void OnGUI()
//	{
	//	if (GUI.Button (new Rect (origin_x, origin_y + buttonHeight + 10, buttonWidth, buttonHeight), "You Have Died")) {
	//		SceneManager.LoadScene (0);
	//	}
	//}

	void Death()
	{
		isDead = true;
		playerMovement.enabled = false;
		//button.gameObject.SetActive (true);
		deadText.text = "You Died";
		//playerShooting.enabled = false;
	}

}

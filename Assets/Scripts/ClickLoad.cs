using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickLoad : MonoBehaviour {


	public void LoadScene(int lvl){

		SceneManager.LoadScene(lvl);
	}
}

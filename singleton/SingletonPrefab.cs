using UnityEngine;

/// <summary>
/// SingletonPrefab allows you to call [Tname].Instance anywhere and have the 
/// prefab instantiated at run-time if it does not already exist in the scene.
/// IMPORTANT: This only works if you have named your prefab the exact same name as the class name of T.
/// </summary>
public abstract class SingletonPrefab<T> : MonoBehaviour where T : MonoBehaviour {
	
	public bool dontDestroyOnLoad = false;
	public bool logSingleton = true;

	private static T _instance;
	public static T Instance { 
		get {
			if (_instance == null) {
				Debug.Log ("[SingletonObj] Instantiating new " + typeof(T) + " instance.");	
				string n = typeof(T).Name;
				_instance = Instantiate (Resources.Load<T> (n));
				_instance.name = "[SingletonObj] " + n;
			}
			return _instance; 
		}
	}

	void Awake () {

		if (_instance == null) {
			_instance = this.GetComponent<T> ();
			if (logSingleton) 
				Debug.Log("[SingletonObj] An instance of " + typeof(T) + " was found in the scene.", this);	
		}
		else if (Instance.GetHashCode () != this.GetComponent<T> ().GetHashCode ()) {
			if (logSingleton) 
				Debug.LogWarning ("[SingletonObj] Destroying duplicate instance of type " + typeof(T) + ".");	
			Destroy (this.gameObject);
			return;
		}

		if (dontDestroyOnLoad) {
			if (logSingleton) 
				Debug.Log ("[SingletonObj] Marking " + typeof(T) + " as DontDestroyOnLoad.", this);	
			DontDestroyOnLoad (this.gameObject);
		}
	}

	void OnDestroy () {
		if (_instance != null && _instance.GetHashCode () == this.GetComponent<T> ().GetHashCode ()) {
			if (logSingleton) 
				Debug.Log ("[SingletonObj] Destroying main instance of " + typeof(T) + ".");	
			_instance = null;
		}
	}
}

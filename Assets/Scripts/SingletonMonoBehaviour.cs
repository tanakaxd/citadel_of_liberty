using UnityEngine;
using System.Collections;

//https://gist.github.com/tsubaki/e0406377a1b014754894

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
	protected static T instance;
	public static T Instance {
		get {
			if (instance == null) {
				instance = (T)FindObjectOfType (typeof(T));
				
				if (instance == null) {
					Debug.LogWarning (typeof(T) + "is nothing");
				}
			}
			
			return instance;
		}
	}
	
	protected virtual void Awake()//元ファイルにvirtualを付け加えた
	{
		CheckInstance();
	}
	
	protected bool CheckInstance()
	{
		if( instance == null)
		{
			instance = (T)this;
			return true;
		}else if( Instance == this )
		{
			return true;
		}

		Destroy(this);
		return false;
	}
}

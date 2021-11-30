using UnityEngine;
[CreateAssetMenu]
public class ModelEffectAnimation : ScriptableObject
{
	public RuntimeAnimatorController Controller;
	public bool Blend;
	public Vector3 Offset = Vector3.zero;
	public Vector2 BackOffset = Vector2.zero;
	public Vector2 ForeOffset = Vector2.zero;
}


using System.Collections;
using UnityEngine;

public class SimpleMoveCurve : MonoBehaviour
{
  public AnimationCurve ac;
  public Vector3 pos1 = new Vector3(-4.0f, 0.0f, 0.0f);
  public Vector3 pos2 = new Vector3( 4.0f, 0.0f, 0.0f);

  private bool isAnimationRunning=false;
  private void Update()
  {
    if (Input.GetKeyDown (KeyCode.Space)) {
      StartCoroutine(UsingAnimationCurve(pos1, pos2,  3.0f));
    }
  }
  IEnumerator UsingAnimationCurve(Vector3 startPosition, Vector3 endPosition, float time)   {
    if (!isAnimationRunning){
      isAnimationRunning = true;
      float i = 0.0f;
      float rate = 1 / time;
      while (i < 1)
      {
        i += Time.deltaTime * rate;
        transform.localPosition=Vector3.Lerp(startPosition,endPosition, ac.Evaluate(i));
        yield return 0;
      }
      isAnimationRunning = false;
    }
    yield return 0;
  }

}

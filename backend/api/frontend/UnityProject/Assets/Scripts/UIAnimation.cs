using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public float animationSpeed = 2.0f;  // Velocidad de la animación
    private Vector3 originalScale;       // Escala original del objeto
    private bool isAnimating = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void StartAnimation()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            StartCoroutine(ScaleAnimation());
        }
    }

    private IEnumerator ScaleAnimation()
    {
        float elapsed = 0f;
        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * animationSpeed;
            transform.localScale = Vector3.Lerp(originalScale, originalScale * 1.2f, Mathf.PingPong(elapsed, 1f));
            yield return null;
        }
        transform.localScale = originalScale;
        isAnimating = false;
    }
}

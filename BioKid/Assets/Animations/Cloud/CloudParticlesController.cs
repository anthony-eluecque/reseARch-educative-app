using UnityEngine;

public class CloudParticlesController : MonoBehaviour
{
    public ParticleSystem cloudParticleSystem;
    public Color startColor = Color.white;
    public Color endColor = Color.black;
    public float transitionTime = 30f; // Temps en secondes pour passer de la couleur de départ à la couleur de fin

    private float elapsedTime = 0f;

    void Start()
    {
        // Assurez-vous que le système de particules est attribué
        if (cloudParticleSystem == null)
        {
            Debug.LogError("Veuillez assigner le système de particules dans l'inspecteur.");
            enabled = false; // Désactivez le script s'il y a une erreur
        }

        // Définissez la couleur initiale du système de particules
        var mainModule = cloudParticleSystem.main;
        mainModule.startColor = startColor;
    }

    void Update()
    {
        // Incrémente le temps écoulé
        elapsedTime += Time.deltaTime;

        // Calcule le facteur d'interpolation entre 0 et 1
        float lerpFactor = Mathf.Clamp01(elapsedTime / transitionTime);

        // Interpole entre la couleur de départ et la couleur de fin
        Color lerpedColor = Color.Lerp(startColor, endColor, lerpFactor);

        // Met à jour la couleur du système de particules
        var mainModule = cloudParticleSystem.main;
        mainModule.startColor = lerpedColor;

        // Si le temps de transition est écoulé, réinitialise le temps écoulé
        if (elapsedTime >= transitionTime)
        {
            elapsedTime = 0f;
        }
    }
}
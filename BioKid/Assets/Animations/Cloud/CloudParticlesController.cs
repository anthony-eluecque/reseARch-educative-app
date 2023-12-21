using UnityEngine;

public class CloudParticlesController : MonoBehaviour
{
    public ParticleSystem cloudParticleSystem;
    public Color startColor = Color.white;
    public Color endColor = Color.black;
    public float transitionTime = 30f; // Temps en secondes pour passer de la couleur de d�part � la couleur de fin

    private float elapsedTime = 0f;

    void Start()
    {
        // Assurez-vous que le syst�me de particules est attribu�
        if (cloudParticleSystem == null)
        {
            Debug.LogError("Veuillez assigner le syst�me de particules dans l'inspecteur.");
            enabled = false; // D�sactivez le script s'il y a une erreur
        }

        // D�finissez la couleur initiale du syst�me de particules
        var mainModule = cloudParticleSystem.main;
        mainModule.startColor = startColor;
    }

    void Update()
    {
        // Incr�mente le temps �coul�
        elapsedTime += Time.deltaTime;

        // Calcule le facteur d'interpolation entre 0 et 1
        float lerpFactor = Mathf.Clamp01(elapsedTime / transitionTime);

        // Interpole entre la couleur de d�part et la couleur de fin
        Color lerpedColor = Color.Lerp(startColor, endColor, lerpFactor);

        // Met � jour la couleur du syst�me de particules
        var mainModule = cloudParticleSystem.main;
        mainModule.startColor = lerpedColor;

        // Si le temps de transition est �coul�, r�initialise le temps �coul�
        if (elapsedTime >= transitionTime)
        {
            elapsedTime = 0f;
        }
    }
}
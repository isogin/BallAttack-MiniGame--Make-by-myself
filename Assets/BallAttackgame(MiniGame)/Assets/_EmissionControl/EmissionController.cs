using UnityEngine;

public class EmissionController : MonoBehaviour
{
    Material m_mat = null;
    Color m_defaultColor = Color.white;
    public float m_minEmission = 0f;
    public float m_maxEmission = 1000f;
    public float m_gradient = 7000f;
    float m_emission = -10f;
    float m_lastEmission;

    void Start()
    {
        m_mat = GetComponent<Renderer>().material;
        m_defaultColor = m_mat.GetColor("_EmissionColor");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_emission = Mathf.Min(m_emission + m_gradient * Time.deltaTime, m_maxEmission);
        }
        else
        {
            m_emission = Mathf.Max(m_emission - m_gradient * Time.deltaTime, m_minEmission);
        }

        if (m_emission != m_lastEmission)
        {
            Color emissionColor = m_defaultColor * m_emission;
            m_mat.SetColor("_EmissionColor", emissionColor);
            m_lastEmission = m_emission;
        }
    }
}

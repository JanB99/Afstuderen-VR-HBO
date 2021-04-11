using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LWRP;
using UnityEngine.Rendering.Universal;

public class MultipleScleroseController : MonoBehaviour
{

    public enum Gradation
    {
        gradation1,
        gradation2,
        gradation3,
        gradation4,
        gradation5,
    };

    public enum Gender { 
        male, 
        female
    }

    public static MultipleScleroseController instance;

    public Gradation setAll;

    public Gradation anxietyAndDepression;
    public Gradation opticNeuritis;
    public Gradation fatique;
    public Gradation coordination;
    public Gradation bladdercontrol;

    public Gender gender;

    public List<AnxietyDepressionPreset> anxietyDepressionPresets;
    public List<OpticNeuritisPreset> opticNeuritisPresets;

    void Start()
    {
        instance = this;
        EnablePresets();
    }

    public void EnablePresets() {
        EnableAnxietyDepressionPreset();
        EnableOpticNeuritisPreset();
        EnableFatiquePreset();
        EnableCoordinationPreset();
        EnableBladdercontrolPreset();
    }

    public void SetAllGradations()
    {
        anxietyAndDepression = setAll;
        opticNeuritis = setAll;
        fatique = setAll;
        coordination = setAll;
        bladdercontrol = setAll;
    }

    void EnableAnxietyDepressionPreset()
    {
        AnxietyDepressionPreset preset = anxietyDepressionPresets[(int)anxietyAndDepression];

        ParticleSystemController.instance.SetRainEmissionRate(preset.numRainParticles);
        ParticleSystemController.instance.SetMistEmissionRate(preset.numMistParticles);
        if (preset.numRainParticles > 0)
        {
            AudioManager.instance.SetVolume("Rain", .2f);
            AudioManager.instance.Play("Rain");
        }
        RenderSettings.skybox = preset.skybox;
        if (preset.numMistParticles > 0) RenderSettings.fog = true;
        if (preset.interval > 0) AudioManager.instance.IntervalVoicelines(preset.interval * 60);

        GameObject.FindGameObjectWithTag("Billboard").SetActive(preset.billboard);
        GameObject.FindGameObjectWithTag("Wheelchair").SetActive(preset.wheelchair);
        GameObject.FindGameObjectWithTag("Medicine")?.SetActive(preset.bottles);
        //zelfde doen maar dan voor rolstoel
        GameObject.FindGameObjectWithTag("Cemetary")?.gameObject.SetActive(preset.hasCemetary);
        GameObject.FindGameObjectWithTag("Playground")?.gameObject.SetActive(!preset.hasCemetary);
    }

    void EnableOpticNeuritisPreset()
    {

        OpticNeuritisPreset preset = opticNeuritisPresets[(int)opticNeuritis];

        RenderPipelineAsset pipeline = ((UniversalRenderPipelineAsset)GraphicsSettings.renderPipelineAsset);
        FieldInfo propertyInfo = pipeline.GetType().GetField("m_RendererDataList", BindingFlags.Instance | BindingFlags.NonPublic);
        ScriptableRendererData forwardRenderer = ((ScriptableRendererData[])propertyInfo?.GetValue(pipeline))?[0];
        ScriptableRendererFeature feature = forwardRenderer.rendererFeatures[0];

        Material mat = ((Blit)feature).settings.blitMaterial;
        mat.SetFloat("_BlurAmount", preset.blurAmount);
        mat.SetFloat("_Scale", preset.scale);
        mat.SetInt("_IsBlurred", preset.voidVision ? 0 : 1);
        if (preset.fieldDefects.Count != 0)
        {
            int index = Random.Range(0, preset.fieldDefects.Count);
            mat.SetTexture("_BlurTex", preset.fieldDefects[index]);
        }
        else
        {
            mat.SetTexture("_BlurTex", null);
        }

        forwardRenderer.SetDirty();
    }

    void EnableFatiquePreset()
    {
    }

    void EnableCoordinationPreset()
    {

    }
    void EnableBladdercontrolPreset()
    {

    }
}



Shader "Unlit/MaskGenerator"
{
    Properties
    {
        _FadeFactor("FadeFactor", float) = 0.1
        _Strength("Strength", float) = 0.1
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }

        CGINCLUDE
        #include "UnityCG.cginc"

        sampler2D _Composite; 
        sampler2D _Diff;

        float _Strength;
        float _FadeFactor;

        float4 accumulation(v2f_img i) : SV_Target{
            float4 col = tex2D(_Composite, i.uv);
            col += _Strength * tex2D(_Diff, i.uv);
            col -= _FadeFactor;
            return saturate(col);
        }

        ENDCG

        Pass
        {
            CGPROGRAM
            #pragma target 5.0
            #pragma vertex vert_img
            #pragma fragment accumulation
            ENDCG
        }
    }
}
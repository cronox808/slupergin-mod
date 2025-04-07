sampler2D TextureSampler : register(s0);

float4x4 MatrixTransform;
float3 ColorShift = float3(1.2, 1.1, 0.6);

float4 DevouriaShader(float2 uv : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(TextureSampler, uv);
    color.rgb *= ColorShift;
    return color;
}

technique DevouriaShader
{
    pass P0
    {
        PixelShader = compile ps_2_0 DevouriaShader();
    }
}

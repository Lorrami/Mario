using SFML.Graphics;
using SFML.System;

class LevelRenderer
{
    private RenderWindow _window;
    private RenderTexture[] _rt = new RenderTexture[8];
    
    private static Vertex[] _unitQuadVertices = 
    {
        new Vertex(new Vector2f(1, 1), Color.White, new Vector2f(1, 1)),
        new Vertex(new Vector2f(-1, 1), Color.White, new Vector2f(0, 1)),
        new Vertex(new Vector2f(1, -1), Color.White, new Vector2f(1, 0)),
        new Vertex(new Vector2f(-1, -1), Color.White, new Vector2f(0, 0)),
    };
    
    private Shader _combineShader;
    private Shader _undersampleShader;
    
    
    public LevelRenderer(RenderWindow window)
    {
        _window = window;
        
        for(int i = 0; i<_rt.Length; i++)
        {
            Vector2u currentRTSize = new Vector2u((uint)(_window.Size.X / Math.Pow(2, i)), (uint)(_window.Size.Y / Math.Pow(2, i)));
            
            _rt[i] = new RenderTexture(currentRTSize.X, currentRTSize.Y);
            _rt[i].Smooth = true;
        };
        _combineShader = Shader.FromString(ShaderSources.CombineShaderVertex, null, ShaderSources.CombineShaderFragment);
        _undersampleShader = Shader.FromString(ShaderSources.UndersampleShaderVertex, null, ShaderSources.UndersampleShaderFragment);

    }

    public void Render(Level level)
    {
        _rt[0].Clear();
        level.Render(_rt[0]);

        for (int i = 0; i < _rt.Length - 1; i++)
        {
            SampleTo(_rt[i].Texture, _rt[i + 1]);
        }

        RenderStates states = RenderStates.Default;
        states.Shader = _combineShader;
        for (int i = 0; i < _rt.Length; i++)
        {
            states.Shader.SetUniform($"u_Textures[{i}]", _rt[i].Texture);
        }

        _window.Draw(_unitQuadVertices, PrimitiveType.TriangleStrip, states);
    }

    public void SwapBuffers()
    {
        _window.Display();
    }
    
    private void SampleTo(Texture prev, RenderTexture current)
    {
        RenderStates states = RenderStates.Default;
        states.Shader = _undersampleShader;
        states.Shader.SetUniform("u_Texture", prev);
        current.Draw(_unitQuadVertices, PrimitiveType.TriangleStrip, states);
    }
}

class ShaderSources
{
          
    public const string UndersampleShaderVertex = @"
#version 130

void main()
{
    // transform the vertex position
    gl_Position = gl_Vertex;

    gl_TexCoord[0] = gl_TextureMatrix[0] * gl_MultiTexCoord0;

    // forward the vertex color
    gl_FrontColor = gl_Color;
}";

    public const string UndersampleShaderFragment = @"
#version 130

uniform sampler2D u_Texture;

void main()
{
    gl_FragColor = gl_Color * texture(u_Texture, gl_TexCoord[0].xy);
}
";  
    
        
    public const string CombineShaderVertex = @"
#version 130

void main()
{
    // transform the vertex position
    gl_Position = gl_Vertex;

    gl_TexCoord[0] = gl_TextureMatrix[0] * gl_MultiTexCoord0;

    // forward the vertex color
    gl_FrontColor = gl_Color;
}";

    public const string CombineShaderFragment = @"
#version 130

uniform sampler2D u_Textures[8];

vec4 cubic(float v){
    vec4 n = vec4(1.0, 2.0, 3.0, 4.0) - v;
    vec4 s = n * n * n;
    float x = s.x;
    float y = s.y - 4.0 * s.x;
    float z = s.z - 4.0 * s.y + 6.0 * s.x;
    float w = 6.0 - x - y - z;
    return vec4(x, y, z, w) * (1.0/6.0);
}

vec4 GetFilteredValue(sampler2D sampler, vec2 texCoords){

   vec2 texSize = textureSize(sampler, 0);
   vec2 invTexSize = 1.0 / texSize;

   texCoords = texCoords * texSize - 0.5;


    vec2 fxy = fract(texCoords);
    texCoords -= fxy;

    vec4 xcubic = cubic(fxy.x);
    vec4 ycubic = cubic(fxy.y);

    vec4 c = texCoords.xxyy + vec2 (-0.5, +1.5).xyxy;

    vec4 s = vec4(xcubic.xz + xcubic.yw, ycubic.xz + ycubic.yw);
    vec4 offset = c + vec4 (xcubic.yw, ycubic.yw) / s;

    offset *= invTexSize.xxyy;

    vec4 sample0 = texture(sampler, offset.xz);
    vec4 sample1 = texture(sampler, offset.yz);
    vec4 sample2 = texture(sampler, offset.xw);
    vec4 sample3 = texture(sampler, offset.yw);

    float sx = s.x / (s.x + s.y);
    float sy = s.z / (s.z + s.w);

    return mix(
       mix(sample3, sample2, sx), mix(sample1, sample0, sx)
    , sy);
}

void main()
{
    vec4 acc = vec4(0.0);
    acc += GetFilteredValue(u_Textures[0], gl_TexCoord[0].xy);
    acc += GetFilteredValue(u_Textures[1], gl_TexCoord[0].xy);
    acc += GetFilteredValue(u_Textures[2], gl_TexCoord[0].xy);
    acc += GetFilteredValue(u_Textures[3], gl_TexCoord[0].xy);
    acc += GetFilteredValue(u_Textures[4], gl_TexCoord[0].xy);
    acc += GetFilteredValue(u_Textures[5], gl_TexCoord[0].xy);
    acc += GetFilteredValue(u_Textures[6], gl_TexCoord[0].xy);
    acc += GetFilteredValue(u_Textures[7], gl_TexCoord[0].xy);
    //gl_FragColor = gl_Color * GetFilteredValue(u_Textures[4], gl_TexCoord[0].xy);
    gl_FragColor = gl_Color * acc;
}
";
}
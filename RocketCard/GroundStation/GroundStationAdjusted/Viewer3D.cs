using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Assimp;
using Assimp.Configs;
using OpenTK.Graphics;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace GroundStationAdjusted
{
    internal class Viewer3D
    {
        double rotx, roty, rotz, posz;
        private int m_displayList;
        private int m_texId;
        Matrix4 RotationX = new Matrix4();
        Matrix4 RotationY = new Matrix4();
        Matrix4 RotationZ = new Matrix4();
        Matrix4 Rotation = new Matrix4();

        float[] SerialData;

        float[] ambientLight = { 0.2f, 0.2f, 0.2f, 1.0f };
        float[] diffuseLight = { 0.5f, 0.5f, 0.5f, 1.0f };
        float[] specularLight = { 1.0f, 1.0f, 1.0f, 1.0f };
        float[] lightpos0 = { 100.0f, 0.0f, 0.0f, -1.0f };
        float[] lightpos1 = { 100.0f, 0.0f, 0.0f, 1.0f };
        bool serialOpen;
        private Scene m_model;
        private GLControl OpenGlControl;
        private RotationMatrixCalculator RotationMatrixCalculator;
        private int RotationType;
        public Viewer3D(GLControl tempGL, float[] serialData, string obj_name, int rotationTypetemp)
        {
            RotationX = Matrix4.Identity;
            RotationY= Matrix4.Identity;
            RotationZ = Matrix4.Identity;
            RotationType = rotationTypetemp;
            
            String fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), obj_name);
            AssimpContext importer = new AssimpContext();
            importer.SetConfig(new NormalSmoothingAngleConfig(66.0f));
            m_model = importer.ImportFile(fileName, PostProcessPreset.TargetRealTimeMaximumQuality);
            OpenGlControl = tempGL;
            OpenGlControl.SwapBuffers(); 
            RotationMatrixCalculator = new RotationMatrixCalculator();
        }

        public void getSerialData(float[] SerialDataTemp, bool serialOpenTemp)
        {
            serialOpen = serialOpenTemp;
            SerialData = SerialDataTemp;
        }
        public void MyPaint(object sender, PaintEventArgs e)
        {
            initiliazeLights();
            initiliazeCamera();
            float tmp = 0.1491525f;
            GL.Scale(tmp * 2.2, tmp * 2, tmp * 2);
            GL.Translate(-0, -15.4028, 0.00000190734);
            GL.MatrixMode(MatrixMode.Modelview);

            if (RotationType == 1 && serialOpen)
            {
                Vector3 EularAngles = new Vector3();
                if (SerialData != null)
                {
                    EularAngles.X = -SerialData[10];
                    EularAngles.Y = -SerialData[9];
                    EularAngles.Z = SerialData[11];
                }

                (RotationX, RotationY, RotationZ) = RotationMatrixCalculator.EularToRotationMatrix(EularAngles);
                GL.MultMatrix(ref RotationX);
                GL.MultMatrix(ref RotationY);
                GL.MultMatrix(ref RotationZ);
            }
            


            GL.Rotate(Convert.ToSingle(rotx) % 360, 1.0f, 0.0f, 0.0f);
            GL.Rotate(Convert.ToSingle(roty) % 360, 0.0f, 1.0f, 0.0f);
            GL.Rotate(Convert.ToSingle(rotz) % 360, 0.0f, 0.0f, 1.0f);   

            if (m_displayList == 0)
            {
                m_displayList = GL.GenLists(1);
                GL.NewList(m_displayList, ListMode.Compile);
                RecursiveRender(m_model, m_model.RootNode);
                GL.EndList();
            }

            GL.CallList(m_displayList);
            OpenGlControl.SwapBuffers();
        }

        private void RecursiveRender(Scene scene, Node node)
        {
            Matrix4 m = FromMatrix(node.Transform);
            m.Transpose();
            GL.PushMatrix();
            GL.MultMatrix(ref m);

            if (node.HasMeshes)
            {
                foreach (int index in node.MeshIndices)
                {
                    Mesh mesh = scene.Meshes[index];
                    ApplyMaterial(scene.Materials[mesh.MaterialIndex]);

                    if (mesh.HasNormals)
                    {
                        GL.Enable(EnableCap.Lighting);
                    }
                    else
                    {
                        GL.Disable(EnableCap.Lighting);
                    }

                    bool hasColors = mesh.HasVertexColors(0);
                    if (hasColors)
                    {
                        GL.Enable(EnableCap.ColorMaterial);
                    }
                    else
                    {
                        GL.Disable(EnableCap.ColorMaterial);
                    }

                    bool hasTexCoords = mesh.HasTextureCoords(0);

                    foreach (Face face in mesh.Faces)
                    {
                        BeginMode faceMode;
                        switch (face.IndexCount)
                        {
                            case 1:
                                faceMode = BeginMode.Points;
                                break;
                            case 2:
                                faceMode = BeginMode.Lines;
                                break;
                            case 3:
                                faceMode = BeginMode.Triangles;
                                break;
                            default:
                                faceMode = BeginMode.Polygon;
                                break;
                        }

                        GL.Begin(faceMode);
                        for (int i = 0; i < face.IndexCount; i++)
                        {
                            int indice = face.Indices[i];
                            if (hasColors)
                            {
                                Color4 vertColor = FromColor(mesh.VertexColorChannels[0][indice]);
                            }
                            if (mesh.HasNormals)
                            {
                                Vector3 normal = FromVector(mesh.Normals[indice]);
                                GL.Normal3(normal);
                            }
                            if (hasTexCoords)
                            {
                                Vector3 uvw = FromVector(mesh.TextureCoordinateChannels[0][indice]);
                                GL.TexCoord2(uvw.X, 1 - uvw.Y);
                            }
                            Vector3 pos = FromVector(mesh.Vertices[indice]);
                            GL.Vertex3(pos);
                        }
                        GL.End();
                    }
                }
            }

            for (int i = 0; i < node.ChildCount; i++)
            {
                RecursiveRender(m_model, node.Children[i]);
            }
        }

        private void LoadTexture(String fileName)
        {
            fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            if (!File.Exists(fileName))
            {
                return;
            }

            System.Drawing.Bitmap textureBitmap = new System.Drawing.Bitmap(fileName);
            BitmapData TextureData =
                    textureBitmap.LockBits(
                    new System.Drawing.Rectangle(0, 0, textureBitmap.Width, textureBitmap.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb
                );
            m_texId = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, m_texId);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, textureBitmap.Width, textureBitmap.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, TextureData.Scan0);
            textureBitmap.UnlockBits(TextureData);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        }

        private void ApplyMaterial(Material mat)
        {
            if (mat.GetMaterialTextureCount(TextureType.Diffuse) > 0)
            {
                TextureSlot tex;
                if (mat.GetMaterialTexture(TextureType.Diffuse, 0, out tex))
                    LoadTexture(tex.FilePath);
            }

            Color4 color = new Color4(.8f, .8f, .8f, 1.0f);
            if (mat.HasColorDiffuse)
            {
                // color = FromColor(mat.ColorDiffuse);
            }
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Diffuse, color);

            color = new Color4(0, 0, 0, 1.0f);
            if (mat.HasColorSpecular)
            {
                color = FromColor(mat.ColorSpecular);
            }
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, color);

            color = new Color4(.2f, .2f, .2f, 1.0f);
            if (mat.HasColorAmbient)
            {
                color = FromColor(mat.ColorAmbient);
            }
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Ambient, color);

            color = new Color4(0, 0, 0, 1.0f);
            if (mat.HasColorEmissive)
            {
                color = FromColor(mat.ColorEmissive);
            }
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Emission, color);

            float shininess = 1;
            float strength = 1;
            if (mat.HasShininess)
            {
                shininess = mat.Shininess;
            }
            if (mat.HasShininessStrength)
            {
                strength = mat.ShininessStrength;
            }

            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, shininess * strength);
        }

        private Matrix4 FromMatrix(Matrix4x4 mat)
        {
            Matrix4 m = new Matrix4();
            m.M11 = mat.A1;
            m.M12 = mat.A2;
            m.M13 = mat.A3;
            m.M14 = mat.A4;
            m.M21 = mat.B1;
            m.M22 = mat.B2;
            m.M23 = mat.B3;
            m.M24 = mat.B4;
            m.M31 = mat.C1;
            m.M32 = mat.C2;
            m.M33 = mat.C3;
            m.M34 = mat.C4;
            m.M41 = mat.D1;
            m.M42 = mat.D2;
            m.M43 = mat.D3;
            m.M44 = mat.D4;
            return m;
        }

        private Color4 FromColor(Color4D color)
        {
            Color4 c;
            c.R = color.R;
            c.G = color.G;
            c.B = color.B;
            c.A = color.A;
            return c;
        }

        private Vector3 FromVector(Vector3D vec)
        {
            Vector3 v;
            v.X = vec.X;
            v.Y = vec.Y;
            v.Z = vec.Z;
            return v;
        }

        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.A):
                    roty += 1; break;
                case (Keys.D):
                    roty -= 1; break;
                case (Keys.W):
                    rotx += 1; break;
                case (Keys.S):
                    rotx -= 1; break;
            }
            rotx = rotx % 360;
            roty = roty % 360;
            rotz = rotz % 360;
            OpenGlControl.Refresh();
        }

        public void MyPreviewKwyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case (Keys.Up):
                    posz++; break;
                case (Keys.Down):
                    posz--; break;
                case (Keys.Left):
                    rotz += 5.0; break;
                case (Keys.Right):
                    rotz -= 5.0; break;
                default:
                    break;
            }
            rotz = rotz % 360;
            OpenGlControl.Refresh();
        }

        private void initiliazeCamera()
        {
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(0.785398f, 1.0f, 1.0f, 100f);
            Matrix4 lookat = Matrix4.LookAt(40, 8, 0, 0, -2, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadIdentity();
            GL.LoadMatrix(ref lookat);
            GL.Viewport(0, 0, OpenGlControl.Width, OpenGlControl.Height);
        }

        private void initiliazeLights()
        {
            GL.ClearColor(OpenTK.Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Lighting);
            GL.Light(LightName.Light0, LightParameter.Ambient, ambientLight);
            GL.Light(LightName.Light0, LightParameter.Diffuse, diffuseLight);
            GL.Light(LightName.Light0, LightParameter.Specular, specularLight);
            GL.Light(LightName.Light0, LightParameter.Position, lightpos0);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, 127);
            GL.Light(LightName.Light1, LightParameter.Ambient, ambientLight);
            GL.Light(LightName.Light1, LightParameter.Diffuse, diffuseLight);
            GL.Light(LightName.Light1, LightParameter.Specular, specularLight);
            GL.Light(LightName.Light1, LightParameter.Position, lightpos1);
            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.Light1);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Normalize);
            GL.CullFace(CullFaceMode.Back);
            GL.Enable(EnableCap.CullFace);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
            GL.ShadeModel(ShadingModel.Smooth);
            GL.FrontFace(FrontFaceDirection.Ccw);
        }

    }
}

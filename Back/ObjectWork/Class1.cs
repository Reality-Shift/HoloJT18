using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ObjectWork
{
    public class Class1
    {

        public static void loadMesh(string filename, out List<Vector3> positions, out List<Vector2> textureCoords, out List<Vector3> normals, out List<uint> indices)
        {

            var lines = File.ReadAllLines(filename).Select(l => l.Replace('.', ',')).ToArray();
            positions = new List<Vector3>();
            textureCoords = new List<Vector2>();
            normals = new List<Vector3>();
            indices = new List<uint>();


            List<Vector3> tempPositions = new List<Vector3>();
            List<Vector2> tempTextureCoords = new List<Vector2>();
            List<Vector3> tempNormals = new List<Vector3>();
            Dictionary<string, uint> verticesToIndices = new Dictionary<string, uint>();

            foreach (var line in lines)
            {

                var tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length > 1)
                {
                    if (tokens[0] == "v" && tokens.Length >= 4)
                    {
                        // Parse position
                        Vector3 position = new Vector3
                        {
                            X = float.Parse(tokens[1]),
                            Y = float.Parse(tokens[2]),
                            Z = float.Parse(tokens[3])
                        };

                        tempPositions.Add(position);
                    }
                    else if (tokens[0] == "vt" && tokens.Length >= 3)
                    {
                        // Parse texture coords
                        Vector2 textureCoord = new Vector2
                        {
                            X = float.Parse(tokens[1]),
                            Y = 1.0f - float.Parse(tokens[2])
                        };

                        tempTextureCoords.Add(textureCoord);
                    }
                    else if (tokens[0] == "vn" && tokens.Length >= 4)
                    {
                        // Parse normal
                        Vector3 normal = new Vector3
                        {
                            X = float.Parse(tokens[1]),
                            Y = float.Parse(tokens[2]),
                            Z = float.Parse(tokens[3])
                        };

                        tempNormals.Add(normal);
                    }
                    else if (tokens[0] == "f" && tokens.Length == 4)
                    {
                        // Parse face
                        for (int i = 0; i < 3; ++i)
                        {
                            string token = tokens[i + 1];
                            if (!verticesToIndices.TryGetValue(token, out var it))
                            {
                                uint index = (uint)(positions.Count);

                                var subtokens = token.Split('/').Select(s => int.Parse(s)).ToArray();
                                if (subtokens.Length > 0)
                                {
                                    positions.Add(tempPositions[(subtokens[0]) - 1]);
                                }
                                if (subtokens.Length > 1)
                                {
                                    textureCoords.Add(tempTextureCoords[(subtokens[1]) - 1]);
                                }
                                if (subtokens.Length > 2)
                                {
                                    normals.Add(tempNormals[(subtokens[2]) - 1]);
                                }

                                verticesToIndices[token] = index;
                                indices.Add(index);
                            }
                            else
                            {
                                indices.Add(it);
                            }
                        }
                    }
                }

            }
        }
        public class Vector2
        {
            public Vector2()
            {

            }
            public Vector2(float x, float y)
            {
                X = x;
                Y = y;
            }

            public float X { get; set; }
            public float Y { get; set; }
            public override string ToString()
            {
                return $"X={X} Y={Y}";
            }
        };

        public class Vector3
        {
            public Vector3()
            {

            }
            public Vector3(float x, float y, float z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }
            public override string ToString()
            {
                return $"X={X} Y={Y} Z={Z}";
            }
        };

    }
}

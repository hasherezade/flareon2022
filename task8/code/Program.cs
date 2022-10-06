using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlareOn.Backdoor;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{

    class Program
    {
        static bool decodeAndSave(Dictionary<uint, int> m, byte[] b, String filename)
        {
            bool isOk = false;
            byte[] outs = FLARE15.flare_71(m, b);
            if (outs.Length != 0)
            {
                isOk = true;
            } else
            {
                Console.Write("Decodeding failed:" + filename + "\n");
            }
            File.WriteAllBytes(filename, outs);
            return isOk;
        }

        static void stage1DecodeChunks(string directory)
        {
            decodeAndSave(FLARE15.gh_m, FLARE15.gh_b, Path.Combine(directory, "flared_66.bin"));
            decodeAndSave(FLARE15.d_m, FLARE15.d_b, Path.Combine(directory, "flared_47.bin"));
            decodeAndSave(FLARE15.gs_m, FLARE15.gs_b, Path.Combine(directory, "flared_69.bin"));
            decodeAndSave(FLARE15.cl_m, FLARE15.cl_b, Path.Combine(directory, "flared_67.bin"));
            decodeAndSave(FLARE15.pe_m, FLARE15.pe_b, Path.Combine(directory, "flared_35.bin"));
            decodeAndSave(new Dictionary<uint, int>(), FLARE15.rt_b, Path.Combine(directory, "flared_68.bin"));
            decodeAndSave(FLARE15.wl_m, FLARE15.wl_b, Path.Combine(directory, "flare_70.bin"));
        }

        static byte[] decodeStage2Chunk(byte[] d, string directory, string filename)
        {
            string path = Path.Combine(directory, filename);
            byte[] b = FLARE12.flared_47(new byte[]
            {
                18,
                120,
                171,
                223
            }, d);
            byte[] next = FLARE15.flared_67(b);
            File.WriteAllBytes(path, next);
            return next;
        }

        static Dictionary<int, int> createMapOfTokens(string tokensFile)
        {
            string tokenStr = "Token: ";
            string offsetStr = "File Offset: ";
            string sepStr = " RID:";
            var tokenToOffset = new Dictionary<int, int>();
            foreach (string line in System.IO.File.ReadLines(tokensFile))
            {
                int tokenStart = line.IndexOf(tokenStr);
                int sep = line.IndexOf(sepStr);
                int offsetStart = line.IndexOf(offsetStr);


                int len = sep - (tokenStart + tokenStr.Length);
                string tokenPart = line.Substring(tokenStart + tokenStr.Length, len);
                string offsetPart = line.Substring(offsetStart + offsetStr.Length);

                int tokenVal = Convert.ToInt32(tokenPart, 16);
                int offsetVal = Convert.ToInt32(offsetPart, 16);

                Console.WriteLine(System.String.Format(@"Adding: '{0}' '{1:X}'", tokenPart, offsetVal));

                tokenToOffset[tokenVal] = offsetVal;
            }
            return tokenToOffset;
        }

        static void stage2DecodeDirectory(string sourceDirectory, string outDirectory, Dictionary<int, int> tokenToOffset, byte[] fileBuf)
        {
            try
            {
                const int hdrSize = 0xC;
                //byte []fileBuf = File.ReadAllBytes(fileToPatch);
                //var tokenToOffset = createMapOfTokens(tokensFile);
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt", SearchOption.AllDirectories);
                
                foreach (string currentFile in txtFiles)
                {
                    Console.WriteLine(currentFile);
                    string filename = Path.GetFileName(currentFile);
                    if (filename == "log.txt")
                    {
                        continue;
                    }
                    string tokenName = Path.GetFileNameWithoutExtension(filename);
                    int tokenVal = Convert.ToInt32(tokenName, 16);
                    Console.WriteLine(System.String.Format(@"tokenName: '{0:X}'", tokenVal));


                    byte []d = File.ReadAllBytes(currentFile);
                    byte []decChunk = decodeStage2Chunk(d, outDirectory, filename);

                    if (tokenToOffset.ContainsKey(tokenVal))
                    {
                        int offset = tokenToOffset[tokenVal];
                        Console.WriteLine(System.String.Format(@"Parsed: '{0:X}' '{1:X}'", tokenVal, offset));

                        Buffer.BlockCopy(decChunk, 0, fileBuf, offset + hdrSize, decChunk.Length);
                    }
                }

                //string outExe = Path.Combine(outDirectory, "FlareOn.Backdoor_s2_p1.exe");
                //File.WriteAllBytes(outExe, fileBuf);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        static void decodeByTables()
        {
            FLARE15.flare_74();

            byte []fileBuf = File.ReadAllBytes("C:\\decoded\\FlareOn.Backdoor_p2a.exe");
            var tokenToOffset = createMapOfTokens("C:\\decoded\\file_offsets.txt");
            stage1DecodeChunks("C:\\decoded\\stage1_decoded");


            stage2DecodeDirectory("C:\\decoded\\new4", "C:\\decoded\\stage2_decoded", tokenToOffset, fileBuf);

            string outExe = Path.Combine("C:\\decoded\\new4", "FlareOn.Backdoor_s2_p1.exe");
            File.WriteAllBytes(outExe, fileBuf);
            //
            Console.Write("Decoded!\n");
        }

        public static byte[] findByMethodHash(Module module, string modulePath, int metadataToken)
        {
            string h = FLARE15.flared_66(module, metadataToken);
            byte[] d = FLARE15.flared_69(modulePath, h);
            if (d.Length == 0) return new byte[] { };

            byte[] b = FLARE12.flared_47(new byte[]
            {
                18,
                120,
                171,
                223
            }, d);
            return FLARE15.flared_67(b);
        }


        static bool decodeByReflection(string offsetsFile, string fileToPatch, string outExe)
        {
            const int hdrSize = 0xC;
            byte[] fileBuf = File.ReadAllBytes(fileToPatch);

            Dictionary<int, int> tokenToOffset = createMapOfTokens(offsetsFile);
            Assembly a = Assembly.LoadFrom(fileToPatch);
            Module[] m = a.Modules.ToArray();
            Console.WriteLine(m.Length);
            if (m.Length == 0) return false;

            Module module = m[0];

            Type[] tArray = module.FindTypes(Module.FilterTypeName, "FLARE*");
            int notFound = 0;

            foreach (Type t in tArray)
            {
                Console.WriteLine("Found a module beginning with FLARE*: {0}.", t.Name);

                foreach (MethodInfo mi in t.GetMethods())
                {
                    var metadataToken = mi.MetadataToken;
                    string name = mi.Name;
                    if (!mi.IsStatic) { continue; }
                    if (!name.StartsWith("flared_")) { continue; }

                    //if (name.StartsWith("flared_28")) { continue; } //skip
                    Console.WriteLine("Method: {0:X} {1}", metadataToken, mi.Name);

                    string h = FLARE15.flared_66(module, metadataToken);
                    //Console.WriteLine(System.String.Format(@"Token: '{0:X}' '{1}'", metadataToken, h));
                    byte[] decChunk = findByMethodHash(module, fileToPatch, metadataToken);
                    if (decChunk.Length == 0)
                    {
                        Console.WriteLine("NOT found: {0:X} {1}", metadataToken, mi.Name);
                        notFound++;
                        continue;
                    }
                    int offset = 0;
                    if (tokenToOffset.ContainsKey(metadataToken))
                    {
                        offset = tokenToOffset[metadataToken];
                    }
                    if (offset == 0)
                    {
                        Console.WriteLine("Offset NOT found: {0:X} {1}", metadataToken, mi.Name);
                        notFound++;
                        continue;
                    }

                    MethodBody methodBody = mi.GetMethodBody();
                    byte[] currentBody = methodBody.GetILAsByteArray();
                    if (currentBody.Length != decChunk.Length)
                    {
                        Console.WriteLine("Length mismatch: {0:X} {1}", metadataToken, mi.Name);
                        notFound++;
                        continue;
                    }
                    // offset where the method body starts (headers may have various sizes)
                    int bodyOffset = 0;
                    for (var i = offset; i < (offset + hdrSize + decChunk.Length); i++)
                    {
                        //memcmp:
                        
                        bool isOk = true;
                        for (var k = 0; k < decChunk.Length; k++)
                        {
                            if (fileBuf[i + k] != currentBody[k])
                            {
                                isOk = false;
                                break;
                            }
                        }
                        if (isOk)
                        {
                            bodyOffset = i;
                            break;
                        }

                    }
                    if (bodyOffset == 0)
                    {
                        Console.WriteLine("Function body not found: {0:X} {1}", metadataToken, mi.Name);
                        notFound++;
                        continue;
                    }

                    Buffer.BlockCopy(decChunk, 0, fileBuf, bodyOffset, decChunk.Length);

                    Console.WriteLine(System.String.Format("\tParsed: '{0:X}' '{1:X}'", metadataToken, offset));
                }
            }

            Console.WriteLine("NOT found count: {0}", notFound);
            File.WriteAllBytes(outExe, fileBuf);

            return false;
        }

        static void Main(string[] args)
        {
            //FLARE15.flare_74();
            string outExe = Path.Combine("C:\\decoded\\stage2_decoded", "FlareOn.Backdoor_stage2.exe");
            decodeByReflection("C:\\decoded\\file_offsets.txt", "C:\\decoded\\FlareOn.Backdoor_p2a.exe", outExe);

        }
    }
}

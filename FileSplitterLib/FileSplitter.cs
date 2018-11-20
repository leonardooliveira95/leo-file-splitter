using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSplitterLib
{
    public class FileSplitter
    {
        private const int TAM_BUFFER = 104857600;

        public static void DividirArquivo(string caminhoArquivo, int numeroPartes)
        {
            FileStream f = File.Open(caminhoArquivo, FileMode.Open);

            long tam = (f.Length / numeroPartes + 1);

            for (int i = 0; i < numeroPartes; i++)
            {
                FileStream temp = File.Create(caminhoArquivo + string.Format(".{0:D3}", i + 1));

                long offset = 0;

                while (offset < tam && f.Position < f.Length)
                {
                    byte[] arr;
                    int arrsize;

                    if (offset + TAM_BUFFER > tam)
                    {
                        if(tam - offset > f.Length - f.Position)
                        {
                            arrsize = (int)(f.Length - f.Position);
                        }
                        else
                        {
                            arrsize = (int)(tam - offset);
                        }

                        arr = new byte[arrsize];
                    }
                    else
                    {
                        arrsize = TAM_BUFFER;
                        arr = new byte[arrsize];
                    }

                    offset += f.Read(arr, 0, arrsize);

                    temp.Write(arr, 0, arr.Length);
                    temp.Flush();

                    arr = null;
                }

                temp.Close();
            }

            f.Close();
        }

        public static void JuntarArquivo(string caminhoArquivo)
        {
            DirectoryInfo di = Directory.GetParent(caminhoArquivo);
            List<FileInfo> arqs = di.GetFiles().ToList();
            FileInfo arq = new FileInfo(caminhoArquivo);

            string subStr = arq.Name.Substring(0, arq.Name.LastIndexOf('.'));

            List<FileInfo> res = arqs.FindAll(x => x.Name.Contains(subStr));
            FileStream arqFinal = File.Create(di.FullName + "\\" + subStr);

            foreach(FileInfo fi in res)
            {
                byte[] arr = File.ReadAllBytes(fi.FullName);
                arqFinal.Write(arr, 0, arr.Length);
            }

            arqFinal.Close();
        }
    }
}

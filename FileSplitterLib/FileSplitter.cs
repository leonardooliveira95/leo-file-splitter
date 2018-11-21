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

        public static async Task DividirArquivo(string caminhoArquivo, int numeroPartes)
        {
            await DividirArquivo(caminhoArquivo, numeroPartes, null);
        }

        public static async Task DividirArquivo(string caminhoArquivo, int numeroPartes, IProgress<int> progress)
        {
            await Task.Run(() => {

                FileStream f = File.Open(caminhoArquivo, FileMode.Open);

                long tam = (f.Length / numeroPartes + 1);

                for (int i = 0; i < numeroPartes; i++)
                {
                    if (progress != null)
                    {
                        progress.Report((int)((double)(i + 1) / numeroPartes * 100));
                    }

                    FileStream temp = File.Create(caminhoArquivo + string.Format(".{0:D3}", i + 1));

                    long offset = 0;

                    while (offset < tam && f.Position < f.Length)
                    {
                        byte[] arr;
                        int arrsize;

                        if (offset + TAM_BUFFER > tam)
                        {
                            if (tam - offset > f.Length - f.Position)
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

            });
            
        }

        public static async Task JuntarArquivo(string caminhoArquivo)
        {
            await JuntarArquivo(caminhoArquivo, null);
        }

        public static async Task JuntarArquivo(string caminhoArquivo, IProgress<int> progress)
        {
            await Task.Run(() => {

                DirectoryInfo di = Directory.GetParent(caminhoArquivo);
                List<FileInfo> arqs = di.GetFiles().ToList();
                FileInfo arq = new FileInfo(caminhoArquivo);

                string subStr = arq.Name.Substring(0, arq.Name.LastIndexOf('.'));

                List<FileInfo> res = arqs.FindAll(x => x.Name.Contains(subStr));
                FileStream arqFinal = File.Create(di.FullName + "\\" + subStr);

                int i = 0;

                foreach (FileInfo fi in res)
                {
                    if(progress != null)
                    {
                        progress.Report((int)((double)(i + 1) / res.Count * 100));
                    }

                    FileStream parte = fi.Open(FileMode.Open);

                    long offset = 0;

                    while (offset < parte.Length)
                    {
                        byte[] arr;
                        int arrsize;

                        if (offset + TAM_BUFFER > parte.Length)
                        {
                            arrsize = (int)(parte.Length - offset);
                        }
                        else
                        {
                            arrsize = TAM_BUFFER;
                        }

                        arr = new byte[arrsize];

                        offset += parte.Read(arr, 0, arrsize);

                        arqFinal.Write(arr, 0, arr.Length);
                        arqFinal.Flush();

                        arr = null;
                    }

                    parte.Close();

                    i++;
                }

                arqFinal.Close();

            });
        }
    }
}

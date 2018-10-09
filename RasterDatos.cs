using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace SimuladorInundaciones
{
    class RasterDatos
    {

        public int anchoEjeX_ = 0;
        public int altoEjeY_ = 0;
        public float[,] matrizDEM_;

        public RasterDatos(string pathFileDEM, int anchoEjeX, int altoEjeY)
        {
            BinaryReader reader = new BinaryReader(File.Open(pathFileDEM, FileMode.Open));

            anchoEjeX_ = anchoEjeX;
            altoEjeY_ = altoEjeY;

            matrizDEM_ = new float[altoEjeY_, anchoEjeX_];


            for (int i = 0; i < altoEjeY_; i++)
            {
                for (int j = 0; j < anchoEjeX_; j++)
                {
                    matrizDEM_[i, j] = reader.ReadSingle();
                }
            }
            reader.Close();
        }



        public RasterDatos(string pathFileDEM, int anchoEjeX, int altoEjeY, int offsetX, int offsetY, int imageSizeX, int imageSizeY)
        {
            BinaryReader reader = new BinaryReader(File.Open(pathFileDEM, FileMode.Open));

            anchoEjeX_ = anchoEjeX;
            altoEjeY_ = altoEjeY;            

            matrizDEM_ = new float[altoEjeY_, anchoEjeX_];


            for (int i = 0; i < imageSizeY; i++)
            {
                if (i < offsetY || i >= offsetY + altoEjeY)
                {
                    for (int r = 0; r < imageSizeX; r++)
                    {
                        reader.ReadSingle();
                    }
                    continue;
                }
                else
                {
                    for (int j = 0; j < imageSizeX; j++)
                    {
                        if (j < offsetX || j >= offsetX + anchoEjeX)
                        {
                            reader.ReadSingle();
                            continue;
                        }
                        else
                        {
                            matrizDEM_[i - offsetY, j - offsetX] = reader.ReadSingle();
                        }
                    }
                }
            }
            reader.Close();           
        }


        public RasterDatos(int anchoEjeX, int altoEjeY)         
        {
            anchoEjeX_ = anchoEjeX;
            altoEjeY_ = altoEjeY;

            matrizDEM_ = new float[altoEjeY_, anchoEjeX_];

        }

        
        public void writeDataMatrix(string pathFile)
        {
            BinaryWriter tempWriter = new BinaryWriter(File.Create(pathFile));

            float tempFloat = 0.0f;

            for(int i = 0; i < altoEjeY_ ; i++ )
            {
                for (int j = 0; j < anchoEjeX_; j++)
                {
                    tempFloat = matrizDEM_[i, j];
                    tempWriter.Write(tempFloat);
                }
            }

            tempWriter.Close();
        }

        public float getValue(int x, int y) 
        {
            return matrizDEM_[y, x];
        }

        public void setValue(float value, int x, int y) 
        {
            matrizDEM_[y, x] = value;
        }

        public float sumaTotal() 
        {
            float valorDevuelto = 0.0f;

            for (int i = 0; i < altoEjeY_; i++)
            {
                for (int j = 0; j < anchoEjeX_; j++)
                {
                    valorDevuelto += matrizDEM_[i, j];                    
                }
            }

            return valorDevuelto;
        } 
    }
}

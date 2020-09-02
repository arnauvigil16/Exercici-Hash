using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace hash01
{

    class Program
    {
        static void Main(string[] args)
        {
           
            Boolean sortida = false;

            while (sortida == false){

                Console.Write("Selecciona: "); 
                Console.WriteLine();
                Console.Write("1.- Extreure el hash del contingut d'un fitxer "); 
                Console.WriteLine();
                Console.Write("2.- Guardar en un fitxer extern el hash del fitxer ");
                Console.WriteLine();
                Console.Write("3.- Comparar dos hash ");
                Console.WriteLine();
                Console.Write("4.- Sortida ");
                Console.WriteLine();
                Console.WriteLine();
                String opcion = Console.ReadLine();
                int opcion_real = int.Parse(opcion);
       
                            switch(opcion_real){

                                case 1:
                                
                                        // Leer el contenido del fichero y guardarlo en una variable
                                        string text = File.ReadAllText(Path.GetFullPath("prova.txt"));

 
                                        // Convertir el string en un array de bytes
                                        byte[] bytesIn = Encoding.UTF8.GetBytes(text);
           
                           
                                        using (SHA512Managed SHA512 = new SHA512Managed())
                                        {
                                            // Calculo del hash
                     
                                            byte[] hashResult = SHA512.ComputeHash(bytesIn);

                                            // Volvemos a converir el hash en string para poder mostrarlo

                                            String textOut = BitConverter.ToString(hashResult).Replace("-", string.Empty);   

                                            Console.WriteLine("Hash del text: {0}", text);
                                            Console.WriteLine();
                                            Console.WriteLine(textOut);
                                            Console.WriteLine();
                                            Console.ReadKey();
                                           } 
                                                break;

                                case 2:


                                        String text2 = File.ReadAllText(Path.GetFullPath("prova.txt"));

                                 
                                        byte[] bytesIn2 = Encoding.UTF8.GetBytes(text2);
           
  
                                        using (SHA512Managed SHA5122 = new SHA512Managed())
                                        {
                            
                                            byte[] hashResult = SHA5122.ComputeHash(bytesIn2);

                                            String textOut2 = BitConverter.ToString(hashResult).Replace("-", string.Empty); 


                                            //Definir la ruta en donde se guarda el archivo
                                            string path = @"c:\Users\arniv\Desktop\resultat.sha"; 

                                            //Crear y guardar el archivo con el contenido del hash
                                            File.WriteAllText(path, textOut2);

                                            Console.WriteLine();
                                            Console.Write("Se ha creado el archivo correctamente");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                        }
                                                break;

                                case 3: 

                                    
                                    
                                        var textIn2 = "";
                                        while (string.IsNullOrEmpty(textIn2))
                                        {
                                            Console.Clear();
                                            Console.Write("Entra un text: "); 
                                            textIn2 = Console.ReadLine();
                                            Console.WriteLine();
                                        }
                                        
                                        // Convertim l'string a un array de bytes
                                        byte[] bytesIn3 = Encoding.UTF8.GetBytes(textIn2);
                                        // Instanciar classe per fer hash
                                        SHA512Managed SHA5123 = new SHA512Managed();
                                        // Calcular hash
                                        byte[] hashResult3 = SHA5123.ComputeHash(bytesIn3);

                                        // Si volem mostrar el hash per pantalla o guardar-lo en un arxiu de text
                                        // cal convertir-lo a un string

                                         String textOut3 = BitConverter.ToString(hashResult3).Replace("-", string.Empty);
                                         String text3 = File.ReadAllText(Path.GetFullPath("prova.txt"));

                                         
                                        if (textOut3 == text3){
                                             Console.WriteLine();
                                             Console.Write("El hash es identic! No hi han hagut canvis");
                                             Console.WriteLine();
                                        }
                                        else {
                                             Console.WriteLine();
                                             Console.Write("El text es diferent !");
                                             Console.WriteLine();
                                             Console.WriteLine();
                                        }

                                    break;

                                case 4:
                                    sortida = true;
                                    break;

                                default:
                                    Console.WriteLine();
                                    Console.Write("Opcio no valida ");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    break;
                            }
              

            }
        }
    }
 }

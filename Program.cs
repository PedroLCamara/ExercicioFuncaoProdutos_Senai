using System;

namespace ExercicioFuncaoProdutos
{
    class Program
    {
        static string[] nomes= new string [num_produtos]; 
        static float[] preco= new float [num_produtos];
        static bool[] promo= new bool [num_produtos];
        static int num_produtos= 0;
        static int c= 0;
        static void Main(string[] args)
        {
            MostrarMenu();
        }
        static void MostrarMenu(){
            string caminhoMenu= null;
            bool resposta_correta= false;
            do
            {
            Console.WriteLine(@"
-------------------------------------------------
|            Digite a opção desejada:           |
-------------------------------------------------
|=========== 1- Cadastar produto(s)  ===========|
|=========== 2- Listar produto(s)    ===========|
|=========== 3- Sair                 ===========|
-------------------------------------------------");
        caminhoMenu= Console.ReadLine();
        if(caminhoMenu== "1"){
            Cadastrar();
            resposta_correta= true;
        }
        else if(caminhoMenu== "2"){
            Listar();
            resposta_correta= true;
        }
        else if(caminhoMenu== "3"){
            Console.WriteLine("Certo, desligando o sistema...");
            resposta_correta= true;
        }
        else{
            Console.WriteLine("Erro 001: Digite '1' para cadastart um ou mais produtos, '2' para listar os produtos cadastrados e '3' para sair.");
            Console.WriteLine();
        }
            } while (resposta_correta== false);
        }
        static void Cadastrar(){
            Console.WriteLine("Digite o número de produtos a serem cadastrados");
            bool resposta_certa= false;
            c= num_produtos;
            num_produtos= c+(int.Parse(Console.ReadLine()));
            string resposta;
            Array.Resize(ref nomes, num_produtos);
            Array.Resize(ref preco, num_produtos);
            Array.Resize(ref promo, num_produtos);
            while (c< num_produtos)
            {
                Console.WriteLine();
                Console.WriteLine($"Escreva o nome do produto nº {(c+1)}");
                nomes[c]= Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine($"Escreva o preço do produto nº {(c+1)}");
                preco[c]= float.Parse(Console.ReadLine());
                Console.WriteLine();
                do
                {
                Console.WriteLine($@"O produto nº {(c+1)} está em promoção?
1- Sim
2- Não");
                resposta= Console.ReadLine().Substring(0,1);
                if (resposta=="1")
                {
                    promo[c]= true;
                    resposta_certa= true;
                }
                else if(resposta== "2"){
                    promo[c]= false;
                    resposta_certa= true;
                }
                else{
                    Console.WriteLine("Resposta inválida, digite '1' para sim e '2' para não.");
                    resposta_certa= false;
                }
                } while (resposta_certa==false); 
                c++;
            }
            MostrarMenu();
        }
        static void Listar(){
            if(num_produtos>=1){
                Console.WriteLine($@"
============================================================
|      Nome    |     Preço    |        em promoção???      |");
            for (var c = 0; c < num_produtos; c++)
            {
                if(promo[c]==true){
                    Console.WriteLine($@"
============================================================
|        {nomes[c]}      |      {preco[c]}      |       SIM!!!      |");
                }
                else{
                    Console.WriteLine($@"
============================================================
|        {nomes[c]}      |      {preco[c]}      |       NÃO :(      |");
                }
            }
            }
            else{
                Console.WriteLine("Sem produtos cadastrados...");
            }
            MostrarMenu();
        }
    }
}
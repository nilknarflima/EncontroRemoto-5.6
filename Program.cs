using System;
using System.Threading;
namespace EcontroRemoto2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(@$"
===========================
|    Bem vindo ao sistema de cadastro      |
|    de pessoa física e pessoa jurídica        |
===========================
");
            BarraCarregamento("Iniciando");

            string? opcao;

            do
            {
                Console.WriteLine(@$"
========================
|   Escolha uma das opções abaixo   |
|       1 - Pessoa Física                         |
|       2 - Pessoa Jurídica                     |
|                                                           |
|       0 - Sair                                        |
========================
");

            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                  Endereco endPf = new Endereco();

                    endPf.logradouro = "Rua Senho do Socorro";
                    endPf.numero = 32;
                    endPf.complemento = "Próximo Rotunda da Confeitira";
                    endPf.enderecoComercial = false;

                    PessoaFisica novapf = new PessoaFisica();

                     novapf.nome = "Franklin Lima";
                    novapf.endereco = endPf;
                    novapf.cpf = "724951900";
                    novapf.rendimento = 5000;
                    novapf.dataNascimento = new DateTime(1982, 04, 17);
                  

                    PessoaFisica pf = new PessoaFisica();
                    pf.ValidarDataNascimento(novapf.dataNascimento);

                    Console.WriteLine(pf.PagarImposto(novapf.rendimento).ToString("N2"));
                    bool idadeValida = pf.ValidarDataNascimento(novapf.dataNascimento);

                    if (idadeValida == true)
                    {
                        Console.WriteLine($"Cadastro Aprovado");
                    }
                    else
                    {
                        Console.WriteLine($"Cadastro Não Aprovado");
                    }
                    Console.WriteLine("Rua: " + novapf.endereco.logradouro + ", " + novapf.endereco.numero);
                    break;
                case "2":
                    PessoaJuridica pj = new PessoaJuridica();

                    PessoaJuridica novapj = new PessoaJuridica();

                    Endereco endPj = new Endereco();

                    endPj.logradouro = "Rua X";
                    endPj.numero = 100;
                    endPj.complemento = "Próximo ao Senai";
                    endPj.enderecoComercial = true;

                    novapj.endereco = endPj;
                    novapj.cnpj = "01234567890001";
                    novapj.rendimento = 8000;
                    novapj.razaoSocial = "Pessoa Jurídica";

                    Console.WriteLine(pj.PagarImposto(novapj.rendimento).ToString("N2"));
                    if (pj.ValidarCNPJ(novapj.cnpj))
                    {
                        Console.WriteLine("CNPJ Válido");
                    }
                    else
                    {
                        Console.WriteLine("CNPJ Inválido");
                    }
                    break;
                
                case "0":
                    Console.WriteLine($"Obrigado por utilizar o nosso sistema");
                    BarraCarregamento("Finalizando");
                    break;
                
                default:
                    Console.WriteLine($"Opção inválida, digite uma opção válida");
                    break;
            }
                
            } while (opcao != "0");
            
            static void BarraCarregamento(string textoCarregamento)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(textoCarregamento);
                Thread.Sleep(500);

                for (var contador = 0; contador < 10; contador++)
                {
                    Console.Write($".");
                    Thread.Sleep(500); 
                }
                Console.ResetColor();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    class Program
    {
        static List<Funcionario> lista = new List<Funcionario>();
        public static void AdicionarFuncionário()
        {
            Funcionario func = new Funcionario();

            Console.WriteLine("Digite o Id do funcionário: ");
            func.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do funcionário: ");
            func.Nome = Console.ReadLine();

            Console.WriteLine("Digite o Cpf: ");
            func.Cpf = Console.ReadLine();

            Console.WriteLine("Digite a data de admissão: ");
            func.DataAdmissao = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Salário: ");
            func.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escolha o tipo de Funcionário (1 - CLT / 2 - Aprendiz): ");
            int opcao = int.Parse(Console.ReadLine());

            //Operador Ternário - Interpretação: Se a consição dos parênteses for verdadeira,
            //escolhe o que está depois da "?", caso contrário, escolhe o que está depois dos ":"
            func.TipoFuncionario = (opcao == 1) ? TipoFuncionarioEnum.CLT : TipoFuncionarioEnum.Aprendiz;

            if (string.IsNullOrEmpty(func.Nome))
            {
                Console.WriteLine("O nome do funcionário não pode ser vazio.");
            }
            else if (string.IsNullOrEmpty(func.Cpf))
            {
                Console.WriteLine("O CPF do funcionário não pode ser vazio.");
            }

            ValidarCpf(func);
            ValidarNome(func);
            ValidarSalarioAdmissao(func);
        }
        public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.00M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.00M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "13579246810";
            f3.DataAdmissao = DateTime.Parse("01/01/2000");
            f3.Salario = 70.00M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "24681357908";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.00M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "24681357910";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.00M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Rodrigo Garro";
            f6.Cpf = "24657952408";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.00M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }
        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "===============================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("Cpf: {0} \n", lista[i].Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", lista[i].Salario);
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
                dados += "===============================\n";
            }
            Console.WriteLine(dados);
        }
        public static void ObterPorNome(string nome)
        {
            lista = lista.FindAll(x => x.Nome.ToLower() == nome);
            ExibirLista();
        }
        public static void ObterRecentes()
        {
            lista = lista.OrderByDescending(x => x.Id).ToList();
            ExibirLista();
        }
        public static void ObterEstatisticas()
        {
            int funcionarios = lista.Count;
            decimal totalSalarios = lista.Sum(x => x.Salario);
            Console.WriteLine("===============================");
            Console.WriteLine("Total de funcionários: {0}", funcionarios);
            Console.WriteLine("Somatória dos salários: {0:c2}", totalSalarios);
            Console.WriteLine("===============================");
        }
        public static void ObterPorTipo(TipoFuncionarioEnum tipo)
        {
            lista = lista.FindAll(x => x.TipoFuncionario == tipo);
            ExibirLista();
        }
        public static Boolean ValidarSalarioAdmissao(Funcionario func)
        {
            if (func.Salario <= 0)
            {
                Console.WriteLine("O salário do funcionário {0} tem que ser maior que 0.", func.Salario);
                return false;
            }
            if (func.DataAdmissao < DateTime.Today)
            {
                Console.WriteLine("A data de admissão não pode ser menor do que o dia atual.\nOu", func.Salario);
                return false;
            }
            return true;
        }
        public static Boolean ValidarNome(Funcionario func)
        {
            if (func.Nome.Length <= 2)
            {
                Console.WriteLine("O nome inserido é menor ou igual a 2 caracteres.");
                return false;
            }
            return true;
        }
        public static Boolean ValidarCpf(Funcionario func)
        {
            if (func.Cpf.Length == 11)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("");
            CriarLista();
        }

    }

}
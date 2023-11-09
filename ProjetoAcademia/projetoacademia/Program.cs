using System;
using System.Collections.Generic;
using System.IO;

class Pessoa
{
    public int PessoaID { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }

    public Pessoa(int pessoaID, string nome, string sobrenome, string cpf, string telefone, string endereco)
    {
        PessoaID = pessoaID;
        Nome = nome;
        Sobrenome = sobrenome;
        CPF = cpf;
        Telefone = telefone;
        Endereco = endereco;
    }

    public override string ToString()
    {
        return $"PessoaID: {PessoaID}, Nome: {Nome} {Sobrenome}, CPF: {CPF}, Telefone: {Telefone}, Endereço: {Endereco}";
    }
}

class Treino
{
    public int TreinoID { get; set; }
    public int PessoaID { get; set; }
    public string Maquina { get; set; }
    public int Repeticoes { get; set; }
    public int Series { get; set; }
    public string Descricao { get; set; }
    public DateTime DataHora { get; set; }

    public Treino(int treinoID, int pessoaID, string maquina, int repeticoes, int series, string descricao, DateTime dataHora)
    {
        TreinoID = treinoID;
        PessoaID = pessoaID;
        Maquina = maquina;
        Repeticoes = repeticoes;
        Series = series;
        Descricao = descricao;
        DataHora = dataHora;
    }

    public override string ToString()
    {
        return $"TreinoID: {TreinoID}, PessoaID: {PessoaID}, Máquina: {Maquina}, Repetições: {Repeticoes}, Séries: {Series}, Descrição: {Descricao}, Data/Hora: {DataHora}";
    }
}

class Program
{
    static int proximoPessoaID = 1;
    static int proximoTreinoID = 1;

    static void Main()
    {
        List<Pessoa> pessoas = new List<Pessoa>();
        List<Treino> treinos = new List<Treino>();

        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Cadastrar Aluno");
            Console.WriteLine("2. Cadastrar Personal");
            Console.WriteLine("3. Criar Treino");
            Console.WriteLine("4. Imprimir Treino por ID");
            Console.WriteLine("5. Editar Treino por ID");
            Console.WriteLine("6. Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarAluno(pessoas);
                    break;
                case "2":
                    CadastrarPersonal(pessoas);
                    break;
                case "3":
                    CriarTreino(pessoas, treinos);
                    break;
                case "4":
                    ImprimirTreinoPorID(treinos);
                    break;
                case "5":
                    EditarTreinoPorID(treinos);
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarAluno(List<Pessoa> pessoas)
    {
        Console.WriteLine("Digite o nome do aluno:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o sobrenome do aluno:");
        string sobrenome = Console.ReadLine();

        Console.WriteLine("Digite o CPF do aluno:");
        string cpf = Console.ReadLine();

        Console.WriteLine("Digite o telefone do aluno:");
        string telefone = Console.ReadLine();

        Console.WriteLine("Digite o endereço do aluno:");
        string endereco = Console.ReadLine();

        Pessoa aluno = new Pessoa(proximoPessoaID, nome, sobrenome, cpf, telefone, endereco);
        proximoPessoaID++;
        pessoas.Add(aluno);

        Console.WriteLine("Aluno cadastrado com sucesso!\n");
    }

    static void CadastrarPersonal(List<Pessoa> pessoas)
    {
        Console.WriteLine("Digite o nome do personal:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o sobrenome do personal:");
        string sobrenome = Console.ReadLine();

        Console.WriteLine("Digite o CPF do personal:");
        string cpf = Console.ReadLine();

        Console.WriteLine("Digite o telefone do personal:");
        string telefone = Console.ReadLine();

        Console.WriteLine("Digite o endereço do personal:");
        string endereco = Console.ReadLine();

        Pessoa personal = new Pessoa(proximoPessoaID, nome, sobrenome, cpf, telefone, endereco);
        proximoPessoaID++;
        pessoas.Add(personal);

        Console.WriteLine("Personal cadastrado com sucesso!\n");
    }

    static void CriarTreino(List<Pessoa> pessoas, List<Treino> treinos)
    {
        Console.WriteLine("Digite o ID da pessoa para associar ao treino:");
        int pessoaID = int.Parse(Console.ReadLine());

        Pessoa pessoaAssociada = pessoas.Find(p => p.PessoaID == pessoaID);

        if (pessoaAssociada == null)
        {
            Console.WriteLine("Pessoa não encontrada. Não é possível criar o treino.");
            return;
        }

        Console.WriteLine("Digite a máquina do treino:");
        string maquina = Console.ReadLine();

        Console.WriteLine("Digite o número de repetições do treino:");
        int repeticoes = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o número de séries do treino:");
        int series = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a descrição do treino:");
        string descricao = Console.ReadLine();

        DateTime dataHora = DateTime.Now;

        Treino treino = new Treino(proximoTreinoID, pessoaID, maquina, repeticoes, series, descricao, dataHora);
        proximoTreinoID++;
        treinos.Add(treino);

        Console.WriteLine("Treino criado com sucesso!\n");
    }

    static void ImprimirTreinoPorID(List<Treino> treinos)
    {
        Console.WriteLine("Digite o ID do treino que deseja imprimir:");
        int treinoID = int.Parse(Console.ReadLine());

        Treino treinoSelecionado = treinos.Find(t => t.TreinoID == treinoID);

        if (treinoSelecionado == null)
        {
            Console.WriteLine("Treino não encontrado.");
        }
        else
        {
            Console.WriteLine("Escolha o formato de impressão:");
            Console.WriteLine("1. Papel");
            Console.WriteLine("2. PDF");

            string opcaoImpressao = Console.ReadLine();

            switch (opcaoImpressao)
            {
                case "1":
                    ImprimirTreinoEmPapel(treinoSelecionado);
                    break;
                case "2":
                    GerarPDF(treinoSelecionado);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Nenhum formato selecionado.");
                    break;
            }
        }
    }

    static void ImprimirTreinoEmPapel(Treino treino)
    {
        Console.WriteLine("Treino Selecionado:");
        Console.WriteLine(treino);
        Console.WriteLine("Impressão em papel concluída.\n");
    }

    static void GerarPDF(Treino treino)
    {
        string nomeArquivo = $"Treino_{treino.TreinoID}.pdf";

        using (StreamWriter sw = new StreamWriter(nomeArquivo))
        {
            sw.WriteLine("Treino Selecionado:");
            sw.WriteLine(treino);
            Console.WriteLine($"Arquivo PDF gerado: {nomeArquivo}");
        }
    }

    static void EditarTreinoPorID(List<Treino> treinos)
    {
        Console.WriteLine("Digite o ID do treino que deseja editar ou excluir:");
        int treinoID = int.Parse(Console.ReadLine());

        Treino treinoParaEditar = treinos.Find(t => t.TreinoID == treinoID);

        if (treinoParaEditar == null)
        {
            Console.WriteLine("Treino não encontrado.");
        }
        else
        {
            Console.WriteLine("Treino Atual:");
            Console.WriteLine(treinoParaEditar);

            Console.WriteLine("Escolha a opção:");
            Console.WriteLine("1. Editar Treino");
            Console.WriteLine("2. Excluir Treino");

            string opcaoEdicao = Console.ReadLine();

            switch (opcaoEdicao)
            {
                case "1":
                    EditarTreino(treinoParaEditar);
                    break;
                case "2":
                    ExcluirTreino(treinos, treinoParaEditar);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Nenhuma ação realizada.");
                    break;
            }
        }
    }

    static void EditarTreino(Treino treino)
    {
        Console.WriteLine("Digite a nova máquina do treino:");
        treino.Maquina = Console.ReadLine();

        Console.WriteLine("Digite o novo número de repetições do treino:");
        treino.Repeticoes = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o novo número de séries do treino:");
        treino.Series = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a nova descrição do treino:");
        treino.Descricao = Console.ReadLine();

        Console.WriteLine("Edição concluída.\n");
    }

    static void ExcluirTreino(List<Treino> treinos, Treino treinoParaExcluir)
    {
        treinos.Remove(treinoParaExcluir);
        Console.WriteLine("Treino excluído com sucesso.\n");
    }
}
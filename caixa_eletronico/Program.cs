using System;

class Program
{
    static decimal contaCorrente = 1000.00m;
    static decimal contaPoupanca = 500.00m;
    static decimal limiteSaque = 500.00m;

    static void Main()
    {
        int opcao;
        do
        {
            ExibirMenu();
            opcao = int.Parse(Console.ReadLine());
            
            switch (opcao)
            {
                case 1:
                    Deposito();
                    break;
                case 2:
                    Saque();
                    break;
                case 3:
                    ExibirExtrato();
                    break;
                case 4:
                    Transferencia();
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        } while (opcao != 5);
    }

    static void ExibirMenu()
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1. Depósito");
        Console.WriteLine("2. Saque");
        Console.WriteLine("3. Extrato");
        Console.WriteLine("4. Transferência entre contas");
        Console.WriteLine("5. Sair");
        Console.Write("Escolha uma opção: ");
    }

    static void ExibirExtrato()
    {
        Console.WriteLine("\n=== Extrato ===");
        Console.WriteLine($"Conta Corrente: R$ {contaCorrente:F2}");
        Console.WriteLine($"Conta Poupança: R$ {contaPoupanca:F2}");
        Console.WriteLine("================");
    }

    static void Deposito()
    {
        Console.Write("Escolha a conta (1 para Corrente, 2 para Poupança): ");
        int tipoConta = int.Parse(Console.ReadLine());
        Console.Write("Digite o valor do depósito: R$ ");
        decimal valor = decimal.Parse(Console.ReadLine());

        if (valor > 0)
        {
            if (tipoConta == 1)
            {
                contaCorrente += valor;
                Console.WriteLine($"Depósito de R$ {valor:F2} realizado na Conta Corrente.");
            }
            else if (tipoConta == 2)
            {
                contaPoupanca += valor;
                Console.WriteLine($"Depósito de R$ {valor:F2} realizado na Conta Poupança.");
            }
            else
            {
                Console.WriteLine("Conta inválida.");
            }
        }
        else
        {
            Console.WriteLine("Valor inválido.");
        }
    }

    static void Saque()
    {
        Console.Write("Escolha a conta (1 para Corrente, 2 para Poupança): ");
        int tipoConta = int.Parse(Console.ReadLine());
        Console.Write("Digite o valor do saque: R$ ");
        decimal valor = decimal.Parse(Console.ReadLine());

        if (valor > 0 && valor <= limiteSaque)
        {
            if (tipoConta == 1 && valor <= contaCorrente)
            {
                contaCorrente -= valor;
                Console.WriteLine($"Saque de R$ {valor:F2} realizado na Conta Corrente.");
            }
            else if (tipoConta == 2 && valor <= contaPoupanca)
            {
                contaPoupanca -= valor;
                Console.WriteLine($"Saque de R$ {valor:F2} realizado na Conta Poupança.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente ou conta inválida.");
            }
        }
        else
        {
            Console.WriteLine("Valor inválido ou acima do limite de saque.");
        }
    }

    static void Transferencia()
    {
        Console.Write("Transferir de (1 para Corrente, 2 para Poupança): ");
        int tipoContaOrigem = int.Parse(Console.ReadLine());
        Console.Write("Digite o valor da transferência: R$ ");
        decimal valor = decimal.Parse(Console.ReadLine());

        if (valor > 0)
        {
            if (tipoContaOrigem == 1 && valor <= contaCorrente)
            {
                contaCorrente -= valor;
                contaPoupanca += valor;
                Console.WriteLine($"Transferência de R$ {valor:F2} da Conta Corrente para Conta Poupança realizada.");
            }
            else if (tipoContaOrigem == 2 && valor <= contaPoupanca)
            {
                contaPoupanca -= valor;
                contaCorrente += valor;
                Console.WriteLine($"Transferência de R$ {valor:F2} da Conta Poupança para Conta Corrente realizada.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente ou conta inválida.");
            }
        }
        else
        {
            Console.WriteLine("Valor inválido.");
        }
    }
}

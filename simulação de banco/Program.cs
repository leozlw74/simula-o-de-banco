internal class Program
{
    static private int add = 1;
    static private string[,] contas = new string[add, 3];
    static private string[,] OwnAccount = new string[1, 3];
    static private string procurar;
    
    static void CriarContas()
    {
        if (add >= contas.GetLength(0))
        {
            string[,] manage = new string[add + 1, 3];

            for (int lin = 0; lin < add; lin++)
            {
                manage[lin, 0] = contas[lin, 0];
                manage[lin, 1] = contas[lin, 1];
                manage[lin, 2] = contas[lin, 2];
            }

            contas = manage;
        }

        Console.WriteLine("Insira o nome da conta");
        contas[add, 0] = Console.ReadLine();
        Console.WriteLine("Insira o numero da conta");
        contas[add, 1] = Console.ReadLine();

        contas[add, 2] = "0";

        add++;

    }
    static void ShowAccountsDetails ()
    {
        int tries;
        int op;
        tries = 0;
        for (int lin = 0; lin < contas.GetLength(0); lin++)
        {
            if (procurar == contas[lin, 0])
            {
                do
                {
                    Console.WriteLine(contas[lin, 0] + " " + contas[lin, 1]);
                    Console.WriteLine();
                    Console.WriteLine("1 - transferir");
                    Console.WriteLine("2 - sair");
                    op = int.Parse(Console.ReadLine());

                    if (op != 2)
                    {
                        Transfer();
                        return;
                    }
                    else
                    {
                        return;
                    }

                } while (true); 
            }
            if (tries == contas.GetLength(0))
            {
                Console.WriteLine("Essa conta não existe!");
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadKey();
                Showaccounts();
            }
            tries++;
        }

    }
    static void Showaccounts()
    {
        string op;
        for (int lin = 0; lin < contas.GetLength(0); lin++)
        {
            Console.WriteLine(contas[lin, 0]);
            
        }
        Console.WriteLine();
        Console.WriteLine("Qual conta deseja selecionar?  (caso deseje retornar ao menu inicial digite \"sair\")");
        procurar = Console.ReadLine();
        if (procurar != "sair")
        {
            ShowAccountsDetails();
        }
        else
        {
            return;
        }

    }
    static void Deposit()
    {

        Console.WriteLine("Quanto deseja depositar?:");
        OwnAccount[0, 2] = Console.ReadLine();

        Console.WriteLine("Deposito realizado com sucesso!");
        Console.WriteLine();
        Console.WriteLine("Saldo bancario: "+ OwnAccount[0, 2]+ "$");

    }
    static void withdraw()
    {
        
        bool checkl;
        double saque, cal;
        string op;

        do
        {

            checkl = false;

            Console.WriteLine("Qual o valor que deseja sacar: ");
            saque = double.Parse(Console.ReadLine());

            if (saque <= double.Parse(OwnAccount[0, 2]))
            {
                cal = double.Parse(OwnAccount[0, 2]) - saque;
                OwnAccount[0, 2] = cal.ToString();

                Console.WriteLine("Saque realizado com sucesso!");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Sem dinheiro o suficente!");
                Console.WriteLine("Tentar novamente? \"S/N\"");
                op = Console.ReadLine();

                if (op == "s")
                {
                    checkl = true;

                }

            }

        } while (checkl);

        
    }
    static void Transfer()
    {
        
        string op;
        bool check = false;
        int trans, transcal, tries;
        tries = 0;
        
        for (int lin = 0; lin < contas.GetLength(0); lin++)
        {
            if (procurar == contas[lin, 0])
            {
                do
                {
                    check = false;


                    Console.WriteLine("Qual o valor desejar tranferir: ");
                    trans = int.Parse(Console.ReadLine());

                    if (trans <= int.Parse(OwnAccount[0, 2]))
                    {
                        transcal = int.Parse(OwnAccount[0, 2]) - trans;
                        OwnAccount[0, 2] = transcal.ToString();

                        transcal = 0;

                        transcal = int.Parse(contas[lin, 2]) + trans;
                        contas[lin, 2] = transcal.ToString();

                        Console.WriteLine();
                        Console.WriteLine("Transferencia realizada com sucessos!");

                    }
                    else
                    {
                        Console.WriteLine("Dinheiro insuficiente! deseja tentar outra vez? \"S/N\"");
                        op = Console.ReadLine();
                        if (op == "s")
                        {
                            check = true;
                        }
                    }

                } while (check);
            }
            if (tries == contas.GetLength(0))
            {
                Console.WriteLine("essa conta não existe");
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadKey();
            }
            tries++;
        }
    }

    private static void Main(string[] args)
    {
        OwnAccount[0, 2] = "0";
        string op;
        do
        {
            Console.WriteLine("╔══════════════════════════╗");
            Console.Write("║                          ║                        saldo: " + OwnAccount[0, 2]+"$");
            Console.WriteLine();
            Console.WriteLine("║                          ║");
            Console.WriteLine("║       BANCO DO LD        ║");
            Console.WriteLine("║                          ║");
            Console.WriteLine("║                          ║");
            Console.WriteLine("╚══════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("1 - Mostrar contas.");
            Console.WriteLine("2 - Adicionar conta.");
            Console.WriteLine("3 - Depositar.");
            Console.WriteLine("4 - Sacar.");
            Console.WriteLine("5 - sair");
            Console.WriteLine();

            op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    Showaccounts();
                    break;
                case "2":
                    CriarContas();
                    break;
                case "3":
                    Deposit();
                    break;
                case "4":
                    withdraw();
                    break;
                default:
                    break;
            }
            if (op != "5")
            {
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadKey();
                Console.Clear();
            }
        } while (op != "6");
        
    }
}
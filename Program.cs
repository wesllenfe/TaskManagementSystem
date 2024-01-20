using TaskModel = TaskManagementSystem.Models.Task;
using TaskService = TaskManagementSystem.Services.TaskService;
using System;

class Program
{
    static void Main()
    {
        var taskService = new TaskService();

        while (true)
        {
            Console.WriteLine("1. Listar Tarefas");
            Console.WriteLine("2. Adicionar Tarefa");
            Console.WriteLine("3. Atualizar Tarefa");
            Console.WriteLine("4. Excluir Tarefa");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListarTarefas(taskService);
                    break;

                case "2":
                    AdicionarTarefa(taskService);
                    break;

                case "3":
                    AtualizarTarefa(taskService);
                    break;

                case "4":
                    ExcluirTarefa(taskService);
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Por favor, informe um número entre 0 e 4.");
                    break;
            }
        }
    }

    static void ListarTarefas(TaskService taskService)
    {
        var tasks = taskService.GetAllTasks();
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id}. {task.Title} - {(task.IsCompleted ? "Concluída" : "Pendente")}");
        }
    }

    static void AdicionarTarefa(TaskService taskService)
    {
        Console.Write("Digite o título da tarefa: ");
        string title = Console.ReadLine();

        Console.Write("Digite a descrição da tarefa: ");
        string description = Console.ReadLine();

        var newTask = new TaskModel { Title = title, Description = description };
        taskService.AddTask(newTask);

        Console.WriteLine("Tarefa adicionada com sucesso!");
    }

    static void AtualizarTarefa(TaskService taskService)
    {
        Console.Write("Digite o ID da tarefa que deseja atualizar: ");
        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            var taskToUpdate = taskService.GetTaskById(taskId);

            if (taskToUpdate != null)
            {
                Console.Write("Digite o novo título da tarefa: ");
                taskToUpdate.Title = Console.ReadLine();

                Console.Write("Digite a nova descrição da tarefa: ");
                taskToUpdate.Description = Console.ReadLine();

                Console.Write("A tarefa foi concluída? (S/N): ");
                taskToUpdate.IsCompleted = Console.ReadLine().Trim().ToUpper() == "S";

                taskService.UpdateTask(taskToUpdate);
                Console.WriteLine("Tarefa atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void ExcluirTarefa(TaskService taskService)
    {
        Console.Write("Digite o ID da tarefa que deseja excluir: ");
        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            var taskToDelete = taskService.GetTaskById(taskId);

            if (taskToDelete != null)
            {
                taskService.DeleteTask(taskId);
                Console.WriteLine("Tarefa excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }
}
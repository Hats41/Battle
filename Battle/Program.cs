using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Spectre.Console;
using System;
using System.Drawing;
using System.Threading;


class UndertaleAsciiMenu
{
    static int selectedIndex = 0;
    static IWavePlayer outputDevice;
    static AudioFileReader audioFile;
    static void Main()
    {
        Console.Title = "UNDERTALE - ASCII MENU";
        Console.CursorVisible = false;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
         try
        {
            audioFile = new AudioFileReader("C:/Users/Javier/Downloads/Undertale OST.mp3") { Volume = 0.2f };
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reproduciendo audio: " + ex.Message);
            Thread.Sleep(2000);
        }
        DrawStaticHeader();
        Door();
        MenuPainting4();
        MenuPainting3();
        MenuPainting2();
        MenuPainting();
        ShowMenu();
    }

    static void DrawStaticHeader()
    {
        int centerX = Console.WindowWidth / 2;
        int artStartY = 16;

        string[] asciiArt =
        {
            "█▀█ █▄▄ ▄▄▄ ▄▄▄ ▄▄▄                      █   █ █   ▄█  █▀█                           ▄█  █▀█ █ █▀▀ ▄█ ",
            "█   █ █ ▄▄█ █ ▀ ▄▄█                      █   █ █    █  ▀▀█                            █  █ █   ▀▀▄  █ ",
            "█▄█ █ █ █▄█ █   █▄█                      █▄▄  █    ▄█▄ ▄▄▀                           ▄█▄ █▄█ █ █▄█ ▄█▄",
        };

        string[] asciiArt2 =
        {
            "▀█▀ █▄▄ ▄▄▄   █▀▀ ▄▄    ▄                                                                              ",
            " █  █ █ █▄█   █▀▀ █ █ █▀█                                                                              ",
            " █  █ █ █▄▄   █▄▄ █ █ █▄█                                                                              "
        };

        foreach (string line in asciiArt)
        {
            Console.SetCursorPosition(centerX - line.Length / 2, artStartY++);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(line);
        }

        foreach (string line in asciiArt2)
        {
            Console.SetCursorPosition(centerX - line.Length / 2, artStartY++ + 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(line);
        }
    }

    static void ShowMenu()
    {
        while (true)
        {
            DrawMenuOptions();
            HandleInput(); 
        }
    }

    static void DrawMenuOptions()
    {
        int centerX = Console.WindowWidth / 2;

        string[] continueAscii = {
            "█▀█ ▄▄▄ ▄▄  ▄█▄  ▀  ▄▄  ▄ ▄ ▄▄▄",
            "█   █ █ █ █  █  ▀█  █ █ █ █ █▄█",
            "█▄█ █▄█ █ █  █▄ ▄█▄ █ █ ▀▄█ █▄▄"
        };

        string[] resetAscii = {
            "█▀▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄█▄",
            "█▀▄ █▄█ █▄▄ █▄█  █",
            "█ █ █▄▄ ▄▄█ █▄▄  █▄"
        };

        int optionY = 30;
        int spacing = 12;
        int maxLineLength = Math.Max(continueAscii[0].Length, resetAscii[0].Length);

        for (int i = 0; i < 3; i++)
        {
            // Borrar líneas anteriores (limpieza)
            Console.SetCursorPosition(0, optionY + i);
            Console.Write(new string(' ', Console.WindowWidth));

            // Imprimir Continue
            Console.SetCursorPosition(centerX - maxLineLength - spacing, optionY + i);
            string color = selectedIndex == 0 ? "#ffcc00" : "white";
            AnsiConsole.Markup($"[{color}]{continueAscii[i]}[/]");

            // Imprimir Reset
            Console.SetCursorPosition(centerX + spacing, optionY + i);
            string color2 = selectedIndex == 1 ? "#ffcc00" : "white";
            AnsiConsole.Markup($"[{color2}]{resetAscii[i]}[/]");
        }

        Console.ResetColor();
    }
    static void Door()
    {
        int centerX = Console.WindowWidth / 2;
        int artStartY = 0;
                
        string[] asciiArt =
        {
            "           █ █ █ █ █                                █ █ █ █ █           ",
            "           █ █ █ █ █                                █ █ █   █           ",
            "           █ █ █ █ █                                █ █ █ █ █           ",
            "           █ █ █ █ █                                █ █ █ █ █           ",
            "██████████ █ █   █ █                                █ █ █ █ █ ██████████",
            "  ▄▄ ▄     █ █   █ █                                █ █ █   █     ▄▄ ▄  ",
            "           █ █   █ █                                █ █ █   █           ",
            "  ██ █     █ █   █ █                                █ █ █   █     ██ █  ",
            "  ██ █     ▄▄▄▄▄▄▄ █                                █ ▄▄▄▄▄▄▄     ██ █  ",
            "  ██ █      ▀▀▀▀▀  ▀                                ▀  ▀▀▀▀▀      ██ █  ",
            "  ▀▀ ▀   ▄██▄▀▀▀▄██▄  ▄▄  ▄   ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄     ▄██▄▀▀▀▄██▄   ▀▀ ▀  ",
            "  ▀▀ ▀   ▀▀▀▀▀▀▀▀▀▀▀▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▀▀▀▀▀▀▀▀▀▀   ▀▀ ▀  ",                          
            "▄██▀▀▀▀    ▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄    ▀▀▀▀██▄",

        };
        string color2 = "#643060";
        foreach (string line in asciiArt)
        {
            Console.SetCursorPosition(centerX - line.Length / 2, artStartY++);
            AnsiConsole.Markup($"[{color2}]{line}[/]");
        }
    }
    static void MenuPainting()
    {
        int centerX = Console.WindowWidth / 2;
        int artStartY = 44;

        string[] asciiArt =
        {
            "███████████████████████",
            "█████████████████████████████",
            "█████████████████████████████████",
            "█████████████████████████████████",
            "█████████████████████████████",
            "███████████████████████",
            
        };
        string color2 = "#10803d";
        foreach (string line in asciiArt)
        {
            Console.SetCursorPosition(centerX - line.Length / 2, artStartY++);
            AnsiConsole.Markup($"[{color2}]{line}[/]");
        }
    }

    static void MenuPainting2()
    {
        int centerX = Console.WindowWidth / 2;
        int artStartY = 43;

        string[] asciiArt =
        {
            "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄",
            "███████████████████████████████████████",
            "███████████████████████████████████████████",
            "█████████████████████████████████████████████",
            "███████████████████████████████████████████████",
            "█████████████████████████████████████████████████",
            "█████████████████████████████████████████████████",
            "███████████████████████████████████████████████",
            "█████████████████████████████████████████████",
            "███████████████████████████████████████████",
            "███████████████████████████████████████",
            "█████████████████████████████████",
            "█████████████████████████",
            "█████████████████"
        };
        string color2 = "#9c98b1"; 
        foreach (string line in asciiArt)
        {
            Console.SetCursorPosition(centerX - line.Length / 2, artStartY++);
            AnsiConsole.Markup($"[{color2}]{line}[/]");
        }

    }
    static void MenuPainting3()
    {
        int centerX = Console.WindowWidth / 2;
        int artStartY = 43;
        
        string[] asciiArt =
        {
            "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄",
            "███████████████████████████████████████████████████████████████████",
            "███████████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████████████████",
            "███████████████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████████████████████",
            "███████████████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████████████████",
            "███████████████████████████████████████████████████████████████████████",
            "███████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████",
            "█████████████████████████████████████████████"
        };
        string color2 = "#4d4b60";
        foreach (string line in asciiArt)
        {
            Console.SetCursorPosition(centerX - line.Length / 2, artStartY++);
            AnsiConsole.Markup($"[{color2}]{line}[/]");
        }

    }
    static void MenuPainting4()
    {
        int centerX = Console.WindowWidth / 2;
        int artStartY = 43;
        
        string[] asciiArt =
        {
            "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄",
            "███████████████████████████████████████████████████████████████████████████████████████",
            "███████████████████████████████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████████████████████████████████████",
            "███████████████████████████████████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████████████████████████████████████████",
            "███████████████████████████████████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████████████████████████████████████",
            "███████████████████████████████████████████████████████████████████████████████████████████",
            "███████████████████████████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████████████████",
            "█████████████████████████████████████████████████████████████████"
        };
        string color2 = "#2e2d38";
        foreach (string line in asciiArt)
        {
            Console.SetCursorPosition(centerX - line.Length / 2, artStartY++);
            AnsiConsole.Markup($"[{color2}]{line}[/]");
        }

    }
    static void HandleInput()
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.LeftArrow:
            case ConsoleKey.UpArrow:
                selectedIndex = (selectedIndex == 0) ? 1 : 0;
                break;
            case ConsoleKey.RightArrow:
            case ConsoleKey.DownArrow:
                selectedIndex = (selectedIndex == 1) ? 0 : 1;
                break;
            case ConsoleKey.Z:
                ExecuteOption();
                break;
        }
    }

    static void ExecuteOption()
    {
        int messageY = 30;
        Console.SetCursorPosition(0, messageY);
        Console.Write(new string(' ', Console.WindowWidth));

        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, messageY);
        Console.ForegroundColor = ConsoleColor.Gray;

        if (selectedIndex == 0)
        {
            Console.Write("Iniciando batalla...");
        }
        else
        {
            Console.Write("Reiniciando juego...");
        }

        Console.ResetColor();
        Thread.Sleep(1500);

        // Limpiar mensaje sin afectar el resto
        Console.SetCursorPosition(0, messageY);
        Console.Write(new string(' ', Console.WindowWidth));
    }

}

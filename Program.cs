using System;
using System.ComponentModel;

/*Prikladan oblikovni obrazac je Composite.

Struktura klasa:

Component(Komponenta):

FileComponent - Apstraktna klasa za sve konkretne komponente (datoteke i direktorije).
void Display() -Metoda koja se koristi za prikaz informacija o datoteci ili direktoriju.

Leaf (List):
File - Konkretna klasa koja predstavlja konkretan list u Composite pattern-u, odnosno pojedinacnu datoteku.
void Display() -Implementacija metode za prikaz informacija o datoteci.

Composite (Sastav):

Directory - Konkretna klasa koja predstavlja direktorij u Composite pattern-u, odnosno sadrzi kolekciju podkomponenata koje mogu biti i same datoteke ili direktoriji.
void Add(FileComponent component) -Metoda za dodavanje podkomponenti (datoteka ili direktorija) u direktorij.
void Remove(FileComponent component) - Metoda za uklanjanje podkomponenti iz direktorija.
void Display() - Implementacija metode za prikaz informacija o direktoriju.*/




public abstract class FileComponent
{
    public abstract void Display();
}


public class File : FileComponent
{
    private string _name;

    public File(string name)
    {
        _name = name;
    }

    public override void Display()
    {
        Console.WriteLine($"File: {_name}");
    }
}

public class Directory : FileComponent
{
    private string _name;
    private List<FileComponent> _components = new List<FileComponent>();

    public Directory(string name)
    {
        _name = name;
    }

    public void Add(FileComponent component)
    {
        _components.Add(component);
    }

    public void Remove(FileComponent component)
    {
        _components.Remove(component);
    }

    public override void Display()
    {
        Console.WriteLine($"Directory: {_name}");

        foreach (var component in _components)
        {
            component.Display();
        }
    }
}

class Program
{
    static void Main()
    {
        var file1 = new File("Zapis.txt");
        var file2 = new File("kodovi.txt");
        var directory1 = new Directory("Slike");
        directory1.Add(file1);
        directory1.Add(file2);

        var file3 = new File("novi.txt");
        var directory2 = new Directory("Videi");
        directory2.Add(file3);

        var rootDirectory = new Directory("Root");
        rootDirectory.Add(directory1);
        rootDirectory.Add(directory2);

        
        rootDirectory.Display();
    }
}


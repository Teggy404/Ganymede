using System;

namespace Ganymede.Core;

public interface IEditRule
{
    string Name(); 
    string Apply(string image);
}

public interface ICommand
{
    void Execute();
    void Undo();
}


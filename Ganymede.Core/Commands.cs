using System;
using System.Runtime.CompilerServices;

namespace Ganymede.Core;

public class AddEditCommand : ICommand
{
    private readonly IEditRule _edit;
    private readonly ImageProcessor _imageProc;
    private readonly int _index;

    public AddEditCommand(IEditRule edit, ImageProcessor imageProc, int index)
    {
        _edit = edit;
        _imageProc = imageProc;
        _index = index;
    }

    public void Execute() => _imageProc.Insert(_index, _edit);
    public void Undo() => _imageProc.RemoveAt(_index);
}

public class RemoveEditCommand : ICommand
{
    private IEditRule? _removedEdit;
    private readonly ImageProcessor _imageProc;
    private readonly int _index;

    public RemoveEditCommand(IEditRule edit, ImageProcessor imageProc, int index)
    {
        _imageProc = imageProc;
        _index = index;
    }

    public void Execute()
    {
        _removedEdit = _imageProc.Edits[_index];
        _imageProc.RemoveAt(_index);
    }

    public void Undo()
    {
        if(_removedEdit != null)
            _imageProc.Insert(_index, _removedEdit);
    }
}

public class ReplaceEditCommand : ICommand
{
    private IEditRule? _previousEdit;
    private readonly IEditRule _newEdit;
    private readonly ImageProcessor _imageProc;
    private readonly int _index;

    public ReplaceEditCommand(IEditRule edit, ImageProcessor imageProc, int index)
    {
        _newEdit = edit;
        _imageProc = imageProc;
        _index = index;
    }

    public void Execute()
    {
        _previousEdit = _imageProc.Edits[_index];
        _imageProc.Replace(_index, _newEdit);
    }

    public void Undo()
    {
        if(_previousEdit != null)
            _imageProc.Replace(_index, _previousEdit);
    }
}
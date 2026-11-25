using System;
using System.Data;
using System.Diagnostics.Contracts;

namespace Ganymede.Core;

public class ImageProcessor
{
    private readonly List<IEditRule> _edits = new();
    private readonly string _image = "";
    
    public IReadOnlyList<IEditRule> Edits => _edits;
    public ImageProcessor(string image) => _image = image;

    public void Insert(int index, IEditRule rule) => _edits.Insert(index, rule);
    public void RemoveAt(int index) => _edits.RemoveAt(index);
    public void Replace(int index, IEditRule rule) => _edits[index] = rule;

    public string Process()
    {
        var image = _image; 
        foreach(var rule in _edits)
            image = rule.Apply(image);
        return image;
    }
}

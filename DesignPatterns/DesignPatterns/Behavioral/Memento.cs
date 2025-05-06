

namespace DesignPatterns.Behavioral;

// Memento
class TextEditorMemento
{
    public string Content { get; }
    public TextEditorMemento(string content) => Content = content;
}

// Originator
class TextEditor
{
    private string _content = "";
    public void Write(string text) => _content += text;
    public string Read() => _content;
    public TextEditorMemento Save() => new TextEditorMemento(_content);
    public void Restore(TextEditorMemento memento) => _content = memento.Content;
}

// Caretaker
class EditorHistory
{
    private Stack<TextEditorMemento> _history = new();
    public void Save(TextEditor editor) => _history.Push(editor.Save());
    public void Undo(TextEditor editor) { if (_history.Count > 0) editor.Restore(_history.Pop()); }
}


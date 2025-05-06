
namespace DesignPatterns.Structural;

// Flyweight: Shared Formatting Attributes
public class TextStyle
{
    public string FontFamily { get; }
    public int FontSize { get; }
    public string Color { get; }

    public TextStyle(string fontFamily, int fontSize, string color)
    {
        FontFamily = fontFamily;
        FontSize = fontSize;
        Color = color;
    }

    public void Display(string character, int positionX, int positionY)
    {
        Console.WriteLine($"Character: {character}, Font: {FontFamily}, Size: {FontSize}, Color: {Color}, Position: ({positionX}, {positionY})");
    }
}

// Flyweight Factory: Manages TextStyle instances
public class TextStyleFactory
{
    private readonly Dictionary<string, TextStyle> _textStyles = new();

    public TextStyle GetTextStyle(string fontFamily, int fontSize, string color)
    {
        string key = $"{fontFamily}-{fontSize}-{color}";
        if (!_textStyles.ContainsKey(key))
        {
            _textStyles[key] = new TextStyle(fontFamily, fontSize, color);
        }
        return _textStyles[key];
    }
}

// Context: Unique Data for Each Character
public class Character
{
    public string Content { get; }
    public int PositionX { get; }
    public int PositionY { get; }
    private readonly TextStyle _textStyle;

    public Character(string content, int positionX, int positionY, TextStyle textStyle)
    {
        Content = content;
        PositionX = positionX;
        PositionY = positionY;
        _textStyle = textStyle;
    }

    public void Display() => _textStyle.Display(Content, PositionX, PositionY);
}

// Client: Document
public class Document
{
    private readonly List<Character> _characters = new();
    private readonly TextStyleFactory _textStyleFactory = new();

    public void AddCharacter(string content, int positionX, int positionY, string fontFamily, int fontSize, string color)
    {
        TextStyle textStyle = _textStyleFactory.GetTextStyle(fontFamily, fontSize, color);
        _characters.Add(new Character(content, positionX, positionY, textStyle));
    }

    public void Render()
    {
        foreach (var character in _characters)
        {
            character.Display();
        }
    }
}

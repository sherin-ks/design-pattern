using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral;

// Iterator Interface
interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Concrete Iterator
class SongIterator : IIterator<string>
{
    private List<string> _songs;
    private int _position = 0;

    public SongIterator(List<string> songs) { _songs = songs; }
    public bool HasNext() => _position < _songs.Count;
    public string Next() => _songs[_position++];
}

// Aggregate
class Playlist
{
    private List<string> _songs = new();
    public void AddSong(string song) => _songs.Add(song);
    public IIterator<string> GetIterator() => new SongIterator(_songs);
}


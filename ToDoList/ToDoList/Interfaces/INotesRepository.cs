using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Interfaces
{
    public interface INotesRepository
    {
        Task<IEnumerable<Note>> GetNotesAsync();
        Task<Note> GetNoteByIdAsync(int noteId);
        Task<bool> AddNoteAsync(Note note);
        Task<bool> UpdateNoteAsync(Note note);
        Task<bool> RemoveNoteAsync(int noteId);
        Task<IEnumerable<Note>> QueryNoteAsync(Func<Note, bool> predicate);
    }
}
